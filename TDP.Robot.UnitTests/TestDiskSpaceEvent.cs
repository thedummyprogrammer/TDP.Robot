using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TDP.Robot.Core;
using TDP.Robot.Plugins.Core.DiskSpaceEvent;

namespace TDP.Robot.UnitTests
{
    [TestClass]
    public class TestDiskSpaceEvent
    {
        [TestMethod]
        public void TestThresholdToBytesMegaBytes()
        { 
            // 549755813888: 512GB space
            // 99999999 is the max value the user can insert in the configuration window
            DiskSpaceEvent EventObj = new DiskSpaceEvent();
            long Result = (long)Utils.CallPrivateMethod(EventObj, "ThresholdToBytes", new object[] { (long)549755813888, (int)99999999, DiskThresholdUnitMeasure.Megabytes });

            Assert.AreEqual(Result, 99999999L * 1024L * 1024L);
        }

        [TestMethod]
        public void TestThresholdToBytesGigaBytes()
        {
            // 99999999 is the max value the user can insert in the configuration window
            DiskSpaceEvent EventObj = new DiskSpaceEvent();
            long Result = (long)Utils.CallPrivateMethod(EventObj, "ThresholdToBytes", new object[] { (long)549755813888, (int)99999999, DiskThresholdUnitMeasure.Gigabytes });

            Assert.AreEqual(Result, 99999999L * 1024L * 1024L * 1024L);
        }

        [TestMethod]
        public void TestThresholdToBytesTeraBytes()
        {
            // 999999 is the max value the user can insert in the configuration window
            DiskSpaceEvent EventObj = new DiskSpaceEvent();
            long Result = (long)Utils.CallPrivateMethod(EventObj, "ThresholdToBytes", new object[] { (long)549755813888, (int)999999, DiskThresholdUnitMeasure.Terabytes });

            Assert.AreEqual(Result, 999999L * 1024L * 1024L * 1024L * 1024L);
        }


        [TestMethod]
        public void TestSpaceLessThan()
        {
            // Arrange
            int CheckIntervalEverySeconds = 3;
            int ToleranceSec = 1;

            Core.Config.BasePath = AppDomain.CurrentDomain.BaseDirectory;
            Core.Config.LogPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Log\");

            Folder FakeFolder = new Folder();
            FakeFolder.ID = 0;

            DiskSpaceEventConfig Config = new DiskSpaceEventConfig();
            Config.ID = 1;
            Config.Name = "Disk space event 1";
            Config.CheckIntervalSeconds = CheckIntervalEverySeconds;

            DriveInfo DriveC = DriveInfo.GetDrives().Where(D => D.Name == @"C:\").FirstOrDefault();
            int DiskFreeSpaceToCheckGB = (int)(((double)DriveC.AvailableFreeSpace) / 1024 / 1024 / 1024);
            DiskFreeSpaceToCheckGB *= 2;

            DiskThreshold DT = new DiskThreshold(@"C:\", CheckOperator.LessThan, DiskFreeSpaceToCheckGB, DiskThresholdUnitMeasure.Gigabytes);
            Config.DiskThresholds.Add(DT);

            DiskSpaceEvent EventObj = new DiskSpaceEvent();
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

            MRE.WaitOne(new TimeSpan(0, 0, CheckIntervalEverySeconds + ToleranceSec));

            // Assert
            lock (ObjSync)
            {
                Assert.IsTrue(EventTriggered);
            }
        }

        [TestMethod]
        public void TestSpaceGreaterThan()
        {
            // Arrange
            int CheckIntervalEverySeconds = 3;
            int ToleranceSec = 1;

            Core.Config.BasePath = AppDomain.CurrentDomain.BaseDirectory;
            Core.Config.LogPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Log\");

            Folder FakeFolder = new Folder();
            FakeFolder.ID = 0;

            DiskSpaceEventConfig Config = new DiskSpaceEventConfig();
            Config.ID = 1;
            Config.Name = "Disk space event 1";
            Config.CheckIntervalSeconds = CheckIntervalEverySeconds;

            DriveInfo DriveC = DriveInfo.GetDrives().Where(D => D.Name == @"C:\").FirstOrDefault();
            int DiskFreeSpaceToCheckGB = (int)(((double)DriveC.AvailableFreeSpace) / 1024 / 1024 / 1024);
            DiskFreeSpaceToCheckGB /= (int)2d;

            DiskThreshold DT = new DiskThreshold(@"C:\", CheckOperator.GreaterThan, DiskFreeSpaceToCheckGB, DiskThresholdUnitMeasure.Gigabytes);
            Config.DiskThresholds.Add(DT);

            DiskSpaceEvent EventObj = new DiskSpaceEvent();
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

            MRE.WaitOne(new TimeSpan(0, 0, CheckIntervalEverySeconds + ToleranceSec));

            // Assert
            lock (ObjSync)
            {
                Assert.IsTrue(EventTriggered);
            }
        }
    }
}
