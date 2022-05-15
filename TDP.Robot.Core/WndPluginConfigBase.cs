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
using System.Windows.Forms;
using TDP.Robot.Core.DynamicData;

namespace TDP.Robot.Core
{
    public partial class WndPluginConfigBase : Form
    {
        protected IPluginInstanceConfig _PluginConfig;
        
        public IPluginInstanceConfig PluginConfig 
        { 
            get 
            {
                if (_PluginConfig != null)
                    FillConfig(_PluginConfig);
                return _PluginConfig; 
            }
            set 
            { 
                _PluginConfig = value;
                if (_PluginConfig != null)
                    FillForm(_PluginConfig);
            }
        }

        public List<DynamicDataObjectSamples> DynamicDataObjectSamples { get; set; }

        protected int _ErrorCount;
        protected void SetError(Control control, string value)
        {
            ErrProvider.SetError(control, value);
            _ErrorCount++;
        }

        protected void ClearErrors()
        {
            ErrProvider.Clear();
            _ErrorCount = 0;
        }

        protected int GetErrorCount()
        {
            return _ErrorCount;
        }

        public WndPluginConfigBase()
        {
            InitializeComponent();
        }

        protected virtual bool ValidateConfig(IPluginInstanceConfig config)
        {
            return true;
        }

        protected virtual void FillForm(IPluginInstanceConfig config)
        {
            TxtID.Text = config.ID.ToString();
            TxtName.Text = config.Name;
            ChkDisable.Checked = config.Disable;
            ChkDoNotLog.Checked = config.DoNotLog;
        }

        protected virtual void FillConfig(IPluginInstanceConfig config)
        {
            config.Name = TxtName.Text;
            config.Disable = ChkDisable.Checked;
            config.DoNotLog = ChkDoNotLog.Checked;
        }

        protected void ShowDynamicDataBrowserWindow(TextBox txtDestinationTextBox, List<DynamicDataObjectSamples> _dynamicDataObjectSamples)
        {
            using (WndDynamicDataBrowser WndDDataBrowser = new WndDynamicDataBrowser())
            {
                WndDDataBrowser.CallerID = _PluginConfig.ID;    // Set ID before DynamicDataObjectSamples!!!
                WndDDataBrowser.DynamicDataObjectSamples = _dynamicDataObjectSamples;
                if (WndDDataBrowser.ShowDialog() == DialogResult.OK)
                {
                    txtDestinationTextBox.AppendText(WndDDataBrowser.DynamicDataCode);
                }
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            ClearErrors();
            if (!ValidateConfig(_PluginConfig))
            {
                MessageBox.Show(Resource.TxtThereAreSomeErrors, Resource.TxtTheDummyProgrammerRobot, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            FillConfig(_PluginConfig);

            DialogResult = DialogResult.OK;
        }

        protected void BtnDynDataButton_Click(object sender, EventArgs e)
        {
            Button BtnDynData = (Button)sender;
            TextBox TxtControl = (TextBox)BtnDynData.Parent.Controls[BtnDynData.Name.Replace("BtnDynData", "Txt")];
            ShowDynamicDataBrowserWindow(TxtControl, DynamicDataObjectSamples);
        }
    }
}
