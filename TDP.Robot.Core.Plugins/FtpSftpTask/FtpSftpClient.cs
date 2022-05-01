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

using FluentFTP;
using Renci.SshNet;
using Renci.SshNet.Sftp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TDP.Robot.Plugins.Core.FtpSftpTask
{
    public class FtpSftpClient : IDisposable
    {
        private bool _Disposed;
        private FtpClient _FtpClient;
        private SftpClient _SftpClient;

        public FtpSftpClient()
        {
            
        }

        public void Connect(ProtocolEnum protocol, string host, int port, string username, string password)
        {
            if (protocol == ProtocolEnum.FTP)
            {
                _FtpClient = new FtpClient(host, port, username, password);
                _FtpClient.Connect();
            }
            else
            {
                _SftpClient = new SftpClient(host, port, username, password);
                _SftpClient.Connect();
            }
        }

        public void Disconnect()
        {
            if (_FtpClient != null)
            {
                _FtpClient.Disconnect();
                _FtpClient = null;
            }
            else
            {
                _SftpClient.Disconnect();
                _SftpClient = null;
            }
        }

        public void Upload(string localFile, string remoteFile, bool overwrite)
        {
            if (_FtpClient == null && _SftpClient == null)
                throw new ApplicationException("Method \"Connect\" not called.");

            if (_FtpClient != null)
            {
                FtpRemoteExists ExistOption = overwrite ? FtpRemoteExists.Overwrite : FtpRemoteExists.Skip;
                using (FileStream FStream = new FileStream(localFile, FileMode.Open))
                {
                    _FtpClient.Upload(FStream, remoteFile, ExistOption, true);
                }
            }
            else
            {
                using (FileStream FStream = new FileStream(localFile, FileMode.Open))
                {
                    _SftpClient.UploadFile(FStream, remoteFile, overwrite);
                }
            }
        }

        public void Download(string localFile, string remoteFile)
        {
            if (_FtpClient == null && _SftpClient == null)
                throw new ApplicationException("Method \"Connect\" not called.");

            bool Result = false;

            if (_FtpClient != null)
            {
                using (FileStream FStream = new FileStream(localFile, FileMode.Create))
                {
                    Result = _FtpClient.Download(FStream, remoteFile);
                }
            }
            else
            {
                using (FileStream FStream = new FileStream(localFile, FileMode.Create))
                {
                    _SftpClient.DownloadFile(localFile, FStream);
                }
            }
        }

        public void RemoteCreateDirectory(string remotePath)
        {
            if (_FtpClient == null && _SftpClient == null)
                throw new ApplicationException("Method \"Connect\" not called.");

            if (_FtpClient != null)
            {
                _FtpClient.CreateDirectory(remotePath);
            }
            else
            {
                _SftpClient.CreateDirectory(remotePath);
            }
        }

        public void LocalCreateDirectory(string localPath)
        {
            Directory.CreateDirectory(localPath);
        }

        public bool RemoteFileExists(string remoteFile)
        {
            if (_FtpClient == null && _SftpClient == null)
                throw new ApplicationException("Method \"Connect\" not called.");

            if (_FtpClient != null)
                return _FtpClient.FileExists(remoteFile);
            else
                return _SftpClient.Exists(remoteFile);
        }

        public bool LocalFileExists(string localFile)
        {
            return File.Exists(localFile);
        }

        public bool RemoteDirectoryExists(string remoteDirectory)
        {
            if (_FtpClient == null && _SftpClient == null)
                throw new ApplicationException("Method \"Connect\" not called.");

            if (_FtpClient != null)
                return _FtpClient.DirectoryExists(remoteDirectory);
            else
                return _SftpClient.Exists(remoteDirectory);
        }

        public bool LocalDirectoryExists(string localDirectory)
        {
            return Directory.Exists(localDirectory);
        }

        public void LocalFileDelete(string localFile)
        {
            File.Delete(localFile);
        }

        public void RemoteFileDelete(string remoteFile)
        {
            if (_FtpClient == null && _SftpClient == null)
                throw new ApplicationException("Method \"Connect\" not called.");

            if (_FtpClient != null)
                _FtpClient.DeleteFile(remoteFile);
            else
                _SftpClient.Delete(remoteFile);
        }

        public void LocalDirectoryDelete(string localDirectory)
        {
            Directory.Delete(localDirectory);
        }

        private void SFtpDeleteDirectoryRecursive(SftpClient client, string path)
        {
            foreach (SftpFile file in client.ListDirectory(path))
            {
                if ((file.Name != ".") && (file.Name != ".."))
                {
                    if (file.IsDirectory)
                    {
                        SFtpDeleteDirectoryRecursive(client, file.FullName);
                    }
                    else
                    {
                        client.DeleteFile(file.FullName);
                    }
                }
            }

            client.DeleteDirectory(path);
        }

        public void RemoteDirectoryDelete(string remoteDirectory)
        {
            if (_FtpClient == null && _SftpClient == null)
                throw new ApplicationException("Method \"Connect\" not called.");

            if (_FtpClient != null)
                _FtpClient.DeleteDirectory(remoteDirectory, FtpListOption.Recursive);
            else
            {
                SFtpDeleteDirectoryRecursive(_SftpClient, remoteDirectory);
            }
        }

        public List<FtpSftpFileInfo> RemoteListing(string remotePath)
        {
            if (_FtpClient == null && _SftpClient == null)
                throw new ApplicationException("Method \"Connect\" not called.");

            List<FtpSftpFileInfo> Result = new List<FtpSftpFileInfo>();

            if (_FtpClient != null)
            {
                FtpListItem[] List = _FtpClient.GetListing(remotePath);
                foreach (FtpListItem Item in List)
                {
                    FtpSftpFileInfo FileInfo = new FtpSftpFileInfo(Item.Name, Item.FullName,
                                                                    Item.Type == FtpFileSystemObjectType.File,
                                                                    Item.Type == FtpFileSystemObjectType.Directory,
                                                                    Item.Type == FtpFileSystemObjectType.Link);
                    Result.Add(FileInfo);
                }
            }
            else
            {
                IEnumerable<SftpFile> List = _SftpClient.ListDirectory(remotePath);
                foreach (SftpFile Item in List)
                {
                    FtpSftpFileInfo FileInfo = new FtpSftpFileInfo(Item.Name, Item.FullName,
                                                                    Item.IsRegularFile,
                                                                    Item.IsDirectory,
                                                                    Item.IsSymbolicLink);
                    Result.Add(FileInfo);
                }
            }

            return Result;
        }

        public List<FtpSftpFileInfo> LocalListing(string localPath)
        {
            List<FtpSftpFileInfo> Result = new List<FtpSftpFileInfo>();

            string[] Files = Directory.GetFiles(localPath);
            foreach (string FullPathFileName in Files)
            {
                Result.Add(new FtpSftpFileInfo(Path.GetFileName(FullPathFileName), FullPathFileName, true, false, false));
            }

            string[] Directories = Directory.GetDirectories(localPath);
            foreach (string FullPathDirectoryName in Directories)
            {
                
                List<string> PathItems = FtpSftpTaskCommon.SplitLocalPath(FullPathDirectoryName);
                string DirectoryName = PathItems[PathItems.Count - 1];
                Result.Add(new FtpSftpFileInfo(DirectoryName, FullPathDirectoryName, false, true, false));
            }

            return Result;
        }

        public bool RemoteIsDirectory(string remotePath)
        {
            if (_FtpClient == null && _SftpClient == null)
                throw new ApplicationException("Method \"Connect\" not called.");

            if (_FtpClient != null)
            {
                FtpListItem Info = _FtpClient.GetObjectInfo(remotePath);
                return (Info.Type == FtpFileSystemObjectType.Directory);
            }
            else
            {
                SftpFile Info = _SftpClient.Get(remotePath);
                return (Info.IsDirectory);
            }
        }

        public bool LocalIsDirectory(string localPath)
        {
            return Common.IsDirectory(localPath);
        }


        public void Dispose()
        {
            Dispose(true);
            // Suppress finalization.
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool disposing)
        {
            if (_Disposed)
            {
                return;
            }

            /*
            if (disposing)
            {
                
            }
            */

            try { Disconnect(); } finally { }

            _Disposed = true;
        }
    }
}
