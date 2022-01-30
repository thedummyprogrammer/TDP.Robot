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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDP.Robot.Plugins.Core.FileSystemTask
{
    [Serializable]
    public class FileSystemTaskCopyItem
    {
        public FileSystemTaskCopyItem()
        {

        }

        public FileSystemTaskCopyItem(string sourcePath, string destinationPath, bool overwriteFileIfExists, bool recursivelyCopyDirectories)
        {
            SourcePath = sourcePath;
            DestinationPath = destinationPath;
            OverwriteFileIfExists = overwriteFileIfExists;
            RecursivelyCopyDirectories = recursivelyCopyDirectories;
        }

        public string SourcePath { get; set; }

        public string DestinationPath { get; set; }

        public bool OverwriteFileIfExists { get; set; }

        public bool RecursivelyCopyDirectories { get; set; }

        public override string ToString()
        {
            string Result = $"{Resource.TxtFrom}: {SourcePath} {Resource.TxtTo}: {DestinationPath}";

            return $"{Result} {(OverwriteFileIfExists ? Resource.TxtOverwriteIfExists : string.Empty)} {(RecursivelyCopyDirectories ? Resource.TxtRecursiveCopy : string.Empty)}";
        }
    }
}
