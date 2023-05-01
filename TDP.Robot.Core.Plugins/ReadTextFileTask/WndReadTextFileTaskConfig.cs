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
using TDP.Robot.Core.DynamicData;
using TDP.Robot.Plugins.Core.Infrastructure;

namespace TDP.Robot.Plugins.Core.ReadTextFileTask
{
    public partial class WndReadTextFileTaskConfig : WndPluginTaskConfig
    {
        public WndReadTextFileTaskConfig()
        {
            InitializeComponent();
            
            MoveBaseTabs();

            CmbReadIntervalType.Items.Add(new ListItem<ReadTextFileIntervalType>(ReadTextFileIntervalType.ReadFromRowToRow, Resource.TxtReadFromRowToRow));
            CmbReadIntervalType.Items.Add(new ListItem<ReadTextFileIntervalType>(ReadTextFileIntervalType.ReadFromRowToLastRow, Resource.TxtReadFromRowToLastRow));
            CmbReadIntervalType.Items.Add(new ListItem<ReadTextFileIntervalType>(ReadTextFileIntervalType.ReadLastNRows, Resource.TxtReadLastNRows));
            CmbReadIntervalType.SelectedIndex = 0;

            BtnDynDataFilePathName.Click += BtnDynDataButton_Click;
            BtnDynDataReadRowNumber.Click += BtnDynDataButton_Click;
            BtnDynDataReadFromRow.Click += BtnDynDataButton_Click;
            BtnDynDataNumberOfRows.Click += BtnDynDataButton_Click;
            BtnDynDataReadToRow.Click += BtnDynDataButton_Click;
        }

        private string[] BuildDelimitersArray()
        {
            List<string> Delimiters = new List<string>();

            if (ChkDelTab.Checked)
                Delimiters.Add("\t");

            if (ChkDelSemicolon.Checked)
                Delimiters.Add(@";");

            if (ChkDelComma.Checked)
                Delimiters.Add(@",");

            if (ChkDelSpace.Checked)
                Delimiters.Add(@" ");

            if (ChkDelOther.Checked)
                Delimiters.Add(TxtDelOther.Text);

            return Delimiters.ToArray();
        }

        private void ManageEditColumn()
        {
            if (LstColumns.SelectedIndex < 0)
            {
                MessageBox.Show(Resource.TxtYouMustSelectItem, Resource.TxtTheDummyProgrammerRobot, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ReadTextFileColumnDefinition ColDef = (ReadTextFileColumnDefinition)LstColumns.SelectedItem;

            using (WndColumn F = new WndColumn())
            {
                F.ColumnName = ColDef.ColumnName;
                F.ColumnDataType = ColDef.ColumnDataType;
                F.ColumnExpectedFormat = ColDef.ColumnExpectedFormat;
                F.ColumnExpectedCulture = ColDef.ColumnExpectedCulture;
                F.ColumnTreatNullStringAsNullValue = ColDef.ColumnTreatNullStringAsNull;
                F.ColumnIsIdentiy = ColDef.ColumnIsIdentity;
                F.ColumnNumber = ColDef.ColumnPosition;
                F.ColumnStartsFromChar = ColDef.ColumnStartsFromCharPos;
                F.ColumnEndsAtChar = ColDef.ColumnEndsAtCharPos;
                F.DynamicDataObjectSamples = DynamicDataObjectSamples;
                F.CallerID = _PluginConfig.ID;
                F.ModeDelimited = ChkSplitDelimiters.Checked;
                if (F.ShowDialog() == DialogResult.OK)
                {
                    ColDef.ColumnName = F.ColumnName;
                    ColDef.ColumnDataType = F.ColumnDataType;
                    ColDef.ColumnExpectedFormat = F.ColumnExpectedFormat;
                    ColDef.ColumnExpectedCulture = F.ColumnExpectedCulture;
                    ColDef.ColumnTreatNullStringAsNull = F.ColumnTreatNullStringAsNullValue;
                    ColDef.ColumnIsIdentity = F.ColumnIsIdentiy;
                    ColDef.ColumnPosition = F.ColumnNumber;
                    ColDef.ColumnStartsFromCharPos = F.ColumnStartsFromChar;
                    ColDef.ColumnEndsAtCharPos = F.ColumnEndsAtChar;
                    F.DynamicDataObjectSamples = DynamicDataObjectSamples;
                    LstColumns.Items[LstColumns.SelectedIndex] = ColDef;
                }
            }
        }

        private void ClearColumnDef()
        {
            ChkOverrideDefaultColumnDef.Checked = false;
            LstColumns.Items.Clear();
        }

        private void ManageColumnDefEnabling()
        {
            if (ChkSplitDelimiters.Checked || ChkSplitUsingFixedLengthCols.Checked)
            {
                ChkOverrideDefaultColumnDef.Enabled = true;
                GrpColumns.Enabled = ChkOverrideDefaultColumnDef.Checked;
            }
            else
            {
                ChkOverrideDefaultColumnDef.Enabled = false;
                GrpColumns.Enabled = ChkOverrideDefaultColumnDef.Checked;
            }
        }

        protected override bool ValidateConfig(IPluginInstanceConfig config)
        {
            base.ValidateConfig(config);

            if (DataValidationHelper.IsEmptyString(TxtFilePathName.Text))
                SetError(TxtFilePathName, Resource.TxtFieldCannotBeEmpty);

            if (RdbReadRowNumber.Checked)
            {
                if (DataValidationHelper.IsEmptyString(TxtReadRowNumber.Text))
                    SetError(TxtReadRowNumber, Resource.TxtFieldCannotBeEmpty);
            }

            if (RdbReadInterval.Checked)
            {
                if (CmbReadIntervalType.SelectedIndex < 0)
                    SetError(TxtReadRowNumber, Resource.TxtFieldCannotBeEmpty);
                else
                {
                    ReadTextFileIntervalType IntervalType = ((ListItem<ReadTextFileIntervalType>)CmbReadIntervalType.SelectedItem).Value;

                    switch (IntervalType)
                    {
                        case ReadTextFileIntervalType.ReadFromRowToRow:
                            if (DataValidationHelper.IsEmptyString(TxtReadFromRow.Text))
                                SetError(TxtReadFromRow, Resource.TxtFieldCannotBeEmpty);

                            if (DataValidationHelper.IsEmptyString(TxtReadToRow.Text))
                                SetError(TxtReadToRow, Resource.TxtFieldCannotBeEmpty);
                            break;

                        case ReadTextFileIntervalType.ReadFromRowToLastRow:
                            if (DataValidationHelper.IsEmptyString(TxtReadFromRow.Text))
                                SetError(TxtReadFromRow, Resource.TxtFieldCannotBeEmpty);
                            break;

                        case ReadTextFileIntervalType.ReadLastNRows:
                            if (DataValidationHelper.IsEmptyString(TxtNumberOfRows.Text))
                                SetError(TxtNumberOfRows, Resource.TxtFieldCannotBeEmpty);
                            break;
                    }
                }
            }

            if (!DataValidationHelper.IsEmptyString(TxtNumberOfRows.Text))
            {

            }

            return GetErrorCount() == 0;
        }

        protected override void FillConfig(IPluginInstanceConfig config)
        {
            base.FillConfig(config);

            ReadTextFileTaskConfig Config = (ReadTextFileTaskConfig)config;

            Config.FilePath = TxtFilePathName.Text;

            Config.ReadAllTheRowsOption = RdbReadAllTheRows.Checked;
            Config.SkipFirstLine = ChkSkipFirstLine.Checked;

            Config.ReadLastRowOption = RdbReadLastRow.Checked;

            Config.ReadRowNumberOption = RdbReadRowNumber.Checked;
            Config.ReadRowNumber = TxtReadRowNumber.Text;

            Config.ReadIntervalOption = RdbReadInterval.Checked;
            Config.ReadInterval = ((ListItem<ReadTextFileIntervalType>)CmbReadIntervalType.SelectedItem).Value;
            Config.ReadFromRow = TxtReadFromRow.Text;
            Config.ReadToRow = TxtReadToRow.Text;
            Config.ReadNumberOfRows = TxtNumberOfRows.Text;

            if (ChkSplitDelimiters.Checked)
            {
                Config.SplitColumnsType = ReadTextFileSplitColumnsType.UseDelimiters;
            }
            else if (ChkSplitUsingFixedLengthCols.Checked)
            {
                Config.SplitColumnsType = ReadTextFileSplitColumnsType.UseFixedWidthColumns;
            }
            else
            {
                Config.SplitColumnsType = ReadTextFileSplitColumnsType.None;
            }

            Config.DelimiterTab = ChkDelTab.Checked;
            Config.DelimiterSemicolon = ChkDelSemicolon.Checked;
            Config.DelimiterComma = ChkDelComma.Checked;
            Config.DelimiterSpace = ChkDelSpace.Checked;
            Config.DelimiterOther = ChkDelOther.Checked;
            Config.DelimiterOtherChar = TxtDelOther.Text;
            Config.UseDoubleQuotes = ChkUseDoubleQuotes.Checked;

            Config.OverrideDefaultColumnsDefinition = ChkOverrideDefaultColumnDef.Checked;
            Config.ColumnsDefinition.Clear();
            foreach (ReadTextFileColumnDefinition ColDef in LstColumns.Items)
            {
                Config.ColumnsDefinition.Add(ColDef);
            }
        }

        protected override void FillForm(IPluginInstanceConfig config)
        {
            base.FillForm(config);

            ReadTextFileTaskConfig Config = (ReadTextFileTaskConfig)config;

            TxtFilePathName.Text = Config.FilePath;

            RdbReadAllTheRows.Checked = Config.ReadAllTheRowsOption;
            ChkSkipFirstLine.Checked = Config.SkipFirstLine;

            RdbReadLastRow.Checked = Config.ReadLastRowOption;

            RdbReadRowNumber.Checked = Config.ReadRowNumberOption;
            TxtReadRowNumber.Text = Config.ReadRowNumber;

            RdbReadInterval.Checked = Config.ReadIntervalOption;
            CmbReadIntervalType.SetSelectedItem(Config.ReadInterval);
            TxtReadFromRow.Text = Config.ReadFromRow;
            TxtReadToRow.Text = Config.ReadToRow;
            TxtNumberOfRows.Text = Config.ReadNumberOfRows;

            if (Config.SplitColumnsType == ReadTextFileSplitColumnsType.UseDelimiters)
            {
                ChkSplitDelimiters.Checked = true;
                ChkSplitUsingFixedLengthCols.Checked = false;
                GrpDelimiters.Enabled = true;
            }
            else if (Config.SplitColumnsType == ReadTextFileSplitColumnsType.UseFixedWidthColumns)
            {
                ChkSplitDelimiters.Checked = false;
                ChkSplitUsingFixedLengthCols.Checked = true;
                GrpDelimiters.Enabled = false;
            }

            ChkDelTab.Checked = Config.DelimiterTab;
            ChkDelSemicolon.Checked = Config.DelimiterSemicolon;
            ChkDelComma.Checked = Config.DelimiterComma;
            ChkDelSpace.Checked = Config.DelimiterSpace;
            ChkDelOther.Checked = Config.DelimiterOther;
            TxtDelOther.Text = Config.DelimiterOtherChar;
            ChkUseDoubleQuotes.Checked = Config.UseDoubleQuotes;

            ChkOverrideDefaultColumnDef.Checked = Config.OverrideDefaultColumnsDefinition;
            LstColumns.Items.Clear();
            foreach (ReadTextFileColumnDefinition ColDef in Config.ColumnsDefinition)
            {
                LstColumns.Items.Add(ColDef);
            }
        }

        private void BtnBrowseFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog F = new OpenFileDialog())
            {
                F.Filter = "Text files (*.txt)|*.txt|CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                F.RestoreDirectory = true;
                F.CheckPathExists = false;
                F.CheckFileExists = false;

                if (F.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    TxtFilePathName.Text = F.FileName;
                }
            }
        }

        private void RdbReadAllTheRows_CheckedChanged(object sender, EventArgs e)
        {
            TxtReadRowNumber.Enabled = false;
            BtnDynDataReadRowNumber.Enabled = false;
            CmbReadIntervalType.Enabled = false;
            TxtReadFromRow.Enabled = false;
            BtnDynDataReadFromRow.Enabled = false;
            TxtReadToRow.Enabled = false;
            BtnDynDataReadToRow.Enabled = false;
            TxtNumberOfRows.Enabled = false;
            BtnDynDataNumberOfRows.Enabled = false;
            ChkSkipFirstLine.Enabled = true;
        }

        private void RdbReadLastRow_CheckedChanged(object sender, EventArgs e)
        {
            TxtReadRowNumber.Enabled = false;
            BtnDynDataReadRowNumber.Enabled = false;
            CmbReadIntervalType.Enabled = false;
            TxtReadFromRow.Enabled = false;
            BtnDynDataReadFromRow.Enabled = false;
            TxtReadToRow.Enabled = false;
            BtnDynDataReadToRow.Enabled = false;
            TxtNumberOfRows.Enabled = false;
            BtnDynDataNumberOfRows.Enabled = false;
            ChkSkipFirstLine.Enabled = false;
        }

        private void RdbReadRowNumber_CheckedChanged(object sender, EventArgs e)
        {
            TxtReadRowNumber.Enabled = true;
            BtnDynDataReadRowNumber.Enabled = true;
            CmbReadIntervalType.Enabled = false;
            TxtReadFromRow.Enabled = false;
            BtnDynDataReadFromRow.Enabled = false;
            TxtReadToRow.Enabled = false;
            BtnDynDataReadToRow.Enabled = false;
            TxtNumberOfRows.Enabled = false;
            BtnDynDataNumberOfRows.Enabled = false;
            ChkSkipFirstLine.Enabled = false;
        }

        private void RdbReadInterval_CheckedChanged(object sender, EventArgs e)
        {
            TxtReadRowNumber.Enabled = false;
            BtnDynDataReadRowNumber.Enabled = true;
            CmbReadIntervalType.Enabled = true;
            TxtReadFromRow.Enabled = true;
            BtnDynDataReadFromRow.Enabled = true;
            TxtReadToRow.Enabled = true;
            BtnDynDataReadToRow.Enabled = true;
            TxtNumberOfRows.Enabled = true;
            BtnDynDataNumberOfRows.Enabled = true;
            ChkSkipFirstLine.Enabled = false;
        }

        private void CmbReadIntervalType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbReadIntervalType.SelectedIndex >= 0)
            {
                ListItem<ReadTextFileIntervalType> Item = (ListItem<ReadTextFileIntervalType>)CmbReadIntervalType.SelectedItem;

                switch (Item.Value)
                {
                    case ReadTextFileIntervalType.ReadFromRowToRow:
                        LblReadFromRow.Visible = true;
                        TxtReadFromRow.Visible = true;
                        BtnDynDataReadFromRow.Visible = true;
                        LblReadToRow.Visible = true;
                        TxtReadToRow.Visible = true;
                        BtnDynDataReadToRow.Visible = true;
                        LblNumberOfRows.Visible = false;
                        TxtNumberOfRows.Visible = false;
                        BtnDynDataNumberOfRows.Visible = false;
                        break;

                    case ReadTextFileIntervalType.ReadFromRowToLastRow:
                        LblReadFromRow.Visible = true;
                        TxtReadFromRow.Visible = true;
                        BtnDynDataReadFromRow.Visible = true;
                        LblReadToRow.Visible = false;
                        TxtReadToRow.Visible = false;
                        BtnDynDataReadToRow.Visible = false;
                        LblNumberOfRows.Visible = false;
                        TxtNumberOfRows.Visible = false;
                        BtnDynDataNumberOfRows.Visible = false;
                        break;

                    case ReadTextFileIntervalType.ReadLastNRows:
                        LblReadFromRow.Visible = false;
                        TxtReadFromRow.Visible = false;
                        BtnDynDataReadFromRow.Visible = false;
                        LblReadToRow.Visible = false;
                        TxtReadToRow.Visible = false;
                        BtnDynDataReadToRow.Visible = false;
                        LblNumberOfRows.Visible = true;
                        TxtNumberOfRows.Visible = true;
                        BtnDynDataNumberOfRows.Visible = true;
                        break;
                }
            }
        }

        private void ChkSplitDelimiters_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkSplitDelimiters.Checked)
            {
                GrpDelimiters.Enabled = true;
                ChkSplitUsingFixedLengthCols.Checked = false;
            }
            else
            {
                GrpDelimiters.Enabled = false;
            }

            ManageColumnDefEnabling();
        }

        private void ChkSplitUsingFixedLengthCols_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkSplitUsingFixedLengthCols.Checked)
            {
                ChkSplitDelimiters.Checked = false;
            }

            ManageColumnDefEnabling();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            using (WndColumn F = new WndColumn())
            {
                F.DynamicDataObjectSamples = DynamicDataObjectSamples;
                F.CallerID = _PluginConfig.ID;
                F.ModeDelimited = ChkSplitDelimiters.Checked;
                if (F.ShowDialog() == DialogResult.OK)
                {
                    ReadTextFileColumnDefinition ColDef = new ReadTextFileColumnDefinition(F.ColumnName, F.ColumnDataType, F.ColumnExpectedFormat, F.ColumnExpectedCulture, F.ColumnTreatNullStringAsNullValue, F.ColumnIsIdentiy, F.ColumnNumber, F.ColumnStartsFromChar, F.ColumnEndsAtChar);
                    LstColumns.Items.Add(ColDef);
                }
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            ManageEditColumn();
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            if (LstColumns.SelectedIndex < 0)
            {
                MessageBox.Show(Resource.TxtYouMustSelectItem, Resource.TxtTheDummyProgrammerRobot, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            LstColumns.Items.RemoveAt(LstColumns.SelectedIndex);
        }

        private void BtnMoveUp_Click(object sender, EventArgs e)
        {
            if (LstColumns.SelectedIndex < 0)
            {
                MessageBox.Show(Resource.TxtYouMustSelectItem, Resource.TxtTheDummyProgrammerRobot, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (LstColumns.SelectedIndex == 0)
                return;

            int SelectedIndex = LstColumns.SelectedIndex;
            ReadTextFileColumnDefinition ColDef = (ReadTextFileColumnDefinition)LstColumns.Items[SelectedIndex - 1];

            LstColumns.Items.RemoveAt(SelectedIndex - 1);
            LstColumns.Items.Insert(SelectedIndex, ColDef);
        }

        private void BtnMoveDown_Click(object sender, EventArgs e)
        {
            if (LstColumns.SelectedIndex < 0)
            {
                MessageBox.Show(Resource.TxtYouMustSelectItem, Resource.TxtTheDummyProgrammerRobot, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (LstColumns.SelectedIndex == (LstColumns.Items.Count - 1))
                return;

            int SelectedIndex = LstColumns.SelectedIndex;
            ReadTextFileColumnDefinition ColDef = (ReadTextFileColumnDefinition)LstColumns.Items[SelectedIndex];

            LstColumns.Items.RemoveAt(SelectedIndex);
            LstColumns.Items.Insert(SelectedIndex + 1, ColDef);
            LstColumns.SelectedIndex = SelectedIndex + 1;
        }

        private void LstColumns_DoubleClick(object sender, EventArgs e)
        {
            ManageEditColumn();
        }

        private void ChkOverrideDefaultColumnDef_CheckedChanged(object sender, EventArgs e)
        {
            GrpColumns.Enabled = ChkOverrideDefaultColumnDef.Checked;
        }

        private void ChkSplitDelimiters_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Resource.TxtChangingThisOptionYouWillLoseColumnDef, Resource.TxtTheDummyProgrammerRobot, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;
            
            ChkSplitDelimiters.Checked = !ChkSplitDelimiters.Checked;

            ClearColumnDef();
        }

        private void ChkSplitUsingFixedLengthCols_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Resource.TxtChangingThisOptionYouWillLoseColumnDef, Resource.TxtTheDummyProgrammerRobot, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;

            ChkSplitUsingFixedLengthCols.Checked = !ChkSplitUsingFixedLengthCols.Checked;

            ClearColumnDef();
        }

        private void LstColumns_DoubleClick_1(object sender, EventArgs e)
        {
            ManageEditColumn();
        }

        private void BtnAutomaticCreation_Click(object sender, EventArgs e)
        {
            using (WndAutoCreateColumns F = new WndAutoCreateColumns())
            {
                F.DelimitersArray = BuildDelimitersArray();
                F.UseDoubleQuotes = ChkUseDoubleQuotes.Checked;
                
                if (F.ShowDialog() == DialogResult.OK)
                {
                    LstColumns.Items.Clear();
                    foreach (ReadTextFileColumnDefinition ColDef in F.ColumnsDefinition)
                    {
                        LstColumns.Items.Add(ColDef);
                    }
                }
            }
        }
    }
}
