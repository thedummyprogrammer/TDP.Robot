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

using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace TDP.Robot.Plugins.Core.FtpSftpTask
{
    internal static class FtpSftpTaskCommon
    {
        public static List<string> SplitRemotePath(string remotePath)
        {
            List<string> Result = new List<string>();
            string[] Items_1 = Regex.Split(remotePath, @"\\");

            foreach (string Item_1 in Items_1)
            {
                string[] Items_2 = Regex.Split(Item_1, @"/");
                foreach (string Item_2 in Items_2)
                {
                    if (!string.IsNullOrEmpty(Item_2))
                        Result.Add(Item_2);
                }
            }

            return Result;
        }

        public static List<string> SplitLocalPath(string localPath)
        {
            List<string> Result = new List<string>();
            string Separator = Path.DirectorySeparatorChar.ToString();

            if (Path.DirectorySeparatorChar == '\\')
                Separator += '\\';

            string[] Items = Regex.Split(localPath, Separator);
            foreach (string Item in Items)
            {
                if (!string.IsNullOrEmpty(Item))
                    Result.Add(Item);
            }

            return Result;
        }

        public static string CombineRemotePath(params string[] paths)
        {
            return Path.Combine(paths).Replace('\\', '/');
        }
    }
}
