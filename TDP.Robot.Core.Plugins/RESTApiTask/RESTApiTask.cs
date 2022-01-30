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

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TDP.Robot.Core;
using TDP.Robot.Core.DynamicData;
using TDP.Robot.Core.Logging;

namespace TDP.Robot.Plugins.Core.RESTApiTask
{
    [Serializable]
    public class RESTApiTask : ITask
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

            List<Dictionary<string, object>> DefaultRecordset = null;
            int ExecutionReturnValue = -1;
            int ActualIterations = 0;

            try
            {
                if (!Config.DoNotLog)
                    instanceLogger.TaskStarted(this);

                RESTApiTaskConfig TConfig = (RESTApiTaskConfig)Config;
                int IterationsCount = DynamicDataParser.GetIterationCount(TConfig, dataChain, lastDynamicDataSet);

                if (IterationsCount > 0)
                {
                    using (HttpClient Client = new HttpClient())
                    {
                        for (int i = 0; i < IterationsCount; i++)
                        {
                            RESTApiTaskConfig ConfigCopy = (RESTApiTaskConfig)CoreHelpers.CloneObjects(Config);
                            DynamicDataParser.Parse(ConfigCopy, dataChain, i);

                            Client.DefaultRequestHeaders.Clear();
                            foreach (RESTApiHeader ApiHeader in ConfigCopy.Headers)
                            {
                                Client.DefaultRequestHeaders.Add(
                                    DynamicDataParser.ReplaceDynamicData(ApiHeader.Name, dataChain, i),
                                    DynamicDataParser.ReplaceDynamicData(ApiHeader.Value, dataChain, i)
                                    );
                            }

                            Task<HttpResponseMessage> TaskResponse;
                            HttpResponseMessage Response;

                            if (ConfigCopy.Method == MethodType.Get)
                            {
                                instanceLogger.Info(this, $"Connecting to: {ConfigCopy.URL} Method: GET");
                                TaskResponse = Client.GetAsync(ConfigCopy.URL);
                            }
                            else if (ConfigCopy.Method == MethodType.Post)
                            {
                                instanceLogger.Info(this, $"Connecting to: {ConfigCopy.URL} Method: POST");
                                StringContent ContentParameters = new StringContent(ConfigCopy.Parameters, Encoding.UTF8 , "application/json");
                                TaskResponse = Client.PostAsync(ConfigCopy.URL, ContentParameters);
                            }
                            else if (ConfigCopy.Method == MethodType.Put)
                            {
                                instanceLogger.Info(this, $"Connecting to: {ConfigCopy.URL} Method: PUT");
                                StringContent ContentParameters = new StringContent(ConfigCopy.Parameters, Encoding.UTF8, "application/json");
                                TaskResponse = Client.PutAsync(ConfigCopy.URL, ContentParameters);
                            }
                            else if (ConfigCopy.Method == MethodType.Delete)
                            {
                                instanceLogger.Info(this, $"Connecting to: {ConfigCopy.URL} Method: DELETE");
                                TaskResponse = Client.DeleteAsync(ConfigCopy.URL);
                            }
                            else
                                throw new ApplicationException($"Http method '{ConfigCopy.Method}' not supported.");

                            // Wait for task to complete
                            string ResultStr;
                            using (Response = TaskResponse.Result)
                            {
                                Response.EnsureSuccessStatusCode();
                                
                                // Wait for task to complete
                                ResultStr = Response.Content.ReadAsStringAsync().Result;
                            }

                            if (TConfig.ReturnsRecordset)
                            {
                                instanceLogger.Info(this, "Trying to deserialize JSON response...");
                                DefaultRecordset = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(ResultStr);
                                instanceLogger.Info(this, "Deserialization completed.");
                            }
                                

                            ActualIterations++;
                        }
                    }
                }

                DynamicDataSet DDataSet = CommonDynamicData.BuildStandardDynamicDataSet(this, true, ExecutionReturnValue, StartDateTime, DateTime.Now, ActualIterations);

                if (TConfig.ReturnsRecordset)
                    DDataSet.Add(CommonDynamicData.DefaultRecordsetName, DefaultRecordset);

                Result = new ExecResult(true, DDataSet);

                if (!Config.DoNotLog)
                    instanceLogger.TaskCompleted(this);
            }
            catch (Exception ex)
            {
                if (!Config.DoNotLog)
                    instanceLogger.TaskError(this, ex);

                DynamicDataSet DDataSet = CommonDynamicData.BuildStandardDynamicDataSet(this, false, -1, StartDateTime, DateTime.Now, ActualIterations);
                DDataSet.Add(CommonDynamicData.DefaultRecordsetName, DefaultRecordset);
                Result = new ExecResult(false, DDataSet);
            }

            return Result;
        }
    }
}
