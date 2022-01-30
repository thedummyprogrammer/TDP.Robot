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
using TDP.BaseServices.Infrastructure.DataValidation;

namespace TDP.Robot.Plugins.Core
{
    static class Common
    {
        public static string GetUniqueFileName(string filePathName)
        {
            if (!File.Exists(filePathName))
                return filePathName;

            FileInfo FI = new FileInfo(filePathName);

            string NewFileName;
            int Attempt = 1;

            do
            {
                NewFileName = $"{FI.Directory.FullName}\\{Path.GetFileNameWithoutExtension(FI.Name)}-{Attempt}{FI.Extension}";
                Attempt++;

            } while (File.Exists(NewFileName));

            return NewFileName;
        }

        public static int? GetNullableInt(string val)
        {
            if (DataValidationHelper.IsEmptyString(val))
                return null;

            return int.Parse(val);
        }

        public static string GetStringFromNullable(int? val)
        {
            if (val == null)
                return string.Empty;
            return val.ToString();
        }

        public static bool IsDirectory(string path)
        {
            FileAttributes Attr = File.GetAttributes(path);
            return Attr.HasFlag(FileAttributes.Directory);
        }
    }
}
