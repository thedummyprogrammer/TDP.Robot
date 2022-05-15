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
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDP.Robot.Core;
using TDP.Robot.Core.DynamicData;
using TDP.Robot.Core.Logging;

namespace TDP.Robot.Plugins.Core.SqlServerBulkCopyTask
{
    [Serializable]
    public class SqlServerBulkCopyTask : IterationTask
    {
        protected override void RunIteration(int currentIteration)
        {
            SqlServerBulkCopyTaskConfig TConfig = (SqlServerBulkCopyTaskConfig)_iterationConfig;            
            string ConnectionString = $"Server={TConfig.Server};Database={TConfig.Database};User ID={TConfig.Username};Password={TConfig.Password};{TConfig.ConnectionStringOptions}";

            using (SqlConnection Cnt = new SqlConnection(ConnectionString))
            {
                Cnt.Open();

                using (SqlBulkCopy BulkCopy = new SqlBulkCopy(Cnt))
                {
                    BulkCopy.DestinationTableName = TConfig.DestinationTable;
                    DataTable DtSource = (DataTable)DynamicDataParser.GetDynamicDataObject(TConfig.SourceRecordset, _dataChain);
                    _instanceLogger.Info(this, $"About to bulk copy {DtSource.Rows.Count} rows to table {TConfig.DestinationTable}...");
                    BulkCopy.WriteToServer(DtSource);
                    _instanceLogger.Info(this, "Bulk copy successfully completed");
                }
            }
        }
    }
}
