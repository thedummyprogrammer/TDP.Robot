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
using TDP.Robot.Core;
using TDP.Robot.Core.DynamicData;
using TDP.Robot.Core.Persistence;

namespace TDP.Robot.Plugins.Core.SqlServerCommandTask
{
    [Serializable]
    public enum QueryTaskType
    {
        Text,
        StoredProcedure
    }

    [Serializable]
    public class SqlServerCommandTaskConfig : ITaskConfig
    {
        public const int DefaultCommandTimeout = 30;

        public SqlServerCommandTaskConfig()
        {
            ParamsDefinition = new List<SqlServerParamDefinition>();
            CommandTimeout = DefaultCommandTimeout.ToString();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public bool Disable { get; set; }
        public bool DoNotLog { get; set; }

        public IterationMode PluginIterationMode { get; set; }
        public string IterationObject { get; set; }
        public int IterationsCount { get; set; }

        [DynamicData]
        public string Query { get; set; }
        public QueryTaskType Type { get; set; }
        [DynamicData]
        public List<SqlServerParamDefinition> ParamsDefinition { get; }

        public bool ReturnsRecordset { get; set; }

        [DynamicData]
        [field: XmlEncryptField]
        public string Server { get; set; }
        [DynamicData]
        [field: XmlEncryptField]
        public string Database { get; set; }
        [DynamicData]
        [field: XmlEncryptField]
        public string Username { get; set; }
        [DynamicData]
        [field: XmlEncryptField]
        public string Password { get; set; }
        [DynamicData]
        [field: XmlEncryptField]
        public string ConnectionStringOptions { get; set; }
        [DynamicData]
        public string CommandTimeout { get; set; }
    }
}
