using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDP.Robot.Core;
using TDP.Robot.Core.DynamicData;
using TDP.Robot.Core.Logging;
using TDP.Robot.Plugins.Core.ExcelFileTask;

namespace TDP.Robot.UnitTests
{
    [TestClass]
    public class TestExcelFileTask
    {
        [TestMethod]
        public void TestReadWrite()
        {
            // Arrange
            string BasePath = AppDomain.CurrentDomain.BaseDirectory;
            Core.Config.BasePath = BasePath;
            Core.Config.LogPath = Path.Combine(BasePath, @"Log\");

            Folder FakeFolder = new Folder();
            FakeFolder.ID = 0;

            File.Delete(Path.Combine(BasePath, "TestExcel.xlsx"));

            ExcelFileTaskConfig TaskWriteConfig = new ExcelFileTaskConfig();
            TaskWriteConfig.ID = 1;
            TaskWriteConfig.Name = "Excel file task (write)";
            TaskWriteConfig.AddHeaderIfEmpty = true;
            TaskWriteConfig.FilePath = Path.Combine(BasePath, "TestExcel.xlsx");
            TaskWriteConfig.TaskType = ExcelFileTaskType.AppendRow;
            TaskWriteConfig.SheetName = "Test";

            ExcelFileColumnDefinition Column1 = new ExcelFileColumnDefinition("ID", "{Object[2].DefaultRecordset['ID']}");
            ExcelFileColumnDefinition Column2 = new ExcelFileColumnDefinition("Name", "{Object[2].DefaultRecordset['Value']}");

            TaskWriteConfig.ColumnsDefinition.Add(Column1);
            TaskWriteConfig.ColumnsDefinition.Add(Column2);

            ExcelFileTask TaskWrite = new ExcelFileTask();
            TaskWrite.Config = TaskWriteConfig;
            TaskWrite.ParentFolder = FakeFolder;

            DataTable Dt = new DataTable();
            Dt.Columns.Add("ID", typeof(int));
            Dt.Columns.Add("Value", typeof(string));

            DataRow Dr = Dt.NewRow();
            Dr["ID"] = 1;
            Dr["Value"] = "Matthew";
            Dt.Rows.Add(Dr);

            Dr = Dt.NewRow();
            Dr["ID"] = 2;
            Dr["Value"] = "Marcus";
            Dt.Rows.Add(Dr);

            Dr = Dt.NewRow();
            Dr["ID"] = 3;
            Dr["Value"] = "Luke";
            Dt.Rows.Add(Dr);

            Dr = Dt.NewRow();
            Dr["ID"] = 4;
            Dr["Value"] = "John";
            Dt.Rows.Add(Dr);

            DynamicDataSet DDataSet = new DynamicDataSet();
            DDataSet.Add("DefaultRecordset", Dt);

            DynamicDataChain DDataChain = new DynamicDataChain();
            DDataChain.Add(2, DDataSet);

            IPluginInstanceLogger Logger = PluginInstanceLogger.GetLogger(TaskWrite);


            ExcelFileTaskConfig TaskReadConfig = new ExcelFileTaskConfig();
            TaskReadConfig.ID = 3;
            TaskReadConfig.Name = "Excel file task (read)";
            TaskReadConfig.AddHeaderIfEmpty = true;
            TaskReadConfig.FilePath = Path.Combine(BasePath, "TestExcel.xlsx");
            TaskReadConfig.TaskType = ExcelFileTaskType.ReadRow;
            TaskReadConfig.SheetName = "Test";
            TaskReadConfig.ReadIntervalOption = true;
            TaskReadConfig.ReadLastRowOption = false;
            TaskReadConfig.ReadRowNumberOption = false;
            TaskReadConfig.ReadInterval = ExcelReadIntervalType.ReadFromRowToLastRow;
            TaskReadConfig.ReadFromRow = "1";
            TaskReadConfig.NumColumnsToRead = "2";

            ExcelFileTask TaskRead = new ExcelFileTask();
            TaskRead.Config = TaskReadConfig;
            TaskRead.ParentFolder = FakeFolder;

            // Act && Assert
            TaskWrite.Init();
            TaskRead.Init();

            TaskWrite.Run(DDataChain, DDataSet, Logger);
            ExecResult ER = TaskRead.Run(DDataChain, DDataSet, Logger);

            DataTable DtRead = (DataTable)ER.Data["DefaultRecordset"];

            Assert.IsTrue(Dt.Rows.Count == (DtRead.Rows.Count - 1));    // Subtract 1 to consider header
            Assert.IsTrue(Dt.Columns.Count == DtRead.Columns.Count);
            Assert.IsTrue(((DtRead.Rows[0][0].ToString() == "ID") && (DtRead.Rows[0][1].ToString() == "Name")));

            for (int r = 1; r < DtRead.Rows.Count; r++)
            {
                for (int c = 0; c < DtRead.Columns.Count; c++)
                {
                    Assert.IsTrue(DtRead.Rows[r][c].ToString() == Dt.Rows[r - 1][c].ToString());
                }
            }
        }
    }
}
