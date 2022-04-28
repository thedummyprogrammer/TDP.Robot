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
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TDP.Robot.Core;
using TDP.Robot.Core.DynamicData;

namespace TDP.Robot.Plugins.Core.RESTApiTask
{
    [Serializable]
    public class RESTApiTask : IterationTask
    {
        private string _RawContent;
        private string _HttpResult;

        protected override void RunIteration(int currentIteration)
        {
            using (HttpClient Client = new HttpClient())
            {
                RESTApiTaskConfig TConfig = (RESTApiTaskConfig)_iterationConfig;

                Client.DefaultRequestHeaders.Clear();
                foreach (RESTApiHeader ApiHeader in TConfig.Headers)
                {
                    Client.DefaultRequestHeaders.Add(
                        DynamicDataParser.ReplaceDynamicData(ApiHeader.Name, _dataChain, currentIteration),
                        DynamicDataParser.ReplaceDynamicData(ApiHeader.Value, _dataChain, currentIteration)
                        );
                }

                Task<HttpResponseMessage> TaskResponse;
                HttpResponseMessage Response;

                if (TConfig.Method == MethodType.Get)
                {
                    _instanceLogger.Info(this, $"Connecting to: {TConfig.URL} Method: GET");
                    TaskResponse = Client.GetAsync(TConfig.URL);
                }
                else if (TConfig.Method == MethodType.Post)
                {
                    _instanceLogger.Info(this, $"Connecting to: {TConfig.URL} Method: POST");
                    StringContent ContentParameters = new StringContent(TConfig.Parameters, Encoding.UTF8, "application/json");
                    TaskResponse = Client.PostAsync(TConfig.URL, ContentParameters);
                }
                else if (TConfig.Method == MethodType.Put)
                {
                    _instanceLogger.Info(this, $"Connecting to: {TConfig.URL} Method: PUT");
                    StringContent ContentParameters = new StringContent(TConfig.Parameters, Encoding.UTF8, "application/json");
                    TaskResponse = Client.PutAsync(TConfig.URL, ContentParameters);
                }
                else if (TConfig.Method == MethodType.Delete)
                {
                    _instanceLogger.Info(this, $"Connecting to: {TConfig.URL} Method: DELETE");
                    TaskResponse = Client.DeleteAsync(TConfig.URL);
                }
                else
                    throw new ApplicationException($"Http method '{TConfig.Method}' not supported.");

                // Wait for task to complete
                using (Response = TaskResponse.Result)
                {
                    Response.EnsureSuccessStatusCode();

                    // Wait for task to complete
                    _RawContent = Response.Content.ReadAsStringAsync().Result;
                    _HttpResult = ((int)Response.StatusCode).ToString();
                }

                if (TConfig.ReturnsRecordset)
                {
                    _instanceLogger.Info(this, "Trying to deserialize JSON response...");
                    _defaultRecordset = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(_RawContent);
                    _instanceLogger.Info(this, "Deserialization completed.");
                }
            }
        }

        private void PostIteration(int currentIteration, ExecResult result, DynamicDataSet dDataSet)
        {
            RESTApiTaskConfig TConfig = (RESTApiTaskConfig)_iterationConfig;
            dDataSet.Add(RESTApiTaskCommon.DynDataKeyURL, TConfig.URL);
            dDataSet.Add(RESTApiTaskCommon.DynDataKeyRawContent, _RawContent);
            dDataSet.Add(RESTApiTaskCommon.DynDataKeyHttpResult, _HttpResult);
            if (TConfig != null && TConfig.ReturnsRecordset)
                dDataSet.Add(CommonDynamicData.DefaultRecordsetName, _defaultRecordset);
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
