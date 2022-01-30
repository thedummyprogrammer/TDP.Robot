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
    public class SqlServerBulkCopyTask : ITask
    {
        public IFolder ParentFolder { get; set; }
        public int ID { get; set; }
        public IPluginInstanceConfig Config { get; set; }
        public List<PluginInstanceConnection> Connections { get; } = new List<PluginInstanceConnection>();

        public void Init()
        {

        }

        public void Destroy()
        {

        }

        public ExecResult Run(DynamicDataChain dataChain, DynamicDataSet lastDynamicDataSet, IPluginInstanceLogger instanceLogger)
        {
            ExecResult Result;
            DateTime StartDateTime = DateTime.Now;

            int ActualIterations = 0;

            try
            {
                if (!Config.DoNotLog)
                    instanceLogger.TaskStarted(this);

                SqlServerBulkCopyTaskConfig TConfig = (SqlServerBulkCopyTaskConfig)Config;

                // This object iterates only one time!!
                SqlServerBulkCopyTaskConfig ConfigCopy = (SqlServerBulkCopyTaskConfig)CoreHelpers.CloneObjects(Config);
                DynamicDataParser.Parse(ConfigCopy, dataChain, ActualIterations);

                string ConnectionString = $"Server={ConfigCopy.Server};Database={ConfigCopy.Database};User ID={ConfigCopy.Username};Password={ConfigCopy.Password};{ConfigCopy.ConnectionStringOptions}";

                using (SqlConnection Cnt = new SqlConnection(ConnectionString))
                {
                    Cnt.Open();

                    using (SqlBulkCopy BulkCopy = new SqlBulkCopy(Cnt))
                    {
                        BulkCopy.DestinationTableName = ConfigCopy.DestinationTable;
                        DataTable DtSource = (DataTable)DynamicDataParser.GetDynamicDataObject(ConfigCopy.SourceRecordset, dataChain);
                        instanceLogger.Info(this, $"About to bulk copy {DtSource.Rows.Count} rows to table {ConfigCopy.DestinationTable}...");
                        BulkCopy.WriteToServer(DtSource);
                        instanceLogger.Info(this, "Bulk copy successfully completed");
                    }
                }

                DynamicDataSet DDataSet = CommonDynamicData.BuildStandardDynamicDataSet(this, true, 0, StartDateTime, DateTime.Now, ActualIterations);
                Result = new ExecResult(true, DDataSet);

                if (!Config.DoNotLog)
                    instanceLogger.TaskCompleted(this);
            }
            catch (Exception ex)
            {
                if (!Config.DoNotLog)
                    instanceLogger.TaskError(this, ex);

                DynamicDataSet DDataSet = CommonDynamicData.BuildStandardDynamicDataSet(this, false, -1, StartDateTime, DateTime.Now, ActualIterations);
                Result = new ExecResult(false, DDataSet);
            }

            return Result;
        }
    }
}
