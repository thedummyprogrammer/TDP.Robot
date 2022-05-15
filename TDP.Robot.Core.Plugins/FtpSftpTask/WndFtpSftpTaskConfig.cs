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
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TDP.BaseServices.Infrastructure.DataValidation;
using TDP.Robot.Core;
using TDP.Robot.Plugins.Core.Infrastructure;

namespace TDP.Robot.Plugins.Core.FtpSftpTask
{
    public partial class WndFtpSftpTaskConfig : WndPluginTaskConfig
    {
        private const int _PortMaxLength = 5;
        private const int _PortMinValue = 0;
        private const int _PortMaxValue = 65535;

        public WndFtpSftpTaskConfig()
        {
            InitializeComponent();

            MoveBaseTabs();

            CmbProtocol.Items.Add(new ListItem<ProtocolEnum>(ProtocolEnum.FTP, Resource.TxtFTPFileTransferProtocol));
            CmbProtocol.Items.Add(new ListItem<ProtocolEnum>(ProtocolEnum.SFTP, Resource.TxtSFTPSSHFileTransferProtocol));
            CmbProtocol.SelectedIndex = 0;

            CmbCommand.Items.Add(new ListItem<CommandEnum>(CommandEnum.Copy, Resource.TxtCopy));
            CmbCommand.Items.Add(new ListItem<CommandEnum>(CommandEnum.Delete, Resource.TxtDelete));
            CmbCommand.SelectedIndex = 0;
        }

        private void ManageEditCopyPath()
        {
            if (LstCopyPaths.SelectedIndex < 0)
            {
                MessageBox.Show(Resource.TxtYouMustSelectItem, Resource.TxtTheDummyProgrammerRobot, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            FtpSftpCopyItem CopyItem = (FtpSftpCopyItem)LstCopyPaths.SelectedItem;

            using (WndCopyItem F = new WndCopyItem())
            {
                F.LocalToRemote = CopyItem.LocalToRemote;
                F.LocalPath = CopyItem.LocalPath;
                F.RemotePath = CopyItem.RemotePath;
                F.OverwriteFileIfExists = CopyItem.OverwriteFileIfExists;
                F.RecursivelyCopyDirectories = CopyItem.RecursivelyCopyDirectories;
                F.DynamicDataObjectSamples = DynamicDataObjectSamples;
                F.CallerID = _PluginConfig.ID;
                if (F.ShowDialog() == DialogResult.OK)
                {
                    CopyItem.LocalToRemote = F.LocalToRemote;
                    CopyItem.LocalPath = F.LocalPath;
                    CopyItem.RemotePath = F.RemotePath;
                    CopyItem.OverwriteFileIfExists = F.OverwriteFileIfExists;
                    CopyItem.RecursivelyCopyDirectories = F.RecursivelyCopyDirectories;
                    LstCopyPaths.Items[LstCopyPaths.SelectedIndex] = CopyItem;
                }
            }
        }

        private void ManageEditDeletePath()
        {
            if (LstDeletePaths.SelectedIndex < 0)
            {
                MessageBox.Show(Resource.TxtYouMustSelectItem, Resource.TxtTheDummyProgrammerRobot, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            FtpSftpDeleteItem DeleteItem = (FtpSftpDeleteItem)LstDeletePaths.SelectedItem;

            using (WndDeleteItem F = new WndDeleteItem())
            {
                F.RemotePath = DeleteItem.RemotePath;
                F.DynamicDataObjectSamples = DynamicDataObjectSamples;
                F.CallerID = _PluginConfig.ID;
                if (F.ShowDialog() == DialogResult.OK)
                {
                    DeleteItem.RemotePath = F.RemotePath;
                    LstDeletePaths.Items[LstDeletePaths.SelectedIndex] = DeleteItem;
                }
            }
        }

        protected override void FillConfig(IPluginInstanceConfig config)
        {
            base.FillConfig(config);

            FtpSftpTaskConfig Config = (FtpSftpTaskConfig)config;

            Config.Protocol = ((ListItem<ProtocolEnum>)CmbProtocol.SelectedItem).Value;
            Config.Host = TxtHost.Text;
            Config.Port = TxtPort.Text;
            Config.Username = TxtUsername.Text;
            Config.Password = TxtPassword.Text;
            Config.Command = ((ListItem<CommandEnum>)CmbCommand.SelectedItem).Value;

            Config.CopyItems.Clear();
            foreach (FtpSftpCopyItem CopyItem in LstCopyPaths.Items)
            {
                Config.CopyItems.Add(CopyItem);
            }

            Config.DeleteItems.Clear();
            foreach (FtpSftpDeleteItem DeleteItem in LstDeletePaths.Items)
            {
                Config.DeleteItems.Add(DeleteItem);
            }


        }

        protected override void FillForm(IPluginInstanceConfig config)
        {
            base.FillForm(config);

            FtpSftpTaskConfig Config = (FtpSftpTaskConfig)config;

            CmbProtocol.SetSelectedItem(Config.Protocol);
            TxtHost.Text = Config.Host;
            TxtPort.Text = Config.Port;
            TxtUsername.Text = Config.Username;
            TxtPassword.Text = Config.Password;
            CmbCommand.SetSelectedItem(Config.Command);

            LstCopyPaths.Items.Clear();
            foreach (FtpSftpCopyItem CopyItem in Config.CopyItems)
            {
                LstCopyPaths.Items.Add(CopyItem);
            }

            LstDeletePaths.Items.Clear();
            foreach (FtpSftpDeleteItem DeleteItem in Config.DeleteItems)
            {
                LstDeletePaths.Items.Add(DeleteItem);
            }
        }

        protected override bool ValidateConfig(IPluginInstanceConfig config)
        {
            if (CmbProtocol.SelectedIndex < 0)
                SetError(CmbProtocol, Resource.TxtFieldCannotBeEmpty);

            if (DataValidationHelper.IsEmptyString(TxtHost.Text))
                SetError(TxtHost, Resource.TxtFieldCannotBeEmpty);

            if (DataValidationHelper.IsEmptyString(TxtPort.Text))
                SetError(TxtPort, Resource.TxtFieldCannotBeEmpty);
            else if (!DataValidationHelper.IsInteger(TxtPort.Text, _PortMaxLength, _PortMinValue, _PortMaxValue))
                SetError(TxtPort, string.Format(Resource.TxtMustBeANumberBetweenXAndY, _PortMinValue, _PortMaxValue));

            if (DataValidationHelper.IsEmptyString(TxtUsername.Text))
                SetError(TxtUsername, Resource.TxtFieldCannotBeEmpty);

            if (DataValidationHelper.IsEmptyString(TxtPassword.Text))
                SetError(TxtPassword, Resource.TxtFieldCannotBeEmpty);

            if (CmbCommand.SelectedIndex < 0)
                SetError(CmbCommand, Resource.TxtFieldCannotBeEmpty);

            if (GrpCopyMove.Visible)
            {
                if (LstCopyPaths.Items.Count == 0)
                    SetError(LstCopyPaths, Resource.TxtFieldCannotBeEmpty);
            }
            else if (GrpDelete.Visible)
            {
                if (LstDeletePaths.Items.Count == 0)
                    SetError(LstDeletePaths, Resource.TxtFieldCannotBeEmpty);
            }

            return GetErrorCount() == 0;
        }

        private void CmbCommand_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListItem<CommandEnum> Item = (ListItem<CommandEnum>)CmbCommand.SelectedItem;

            switch (Item.Value)
            {
                case CommandEnum.Copy:
                    GrpCopyMove.Visible = true;
                    GrpDelete.Visible = false;
                    break;

                case CommandEnum.Delete:
                    GrpCopyMove.Visible = false;
                    GrpDelete.Visible = true;
                    break;
            }
        }

        private void BtnAddCopyPath_Click(object sender, EventArgs e)
        {
            using (WndCopyItem F = new WndCopyItem())
            {
                F.DynamicDataObjectSamples = DynamicDataObjectSamples;
                F.CallerID = _PluginConfig.ID;
                if (F.ShowDialog() == DialogResult.OK)
                {
                    FtpSftpCopyItem CopyItem = new FtpSftpCopyItem(F.LocalToRemote, F.LocalPath, F.RemotePath, F.OverwriteFileIfExists, F.RecursivelyCopyDirectories);
                    LstCopyPaths.Items.Add(CopyItem);
                }
            }
        }

        private void BtnEditCopyPath_Click(object sender, EventArgs e)
        {
            ManageEditCopyPath();
        }

        private void LstCopyPaths_DoubleClick(object sender, EventArgs e)
        {
            ManageEditCopyPath();
        }

        private void BtnRemoveCopyPath_Click(object sender, EventArgs e)
        {
            if (LstCopyPaths.SelectedIndex < 0)
            {
                MessageBox.Show(Resource.TxtYouMustSelectItem, Resource.TxtTheDummyProgrammerRobot, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            LstCopyPaths.Items.RemoveAt(LstCopyPaths.SelectedIndex);
        }

        private void BtnAddDeletePath_Click(object sender, EventArgs e)
        {
            using (WndDeleteItem F = new WndDeleteItem())
            {
                F.DynamicDataObjectSamples = DynamicDataObjectSamples;
                F.CallerID = _PluginConfig.ID;
                if (F.ShowDialog() == DialogResult.OK)
                {
                    FtpSftpDeleteItem DeleteItem = new FtpSftpDeleteItem(F.RemotePath);
                    LstDeletePaths.Items.Add(DeleteItem);
                }
            }
        }

        private void BtnEditDeletePath_Click(object sender, EventArgs e)
        {
            ManageEditDeletePath();
        }

        private void BtnRemoveDeletePath_Click(object sender, EventArgs e)
        {
            if (LstDeletePaths.SelectedIndex < 0)
            {
                MessageBox.Show(Resource.TxtYouMustSelectItem, Resource.TxtTheDummyProgrammerRobot, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            LstDeletePaths.Items.RemoveAt(LstDeletePaths.SelectedIndex);
        }

        private void LstDeletePaths_DoubleClick(object sender, EventArgs e)
        {
            ManageEditDeletePath();
        }
    }
}
