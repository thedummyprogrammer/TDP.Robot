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
using TDP.Robot.Plugins.Core.ReadTextFileTask;

namespace TDP.Robot.UnitTests
{
    [TestClass]
    public class TestReadTextFileTask
    {
        [TestMethod]
        public void TestReadTextFile_AllRows()
        {
            // Arrange
            string BasePath = AppDomain.CurrentDomain.BaseDirectory;
            Core.Config.BasePath = BasePath;
            Core.Config.LogPath = Path.Combine(BasePath, @"Log\");
            string TestFilePath = Path.Combine(BasePath, @"TestFile.txt");

            Folder FakeFolder = new Folder();
            FakeFolder.ID = 0;

            // Write test file
            string[] TestFileRows = new string[] {
                @"""A"",B,C,D",
                @"""E"",F,G,H",
                @"""I"",J,K,L",
                @"""M"",N,O,P",
            };

            File.Delete(TestFilePath);

            using (StreamWriter SW = new StreamWriter(TestFilePath))
            {
                foreach (string R in TestFileRows)
                {
                    SW.WriteLine(R);
                }
            }


            {
                ReadTextFileTaskConfig TaskConfig = new ReadTextFileTaskConfig();
                TaskConfig.ID = 1;
                TaskConfig.Name = "Read text file task";
                TaskConfig.FilePath = TestFilePath;
                TaskConfig.ReadAllTheRowsOption = true;

                ReadTextFileTask TaskRead = new ReadTextFileTask();
                TaskRead.Config = TaskConfig;
                TaskRead.ParentFolder = FakeFolder;

                IPluginInstanceLogger Logger = PluginInstanceLogger.GetLogger(TaskRead);
                DynamicDataSet DDataSet = new DynamicDataSet();
                DynamicDataChain DDataChain = new DynamicDataChain();
                DDataChain.Add(2, DDataSet);

                TaskRead.Init();
                ExecResult ER = TaskRead.Run(DDataChain, DDataSet, Logger);

                DataTable Dt = (DataTable)ER.Data["DefaultRecordset"];

                Assert.IsTrue(TestFileRows.Length == Dt.Rows.Count);

                for (int i = 0; i < Dt.Rows.Count; i++)
                {
                    Assert.IsTrue(TestFileRows[i] == Dt.Rows[i]["Column1"].ToString());
                }
            }

            {
                ReadTextFileTaskConfig TaskConfig = new ReadTextFileTaskConfig();
                TaskConfig.ID = 1;
                TaskConfig.Name = "Read text file task";
                TaskConfig.FilePath = TestFilePath;
                TaskConfig.ReadLastRowOption = true;

                ReadTextFileTask TaskRead = new ReadTextFileTask();
                TaskRead.Config = TaskConfig;
                TaskRead.ParentFolder = FakeFolder;

                IPluginInstanceLogger Logger = PluginInstanceLogger.GetLogger(TaskRead);
                DynamicDataSet DDataSet = new DynamicDataSet();
                DynamicDataChain DDataChain = new DynamicDataChain();
                DDataChain.Add(2, DDataSet);

                TaskRead.Init();
                ExecResult ER = TaskRead.Run(DDataChain, DDataSet, Logger);

                DataTable Dt = (DataTable)ER.Data["DefaultRecordset"];

                Assert.IsTrue(Dt.Rows.Count == 1);
                Assert.IsTrue(TestFileRows[TestFileRows.Length - 1] == Dt.Rows[Dt.Rows.Count - 1]["Column1"].ToString());
            }

            {
                ReadTextFileTaskConfig TaskConfig = new ReadTextFileTaskConfig();
                TaskConfig.ID = 1;
                TaskConfig.Name = "Read text file task";
                TaskConfig.FilePath = TestFilePath;
                TaskConfig.ReadAllTheRowsOption = true;
                TaskConfig.SplitColumnsType = ReadTextFileSplitColumnsType.UseDelimiters;
                TaskConfig.DelimiterComma = true;
                TaskConfig.UseDoubleQuotes = true;

                ReadTextFileTask TaskRead = new ReadTextFileTask();
                TaskRead.Config = TaskConfig;
                TaskRead.ParentFolder = FakeFolder;

                IPluginInstanceLogger Logger = PluginInstanceLogger.GetLogger(TaskRead);
                DynamicDataSet DDataSet = new DynamicDataSet();
                DynamicDataChain DDataChain = new DynamicDataChain();
                DDataChain.Add(2, DDataSet);

                TaskRead.Init();
                ExecResult ER = TaskRead.Run(DDataChain, DDataSet, Logger);

                DataTable Dt = (DataTable)ER.Data["DefaultRecordset"];


                Assert.IsTrue(Dt.Rows[0]["Column1"].ToString() == "A");
                Assert.IsTrue(Dt.Rows[3]["Column4"].ToString() == "P");
            }
        }

    }
}
