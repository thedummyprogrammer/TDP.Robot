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

namespace TDP.Robot.Plugins.Core.SqlServerCommandTask
{
    [Serializable]
    public enum SqlParamType
    {
        Varchar,
        NVarchar,
        Xml,
        Numeric,
        Int,
        Long,
        Date,
        Datetime,
        Bit
    }

    [Serializable]
    public class SqlServerParamDefinition
    {
        public SqlServerParamDefinition()
        {

        }

        public SqlServerParamDefinition(string name, string value, SqlParamType type, string length, string precision)
        {
            Name = name;
            Value = value;
            Type = type;
            Length = length;
            Precision = precision;
        }

        public string Name { get; set; }
        public string Value { get; set; }
        public SqlParamType Type { get; set; }
        public string Length { get; set; }
        public string Precision { get; set; }

        public override string ToString()
        {
            string Result = Name;

            if (!string.IsNullOrEmpty(Value))
                Result += ": " + Value;
            else
                Result += ": " + Resource.TxtNoValue;

            return Result;
        }
    }
}
