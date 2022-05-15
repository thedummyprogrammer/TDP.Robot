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
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TDP.BaseServices.Infrastructure.DataValidation;
using TDP.Robot.Core;
using TDP.Robot.Plugins.Core.Infrastructure;

namespace TDP.Robot.Plugins.Core.SqlServerBackupTask
{
    public partial class WndSqlServerBackupConfig : WndPluginTaskConfig
    {
        public WndSqlServerBackupConfig()
        {
            InitializeComponent();

            MoveBaseTabs();

            CmbBackupType.Items.Add(new ListItem<BackupTypeEnum>(BackupTypeEnum.Full, Resource.TxtFullBackup));
            CmbBackupType.Items.Add(new ListItem<BackupTypeEnum>(BackupTypeEnum.TransactionLog, Resource.TxtTransactionLog));
            CmbBackupType.SelectedIndex = 0;

            CmbCompression.Items.Add(new ListItem<UseCompressionEnum>(UseCompressionEnum.UseServerDefault, Resource.TxtUseServerDefault));
            CmbCompression.Items.Add(new ListItem<UseCompressionEnum>(UseCompressionEnum.CompressBackup, Resource.TxtCompressBackup));
            CmbCompression.Items.Add(new ListItem<UseCompressionEnum>(UseCompressionEnum.DoNotCompressBackup, Resource.TxtDoNotCompressBackup));
            CmbCompression.SelectedIndex = 0;

            BtnDynDataDestPath.Click += BtnDynDataButton_Click;
            BtnDynDataFileNameTemplate.Click += BtnDynDataButton_Click;
        }

        private bool FillDatabasesList()
        {
            if (DataValidationHelper.IsEmptyString(TxtServer.Text) || DataValidationHelper.IsEmptyString(TxtUserName.Text) || DataValidationHelper.IsEmptyString(TxtPassword.Text))
            {
                MessageBox.Show(Resource.TxtYouMustEnterDatabaseCredentials, Resource.TxtTheDummyProgrammerRobot, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            try
            {
                string ConnectionString = $"Server={TxtServer.Text};User Id={TxtUserName.Text};Password={TxtPassword.Text};{TxtConnectionStringOptions.Text}";
                List<string> DatabaseList = SqlServerBackupTaskCommon.GetDatabaseList(ConnectionString);
                ChkDatabaseList.Items.Clear();
                foreach (string DbName in DatabaseList)
                {
                    ChkDatabaseList.Items.Add(DbName);
                }
            }
            catch
            {
                MessageBox.Show(Resource.TxtUnableToGetDatabaseList, Resource.TxtTheDummyProgrammerRobot, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        protected override void FillConfig(IPluginInstanceConfig config)
        {
            base.FillConfig(config);

            SqlServerBackupTaskConfig Config = (SqlServerBackupTaskConfig)config;

            Config.Server = TxtServer.Text;
            Config.Username = TxtUserName.Text;
            Config.Password = TxtPassword.Text;
            Config.ConnectionStringOptions = TxtConnectionStringOptions.Text;

            Config.BackupType = ((ListItem<BackupTypeEnum>)CmbBackupType.SelectedItem).Value;

            if (RdbAllDatabases.Checked)
                Config.DatabasesToBackup = DatabasesToBackupEnum.AllDatabases;
            else if (RdbAllUserDatabases.Checked)
                Config.DatabasesToBackup = DatabasesToBackupEnum.AllUserDatabases;
            else
                Config.DatabasesToBackup = DatabasesToBackupEnum.SelectedDatabases;

            Config.DatabasesList.Clear();
            foreach (string DbName in ChkDatabaseList.Items)
            {
                Config.DatabasesList.Add(DbName);
            }

            Config.SelectedDatabases.Clear();
            foreach (string DbName in ChkDatabaseList.CheckedItems)
            {
                Config.SelectedDatabases.Add(DbName);
            }

            Config.DestinationPath = TxtDestPath.Text;
            Config.FileNameTemplate = TxtFileNameTemplate.Text;

            if (RdbIfExistsAppend.Checked)
                Config.OverwriteIfExists = false;
            else
                Config.OverwriteIfExists = true;

            Config.VerifyBackup = ChkVerifyBackup.Checked;
            Config.PerformChecksum = ChkPerformChecksum.Checked;
            Config.ContinueOnError = ChkContinueOnError.Checked;

            Config.UseCompression = ((ListItem<UseCompressionEnum>)CmbCompression.SelectedItem).Value;
        }

        protected override void FillForm(IPluginInstanceConfig config)
        {
            base.FillForm(config);

            SqlServerBackupTaskConfig Config = (SqlServerBackupTaskConfig)config;

            TxtServer.Text = Config.Server;
            TxtUserName.Text = Config.Username;
            TxtPassword.Text = Config.Password;
            TxtConnectionStringOptions.Text = Config.ConnectionStringOptions;

            CmbBackupType.SelectedItem = Config.BackupType;

            switch (Config.DatabasesToBackup)
            {
                case DatabasesToBackupEnum.AllDatabases:
                    RdbAllDatabases.Checked = true;
                    ChkDatabaseList.Enabled = false;
                    break;
                
                case DatabasesToBackupEnum.AllUserDatabases:
                    RdbAllUserDatabases.Checked = true;
                    ChkDatabaseList.Enabled = false;
                    break;

                case DatabasesToBackupEnum.SelectedDatabases:
                    RdbSelectedDatabases.Checked = true;
                    ChkDatabaseList.Enabled = true;
                    break;
            }

            // Try to connect to get database list, if fail fill the checkbox list with the saved list (if any)
            bool FillDatabasesListSucceded = false;
            if (!DataValidationHelper.IsEmptyString(TxtConnectionStringOptions.Text))
                FillDatabasesListSucceded = FillDatabasesList();

            if (!FillDatabasesListSucceded)
            {
                foreach (string DbName in Config.DatabasesList)
                {
                    ChkDatabaseList.Items.Add(DbName);
                }
            }

            for (int i = 0; i < ChkDatabaseList.Items.Count; i++)
            {
                if (Config.SelectedDatabases.Contains(ChkDatabaseList.Items[i].ToString()))
                    ChkDatabaseList.SetItemChecked(i, true);
            }

            TxtDestPath.Text = Config.DestinationPath;
            TxtFileNameTemplate.Text = Config.FileNameTemplate;

            RdbIfExistsAppend.Checked = !Config.OverwriteIfExists;
            RdbIfExistsOverwrite.Checked = Config.OverwriteIfExists;

            ChkVerifyBackup.Checked = Config.VerifyBackup;
            ChkPerformChecksum.Checked = Config.PerformChecksum;
            ChkContinueOnError.Checked = Config.ContinueOnError;

            CmbCompression.SelectedItem = Config.UseCompression;
        }

        protected override bool ValidateConfig(IPluginInstanceConfig config)
        {
            base.ValidateConfig(config);

            if (DataValidationHelper.IsEmptyString(TxtServer.Text))
                SetError(TxtServer, Resource.TxtFieldCannotBeEmpty);

            if (DataValidationHelper.IsEmptyString(TxtUserName.Text))
                SetError(TxtUserName, Resource.TxtFieldCannotBeEmpty);

            if (DataValidationHelper.IsEmptyString(TxtPassword.Text))
                SetError(TxtPassword, Resource.TxtFieldCannotBeEmpty);

            if (RdbSelectedDatabases.Checked && ChkDatabaseList.CheckedItems.Count == 0)
                SetError(ChkDatabaseList, Resource.TxtYouMustSelectADatabase);

            if (DataValidationHelper.IsEmptyString(TxtDestPath.Text))
                SetError(TxtDestPath, Resource.TxtFieldCannotBeEmpty);

            if (CmbCompression.SelectedIndex < 0)
                SetError(CmbCompression, Resource.TxtFieldCannotBeEmpty);

            return GetErrorCount() == 0;
        }

        private void BtnTestRefresh_Click(object sender, EventArgs e)
        {
            FillDatabasesList();
        }

        private void RdbAllDatabases_CheckedChanged(object sender, EventArgs e)
        {
            ChkDatabaseList.Enabled = !RdbAllDatabases.Checked;
        }

        private void RdbAllUserDatabases_CheckedChanged(object sender, EventArgs e)
        {
            ChkDatabaseList.Enabled = !RdbAllUserDatabases.Checked;
        }

        private void RdbSelectedDatabases_CheckedChanged(object sender, EventArgs e)
        {
            ChkDatabaseList.Enabled = RdbSelectedDatabases.Checked;
        }

        private void TxtBrowseDestPath_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog F = new FolderBrowserDialog())
            {
                if (F.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    TxtDestPath.Text = F.SelectedPath;
                }
            }
        }
    }
}
