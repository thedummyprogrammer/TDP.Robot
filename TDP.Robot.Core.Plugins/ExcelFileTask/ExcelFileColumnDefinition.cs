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

namespace TDP.Robot.Plugins.Core.ExcelFileTask
{
    [Serializable]
    public class ExcelFileColumnDefinition
    {
        public ExcelFileColumnDefinition()
        {

        }

        public ExcelFileColumnDefinition(string headerTitle, string cellValue)
        {
            HeaderTitle = headerTitle;
            CellValue = cellValue;
        }

        public string HeaderTitle { get; set; }
        public string CellValue { get; set; }

        public override string ToString()
        {
            string Result = string.Empty;

            if (!string.IsNullOrEmpty(HeaderTitle))
                Result += HeaderTitle;
            else
                Result += Resource.TxtNoHeader;

            if (!string.IsNullOrEmpty(CellValue))
                Result += ": " + CellValue;
            else
                Result += ": " + Resource.TxtNoValue;

            return Result;
        }
    }
}
