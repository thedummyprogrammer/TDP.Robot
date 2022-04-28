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
using TDP.Robot.Plugins.Core.SqlServerCommandTask;

namespace TDP.Robot.UnitTests
{
    [TestClass]
    public class TestSqlServerCommandTask
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

            SqlServerCommandTaskConfig TaskCleanConfig = new SqlServerCommandTaskConfig();
            TaskCleanConfig.ID = 1;
            TaskCleanConfig.Name = "DB task (clean)";
            TaskCleanConfig.Server = "(local)";
            TaskCleanConfig.Database = "TestDB";
            TaskCleanConfig.Username = "Test";
            TaskCleanConfig.Password = "12345";
            TaskCleanConfig.ConnectionStringOptions = "";
            TaskCleanConfig.Query = "DELETE FROM TestTable";
            TaskCleanConfig.ReturnsRecordset = false;
            TaskCleanConfig.PluginIterationMode = IterationMode.IterateExactNumber;
            TaskCleanConfig.IterationsCount = 1;
            
            SqlServerCommandTask TaskClean = new SqlServerCommandTask();
            TaskClean.Config = TaskCleanConfig;
            TaskClean.ParentFolder = FakeFolder;


            SqlServerCommandTaskConfig TaskWriteConfig = new SqlServerCommandTaskConfig();
            TaskWriteConfig.ID = 2;
            TaskWriteConfig.Name = "DB task (write)";
            TaskWriteConfig.Server = "(local)";
            TaskWriteConfig.Database = "TestDB";
            TaskWriteConfig.Username = "Test";
            TaskWriteConfig.Password = "12345";
            TaskWriteConfig.ConnectionStringOptions = "";
            TaskWriteConfig.Query = "INSERT INTO TestTable(ID, [Value]) VALUES(@ID, @VALUE)";
            TaskWriteConfig.ParamsDefinition.Add(new SqlServerParamDefinition("@ID", "{Object[2].DefaultRecordset['ID']}", SqlParamType.Int, string.Empty, string.Empty));
            TaskWriteConfig.ParamsDefinition.Add(new SqlServerParamDefinition("@VALUE", "{Object[2].DefaultRecordset['Value']}", SqlParamType.Varchar, "100", string.Empty));
            TaskWriteConfig.ReturnsRecordset = false;

            SqlServerCommandTask TaskWrite = new SqlServerCommandTask();
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


            SqlServerCommandTaskConfig TaskReadConfig = new SqlServerCommandTaskConfig();
            TaskReadConfig.ID = 3;
            TaskReadConfig.Name = "DB task (read)";
            TaskReadConfig.Server = "(local)";
            TaskReadConfig.Database = "TestDB";
            TaskReadConfig.Username = "Test";
            TaskReadConfig.Password = "12345";
            TaskReadConfig.ConnectionStringOptions = "";
            TaskReadConfig.Query = "SELECT ID, [Value] FROM TestTable ORDER BY ID";
            TaskReadConfig.ReturnsRecordset = true;
            TaskReadConfig.PluginIterationMode = IterationMode.IterateExactNumber;
            TaskReadConfig.IterationsCount = 1;

            SqlServerCommandTask TaskRead = new SqlServerCommandTask();
            TaskRead.Config = TaskReadConfig;
            TaskRead.ParentFolder = FakeFolder;

            // Act && Assert
            TaskClean.Init();
            TaskWrite.Init();
            TaskRead.Init();

            TaskClean.Run(DDataChain, DDataSet, Logger);
            TaskWrite.Run(DDataChain, DDataSet, Logger);
            ExecResult ER = TaskRead.Run(DDataChain, DDataSet, Logger).execResults[0];

            DataTable DtRead = (DataTable)ER.Data["DefaultRecordset"];

            Assert.IsTrue(Dt.Rows.Count == (DtRead.Rows.Count));
            Assert.IsTrue(Dt.Columns.Count == DtRead.Columns.Count);
            
            for (int r = 0; r < DtRead.Rows.Count; r++)
            {
                for (int c = 0; c < DtRead.Columns.Count; c++)
                {
                    Assert.IsTrue(DtRead.Rows[r][c].ToString() == Dt.Rows[r][c].ToString());
                }
            }
        }
    }
}
