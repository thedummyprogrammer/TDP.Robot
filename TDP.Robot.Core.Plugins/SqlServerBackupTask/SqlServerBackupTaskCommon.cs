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

using System.Collections.Generic;
using System.Data.SqlClient;

namespace TDP.Robot.Plugins.Core.SqlServerBackupTask
{
    internal static class SqlServerBackupTaskCommon
    {
        public const string DynDataKeySuccessfulBackupsNumber = "SuccessfulBackupsNumber";
        public const string DynDataKeyFailedBackupsNumber = "FailedBackupsNumber";

        public static List<string> GetDatabaseList(string connectionString, bool onlyUserDatabases = false)
        {
            List<string> DatabaseList = new List<string>();

            using (SqlConnection Cnt = new SqlConnection(connectionString))
            {
                Cnt.Open();

                using (SqlCommand CmdDatabases = new SqlCommand("SELECT name FROM sys.databases", Cnt))
                {
                    using (SqlDataReader Reader = CmdDatabases.ExecuteReader())
                    {
                        while (Reader.Read())
                        {
                            string DbName = Reader["name"].ToString();

                            if (!onlyUserDatabases || (onlyUserDatabases && DbName != "master" && DbName != "model" && DbName != "msdb" && DbName != "tempdb"))
                                DatabaseList.Add(Reader["name"].ToString());
                        }
                    }
                }
            }

            return DatabaseList;
        }
    }
}
