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
using TDP.Robot.Core.DynamicData;

namespace TDP.Robot.Plugins.Core.SendEMailTask
{
    public partial class WndSendEMailTaskConfig : WndPluginTaskConfig
    {
        public WndSendEMailTaskConfig()
        {
            InitializeComponent();

            MoveBaseTabs();

            BtnDynDataSubject.Click += BtnDynDataButton_Click;
            BtnDynDataMessage.Click += BtnDynDataButton_Click;
            BtnDynDataSender.Click += BtnDynDataButton_Click;
            BtnDynDataSMTPServer.Click += BtnDynDataButton_Click;
            BtnDynDataPort.Click += BtnDynDataButton_Click;
            BtnDynDataUserName.Click += BtnDynDataButton_Click;
            BtnDynDataPassword.Click += BtnDynDataButton_Click;
        }

        protected override bool ValidateConfig(IPluginInstanceConfig config)
        {
            base.ValidateConfig(config);

            if (DataValidationHelper.IsEmptyString(TxtName.Text))
                SetError(TxtName, Resource.TxtFieldCannotBeEmpty);

            if (DataValidationHelper.IsEmptyString(TxtSubject.Text))
                SetError(TxtSubject, Resource.TxtFieldCannotBeEmpty);

            if (DataValidationHelper.IsEmptyString(TxtMessage.Text))
                SetError(TxtMessage, Resource.TxtFieldCannotBeEmpty);

            if (DataValidationHelper.IsEmptyString(TxtSender.Text))
                SetError(TxtSender, Resource.TxtFieldCannotBeEmpty);

            if (DataValidationHelper.IsEmptyString(TxtSMTPServer.Text))
                SetError(TxtSMTPServer, Resource.TxtFieldCannotBeEmpty);

            if (DataValidationHelper.IsEmptyString(TxtPort.Text))
                TxtPort.Text = SendEMailTaskConfig.DefaultSMTPPort.ToString();
            else if (!DynamicDataParser.ContainsDynamicData(TxtPort.Text)
                    && !DataValidationHelper.IsInteger(TxtPort.Text, Constants.TcpPortMaxLength, Constants.TcpPortNumberMin, Constants.TcpPortNumberMax))
                SetError(TxtPort, string.Format(Resource.TxtMustBeANumberBetweenXAndY, Constants.TcpPortNumberMin, Constants.TcpPortNumberMax));

            if (ChkAuthenticate.Checked)
            {
                if (DataValidationHelper.IsEmptyString(TxtUserName.Text))
                    SetError(TxtUserName, Resource.TxtFieldCannotBeEmpty);

                if (DataValidationHelper.IsEmptyString(TxtPassword.Text))
                    SetError(TxtPassword, Resource.TxtFieldCannotBeEmpty);

                if (DataValidationHelper.IsEmptyString(TxtConfirmPassword.Text))
                    SetError(TxtConfirmPassword, Resource.TxtFieldCannotBeEmpty);

                if (!DataValidationHelper.IsEmptyString(TxtPassword.Text)
                    && !DataValidationHelper.IsEmptyString(TxtConfirmPassword.Text)
                    && TxtPassword.Text != TxtConfirmPassword.Text)
                {
                    SetError(TxtPassword, Resource.TxtPasswordAndConfirmDoNotMatch);
                }
            }

            return GetErrorCount() == 0;
        }

        protected override void FillConfig(IPluginInstanceConfig config)
        {
            base.FillConfig(config);

            SendEMailTaskConfig Config = (SendEMailTaskConfig)config;

            Config.Recipients.Clear();
            foreach (string Recipient in LstRecipients.Items)
            {
                Config.Recipients.Add(Recipient);
            }

            Config.CC.Clear();
            foreach (string CC in LstCC.Items)
            {
                Config.CC.Add(CC);
            }

            Config.Subject = TxtSubject.Text;
            Config.Message = TxtMessage.Text;

            Config.Attachments.Clear();
            foreach (string Attachment in LstAttachments.Items)
            {
                Config.Attachments.Add(Attachment);
            }

            Config.Sender = TxtSender.Text;
            Config.SMTPServer = TxtSMTPServer.Text;
            Config.Port = TxtPort.Text;
            Config.UseSSL = ChkUseSSL.Checked;

            Config.Authenticate = ChkAuthenticate.Checked;
            Config.Username = TxtUserName.Text;
            Config.Password = TxtPassword.Text;
        }

        protected override void FillForm(IPluginInstanceConfig config)
        {
            base.FillForm(config);

            SendEMailTaskConfig Config = (SendEMailTaskConfig)config;

            LstRecipients.Items.Clear();
            foreach (string Recipient in Config.Recipients)
            {
                LstRecipients.Items.Add(Recipient);
            }

            LstCC.Items.Clear();
            foreach (string CC in Config.CC)
            {
                LstCC.Items.Add(CC);
            }

            TxtSubject.Text = Config.Subject;
            TxtMessage.Text = Config.Message;

            LstAttachments.Items.Clear();
            foreach (string Attachment in Config.Attachments)
            {
                LstAttachments.Items.Add(Attachment);
            }

            TxtSender.Text = Config.Sender;
            TxtSMTPServer.Text = Config.SMTPServer;
            TxtPort.Text = Config.Port.ToString();
            ChkUseSSL.Checked = Config.UseSSL;
            
            ChkAuthenticate.Checked = Config.Authenticate;
            TxtUserName.Text = Config.Username;
            TxtPassword.Text = Config.Password;
            TxtConfirmPassword.Text = Config.Password;
        }

        private void BtnAddRecipient_Click(object sender, EventArgs e)
        {
            using (WndEMail F = new WndEMail())
            {
                F.DynamicDataObjectSamples = DynamicDataObjectSamples;
                F.CallerID = _PluginConfig.ID;
                if (F.ShowDialog() == DialogResult.OK)
                    LstRecipients.Items.Add(F.EMail);
            }
        }

        private void BtnRemoveRecipient_Click(object sender, EventArgs e)
        {
            if (LstRecipients.SelectedIndex < 0)
            {
                MessageBox.Show(Resource.TxtYouMustSelectItem, Resource.TxtTheDummyProgrammerRobot, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            LstRecipients.Items.RemoveAt(LstRecipients.SelectedIndex);
        }

        private void BtnAddCC_Click(object sender, EventArgs e)
        {
            using (WndEMail F = new WndEMail())
            {
                F.DynamicDataObjectSamples = DynamicDataObjectSamples;
                F.CallerID = _PluginConfig.ID;
                if (F.ShowDialog() == DialogResult.OK)
                    LstCC.Items.Add(F.EMail);
            }
        }

        private void BtnRemoveCC_Click(object sender, EventArgs e)
        {
            if (LstCC.SelectedIndex < 0)
            {
                MessageBox.Show(Resource.TxtYouMustSelectItem, Resource.TxtTheDummyProgrammerRobot, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            LstCC.Items.RemoveAt(LstCC.SelectedIndex);
        }

        private void BtnAddAttachment_Click(object sender, EventArgs e)
        {
            using (WndPath F = new WndPath())
            {
                F.DynamicDataObjectSamples = DynamicDataObjectSamples;
                F.CallerID = _PluginConfig.ID;
                if (F.ShowDialog() == DialogResult.OK)
                    LstAttachments.Items.Add(F.FilePathName);
            }
        }

        private void BtnRemoveAttachment_Click(object sender, EventArgs e)
        {
            if (LstAttachments.SelectedIndex < 0)
            {
                MessageBox.Show(Resource.TxtYouMustSelectItem, Resource.TxtTheDummyProgrammerRobot, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            LstAttachments.Items.RemoveAt(LstAttachments.SelectedIndex);
        }

        private void ChkAuthenticate_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkAuthenticate.Checked)
            {
                TxtUserName.Enabled = true;
                TxtPassword.Enabled = true;
                TxtConfirmPassword.Enabled = true;
                BtnDynDataUserName.Enabled = true;
                BtnDynDataPassword.Enabled = true;
            }
            else
            {
                TxtUserName.Enabled = false;
                TxtPassword.Enabled = false;
                TxtConfirmPassword.Enabled = false;
                BtnDynDataUserName.Enabled = false;
                BtnDynDataPassword.Enabled = false;
            }
        }
    }
}
