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
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDP.Robot.Core;
using TDP.Robot.Core.DynamicData;
using TDP.Robot.Core.Logging;

namespace TDP.Robot.Plugins.Core.WriteTextFileTask
{
    [Serializable]
    public class WriteTextFileTask : ITask
    {
        public IFolder ParentFolder { get; set; }
        public int ID { get; set; }
        public IPluginInstanceConfig Config { get; set; }

        public List<PluginInstanceConnection> Connections { get; } = new List<PluginInstanceConnection>();

        private string GetDelimiter(WriteTextFileTaskConfig config)
        {
            if (config.DelimiterTab)
                return "\t";
            if (config.DelimiterSemicolon)
                return ";";
            if (config.DelimiterComma)
                return ",";
            if (config.DelimiterSpace)
                return " ";
            if (config.DelimiterOther)
                return config.DelimiterOtherChar;
            return string.Empty;
        }

        private WriteTextFileTaskConfig ParseDynamicData(int iterationNumber, WriteTextFileTaskConfig config, DynamicDataChain dataChain)
        {
            WriteTextFileTaskConfig ConfigCopy = (WriteTextFileTaskConfig)CoreHelpers.CloneObjects(config);
            DynamicDataParser.Parse(ConfigCopy, dataChain, iterationNumber);
            
            foreach (WriteTextFileColumnDefinition Col in ConfigCopy.ColumnsDefinition)
            {
                Col.FieldValue = DynamicDataParser.ReplaceDynamicData(Col.FieldValue, dataChain, iterationNumber);
                Col.HeaderTitle = DynamicDataParser.ReplaceDynamicData(Col.HeaderTitle, dataChain, iterationNumber);
                Col.FieldWidth = DynamicDataParser.ReplaceDynamicData(Col.FieldWidth, dataChain, iterationNumber);
            }

            return ConfigCopy;
        }

        private bool ShouldAddHeader(WriteTextFileTaskConfig config)
        {
            if (!config.AddHeaderIfEmpty)
                return false;

            if (!File.Exists(config.FilePath))
                return true;

            FileInfo FI = new FileInfo(config.FilePath);
            if (FI.Length == 0)
                return true;

            return false;
        }

        private string[] BuildHeaderArray(WriteTextFileTaskConfig config, DynamicDataChain dataChain)
        {
            List<string> FieldValues = new List<string>();

            foreach (WriteTextFileColumnDefinition Col in config.ColumnsDefinition)
            {
                FieldValues.Add(Col.HeaderTitle);
            }

            return FieldValues.ToArray();
        }


        private string[] BuildDataArray(int iterationNumber, WriteTextFileTaskConfig config, DynamicDataChain dataChain)
        {
            List<string> FieldValues = new List<string>();

            foreach (WriteTextFileColumnDefinition Col in config.ColumnsDefinition)
            {
                FieldValues.Add(DynamicDataParser.ReplaceDynamicData(Col.FieldValue, dataChain, iterationNumber));
            }

            return FieldValues.ToArray();
        }

        private string BuildFixedFormatString(WriteTextFileTaskConfig config)
        {
            StringBuilder SB = new StringBuilder();

            int ColIndex = 0;
            foreach (WriteTextFileColumnDefinition Col in config.ColumnsDefinition)
            {
                SB.Append($"{{{ColIndex},-{Col.FieldWidth}}}");

                ColIndex++;
            }

            return SB.ToString();
        }

        private string BuildRow(WriteTextFileTaskConfig config, string[] fieldValues)
        {
            StringBuilder SB = new StringBuilder();

            if (!config.FormatAsDelimitedFile && !config.FormatAsFixedLengthColumnsFile)
            {
                // No configuration is specified, concatenate all fields
                foreach (string FieldValue in fieldValues)
                {
                    SB.Append(FieldValue);
                }
            }
            else if (config.FormatAsDelimitedFile)
            {
                string Delimiter = GetDelimiter(config);
                for (int c = 0; c < config.ColumnsDefinition.Count; c++)
                {
                    string FieldValue = fieldValues[c];
                    if (config.EncloseInDoubleQuotes)
                        FieldValue = $"\"{FieldValue.Replace("\"", "\"\"")}\"";

                    SB.Append(FieldValue);

                    if (c != (config.ColumnsDefinition.Count - 1))
                        SB.Append(Delimiter);
                }
            }
            else if (config.FormatAsFixedLengthColumnsFile)
            {
                string FixedFormatString = BuildFixedFormatString(config);
                SB.Append(string.Format(FixedFormatString, fieldValues));
            }

            return SB.ToString();
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

            int ActualIterations = 0;

            try
            {
                if (!Config.DoNotLog)
                    instanceLogger.TaskStarted(this);

                WriteTextFileTaskConfig TConfig = (WriteTextFileTaskConfig)Config;
                int IterationsCount = DynamicDataParser.GetIterationCount(TConfig, dataChain, lastDynamicDataSet);

                if (IterationsCount > 0)
                {
                    WriteTextFileTaskConfig ConfigCopy_0 = ParseDynamicData(0, TConfig, dataChain);

                    bool AddHeader = ShouldAddHeader(ConfigCopy_0);
                    
                    switch (TConfig.TaskType)
                    {
                        case WriteTextFileTaskType.AppendRow:
                            using (StreamWriter SW = new StreamWriter(ConfigCopy_0.FilePath, true))
                            {
                                for (int i = 0; i < IterationsCount; i++)
                                {
                                    if (AddHeader)
                                    {
                                        string[] HeaderValues = BuildHeaderArray(ConfigCopy_0, dataChain);
                                        SW.WriteLine(BuildRow(ConfigCopy_0, HeaderValues));
                                        AddHeader = false;
                                    }

                                    WriteTextFileTaskConfig ConfigCopy = ParseDynamicData(i, TConfig, dataChain);
                                    string[] FieldValues = BuildDataArray(i, ConfigCopy, dataChain);
                                    SW.WriteLine(BuildRow(ConfigCopy, FieldValues));

                                    ActualIterations++;
                                }
                            }   
                            break;

                        case WriteTextFileTaskType.InsertRow:
                            {
                                List<string> FileLines = File.ReadAllLines(ConfigCopy_0.FilePath).ToList();

                                for (int i = 0; i < IterationsCount; i++)
                                {
                                    if (AddHeader)
                                    {
                                        string[] HeaderValues = BuildHeaderArray(ConfigCopy_0, dataChain);
                                        FileLines.Add(BuildRow(ConfigCopy_0, HeaderValues));
                                        AddHeader = false;
                                    }

                                    WriteTextFileTaskConfig ConfigCopy = ParseDynamicData(i, TConfig, dataChain);
                                    string[] FieldValues = BuildDataArray(i, ConfigCopy, dataChain);
                                    FileLines.Insert(int.Parse(ConfigCopy.InsertAtRow), BuildRow(ConfigCopy, FieldValues));

                                    ActualIterations++;
                                }
                                File.WriteAllLines(ConfigCopy_0.FilePath, FileLines);
                            }
                            break;
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
