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
using System.Windows.Forms;
using TDP.BaseServices.Infrastructure.DataValidation;
using TDP.Robot.Core;
using TDP.Robot.Core.DynamicData;
using TDP.Robot.JobEditor.Infrastructure.Workspace.Abstract;
using TDP.Robot.JobEditor.Properties;
using TDP.Robot.Plugins.Core.Infrastructure;

namespace TDP.Robot.JobEditor
{
    partial class WndExecutionCondition : Form
    {
        /*
        public int ObjectID { get; set; }
        public string ObjectName { get; set; }
        */
        public IWorkspaceItem Item { get; set; }

        public List<DynamicDataSample> DynamicDataSampleList { get; set; }
        public string DynamicData { get; set; }
        public EnumExecutionConditionOperator Operator { get; set; }
        public string Value { get; set; }
        public string MaxValue { get; set; }

        public WndExecutionCondition()
        {
            InitializeComponent();

            CmbOperator.Items.Add(new ListItem<EnumExecutionConditionOperator>(EnumExecutionConditionOperator.ObjectExecutes, Resources.TxtObjectExecutes));
            CmbOperator.Items.Add(new ListItem<EnumExecutionConditionOperator>(EnumExecutionConditionOperator.ObjectDoesNotExecute, Resources.TxtObjectDontExecute));
            CmbOperator.Items.Add(new ListItem<EnumExecutionConditionOperator>(EnumExecutionConditionOperator.ValueEqualsTo, Resources.TxtValueEqualsTo));
            CmbOperator.Items.Add(new ListItem<EnumExecutionConditionOperator>(EnumExecutionConditionOperator.ValueGreaterThan, Resources.TxtValueGreaterThan));
            CmbOperator.Items.Add(new ListItem<EnumExecutionConditionOperator>(EnumExecutionConditionOperator.ValueLessThan, Resources.TxtValueLessThan));
            CmbOperator.Items.Add(new ListItem<EnumExecutionConditionOperator>(EnumExecutionConditionOperator.ValueBetween, Resources.TxtValueBetween));
            CmbOperator.Items.Add(new ListItem<EnumExecutionConditionOperator>(EnumExecutionConditionOperator.ValueContains, Resources.TxtValueContains));
            CmbOperator.Items.Add(new ListItem<EnumExecutionConditionOperator>(EnumExecutionConditionOperator.ValueStartsWith, Resources.TxtValueStartsWith));
            CmbOperator.Items.Add(new ListItem<EnumExecutionConditionOperator>(EnumExecutionConditionOperator.ValueEndsWith, Resources.TxtValueEndsWith));
            
            CmbOperator.SelectedIndex = 0;
        }

        private void CmbOperator_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbOperator.SelectedIndex < 0)
                return;

            ListItem<EnumExecutionConditionOperator> SelectedItem = (ListItem<EnumExecutionConditionOperator>)CmbOperator.SelectedItem;

            switch (SelectedItem.Value)
            {
                case EnumExecutionConditionOperator.ObjectExecutes:
                case EnumExecutionConditionOperator.ObjectDoesNotExecute:
                    CmbDynamicData.SelectedIndex = -1;
                    CmbDynamicData.Enabled = false;

                    LblValue.Visible = false;
                    TxtValue.Text = string.Empty;
                    TxtValue.Visible = false;
                    
                    LblMaxValue.Visible = false;
                    TxtMaxValue.Text = string.Empty;
                    TxtMaxValue.Visible = false;
                    break;

                case EnumExecutionConditionOperator.ValueEqualsTo:
                case EnumExecutionConditionOperator.ValueGreaterThan:
                case EnumExecutionConditionOperator.ValueLessThan:
                case EnumExecutionConditionOperator.ValueContains:
                case EnumExecutionConditionOperator.ValueStartsWith:
                case EnumExecutionConditionOperator.ValueEndsWith:
                    if (CmbDynamicData.Items.Count > 0)
                        CmbDynamicData.SelectedIndex = 0;
                    CmbDynamicData.Enabled = true;

                    LblValue.Text = Resources.TxtValue;
                    LblValue.Visible = true;
                    TxtValue.Visible = true;

                    LblMaxValue.Visible = false;
                    TxtMaxValue.Text = string.Empty;
                    TxtMaxValue.Visible = false;
                    break;

                case EnumExecutionConditionOperator.ValueBetween:
                    if (CmbDynamicData.Items.Count > 0)
                        CmbDynamicData.SelectedIndex = 0;
                    CmbDynamicData.Enabled = true;

                    LblValue.Text = Resources.TxtMinValue;
                    LblValue.Visible = true;
                    TxtValue.Visible = true;

                    LblMaxValue.Visible = true;
                    TxtMaxValue.Visible = true;
                    break;
            }
        }

        private void WndExecutionCondition_Load(object sender, EventArgs e)
        {
            TxtObjectID.Text = Item.ID.ToString();
            TxtObjectName.Text = Item.Name;

            CmbDynamicData.Items.Add(string.Empty);
            foreach (DynamicDataSample DataSample in DynamicDataSampleList)
            {
                CmbDynamicData.Items.Add(new ListItem<string>(DataSample.InternalName, DataSample.ToString()));
            }

            CmbOperator.SetSelectedItem(Operator);
            if (!string.IsNullOrEmpty(DynamicData))
                CmbDynamicData.SetSelectedItem(DynamicData);
            TxtValue.Text = Value;
            TxtMaxValue.Text = MaxValue;
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            int ErrorCount = 0;
            ErrorProvider.Clear();

            if (CmbDynamicData.Enabled 
                && (CmbDynamicData.SelectedIndex < 0 
                        || CmbDynamicData.SelectedItem == null) 
                        || DataValidationHelper.IsEmptyString(CmbDynamicData.SelectedItem.ToString()))
            {
                ErrorCount++;
                ErrorProvider.SetError(CmbDynamicData, Resources.TxtFieldCannotBeEmpty);
            }

            if (CmbOperator.SelectedIndex < 0)
            {
                ErrorCount++;
                ErrorProvider.SetError(CmbOperator, Resources.TxtFieldCannotBeEmpty);
            }

            // For convenience, set here Operator property
            Operator = ((ListItem<EnumExecutionConditionOperator>)CmbOperator.SelectedItem).Value;

            bool CheckValuesForInteger = (Operator == EnumExecutionConditionOperator.ValueBetween
                                                    || Operator == EnumExecutionConditionOperator.ValueEqualsTo
                                                    || Operator == EnumExecutionConditionOperator.ValueGreaterThan
                                                    || Operator == EnumExecutionConditionOperator.ValueLessThan);


            bool IsValueValid = false;
            if (TxtValue.Visible)
            {
                if (DataValidationHelper.IsEmptyString(TxtValue.Text))
                {
                    ErrorCount++;
                    ErrorProvider.SetError(TxtValue, Resources.TxtFieldCannotBeEmpty);
                }
                else if (CheckValuesForInteger)
                {
                    if (!DataValidationHelper.IsInteger(TxtValue.Text, int.MinValue.ToString().Length, int.MinValue, int.MaxValue))
                    {
                        ErrorCount++;
                        ErrorProvider.SetError(TxtValue, Resources.TxtFieldNotContainAValidInteger);
                    }
                    else
                        IsValueValid = true;
                }
            }

            bool IsMaxValueValid = false;
            if (TxtMaxValue.Visible)
            {
                if (DataValidationHelper.IsEmptyString((TxtMaxValue.Text)))
                {
                    ErrorCount++;
                    ErrorProvider.SetError(TxtMaxValue, Resources.TxtFieldCannotBeEmpty);
                }
                else if (CheckValuesForInteger)
                {
                    if (!DataValidationHelper.IsInteger(TxtValue.Text, int.MinValue.ToString().Length, int.MinValue, int.MaxValue))
                    {
                        ErrorCount++;
                        ErrorProvider.SetError(TxtMaxValue, Resources.TxtFieldNotContainAValidInteger);
                    }
                    else
                        IsMaxValueValid = true;
                }
            }

            if (IsValueValid && IsMaxValueValid)
            {
                if (int.Parse(TxtValue.Text) > int.Parse(TxtMaxValue.Text))
                {
                    ErrorCount++;
                    ErrorProvider.SetError(TxtValue, string.Format(Resources.TxtThisFieldCannotBeGreaterThanField, Resources.TxtMaxValue));
                }
            }


            if (ErrorCount > 0)
            {
                MessageBox.Show(Resources.TxtThereAreSomeErrors, Resources.TxtTheDummyProgrammerRobot, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            

            if (Operator != EnumExecutionConditionOperator.ObjectExecutes && Operator != EnumExecutionConditionOperator.ObjectDoesNotExecute)
                DynamicData = ((ListItem<string>)CmbDynamicData.SelectedItem).Value;
            
            Value = TxtValue.Text;
            MaxValue = TxtMaxValue.Text;

            DialogResult = DialogResult.OK;
        }
    }
}
