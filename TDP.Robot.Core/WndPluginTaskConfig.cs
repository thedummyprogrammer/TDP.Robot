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

namespace TDP.Robot.Core
{
    public partial class WndPluginTaskConfig : WndPluginConfigBase
    {
        public WndPluginTaskConfig()
        {
            InitializeComponent();
        }

        protected void MoveBaseTabs()
        {
            TabPage TabIterations = TabConfig2.TabPages["TabIterations"];
            TabConfig2.TabPages.Remove(TabIterations);
            TabConfig2.TabPages.Add(TabIterations);
        }

        protected override bool ValidateConfig(IPluginInstanceConfig config)
        {
            base.ValidateConfig(config);

            if (!RdbIteratesDefaultRecordset.Checked && !RdbIterateObjectRecordset.Checked && !RdbIteratesExactNumber.Checked)
            {
                SetError(RdbIteratesDefaultRecordset, Resource.TxtYouMustChooseAnIterationMode);
            }
            else
            {
                if (RdbIterateObjectRecordset.Checked)
                {
                    if (DataValidationHelper.IsEmptyString(TxtObjectRecordset.Text))
                        SetError(TxtObjectRecordset, Resource.TxtFieldCannotBeEmpty);
                }
                else if (RdbIteratesExactNumber.Checked)
                {
                    if (DataValidationHelper.IsEmptyString(TxtIterationsNumber.Text))
                        SetError(TxtIterationsNumber, Resource.TxtFieldCannotBeEmpty);
                    else if (!DataValidationHelper.IsInteger(TxtIterationsNumber.Text, Constants.IterationsNumberLength, Constants.IterationsMinNumber, Constants.IterationsMaxNumber))
                        SetError(TxtIterationsNumber, string.Format(Resource.TxtMustBeANumberBetweenXAndY, Constants.IterationsMinNumber, Constants.IterationsMaxNumber));
                }
            }

            return GetErrorCount() == 0;
        }

        protected override void FillForm(IPluginInstanceConfig config)
        {
            base.FillForm(config);

            ITaskConfig Config = (ITaskConfig)config;
            if (Config.PluginIterationMode == IterationMode.IterateDefaultRecordset)
            {
                RdbIteratesDefaultRecordset.Checked = true;
            }
            else if (Config.PluginIterationMode == IterationMode.IterateObjectRecordset)
            {
                RdbIterateObjectRecordset.Checked = true;
                TxtObjectRecordset.Text = Config.IterationObject;
            }
            else if (Config.PluginIterationMode == IterationMode.IterateExactNumber)
            {
                RdbIteratesExactNumber.Checked = true;
                TxtIterationsNumber.Text = Config.IterationsCount.ToString();
            }
        }

        protected override void FillConfig(IPluginInstanceConfig config)
        {
            base.FillConfig(config);

            ITaskConfig Config = (ITaskConfig)config;
            if (RdbIteratesDefaultRecordset.Checked)
            {
                Config.PluginIterationMode = IterationMode.IterateDefaultRecordset;
            }
            else if (RdbIterateObjectRecordset.Checked)
            {
                Config.PluginIterationMode = IterationMode.IterateObjectRecordset;
                Config.IterationObject = TxtObjectRecordset.Text;
            }
            else if (RdbIteratesExactNumber.Checked)
            {
                Config.PluginIterationMode = IterationMode.IterateExactNumber;
                Config.IterationsCount = int.Parse(TxtIterationsNumber.Text);
            }
        }

        private void RdbIteratesDefaultRecordset_CheckedChanged(object sender, EventArgs e)
        {
            if (RdbIteratesDefaultRecordset.Checked)
            {
                TxtObjectRecordset.Enabled = false;
                TxtIterationsNumber.Enabled = false;
            }
        }

        private void RdbIterateObjectRecordset_CheckedChanged(object sender, EventArgs e)
        {
            TxtObjectRecordset.Enabled = true;
            TxtIterationsNumber.Enabled = false;
        }

        private void RdbIteratesExactNumber_CheckedChanged(object sender, EventArgs e)
        {
            TxtObjectRecordset.Enabled = false;
            TxtIterationsNumber.Enabled = true;
        }
    }
}
