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
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDP.Robot.Core;
using TDP.Robot.Core.DynamicData;
using TDP.Robot.Core.Logging;

namespace TDP.Robot.Plugins.Core.FileSystemTask
{
    [Serializable]
    public class FileSystemTask : ITask
    {
        public IFolder ParentFolder { get; set; }
        public int ID { get; set; }
        public IPluginInstanceConfig Config { get; set; }

        public List<PluginInstanceConnection> Connections { get; } = new List<PluginInstanceConnection>();

        public void Destroy()
        {
            
        }

        public void Init()
        {
            
        }

        private void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs, bool overwriteIfFileExists)
        {
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();

            // If the destination directory doesn't exist, create it.       
            Directory.CreateDirectory(destDirName);

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string tempPath = Path.Combine(destDirName, file.Name);

                if (!File.Exists(tempPath) || (File.Exists(tempPath) && overwriteIfFileExists))
                    file.CopyTo(tempPath, overwriteIfFileExists);
            }

            // If copying subdirectories, copy them and their contents to new location.
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string tempPath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, tempPath, copySubDirs, overwriteIfFileExists);
                }
            }
        }

        private void ManageCopyItem(FileSystemTaskCopyItem copyItem, IPluginInstanceLogger logger)
        {
            if (Common.IsDirectory(copyItem.SourcePath))
            {
                logger.Info(this, $"Copying directory {copyItem.SourcePath} to {copyItem.DestinationPath}...");
                DirectoryCopy(copyItem.SourcePath, copyItem.DestinationPath, copyItem.RecursivelyCopyDirectories, copyItem.OverwriteFileIfExists);
            }
            else
            {
                if (!File.Exists(copyItem.DestinationPath) 
                    || (File.Exists(copyItem.DestinationPath) && copyItem.OverwriteFileIfExists))
                {
                    logger.Info(this, $"Copying file {copyItem.SourcePath} to {copyItem.DestinationPath}...");
                    Directory.CreateDirectory(Path.GetDirectoryName(copyItem.DestinationPath));
                    File.Copy(copyItem.SourcePath, copyItem.DestinationPath, copyItem.OverwriteFileIfExists);
                }
            }
        }

        private void ManageDeleteItem(FileSystemTaskDeleteItem deleteItem, IPluginInstanceLogger logger)
        {
            if (Common.IsDirectory(deleteItem.DeletePath))
            {
                logger.Info(this, $"Deleting directory {deleteItem.DeletePath}...");
                Directory.Delete(deleteItem.DeletePath, true);
            }
            else
            {
                logger.Info(this, $"Deleting file {deleteItem.DeletePath}...");
                File.Delete(deleteItem.DeletePath);
            }
        }

        public ExecResult Run(DynamicDataChain dataChain, DynamicDataSet lastDynamicDataSet, IPluginInstanceLogger instanceLogger)
        {
            ExecResult Result;
            DateTime StartDateTime = DateTime.Now;

            int ActualIterations = 0;

            try
            {
                if (!Config.DoNotLog)
                    instanceLogger.TaskStarted(this);

                FileSystemTaskConfig TConfig = (FileSystemTaskConfig)Config;
                int IterationsCount = DynamicDataParser.GetIterationCount(TConfig, dataChain, lastDynamicDataSet);


                for (int i = 0; i < IterationsCount; i++)
                {
                    FileSystemTaskConfig ConfigCopy = (FileSystemTaskConfig)CoreHelpers.CloneObjects(Config);
                    DynamicDataParser.Parse(ConfigCopy, dataChain, IterationsCount);

                    if (ConfigCopy.Command == FileSystemTaskCommandType.Copy)
                    {
                        instanceLogger.Info(this, "Starting copy files...");

                        foreach (FileSystemTaskCopyItem CopyItem in ConfigCopy.CopyItems)
                        {
                            FileSystemTaskCopyItem CopyItemCopy = (FileSystemTaskCopyItem)CoreHelpers.CloneObjects(CopyItem);
                            CopyItemCopy.SourcePath = DynamicDataParser.ReplaceDynamicData(CopyItemCopy.SourcePath, dataChain, IterationsCount);
                            CopyItemCopy.DestinationPath = DynamicDataParser.ReplaceDynamicData(CopyItemCopy.DestinationPath, dataChain, IterationsCount);
                            ManageCopyItem(CopyItemCopy, instanceLogger);
                        }

                        instanceLogger.Info(this, "Copy files completed");
                    }
                    else
                    {
                        instanceLogger.Info(this, "Starting delete files...");

                        foreach (FileSystemTaskDeleteItem DeleteItem in ConfigCopy.DeleteItems)
                        {
                            FileSystemTaskDeleteItem DeleteItemCopy = (FileSystemTaskDeleteItem)CoreHelpers.CloneObjects(DeleteItem);
                            DeleteItemCopy.DeletePath = DynamicDataParser.ReplaceDynamicData(DeleteItemCopy.DeletePath, dataChain, IterationsCount);
                            ManageDeleteItem(DeleteItemCopy, instanceLogger);
                        }

                        instanceLogger.Info(this, "Delete files completed");
                    }
                    

                    ActualIterations++;
                }

                DynamicDataSet DDataSet = CommonDynamicData.BuildStandardDynamicDataSet(this, true, 0, StartDateTime, DateTime.Now, ActualIterations);
                Result = new ExecResult(true, DDataSet);

                if (!Config.DoNotLog)
                    instanceLogger.TaskCompleted(this);
            }
            catch (Exception ex)
            {
                if (!Config.DoNotLog)
                    instanceLogger.TaskError(this, ex);

                DynamicDataSet DDataSet = CommonDynamicData.BuildStandardDynamicDataSet(this, false, -1, StartDateTime, DateTime.Now, ActualIterations);
                Result = new ExecResult(false, DDataSet);
            }

            return Result;
        }
    }
}
