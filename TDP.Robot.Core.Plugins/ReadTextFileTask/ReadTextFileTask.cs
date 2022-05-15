﻿/*======================================================================================
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

using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDP.Robot.Core;
using TDP.Robot.Core.DynamicData;
using TDP.Robot.Core.Logging;

namespace TDP.Robot.Plugins.Core.ReadTextFileTask
{
    [Serializable]
    public class ReadTextFileTask : IterationTask
    {
        

        private string[] BuildDelimitersArray(ReadTextFileTaskConfig config)
        {
            List<string> Delimiters = new List<string>();

            if (config.DelimiterTab)
                Delimiters.Add("\t");
            
            if (config.DelimiterSemicolon)
                Delimiters.Add(@";");

            if (config.DelimiterComma)
                Delimiters.Add(@",");

            if (config.DelimiterSpace)
                Delimiters.Add(@" ");

            if (config.DelimiterOther)
                Delimiters.Add(config.DelimiterOtherChar);

            return Delimiters.ToArray();
        }

        private void BuildCustomDataTable(DataTable recordset, ReadTextFileTaskConfig config)
        {
            foreach (ReadTextFileColumnDefinition ColDef in config.ColumnsDefinition)
            {
                if (ColDef.ColumnDataType == ReadTextFileColumnDataType.String)
                    recordset.Columns.Add(ColDef.ColumnName, typeof(string));
                else if (ColDef.ColumnDataType == ReadTextFileColumnDataType.Integer)
                    recordset.Columns.Add(ColDef.ColumnName, typeof(int));
                else if (ColDef.ColumnDataType == ReadTextFileColumnDataType.Decimal)
                    recordset.Columns.Add(ColDef.ColumnName, typeof(decimal));
                else if (ColDef.ColumnDataType == ReadTextFileColumnDataType.Datetime)
                    recordset.Columns.Add(ColDef.ColumnName, typeof(DateTime));
            }
        }

        private void AdjustDataTableColumnsCount(DataTable dt, int columnsCount)
        {
            if (dt.Columns.Count < columnsCount)
            {
                int InitialColCount = dt.Columns.Count;
                for (int i = 1; i <= columnsCount - InitialColCount; i++)
                {
                    dt.Columns.Add("Column" + (dt.Columns.Count + i).ToString(), typeof(string));
                }
            }
        }

        private CultureInfo GetCulture(string culture)
        {
            if (string.IsNullOrEmpty(culture))
                return CultureInfo.InvariantCulture;

            return CultureInfo.GetCultureInfo(culture);
        }

        private string[] ReadRow(TextFieldParser parser, ReadTextFileTaskConfig config)
        {
            if (config.SplitColumnsType == ReadTextFileSplitColumnsType.None || config.SplitColumnsType == ReadTextFileSplitColumnsType.UseFixedWidthColumns)
                return new string[] { parser.ReadLine() };
            else // TextFileReadSplitColumnsType.UseDelimiters
            {
                return parser.ReadFields();
            }
        }

        private void FillDataRowColumn(ReadTextFileColumnDefinition colDef, string val, DataRow dataRow)
        {
            if (val.ToUpper().Trim() == "NULL" && colDef.ColumnTreatNullStringAsNull)
            {
                dataRow[colDef.ColumnName] = DBNull.Value;
                return;
            }               

            if (colDef.ColumnDataType == ReadTextFileColumnDataType.String)
                dataRow[colDef.ColumnName] = val;
            else if (colDef.ColumnDataType == ReadTextFileColumnDataType.Integer)
            {
                dataRow[colDef.ColumnName] = int.Parse(val, GetCulture(colDef.ColumnExpectedCulture));
            }
            else if (colDef.ColumnDataType == ReadTextFileColumnDataType.Decimal)
            {
                dataRow[colDef.ColumnName] = decimal.Parse(val, GetCulture(colDef.ColumnExpectedCulture));
            }
            else if (colDef.ColumnDataType == ReadTextFileColumnDataType.Datetime)
            {
                dataRow[colDef.ColumnName] = DateTime.ParseExact(val, colDef.ColumnExpectedFormat, GetCulture(colDef.ColumnExpectedCulture));
            }
        }

        private void AddRow(int rowIndex, string[] row, ReadTextFileTaskConfig config, DataTable recordset)
        {
            if (config.SplitColumnsType == ReadTextFileSplitColumnsType.None || !config.OverrideDefaultColumnsDefinition)
            {
                AdjustDataTableColumnsCount(recordset, row.Length);
                recordset.Rows.Add(row);
            }
            else if (config.SplitColumnsType == ReadTextFileSplitColumnsType.UseDelimiters)
            {
                int ColumnPosition = int.MinValue;

                try
                {
                    DataRow DR = recordset.NewRow();
                    foreach (ReadTextFileColumnDefinition ColDef in config.ColumnsDefinition)
                    {
                        // **** Only for logging purpose
                        if (ColDef.ColumnPosition == null)
                            ColumnPosition = int.MinValue;
                        else
                            ColumnPosition = (int)ColDef.ColumnPosition;

                        if (!ColDef.ColumnIsIdentity)
                        {
                            string TempColumnValue = row[(int)ColDef.ColumnPosition - 1];
                            FillDataRowColumn(ColDef, TempColumnValue, DR);
                        }
                        // **** 
                    }
                    recordset.Rows.Add(DR);
                }
                catch (Exception ex)
                {
                    throw new ApplicationException($"An error occurred adding row into datatable. Row: {rowIndex} Column position: {ColumnPosition}", ex);
                }
            }
            else if (config.SplitColumnsType == ReadTextFileSplitColumnsType.UseFixedWidthColumns)
            {
                int ColumnStartsFrom = int.MinValue;
                int ColumnEndsTo = int.MinValue;

                try
                {
                    DataRow DR = recordset.NewRow();
                    string FullRow = row[0];
                    foreach (ReadTextFileColumnDefinition ColDef in config.ColumnsDefinition)
                    {
                        // **** Only for logging purpose
                        if (ColDef.ColumnStartsFromCharPos == null)
                            ColumnStartsFrom = int.MinValue;
                        else
                            ColumnStartsFrom = (int)ColDef.ColumnStartsFromCharPos;

                        if (ColDef.ColumnEndsAtCharPos == null)
                            ColumnEndsTo = int.MinValue;
                        else
                            ColumnEndsTo = (int)ColDef.ColumnEndsAtCharPos;
                        // **** 

                        if (!ColDef.ColumnIsIdentity)
                        {
                            string TempColumnValue = FullRow.Substring((int)ColDef.ColumnStartsFromCharPos - 1, (int)((ColDef.ColumnEndsAtCharPos - 1) - (ColDef.ColumnStartsFromCharPos - 1) + 1));
                            FillDataRowColumn(ColDef, TempColumnValue, DR);
                        }
                    }
                    recordset.Rows.Add(DR);
                }
                catch (Exception ex)
                {
                    throw new ApplicationException($"An error occurred adding row into datatable. Row: {rowIndex} Column starts from: {ColumnStartsFrom} Column ends to: {ColumnEndsTo}", ex);
                }
            }
        }

        protected override void RunIteration(int currentIteration)
        {
            // For this kind of objects consider only one iteration
            ReadTextFileTaskConfig TConfig = (ReadTextFileTaskConfig)_iterationConfig;
            DataTable DefaultRecordset = new DataTable();
            _defaultRecordset = DefaultRecordset;

            // If columns definition have been overriden, build the datatable according to user definition
            if (TConfig.OverrideDefaultColumnsDefinition)
                BuildCustomDataTable(DefaultRecordset, TConfig);

            using (TextFieldParser FileParser = new TextFieldParser(TConfig.FilePath))
            {
                if (TConfig.SplitColumnsType == ReadTextFileSplitColumnsType.UseDelimiters)
                {
                    FileParser.TextFieldType = FieldType.Delimited;
                    FileParser.Delimiters = BuildDelimitersArray(TConfig);
                    FileParser.HasFieldsEnclosedInQuotes = TConfig.UseDoubleQuotes;
                }

                int ReadFromRow = 0;
                int ReadToRow = 0;
                int CurrentRow = 1;

                if (TConfig.ReadAllTheRowsOption)
                {
                    while (!FileParser.EndOfData)
                    {
                        try
                        {
                            string[] Row = ReadRow(FileParser, TConfig);

                            if (CurrentRow == 1 && TConfig.SkipFirstLine)
                            {
                                CurrentRow++;
                                continue;
                            }

                            AddRow(CurrentRow, Row, TConfig, DefaultRecordset);
                        }
                        catch (MalformedLineException ex)
                        {
                            _instanceLogger.Error(this, "Error parsing line", ex);
                        }

                        CurrentRow++;
                    }
                }
                else if (TConfig.ReadLastRowOption)
                {
                    string[] Row = null;
                    while (!FileParser.EndOfData)
                    {
                        try
                        {
                            Row = ReadRow(FileParser, TConfig);
                            CurrentRow++;
                        }
                        catch (MalformedLineException ex)
                        {
                            _instanceLogger.Error(this, "Error parsing line", ex);
                        }
                    }
                    if (Row != null)
                    {
                        AddRow(CurrentRow, Row, TConfig, DefaultRecordset);
                    }
                }
                else if (TConfig.ReadRowNumberOption || (TConfig.ReadIntervalOption && TConfig.ReadInterval == ReadTextFileIntervalType.ReadFromRowToRow))
                {
                    if (TConfig.ReadRowNumberOption)
                    {
                        ReadFromRow = int.Parse(TConfig.ReadRowNumber);
                        ReadToRow = ReadFromRow;
                    }
                    else
                    {
                        ReadFromRow = int.Parse(TConfig.ReadFromRow);
                        ReadToRow = int.Parse(TConfig.ReadToRow);
                    }

                    string[] Row = null;
                    while (!FileParser.EndOfData)
                    {
                        try
                        {
                            if (CurrentRow > ReadToRow)
                                break;

                            Row = ReadRow(FileParser, TConfig);
                            if (CurrentRow >= ReadFromRow && CurrentRow <= ReadToRow)
                            {
                                AddRow(CurrentRow, Row, TConfig, DefaultRecordset);
                            }
                        }
                        catch (MalformedLineException ex)
                        {
                            _instanceLogger.Error(this, "Error parsing line", ex);
                        }

                        CurrentRow++;
                    }
                }
                else
                {
                    List<string[]> Rows = new List<string[]>();
                    string[] Row = null;
                    while (!FileParser.EndOfData)
                    {
                        try
                        {
                            Row = ReadRow(FileParser, TConfig);
                            Rows.Add(Row);
                        }
                        catch (MalformedLineException ex)
                        {
                            _instanceLogger.Error(this, "Error parsing line", ex);
                        }
                    }

                    if (Rows.Count > 0)
                    {
                        if (TConfig.ReadInterval == ReadTextFileIntervalType.ReadFromRowToLastRow)
                        {
                            // From row to end
                            ReadFromRow = int.Parse(TConfig.ReadFromRow);
                            ReadFromRow--;
                            if (ReadFromRow < 0) ReadFromRow = 0;
                        }
                        else
                        {
                            // Read N Last rows
                            ReadFromRow = (Rows.Count - 1) - int.Parse(TConfig.ReadNumberOfRows);
                        }

                        if (ReadFromRow <= (Rows.Count - 1))
                        {
                            for (int RowIndex = ReadFromRow; RowIndex < Rows.Count; RowIndex++)
                            {
                                AddRow(RowIndex, Row, TConfig, DefaultRecordset);
                            }
                        }
                    }
                }
            }
        }

        private void PostIteration(int currentIteration, ExecResult result, DynamicDataSet dDataSet)
        {
            if (!Config.DoNotLog)
            {
                _instanceLogger.Info(this, $"Rows processed: {currentIteration - 1}");
                _instanceLogger.TaskCompleted(this);
            }

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
