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
    public class WriteTextFileTask : BaseTask
    {
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

        protected override void RunTask()
        {
            WriteTextFileTaskConfig TConfig_0 = ParseDynamicData(0, (WriteTextFileTaskConfig)Config, _dataChain);
            
            int i = 0;
            bool AddHeader = ShouldAddHeader(TConfig_0);
            DateTime StartDateTime = DateTime.Now;

            try
            {
                switch (TConfig_0.TaskType)
                {
                    case WriteTextFileTaskType.AppendRow:
                        using (StreamWriter SW = new StreamWriter(TConfig_0.FilePath, true))
                        {
                            for (i = 0; i < _iterationsCount; i++)
                            {
                                if (AddHeader)
                                {
                                    string[] HeaderValues = BuildHeaderArray(TConfig_0, _dataChain);
                                    SW.WriteLine(BuildRow(TConfig_0, HeaderValues));
                                    AddHeader = false;
                                }

                                WriteTextFileTaskConfig ConfigCopy = ParseDynamicData(i, (WriteTextFileTaskConfig)Config, _dataChain);
                                string[] FieldValues = BuildDataArray(i, ConfigCopy, _dataChain);
                                SW.WriteLine(BuildRow(ConfigCopy, FieldValues));
                            }
                        }
                        break;

                    case WriteTextFileTaskType.InsertRow:
                        {
                            List<string> FileLines = File.ReadAllLines(TConfig_0.FilePath).ToList();

                            for (i = 0; i < _iterationsCount; i++)
                            {
                                if (AddHeader)
                                {
                                    string[] HeaderValues = BuildHeaderArray(TConfig_0, _dataChain);
                                    FileLines.Add(BuildRow(TConfig_0, HeaderValues));
                                    AddHeader = false;
                                }

                                WriteTextFileTaskConfig ConfigCopy = ParseDynamicData(i, (WriteTextFileTaskConfig)Config, _dataChain);
                                string[] FieldValues = BuildDataArray(i, ConfigCopy, _dataChain);
                                FileLines.Insert(int.Parse(ConfigCopy.InsertAtRow), BuildRow(ConfigCopy, FieldValues));
                            }
                            File.WriteAllLines(TConfig_0.FilePath, FileLines);
                        }
                        break;
                }

                DynamicDataSet DDataSet = CommonDynamicData.BuildStandardDynamicDataSet(this, true, 0, StartDateTime, DateTime.Now, _iterationsCount);
                ExecResult Result = new ExecResult(true, DDataSet);
                _execResults.Add(Result);
            }
            catch (Exception ex)
            {
                if (!Config.DoNotLog)
                    _instanceLogger.TaskError(this, ex);

                DynamicDataSet DDataSet = CommonDynamicData.BuildStandardDynamicDataSet(this, false, -1, StartDateTime, DateTime.Now, i + 1);
                ExecResult Result = new ExecResult(false, DDataSet);
                _execResults.Add(Result);
            }
        }
    }
}
