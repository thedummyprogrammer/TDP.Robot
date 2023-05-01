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
using System.Data;
using System.Data.SqlClient;
using TDP.Robot.Core;
using TDP.Robot.Core.DynamicData;
using TDP.Robot.Core.Logging;

namespace TDP.Robot.Plugins.Core.SqlServerCommandTask
{
    [Serializable]
    public class SqlServerCommandTask : IterationTask
    {
        private int _executionReturnValue;

        private SqlParameter CreateParameter(SqlServerParamDefinition paramDef, DynamicDataChain dataChain, int iterationNumber)
        {
            SqlParameter SqlParam = new SqlParameter();

            SqlParam.ParameterName = paramDef.Name;

            switch (paramDef.Type)
            {
                case SqlParamType.Varchar:
                    SqlParam.SqlDbType = SqlDbType.VarChar;
                    if (!string.IsNullOrEmpty(paramDef.Length))
                    {
                        if (paramDef.Length.ToUpper() != "MAX")
                            SqlParam.Size = int.Parse(paramDef.Length);
                        else
                            SqlParam.Size = -1;
                    }
                        
                    break;

                case SqlParamType.NVarchar:
                    SqlParam.SqlDbType = SqlDbType.NVarChar;
                    if (!string.IsNullOrEmpty(paramDef.Length))
                    {
                        if (paramDef.Length.ToUpper() != "MAX")
                            SqlParam.Size = int.Parse(paramDef.Length);
                        else
                            SqlParam.Size = -1;
                    }
                    break;

                case SqlParamType.Xml:
                    SqlParam.SqlDbType = SqlDbType.Xml;
                    SqlParam.Size = -1;
                    break;

                case SqlParamType.Numeric:
                    SqlParam.SqlDbType = SqlDbType.Decimal;
                    if (!string.IsNullOrEmpty(paramDef.Length))
                        SqlParam.Size = int.Parse(paramDef.Length);
                    if (!string.IsNullOrEmpty(paramDef.Precision))
                        SqlParam.Precision = byte.Parse(paramDef.Precision);
                    break;

                case SqlParamType.Int:
                    SqlParam.SqlDbType = SqlDbType.Int;
                    break;

                case SqlParamType.Long:
                    SqlParam.SqlDbType = SqlDbType.BigInt;
                    break;

                case SqlParamType.Bit:
                    SqlParam.SqlDbType = SqlDbType.Bit;
                    break;

                case SqlParamType.Date:
                    SqlParam.SqlDbType = SqlDbType.Date;
                    break;

                case SqlParamType.Datetime:
                    SqlParam.SqlDbType = SqlDbType.DateTime;
                    break;
            }

            SqlParam.Value = DynamicDataParser.ReplaceDynamicData(paramDef.Value, dataChain, iterationNumber);

            return SqlParam;
        }

        protected override void RunIteration(int currentIteration)
        {
            SqlServerCommandTaskConfig TConfig = (SqlServerCommandTaskConfig)_iterationConfig;
            _defaultRecordset = new DataTable();

            string ConnectionString = $"Server={TConfig.Server};Database={TConfig.Database};User Id={TConfig.Username};Password={TConfig.Password};{TConfig.ConnectionStringOptions}";

            using (SqlConnection Cnt = new SqlConnection(ConnectionString))
            using (SqlCommand Cmd = new SqlCommand(string.Empty, Cnt))
            {
                Cnt.Open();

                if (TConfig.Type == QueryTaskType.Text)
                    Cmd.CommandType = CommandType.Text;
                else
                    Cmd.CommandType = CommandType.StoredProcedure;

                if (Cmd.CommandType == CommandType.StoredProcedure)
                {
                    Cmd.Parameters.Add("@RETVALUE", SqlDbType.Int);
                    Cmd.Parameters["@RETVALUE"].Direction = ParameterDirection.ReturnValue;
                }

                foreach (SqlServerParamDefinition ParamDef in TConfig.ParamsDefinition)
                {
                    Cmd.Parameters.Add(CreateParameter(ParamDef, _dataChain, currentIteration));
                }

                Cmd.CommandText = TConfig.Query;
                Cmd.CommandTimeout = int.Parse(TConfig.CommandTimeout);

                if (TConfig.ReturnsRecordset)
                {
                    SqlDataAdapter DA = new SqlDataAdapter(Cmd);
                    DA.Fill((DataTable)_defaultRecordset);
                }
                else
                {
                    _executionReturnValue = Cmd.ExecuteNonQuery();
                }

                if (Cmd.CommandType == CommandType.StoredProcedure)
                {
                    _executionReturnValue = (int)Cmd.Parameters["@RETVALUE"].Value;
                }
            }
        }

        private void PostIteration(int currentIteration, ExecResult result, DynamicDataSet dDataSet)
        {
            if (!_iterationConfig.DoNotLog)
            {
                _instanceLogger.Info(this, $"Number of queries/commands executed: {currentIteration + 1}");
                _instanceLogger.TaskCompleted(this);
            }

            SqlServerCommandTaskConfig TConfig = (SqlServerCommandTaskConfig)_iterationConfig;

            if (TConfig.ReturnsRecordset)
                dDataSet.Add(CommonDynamicData.DefaultRecordsetName, _defaultRecordset);

            dDataSet[CommonDynamicData.ExecutionReturnValue] = _executionReturnValue;
        }

        protected override void PostIterationSucceded(int currentIteration, ExecResult result, DynamicDataSet dDataSet)
        {
            PostIteration(currentIteration, result, dDataSet);
        }

        protected override void PostIterationFailed(int currentIteration, ExecResult result, DynamicDataSet dDataSet)
        {
            PostIteration(currentIteration, result, dDataSet);
        }
    }
}
