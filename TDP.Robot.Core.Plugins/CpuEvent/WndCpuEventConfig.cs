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
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TDP.BaseServices.Infrastructure.DataValidation;
using TDP.Robot.Core;

namespace TDP.Robot.Plugins.Core.CpuEvent
{
    public partial class WndCpuEventConfig : WndPluginEventConfig
    {
        private const int _CheckIntervalMaxLength = 5;
        private const int _CheckIntervalMinValue = 0;
        private const int _CheckIntervalMaxValue = 99999;

        private const int _ThresholdMaxLength = 6;
        private const float _ThresholdMinValue = 0;
        private const float _ThresholdMaxValue = 99999;

        private const int _MinutesIntervalMaxLength = 3;
        private const int _MinutesIntervalMinValue = 0;
        private const int _MinutesIntervalMaxValue = 999;

        public WndCpuEventConfig()
        {
            InitializeComponent();
        }

        protected override void FillConfig(IPluginInstanceConfig config)
        {
            base.FillConfig(config);

            CpuEventConfig Config = (CpuEventConfig)config;

            Config.TriggerIfUsageIsAboveThreshold = RdbTriggerIfUsageIsAboveThreshold.Checked;
            Config.TriggerIfAvgUsageIsAboveThresholdLastXMin = RdbTriggerIfAvgUsageIsAboveThreshold.Checked;

            if (RdbTriggerIfUsageIsAboveThreshold.Checked)
            {
                Config.Threshold = float.Parse(TxtThreshold1.Text);
            }
            else if (RdbTriggerIfAvgUsageIsAboveThreshold.Checked)
            {
                Config.Threshold = float.Parse(TxtThreshold2.Text);
                Config.AvgIntervalMinutes = int.Parse(TxtAvgIntervalMinutes.Text);
            }

            Config.TriggerIfPassedXMinFromLastTrigger = ChkTriggerIfPassedXMinFromLastTrigger.Checked;

            if (ChkTriggerIfPassedXMinFromLastTrigger.Checked)
                Config.MinutesFromLastTrigger = int.Parse(TxtMinutesFromLastTrigger.Text);

            Config.CheckIntervalSeconds = int.Parse(TxtCheckIntervalSeconds.Text);
        }

        protected override void FillForm(IPluginInstanceConfig config)
        {
            base.FillForm(config);

            CpuEventConfig Config = (CpuEventConfig)config;

            RdbTriggerIfUsageIsAboveThreshold.Checked = Config.TriggerIfUsageIsAboveThreshold;
            RdbTriggerIfAvgUsageIsAboveThreshold.Checked = Config.TriggerIfAvgUsageIsAboveThresholdLastXMin;

            if (Config.TriggerIfUsageIsAboveThreshold)
            {
                TxtThreshold1.Text = Config.Threshold.ToString();
            }
            else if (Config.TriggerIfAvgUsageIsAboveThresholdLastXMin)
            {
                TxtThreshold2.Text = Config.Threshold.ToString();
                TxtAvgIntervalMinutes.Text = Config.AvgIntervalMinutes.ToString();
            }

            ChkTriggerIfPassedXMinFromLastTrigger.Checked = Config.TriggerIfPassedXMinFromLastTrigger;

            if (ChkTriggerIfPassedXMinFromLastTrigger.Checked)
                TxtMinutesFromLastTrigger.Text = Config.MinutesFromLastTrigger.ToString();

            TxtCheckIntervalSeconds.Text = Config.CheckIntervalSeconds.ToString();
        }

        protected override bool ValidateConfig(IPluginInstanceConfig config)
        {
            base.ValidateConfig(config);

            DataValidationHelper Validation = new DataValidationHelper();

            if (DataValidationHelper.IsEmptyString(TxtCheckIntervalSeconds.Text))
                SetError(TxtCheckIntervalSeconds, Resource.TxtFieldCannotBeEmpty);
            else if (!DataValidationHelper.IsInteger(TxtCheckIntervalSeconds.Text, _CheckIntervalMaxLength, _CheckIntervalMinValue, _CheckIntervalMaxValue))
                SetError(TxtCheckIntervalSeconds, string.Format(Resource.TxtMustBeANumberBetweenXAndY, _CheckIntervalMinValue, _CheckIntervalMaxValue));

            if (RdbTriggerIfUsageIsAboveThreshold.Checked)
            {
                if (DataValidationHelper.IsEmptyString(TxtThreshold1.Text))
                    SetError(TxtThreshold1, Resource.TxtFieldCannotBeEmpty);
                else if (!Validation.IsValidFloat(TxtThreshold1.Text, _ThresholdMaxLength, _ThresholdMinValue, _ThresholdMaxValue))
                    SetError(TxtThreshold1, string.Format(Resource.TxtMustBeANumberBetweenXAndY, _ThresholdMinValue, _ThresholdMaxValue));
            }
            else if (RdbTriggerIfAvgUsageIsAboveThreshold.Checked)
            {
                if (DataValidationHelper.IsEmptyString(TxtThreshold2.Text))
                    SetError(TxtThreshold2, Resource.TxtFieldCannotBeEmpty);
                else if (!Validation.IsValidFloat(TxtThreshold2.Text, _ThresholdMaxLength, _ThresholdMinValue, _ThresholdMaxValue))
                    SetError(TxtThreshold2, string.Format(Resource.TxtMustBeANumberBetweenXAndY, _ThresholdMinValue, _ThresholdMaxValue));

                if (DataValidationHelper.IsEmptyString(TxtAvgIntervalMinutes.Text))
                    SetError(TxtAvgIntervalMinutes, Resource.TxtFieldCannotBeEmpty);
                else if (!DataValidationHelper.IsInteger(TxtAvgIntervalMinutes.Text, _MinutesIntervalMaxLength, _MinutesIntervalMinValue, _MinutesIntervalMaxValue))
                    SetError(TxtAvgIntervalMinutes, string.Format(Resource.TxtMustBeANumberBetweenXAndY, _MinutesIntervalMinValue, _MinutesIntervalMaxValue));
            }

            if (ChkTriggerIfPassedXMinFromLastTrigger.Checked)
            {
                if (DataValidationHelper.IsEmptyString(TxtMinutesFromLastTrigger.Text))
                    SetError(TxtMinutesFromLastTrigger, Resource.TxtFieldCannotBeEmpty);
                else if (!DataValidationHelper.IsInteger(TxtMinutesFromLastTrigger.Text, _MinutesIntervalMaxLength, _MinutesIntervalMinValue, _MinutesIntervalMaxValue))
                    SetError(TxtMinutesFromLastTrigger, string.Format(Resource.TxtMustBeANumberBetweenXAndY, _MinutesIntervalMinValue, _MinutesIntervalMaxValue));
            }

            return GetErrorCount() == 0;
        }

        private void RdbTriggerIfUsageIsAboveThreshold_CheckedChanged(object sender, EventArgs e)
        {
            if (RdbTriggerIfUsageIsAboveThreshold.Checked)
            {
                TxtThreshold1.Enabled = true;
            }
            else
            {
                TxtThreshold1.Enabled = false;
                TxtThreshold1.Text = string.Empty;
            }
        }

        private void RdbTriggerIfAvgUsageIsAboveThreshold_CheckedChanged(object sender, EventArgs e)
        {
            if (RdbTriggerIfAvgUsageIsAboveThreshold.Checked)
            {
                TxtThreshold2.Enabled = true;
                TxtAvgIntervalMinutes.Enabled = true;
            }
            else
            {
                TxtThreshold2.Enabled = false;
                TxtThreshold2.Text = string.Empty;
                TxtAvgIntervalMinutes.Enabled = false;
                TxtAvgIntervalMinutes.Text = string.Empty;
            }
        }

        private void ChkTriggerIfPassedXMinFromLastTrigger_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkTriggerIfPassedXMinFromLastTrigger.Checked)
            {
                TxtMinutesFromLastTrigger.Enabled = true;
            }
            else
            {
                TxtMinutesFromLastTrigger.Enabled = false;
                TxtMinutesFromLastTrigger.Text = string.Empty;
            }
        }
    }
}
