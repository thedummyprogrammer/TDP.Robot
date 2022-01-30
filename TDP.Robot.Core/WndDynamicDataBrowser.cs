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
    public partial class WndDynamicDataBrowser : Form
    {
        public int CallerID { get; set; }

        protected List<DynamicDataObjectSamples> _dynamicDataObjectSamples;

        public List<DynamicDataObjectSamples> DynamicDataObjectSamples
        {
            set
            {
                _dynamicDataObjectSamples = value;

                LsvObjects.Items.Clear();
                foreach (DynamicDataObjectSamples Object in _dynamicDataObjectSamples)
                {
                    if (Object.ID == CallerID)
                        continue;

                    ListViewItem LI = new ListViewItem(Object.Description);
                    LI.SubItems.Add(Object.ID.ToString());
                    LI.SubItems.Add(Object.Type.ToString());
                    LI.Tag = Object;
                    LsvObjects.Items.Add(LI);
                }
            }
        }

        public string DynamicDataCode { get; private set; }

        public WndDynamicDataBrowser()
        {
            InitializeComponent();
        }

        private void LsvObjects_Click(object sender, EventArgs e)
        {

        }

        private void LsvObjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LsvObjects.SelectedItems.Count > 0)
            {
                ListViewItem LI = LsvObjects.SelectedItems[0];
                DynamicDataObjectSamples Obj = (DynamicDataObjectSamples)LI.Tag;

                LsvDynData.Items.Clear();
                foreach (DynamicDataSample DynDataSample in Obj.DynamicDataSampleList)
                {
                    ListViewItem LIDynData = new ListViewItem(DynDataSample.Description);
                    LIDynData.Tag = DynDataSample;
                    LIDynData.SubItems.Add(DynDataSample.Example);
                    LsvDynData.Items.Add(LIDynData);
                }
            }
        }

        private void SelectDynamicData()
        {
            if (LsvObjects.SelectedItems.Count == 0 || LsvDynData.SelectedItems.Count == 0)
            {
                MessageBox.Show(Resource.TxtYouMustSelectADynamicData, Resource.TxtTheDummyProgrammerRobot, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ListViewItem LIObject = LsvObjects.SelectedItems[0];
            DynamicDataObjectSamples Obj = (DynamicDataObjectSamples)LIObject.Tag;
            ListViewItem LIDynData = LsvDynData.SelectedItems[0];
            DynamicDataSample DynDataSample = (DynamicDataSample)LIDynData.Tag;

            DynamicDataCode = "{Object[" + Obj.ID.ToString() + "]." + DynDataSample.InternalName;

            if (DynDataSample.IsRecordset)
                DynamicDataCode += "['SetYourFieldName']";

            DynamicDataCode += "}";

            DialogResult = DialogResult.OK;
        }

        private void LsvDynData_DoubleClick(object sender, EventArgs e)
        {
            SelectDynamicData();
        }

        private void BtnSelect_Click(object sender, EventArgs e)
        {
            SelectDynamicData();
        }
    }
}
