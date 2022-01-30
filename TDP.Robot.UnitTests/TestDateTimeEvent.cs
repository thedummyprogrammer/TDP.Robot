using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Threading;
using TDP.Robot.Core;
using TDP.Robot.Plugins.Core.DateTimeEvent;

namespace TDP.Robot.UnitTests
{
    [TestClass]
    public class TestDateTimeEvent
    {
        [TestMethod]
        public void TestAtTime()
        {
            // Arrange
            int WithinMinutes = 1;
            int ToleranceSec = 1;

            Core.Config.BasePath = AppDomain.CurrentDomain.BaseDirectory;
            Core.Config.LogPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Log\");

            Folder FakeFolder = new Folder();
            FakeFolder.ID = 0;

            DateTimeEventConfig Config = new DateTimeEventConfig();
            Config.ID = 1;
            Config.Name = "DateTimeEvent 1";
            Config.OneTime = true;
            Config.AtDate = DateTime.Now.AddMinutes(WithinMinutes);

            DateTimeEvent EventObj = new DateTimeEvent();
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

            MRE.WaitOne(new TimeSpan(0, WithinMinutes, ToleranceSec)); 

            // Assert
            lock (ObjSync)
            {
                Assert.IsTrue(EventTriggered && (Math.Abs(DateTime.Now.Subtract(Config.AtDate).TotalSeconds) <= ToleranceSec));
            }
        }

        [TestMethod]
        public void TestEverySecond()
        {
            // Arrange
            int EveryNumSeconds = 5;
            int RepeatNumber = 5;
            int ToleranceSec = 1;

            Core.Config.BasePath = AppDomain.CurrentDomain.BaseDirectory;
            Core.Config.LogPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Log\");

            Folder FakeFolder = new Folder();
            FakeFolder.ID = 0;

            DateTimeEventConfig Config = new DateTimeEventConfig();
            Config.ID = 1;
            Config.Name = "DateTimeEvent 1";
            Config.EverySeconds = true;
            Config.AtDate = DateTime.Now.AddSeconds(-10); // Start with AtTime in the past
            Config.EveryNumSeconds = EveryNumSeconds;

            DateTimeEvent EventObj = new DateTimeEvent();
            FakeFolder.Add(EventObj);
            EventObj.ParentFolder = FakeFolder;

            object ObjSync = new object();
            ManualResetEvent MRE = new ManualResetEvent(false);
            bool EventTriggered = false;
            int RepeatCount = 0;
            DateTime ExpectedLastTrigger = DateTime.Now.AddSeconds(EveryNumSeconds * RepeatNumber);
            EventObj.EventTriggered += (sender, e) =>
            {
                RepeatCount++;

                if (RepeatCount == RepeatNumber)
                {
                    lock (ObjSync)
                    {
                        EventTriggered = true;
                    }

                    MRE.Set();
                    return;
                }
            };
            EventObj.Config = Config;

            // Act
            EventObj.Init();
            EventObj.Run(null, null, null);

            MRE.WaitOne(new TimeSpan(0, 0, (EveryNumSeconds * RepeatNumber) + ToleranceSec));

            // Assert
            lock (ObjSync)
            {
                Assert.IsTrue(EventTriggered && (Math.Abs(DateTime.Now.Subtract(ExpectedLastTrigger).TotalSeconds) <= ToleranceSec));
            }
        }

        [TestMethod]
        public void TestEveryMinute()
        {
            // Arrange
            int EveryNumMinutes = 1;
            int RepeatNumber = 5;
            int ToleranceSec = 1;

            Core.Config.BasePath = AppDomain.CurrentDomain.BaseDirectory;
            Core.Config.LogPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Log\");

            Folder FakeFolder = new Folder();
            FakeFolder.ID = 0;

            DateTimeEventConfig Config = new DateTimeEventConfig();
            Config.ID = 1;
            Config.Name = "DateTimeEvent 1";
            Config.EveryDaysHoursSecs = true;
            Config.AtDate = DateTime.Now.AddSeconds(-10); // Start with AtTime in the past
            Config.EveryNumDays = 0;
            Config.EveryNumHours = 0;
            Config.EveryNumMinutes = EveryNumMinutes;

            DateTimeEvent EventObj = new DateTimeEvent();
            FakeFolder.Add(EventObj);
            EventObj.ParentFolder = FakeFolder;

            object ObjSync = new object();
            ManualResetEvent MRE = new ManualResetEvent(false);
            bool EventTriggeredInTime = false;
            int RepeatCount = 0;
            DateTime ExpectedLastTrigger = DateTime.Now.AddMinutes(EveryNumMinutes * RepeatNumber);
            EventObj.EventTriggered += (sender, e) =>
            {
                RepeatCount++;

                if (RepeatCount == RepeatNumber)
                {
                    lock (ObjSync)
                    {
                        EventTriggeredInTime = true;
                    }

                    MRE.Set();
                    return;
                }
            };
            EventObj.Config = Config;

            // Act
            EventObj.Init();
            EventObj.Run(null, null, null);

            MRE.WaitOne(new TimeSpan(0, 0, (EveryNumMinutes * 60 * RepeatNumber) + ToleranceSec));

            // Assert
            lock (ObjSync)
            {
                Assert.IsTrue(EventTriggeredInTime && (Math.Abs(DateTime.Now.Subtract(ExpectedLastTrigger).TotalSeconds) <= ToleranceSec));
            }
        }

        [TestMethod]
        public void TestEverySecondOnDaysTrue()
        {
            // Arrange
            int EveryNumSeconds = 5;
            int RepeatNumber = 1;
            int ToleranceSec = 1;

            Core.Config.BasePath = AppDomain.CurrentDomain.BaseDirectory;
            Core.Config.LogPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Log\");

            Folder FakeFolder = new Folder();
            FakeFolder.ID = 0;

            DateTimeEventConfig Config = new DateTimeEventConfig();
            Config.ID = 1;
            Config.Name = "DateTimeEvent 1";
            Config.EverySeconds = true;
            Config.AtDate = DateTime.Now.AddSeconds(-10); // Start with AtTime in the past
            Config.EveryNumSeconds = EveryNumSeconds;
            Config.OnDays.Clear();
            Config.OnDays.Add(DateTime.Now.DayOfWeek);

            DateTimeEvent EventObj = new DateTimeEvent();
            FakeFolder.Add(EventObj);
            EventObj.ParentFolder = FakeFolder;

            object ObjSync = new object();
            ManualResetEvent MRE = new ManualResetEvent(false);
            bool EventTriggered = false;
            int RepeatCount = 0;
            DateTime ExpectedLastTrigger = DateTime.Now.AddSeconds(EveryNumSeconds * RepeatNumber);
            EventObj.EventTriggered += (sender, e) =>
            {
                RepeatCount++;

                if (RepeatCount == RepeatNumber)
                {
                    lock (ObjSync)
                    {
                        EventTriggered = true;
                    }

                    MRE.Set();
                    return;
                }
            };
            EventObj.Config = Config;

            // Act
            EventObj.Init();
            EventObj.Run(null, null, null);

            MRE.WaitOne(new TimeSpan(0, 0, (EveryNumSeconds * RepeatNumber) + ToleranceSec));

            // Assert
            lock (ObjSync)
            {
                Assert.IsTrue(EventTriggered && (Math.Abs(DateTime.Now.Subtract(ExpectedLastTrigger).TotalSeconds) <= ToleranceSec));
            }
        }

        [TestMethod]
        public void TestEverySecondOnAllDays()
        {
            // Arrange
            int EveryNumSeconds = 5;
            int RepeatNumber = 1;
            int ToleranceSec = 1;

            Core.Config.BasePath = AppDomain.CurrentDomain.BaseDirectory;
            Core.Config.LogPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Log\");

            Folder FakeFolder = new Folder();
            FakeFolder.ID = 0;

            DateTimeEventConfig Config = new DateTimeEventConfig();
            Config.ID = 1;
            Config.Name = "DateTimeEvent 1";
            Config.EverySeconds = true;
            Config.AtDate = DateTime.Now.AddSeconds(-10); // Start with AtTime in the past
            Config.EveryNumSeconds = EveryNumSeconds;
            Config.OnDays.Clear();
            Config.OnAllDays = true;

            DateTimeEvent EventObj = new DateTimeEvent();
            FakeFolder.Add(EventObj);
            EventObj.ParentFolder = FakeFolder;

            object ObjSync = new object();
            ManualResetEvent MRE = new ManualResetEvent(false);
            bool EventTriggered = false;
            int RepeatCount = 0;
            DateTime ExpectedLastTrigger = DateTime.Now.AddSeconds(EveryNumSeconds * RepeatNumber);
            EventObj.EventTriggered += (sender, e) =>
            {
                RepeatCount++;

                if (RepeatCount == RepeatNumber)
                {
                    lock (ObjSync)
                    {
                        EventTriggered = true;
                    }

                    MRE.Set();
                    return;
                }
            };
            EventObj.Config = Config;

            // Act
            EventObj.Init();
            EventObj.Run(null, null, null);

            MRE.WaitOne(new TimeSpan(0, 0, (EveryNumSeconds * RepeatNumber) + ToleranceSec));

            // Assert
            lock (ObjSync)
            {
                Assert.IsTrue(EventTriggered && (Math.Abs(DateTime.Now.Subtract(ExpectedLastTrigger).TotalSeconds) <= ToleranceSec));
            }
        }

        [TestMethod]
        public void TestEverySecondOnDaysFalse()
        {
            // Arrange
            int EveryNumSeconds = 5;
            int RepeatNumber = 1;
            int ToleranceSec = 1;

            Core.Config.BasePath = AppDomain.CurrentDomain.BaseDirectory;
            Core.Config.LogPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Log\");

            Folder FakeFolder = new Folder();
            FakeFolder.ID = 0;

            DateTimeEventConfig Config = new DateTimeEventConfig();
            Config.ID = 1;
            Config.Name = "DateTimeEvent 1";
            Config.EverySeconds = true;
            Config.AtDate = DateTime.Now.AddSeconds(-10); // Start with AtTime in the past
            Config.EveryNumSeconds = EveryNumSeconds;
            Config.OnDays.Clear();
            Config.OnAllDays = false;
            foreach (DayOfWeek D in Enum.GetValues(typeof(DayOfWeek)))
            {
                if (D != DateTime.Now.DayOfWeek)
                {
                    Config.OnDays.Add(D);
                    break;
                }
            }

            DateTimeEvent EventObj = new DateTimeEvent();
            FakeFolder.Add(EventObj);
            EventObj.ParentFolder = FakeFolder;

            object ObjSync = new object();
            ManualResetEvent MRE = new ManualResetEvent(false);
            bool EventTriggered = false;
            int RepeatCount = 0;
            DateTime ExpectedLastTrigger = DateTime.Now.AddSeconds(EveryNumSeconds * RepeatNumber);
            EventObj.EventTriggered += (sender, e) =>
            {
                RepeatCount++;

                if (RepeatCount == RepeatNumber)
                {
                    lock (ObjSync)
                    {
                        EventTriggered = true;
                    }

                    MRE.Set();
                    return;
                }
            };
            EventObj.Config = Config;

            // Act
            EventObj.Init();
            EventObj.Run(null, null, null);

            MRE.WaitOne(new TimeSpan(0, 0, (EveryNumSeconds * RepeatNumber) + ToleranceSec));

            // Assert
            lock (ObjSync)
            {
                Assert.IsFalse(EventTriggered);
            }
        }
    }
}
