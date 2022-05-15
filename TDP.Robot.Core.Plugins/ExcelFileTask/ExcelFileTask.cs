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

using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using TDP.Robot.Core;
using TDP.Robot.Core.DynamicData;
using TDP.Robot.Core.Logging;

namespace TDP.Robot.Plugins.Core.ExcelFileTask
{
    [Serializable]
    public class ExcelFileTask : BaseTask
    {
        bool WorksheetExists(IXLWorkbook wb, string worksheetName)
        {
            int TotalWorksheets = wb.Worksheets.Count();
            for (int i = 1; i <= TotalWorksheets; i++)
            {
                if (wb.Worksheet(i).Name == worksheetName)
                    return true;
            }

            return false;
        }

        protected override void RunTask()
        {
            DateTime StartDateTime = DateTime.Now;
            DataTable DefaultRecordset = new DataTable();

            int ActualIterations = 1;
            ExcelFileTaskConfig TConfig_0 = (ExcelFileTaskConfig)CoreHelpers.CloneObjects(Config);
            DynamicDataParser.Parse(TConfig_0, _dataChain, 0);

            try
            {
                
                switch (TConfig_0.TaskType)
                {
                    case ExcelFileTaskType.AppendRow:
                    case ExcelFileTaskType.InsertRow:
                        {
                            bool FileExists = File.Exists(TConfig_0.FilePath);

                            using (IXLWorkbook WksBook = (FileExists ? new XLWorkbook(TConfig_0.FilePath) : new XLWorkbook()))
                            {
                                IXLWorksheet WksSheet;
                                if (!WorksheetExists(WksBook, TConfig_0.SheetName))
                                    WksSheet = WksBook.Worksheets.Add(TConfig_0.SheetName);
                                else
                                    WksSheet = WksBook.Worksheet(TConfig_0.SheetName);

                                int LastRow = WksSheet.RowsUsed().Count();

                                ExcelFileTaskConfig ConfigCopy_0 = (ExcelFileTaskConfig)CoreHelpers.CloneObjects(Config);
                                DynamicDataParser.Parse(ConfigCopy_0, _dataChain, 0);

                                if (ConfigCopy_0.AddHeaderIfEmpty && (!FileExists || LastRow == 0))
                                {
                                    LastRow = 1;
                                    // Create header
                                    // During header creation dynamic data is parsed only one time using the data first iteration                                        
                                    int ColIndex = 1;
                                    foreach (ExcelFileColumnDefinition Col in ConfigCopy_0.ColumnsDefinition)
                                    {
                                        WksSheet.Cell(LastRow, ColIndex).Value = DynamicDataParser.ReplaceDynamicData(Col.HeaderTitle, _dataChain, 1);
                                        ColIndex++;
                                    }
                                }

                                if (TConfig_0.TaskType == ExcelFileTaskType.InsertRow)
                                {
                                    int InsertAtRow = int.Parse(ConfigCopy_0.InsertAtRow);
                                    WksSheet.Row(InsertAtRow).InsertRowsAbove(_iterationsCount);
                                    LastRow = InsertAtRow;
                                }
                                else
                                {
                                    LastRow++;
                                }
                                    
                                for (int i = 0; i < _iterationsCount; i++)
                                {
                                    ExcelFileTaskConfig ConfigCopy = (ExcelFileTaskConfig)CoreHelpers.CloneObjects(Config);
                                    DynamicDataParser.Parse(ConfigCopy, _dataChain, i);

                                    int ColIndex = 1;
                                    foreach (ExcelFileColumnDefinition Col in ConfigCopy.ColumnsDefinition)
                                    {
                                        WksSheet.Cell(LastRow, ColIndex).Value = DynamicDataParser.ReplaceDynamicData(Col.CellValue, _dataChain, i);
                                        ColIndex++;
                                    }

                                    LastRow++;
                                    ActualIterations++;
                                }

                                if (FileExists)
                                    WksBook.Save();
                                else
                                    WksBook.SaveAs(TConfig_0.FilePath);
                            }
                        }
                        break;

                    case ExcelFileTaskType.ReadRow:
                        {
                            using (IXLWorkbook WksBook = new XLWorkbook(TConfig_0.FilePath))
                            {
                                IXLWorksheet WksSheet = WksBook.Worksheet(TConfig_0.SheetName);

                                int ReadFromRow = 0;
                                int ReadToRow = 0;
                                int LastRow = WksSheet.RowsUsed().Count();
                                int LastCol;
                                if (!string.IsNullOrEmpty(TConfig_0.NumColumnsToRead))
                                    LastCol = int.Parse(TConfig_0.NumColumnsToRead);
                                else
                                    LastCol = WksSheet.CellsUsed().Count();

                                if (TConfig_0.ReadLastRowOption || TConfig_0.ReadRowNumberOption)
                                {
                                    if (TConfig_0.ReadLastRowOption)
                                    {
                                        ReadFromRow = LastRow;
                                        ReadToRow = LastRow;
                                    }
                                    else
                                    {
                                        ReadFromRow = int.Parse(TConfig_0.ReadRowNumber);
                                        ReadToRow = ReadFromRow;
                                    }
                                }
                                else if (TConfig_0.ReadIntervalOption)
                                {
                                    switch (TConfig_0.ReadInterval)
                                    {
                                        case ExcelReadIntervalType.ReadLastNRows:
                                            int NumberOfRows = int.Parse(TConfig_0.ReadNumberOfRows);
                                            if (LastRow - NumberOfRows >= 1)
                                                ReadFromRow = LastRow - NumberOfRows;
                                            else
                                                ReadFromRow = 1;

                                            ReadToRow = LastRow;
                                            break;

                                        case ExcelReadIntervalType.ReadFromRowToRow:
                                            ReadFromRow = int.Parse(TConfig_0.ReadFromRow);

                                            if (ReadFromRow <= LastRow)
                                            {                                                
                                                ReadToRow = int.Parse(TConfig_0.ReadToRow);

                                                if (ReadToRow > LastRow)
                                                    ReadToRow = LastRow;
                                            }
                                            break;

                                        case ExcelReadIntervalType.ReadFromRowToLastRow:
                                            ReadFromRow = int.Parse(TConfig_0.ReadFromRow);
                                            ReadToRow = LastRow;
                                            break;
                                    }
                                }

                                if (ReadToRow >= ReadFromRow 
                                    && ReadFromRow > 0 
                                    && ReadToRow > 0)
                                {
                                    for (int CurCol = 1; CurCol <= LastCol; CurCol++)
                                    {
                                        DefaultRecordset.Columns.Add("Column" + CurCol.ToString());
                                    }

                                    for (int CurRow = ReadFromRow; CurRow <= ReadToRow; CurRow++)
                                    {
                                        DataRow DR = DefaultRecordset.NewRow();
                                        for (int CurCol = 1; CurCol <= LastCol; CurCol++)
                                        {
                                            DR[CurCol - 1] = WksSheet.Cell(CurRow, CurCol).Value.ToString();
                                        }
                                        DefaultRecordset.Rows.Add(DR);
                                    }
                                }
                            }
                        }
                        break;
                }
                

                DynamicDataSet DDataSet = CommonDynamicData.BuildStandardDynamicDataSet(this, true, 0, StartDateTime, DateTime.Now, _iterationsCount);

                if (TConfig_0.TaskType == ExcelFileTaskType.ReadRow)
                    DDataSet.Add(CommonDynamicData.DefaultRecordsetName, DefaultRecordset);
                ExecResult Result = new ExecResult(true, DDataSet);
                _execResults.Add(Result);

                if (!Config.DoNotLog)
                {
                    _instanceLogger.Info(this, $"Rows processed: {_iterationsCount}");
                    _instanceLogger.TaskCompleted(this);
                }
                    
            }
            catch (Exception ex)
            {
                if (!Config.DoNotLog)
                {
                    _instanceLogger.Info(this, $"Rows processed: {ActualIterations}");
                    _instanceLogger.TaskError(this, ex);
                }

                DynamicDataSet DDataSet = CommonDynamicData.BuildStandardDynamicDataSet(this, false, -1, StartDateTime, DateTime.Now, ActualIterations);
                ExecResult Result = new ExecResult(false, DDataSet);
                _execResults.Add(Result);
            }
        }
    }
}
