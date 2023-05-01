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
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TDP.Robot.Plugins.Core.SystemEventsEvent
{
    public partial class WndHiddenForm : Form
    {
        public WndHiddenForm()
        {
            InitializeComponent();
        }

        public bool EventDisplaySettingsChanged { get; set; }
        public bool EventInstalledFontsChanged { get; set; }
        public bool EventPaletteChanged { get; set; }
        public bool EventPowerModeChanged { get; set; }
        public bool EventSessionEnded { get; set; }
        public bool EventSessionSwitch { get; set; }
        public bool EventTimeChanged { get; set; }
        public bool EventUserPreferenceChanged { get; set; }

        [field: NonSerialized]
        public event EventHandler DisplaySettingsChanged;

        [field: NonSerialized]
        public event EventHandler InstalledFontsChanged;

        [field: NonSerialized]
        public event EventHandler PaletteChanged;

        [field: NonSerialized]
        public event PowerModeChangedEventHandler PowerModeChanged;

        [field: NonSerialized]
        public event SessionEndedEventHandler SessionEnded;

        [field: NonSerialized]
        public event SessionSwitchEventHandler SessionSwitch;

        [field: NonSerialized]
        public event EventHandler TimeChanged;

        [field: NonSerialized]
        public event UserPreferenceChangedEventHandler UserPreferenceChanged;

        protected virtual void OnDisplaySettingsChanged(EventArgs e)
        {
            EventHandler handler = DisplaySettingsChanged;
            if (handler != null)
            {
                foreach (EventHandler singleCast in handler.GetInvocationList())
                {
                    ISynchronizeInvoke syncInvoke = singleCast.Target as ISynchronizeInvoke;
                    if ((syncInvoke != null) && (syncInvoke.InvokeRequired))
                        syncInvoke.Invoke(singleCast, new object[] { this, e });
                    else
                        singleCast(this, e);
                }
            }
        }

        protected virtual void OnInstalledFontsChanged(EventArgs e)
        {
            EventHandler handler = InstalledFontsChanged;
            if (handler != null)
            {
                foreach (EventHandler singleCast in handler.GetInvocationList())
                {
                    ISynchronizeInvoke syncInvoke = singleCast.Target as ISynchronizeInvoke;
                    if ((syncInvoke != null) && (syncInvoke.InvokeRequired))
                        syncInvoke.Invoke(singleCast, new object[] { this, e });
                    else
                        singleCast(this, e);
                }
            }
        }

        protected virtual void OnPaletteChanged(EventArgs e)
        {
            EventHandler handler = PaletteChanged;
            if (handler != null)
            {
                foreach (EventHandler singleCast in handler.GetInvocationList())
                {
                    ISynchronizeInvoke syncInvoke = singleCast.Target as ISynchronizeInvoke;
                    if ((syncInvoke != null) && (syncInvoke.InvokeRequired))
                        syncInvoke.Invoke(singleCast, new object[] { this, e });
                    else
                        singleCast(this, e);
                }
            }
        }

        protected virtual void OnPowerModeChanged(PowerModeChangedEventArgs e)
        {
            PowerModeChangedEventHandler handler = PowerModeChanged;
            if (handler != null)
            {
                foreach (PowerModeChangedEventHandler singleCast in handler.GetInvocationList())
                {
                    ISynchronizeInvoke syncInvoke = singleCast.Target as ISynchronizeInvoke;
                    if ((syncInvoke != null) && (syncInvoke.InvokeRequired))
                        syncInvoke.Invoke(singleCast, new object[] { this, e });
                    else
                        singleCast(this, e);
                }
            }
        }

        protected virtual void OnSessionEndeded(SessionEndedEventArgs e)
        {
            SessionEndedEventHandler handler = SessionEnded;
            if (handler != null)
            {
                foreach (SessionEndedEventHandler singleCast in handler.GetInvocationList())
                {
                    ISynchronizeInvoke syncInvoke = singleCast.Target as ISynchronizeInvoke;
                    if ((syncInvoke != null) && (syncInvoke.InvokeRequired))
                        syncInvoke.Invoke(singleCast, new object[] { this, e });
                    else
                        singleCast(this, e);
                }
            }
        }

        protected virtual void OnSessionSwitch(SessionSwitchEventArgs e)
        {
            SessionSwitchEventHandler handler = SessionSwitch;
            if (handler != null)
            {
                foreach (SessionSwitchEventHandler singleCast in handler.GetInvocationList())
                {
                    ISynchronizeInvoke syncInvoke = singleCast.Target as ISynchronizeInvoke;
                    if ((syncInvoke != null) && (syncInvoke.InvokeRequired))
                        syncInvoke.Invoke(singleCast, new object[] { this, e });
                    else
                        singleCast(this, e);
                }
            }
        }

        protected virtual void OnTimeChanged(EventArgs e)
        {
            EventHandler handler = TimeChanged;
            if (handler != null)
            {
                foreach (EventHandler singleCast in handler.GetInvocationList())
                {
                    ISynchronizeInvoke syncInvoke = singleCast.Target as ISynchronizeInvoke;
                    if ((syncInvoke != null) && (syncInvoke.InvokeRequired))
                        syncInvoke.Invoke(singleCast, new object[] { this, e });
                    else
                        singleCast(this, e);
                }
            }
        }

        protected virtual void OnUserPreferenceChanged(UserPreferenceChangedEventArgs e)
        {
            UserPreferenceChangedEventHandler handler = UserPreferenceChanged;
            if (handler != null)
            {
                foreach (UserPreferenceChangedEventHandler singleCast in handler.GetInvocationList())
                {
                    ISynchronizeInvoke syncInvoke = singleCast.Target as ISynchronizeInvoke;
                    if ((syncInvoke != null) && (syncInvoke.InvokeRequired))
                        syncInvoke.Invoke(singleCast, new object[] { this, e });
                    else
                        singleCast(this, e);
                }
            }
        }

        private void WndHiddenForm_Load(object sender, EventArgs e)
        {
            if (EventDisplaySettingsChanged)
            {
                SystemEvents.DisplaySettingsChanged += SystemEvents_DisplaySettingsChanged;
            }

            if (EventInstalledFontsChanged)
            {
                SystemEvents.InstalledFontsChanged += SystemEvents_InstalledFontsChanged;
            }

            if (EventPaletteChanged)
            {
                SystemEvents.PaletteChanged += SystemEvents_PaletteChanged;
            }

            if (EventPowerModeChanged)
            {
                SystemEvents.PowerModeChanged += SystemEvents_PowerModeChanged;
            }

            if (EventSessionEnded)
            {
                SystemEvents.SessionEnded += SystemEvents_SessionEnded;
            }

            if (EventSessionSwitch)
            {
                SystemEvents.SessionSwitch += SystemEvents_SessionSwitch;
            }

            if (EventTimeChanged)
            {
                SystemEvents.TimeChanged += SystemEvents_TimeChanged;
            }

            if (EventUserPreferenceChanged)
            {
                SystemEvents.UserPreferenceChanged += SystemEvents_UserPreferenceChanged;
            }
        }

        private void SystemEvents_UserPreferenceChanged(object sender, UserPreferenceChangedEventArgs e)
        {
            OnUserPreferenceChanged(e);
        }

        private void SystemEvents_TimeChanged(object sender, EventArgs e)
        {
            OnTimeChanged(e);
        }

        private void SystemEvents_SessionSwitch(object sender, SessionSwitchEventArgs e)
        {
            OnSessionSwitch(e);
        }

        private void SystemEvents_SessionEnded(object sender, SessionEndedEventArgs e)
        {
            OnSessionEndeded(e);
        }

        private void SystemEvents_PowerModeChanged(object sender, PowerModeChangedEventArgs e)
        {
            OnPowerModeChanged(e);
        }

        private void SystemEvents_PaletteChanged(object sender, EventArgs e)
        {
            OnPaletteChanged(e);
        }

        private void SystemEvents_InstalledFontsChanged(object sender, EventArgs e)
        {
            OnInstalledFontsChanged(e);
        }

        private void SystemEvents_DisplaySettingsChanged(object sender, EventArgs e)
        {
            OnDisplaySettingsChanged(e);
        }

        private void WndHiddenForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (EventDisplaySettingsChanged)
            {
                SystemEvents.DisplaySettingsChanged -= SystemEvents_DisplaySettingsChanged;
            }

            if (EventInstalledFontsChanged)
            {
                SystemEvents.InstalledFontsChanged -= SystemEvents_InstalledFontsChanged;
            }

            if (EventPaletteChanged)
            {
                SystemEvents.PaletteChanged -= SystemEvents_PaletteChanged;
            }

            if (EventPowerModeChanged)
            {
                SystemEvents.PowerModeChanged -= SystemEvents_PowerModeChanged;
            }

            if (EventSessionEnded)
            {
                SystemEvents.SessionEnded -= SystemEvents_SessionEnded;
            }

            if (EventSessionSwitch)
            {
                SystemEvents.SessionSwitch -= SystemEvents_SessionSwitch;
            }

            if (EventTimeChanged)
            {
                SystemEvents.TimeChanged -= SystemEvents_TimeChanged;
            }

            if (EventUserPreferenceChanged)
            {
                SystemEvents.UserPreferenceChanged -= SystemEvents_UserPreferenceChanged;
            }
        }
    }
}
