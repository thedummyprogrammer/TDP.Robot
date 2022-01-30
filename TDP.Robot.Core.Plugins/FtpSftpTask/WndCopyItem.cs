﻿/*======================================================================================
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

namespace TDP.Robot.Plugins.Core.FtpSftpTask
{
    public partial class WndCopyItem : WndPluginDetailConfigBase
    {
        public WndCopyItem()
        {
            InitializeComponent();

            BtnDynDataCopyLocalPath.Click += BtnDynDataButton_Click;
            BtnDynDataCopyRemotePath.Click += BtnDynDataButton_Click;
        }

        public string RemotePath
        {
            get { return TxtCopyRemotePath.Text; }
            set { TxtCopyRemotePath.Text = value; }
        }

        public string LocalPath
        {
            get { return TxtCopyLocalPath.Text; }
            set { TxtCopyLocalPath.Text = value; }
        }

        public bool LocalToRemote
        {
            get { return RdbCopyLocalToRemote.Checked; }
            set 
            { 
                RdbCopyLocalToRemote.Checked = value;
                RdbCopyRemoteToLocal.Checked = !value;
            }
        }

        public bool OverwriteFileIfExists
        {
            get { return ChkOverwriteFileIfExists.Checked; }
            set { ChkOverwriteFileIfExists.Checked = value; }
        }

        public bool RecursivelyCopyDirectories
        {
            get { return ChkRecursivelyCopyDirectories.Checked; }
            set { ChkRecursivelyCopyDirectories.Checked = value; }
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            ClearErrors();

            if (DataValidationHelper.IsEmptyString(TxtCopyLocalPath.Text))
                SetError(TxtCopyLocalPath, Resource.TxtFieldCannotBeEmpty);

            if (DataValidationHelper.IsEmptyString(TxtCopyRemotePath.Text))
                SetError(TxtCopyRemotePath, Resource.TxtFieldCannotBeEmpty);

            if (GetErrorCount() == 0)
                DialogResult = DialogResult.OK;
        }

        private void BtnBrowserCopyLocalPath_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog F = new OpenFileDialog())
            {
                F.RestoreDirectory = true;
                F.CheckPathExists = false;
                F.CheckFileExists = false;

                if (F.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    TxtCopyLocalPath.Text = F.FileName;
                }
            }
        }
    }
}