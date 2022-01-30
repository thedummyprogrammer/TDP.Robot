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
using System.Windows.Forms;
using TDP.Robot.Core.DynamicData;

namespace TDP.Robot.Core
{
    public partial class WndPluginDetailConfigBase : Form
    {
        protected void ShowDynamicDataBrowserWindow(TextBox txtDestinationTextBox, List<DynamicDataObjectSamples> _dynamicDataObjectSamples)
        {
            using (WndDynamicDataBrowser WndDDataBrowser = new WndDynamicDataBrowser())
            {
                WndDDataBrowser.CallerID = CallerID;    // Set ID before DynamicDataObjectSamples!!!
                WndDDataBrowser.DynamicDataObjectSamples = _dynamicDataObjectSamples;
                if (WndDDataBrowser.ShowDialog() == DialogResult.OK)
                {
                    txtDestinationTextBox.AppendText(WndDDataBrowser.DynamicDataCode);
                }
            }
        }

        public List<DynamicDataObjectSamples> DynamicDataObjectSamples { get; set; }
        public int CallerID { get; set; }

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

        public WndPluginDetailConfigBase()
        {
            InitializeComponent();
        }

        protected void BtnDynDataButton_Click(object sender, EventArgs e)
        {
            Button BtnDynData = (Button)sender;
            TextBox TxtControl = (TextBox)BtnDynData.Parent.Controls[BtnDynData.Name.Replace("BtnDynData", "Txt")];
            ShowDynamicDataBrowserWindow(TxtControl, DynamicDataObjectSamples);
        }
    }
}
