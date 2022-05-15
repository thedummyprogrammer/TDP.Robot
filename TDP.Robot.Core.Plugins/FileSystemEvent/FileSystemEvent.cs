/*======================================================================================
    Copyright 2021 - 2022 by TheDummyProgrammer (https://www.thedummyprogrammer.com)

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
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using TDP.Robot.Core;
using TDP.Robot.Core.DynamicData;
using TDP.Robot.Core.Logging;

namespace TDP.Robot.Plugins.Core.FileSystemEvent
{
    [Serializable]
    public class FileSystemEvent : IEvent
    {
        public IPluginInstanceConfig Config { get; set; }

        public List<PluginInstanceConnection> Connections { get; } = new List<PluginInstanceConnection>();

        public IFolder ParentFolder { get; set; }
        public int ID { get; set; }

        [field: NonSerialized]
        public event EventTriggeredDelegate EventTriggered;

        protected virtual void OnEventTriggered(EventTriggeredEventArgs e)
        {
            EventTriggeredDelegate handler = EventTriggered;
            if (handler != null)
            {
                foreach (EventTriggeredDelegate singleCast in handler.GetInvocationList())
                {
                    ISynchronizeInvoke syncInvoke = singleCast.Target as ISynchronizeInvoke;
                    if ((syncInvoke != null) && (syncInvoke.InvokeRequired))
                        syncInvoke.Invoke(singleCast, new object[] { this, e });
                    else
                        singleCast(this, e);
                }
            }
        }

        [field: NonSerialized]
        private List<FileSystemWatcher> _FileSystemWatchers;

        public void Init()
        {
            FileSystemEventConfig TConfig = (FileSystemEventConfig)Config;

            _FileSystemWatchers = new List<FileSystemWatcher>();
            foreach (FolderToMonitor Folder in TConfig.FoldersToMonitor)
            {
                FileSystemWatcher Watcher = new FileSystemWatcher();
                Watcher.Path = Folder.Path;
                Watcher.IncludeSubdirectories = Folder.MonitorSubFolders;
                
                if (Folder.MonitorAction == MonitorActionType.NewFiles)
                    Watcher.Created += WatcherEvent;
                else if (Folder.MonitorAction == MonitorActionType.ModifiedFiles)
                    Watcher.Changed += WatcherEvent;
                else
                    Watcher.Deleted += WatcherEvent;

                _FileSystemWatchers.Add(Watcher);
            }
        }

        public void Destroy()
        {
            foreach (FileSystemWatcher FWatcher in _FileSystemWatchers)
            {
                FWatcher.Dispose();
            }
        }

        private void WatcherEvent(object sender, FileSystemEventArgs e)
        {
            IPluginInstanceLogger Logger = PluginInstanceLogger.GetLogger(this);

            try
            {
                if (!Config.DoNotLog)
                    Logger.EventTriggered(this);
                DateTime Now = DateTime.Now;
                FileSystemEventConfig TConfig = (FileSystemEventConfig)Config;
                DynamicDataSet DDataSet = CommonDynamicData.BuildStandardDynamicDataSet(this, true, 0, Now, Now, 1);
                
                FileInfo FI = new FileInfo(e.FullPath);
                DDataSet.Add(FileSystemEventCommon.DynDataKeyFullPathName, e.FullPath);
                DDataSet.Add(FileSystemEventCommon.DynDataKeyFileName, e.Name);
                DDataSet.Add(FileSystemEventCommon.DynDataKeyFileNameWithoutExtension, e.Name.Substring(0, e.Name.Length - FI.Extension.Length));
                DDataSet.Add(FileSystemEventCommon.DynDataKeyFileExtension, FI.Extension.Substring(1));
                DDataSet.Add(FileSystemEventCommon.DynDataKeyChangeType, e.ChangeType.ToString());
                
                if (!Config.DoNotLog)
                {
                    Logger.Info(this, $"File detected {e.FullPath}");
                    Logger.EventTriggering(this);
                }
                    
                OnEventTriggered(new EventTriggeredEventArgs(DDataSet, Logger));
            }
            catch (Exception ex)
            {
                if (!Config.DoNotLog)
                    Logger.EventError(this, ex);
            }
        }

        public InstanceExecResult Run(DynamicDataChain dataChain, DynamicDataSet lastDynamicDataSet, IPluginInstanceLogger instanceLogger)
        {
            foreach (FileSystemWatcher Watcher in _FileSystemWatchers)
            {
                Watcher.EnableRaisingEvents = true;
            }

            List<ExecResult> execResults = new List<ExecResult>();
            execResults.Add(new ExecResult(true, null));
            return new InstanceExecResult(execResults);
        }
    }
}
