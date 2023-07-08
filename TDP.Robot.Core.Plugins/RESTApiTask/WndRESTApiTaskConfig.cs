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
using TDP.Robot.Plugins.Core.Infrastructure;

namespace TDP.Robot.Plugins.Core.RESTApiTask
{
    public partial class WndRESTApiTaskConfig : WndPluginTaskConfig
    {
        public WndRESTApiTaskConfig()
        {
            InitializeComponent();

            MoveBaseTabs();

            CmbMethod.Items.Add(new ListItem<MethodType>(MethodType.Get, Resource.TxtGet));
            CmbMethod.Items.Add(new ListItem<MethodType>(MethodType.Post, Resource.TxtPost));
            CmbMethod.Items.Add(new ListItem<MethodType>(MethodType.Put, Resource.TxtPut));
            CmbMethod.Items.Add(new ListItem<MethodType>(MethodType.Delete, Resource.TxtDelete));
            
            BtnDynDataParameters.Click += BtnDynDataButton_Click;
            BtnDynDataURL.Click += BtnDynDataButton_Click;
        }

        protected override bool ValidateConfig(IPluginInstanceConfig config)
        {
            base.ValidateConfig(config);

            if (DataValidationHelper.IsEmptyString(TxtURL.Text))
                SetError(TxtURL, Resource.TxtFieldCannotBeEmpty);

            if (CmbMethod.SelectedIndex < 0)
                SetError(CmbMethod, Resource.TxtFieldCannotBeEmpty);

            return GetErrorCount() == 0;
        }

        protected override void FillConfig(IPluginInstanceConfig config)
        {
            RESTApiTaskConfig Config = (RESTApiTaskConfig)config;
            
            Config.URL = TxtURL.Text;
            Config.Method = ((ListItem<MethodType>)CmbMethod.SelectedItem).Value;
            Config.Parameters = TxtParameters.Text;
            Config.ReturnsRecordset = ChkReturnsRecordset.Checked;

            Config.Headers.Clear();
            foreach (RESTApiHeader ApiHeader in LstHeaders.Items)
            {
                Config.Headers.Add(ApiHeader);
            }

            base.FillConfig(config);
        }

        protected override void FillForm(IPluginInstanceConfig config)
        {
            RESTApiTaskConfig Config = (RESTApiTaskConfig)config;

            TxtURL.Text = Config.URL;
            CmbMethod.SetSelectedItem(Config.Method);
            TxtParameters.Text = Config.Parameters;
            ChkReturnsRecordset.Checked = Config.ReturnsRecordset;

            LstHeaders.Items.Clear();
            foreach (RESTApiHeader ApiHeader in Config.Headers)
            {
                LstHeaders.Items.Add(ApiHeader);
            }

            base.FillForm(config);
        }

        private void ManageEditColumn()
        {
            if (LstHeaders.SelectedIndex < 0)
            {
                MessageBox.Show(Resource.TxtYouMustSelectItem, Resource.TxtTheDummyProgrammerRobot, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            RESTApiHeader ApiHeader = (RESTApiHeader)LstHeaders.SelectedItem;

            using (WndHeader F = new WndHeader())
            {
                F.HeaderName = ApiHeader.Name;
                F.HeaderValue = ApiHeader.Value;
                F.DynamicDataObjectSamples = DynamicDataObjectSamples;
                F.CallerID = _PluginConfig.ID;
                if (F.ShowDialog() == DialogResult.OK)
                {
                    ApiHeader.Name = F.HeaderName;
                    ApiHeader.Value = F.HeaderValue;
                    LstHeaders.Items[LstHeaders.SelectedIndex] = ApiHeader;
                }
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            using (WndHeader F = new WndHeader())
            {
                F.DynamicDataObjectSamples = DynamicDataObjectSamples;
                F.CallerID = _PluginConfig.ID;
                if (F.ShowDialog() == DialogResult.OK)
                {
                    RESTApiHeader ApiHeader = new RESTApiHeader(F.HeaderName, F.HeaderValue);
                    LstHeaders.Items.Add(ApiHeader);
                }
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            ManageEditColumn();
        }

        private void LstHeaders_DoubleClick(object sender, EventArgs e)
        {
            ManageEditColumn();
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            if (LstHeaders.SelectedIndex < 0)
            {
                MessageBox.Show(Resource.TxtYouMustSelectItem, Resource.TxtTheDummyProgrammerRobot, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            LstHeaders.Items.RemoveAt(LstHeaders.SelectedIndex);
        }

        private void BtnMoveUp_Click(object sender, EventArgs e)
        {
            if (LstHeaders.SelectedIndex < 0)
            {
                MessageBox.Show(Resource.TxtYouMustSelectItem, Resource.TxtTheDummyProgrammerRobot, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (LstHeaders.SelectedIndex == 0)
                return;

            int SelectedIndex = LstHeaders.SelectedIndex;
            RESTApiHeader ApiHeader = (RESTApiHeader)LstHeaders.Items[SelectedIndex - 1];

            LstHeaders.Items.RemoveAt(SelectedIndex - 1);
            LstHeaders.Items.Insert(SelectedIndex, ApiHeader);
        }

        private void BtnMoveDown_Click(object sender, EventArgs e)
        {
            if (LstHeaders.SelectedIndex < 0)
            {
                MessageBox.Show(Resource.TxtYouMustSelectItem, Resource.TxtTheDummyProgrammerRobot, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (LstHeaders.SelectedIndex == (LstHeaders.Items.Count - 1))
                return;

            int SelectedIndex = LstHeaders.SelectedIndex;
            RESTApiHeader ApiHeader = (RESTApiHeader)LstHeaders.Items[SelectedIndex];

            LstHeaders.Items.RemoveAt(SelectedIndex);
            LstHeaders.Items.Insert(SelectedIndex + 1, ApiHeader);
            LstHeaders.SelectedIndex = SelectedIndex + 1;
        }
    }
}
