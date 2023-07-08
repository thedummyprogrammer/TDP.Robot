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
using TDP.Robot.Core;
using TDP.Robot.Core.DynamicData;

namespace TDP.Robot.Plugins.Core.ExcelFileTask
{
    [Serializable]
    public enum ExcelFileTaskType
    {
        AppendRow,
        InsertRow,
        ReadRow,
        DeleteRow,
        FindFirstRow,
        FindAllRows,
        FindAndReplace
    }

    [Serializable]
    public enum ExcelReadIntervalType
    {
        ReadFromRowToRow,
        ReadFromRowToLastRow,
        ReadLastNRows
    }

    [Serializable]
    public class ExcelFileTaskConfig : ITaskConfig
    {
        public ExcelFileTaskConfig()
        {
            ColumnsDefinition = new List<ExcelFileColumnDefinition>();
            ReadLastRowOption = true;
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public bool Disable { get; set; }
        public bool DoNotLog { get; set; }
        public IterationMode PluginIterationMode { get; set; }
        public string IterationObject { get; set; }
        public int IterationsCount { get; set; }

        
        public ExcelFileTaskType TaskType { get; set; }


        // Insert / Append configuration
        [DynamicData]
        public string FilePath { get; set; }
        [DynamicData]
        public string SheetName { get; set; }

        public List<ExcelFileColumnDefinition> ColumnsDefinition { get; }

        public bool AddHeaderIfEmpty { get; set; }
        [DynamicData]
        public string InsertAtRow { get; set; }

        // Read configuration
        public bool ReadLastRowOption { get; set; }
        public bool ReadRowNumberOption { get; set; }
        [DynamicData]
        public string ReadRowNumber { get; set; }
        public bool ReadIntervalOption { get; set; }
        public ExcelReadIntervalType ReadInterval { get; set; }
        [DynamicData]
        public string ReadFromRow { get; set; }
        [DynamicData]
        public string ReadToRow { get; set; }
        [DynamicData]
        public string ReadNumberOfRows { get; set; }
        [DynamicData]
        public string NumColumnsToRead { get; set; }

        // Delete configuration
        [DynamicData]
        public string DeleteRowNumber { get; set; }

        // Find / Replace configuration
        [DynamicData]
        public string FindText { get; set; }
        [DynamicData]
        public string ReplaceWith { get; set; }
    }
}
