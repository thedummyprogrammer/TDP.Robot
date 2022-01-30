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
using TDP.Robot.Core;
using TDP.Robot.Core.DynamicData;
using TDP.Robot.Core.Logging;

namespace TDP.Robot.Plugins.Core.SqlServerCommandTask
{
    [Serializable]
    public class SqlServerCommandTask : ITask
    {
        public IFolder ParentFolder { get; set; }
        public int ID { get; set; }
        public IPluginInstanceConfig Config { get; set; }

        public List<PluginInstanceConnection> Connections { get; } = new List<PluginInstanceConnection>();

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

            DataTable DefaultRecordset = new DataTable();
            int ExecutionReturnValue = -1;
            int ActualIterations = 0;

            try
            {
                if (!Config.DoNotLog)
                    instanceLogger.TaskStarted(this);

                SqlServerCommandTaskConfig TConfig = (SqlServerCommandTaskConfig)Config;
                int IterationsCount = DynamicDataParser.GetIterationCount(TConfig, dataChain, lastDynamicDataSet);

                for (int i = 0; i < IterationsCount; i++)
                {
                    SqlServerCommandTaskConfig ConfigCopy = (SqlServerCommandTaskConfig)CoreHelpers.CloneObjects(Config);
                    DynamicDataParser.Parse(ConfigCopy, dataChain, i);

                    string ConnectionString = $"Server={ConfigCopy.Server};Database={ConfigCopy.Database};User Id={ConfigCopy.Username};Password={ConfigCopy.Password};{ConfigCopy.ConnectionStringOptions}";

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

                        foreach (SqlServerParamDefinition ParamDef in ConfigCopy.ParamsDefinition)
                        {
                            Cmd.Parameters.Add(CreateParameter(ParamDef, dataChain, i));
                        }

                        Cmd.CommandText = ConfigCopy.Query;
                        Cmd.CommandTimeout = int.Parse(ConfigCopy.CommandTimeout);

                        if (ConfigCopy.ReturnsRecordset)
                        {
                            SqlDataAdapter DA = new SqlDataAdapter(Cmd);
                            DA.Fill(DefaultRecordset);
                        }
                        else
                        {
                            ExecutionReturnValue = Cmd.ExecuteNonQuery();
                        }

                        if (Cmd.CommandType == CommandType.StoredProcedure)
                        {
                            ExecutionReturnValue = (int)Cmd.Parameters["@RETVALUE"].Value;
                        }
                    }

                    ActualIterations++;
                }

                DynamicDataSet DDataSet = CommonDynamicData.BuildStandardDynamicDataSet(this, true, ExecutionReturnValue, StartDateTime, DateTime.Now, ActualIterations);

                if (TConfig.ReturnsRecordset)
                    DDataSet.Add(CommonDynamicData.DefaultRecordsetName, DefaultRecordset);                    
                
                Result = new ExecResult(true, DDataSet);

                if (!Config.DoNotLog)
                {
                    instanceLogger.Info(this, $"Number of queries/commands executed: {ActualIterations}");
                    instanceLogger.TaskCompleted(this);
                }                    
            }
            catch (Exception ex)
            {
                if (!Config.DoNotLog)
                {
                    instanceLogger.Info(this, $"Number of queries/commands executed: {ActualIterations}");
                    instanceLogger.TaskError(this, ex);
                }

                DynamicDataSet DDataSet = CommonDynamicData.BuildStandardDynamicDataSet(this, false, -1, StartDateTime, DateTime.Now, ActualIterations);
                DDataSet.Add(CommonDynamicData.DefaultRecordsetName, DefaultRecordset);
                Result = new ExecResult(false, DDataSet);
            }

            return Result;
        }
    }
}
