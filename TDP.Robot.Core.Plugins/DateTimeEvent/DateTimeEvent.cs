/*======================================================================================
    Copyright 2021 - 2022 by TheDummyProgrammer (https://www.thedummyprogrammer.com)

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
using System.Linq;
using TDP.Robot.Core;
using TDP.Robot.Core.Logging;
using TDP.Robot.Core.DynamicData;

namespace TDP.Robot.Plugins.Core.DateTimeEvent
{
    [Serializable]
    public class DateTimeEvent : IEvent
    {
        public IFolder ParentFolder { get; set; }
        public int ID { get; set; }
        public IPluginInstanceConfig Config { get; set; }

        public List<PluginInstanceConnection> Connections { get; } = new List<PluginInstanceConnection>();

        [field: NonSerialized]
        public event EventTriggeredDelegate EventTriggered;

        [field: NonSerialized]
        private System.Timers.Timer _OneTimeTimer;

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
            _OneTimeTimer = new System.Timers.Timer();
            _OneTimeTimer.Enabled = false;
            _OneTimeTimer.AutoReset = false;
            _OneTimeTimer.Elapsed += _OnTimeTimer_Elapsed;

            _RecurringTimer = new System.Timers.Timer();
            _RecurringTimer.Enabled = false;
            _RecurringTimer.AutoReset = true;
            _RecurringTimer.Elapsed += _RecurringTimer_Elapsed;
        }

        public void Destroy()
        {
            _OneTimeTimer.Dispose();
            _RecurringTimer.Dispose();
        }

        private void _OnTimeTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            IPluginInstanceLogger Logger = PluginInstanceLogger.GetLogger(this);

            try
            {
                if (!Config.DoNotLog)
                    Logger.EventTriggered(this);
                
                DateTime Now = DateTime.Now;
                DynamicDataSet DDataSet = CommonDynamicData.BuildStandardDynamicDataSet(this, true, 0, Now, Now, 1);

                if (!Config.DoNotLog)
                    Logger.EventTriggering(this);
                OnEventTriggered(new EventTriggeredEventArgs(DDataSet, Logger));

                DateTimeEventConfig TConfig = (DateTimeEventConfig)Config;
                if (!TConfig.OneTime)
                    _RecurringTimer.Enabled = true;
            }
            catch (Exception ex)
            {
                if (!Config.DoNotLog)
                    Logger.EventError(this, ex);
            }
        }

        private void _RecurringTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            IPluginInstanceLogger Logger = PluginInstanceLogger.GetLogger(this);

            try
            {
                if (!Config.DoNotLog)
                    Logger.EventTriggered(this);
                DateTime Now = DateTime.Now;
                DateTimeEventConfig TConfig = (DateTimeEventConfig)Config;
                DynamicDataSet DDataSet = CommonDynamicData.BuildStandardDynamicDataSet(this, true, 0, Now, Now, 1);

                if ((TConfig.OnDays.Where(I => I.Equals(Now.DayOfWeek)).Count() > 0) || TConfig.OnAllDays)
                {
                    if (!Config.DoNotLog)
                        Logger.EventTriggering(this);
                    OnEventTriggered(new EventTriggeredEventArgs(DDataSet, Logger));
                }
            }
            catch (Exception ex)
            {
                if (!Config.DoNotLog)
                    Logger.EventError(this, ex);
            }
        }


        public InstanceExecResult Run(DynamicDataChain dataChain, DynamicDataSet lastDynamicDataSet, IPluginInstanceLogger instanceLogger)
        {
            bool EnableOneTimeTimer = false;
            bool EnableRecurringTimer = false;
            DateTimeEventConfig TConfig = (DateTimeEventConfig)Config;

            DateTime Now = DateTime.Now;
            if (TConfig.AtDate > Now)
            {
                _OneTimeTimer.Interval = TConfig.AtDate.Subtract(Now).TotalMilliseconds;
                EnableOneTimeTimer = true;
            }

            if (TConfig.EveryDaysHoursSecs)
            {
                _RecurringTimer.Interval = new TimeSpan(TConfig.EveryNumDays, TConfig.EveryNumHours, TConfig.EveryNumMinutes, 0).TotalMilliseconds;
                EnableRecurringTimer = true;
            }
            else if (TConfig.EverySeconds)
            {
                _RecurringTimer.Interval = new TimeSpan(0, 0, 0, TConfig.EveryNumSeconds).TotalMilliseconds;
                EnableRecurringTimer = true;
            }

            if (EnableOneTimeTimer)
                _OneTimeTimer.Enabled = true;
            else if (EnableRecurringTimer)
                _RecurringTimer.Enabled = true;

            List<ExecResult> execResults = new List<ExecResult>();
            execResults.Add(new ExecResult(true, null));
            return new InstanceExecResult(execResults);
        }
    }
}
