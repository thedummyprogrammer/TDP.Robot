/*======================================================================================
    Copyright 2021 by TheDummyProgrammer (https://www.thedummyprogrammer.com)

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
using TDP.BaseServices.Infrastructure.Logging.Abstract;
using TDP.Robot.Core;
using TDP.Robot.Core.DynamicData;
using TDP.Robot.Core.Logging;
using TDP.Robot.Core.Persistence;

namespace TDP.Robot.JobEngineLib
{
    public class JobEngine
    {
        private ILogger _Log;
        private List<IEvent> _Events;
        private List<ITask> _Tasks;
        private string _BasePath;

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
                Common.RootFolder = JobsPersistence.Load(DataPath, new PluginBinder(Common.PluginTypes));
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
            }
            catch (Exception ex)
            {
                _Log.Error("An error occurred while starting JobEngine.", ex);
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
            }
            catch (Exception ex)
            {
                _Log.Error("An error occurred while stopping JobEngine.", ex);
            }
        }

        /*
        public Task StartJob(int taskID)
        {
            ITask TaskObj = _Tasks.Where(T => T.ID == taskID).FirstOrDefault();

            DynamicDataChain DataChain = new DynamicDataChain();
            Task T = ExecuteTask(TaskObj, DataChain, );

            return;
        }
        */
    }
}
