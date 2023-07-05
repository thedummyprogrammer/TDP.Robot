/*======================================================================================
    Copyright 2021 - 2023 by TheDummyProgrammer (https://www.thedummyprogrammer.com)

    This file is part of The Dummy Programmer Robot.

    The Dummy Programmer Robot is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    The Dummy Programmer Robot is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with The Dummy Programmer Robot.  If not, see <http://www.gnu.org/licenses/>.
======================================================================================*/

using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Net;
using TDP.BaseServices.Infrastructure.Logging.Abstract;
using TDP.Robot.Core;
using TDP.Robot.Core.DynamicData;
using TDP.Robot.Core.Logging;
using TDP.Robot.Core.Persistence;
using TDP.BaseServices.Infrastructure.Logging;
using System.Text;

namespace TDP.Robot.JobEngineLib
{
    public class JobEngine
    {
        private ILogger _Log;
        private List<IEvent> _Events;
        private List<ITask> _Tasks;
        private string _BasePath;

        private System.Timers.Timer _LogCleanTimer;

        private HttpListener _HttpListener;

        private string GetLogPath()
        {
            return Path.Combine(_BasePath, Config.LogPath);
        }

        private string GetLibPath()
        {
            return Path.Combine(_BasePath, Config.LibPath);
        }

        private string GetDataPath()
        {
            return Path.Combine(_BasePath, Config.DataPath);
        }

        private bool LoadJobData()
        {
            bool Result = true;
            string DataPath = GetDataPath();
            _Log.Info($"Loading jobs data from directory: {DataPath}");

            try
            {
                _Log.Info("Loading jobs data...");
                Common.RootFolder = JobsPersistence.LoadXML(DataPath, Common.PluginTypes);
            }
            catch (Exception ex)
            {
                _Log.Error("Error loading data", ex);
                Result = false;
            }

            return Result;
        }

        private List<IEvent> GetEventList(IFolder folder)
        {
            List<IEvent> Events = new List<IEvent>();

            foreach (IPluginInstanceBase PluginInstance in folder)
            {
                if (PluginInstance is IEvent)
                {
                    Events.Add((IEvent)PluginInstance);
                }
                else if (PluginInstance is IFolder)
                {
                    List<IEvent> InnerFolderEvents = GetEventList((IFolder)PluginInstance);
                    Events.AddRange(InnerFolderEvents);
                }
            }

            return Events;
        }

        private List<ITask> GetTaskList(IFolder folder)
        {
            List<ITask> Tasks = new List<ITask>();

            foreach (IPluginInstanceBase PluginInstance in folder)
            {
                if (PluginInstance is ITask)
                {
                    Tasks.Add((ITask)PluginInstance);
                }
                else if (PluginInstance is IFolder)
                {
                    List<ITask> InnerFolderEvents = GetTaskList((IFolder)PluginInstance);
                    Tasks.AddRange(InnerFolderEvents);
                }
            }

            return Tasks;
        }

        private Task ExecuteTask(ITask task, DynamicDataChain dataChain, DynamicDataSet lastDynamicDataSet, IPluginInstanceLogger instanceLogger)
        {
            Task T = new Task(() =>
            {
                ITask TaskCopy = null;
                try
                {
                    TaskCopy = (ITask)CoreHelpers.CloneObjects(task);
                    DynamicDataSet LastDataSetCopy = (DynamicDataSet)CoreHelpers.CloneObjects(lastDynamicDataSet);

                    if (!TaskCopy.Config.DoNotLog)
                        instanceLogger.TaskStarting(TaskCopy);
                    InstanceExecResult InstExecResult = TaskCopy.Run(dataChain, LastDataSetCopy, instanceLogger);
                    if (!TaskCopy.Config.DoNotLog)
                        instanceLogger.TaskEnded(TaskCopy);

                    if (TaskCopy.Connections != null)
                    {
                        foreach (PluginInstanceConnection Connection in TaskCopy.Connections)
                        {
                            if (Connection.Disable)
                                continue;

                            if (Connection.WaitSeconds != null)
                                System.Threading.Thread.Sleep((int)Connection.WaitSeconds * 1000);
                            
                            ITask NextTask = (ITask)Connection.ConnectTo;

                            if (NextTask.Config.Disable)
                                continue;

                            foreach (ExecResult ExecRes in InstExecResult.execResults)
                            {
                                if (Connection.EvaluateExecConditions(ExecRes))
                                {
                                    DynamicDataChain DataChainCopy = (DynamicDataChain)CoreHelpers.CloneObjects(dataChain);
                                    DataChainCopy.Add(TaskCopy.ID, ExecRes.Data);
                                    ExecuteTask(NextTask, DataChainCopy, ExecRes.Data, instanceLogger);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    if (TaskCopy != null)
                        instanceLogger.Error(TaskCopy, "ExecuteTask", ex);
                    else
                        instanceLogger.Error("ExecuteTask: TaskCopy object is null.", ex);
                }
            });
            T.Start();

            if (Config.SerialExecution)
                T.Wait();

            return T;
        }

        private void Plugin_EventTriggered(object sender, EventTriggeredEventArgs e)
        {
            IEvent Event = (IEvent)sender;
            e.Logger.EventTriggered(Event);
            _Log.Info($"Event triggered by object: {Event.ID}:{Event.Config.Name}:{Event.GetType().Name}");

            _Log.Info("Building dynamic data chain");
            DynamicDataChain DataChain = new DynamicDataChain();
            DataChain.Add(Event.ID, e.DynamicData);

            ExecResult ExecResult = new ExecResult(true, e.DynamicData);

            foreach (PluginInstanceConnection Connection in Event.Connections)
            {
                if (Connection.EvaluateExecConditions(ExecResult))
                {
                    ITask TDRTask = (ITask)Connection.ConnectTo;

                    if (!TDRTask.Config.Disable)
                    {
                        _Log.Info($"Calling ExecuteTask for: {TDRTask.ID}:{TDRTask.Config.Name}:{TDRTask.GetType().Name}");
                        ExecuteTask(TDRTask, DataChain, e.DynamicData, e.Logger);
                    }
                    else
                    {
                        _Log.Info($"Task: {TDRTask.ID}:{TDRTask.Config.Name}:{TDRTask.GetType().Name} disabled, skipped");
                    }
                }
            }
        }

        public void Start(string basePath)
        {
            try
            {
                _BasePath = basePath;

                Config.Init();
                Common.Init();

                Core.Config.BasePath = basePath;
                Core.Config.LogPath = Config.LogPath;

                _Log = Common.Log;

                _Log.Info("Starting TDP.Robot.JobEngine...");

                _Log.Info("Loading plugins");
                if (!CoreHelpers.LoadPlugins(GetLibPath(), _Log, Common.PluginTypes, Common.PluginList, Common.PluginDict))
                {
                    _Log.Info("One ore more plugins were not loaded correctly, JobEngine is not working...");
                    return;
                }

                _Log.Info("Loading job data");
                if (!LoadJobData())
                {
                    _Log.Info("Error loading job data, JobEngine is not working...");
                    return;
                }

                Core.CoreHelpers.Plugins = Common.PluginTypes;

                if (Common.RootFolder == null)
                {
                    _Log.Info("There are no jobs to load...");
                    return;
                }

                // Set the timer to clean logs
                if (Config.CleanUpLogsOlderThanHours > 0)
                {
                    try
                    {
                        // Trigger a clean up at service startup
                        _Log.Info("Cleaning up old logs on initialization");
                        CleanUpLog(Config.LogPath, Config.CleanUpLogsOlderThanHours);
                    }
                    catch (Exception ex)
                    {
                        _Log.Error("An error occurred while cleaning up old logs on initialization", ex);
                    }

                    _LogCleanTimer = new System.Timers.Timer();
                    _LogCleanTimer.Interval = new TimeSpan(0, Config.CleanUpLogsIntervalHours, 0, 0).TotalMilliseconds;
                    _LogCleanTimer.Enabled = true;
                    _LogCleanTimer.AutoReset = true;
                    _LogCleanTimer.Elapsed += _LogCleanTimer_Elapsed;
                }

                // Initializes events and tasks
                _Log.Info("Starting events initialization");
                _Events = GetEventList(Common.RootFolder);
                _Events.ForEach(E =>
                {
                    _Log.Info($"Initializing event: {E.ID}:{E.Config.Name}:{E.GetType().Name}");
                    E.EventTriggered += Plugin_EventTriggered;
                    E.Init();
                });

                _Log.Info("Starting tasks initialization");
                _Tasks = GetTaskList(Common.RootFolder);
                _Tasks.ForEach(T =>
                {
                    _Log.Info($"Initializing task: {T.ID}:{T.Config.Name}:{T.GetType().Name}");
                    T.Init();
                });

                _Log.Info("Running events");
                _Events.ForEach(E =>
                {
                    if (!E.Config.Disable)
                    {
                        _Log.Info($"Running event {E.ID}:{E.Config.Name}:{E.GetType().Name}");
                        E.Run(null, null, null);
                    }
                    else
                    {
                        _Log.Info($"Event {E.ID}:{E.Config.Name}:{E.GetType().Name} disabled, skipped");
                    }
                });

                _HttpListener = new HttpListener();
                _HttpListener.Prefixes.Add($"http://localhost:{Config.HttpListenerPort.ToString()}/");
                _HttpListener.Start();
                ReceiveHttpCommand();
                
            }
            catch (Exception ex)
            {
                _Log.Error("An error occurred while starting JobEngine.", ex);
            }
        }

        private void ReceiveHttpCommand()
        {
            _HttpListener.BeginGetContext(new AsyncCallback(_HttpListener_ListenerCallback), _HttpListener);
        }

        private void _HttpListener_ListenerCallback(IAsyncResult result)
        {
            _Log.Info("HttpListener callback started...");

            if (_HttpListener.IsListening)
            {
                HttpListenerContext Context = _HttpListener.EndGetContext(result);
                HttpListenerRequest Request = Context.Request;
                HttpListenerResponse Response = Context.Response;

                _Log.Info("Handling request...");

                if (Request.HasEntityBody)
                {
                    Stream BodyStream = Request.InputStream;
                    Encoding Encoding = Request.ContentEncoding;
                    StreamReader Reader = new StreamReader(BodyStream, Encoding);
                    string BodyContent = Reader.ReadToEnd();

                    bool CommandParsed = true;
                    string Command = string.Empty;
                    int TaskID = int.MinValue;
                    string[] CommandParts = BodyContent.Split(new char[] { '&' });
                    
                    try
                    {
                        foreach (string CommandPart in CommandParts)
                        {
                            string[] CommandParams = CommandPart.Split(new char[] { '=' });

                            if (CommandParams[0].ToLowerInvariant() == "command")
                                Command = CommandParams[1];
                            else if (CommandParams[0].ToLowerInvariant() == "task")
                                TaskID = int.Parse(CommandParams[1]);
                        }
                    }
                    catch
                    {
                        CommandParsed = false;
                    }

                    bool CommandStarted = false;
                    if (CommandParsed)
                    {
                        if (Command.ToLowerInvariant() == "executetask")
                        {
                            CommandStarted = StartJob(TaskID);
                        }
                    }
                    
                    string Result = string.Empty;
                    if (CommandStarted)
                    {
                        Result = $"{{\"Result\":\"ok\"}}";
                        Response.StatusCode = (int)HttpStatusCode.OK;
                    }
                    else
                    {
                        Result = $"{{\"Result\":\"error\"}}";
                        Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    }

                    byte[] OutputBuffer = new byte[] { };

                    Response.ContentType = "application/json";

                    OutputBuffer = Encoding.ASCII.GetBytes(Result);
                    Response.ContentLength64 = OutputBuffer.Length;
                    Stream OutputStream = Response.OutputStream;
                    OutputStream.Write(OutputBuffer, 0, OutputBuffer.Length);
                    OutputStream.Close();
                    

                    Reader.Close();
                    BodyStream.Close();
                }

                ReceiveHttpCommand();
            }

            _Log.Info("HttpListener callback ended.");
        }

        private bool IsDirectoryEmpty(string directoryPath)
        {
            return (Directory.GetFiles(directoryPath).Length == 0 && Directory.GetDirectories(directoryPath).Length == 0);
        }

        private void CleanUpLog(string logPath, int cleanUpLogsOlderThanHours)
        {
            DateTime DateLimit = DateTime.Now.AddHours(-cleanUpLogsOlderThanHours);
            string[] Files = Directory.GetFiles(logPath);
            foreach (string FullPathFileName in Files)
            {
                FileInfo FI = new FileInfo(FullPathFileName);
                if (FI.CreationTime < DateLimit)
                    FI.Delete();
            }

            string[] Directories = Directory.GetDirectories(logPath);
            foreach (string FullPathDirectoryName in Directories)
            {
                CleanUpLog(FullPathDirectoryName, cleanUpLogsOlderThanHours);
                if (IsDirectoryEmpty(FullPathDirectoryName))
                    Directory.Delete(FullPathDirectoryName);
            }
        }

        private void _LogCleanTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                _Log.Info("Cleaning up old logs");
                CleanUpLog(Config.LogPath, Config.CleanUpLogsOlderThanHours);

            }
            catch (Exception ex)
            {
                _Log.Error("An error occurred while cleaning up old logs", ex);
            }
        }

        public void Stop()
        {
            try
            {
                _Log.Info("Destroying events");
                _Events.ForEach(E =>
                {
                    _Log.Info($"Destroying event: {E.ID}:{E.Config.Name}:{E.GetType().Name}");
                    E.Destroy();
                });

                _Log.Info("Destroying tasks");
                _Tasks.ForEach(T =>
                {
                    _Log.Info($"Destroying task: {T.ID}:{T.Config.Name}:{T.GetType().Name}");
                    T.Destroy();
                });

                _HttpListener.Stop();
            }
            catch (Exception ex)
            {
                _Log.Error("An error occurred while stopping JobEngine.", ex);
            }
        }

        public bool StartJob(int taskID)
        {
            _Log.Info($"Requested execution of task: {taskID}");

            try
            {
                DateTime Now = DateTime.Now;
                ITask TaskObj = _Tasks.Where(task => task.ID == taskID).FirstOrDefault();

                if (TaskObj == null)
                {
                    _Log.Info($"The task {taskID} cannot be found.");
                    return false;
                }

                IPluginInstanceLogger Logger = PluginInstanceLogger.GetLogger(TaskObj);
                DynamicDataChain DataChain = new DynamicDataChain();
                DynamicDataSet DDataSet = CommonDynamicData.BuildStandardDynamicDataSet(TaskObj, true, 0, Now, Now, 1);

                Task T = ExecuteTask(TaskObj, DataChain, DDataSet, Logger);

                return true;
            }
            catch (Exception ex)
            {
                _Log.Error("An error occurred while executing the requested task.", ex);
            }
            return false;
        }
    }
}
