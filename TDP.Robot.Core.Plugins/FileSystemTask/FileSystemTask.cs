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
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDP.BaseServices.Infrastructure.DataValidation;
using TDP.Robot.Core;
using TDP.Robot.Core.DynamicData;
using TDP.Robot.Core.Logging;

namespace TDP.Robot.Plugins.Core.FileSystemTask
{
    [Serializable]
    public class FileSystemTask : IterationTask
    {
        private bool _FilePathExists = false;

        private TimeSpan GetFileTimeThreshold(string filesOlderThanDays, string filesOlderThanHours, string filesOlderThanMinutes)
        {
            int Days = 0;
            if (!DataValidationHelper.IsEmptyString(filesOlderThanDays))
                Days = int.Parse(filesOlderThanDays);

            int Hours = 0;
            if (!DataValidationHelper.IsEmptyString(filesOlderThanHours))
                Hours = int.Parse(filesOlderThanHours);

            int Minutes = 0;
            if (!DataValidationHelper.IsEmptyString(filesOlderThanMinutes))
                Minutes = int.Parse(filesOlderThanMinutes);

            return new TimeSpan(Days, Hours, Minutes, 0);
        }

        private void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs, bool overwriteIfFileExists, TimeSpan fileTimeThreshold)
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

                if ((!File.Exists(tempPath) || (File.Exists(tempPath) && overwriteIfFileExists))
                    && (fileTimeThreshold.Ticks == 0 || file.LastWriteTime < DateTime.Now.Subtract(fileTimeThreshold))
                    )
                {
                    file.CopyTo(tempPath, overwriteIfFileExists);
                }
            }

            // If copying subdirectories, copy them and their contents to new location.
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string tempPath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, tempPath, copySubDirs, overwriteIfFileExists, fileTimeThreshold);
                }
            }
        }

        private void DirectoryDelete(string deletePath, TimeSpan fileTimeThreshold)
        {
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(deletePath);

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + deletePath);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string tempPath = Path.Combine(deletePath, file.Name);

                if (fileTimeThreshold.Ticks == 0 || file.LastWriteTime < DateTime.Now.Subtract(fileTimeThreshold))
                {
                    //logger.Info(this, $"Deleting file {deleteItem.DeletePath}...");
                    File.Delete(tempPath);
                }
            }

            foreach (DirectoryInfo subdir in dirs)
            {
                string tempPath = Path.Combine(deletePath, subdir.Name); 
                DirectoryDelete(tempPath, fileTimeThreshold);
            }
        }

        private void ManageCopyItem(FileSystemTaskCopyItem copyItem, IPluginInstanceLogger logger)
        {
            TimeSpan FileTimeThreshold = GetFileTimeThreshold(copyItem.FilesOlderThanDays, copyItem.FilesOlderThanHours, copyItem.FilesOlderThanMinutes);

            if (Common.IsDirectory(copyItem.SourcePath))
            {
                logger.Info(this, $"Copying directory {copyItem.SourcePath} to {copyItem.DestinationPath}...");

                DirectoryCopy(copyItem.SourcePath, copyItem.DestinationPath, copyItem.RecursivelyCopyDirectories, copyItem.OverwriteFileIfExists, FileTimeThreshold);
            }
            else
            {
                if ((!File.Exists(copyItem.DestinationPath) 
                    || (File.Exists(copyItem.DestinationPath) && copyItem.OverwriteFileIfExists))
                    && (FileTimeThreshold.Ticks == 0 || File.GetLastWriteTime(copyItem.SourcePath) < DateTime.Now.Subtract(FileTimeThreshold))
                    )
                {
                    logger.Info(this, $"Copying file {copyItem.SourcePath} to {copyItem.DestinationPath}...");
                    Directory.CreateDirectory(Path.GetDirectoryName(copyItem.DestinationPath));
                    File.Copy(copyItem.SourcePath, copyItem.DestinationPath, copyItem.OverwriteFileIfExists);
                }
            }
        }

        private void ManageDeleteItem(FileSystemTaskDeleteItem deleteItem, IPluginInstanceLogger logger)
        {
            TimeSpan FileTimeThreshold = GetFileTimeThreshold(deleteItem.FilesOlderThanDays, deleteItem.FilesOlderThanHours, deleteItem.FilesOlderThanMinutes);

            if (Common.IsDirectory(deleteItem.DeletePath))
            {
                if (FileTimeThreshold.Ticks == 0)
                {
                    logger.Info(this, $"Deleting directory {deleteItem.DeletePath}...");
                    Directory.Delete(deleteItem.DeletePath, true);
                }
                else
                { 
                    DirectoryDelete(deleteItem.DeletePath, FileTimeThreshold);
                }
            }
            else
            {
                if (FileTimeThreshold.Ticks == 0 || File.GetLastWriteTime(deleteItem.DeletePath) < DateTime.Now.Subtract(FileTimeThreshold))
                {
                    logger.Info(this, $"Deleting file {deleteItem.DeletePath}...");
                    File.Delete(deleteItem.DeletePath);
                }
            }
        }

        protected override void RunIteration(int currentIteration)
        {
            FileSystemTaskConfig TConfig = (FileSystemTaskConfig)_iterationConfig;

            if (TConfig.Command == FileSystemTaskCommandType.Copy)
            {
                _instanceLogger.Info(this, "Starting copy files...");

                foreach (FileSystemTaskCopyItem CopyItem in TConfig.CopyItems)
                {
                    FileSystemTaskCopyItem CopyItemCopy = (FileSystemTaskCopyItem)CoreHelpers.CloneObjects(CopyItem);
                    CopyItemCopy.SourcePath = DynamicDataParser.ReplaceDynamicData(CopyItemCopy.SourcePath, _dataChain, currentIteration);
                    CopyItemCopy.DestinationPath = DynamicDataParser.ReplaceDynamicData(CopyItemCopy.DestinationPath, _dataChain, currentIteration);
                    CopyItemCopy.FilesOlderThanDays = DynamicDataParser.ReplaceDynamicData(CopyItemCopy.FilesOlderThanDays, _dataChain, currentIteration);
                    CopyItemCopy.FilesOlderThanHours = DynamicDataParser.ReplaceDynamicData(CopyItemCopy.FilesOlderThanHours, _dataChain, currentIteration);
                    CopyItemCopy.FilesOlderThanMinutes = DynamicDataParser.ReplaceDynamicData(CopyItemCopy.FilesOlderThanMinutes, _dataChain, currentIteration);
                    ManageCopyItem(CopyItemCopy, _instanceLogger);
                }

                _instanceLogger.Info(this, "Copy files completed");
            }
            else if (TConfig.Command == FileSystemTaskCommandType.Delete)
            {
                _instanceLogger.Info(this, "Starting delete files...");

                foreach (FileSystemTaskDeleteItem DeleteItem in TConfig.DeleteItems)
                {
                    FileSystemTaskDeleteItem DeleteItemCopy = (FileSystemTaskDeleteItem)CoreHelpers.CloneObjects(DeleteItem);
                    DeleteItemCopy.DeletePath = DynamicDataParser.ReplaceDynamicData(DeleteItemCopy.DeletePath, _dataChain, currentIteration);
                    DeleteItemCopy.FilesOlderThanDays = DynamicDataParser.ReplaceDynamicData(DeleteItemCopy.FilesOlderThanDays, _dataChain, currentIteration);
                    DeleteItemCopy.FilesOlderThanHours = DynamicDataParser.ReplaceDynamicData(DeleteItemCopy.FilesOlderThanHours, _dataChain, currentIteration);
                    DeleteItemCopy.FilesOlderThanMinutes = DynamicDataParser.ReplaceDynamicData(DeleteItemCopy.FilesOlderThanMinutes, _dataChain, currentIteration);
                    ManageDeleteItem(DeleteItemCopy, _instanceLogger);
                }

                _instanceLogger.Info(this, "Delete files completed");
            }
            else
            {
                _instanceLogger.Info(this, "Starting check existence of file/directory...");
                _FilePathExists = false;

                if (File.Exists(TConfig.CheckExistenceFilePath) || Directory.Exists(TConfig.CheckExistenceFilePath))
                {
                    _FilePathExists = true;
                    _instanceLogger.Info(this, $"File/Folder: {TConfig.CheckExistenceFilePath} exists");
                }

                _instanceLogger.Info(this, "Check existence completed");
            }
        }

        protected override void PostIterationSucceded(int currentIteration, ExecResult result, DynamicDataSet dDataSet)
        {
            FileSystemTaskConfig TConfig = (FileSystemTaskConfig)_iterationConfig;

            if (TConfig.Command == FileSystemTaskCommandType.CheckExistence)
            {
                if (_FilePathExists)
                    dDataSet.Add("FilePathExists", 1);
                else
                    dDataSet.Add("FilePathExists", 0);
            }
        }
    }
}
