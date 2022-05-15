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

namespace TDP.Robot.Plugins.Core.ReadTextFileTask
{
    public partial class WndColumn : WndPluginDetailConfigBase
    {
        private const int _ColumnPosMaxLength = 8;
        private const int _ColumnPosMinValue = 1;
        private const int _ColumnPosMaxValue = 99999999;

        private bool _ModeDelimited;
        public bool ModeDelimited 
        { 
            get 
            { 
                return _ModeDelimited; 
            } 
            set
            {
                _ModeDelimited = value;

                if (_ModeDelimited)
                {
                    TxtColumnNumber.Enabled = true;
                    TxtColumnStartsFromChar.Enabled = false;
                    TxtColumnEndsAtChar.Enabled = false;
                }
                else
                {
                    TxtColumnNumber.Enabled = false;
                    TxtColumnStartsFromChar.Enabled = true;
                    TxtColumnEndsAtChar.Enabled = true;
                }
            }
        }
        
        public string ColumnName
        {
            get { return TxtColumnName.Text; }
            set { TxtColumnName.Text = value; }
        }

        public ReadTextFileColumnDataType ColumnDataType
        {
            get { return ((ListItem<ReadTextFileColumnDataType>)CmbColumnDatatype.SelectedItem).Value; }
            set { CmbColumnDatatype.SetSelectedItem(value); }
        }

        public string ColumnExpectedFormat
        {
            get { return TxtColumnExpectedFormat.Text; }
            set { TxtColumnExpectedFormat.Text = value; }
        }

        public string ColumnExpectedCulture
        {
            get { return TxtColumnExpectedCulture.Text; }
            set { TxtColumnExpectedCulture.Text = value; }
        }

        public bool ColumnTreatNullStringAsNullValue
        {
            get { return ChkTreatNullStrAsNull.Checked; }
            set { ChkTreatNullStrAsNull.Checked = value; }
        }

        public bool ColumnIsIdentiy
        {
            get { return ChkColumnIsIdentity.Checked; }
            set { ChkColumnIsIdentity.Checked = value; }
        }


        public int? ColumnNumber
        {
            get  { return Common.GetNullableInt(TxtColumnNumber.Text); }
            set { TxtColumnNumber.Text = Common.GetStringFromNullable(value); }
        }

        public int? ColumnStartsFromChar
        {
            get { return Common.GetNullableInt(TxtColumnStartsFromChar.Text); }
            set { TxtColumnStartsFromChar.Text = Common.GetStringFromNullable(value); }
        }

        public int? ColumnEndsAtChar
        {
            get { return Common.GetNullableInt(TxtColumnEndsAtChar.Text); }
            set { TxtColumnEndsAtChar.Text = Common.GetStringFromNullable(value); }
        }

        public WndColumn()
        {
            InitializeComponent();

            CmbColumnDatatype.Items.Add(new ListItem<ReadTextFileColumnDataType>(ReadTextFileColumnDataType.String, Resource.TxtString));
            CmbColumnDatatype.Items.Add(new ListItem<ReadTextFileColumnDataType>(ReadTextFileColumnDataType.Integer, Resource.TxtInteger));
            CmbColumnDatatype.Items.Add(new ListItem<ReadTextFileColumnDataType>(ReadTextFileColumnDataType.Decimal, Resource.TxtDecimal));
            CmbColumnDatatype.Items.Add(new ListItem<ReadTextFileColumnDataType>(ReadTextFileColumnDataType.Datetime, Resource.TxtDatetime));
            CmbColumnDatatype.SelectedIndex = 0;
        }

        private void ManageControlsEnabling()
        {
            ListItem<ReadTextFileColumnDataType> Item = (ListItem<ReadTextFileColumnDataType>)CmbColumnDatatype.SelectedItem;
            if (Item.Value == ReadTextFileColumnDataType.String)
            {
                TxtColumnExpectedFormat.Enabled = false;
                TxtColumnExpectedFormat.Text = string.Empty;
                TxtColumnExpectedCulture.Enabled = false;
                TxtColumnExpectedCulture.Text = string.Empty;
            }
            else if (Item.Value == ReadTextFileColumnDataType.Integer || Item.Value == ReadTextFileColumnDataType.Decimal)
            {
                TxtColumnExpectedFormat.Enabled = false;
                TxtColumnExpectedFormat.Text = string.Empty;
                TxtColumnExpectedCulture.Enabled = true;
            }
            else
            {
                TxtColumnExpectedFormat.Enabled = true;
                TxtColumnExpectedCulture.Enabled = true;
            }

            if (ChkColumnIsIdentity.Checked)
            {
                TxtColumnExpectedCulture.Enabled = false;
                TxtColumnExpectedCulture.Text = string.Empty;
                TxtColumnExpectedFormat.Enabled = false;
                TxtColumnExpectedFormat.Text = string.Empty;

                GrpColumnPos.Enabled = false;
                TxtColumnNumber.Text = string.Empty;
                TxtColumnStartsFromChar.Text = string.Empty;
                TxtColumnEndsAtChar.Text = string.Empty;
            }
            else
            {
                GrpColumnPos.Enabled = true;
            }
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            ClearErrors();

            if (DataValidationHelper.IsEmptyString(TxtColumnName.Text))
                SetError(TxtColumnName, Resource.TxtFieldCannotBeEmpty);

            if (CmbColumnDatatype.SelectedIndex < 0)
                SetError(CmbColumnDatatype, Resource.TxtFieldCannotBeEmpty);

            ListItem<ReadTextFileColumnDataType> Item = (ListItem<ReadTextFileColumnDataType>)CmbColumnDatatype.SelectedItem;
            if (ChkColumnIsIdentity.Checked 
                && (Item.Value == ReadTextFileColumnDataType.String || Item.Value == ReadTextFileColumnDataType.Datetime))
            {
                SetError(ChkColumnIsIdentity, Resource.TxtCannotSetIsDentity);
            }

            if (!ChkColumnIsIdentity.Checked)
            {
                if (_ModeDelimited)
                {
                    if (DataValidationHelper.IsEmptyString(TxtColumnNumber.Text))
                        SetError(TxtColumnNumber, Resource.TxtFieldCannotBeEmpty);
                    else if (!DataValidationHelper.IsInteger(TxtColumnNumber.Text, _ColumnPosMaxLength, _ColumnPosMinValue, _ColumnPosMaxValue))
                        SetError(TxtColumnNumber, string.Format(Resource.TxtMustBeANumberBetweenXAndY, _ColumnPosMaxLength, _ColumnPosMinValue, _ColumnPosMaxValue));
                }
                else
                {
                    if (DataValidationHelper.IsEmptyString(TxtColumnStartsFromChar.Text))
                        SetError(TxtColumnStartsFromChar, Resource.TxtFieldCannotBeEmpty);
                    else if (!DataValidationHelper.IsInteger(TxtColumnStartsFromChar.Text, _ColumnPosMaxLength, _ColumnPosMinValue, _ColumnPosMaxValue))
                        SetError(TxtColumnStartsFromChar, string.Format(Resource.TxtMustBeANumberBetweenXAndY, _ColumnPosMaxLength, _ColumnPosMinValue, _ColumnPosMaxValue));

                    if (DataValidationHelper.IsEmptyString(TxtColumnEndsAtChar.Text))
                        SetError(TxtColumnEndsAtChar, Resource.TxtFieldCannotBeEmpty);
                    else if (!DataValidationHelper.IsInteger(TxtColumnEndsAtChar.Text, _ColumnPosMaxLength, _ColumnPosMinValue, _ColumnPosMaxValue))
                        SetError(TxtColumnEndsAtChar, string.Format(Resource.TxtMustBeANumberBetweenXAndY, _ColumnPosMaxLength, _ColumnPosMinValue, _ColumnPosMaxValue));
                }
            }

            if (GetErrorCount() == 0)
                DialogResult = DialogResult.OK;
        }

        private void CmbColumnDatatype_SelectedIndexChanged(object sender, EventArgs e)
        {
            ManageControlsEnabling();
        }

        private void ChkColumnIsIdentity_CheckedChanged(object sender, EventArgs e)
        {
            ManageControlsEnabling();
        }
    }
}
