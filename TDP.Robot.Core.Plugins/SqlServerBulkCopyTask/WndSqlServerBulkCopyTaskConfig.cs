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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TDP.BaseServices.Infrastructure.DataValidation;
using TDP.Robot.Core;

namespace TDP.Robot.Plugins.Core.SqlServerBulkCopyTask
{
    public partial class WndSqlServerBulkCopyTaskConfig : WndPluginTaskConfig
    {
        private const int _MaxTimeoutLength = 10;

        public WndSqlServerBulkCopyTaskConfig()
        {
            InitializeComponent();

            MoveBaseTabs();

            BtnDynDataSourceRecordset.Click += BtnDynDataButton_Click;
            BtnDynDataDestinationTable.Click += BtnDynDataButton_Click;
        }

        protected override void FillConfig(IPluginInstanceConfig config)
        {
            base.FillConfig(config);

            SqlServerBulkCopyTaskConfig Config = (SqlServerBulkCopyTaskConfig)config;

            Config.SourceRecordset = TxtSourceRecordset.Text;
            Config.DestinationTable = TxtDestinationTable.Text;

            Config.Server = TxtServer.Text;
            Config.Database = TxtDatabase.Text;
            Config.Username = TxtUserName.Text;
            Config.Password = TxtPassword.Text;
            Config.ConnectionStringOptions = TxtConnectionStringOptions.Text;
        }

        protected override void FillForm(IPluginInstanceConfig config)
        {
            base.FillForm(config);

            SqlServerBulkCopyTaskConfig Config = (SqlServerBulkCopyTaskConfig)config;

            TxtSourceRecordset.Text = Config.SourceRecordset;
            TxtDestinationTable.Text = Config.DestinationTable;

            TxtServer.Text = Config.Server;
            TxtDatabase.Text = Config.Database;
            TxtUserName.Text = Config.Username;
            TxtPassword.Text = Config.Password;
            TxtConnectionStringOptions.Text = Config.ConnectionStringOptions;
        }

        protected override bool ValidateConfig(IPluginInstanceConfig config)
        {
            base.ValidateConfig(config);

            if (DataValidationHelper.IsEmptyString(TxtSourceRecordset.Text))
                SetError(TxtSourceRecordset, Resource.TxtFieldCannotBeEmpty);

            if (DataValidationHelper.IsEmptyString(TxtDestinationTable.Text))
                SetError(TxtDestinationTable, Resource.TxtFieldCannotBeEmpty);

            if (DataValidationHelper.IsEmptyString(TxtServer.Text))
                SetError(TxtServer, Resource.TxtFieldCannotBeEmpty);

            if (DataValidationHelper.IsEmptyString(TxtUserName.Text))
                SetError(TxtUserName, Resource.TxtFieldCannotBeEmpty);

            if (DataValidationHelper.IsEmptyString(TxtPassword.Text))
                SetError(TxtPassword, Resource.TxtFieldCannotBeEmpty);

            if (!DataValidationHelper.IsEmptyString(TxtCommandTimeout.Text)
                && DataValidationHelper.IsInteger(TxtCommandTimeout.Text, _MaxTimeoutLength, int.MinValue, int.MaxValue))
                SetError(TxtCommandTimeout, Resource.TxtFieldNotContainAValidInteger);


            return GetErrorCount() == 0;
        }
    }
}
