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
using System.Windows.Forms;
using TDP.BaseServices.Infrastructure.DataValidation;
using TDP.Robot.Core;

namespace TDP.Robot.Plugins.Core.SqlServerCommandTask
{
    public partial class WndSqlServerCommandTaskConfig : WndPluginTaskConfig
    {
        public WndSqlServerCommandTaskConfig()
        {
            InitializeComponent();

            MoveBaseTabs();
        }

        private void ManageEditColumn()
        {
            if (LstParameters.SelectedIndex < 0)
            {
                MessageBox.Show(Resource.TxtYouMustSelectItem, Resource.TxtTheDummyProgrammerRobot, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SqlServerParamDefinition ParamDef = (SqlServerParamDefinition)LstParameters.SelectedItem;

            using (WndParameter F = new WndParameter())
            {
                F.ParamName = ParamDef.Name;
                F.Value = ParamDef.Value;
                F.Type = ParamDef.Type;
                F.Length = ParamDef.Length;
                F.Precision = ParamDef.Precision;
                F.DynamicDataObjectSamples = DynamicDataObjectSamples;
                F.CallerID = _PluginConfig.ID;
                if (F.ShowDialog() == DialogResult.OK)
                {
                    ParamDef.Name = F.ParamName;
                    ParamDef.Value = F.Value;
                    ParamDef.Type = F.Type;
                    ParamDef.Length = F.Length;
                    ParamDef.Precision = F.Precision;
                    LstParameters.Items[LstParameters.SelectedIndex] = ParamDef;
                }
            }
        }

        protected override bool ValidateConfig(IPluginInstanceConfig config)
        {
            base.ValidateConfig(config);

            if (DataValidationHelper.IsEmptyString(TxtQuery.Text))
                SetError(TxtQuery, Resource.TxtFieldCannotBeEmpty);

            if (!RdbText.Checked && !RdbStoredProcedure.Checked)
                SetError(LblType, Resource.TxtFieldCannotBeEmpty);

            if (DataValidationHelper.IsEmptyString(TxtServer.Text))
                SetError(TxtServer, Resource.TxtFieldCannotBeEmpty);

            if (DataValidationHelper.IsEmptyString(TxtDatabase.Text))
                SetError(TxtDatabase, Resource.TxtFieldCannotBeEmpty);

            if (DataValidationHelper.IsEmptyString(TxtUserName.Text))
                SetError(TxtUserName, Resource.TxtFieldCannotBeEmpty);

            if (DataValidationHelper.IsEmptyString(TxtPassword.Text))
                SetError(TxtPassword, Resource.TxtFieldCannotBeEmpty);

            if (DataValidationHelper.IsEmptyString(TxtCommandTimeout.Text))
                SetError(TxtCommandTimeout, Resource.TxtFieldCannotBeEmpty);

            return GetErrorCount() == 0;
        }

        protected override void FillConfig(IPluginInstanceConfig config)
        {
            base.FillConfig(config);

            SqlServerCommandTaskConfig Config = (SqlServerCommandTaskConfig)config;

            Config.Query = TxtQuery.Text;

            if (RdbText.Checked)
                Config.Type = QueryTaskType.Text;
            else
                Config.Type = QueryTaskType.StoredProcedure;

            Config.ParamsDefinition.Clear();
            foreach (SqlServerParamDefinition ParamDef in LstParameters.Items)
            {
                Config.ParamsDefinition.Add(ParamDef);
            }
            Config.ReturnsRecordset = ChkCommandReturnsRecordset.Checked;
            Config.Server = TxtServer.Text;
            Config.Database = TxtDatabase.Text;
            Config.Username = TxtUserName.Text;
            Config.Password = TxtPassword.Text;
            Config.ConnectionStringOptions = TxtConnectionString.Text;
            Config.CommandTimeout = TxtCommandTimeout.Text;
        }

        protected override void FillForm(IPluginInstanceConfig config)
        {
            base.FillForm(config);

            SqlServerCommandTaskConfig Config = (SqlServerCommandTaskConfig)config;

            TxtQuery.Text = Config.Query;

            RdbText.Checked = (Config.Type == QueryTaskType.Text);
            RdbStoredProcedure.Checked = (Config.Type == QueryTaskType.StoredProcedure);


            LstParameters.Items.Clear();
            foreach (SqlServerParamDefinition ParamDef in Config.ParamsDefinition)
            {
                LstParameters.Items.Add(ParamDef);
            }
            ChkCommandReturnsRecordset.Checked = Config.ReturnsRecordset;
            TxtServer.Text = Config.Server;
            TxtDatabase.Text = Config.Database;
            TxtUserName.Text = Config.Username;
            TxtPassword.Text = Config.Password;
            TxtConnectionString.Text = Config.ConnectionStringOptions;
            TxtCommandTimeout.Text = Config.CommandTimeout;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            using (WndParameter F = new WndParameter())
            {
                F.DynamicDataObjectSamples = DynamicDataObjectSamples;
                F.CallerID = _PluginConfig.ID;
                if (F.ShowDialog() == DialogResult.OK)
                {
                    SqlServerParamDefinition ParamDef = new SqlServerParamDefinition(F.ParamName, F.Value, F.Type, F.Length, F.Precision);
                    LstParameters.Items.Add(ParamDef);
                }
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            ManageEditColumn();
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            if (LstParameters.SelectedIndex < 0)
            {
                MessageBox.Show(Resource.TxtYouMustSelectItem, Resource.TxtTheDummyProgrammerRobot, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            LstParameters.Items.RemoveAt(LstParameters.SelectedIndex);
        }

        private void LstParameters_DoubleClick(object sender, EventArgs e)
        {
            ManageEditColumn();
        }
    }
}
