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
using System.Windows.Forms;
using TDP.BaseServices.Infrastructure.DataValidation;
using TDP.Robot.Core;
using TDP.Robot.Core.DynamicData;

namespace TDP.Robot.Plugins.Core.SendEMailTask
{
    public partial class WndEMail : WndPluginDetailConfigBase
    {
        public string EMail 
        { 
            get
            {
                return TxtEMail.Text;
            }
            set
            {
                TxtEMail.Text = value;
            }
        }

        public WndEMail()
        {
            InitializeComponent();

            BtnDynDataEMail.Click += BtnDynDataButton_Click;
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            if (DataValidationHelper.IsEmptyString(TxtEMail.Text))
            {
                SetError(TxtEMail, Resource.TxtFieldCannotBeEmpty);
            }
            else if (!DynamicDataParser.ContainsDynamicData(TxtEMail.Text)
                    && !DataValidationHelper.IsValidEMail(TxtEMail.Text))
            {
                SetError(TxtEMail, Resource.TxtEMailNotValid);
            }

            if (GetErrorCount() == 0)
                DialogResult = DialogResult.OK;
        }
    }
}
