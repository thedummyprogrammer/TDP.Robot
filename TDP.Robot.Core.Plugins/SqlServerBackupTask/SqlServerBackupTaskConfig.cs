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

namespace TDP.Robot.Plugins.Core.SqlServerBackupTask
{
    [Serializable]
    public enum DatabasesToBackupEnum
    {
        AllDatabases,
        AllUserDatabases,
        SelectedDatabases
    }

    [Serializable]
    public enum UseCompressionEnum
    {
        UseServerDefault,
        CompressBackup,
        DoNotCompressBackup
    }

    [Serializable]
    public enum BackupTypeEnum
    {
        Full,
        TransactionLog
    }


    [Serializable]
    public class SqlServerBackupTaskConfig : ITaskConfig
    {
        public SqlServerBackupTaskConfig()
        {
            DatabasesList = new List<string>();
            SelectedDatabases = new List<string>();
        }

        public IterationMode PluginIterationMode { get; set; }
        public string IterationObject { get; set; }
        public int IterationsCount { get; set; }
        public int ID { get; set; }
        public string Name { get; set; }
        public bool Disable { get; set; }
        public bool DoNotLog { get; set; }

        [DynamicData]
        [field: XmlEncryptField]
        public string Server { get; set; }
        [DynamicData]
        [field: XmlEncryptField]
        public string Username { get; set; }
        
        [DynamicData]
        [field: XmlEncryptField]
        public string Password { get; set; }
        [DynamicData]
        [field: XmlEncryptField]
        public string ConnectionStringOptions { get; set; }

        public BackupTypeEnum BackupType { get; set; }

        public DatabasesToBackupEnum DatabasesToBackup { get; set; }

        public List<string> DatabasesList { get; }

        public List<string> SelectedDatabases { get; }

        [DynamicData]
        public string DestinationPath { get; set; }

        [DynamicData]
        public string FileNameTemplate { get; set; }

        public bool OverwriteIfExists { get; set; }

        public bool VerifyBackup { get; set; }
        public bool PerformChecksum { get; set; }
        public bool ContinueOnError { get; set; }

        public UseCompressionEnum UseCompression { get; set; }
    }
}
