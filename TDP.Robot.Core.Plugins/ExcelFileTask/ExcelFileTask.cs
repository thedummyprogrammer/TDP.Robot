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
    public class ExcelFileTask : ITask
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

        public ExecResult Run(DynamicDataChain dataChain, DynamicDataSet lastDynamicDataSet, IPluginInstanceLogger instanceLogger)
        {
            ExecResult Result;
            DateTime StartDateTime = DateTime.Now;

            DataTable DefaultRecordset = new DataTable();

            int ActualIterations = 0;

            try
            {
                if (!Config.DoNotLog)
                    instanceLogger.TaskStarted(this);

                ExcelFileTaskConfig TConfig = (ExcelFileTaskConfig)Config;
                int IterationsCount = DynamicDataParser.GetIterationCount(TConfig, dataChain, lastDynamicDataSet);

                if (IterationsCount > 0)
                {
                    switch (TConfig.TaskType)
                    {
                        case ExcelFileTaskType.AppendRow:
                        case ExcelFileTaskType.InsertRow:
                            {
                                bool FileExists = File.Exists(TConfig.FilePath);

                                using (IXLWorkbook WksBook = (FileExists ? new XLWorkbook(TConfig.FilePath) : new XLWorkbook()))
                                {
                                    IXLWorksheet WksSheet;
                                    if (!WorksheetExists(WksBook, TConfig.SheetName))
                                        WksSheet = WksBook.Worksheets.Add(TConfig.SheetName);
                                    else
                                        WksSheet = WksBook.Worksheet(TConfig.SheetName);

                                    int LastRow = WksSheet.RowsUsed().Count();

                                    ExcelFileTaskConfig ConfigCopy_0 = (ExcelFileTaskConfig)CoreHelpers.CloneObjects(Config);
                                    DynamicDataParser.Parse(ConfigCopy_0, dataChain, 0);

                                    if (ConfigCopy_0.AddHeaderIfEmpty && (!FileExists || LastRow == 0))
                                    {
                                        LastRow = 1;
                                        // Create header
                                        // During header creation dynamic data is parsed only one time using the data first iteration                                        
                                        int ColIndex = 1;
                                        foreach (ExcelFileColumnDefinition Col in ConfigCopy_0.ColumnsDefinition)
                                        {
                                            WksSheet.Cell(LastRow, ColIndex).Value = DynamicDataParser.ReplaceDynamicData(Col.HeaderTitle, dataChain, 1);
                                            ColIndex++;
                                        }
                                    }

                                    if (TConfig.TaskType == ExcelFileTaskType.InsertRow)
                                    {
                                        int InsertAtRow = int.Parse(ConfigCopy_0.InsertAtRow);
                                        WksSheet.Row(InsertAtRow).InsertRowsAbove(IterationsCount);
                                        LastRow = InsertAtRow;
                                    }
                                    else
                                    {
                                        LastRow++;
                                    }
                                    
                                    for (int i = 0; i < IterationsCount; i++)
                                    {
                                        ExcelFileTaskConfig ConfigCopy = (ExcelFileTaskConfig)CoreHelpers.CloneObjects(Config);
                                        DynamicDataParser.Parse(ConfigCopy, dataChain, i);

                                        int ColIndex = 1;
                                        foreach (ExcelFileColumnDefinition Col in ConfigCopy.ColumnsDefinition)
                                        {
                                            WksSheet.Cell(LastRow, ColIndex).Value = DynamicDataParser.ReplaceDynamicData(Col.CellValue, dataChain, i);
                                            ColIndex++;
                                        }

                                        LastRow++;
                                        ActualIterations++;
                                    }

                                    if (FileExists)
                                        WksBook.Save();
                                    else
                                        WksBook.SaveAs(TConfig.FilePath);
                                }
                            }
                            break;

                        case ExcelFileTaskType.ReadRow:
                            {
                                using (IXLWorkbook WksBook = new XLWorkbook(TConfig.FilePath))
                                {
                                    IXLWorksheet WksSheet = WksBook.Worksheet(TConfig.SheetName);
                                    
                                    ExcelFileTaskConfig ConfigCopy_0 = (ExcelFileTaskConfig)CoreHelpers.CloneObjects(Config);
                                    DynamicDataParser.Parse(ConfigCopy_0, dataChain, 0);

                                    int ReadFromRow = 0;
                                    int ReadToRow = 0;
                                    int LastRow = WksSheet.RowsUsed().Count();
                                    int LastCol;
                                    if (!string.IsNullOrEmpty(ConfigCopy_0.NumColumnsToRead))
                                        LastCol = int.Parse(ConfigCopy_0.NumColumnsToRead);
                                    else
                                        LastCol = WksSheet.CellsUsed().Count();

                                    if (TConfig.ReadLastRowOption || TConfig.ReadRowNumberOption)
                                    {
                                        if (TConfig.ReadLastRowOption)
                                        {
                                            ReadFromRow = LastRow;
                                            ReadToRow = LastRow;
                                        }
                                        else
                                        {
                                            ReadFromRow = int.Parse(ConfigCopy_0.ReadRowNumber);
                                            ReadToRow = ReadFromRow;
                                        }
                                    }
                                    else if (TConfig.ReadIntervalOption)
                                    {
                                        switch (TConfig.ReadInterval)
                                        {
                                            case ExcelReadIntervalType.ReadLastNRows:
                                                int NumberOfRows = int.Parse(ConfigCopy_0.ReadNumberOfRows);
                                                if (LastRow - NumberOfRows >= 1)
                                                    ReadFromRow = LastRow - NumberOfRows;
                                                else
                                                    ReadFromRow = 1;

                                                ReadToRow = LastRow;
                                                break;

                                            case ExcelReadIntervalType.ReadFromRowToRow:
                                                ReadFromRow = int.Parse(ConfigCopy_0.ReadFromRow);

                                                if (ReadFromRow <= LastRow)
                                                {                                                
                                                    ReadToRow = int.Parse(ConfigCopy_0.ReadToRow);

                                                    if (ReadToRow > LastRow)
                                                        ReadToRow = LastRow;
                                                }
                                                break;

                                            case ExcelReadIntervalType.ReadFromRowToLastRow:
                                                ReadFromRow = int.Parse(ConfigCopy_0.ReadFromRow);
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
                                            
                                            ActualIterations++;
                                        }
                                    }
                                }
                            }
                            break;
                    }
                }

                DynamicDataSet DDataSet = CommonDynamicData.BuildStandardDynamicDataSet(this, true, 0, StartDateTime, DateTime.Now, ActualIterations);

                if (TConfig.TaskType == ExcelFileTaskType.ReadRow)
                    DDataSet.Add(CommonDynamicData.DefaultRecordsetName, DefaultRecordset);
                Result = new ExecResult(true, DDataSet);

                if (!Config.DoNotLog)
                {
                    instanceLogger.Info(this, $"Rows processed: {ActualIterations}");
                    instanceLogger.TaskCompleted(this);
                }
                    
            }
            catch (Exception ex)
            {
                if (!Config.DoNotLog)
                {
                    instanceLogger.Info(this, $"Rows processed: {ActualIterations}");
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
