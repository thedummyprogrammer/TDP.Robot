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

namespace TDP.Robot.Plugins.Core.FileSystemTask
{
    public partial class WndCopyItem : WndPluginDetailConfigBase
    {
        public WndCopyItem()
        {
            InitializeComponent();

            BtnDynDataSourcePath.Click += BtnDynDataButton_Click;
            BtnDynDataDestinationPath.Click += BtnDynDataButton_Click;
        }

        public string SourcePath
        {
            get { return TxtSourcePath.Text; }
            set { TxtSourcePath.Text = value; }
        }

        public string DestinationPath
        {
            get { return TxtDestinationPath.Text; }
            set { TxtDestinationPath.Text = value; }
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

        private void BtnBrowserSourcePath_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog F = new OpenFileDialog())
            {
                F.RestoreDirectory = true;
                F.CheckPathExists = false;
                F.CheckFileExists = false;

                if (F.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    TxtSourcePath.Text = F.FileName;
                }
            }
        }

        private void BtnBrowseDestinationPath_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog F = new OpenFileDialog())
            {
                F.RestoreDirectory = true;
                F.CheckPathExists = false;
                F.CheckFileExists = false;

                if (F.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    TxtDestinationPath.Text = F.FileName;
                }
            }
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            ClearErrors();

            if (DataValidationHelper.IsEmptyString(TxtSourcePath.Text))
                SetError(TxtSourcePath, Resource.TxtFieldCannotBeEmpty);

            if (DataValidationHelper.IsEmptyString(TxtDestinationPath.Text))
                SetError(TxtDestinationPath, Resource.TxtFieldCannotBeEmpty);

            if (GetErrorCount() == 0)
                DialogResult = DialogResult.OK;
        }
    }
}
