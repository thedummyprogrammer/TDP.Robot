/*======================================================================================
    Copyright 2021 - 2023 by TheDummyProgrammer (https://www.thedummyprogrammer.com)

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

using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TDP.Robot.Core;
using TDP.Robot.Core.DynamicData;
using TDP.Robot.Core.Logging;

namespace TDP.Robot.Plugins.Core.SystemEventsEvent
{
    [Serializable]
    public class SystemEventsEvent : IEvent
    {
        public IFolder ParentFolder { get; set; }
        public int ID { get; set; }
        public IPluginInstanceConfig Config { get; set; }

        public List<PluginInstanceConnection> Connections { get; } = new List<PluginInstanceConnection>();

        [field: NonSerialized]
        public event EventTriggeredDelegate EventTriggered;

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
            
        }

        public void Destroy()
        {
            
        }

        public InstanceExecResult Run(DynamicDataChain dataChain, DynamicDataSet lastDynamicDataSet, IPluginInstanceLogger instanceLogger)
        {
            new Thread(() =>
            {
                SystemEventsEventConfig TConfig = (SystemEventsEventConfig)Config;
                WndHiddenForm FormEvents = new WndHiddenForm();

                if (TConfig.EventDisplaySettingsChanged)
                {
                    FormEvents.EventDisplaySettingsChanged = true;
                    FormEvents.DisplaySettingsChanged += FormEvents_DisplaySettingsChanged;
                }

                if (TConfig.EventInstalledFontsChanged)
                {
                    FormEvents.EventInstalledFontsChanged = true;
                    FormEvents.InstalledFontsChanged += FormEvents_InstalledFontsChanged;
                }

                if (TConfig.EventPaletteChanged)
                {
                    FormEvents.EventPaletteChanged = true;
                    FormEvents.PaletteChanged += FormEvents_PaletteChanged;
                }

                if (TConfig.EventPowerModeChanged)
                {
                    FormEvents.EventPowerModeChanged = true;
                    FormEvents.PowerModeChanged += FormEvents_PowerModeChanged;
                }

                if (TConfig.EventSessionEnded)
                {
                    FormEvents.EventSessionEnded = true;
                    FormEvents.SessionEnded += FormEvents_SessionEnded;
                }

                if (TConfig.EventSessionSwitch)
                {
                    FormEvents.EventSessionSwitch = true;
                    FormEvents.SessionSwitch += FormEvents_SessionSwitch;
                }

                if (TConfig.EventTimeChanged)
                {
                    FormEvents.EventTimeChanged = true;
                    FormEvents.TimeChanged += FormEvents_TimeChanged;
                }

                if (TConfig.EventUserPreferenceChanged)
                {
                    FormEvents.EventUserPreferenceChanged = true;
                    FormEvents.UserPreferenceChanged += FormEvents_UserPreferenceChanged;
                }

                Application.Run(FormEvents);

            }).Start();

            List<ExecResult> execResults = new List<ExecResult>();
            execResults.Add(new ExecResult(true, null));
            return new InstanceExecResult(execResults);
        }

        private void TriggerEvent(string eventCode)
        {
            IPluginInstanceLogger Logger = PluginInstanceLogger.GetLogger(this);

            try
            {
                if (!Config.DoNotLog)
                    Logger.EventTriggered(this);

                DateTime Now = DateTime.Now;
                DynamicDataSet DDataSet = CommonDynamicData.BuildStandardDynamicDataSet(this, true, 0, Now, Now, 1);
                DDataSet.Add(SystemEventsEventCommon.DynDataKeyEventCode, eventCode);

                if (!Config.DoNotLog)
                {
                    Logger.Info(this, $"Detected event: {eventCode}");
                    Logger.EventTriggering(this);
                }
                    
                OnEventTriggered(new EventTriggeredEventArgs(DDataSet, Logger));
            }
            catch (Exception ex)
            {
                if (!Config.DoNotLog)
                    Logger.EventError(this, ex);
            }
        }

        private void FormEvents_UserPreferenceChanged(object sender, UserPreferenceChangedEventArgs e)
        {
            TriggerEvent(SystemEventsEventCommon.EventCodeUserPreferenceChanged);
        }

        private void FormEvents_TimeChanged(object sender, EventArgs e)
        {
            TriggerEvent(SystemEventsEventCommon.EventCodeTimeChanged);
        }

        private void FormEvents_SessionSwitch(object sender, SessionSwitchEventArgs e)
        {
            TriggerEvent(SystemEventsEventCommon.EventCodeSessionSwitch);
        }

        private void FormEvents_SessionEnded(object sender, SessionEndedEventArgs e)
        {
            TriggerEvent(SystemEventsEventCommon.EventCodeSessionEnded);
        }

        private void FormEvents_PowerModeChanged(object sender, PowerModeChangedEventArgs e)
        {
            TriggerEvent(SystemEventsEventCommon.EventCodePowerModeChanged);
        }

        private void FormEvents_PaletteChanged(object sender, EventArgs e)
        {
            TriggerEvent(SystemEventsEventCommon.EventCodePaletteChanged);
        }

        private void FormEvents_InstalledFontsChanged(object sender, EventArgs e)
        {
            TriggerEvent(SystemEventsEventCommon.EventCodeInstalledFontsChanged);
        }

        private void FormEvents_DisplaySettingsChanged(object sender, EventArgs e)
        {
            TriggerEvent(SystemEventsEventCommon.EventCodeDisplaySettingsChanged);
        }
    }
}
