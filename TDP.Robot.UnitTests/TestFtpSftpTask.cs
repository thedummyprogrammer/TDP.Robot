using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDP.Robot.Core;
using TDP.Robot.Core.DynamicData;
using TDP.Robot.Core.Logging;
using TDP.Robot.Plugins.Core.FtpSftpTask;

namespace TDP.Robot.UnitTests
{
    [TestClass]
    public class TestFtpSftpTask
    {
        private void WriteTestFile(string filePathName, string content)
        {
            using (FileStream FS = new FileStream(filePathName, FileMode.Create))
            {
                using (StreamWriter SW = new StreamWriter(FS))
                {
                    SW.WriteLine(content);
                }
            }
        }

        [TestMethod]
        public void TestSftp()
        {
            // Arrange
            string BasePath = AppDomain.CurrentDomain.BaseDirectory;
            Core.Config.BasePath = BasePath;
            Core.Config.LogPath = Path.Combine(BasePath, @"Log\");
            string TestFileFolder = Path.Combine(BasePath, @"TestSftp\");

            if (Directory.Exists(TestFileFolder))
                Directory.Delete(TestFileFolder, true);
            Directory.CreateDirectory(TestFileFolder);
            Directory.CreateDirectory(TestFileFolder + @"\SubFolder");

            Folder FakeFolder = new Folder();
            FakeFolder.ID = 0;

            WriteTestFile(Path.Combine(TestFileFolder, "Sftp1.txt"), "Test Sftp 1");
            WriteTestFile(Path.Combine(TestFileFolder, "Sftp2.txt"), "Test Sftp 2");
            WriteTestFile(Path.Combine(TestFileFolder, "Sftp3.txt"), "Test Sftp 3");
            WriteTestFile(Path.Combine(TestFileFolder + @"\SubFolder", "Sftp4.txt"), "Test Sftp 4");

            FtpSftpTaskConfig TaskUploadConfig = new FtpSftpTaskConfig();
            TaskUploadConfig.ID = 1;
            TaskUploadConfig.Name = "Sftp Upload";
            TaskUploadConfig.Command = CommandEnum.Copy;
            TaskUploadConfig.Protocol = ProtocolEnum.SFTP;
            TaskUploadConfig.Host = "localhost";
            TaskUploadConfig.Username = "test";
            TaskUploadConfig.Password = "12345";
            TaskUploadConfig.Port = "22";

            FtpSftpTask TaskUpload = new FtpSftpTask();
            TaskUpload.Config = TaskUploadConfig;
            TaskUpload.ParentFolder = FakeFolder;

            FtpSftpCopyItem CopyItem = new FtpSftpCopyItem(true, TestFileFolder, @"\RemoteFolder", true, true);
            TaskUploadConfig.CopyItems.Add(CopyItem);



            FtpSftpTaskConfig TaskDeleteConfig = new FtpSftpTaskConfig();
            TaskDeleteConfig.ID = 2;
            TaskDeleteConfig.Name = "Sftp Delete";
            TaskDeleteConfig.Command = CommandEnum.Delete;
            TaskDeleteConfig.Protocol = ProtocolEnum.SFTP;
            TaskDeleteConfig.Host = "localhost";
            TaskDeleteConfig.Username = "test";
            TaskDeleteConfig.Password = "12345";
            TaskDeleteConfig.Port = "22";

            FtpSftpTask TaskDelete = new FtpSftpTask();
            TaskDelete.Config = TaskDeleteConfig;
            TaskDelete.ParentFolder = FakeFolder;

            FtpSftpDeleteItem DeleteItem = new FtpSftpDeleteItem(@"\RemoteFolder");
            TaskDeleteConfig.DeleteItems.Add(DeleteItem);


            DynamicDataSet DDataSet = new DynamicDataSet();

            DynamicDataChain DDataChain = new DynamicDataChain();
            DDataChain.Add(2, DDataSet);

            IPluginInstanceLogger Logger = PluginInstanceLogger.GetLogger(TaskUpload);

            // Act && Assert
            
            ExecResult ERTaskDelete = TaskDelete.Run(DDataChain, DDataSet, Logger).execResults[0];
            Assert.IsTrue(ERTaskDelete.Result);

            ExecResult ERTaskUpload = TaskUpload.Run(DDataChain, DDataSet, Logger).execResults[0];
            Assert.IsTrue(ERTaskUpload.Result);
        }

        [TestMethod]
        public void TestFtp()
        {
            // Arrange
            string BasePath = AppDomain.CurrentDomain.BaseDirectory;
            Core.Config.BasePath = BasePath;
            Core.Config.LogPath = Path.Combine(BasePath, @"Log\");
            string TestFileFolder = Path.Combine(BasePath, @"TestFtp\");

            if (Directory.Exists(TestFileFolder))
                Directory.Delete(TestFileFolder, true);
            Directory.CreateDirectory(TestFileFolder);
            Directory.CreateDirectory(TestFileFolder + @"\SubFolder");

            Folder FakeFolder = new Folder();
            FakeFolder.ID = 0;

            WriteTestFile(Path.Combine(TestFileFolder, "Sftp1.txt"), "Test Sftp 1");
            WriteTestFile(Path.Combine(TestFileFolder, "Sftp2.txt"), "Test Sftp 2");
            WriteTestFile(Path.Combine(TestFileFolder, "Sftp3.txt"), "Test Sftp 3");
            WriteTestFile(Path.Combine(TestFileFolder + @"\SubFolder", "Sftp4.txt"), "Test Sftp 4");

            FtpSftpTaskConfig TaskUploadConfig = new FtpSftpTaskConfig();
            TaskUploadConfig.ID = 1;
            TaskUploadConfig.Name = "Ftp Upload";
            TaskUploadConfig.Command = CommandEnum.Copy;
            TaskUploadConfig.Protocol = ProtocolEnum.FTP;
            TaskUploadConfig.Host = "localhost";
            TaskUploadConfig.Username = "test";
            TaskUploadConfig.Password = "12345";
            TaskUploadConfig.Port = "21";

            FtpSftpTask TaskUpload = new FtpSftpTask();
            TaskUpload.Config = TaskUploadConfig;
            TaskUpload.ParentFolder = FakeFolder;

            FtpSftpCopyItem CopyItem = new FtpSftpCopyItem(true, TestFileFolder, @"\RemoteFolder", true, true);
            TaskUploadConfig.CopyItems.Add(CopyItem);



            FtpSftpTaskConfig TaskDeleteConfig = new FtpSftpTaskConfig();
            TaskDeleteConfig.ID = 2;
            TaskDeleteConfig.Name = "Ftp Delete";
            TaskDeleteConfig.Command = CommandEnum.Delete;
            TaskDeleteConfig.Protocol = ProtocolEnum.FTP;
            TaskDeleteConfig.Host = "localhost";
            TaskDeleteConfig.Username = "test";
            TaskDeleteConfig.Password = "12345";
            TaskDeleteConfig.Port = "21";

            FtpSftpTask TaskDelete = new FtpSftpTask();
            TaskDelete.Config = TaskDeleteConfig;
            TaskDelete.ParentFolder = FakeFolder;

            FtpSftpDeleteItem DeleteItem = new FtpSftpDeleteItem(@"\RemoteFolder");
            TaskDeleteConfig.DeleteItems.Add(DeleteItem);


            DynamicDataSet DDataSet = new DynamicDataSet();

            DynamicDataChain DDataChain = new DynamicDataChain();
            DDataChain.Add(2, DDataSet);

            IPluginInstanceLogger Logger = PluginInstanceLogger.GetLogger(TaskUpload);

            /*
            // Act && Assert
            ExecResult ERTaskDelete = TaskDelete.Run(DDataChain, DDataSet, Logger);
            Assert.IsTrue(ERTaskDelete.Result);

            ExecResult ERTaskUpload = TaskUpload.Run(DDataChain, DDataSet, Logger);
            Assert.IsTrue(ERTaskUpload.Result);
            */
        }
    }
}
