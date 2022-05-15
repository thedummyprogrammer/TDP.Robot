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
using TDP.Robot.Plugins.Core.Infrastructure;
using TDP.Robot.Core;
using TDP.BaseServices.Infrastructure.DataValidation;
using TDP.Robot.Core.DynamicData;

namespace TDP.Robot.Plugins.Core.SqlServerCommandTask
{
    public partial class WndParameter : WndPluginDetailConfigBase
    {
        private const int _MaxVarcharLength = 4;
        private const int _MinVarcharSize = 1;
        private const int _MaxVarcharSize = 8000;

        private const int _MaxNVarcharLength = 4;
        private const int _MinNVarcharSize = 1;
        private const int _MaxNVarcharSize = 4000;

        private const int _MaxPrecisionLength = 2;
        private const int _MinPrecisionSize = 1;
        private const int _MaxPrecisionSize = 38;

        private const int _MaxScaleLength = 2;
        private const int _MinScaleSize = 0;
        private const int _MaxScaleSize = 38;

        private const int _MaxNumericValueLength = 50;

        public string ParamName
        {
            get { return TxtParamName.Text; }
            set { TxtParamName.Text = value; }
        }

        public string Value
        {
            get { return TxtValue.Text; }
            set { TxtValue.Text = value; }
        }

        public SqlParamType Type
        {
            get { return ((ListItem<SqlParamType>)CmbType.SelectedItem).Value; }
            set { CmbType.SetSelectedItem(value); }
        }

        public string Length
        {
            get { return TxtLength.Text; }
            set { TxtLength.Text = value; }
        }

        public string Precision
        {
            get { return TxtScale.Text; }
            set { TxtScale.Text = value; }
        }

        public WndParameter()
        {
            InitializeComponent();

            CmbType.Items.Add(new ListItem<SqlParamType>(SqlParamType.Varchar, Resource.TxtSqlTypeVarchar));
            CmbType.Items.Add(new ListItem<SqlParamType>(SqlParamType.NVarchar, Resource.TxtSqlTypeNVarchar));
            CmbType.Items.Add(new ListItem<SqlParamType>(SqlParamType.Xml, Resource.TxtSqlTypeXml));
            CmbType.Items.Add(new ListItem<SqlParamType>(SqlParamType.Numeric, Resource.TxtSqlTypeNumeric));
            CmbType.Items.Add(new ListItem<SqlParamType>(SqlParamType.Int, Resource.TxtSqlTypeInt));
            CmbType.Items.Add(new ListItem<SqlParamType>(SqlParamType.Long, Resource.TxtSqlTypeLong));
            CmbType.Items.Add(new ListItem<SqlParamType>(SqlParamType.Date, Resource.TxtSqlTypeDate));
            CmbType.Items.Add(new ListItem<SqlParamType>(SqlParamType.Datetime, Resource.TxtSqlTypeDateTime));
            CmbType.Items.Add(new ListItem<SqlParamType>(SqlParamType.Bit, Resource.TxtSqlTypeBit));
            CmbType.SelectedIndex = 0;

            BtnDynDataValue.Click += BtnDynDataButton_Click;
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            DataValidationHelper ValidationHelper = new DataValidationHelper();

            ClearErrors();

            try
            {
                if (CmbType.SelectedIndex < 0)
                {
                    SetError(TxtValue, Resource.TxtFieldCannotBeEmpty);
                    return;
                }

                SqlParamType ParamType = ((ListItem<SqlParamType>)CmbType.SelectedItem).Value;

                if (ValidationHelper.IsEmptyStringI(TxtParamName.Text))
                {
                    SetError(TxtParamName, Resource.TxtFieldCannotBeEmpty);
                }

                if (ParamType != SqlParamType.Varchar && ParamType != SqlParamType.NVarchar 
                    && ValidationHelper.IsEmptyStringI(TxtValue.Text) && !ChkPassNullValue.Checked)
                {
                    SetError(TxtValue, Resource.TxtYouMustInsertValueOrNull);
                }

                switch (ParamType)
                {
                    case SqlParamType.Varchar:
                        {
                            if (!ValidationHelper.IsEmptyStringI(TxtLength.Text)
                                && !DynamicDataParser.ContainsDynamicData(TxtLength.Text)
                                && TxtLength.Text.ToUpper() != "MAX"
                                && !ValidationHelper.IsIntegerI(TxtLength.Text, _MaxVarcharLength, _MinVarcharSize, _MaxVarcharSize))
                            {
                                SetError(TxtLength, string.Format(Resource.TxtFieldMustBeANumberBetweenXAndY, Resource.TxtLengthPrecision, _MinVarcharSize, _MaxVarcharSize));
                            }
                        }
                        break;

                    case SqlParamType.NVarchar:
                        {
                            if (!ValidationHelper.IsEmptyStringI(TxtLength.Text)
                                && !DynamicDataParser.ContainsDynamicData(TxtLength.Text)
                                && TxtLength.Text.ToUpper() != "MAX"
                                && !ValidationHelper.IsIntegerI(TxtLength.Text, _MaxNVarcharLength, _MinNVarcharSize, _MaxNVarcharSize))
                            {
                                SetError(TxtLength, string.Format(Resource.TxtFieldMustBeANumberBetweenXAndY, Resource.TxtLengthPrecision, _MinNVarcharSize, _MaxNVarcharSize));
                            }
                        }
                        break;

                    case SqlParamType.Numeric:
                        {
                            if (!ValidationHelper.IsEmptyStringI(TxtLength.Text)
                                && !DynamicDataParser.ContainsDynamicData(TxtLength.Text)
                                && !ValidationHelper.IsIntegerI(TxtLength.Text, _MaxPrecisionLength, _MinPrecisionSize, _MaxPrecisionSize))
                            {
                                SetError(TxtLength, string.Format(Resource.TxtFieldMustBeANumberBetweenXAndY, Resource.TxtLengthPrecision, _MinPrecisionSize, _MaxPrecisionSize));
                            }

                            if (!ValidationHelper.IsEmptyStringI(TxtLength.Text)
                                && !DynamicDataParser.ContainsDynamicData(TxtLength.Text)
                                && !ValidationHelper.IsEmptyStringI(TxtScale.Text)
                                && !DynamicDataParser.ContainsDynamicData(TxtScale.Text)
                                )
                            {
                                if (!ValidationHelper.IsIntegerI(TxtScale.Text, _MaxScaleLength, _MinScaleSize, _MaxScaleSize))
                                {
                                    SetError(TxtScale, string.Format(Resource.TxtFieldMustBeANumberBetweenXAndY, Resource.TxtScale, _MinScaleSize, _MaxScaleSize));
                                }
                                else
                                {
                                    int Precision = int.Parse(TxtLength.Text);
                                    int Scale = int.Parse(TxtScale.Text);

                                    if (Scale >= Precision)
                                    {
                                        SetError(TxtScale, Resource.TxtScaleMustBeLessThanPrecision);
                                    }
                                }
                            }

                            if (!ValidationHelper.IsEmptyStringI(TxtValue.Text)
                                && !DynamicDataParser.ContainsDynamicData(TxtValue.Text)
                                && !ValidationHelper.IsValidDecimal(TxtValue.Text, _MaxNumericValueLength, decimal.MinValue, decimal.MaxValue))
                            {
                                SetError(TxtValue, Resource.TxtFieldNotContainAValidNumber);
                            }
                        }
                        break;

                    case SqlParamType.Int:
                        {
                            if (!ValidationHelper.IsEmptyStringI(TxtValue.Text)
                                && !DynamicDataParser.ContainsDynamicData(TxtValue.Text)
                                && !ValidationHelper.IsIntegerI(TxtValue.Text, _MaxNumericValueLength, int.MinValue, int.MaxValue))
                            {
                                SetError(TxtValue, Resource.TxtFieldNotContainAValidInteger);
                            }
                        }
                        break;

                    case SqlParamType.Long:
                        {
                            if (!ValidationHelper.IsEmptyStringI(TxtValue.Text)
                                && !DynamicDataParser.ContainsDynamicData(TxtValue.Text)
                                && !ValidationHelper.IsLong(TxtValue.Text, _MaxNumericValueLength, long.MinValue, long.MaxValue))
                            {
                                SetError(TxtValue, Resource.TxtFieldNotContainAValidLong);
                            }
                        }
                        break;

                    case SqlParamType.Date:
                    case SqlParamType.Datetime:
                        {
                            if (!ValidationHelper.IsEmptyStringI(TxtValue.Text)
                                && !DynamicDataParser.ContainsDynamicData(TxtValue.Text)
                                && !ValidationHelper.IsValidSqlServerDate(TxtValue.Text, new DateTime(1900, 0, 0), new DateTime(9999, 12, 31)))
                            {
                                SetError(TxtValue, Resource.TxtFieldNotContainAValidSqlServerDate);
                            }
                        }
                        break;

                    case SqlParamType.Bit:
                        {
                            if (!ValidationHelper.IsEmptyStringI(TxtValue.Text)
                                && !DynamicDataParser.ContainsDynamicData(TxtValue.Text)
                                && !ValidationHelper.IsValidBool(TxtValue.Text))
                            {
                                SetError(TxtValue, Resource.TxtFieldNotContainAValidBool);
                            }
                        }
                        break;
                }
            }
            finally
            {
                if (GetErrorCount() == 0)
                    DialogResult = DialogResult.OK;
            }
        }

        private void ChkPassNullValue_CheckedChanged(object sender, EventArgs e)
        {
            TxtValue.Enabled = !ChkPassNullValue.Checked;
        }

        private void CmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbType.SelectedIndex >= 0)
            {
                SqlParamType ParamType = ((ListItem<SqlParamType>)CmbType.SelectedItem).Value;

                switch (ParamType)
                {
                    case SqlParamType.Varchar:
                    case SqlParamType.NVarchar:
                        TxtLength.Enabled = true;
                        TxtScale.Enabled = false;
                        break;

                    case SqlParamType.Xml:
                    case SqlParamType.Date:
                    case SqlParamType.Datetime:
                    case SqlParamType.Int:
                    case SqlParamType.Long:
                    case SqlParamType.Bit:
                        TxtLength.Enabled = false;
                        TxtScale.Enabled = false;
                        break;

                    case SqlParamType.Numeric:
                        TxtLength.Enabled = true;
                        TxtScale.Enabled = true;
                        break;
                }
            }
        }
    }
}
