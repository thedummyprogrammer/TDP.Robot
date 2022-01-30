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
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TDP.Robot.Core;

namespace TDP.Robot.Plugins.Core.SystemEventsEvent
{
    public partial class WndSystemEventsEventConfig : WndPluginEventConfig
    {
        public WndSystemEventsEventConfig()
        {
            InitializeComponent();
        }

        protected override void FillConfig(IPluginInstanceConfig config)
        {
            base.FillConfig(config);

            SystemEventsEventConfig Config = (SystemEventsEventConfig)config;
            Config.EventDisplaySettingsChanged = ChkEventDisplaySettingsChanged.Checked;
            Config.EventInstalledFontsChanged = ChkEventInstalledFontsChanged.Checked;
            Config.EventPaletteChanged = ChkEventPaletteChanges.Checked;
            Config.EventPowerModeChanged = ChkEventPowerModeChanged.Checked;
            Config.EventSessionEnded = ChkEventSessionEnded.Checked;
            Config.EventSessionSwitch = ChkEventSessionSwitch.Checked;
            Config.EventTimeChanged = ChkEventTimeChanged.Checked;
            Config.EventUserPreferenceChanged = ChkEventUserPreferenceChanged.Checked;
        }

        protected override void FillForm(IPluginInstanceConfig config)
        {
            base.FillForm(config);

            SystemEventsEventConfig Config = (SystemEventsEventConfig)config;
            ChkEventDisplaySettingsChanged.Checked = Config.EventDisplaySettingsChanged;
            ChkEventInstalledFontsChanged.Checked = Config.EventInstalledFontsChanged;
            ChkEventPaletteChanges.Checked = Config.EventPaletteChanged;
            ChkEventPowerModeChanged.Checked = Config.EventPowerModeChanged;
            ChkEventSessionEnded.Checked = Config.EventSessionEnded;
            ChkEventSessionSwitch.Checked = Config.EventSessionSwitch;
            ChkEventTimeChanged.Checked = Config.EventTimeChanged;
            ChkEventUserPreferenceChanged.Checked = Config.EventUserPreferenceChanged;
        }

        protected override bool ValidateConfig(IPluginInstanceConfig config)
        {
            base.ValidateConfig(config);

            if (!ChkEventDisplaySettingsChanged.Checked && !ChkEventInstalledFontsChanged.Checked
                && !ChkEventPaletteChanges.Checked && !ChkEventPowerModeChanged.Checked
                && !ChkEventSessionEnded.Checked && !ChkEventSessionSwitch.Checked
                && !ChkEventTimeChanged.Checked && !ChkEventUserPreferenceChanged.Checked)
            {
                SetError(GrpEventsToMonitor, Resource.TxtYouMustSelectAnEvent);
            }

            return GetErrorCount() == 0;
        }
    }
}
