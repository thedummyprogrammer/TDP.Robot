using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TDP.Robot.Core;
using TDP.Robot.Plugins.Core.FileSystemEvent;

namespace TDP.Robot.UnitTests
{
    [TestClass]
    public class TestFileSystemEvent
    {
        [TestMethod]
        public void TestAddFile()
        {
            // Arrange
            int ToleranceSec = 30;

            string AppBasePath = AppDomain.CurrentDomain.BaseDirectory;
            Core.Config.BasePath = AppBasePath;
            Core.Config.LogPath = Path.Combine(AppBasePath, @"Log\");
            string TestFileFolder = Path.Combine(AppBasePath, @"TestFileEvent\");

            if (Directory.Exists(TestFileFolder))
                Directory.Delete(TestFileFolder, true);
            Directory.CreateDirectory(TestFileFolder);

            Folder FakeFolder = new Folder();
            FakeFolder.ID = 0;

            FileSystemEventConfig Config = new FileSystemEventConfig();
            Config.ID = 1;
            Config.Name = "FileSystemEvent 1";
            FolderToMonitor FolderMon = new FolderToMonitor(TestFileFolder, false, MonitorActionType.NewFiles);
            Config.FoldersToMonitor.Add(FolderMon);

            FileSystemEvent EventObj = new FileSystemEvent();
            FakeFolder.Add(EventObj);
            EventObj.ParentFolder = FakeFolder;

            object ObjSync = new object();
            ManualResetEvent MRE = new ManualResetEvent(false);
            bool EventTriggered = false;
            EventObj.EventTriggered += (sender, e) =>
            {
                lock (ObjSync)
                {
                    EventTriggered = true;
                }

                MRE.Set();
            };
            EventObj.Config = Config;

            // Act
            EventObj.Init();
            EventObj.Run(null, null, null);


            string FilePath = Path.Combine(TestFileFolder, "TestAdd.txt");
            using (FileStream FS = new FileStream(FilePath, FileMode.Create))
            {
                using (StreamWriter SW = new StreamWriter(FS))
                {
                    SW.WriteLine("This is a test!");
                }
            }

            MRE.WaitOne(new TimeSpan(0, 0, ToleranceSec));
            
            // Assert
            lock (ObjSync)
            {
                Assert.IsTrue(EventTriggered);
            }
        }

        [TestMethod]
        public void TestModifyFile()
        {
            // Arrange
            int ToleranceSec = 30;

            string AppBasePath = AppDomain.CurrentDomain.BaseDirectory;
            Core.Config.BasePath = AppBasePath;
            Core.Config.LogPath = Path.Combine(AppBasePath, @"Log\");
            string TestFileFolder = Path.Combine(AppBasePath, @"TestFileEvent\");

            if (Directory.Exists(TestFileFolder))
                Directory.Delete(TestFileFolder, true);
            Directory.CreateDirectory(TestFileFolder);

            string FilePath = Path.Combine(TestFileFolder, "TestModify.txt");
            using (FileStream FS = new FileStream(FilePath, FileMode.Create))
            {
                using (StreamWriter SW = new StreamWriter(FS))
                {
                    SW.WriteLine("This is a test!");
                }
            }

            Folder FakeFolder = new Folder();
            FakeFolder.ID = 0;

            FileSystemEventConfig Config = new FileSystemEventConfig();
            Config.ID = 1;
            Config.Name = "FileSystemEvent 1";
            FolderToMonitor FolderMon = new FolderToMonitor(TestFileFolder, false, MonitorActionType.ModifiedFiles);
            Config.FoldersToMonitor.Add(FolderMon);

            FileSystemEvent EventObj = new FileSystemEvent();
            FakeFolder.Add(EventObj);
            EventObj.ParentFolder = FakeFolder;

            object ObjSync = new object();
            ManualResetEvent MRE = new ManualResetEvent(false);
            bool EventTriggered = false;
            EventObj.EventTriggered += (sender, e) =>
            {
                lock (ObjSync)
                {
                    EventTriggered = true;
                }

                MRE.Set();
            };
            EventObj.Config = Config;

            // Act
            EventObj.Init();
            EventObj.Run(null, null, null);

            using (FileStream FS = new FileStream(FilePath, FileMode.Append))
            {
                using (StreamWriter SW = new StreamWriter(FS))
                {
                    SW.WriteLine("This is a test!");
                }
            }

            MRE.WaitOne(new TimeSpan(0, 0, ToleranceSec));

            // Assert
            lock (ObjSync)
            {
                Assert.IsTrue(EventTriggered);
            }
        }

        [TestMethod]
        public void TestDeleteFile()
        {
            // Arrange
            int ToleranceSec = 30;

            string AppBasePath = AppDomain.CurrentDomain.BaseDirectory;
            Core.Config.BasePath = AppBasePath;
            Core.Config.LogPath = Path.Combine(AppBasePath, @"Log\");
            string TestFileFolder = Path.Combine(AppBasePath, @"TestFileEvent\");

            if (Directory.Exists(TestFileFolder))
                Directory.Delete(TestFileFolder, true);
            Directory.CreateDirectory(TestFileFolder);

            string FilePath = Path.Combine(TestFileFolder, "TestDelete.txt");
            using (FileStream FS = new FileStream(FilePath, FileMode.Create))
            {
                using (StreamWriter SW = new StreamWriter(FS))
                {
                    SW.WriteLine("This is a test!");
                }
            }

            Folder FakeFolder = new Folder();
            FakeFolder.ID = 0;

            FileSystemEventConfig Config = new FileSystemEventConfig();
            Config.ID = 1;
            Config.Name = "FileSystemEvent 1";
            FolderToMonitor FolderMon = new FolderToMonitor(TestFileFolder, false, MonitorActionType.DeletedFiles);
            Config.FoldersToMonitor.Add(FolderMon);

            FileSystemEvent EventObj = new FileSystemEvent();
            FakeFolder.Add(EventObj);
            EventObj.ParentFolder = FakeFolder;

            object ObjSync = new object();
            ManualResetEvent MRE = new ManualResetEvent(false);
            bool EventTriggered = false;
            EventObj.EventTriggered += (sender, e) =>
            {
                lock (ObjSync)
                {
                    EventTriggered = true;
                }

                MRE.Set();
            };
            EventObj.Config = Config;

            // Act
            EventObj.Init();
            EventObj.Run(null, null, null);

            File.Delete(FilePath);

            MRE.WaitOne(new TimeSpan(0, 0, ToleranceSec));

            // Assert
            lock (ObjSync)
            {
                Assert.IsTrue(EventTriggered);
            }
        }
    }
}
