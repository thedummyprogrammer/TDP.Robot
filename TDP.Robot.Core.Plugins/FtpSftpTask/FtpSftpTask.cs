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
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TDP.Robot.Core;
using TDP.Robot.Core.DynamicData;
using TDP.Robot.Core.Logging;

namespace TDP.Robot.Plugins.Core.FtpSftpTask
{
    [Serializable]
    public class FtpSftpTask : IterationTask
    {
        private void BuildRemotePath(FtpSftpClient fileTransferClient, string remotePath, bool skipLastSegment)
        {
            List<string> PathItems = FtpSftpTaskCommon.SplitRemotePath(remotePath);

            if (PathItems.Count > 0)
            {
                StringBuilder FullPath = new StringBuilder();
                for (int i = 0; i < PathItems.Count - 1; i++)
                {
                    string Item = PathItems[i];
                    if (!string.IsNullOrEmpty(Item))
                    {
                        FullPath.Append($"/{Item}");
                        string FullPathString = FullPath.ToString();
                        if (!fileTransferClient.RemoteDirectoryExists(FullPathString))
                            fileTransferClient.RemoteCreateDirectory(FullPathString);
                    }

                    if (skipLastSegment && (i == (PathItems.Count - 1)))
                        break;
                }
            }
        }

        private void BuildLocalPath(FtpSftpClient fileTransferClient, string localPath, bool skipLastSegment)
        {
            List<string> PathItems = FtpSftpTaskCommon.SplitLocalPath(localPath);

            if (PathItems.Count > 0)
            {
                StringBuilder FullPath = new StringBuilder();
                for (int i = 0; i < PathItems.Count - 1; i++)
                {
                    string Item = PathItems[i];
                    if (!string.IsNullOrEmpty(Item))
                    {
                        if (Regex.Match(Item, @"[A-Z]:", RegexOptions.IgnoreCase).Success)
                        {
                            FullPath.Append($"{Path.DirectorySeparatorChar}{Item}");
                        }
                        else
                        {
                            // TODO: Correct here to use RemoteDirectoryExists & RemoteCreateDirectory?
                            FullPath.Append($"{Path.DirectorySeparatorChar}{Item}");
                            string FullPathString = FullPath.ToString();
                            if (!fileTransferClient.RemoteDirectoryExists(FullPathString))
                                fileTransferClient.RemoteCreateDirectory(FullPathString);
                        }
                    }

                    if (skipLastSegment && (i == (PathItems.Count - 1)))
                        break;
                }
            }
        }

        private void UploadFile(FtpSftpClient fileTransferClient, string localPath, string remotePath, bool overwriteFileIfExists, bool createDirectoryTree)
        {
            if (overwriteFileIfExists || !fileTransferClient.RemoteFileExists(remotePath))
            {
                if (createDirectoryTree)
                    BuildRemotePath(fileTransferClient, remotePath, true);
                    
                fileTransferClient.Upload(localPath, remotePath, overwriteFileIfExists);
            }
        }

        private void UploadDirectory(FtpSftpClient fileTransferClient, string localPath, string remotePath, bool overwriteFileIfExists, bool recursivelyCopyDirectories)
        {
            List<FtpSftpFileInfo> FileList = fileTransferClient.LocalListing(localPath);
            BuildRemotePath(fileTransferClient, remotePath, false);

            foreach (FtpSftpFileInfo FInfo in FileList)
            {
                if (!FInfo.IsDirectory)
                {
                    UploadFile(fileTransferClient, Path.Combine(localPath, FInfo.FileName), FtpSftpTaskCommon.CombineRemotePath(remotePath, FInfo.FileName), overwriteFileIfExists, false);
                }
                else
                {
                    if (recursivelyCopyDirectories)
                        UploadDirectory(fileTransferClient, Path.Combine(localPath, FInfo.FileName), FtpSftpTaskCommon.CombineRemotePath(remotePath, FInfo.FileName), overwriteFileIfExists, recursivelyCopyDirectories);
                }
            }
        }

        private void DownloadFile(FtpSftpClient fileTransferClient, string localPath, string remotePath, bool overwriteFileIfExists, bool createDirectoryTree)
        {
            if (overwriteFileIfExists || !fileTransferClient.LocalFileExists(localPath))
            {
                if (createDirectoryTree)
                    BuildLocalPath(fileTransferClient, localPath, true);
                fileTransferClient.Download(localPath, remotePath);
            }
        }

        private void DownloadDirectory(FtpSftpClient fileTransferClient, string localPath, string remotePath, bool overwriteFileIfExists, bool recursivelyCopyDirectories)
        {
            List<FtpSftpFileInfo> FileList = fileTransferClient.LocalListing(remotePath);
            BuildLocalPath(fileTransferClient, remotePath, false);

            foreach (FtpSftpFileInfo FInfo in FileList)
            {
                if (!FInfo.IsDirectory)
                {
                    DownloadFile(fileTransferClient, localPath, remotePath, overwriteFileIfExists, false);
                }
                else
                {
                    if (recursivelyCopyDirectories)
                        DownloadDirectory(fileTransferClient, localPath, remotePath, overwriteFileIfExists, recursivelyCopyDirectories);
                }
            }
        }

        private void ManageCopyItem(FtpSftpClient fileTransferClient, FtpSftpCopyItem copyItem, IPluginInstanceLogger logger)
        {
            if (copyItem.LocalToRemote)
            {
                if (fileTransferClient.LocalIsDirectory(copyItem.LocalPath))
                {
                    logger.Info($"Copying directory {copyItem.LocalPath} to {copyItem.RemotePath}...");
                    UploadDirectory(fileTransferClient, copyItem.LocalPath, copyItem.RemotePath, copyItem.OverwriteFileIfExists, copyItem.RecursivelyCopyDirectories);
                }
                else
                {
                    logger.Info($"Copying file {copyItem.LocalPath} to {copyItem.RemotePath}...");
                    UploadFile(fileTransferClient, copyItem.LocalPath, copyItem.RemotePath, copyItem.OverwriteFileIfExists, true);
                }
            }
            else
            {
                if (fileTransferClient.RemoteIsDirectory(copyItem.LocalPath))
                {
                    logger.Info($"Copying directory {copyItem.RemotePath} to {copyItem.LocalPath}...");
                    DownloadDirectory(fileTransferClient, copyItem.LocalPath, copyItem.RemotePath, copyItem.OverwriteFileIfExists, copyItem.RecursivelyCopyDirectories);
                }
                else
                {
                    logger.Info($"Copying file {copyItem.RemotePath} to {copyItem.LocalPath}...");
                    DownloadFile(fileTransferClient, copyItem.LocalPath, copyItem.RemotePath, copyItem.OverwriteFileIfExists, true);
                }
            }
        }

        private void ManageDeleteItem(FtpSftpClient fileTransferClient, FtpSftpDeleteItem deleteItem, IPluginInstanceLogger logger)
        {
            if (fileTransferClient.RemoteDirectoryExists(deleteItem.RemotePath) 
                || fileTransferClient.RemoteFileExists(deleteItem.RemotePath))
            {
                if (fileTransferClient.RemoteIsDirectory(deleteItem.RemotePath))
                {
                    logger.Info($"Deleting directory {deleteItem.RemotePath}...");
                    fileTransferClient.RemoteDirectoryDelete(deleteItem.RemotePath);
                }
                else
                {
                    logger.Info($"Deleting file {deleteItem.RemotePath}...");
                    fileTransferClient.RemoteFileDelete(deleteItem.RemotePath);
                }
            }
        }

        protected override void RunIteration(int currentIteration)
        {
            FtpSftpTaskConfig TConfig = (FtpSftpTaskConfig)_iterationConfig;

            using (FtpSftpClient FileTransferClient = new FtpSftpClient())
            {
                _instanceLogger.Info($"Connecting to host: {TConfig.Host} Port: {TConfig.Port} Username: {TConfig.Username}");
                FileTransferClient.Connect(TConfig.Protocol, TConfig.Host, int.Parse(TConfig.Port), TConfig.Username, TConfig.Password);
                _instanceLogger.Info("Connection established");

                if (TConfig.Command == CommandEnum.Copy)
                {
                    _instanceLogger.Info("Starting copy files...");

                    foreach (FtpSftpCopyItem CopyItem in TConfig.CopyItems)
                    {
                        FtpSftpCopyItem CopyItemCopy = (FtpSftpCopyItem)CoreHelpers.CloneObjects(CopyItem);
                        CopyItemCopy.LocalPath = DynamicDataParser.ReplaceDynamicData(CopyItemCopy.LocalPath, _dataChain, currentIteration);
                        CopyItemCopy.RemotePath = DynamicDataParser.ReplaceDynamicData(CopyItemCopy.RemotePath, _dataChain, currentIteration);
                        ManageCopyItem(FileTransferClient, CopyItemCopy, _instanceLogger);
                    }

                    _instanceLogger.Info("Copy files completed");
                }
                else
                {
                    _instanceLogger.Info("Starting delete files...");

                    foreach (FtpSftpDeleteItem DeleteItem in TConfig.DeleteItems)
                    {
                        FtpSftpDeleteItem DeleteItemCopy = (FtpSftpDeleteItem)CoreHelpers.CloneObjects(DeleteItem);
                        DeleteItemCopy.RemotePath = DynamicDataParser.ReplaceDynamicData(DeleteItemCopy.RemotePath, _dataChain, currentIteration);
                        ManageDeleteItem(FileTransferClient, DeleteItemCopy, _instanceLogger);
                    }

                    _instanceLogger.Info("Delete files completed");
                }
            }
        }
    }
}
