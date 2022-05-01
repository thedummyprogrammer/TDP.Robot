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
using System.Windows.Forms;
using TDP.BaseServices.Infrastructure.DataValidation;
using TDP.Robot.Core;

namespace TDP.Robot.Plugins.Core.DiskSpaceEvent
{
    public partial class WndDiskSpaceEventConfig : WndPluginEventConfig
    {
        private const int _CheckIntervalMaxLength = 5;
        private const int _CheckIntervalMinValue = 0;
        private const int _CheckIntervalMaxValue = 99999;

        public WndDiskSpaceEventConfig()
        {
            InitializeComponent();
        }

        private void ManageEditDiskThreshold()
        {
            if (LstDisks.SelectedIndex < 0)
            {
                MessageBox.Show(Resource.TxtYouMustSelectItem, Resource.TxtTheDummyProgrammerRobot, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DiskThreshold DiskTh = (DiskThreshold)LstDisks.SelectedItem;

            using (WndDiskThreshold F = new WndDiskThreshold())
            {
                F.Disk = DiskTh.Disk;
                F.Operator = DiskTh.CheckOperator;
                F.Threshold = DiskTh.ThresholdValue.ToString();
                F.UnitMeasure = DiskTh.UnitMeasure;
                F.DynamicDataObjectSamples = DynamicDataObjectSamples;
                F.CallerID = _PluginConfig.ID;
                if (F.ShowDialog() == DialogResult.OK)
                {
                    DiskTh.Disk = F.Disk;
                    DiskTh.CheckOperator = F.Operator;
                    DiskTh.ThresholdValue = int.Parse(F.Threshold);
                    DiskTh.UnitMeasure = F.UnitMeasure;
                                        
                    LstDisks.Items[LstDisks.SelectedIndex] = DiskTh;
                }
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            using (WndDiskThreshold F = new WndDiskThreshold())
            {
                F.DynamicDataObjectSamples = DynamicDataObjectSamples;
                F.CallerID = _PluginConfig.ID;
                if (F.ShowDialog() == DialogResult.OK)
                {
                    DiskThreshold DiskTh = new DiskThreshold(F.Disk, F.Operator, int.Parse(F.Threshold), F.UnitMeasure);
                    LstDisks.Items.Add(DiskTh);
                }
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            ManageEditDiskThreshold();
        }

        private void LstDisks_DoubleClick(object sender, EventArgs e)
        {
            ManageEditDiskThreshold();
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            if (LstDisks.SelectedIndex < 0)
            {
                MessageBox.Show(Resource.TxtYouMustSelectItem, Resource.TxtTheDummyProgrammerRobot, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            LstDisks.Items.RemoveAt(LstDisks.SelectedIndex);
        }

        protected override void FillConfig(IPluginInstanceConfig config)
        {
            base.FillConfig(config);

            DiskSpaceEventConfig Config = (DiskSpaceEventConfig)config;

            Config.CheckIntervalSeconds = int.Parse(TxtCheckIntervalSeconds.Text);

            Config.DiskThresholds.Clear();
            foreach (DiskThreshold DiskTh in LstDisks.Items)
            {
                Config.DiskThresholds.Add(DiskTh);
            }
        }

        protected override void FillForm(IPluginInstanceConfig config)
        {
            base.FillForm(config);

            DiskSpaceEventConfig Config = (DiskSpaceEventConfig)config;

            TxtCheckIntervalSeconds.Text = Config.CheckIntervalSeconds.ToString();

            LstDisks.Items.Clear();
            foreach (DiskThreshold DiskTh in Config.DiskThresholds)
            {
                LstDisks.Items.Add(DiskTh);
            }
        }

        protected override bool ValidateConfig(IPluginInstanceConfig config)
        {
            base.ValidateConfig(config);

            if (LstDisks.Items.Count == 0)
                SetError(LstDisks, Resource.TxtFieldCannotBeEmpty);
            
            if (DataValidationHelper.IsEmptyString(TxtCheckIntervalSeconds.Text))
                SetError(TxtCheckIntervalSeconds, Resource.TxtFieldCannotBeEmpty);
            else if (!DataValidationHelper.IsInteger(TxtCheckIntervalSeconds.Text, _CheckIntervalMaxLength, _CheckIntervalMinValue, _CheckIntervalMaxValue))
                SetError(LstDisks, string.Format(Resource.TxtMustBeANumberBetweenXAndY, _CheckIntervalMinValue, _CheckIntervalMaxValue));

            return GetErrorCount() == 0;
        }
    }
}
