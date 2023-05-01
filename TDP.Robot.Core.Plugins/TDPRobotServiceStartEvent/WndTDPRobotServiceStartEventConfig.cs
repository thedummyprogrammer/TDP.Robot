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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TDP.BaseServices.Infrastructure.DataValidation;
using TDP.Robot.Core;

namespace TDP.Robot.Plugins.Core.TDPRobotServiceStartEvent
{
    public partial class WndTDPRobotServiceStartEventConfig : WndPluginEventConfig
    {
        private const int _MinutesLength = 3;
        private const int _MinMinutesLengthValue = 0;
        private const int _MaxMinutesLengthValue = 999;

        public WndTDPRobotServiceStartEventConfig()
        {
            InitializeComponent();
        }

        protected override bool ValidateConfig(IPluginInstanceConfig config)
        {
            base.ValidateConfig(config);

            if (RdbTriggerEventWithin.Checked)
            {
                if (DataValidationHelper.IsEmptyString(TxtMinutesWithin.Text))
                    SetError(TxtMinutesWithin, Resource.TxtFieldCannotBeEmpty);
                else if (!DataValidationHelper.IsInteger(TxtMinutesWithin.Text, _MinutesLength, _MinMinutesLengthValue, _MaxMinutesLengthValue))
                    SetError(TxtMinutesWithin, Resource.TxtFieldNotContainAValidInteger);
            }

            if (RdbTriggerEventAfter.Checked)
            {
                if (DataValidationHelper.IsEmptyString(TxtMinutesAfter.Text))
                    SetError(TxtMinutesAfter, Resource.TxtFieldCannotBeEmpty);
                else if (!DataValidationHelper.IsInteger(TxtMinutesAfter.Text, _MinutesLength, _MinMinutesLengthValue, _MaxMinutesLengthValue))
                    SetError(TxtMinutesAfter, Resource.TxtFieldNotContainAValidInteger);
            }

            return GetErrorCount() == 0;
        }

        protected override void FillConfig(IPluginInstanceConfig config)
        {
            base.FillConfig(config);

            TDPRobotServiceStartEventConfig Config = (TDPRobotServiceStartEventConfig)config;

            if (!string.IsNullOrEmpty(TxtMinutesWithin.Text))
            {
                Config.MinutesWithin = int.Parse(TxtMinutesWithin.Text);
                Config.MinutesAfter = null;
            }
            else
            {
                Config.MinutesWithin = null;
                Config.MinutesAfter = int.Parse(TxtMinutesAfter.Text);
            }
        }

        protected override void FillForm(IPluginInstanceConfig config)
        {
            base.FillForm(config);

            TDPRobotServiceStartEventConfig Config = (TDPRobotServiceStartEventConfig)config;

            if (Config.MinutesWithin != null)
            {
                TxtMinutesWithin.Text = Config.MinutesWithin.ToString();
                RdbTriggerEventWithin.Checked = true;
            }
            else
            {
                TxtMinutesAfter.Text = Config.MinutesAfter.ToString();
                RdbTriggerEventAfter.Checked = true;
            }
        }

        private void RdbTriggerEventWithin_CheckedChanged(object sender, EventArgs e)
        {
            if (RdbTriggerEventWithin.Checked)
            {
                TxtMinutesWithin.Enabled = true;
                TxtMinutesAfter.Enabled = false;
                TxtMinutesAfter.Text = string.Empty;
            }
            else
            {
                TxtMinutesWithin.Enabled = false;
                TxtMinutesWithin.Text = string.Empty;
                TxtMinutesAfter.Enabled = true;
            }
        }
    }
}
