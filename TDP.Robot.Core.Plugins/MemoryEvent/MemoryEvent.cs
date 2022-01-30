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

using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDP.Robot.Core;
using TDP.Robot.Core.DynamicData;
using TDP.Robot.Core.Logging;

namespace TDP.Robot.Plugins.Core.MemoryEvent
{
    [Serializable]
    public class MemoryUsageSample
    {
        public MemoryUsageSample(float sampleValue)
        {
            SampleDateTime = DateTime.Now;
            SampleValue = sampleValue;
        }

        public DateTime SampleDateTime { get; set; }

        public float SampleValue { get; set; }
    }

    [Serializable]
    public class MemoryEvent : IEvent
    {
        public IFolder ParentFolder { get; set; }
        public int ID { get; set; }
        public IPluginInstanceConfig Config { get; set; }

        public List<PluginInstanceConnection> Connections { get; } = new List<PluginInstanceConnection>();

        [field: NonSerialized]
        public event EventTriggeredDelegate EventTriggered;

        [field: NonSerialized]
        private System.Timers.Timer _RecurringTimer;

        [field: NonSerialized]
        private ComputerInfo _ComputerInfo;

        [field: NonSerialized]
        private List<MemoryUsageSample> _MemoryUsageSamples = new List<MemoryUsageSample>();

        [field: NonSerialized]
        private DateTime _DateLastTrigger;

        [field: NonSerialized]
        private DateTime _DateFirstSample = DateTime.MinValue;

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

        private void _RecurringTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            IPluginInstanceLogger Logger = PluginInstanceLogger.GetLogger(this);

            try
            {
                bool TriggerEvent = false;

                if (!Config.DoNotLog)
                    Logger.Info(this, "Checking Memory usage...");

                MemoryEventConfig TConfig = (MemoryEventConfig)Config;

                if (_ComputerInfo == null)
                    _ComputerInfo = new ComputerInfo();

                if (_DateFirstSample == DateTime.MinValue)
                    _DateFirstSample = DateTime.Now;

                float TotalMemory = _ComputerInfo.TotalPhysicalMemory;
                float UsedMemory = _ComputerInfo.TotalPhysicalMemory - _ComputerInfo.AvailablePhysicalMemory;
                float MemoryUsage = UsedMemory / TotalMemory * 100; 

                Debug.WriteLine($"Samples Count before: {_MemoryUsageSamples.Count}");
                if (TConfig.TriggerIfAvgUsageIsAboveThresholdLastXMin)
                    _MemoryUsageSamples.Add(new MemoryUsageSample(MemoryUsage));
                Debug.WriteLine($"Samples Count after: {_MemoryUsageSamples.Count}");

                if (TConfig.TriggerIfPassedXMinFromLastTrigger
                    && DateTime.Now.Subtract(_DateLastTrigger).TotalMinutes < TConfig.MinutesFromLastTrigger)
                {
                    if (!Config.DoNotLog)
                        Logger.Info(this, "Minimum trigger time not elapsed");
                    return;
                }

                Debug.WriteLine($"Object hash: {this.GetHashCode()}, MemoryUsage: {MemoryUsage}, Threshold: {TConfig.Threshold}");

                if (TConfig.TriggerIfUsageIsAboveThreshold)
                {
                    if (MemoryUsage > TConfig.Threshold)
                        TriggerEvent = true;
                }
                else if (TConfig.TriggerIfAvgUsageIsAboveThresholdLastXMin)
                {
                    DateTime DtFrom = DateTime.Now.Subtract(new TimeSpan(0, (int)TConfig.AvgIntervalMinutes, 0));
                    MemoryUsage = _MemoryUsageSamples.Where(t => t.SampleDateTime >= DtFrom).DefaultIfEmpty().Average(t => t == null ? 0 : t.SampleValue);

                    Debug.WriteLine($"Memory Average Usage: {MemoryUsage}, Threshold: {TConfig.Threshold}, Samples Count: {_MemoryUsageSamples.Count}");

                    // Before starting triggering the event, we want at least samples for duaration of TConfig.AvgIntervalMinutes minutes
                    if (DateTime.Now.Subtract(_DateFirstSample).TotalMinutes > TConfig.AvgIntervalMinutes
                        && MemoryUsage > TConfig.Threshold)
                        TriggerEvent = true;

                    _MemoryUsageSamples.RemoveAll(t => t.SampleDateTime < DtFrom);
                }

                if (TriggerEvent)
                {
                    DateTime Now = DateTime.Now;
                    DynamicDataSet DDataSet = CommonDynamicData.BuildStandardDynamicDataSet(this, true, 0, Now, Now, 1);
                    DDataSet.Add("MemoryUsagePercentage", MemoryUsage);

                    if (!Config.DoNotLog)
                    {
                        Logger.Info(this, $"Memory usage %: {MemoryUsage}");
                        Logger.EventTriggering(this);
                    }
                        
                    OnEventTriggered(new EventTriggeredEventArgs(DDataSet, Logger));
                    _DateLastTrigger = Now;
                }

                if (!TriggerEvent && !Config.DoNotLog)
                    Logger.Info(this, "Memory usage threshold not exceeded");
            }
            catch (Exception ex)
            {
                if (!Config.DoNotLog)
                    Logger.EventError(this, ex);
            }
        }

        public ExecResult Run(DynamicDataChain dataChain, DynamicDataSet lastDynamicDataSet, IPluginInstanceLogger instanceLogger)
        {
            MemoryEventConfig TConfig = (MemoryEventConfig)Config;

            int CheckIntervalSeconds = TConfig.CheckIntervalSeconds;
            if (CheckIntervalSeconds <= 0)
                CheckIntervalSeconds = 1;

            _RecurringTimer.Interval = new TimeSpan(0, 0, CheckIntervalSeconds).TotalMilliseconds;

            _RecurringTimer.Enabled = true;

            ExecResult ER = new ExecResult(true, null);
            return ER;
        }
    }
}
