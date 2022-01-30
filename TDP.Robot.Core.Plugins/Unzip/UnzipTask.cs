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

namespace TDP.Robot.Plugins.Core.Unzip
{
    [Serializable]
    public class UnzipTask : ITask
    {
        public IFolder ParentFolder { get; set; }
        public int ID { get; set; }
        public IPluginInstanceConfig Config { get; set; }

        public List<PluginInstanceConnection> Connections { get; } = new List<PluginInstanceConnection>();

        private bool UncompressArchive(string zipFileName, string outputFolder, IfDestFileExistsType ifDestFileExists)
        {
            using (FileStream FS = File.OpenRead(zipFileName))
            using (ZipFile ZipFileToExtract = new ZipFile(FS))
            {
                foreach (ZipEntry ZipItem in ZipFileToExtract)
                {
                    if (!ZipItem.IsFile)
                    {
                        // Ignore directories
                        continue;
                    }

                    string EntryFileName = ZipItem.Name;

                    byte[] Buffer = new byte[4096];
                    using (Stream ZipStream = ZipFileToExtract.GetInputStream(ZipItem))
                    {
                        string FullZipToPath = Path.Combine(outputFolder, EntryFileName);
                        string DirectoryName = Path.GetDirectoryName(FullZipToPath);

                        if (DirectoryName.Length > 0)
                        {
                            Directory.CreateDirectory(DirectoryName);
                        }


                        if (File.Exists(FullZipToPath))
                        {
                            if (ifDestFileExists == IfDestFileExistsType.Fail)
                                return false;
                            else if (ifDestFileExists == IfDestFileExistsType.CreateWithUniqueNames)
                                FullZipToPath = Common.GetUniqueFileName(FullZipToPath);
                        }
                        
                        using (FileStream streamWriter = File.Create(FullZipToPath))
                        {
                            StreamUtils.Copy(ZipStream, streamWriter, Buffer);
                        }
                    }
                }
            }

            return true;
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

                UnzipTaskConfig TConfig = (UnzipTaskConfig)Config;
                int IterationsCount = DynamicDataParser.GetIterationCount(TConfig, dataChain, lastDynamicDataSet);

                for (int i = 0; i < IterationsCount; i++)
                {
                    UnzipTaskConfig ConfigCopy = (UnzipTaskConfig)CoreHelpers.CloneObjects(Config);
                    DynamicDataParser.Parse(ConfigCopy, dataChain, IterationsCount);

                    instanceLogger.Info(this, $"Uncompressing archive {ConfigCopy.Source} to {ConfigCopy.Destination}...");
                    bool Completed = UncompressArchive(ConfigCopy.Source, ConfigCopy.Destination, ConfigCopy.IfDestFileExists);

                    if (Completed)
                    {
                        if (!Config.DoNotLog)
                            instanceLogger.Error($"One or more files with the same name found in destination folder.");

                        DynamicDataSet FailDDataSet = CommonDynamicData.BuildStandardDynamicDataSet(this, false, -1, StartDateTime, DateTime.Now, ActualIterations);
                        Result = new ExecResult(false, FailDDataSet);
                        break;
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
