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
using System.IO;
using System.Windows.Forms;
using TDP.BaseServices.Infrastructure.DataValidation;
using TDP.Robot.Core;
using TDP.Robot.Plugins.Core.Infrastructure;

namespace TDP.Robot.Plugins.Core.DiskSpaceEvent
{
    public partial class WndDiskThreshold : WndPluginDetailConfigBase
    {
        private const int _ThresholdMaxLength = 8;
        private const int _ThresholdMinValue = 0;
        private const int _ThresholdMaxValue = 99999999;
        
        private const int _ThresholdMaxValueTB = 999999;
        private const int _ThresholdMaxLengthTB = 6;

        public string Disk
        {
            get { return CmbDisk.SelectedItem.ToString(); }
            set { CmbDisk.SelectedItem = value; }
        }

        public CheckOperator Operator
        {
            get { return ((ListItem<CheckOperator>)CmbCheckOperator.SelectedItem).Value; }
            set { CmbCheckOperator.SetSelectedItem(value); }
        }

        public string Threshold
        {
            get { return TxtThreshold.Text; }
            set { TxtThreshold.Text = value; }
        }

        public DiskThresholdUnitMeasure UnitMeasure
        {
            get { return ((ListItem<DiskThresholdUnitMeasure>)CmbUnitMeasure.SelectedItem).Value; }
            set { CmbUnitMeasure.SetSelectedItem(value); }
        }


        public WndDiskThreshold()
        {
            InitializeComponent();

            DriveInfo[] AllDrives = DriveInfo.GetDrives();
            foreach (DriveInfo Drive in AllDrives)
            {
                CmbDisk.Items.Add(Drive.Name);
            }
            CmbDisk.SelectedIndex = 0;

            CmbCheckOperator.Items.Add(new ListItem<CheckOperator>(CheckOperator.GreaterThan, Resource.TxtGreaterThan));
            CmbCheckOperator.Items.Add(new ListItem<CheckOperator>(CheckOperator.LessThan, Resource.TxtLessThan));
            CmbCheckOperator.SelectedIndex = 0;

            CmbUnitMeasure.Items.Add(new ListItem<DiskThresholdUnitMeasure>(DiskThresholdUnitMeasure.Megabytes, Resource.TxtMegabytes));
            CmbUnitMeasure.Items.Add(new ListItem<DiskThresholdUnitMeasure>(DiskThresholdUnitMeasure.Gigabytes, Resource.TxtGigabytes));
            CmbUnitMeasure.Items.Add(new ListItem<DiskThresholdUnitMeasure>(DiskThresholdUnitMeasure.Terabytes, Resource.TxtTerabytes));
            CmbUnitMeasure.Items.Add(new ListItem<DiskThresholdUnitMeasure>(DiskThresholdUnitMeasure.Percentage, Resource.TxtPercentage));
            CmbUnitMeasure.SelectedIndex = 0;
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            ClearErrors();

            try
            {
                if (CmbDisk.SelectedIndex < 0)
                    SetError(CmbDisk, Resource.TxtFieldCannotBeEmpty);

                if (CmbCheckOperator.SelectedIndex < 0)
                    SetError(CmbCheckOperator, Resource.TxtFieldCannotBeEmpty);

                if (DataValidationHelper.IsEmptyString(TxtThreshold.Text))
                    SetError(TxtThreshold, Resource.TxtFieldCannotBeEmpty);
                else if (((DiskThresholdUnitMeasure)CmbCheckOperator.SelectedValue) != DiskThresholdUnitMeasure.Terabytes && !DataValidationHelper.IsInteger(TxtThreshold.Text, _ThresholdMaxLength, _ThresholdMinValue, _ThresholdMaxValue))
                    SetError(TxtThreshold, string.Format(Resource.TxtMustBeANumberBetweenXAndY, _ThresholdMinValue, _ThresholdMaxValue));
                else if (((DiskThresholdUnitMeasure)CmbCheckOperator.SelectedValue) == DiskThresholdUnitMeasure.Terabytes && !DataValidationHelper.IsInteger(TxtThreshold.Text, _ThresholdMaxLengthTB, _ThresholdMinValue, _ThresholdMaxValueTB))
                    SetError(TxtThreshold, string.Format(Resource.TxtMustBeANumberBetweenXAndY, _ThresholdMinValue, _ThresholdMaxValueTB));

                if (CmbUnitMeasure.SelectedIndex < 0)
                    SetError(CmbUnitMeasure, Resource.TxtFieldCannotBeEmpty);
            }
            finally
            {
                if (GetErrorCount() == 0)
                    DialogResult = DialogResult.OK;
            }
        }
    }
}
