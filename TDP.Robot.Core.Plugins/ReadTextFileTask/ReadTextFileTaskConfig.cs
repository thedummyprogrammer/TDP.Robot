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
using TDP.Robot.Core;
using TDP.Robot.Core.DynamicData;

namespace TDP.Robot.Plugins.Core.ReadTextFileTask
{
    [Serializable]
    public enum ReadTextFileIntervalType
    {
        ReadFromRowToRow,
        ReadFromRowToLastRow,
        ReadLastNRows
    }

    [Serializable]
    public enum ReadTextFileSplitColumnsType
    {
        None,
        UseDelimiters,
        UseFixedWidthColumns
    }

    [Serializable]
    public enum ReadTextFileColumnDataType
    {
        String,
        Integer,
        Decimal,
        Datetime
    }



    [Serializable]
    public class ReadTextFileTaskConfig : ITaskConfig
    {
        public ReadTextFileTaskConfig()
        {
            ReadAllTheRowsOption = true;
            SplitColumnsType = ReadTextFileSplitColumnsType.None;
            ColumnsDefinition = new List<ReadTextFileColumnDefinition>();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public bool Disable { get; set; }
        public bool DoNotLog { get; set; }

        public IterationMode PluginIterationMode { get; set; }
        public string IterationObject { get; set; }
        public int IterationsCount { get; set; }

        [DynamicData]
        public string FilePath { get; set; }

        public bool ReadAllTheRowsOption { get; set; }
        public bool SkipFirstLine { get; set; }

        public bool ReadLastRowOption { get; set; }
        public bool ReadRowNumberOption { get; set; }
        [DynamicData]
        public string ReadRowNumber { get; set; }
        public bool ReadIntervalOption { get; set; }
        public ReadTextFileIntervalType ReadInterval { get; set; }
        [DynamicData]
        public string ReadFromRow { get; set; }
        [DynamicData]
        public string ReadToRow { get; set; }
        [DynamicData]
        public string ReadNumberOfRows { get; set; }

        public ReadTextFileSplitColumnsType SplitColumnsType { get; set; }

        public bool DelimiterTab { get; set; }

        public bool DelimiterSemicolon { get; set; }

        public bool DelimiterComma { get; set; }

        public bool DelimiterSpace { get; set; }

        public bool DelimiterOther { get; set; }

        public string DelimiterOtherChar { get; set; }

        public bool UseDoubleQuotes { get; set; }

        public bool OverrideDefaultColumnsDefinition { get; set; }
        public List<ReadTextFileColumnDefinition> ColumnsDefinition { get; }
    }
}
