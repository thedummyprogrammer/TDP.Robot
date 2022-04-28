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
using System.IO;
using TDP.Robot.Core;

namespace TDP.Robot.Plugins.Core.Unzip
{
    [Serializable]
    public class UnzipTask : IterationTask
    {
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

        protected override void RunIteration(int currentIteration)
        {
            UnzipTaskConfig ConfigCopy = (UnzipTaskConfig)_iterationConfig;
            
            _instanceLogger.Info(this, $"Uncompressing archive {ConfigCopy.Source} to {ConfigCopy.Destination}...");
            bool Completed = UncompressArchive(ConfigCopy.Source, ConfigCopy.Destination, ConfigCopy.IfDestFileExists);

            if (!Completed)
                throw new ApplicationException("One or more files with the same name found in destination folder.");
        }
    }
}
