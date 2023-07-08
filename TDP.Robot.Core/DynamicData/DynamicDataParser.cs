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
using System.Reflection;
using System.Text.RegularExpressions;

namespace TDP.Robot.Core.DynamicData
{
    public static class DynamicDataParser
    {       
        private static Regex _RegExFieldValue = new Regex(@"\{object\[(?<ObjectID>\d+)\]\.(?<FieldName>\w+)(\[\'(?<SubFieldName>\w+)\'\])?\}", RegexOptions.IgnoreCase);

        public static string ReplaceDynamicData(string input, DynamicDataChain dynamicDataChain, int iterationNumber)
        {
            if (input == null)
                return string.Empty;

            return _RegExFieldValue.Replace(input, (RegExMatch) => {
                string Result = string.Empty;
                int ObjectID = int.Parse(RegExMatch.Groups["ObjectID"].Value);
                string FieldName = RegExMatch.Groups["FieldName"].Value;
                string SubFieldName;
                
                DynamicDataSet ObjectDataSet = dynamicDataChain[ObjectID];

                if (RegExMatch.Groups["SubFieldName"].Value == string.Empty)
                {
                    Result = ObjectDataSet[FieldName].ToString();
                }
                else
                {
                    SubFieldName = RegExMatch.Groups["SubFieldName"].Value;

                    if (ObjectDataSet[FieldName] is List<Dictionary<string, object>>)
                    {
                        List<Dictionary<string, object>> List = (List<Dictionary<string, object>>)ObjectDataSet[FieldName];
                        Dictionary<string, object> Row = List[iterationNumber];
                        Result = Row[SubFieldName].ToString();
                    }
                    else if (ObjectDataSet[FieldName] is DataTable)
                    {
                        DataTable List = (DataTable)ObjectDataSet[FieldName];
                        DataRow Row = List.Rows[iterationNumber];
                        Result = Row[SubFieldName].ToString();
                    }
                }

                return Result;
            });
        }

        public static object GetDynamicDataObject(string input, DynamicDataChain dynamicDataChain)
        {
            if (input == null)
                return null;

            object Result = null;
            Match RegExMatch = _RegExFieldValue.Match(input);

            if (RegExMatch.Success)
            {
                int ObjectID = int.Parse(RegExMatch.Groups["ObjectID"].Value);
                string FieldName = RegExMatch.Groups["FieldName"].Value;

                DynamicDataSet ObjectDataSet = dynamicDataChain[ObjectID];
                Result = ObjectDataSet[FieldName];
            }

            return Result;
        }

        public static int GetIterationCount(ITaskConfig config, DynamicDataChain dynamicDataChain, DynamicDataSet dynamicDataSet)
        {
            int Count = 1;
            
            if (config.PluginIterationMode == IterationMode.IterateDefaultRecordset)
            {
                if (dynamicDataSet.ContainsKey(CommonDynamicData.DefaultRecordsetName))
                {
                    if (dynamicDataSet[CommonDynamicData.DefaultRecordsetName] is List<Dictionary<string, object>>)
                    {
                        Count = ((List<Dictionary<string, object>>)dynamicDataSet[CommonDynamicData.DefaultRecordsetName]).Count;
                    }
                    else if (dynamicDataSet[CommonDynamicData.DefaultRecordsetName] is DataTable)
                    {
                        Count = ((DataTable)dynamicDataSet[CommonDynamicData.DefaultRecordsetName]).Rows.Count;
                    }
                }
            }
            else if (config.PluginIterationMode == IterationMode.IterateObjectRecordset)
            {
                Count = int.Parse(ReplaceDynamicData(config.IterationObject, dynamicDataChain, 0));
            }
            else // Extact number of times
            {
                Count = config.IterationsCount;
            }

            return Count;
        }

        public static bool ContainsDynamicData(string input)
        {
            return _RegExFieldValue.IsMatch(input);
        }

        public static void Parse(IPluginInstanceConfig config, DynamicDataChain dynamicDataChain, int iterationNumber)
        {
            Type ConfigType = config.GetType();

            foreach (PropertyInfo Prop in ConfigType.GetProperties())
            {
                if (Prop.PropertyType == typeof(string) || Prop.PropertyType == typeof(List<string>))
                {
                    foreach (CustomAttributeData CA in Prop.CustomAttributes)
                    {
                        if (CA.AttributeType == typeof(DynamicDataAttribute))
                        {
                            System.Diagnostics.Debug.WriteLine("Parsing property: " + Prop.Name);

                            if (Prop.PropertyType == typeof(string))
                            {
                                string PropertyValue = (string)Prop.GetValue(config);
                                string Result = ReplaceDynamicData(PropertyValue, dynamicDataChain, iterationNumber);
                                Prop.SetValue(config, Result);
                            }
                            else if (Prop.PropertyType == typeof(List<string>))
                            {
                                List<string> TempList = (List<string>)Prop.GetValue(config);
                                for (int i = 0; i <= TempList.Count - 1; i++)
                                {
                                    string NewT = ReplaceDynamicData(TempList[i], dynamicDataChain, iterationNumber);
                                    TempList[i] = NewT;
                                }
                            }
                        }
                    }
                }
            }
        }

        public static void Parse(ITask task, DynamicDataChain dynamicDataChain, int iterationNumber)
        {
            IPluginInstanceConfig Config = task.Config;
            Parse(Config, dynamicDataChain, iterationNumber);
        }
    }
}
