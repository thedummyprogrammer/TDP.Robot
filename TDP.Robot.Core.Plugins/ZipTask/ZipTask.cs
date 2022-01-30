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

using ICSharpCode.SharpZipLib.Core;
using ICSharpCode.SharpZipLib.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDP.Robot.Core;
using TDP.Robot.Core.DynamicData;
using TDP.Robot.Core.Logging;

namespace TDP.Robot.Plugins.Core.ZipTask
{
    [Serializable]
    public class ZipTask : ITask
    {
        public IFolder ParentFolder { get; set; }
        public int ID { get; set; }
        public IPluginInstanceConfig Config { get; set; }

        public List<PluginInstanceConnection> Connections { get; } = new List<PluginInstanceConnection>();

        private int ToNumericCompressionLevel(CompressionLevelType compressionLevel)
        {
            if (compressionLevel == CompressionLevelType.Low)
                return 1;
            else if (compressionLevel == CompressionLevelType.Medium)
                return 4;
            else // High
                return 9;
        }

        private void CompressFolder(string path, ZipOutputStream zipStream, int folderOffset, bool skipEmptyFolder)
        {
            string[] Files = Directory.GetFiles(path);
            foreach (string FileName in Files)
            {
                CompressFile(FileName, zipStream, folderOffset);
            }

            // Recursively call CompressFolder on all folders in path
            string[] Folders = Directory.GetDirectories(path);
            foreach (string Folder in Folders)
            {
                CompressFolder(Folder, zipStream, folderOffset, skipEmptyFolder);
            }

            if (Files.Length == 0 && Folders.Length == 0 && !skipEmptyFolder)
            {
                DirectoryInfo FI = new DirectoryInfo(path);
                string EntryName = path.Substring(folderOffset);
                EntryName = ZipEntry.CleanName(EntryName + "/empty.txt");   // It seems the only way to mantain an empty folder...
                ZipEntry NewEntry = new ZipEntry(EntryName);
                NewEntry.DateTime = FI.LastWriteTime;
                zipStream.PutNextEntry(NewEntry);
                zipStream.CloseEntry();
            }
        }


        private void CompressFile(string filePathName, ZipOutputStream zipStream, int folderOffset)
        {
            FileInfo FI = new FileInfo(filePathName);

            // Make the name in zip based on the folder
            string EntryName = filePathName.Substring(folderOffset);

            // Remove drive from name and fix slash direction
            EntryName = ZipEntry.CleanName(EntryName);

            ZipEntry NewEntry = new ZipEntry(EntryName);

            // Note the zip format stores 2 second granularity
            NewEntry.DateTime = FI.LastWriteTime;

            // Specifying the AESKeySize triggers AES encryption. 
            // Allowable values are 0 (off), 128 or 256.
            // A password on the ZipOutputStream is required if using AES.
            //   newEntry.AESKeySize = 256;

            // To permit the zip to be unpacked by built-in extractor in WinXP and Server2003,
            // WinZip 8, Java, and other older code, you need to do one of the following: 
            // Specify UseZip64.Off, or set the Size.
            // If the file may be bigger than 4GB, or you do not need WinXP built-in compatibility, 
            // you do not need either, but the zip will be in Zip64 format which
            // not all utilities can understand.
            //   zipStream.UseZip64 = UseZip64.Off;
            NewEntry.Size = FI.Length;

            zipStream.PutNextEntry(NewEntry);

            // Zip the file in buffered chunks
            // the "using" will close the stream even if an exception occurs
            var buffer = new byte[4096];
            using (FileStream fsInput = File.OpenRead(filePathName))
            {
                StreamUtils.Copy(fsInput, zipStream, buffer);
            }
            zipStream.CloseEntry();
        }

        private void CompressItem(string itemPathName, string zipFileName, bool includeSubFolders, bool storeFullPath, bool skipEmptyFolder, int compressionLevel)
        {
            using (FileStream FsOut = File.Create(zipFileName))
            using (ZipOutputStream ZipStream = new ZipOutputStream(FsOut))
            {

                //0-9, 9 being the highest level of compression
                ZipStream.SetLevel(compressionLevel);

                string ItemName = Path.GetFileName(itemPathName);       // It might contain a pattern!
                string ItemFolderName = Path.GetDirectoryName(itemPathName);

                // This setting will strip the leading part of the folder path in the entries, 
                // to make the entries relative to the starting folder.
                // To include the full path for each entry up to the drive root, assign to 0.
                int FolderOffset = storeFullPath ? 0 : (ItemFolderName.Length + (ItemFolderName.EndsWith("\\") ? 0 : 1));

                string[] Files = Directory.GetFiles(ItemFolderName, ItemName);
                foreach (string FileName in Files)
                {
                    CompressFile(FileName, ZipStream, FolderOffset);
                }

                if (includeSubFolders)
                {
                    string[] Folders = Directory.GetDirectories(ItemFolderName, ItemName);
                    foreach (string FolderName in Folders)
                    {
                        CompressFolder(FolderName, ZipStream, FolderOffset, skipEmptyFolder);
                    }
                }
            }
        }

        public void Init()
        {
            
        }

        public void Destroy()
        {
            
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

                ZipTaskConfig TConfig = (ZipTaskConfig)Config;
                int IterationsCount = DynamicDataParser.GetIterationCount(TConfig, dataChain, lastDynamicDataSet);

                for (int i = 0; i < IterationsCount; i++)
                {
                    ZipTaskConfig ConfigCopy = (ZipTaskConfig)CoreHelpers.CloneObjects(Config);
                    DynamicDataParser.Parse(ConfigCopy, dataChain, IterationsCount);

                    if (File.Exists(ConfigCopy.Destination))
                    {
                        if (ConfigCopy.IfArchiveExists == IfArchiveExistsType.CreateWithUniqueNames)
                        {
                            ConfigCopy.Destination = Common.GetUniqueFileName(ConfigCopy.Destination);
                        }
                        else if (ConfigCopy.IfArchiveExists == IfArchiveExistsType.Fail)
                        {
                            if (!Config.DoNotLog)
                                instanceLogger.Error($"File name {ConfigCopy.Destination} already exists.");

                            DynamicDataSet FailDDataSet = CommonDynamicData.BuildStandardDynamicDataSet(this, false, -1, StartDateTime, DateTime.Now, ActualIterations);
                            Result = new ExecResult(false, FailDDataSet);
                            break;
                        }
                    }

                    instanceLogger.Info(this, $"Compressing {ConfigCopy.Source} to {ConfigCopy.Destination}...");
                    CompressItem(ConfigCopy.Source, ConfigCopy.Destination, ConfigCopy.IncludeFilesInSubFolders,
                                    ConfigCopy.StoreFullPath, ConfigCopy.SkipEmptyFolder, ToNumericCompressionLevel(ConfigCopy.CompressionLevel));
                        
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
