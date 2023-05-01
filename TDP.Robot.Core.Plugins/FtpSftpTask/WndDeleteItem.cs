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

namespace TDP.Robot.Plugins.Core.FtpSftpTask
{
    public partial class WndDeleteItem : WndPluginDetailConfigBase
    {
        public WndDeleteItem()
        {
            InitializeComponent();

            BtnDynDataCopyRemotePath.Click += BtnDynDataButton_Click;
        }

        public string RemotePath
        {
            get { return TxtCopyRemotePath.Text; }
            set { TxtCopyRemotePath.Text = value; }
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            ClearErrors();

            if (DataValidationHelper.IsEmptyString(TxtCopyRemotePath.Text))
                SetError(TxtCopyRemotePath, Resource.TxtFieldCannotBeEmpty);

            if (GetErrorCount() == 0)
                DialogResult = DialogResult.OK;
        }
    }
}
