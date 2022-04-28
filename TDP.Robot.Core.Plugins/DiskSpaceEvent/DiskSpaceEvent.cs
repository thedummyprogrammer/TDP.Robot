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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using TDP.Robot.Core;
using TDP.Robot.Core.DynamicData;
using TDP.Robot.Core.Logging;

namespace TDP.Robot.Plugins.Core.DiskSpaceEvent
{
    [Serializable]
    public class DiskSpaceEvent : IEvent
    {

        public IPluginInstanceConfig Config { get; set; }

        public List<PluginInstanceConnection> Connections { get; } = new List<PluginInstanceConnection>();

        public IFolder ParentFolder { get; set; }
        public int ID { get; set; }

        [field: NonSerialized]
        public event EventTriggeredDelegate EventTriggered;

        [field: NonSerialized]
        private System.Timers.Timer _RecurringTimer;

        protected virtual void OnEventTriggered(EventTriggeredEventArgs e)
        {
            EventTriggeredDelegate handler = EventTriggered;
            if (handler != null)
            {
                foreach (EventTriggeredDelegate singleCast in handler.GetInvocationList())
                {
                    ISynchronizeInvoke syncInvoke = singleCast.Target as ISynchronizeInvoke;
                    if ((syncInvoke != null) && (syncInvoke.InvokeRequired))
                        syncInvoke.Invoke(singleCast, new object[] { this, e });
                    else
                        singleCast(this, e);
                }
            }
        }

        public void Init()
        {
            _RecurringTimer = new System.Timers.Timer();
            _RecurringTimer.Enabled = false;
            _RecurringTimer.AutoReset = true;
            _RecurringTimer.Elapsed += _RecurringTimer_Elapsed;
        }

        public void Destroy()
        {
            _RecurringTimer.Dispose();
        }

        public InstanceExecResult Run(DynamicDataChain dataChain, DynamicDataSet lastDynamicDataSet, IPluginInstanceLogger instanceLogger)
        {
            DiskSpaceEventConfig TConfig = (DiskSpaceEventConfig)Config;

            int CheckIntervalSeconds = TConfig.CheckIntervalSeconds;
            if (CheckIntervalSeconds <= 0)
                CheckIntervalSeconds = 1;

            _RecurringTimer.Interval = new TimeSpan(0, 0, CheckIntervalSeconds).TotalMilliseconds;

            _RecurringTimer.Enabled = true;

            List<ExecResult> execResults = new List<ExecResult>();
            execResults.Add(new ExecResult(true, null));
            return new InstanceExecResult(execResults);
        }

        private long ThresholdToBytes(long totalDriveSpace, int value, DiskThresholdUnitMeasure unit)
        {
            long Result = 0;
            long TempValue = value;
            
            switch (unit)
            {
                case DiskThresholdUnitMeasure.Megabytes:
                    Result = TempValue * 1024 * 1024;
                    break;

                case DiskThresholdUnitMeasure.Gigabytes:
                    Result = TempValue * 1024 * 1024 * 1024;
                    break;

                case DiskThresholdUnitMeasure.Terabytes:
                    Result = TempValue * 1024 * 1024 * 1024 * 1024;
                    break;

                case DiskThresholdUnitMeasure.Percentage:
                    Result = totalDriveSpace * TempValue / 100;
                    break;
            }
                       
            return Result;
        }

        private void _RecurringTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            IPluginInstanceLogger Logger = PluginInstanceLogger.GetLogger(this);

            try
            {
                bool EventTriggered = false;

                if (!Config.DoNotLog)
                    Logger.Info(this, "Checking disks space...");

                DiskSpaceEventConfig TConfig = (DiskSpaceEventConfig)Config;

                DriveInfo[] AllDrives = DriveInfo.GetDrives();
                foreach (DriveInfo Drive in AllDrives)
                {
                    DiskThreshold DiskTh = TConfig.DiskThresholds.Where(T => T.Disk == Drive.Name && Drive.DriveType == DriveType.Fixed).FirstOrDefault();

                    if (DiskTh != null)
                    {

                        if ((DiskTh.CheckOperator == CheckOperator.LessThan && Drive.AvailableFreeSpace < ThresholdToBytes(Drive.TotalSize, DiskTh.ThresholdValue, DiskTh.UnitMeasure))
                            || (DiskTh.CheckOperator == CheckOperator.GreaterThan && Drive.AvailableFreeSpace > ThresholdToBytes(Drive.TotalSize, DiskTh.ThresholdValue, DiskTh.UnitMeasure)))
                        {
                            EventTriggered = true;

                            DateTime Now = DateTime.Now;
                            DynamicDataSet DDataSet = CommonDynamicData.BuildStandardDynamicDataSet(this, true, 0, Now, Now, 1);
                            DDataSet.Add("DiskName", Drive.Name);
                            DDataSet.Add("DiskSpaceBytes", Drive.AvailableFreeSpace);

                            if (!Config.DoNotLog)
                            {
                                Logger.Info(this, $"Disk: {Drive.Name} Available free space (bytes) {Drive.AvailableFreeSpace}");
                                Logger.EventTriggering(this);
                            }
                                
                            OnEventTriggered(new EventTriggeredEventArgs(DDataSet, Logger));
                        }
                    }
                }

                if (!EventTriggered && !Config.DoNotLog)
                    Logger.Info(this, "No disk with space below the threshold");
            }
            catch (Exception ex)
            {
                if (!Config.DoNotLog)
                    Logger.EventError(this, ex);
            }
        }
    }
}
