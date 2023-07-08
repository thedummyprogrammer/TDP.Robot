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
using System.IO;

namespace TDP.Robot.Core.Logging
{
    public class PluginInstanceLogger : IPluginInstanceLogger
    {
        private string _PathFileName;
        private object _LockWriting = new object();

        private static int _InstanceCounter = 0;
        private static object _LockInstanceCounter = new object();

        private static string GetLogFileName(int eventID)
        {
            // You can have the same event trigger multiple times at the same moment.
            // This counter is used to make the log file name unique for each event instance.
            lock (_LockInstanceCounter)
            {
                _InstanceCounter++;
            }

            DateTime Now = DateTime.Now;
            return $"{eventID}_{Now.ToIsoDate().Replace(":", "_")}_{Now.Ticks}_{_InstanceCounter}.log";
        }

        private static IPluginInstanceLogger GetPluginLogger(IPluginInstance plugin)
        {
            string LogPath = Path.Combine(Config.GetLogPath(), plugin.ParentFolder.GetPhysicalFullPath());
            if (!Directory.Exists(LogPath))
            {
                Directory.CreateDirectory(LogPath);
            }

            PluginInstanceLogger PInstanceLogger = new PluginInstanceLogger();
            PInstanceLogger.Init(Path.Combine(LogPath, GetLogFileName(plugin.ID)));

            return PInstanceLogger;
        }

        public static IPluginInstanceLogger GetLogger(IEvent tdrEvent)
        {
            return GetPluginLogger(tdrEvent);
        }

        public static IPluginInstanceLogger GetLogger(ITask task)
        {
            return GetPluginLogger(task);
        }

        private void WriteLine(string text, int position = -1)
        {
            lock (_LockWriting)
            {
                using (StreamWriter File = new StreamWriter(_PathFileName, true))
                {
                    if (position != -1)
                        File.BaseStream.Position = position;

                    File.WriteLine(text);
                }
            }
        }

        private string GetCurrentISODateTime()
        {
            return DateTime.Now.ToIsoDate();
        }

        public void TaskStarting(ITask task)
        {
            WriteLine($"{GetCurrentISODateTime()} - INFO - {task.ID}:{task.Config.Name}:{task.GetType().Name} - Starting...");
        }

        public void TaskStarted(ITask task)
        {
            WriteLine($"{GetCurrentISODateTime()} - INFO - {task.ID}:{task.Config.Name}:{task.GetType().Name} - Started");
        }

        public void TaskCompleted(ITask task)
        {
            WriteLine($"{GetCurrentISODateTime()} - INFO - {task.ID}:{task.Config.Name}:{task.GetType().Name} - Completed");
        }

        public void TaskError(ITask task, Exception ex)
        {
            Error(task, "Task error", ex);
        }

        public void TaskEnded(ITask task)
        {
            WriteLine($"{GetCurrentISODateTime()} - INFO - {task.ID}:{task.Config.Name}:{task.GetType().Name} - Ended");
        }

        public void EventError(IEvent tdrEvent, Exception ex)
        {
            Error(tdrEvent, "Event error", ex);
        }

        public void EventTriggering(IEvent tdrEvent)
        {
            WriteLine($"{GetCurrentISODateTime()} - INFO - {tdrEvent.ID}:{tdrEvent.Config.Name}:{tdrEvent.GetType().Name} - Event triggering");
        }

        public void EventTriggered(IEvent tdrEvent)
        {
            WriteLine($"{GetCurrentISODateTime()} - INFO - {tdrEvent.ID}:{tdrEvent.Config.Name}:{tdrEvent.GetType().Name} - Event triggered");
        }

        public void Error(string text)
        {
            WriteLine($"{GetCurrentISODateTime()} - ERROR - {text}");
        }

        public void Error(string text, Exception ex)
        {
            WriteLine($"{GetCurrentISODateTime()} - ERROR - {text}\n{ex}");
        }

        public void Error(IPluginInstance pluginInstance, string text)
        {
            WriteLine($"{GetCurrentISODateTime()} - ERROR - {pluginInstance.ID}:{pluginInstance.Config.Name}:{pluginInstance.GetType().Name} - {text}");
        }

        public void Error(IPluginInstance pluginInstance, string text, Exception ex)
        {
            WriteLine($"{GetCurrentISODateTime()} - ERROR - {pluginInstance.ID}:{pluginInstance.Config.Name}:{pluginInstance.GetType().Name} - {text}\n{ex}");
        }

        public void Info(string text)
        {
            WriteLine($"{GetCurrentISODateTime()} - INFO - {text}");
        }

        public void Info(string text, Exception ex)
        {
            WriteLine($"{GetCurrentISODateTime()} - INFO - {text}\n{ex}");
        }

        public void Info(IPluginInstance pluginInstance, string text)
        {
            WriteLine($"{GetCurrentISODateTime()} - INFO - {pluginInstance.ID}:{pluginInstance.Config.Name}:{pluginInstance.GetType().Name} - {text}");
        }

        public void Info(IPluginInstance pluginInstance, string text, Exception ex)
        {
            WriteLine($"{GetCurrentISODateTime()} - INFO - {pluginInstance.ID}:{pluginInstance.Config.Name}:{pluginInstance.GetType().Name} - {text}\n{ex}");
        }

        public void Init(string pathFileName)
        {
            _PathFileName = pathFileName;
        }
    }
}
