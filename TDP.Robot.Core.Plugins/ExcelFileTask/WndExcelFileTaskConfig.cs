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
using TDP.Robot.Plugins.Core.Infrastructure;

namespace TDP.Robot.Plugins.Core.ExcelFileTask
{
    public partial class WndExcelFileTaskConfig : WndPluginTaskConfig
    {
        private const int _ExcelRowLength = 7;
        private const int _MinExcelRow = 1;
        private const int _MaxExcelRow = 1048576;

        public WndExcelFileTaskConfig()
        {
            InitializeComponent();

            MoveBaseTabs();

            CmbTaskType.Items.Add(new ListItem<ExcelFileTaskType>(ExcelFileTaskType.AppendRow, Resource.TxtAppendRow));
            CmbTaskType.Items.Add(new ListItem<ExcelFileTaskType>(ExcelFileTaskType.InsertRow, Resource.TxtInsertRow));
            CmbTaskType.Items.Add(new ListItem<ExcelFileTaskType>(ExcelFileTaskType.ReadRow, Resource.TxtReadRow));
            /*
            CmbTaskType.Items.Add(new ListItem<ExcelFileTaskType>(ExcelFileTaskType.DeleteRow, Resource.TxtDeleteRow));
            CmbTaskType.Items.Add(new ListItem<ExcelFileTaskType>(ExcelFileTaskType.FindFirstRow, Resource.TxtFindFirstRow));
            CmbTaskType.Items.Add(new ListItem<ExcelFileTaskType>(ExcelFileTaskType.FindAllRows, Resource.TxtFindAllRows));
            CmbTaskType.Items.Add(new ListItem<ExcelFileTaskType>(ExcelFileTaskType.FindAndReplace, Resource.TxtFindAndReplace));
            */
            CmbTaskType.SelectedIndex = 0;

            CmbReadIntervalType.Items.Add(new ListItem<ExcelReadIntervalType>(ExcelReadIntervalType.ReadFromRowToRow, Resource.TxtReadFromRowToRow));
            CmbReadIntervalType.Items.Add(new ListItem<ExcelReadIntervalType>(ExcelReadIntervalType.ReadFromRowToLastRow, Resource.TxtReadFromRowToLastRow));
            CmbReadIntervalType.Items.Add(new ListItem<ExcelReadIntervalType>(ExcelReadIntervalType.ReadLastNRows, Resource.TxtReadLastNRows));
            CmbReadIntervalType.SelectedIndex = 0;

            BtnDynDataFilePathName.Click += BtnDynDataButton_Click;
            BtnDynDataSheetName.Click += BtnDynDataButton_Click;
            BtnDynDataInsertAtRow.Click += BtnDynDataButton_Click;
            BtnDynDataReadRowNumber.Click += BtnDynDataButton_Click;
            BtnDynDataReadFromRow.Click += BtnDynDataButton_Click;
            BtnDynDataNumberOfRows.Click += BtnDynDataButton_Click;
            BtnDynDataReadToRow.Click += BtnDynDataButton_Click;
            BtnDynDataNumColumnsToRead.Click += BtnDynDataButton_Click;
            BtnDynDataDeleteRowNumber.Click += BtnDynDataButton_Click;
        }

        private void ManageEditColumn()
        {
            if (LstColumns.SelectedIndex < 0)
            {
                MessageBox.Show(Resource.TxtYouMustSelectItem, Resource.TxtTheDummyProgrammerRobot, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ExcelFileColumnDefinition ColDef = (ExcelFileColumnDefinition)LstColumns.SelectedItem;

            using (WndColumn F = new WndColumn())
            {
                F.HeaderTitle = ColDef.HeaderTitle;
                F.CellValue = ColDef.CellValue;
                F.DynamicDataObjectSamples = DynamicDataObjectSamples;
                F.CallerID = _PluginConfig.ID;
                if (F.ShowDialog() == DialogResult.OK)
                {
                    ColDef.HeaderTitle = F.HeaderTitle;
                    ColDef.CellValue = F.CellValue;
                    LstColumns.Items[LstColumns.SelectedIndex] = ColDef;
                }
            }
        }

        private void CmbTaskType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbTaskType.SelectedIndex >= 0)
            {
                ListItem<ExcelFileTaskType> Item = (ListItem<ExcelFileTaskType>)CmbTaskType.SelectedItem;

                switch (Item.Value)
                {
                    case ExcelFileTaskType.AppendRow:
                        GrpInsertAppend.Visible = true;
                        GrpRead.Visible = false;
                        GrpDelete.Visible = false;
                        GrpFind.Visible = false;
                        LblInsertAtRow.Visible = false;
                        TxtInsertAtRow.Visible = false;
                        BtnDynDataInsertAtRow.Visible = false;
                        break;

                    case ExcelFileTaskType.InsertRow:
                        GrpInsertAppend.Visible = true;
                        GrpRead.Visible = false;
                        GrpDelete.Visible = false;
                        GrpFind.Visible = false;
                        LblInsertAtRow.Visible = true;
                        TxtInsertAtRow.Visible = true;
                        BtnDynDataInsertAtRow.Visible = true;
                        break;

                    case ExcelFileTaskType.ReadRow:
                        GrpInsertAppend.Visible = false;
                        GrpRead.Visible = true;
                        GrpDelete.Visible = false;
                        GrpFind.Visible = false;
                        break;

                    case ExcelFileTaskType.DeleteRow:
                        GrpInsertAppend.Visible = false;
                        GrpRead.Visible = false;
                        GrpDelete.Visible = true;
                        GrpFind.Visible = false;
                        break;

                    case ExcelFileTaskType.FindFirstRow:
                        GrpInsertAppend.Visible = false;
                        GrpRead.Visible = false;
                        GrpDelete.Visible = false;
                        GrpFind.Visible = true;
                        LblReplaceWith.Visible = false;
                        TxtReplaceWith.Visible = false;
                        break;

                    case ExcelFileTaskType.FindAllRows:
                        GrpInsertAppend.Visible = false;
                        GrpRead.Visible = false;
                        GrpDelete.Visible = false;
                        GrpFind.Visible = true;
                        LblReplaceWith.Visible = false;
                        TxtReplaceWith.Visible = false;
                        break;

                    case ExcelFileTaskType.FindAndReplace:
                        GrpInsertAppend.Visible = false;
                        GrpRead.Visible = false;
                        GrpDelete.Visible = false;
                        GrpFind.Visible = true;
                        LblReplaceWith.Visible = true;
                        TxtReplaceWith.Visible = true;
                        break;
                }
            }
        }

        private void TxtBrowseFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog F = new OpenFileDialog())
            {
                F.Filter = "xlsx files (*.xlsx)|*.xlsx";
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
        }

        private void CmbReadIntervalType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbReadIntervalType.SelectedIndex >= 0)
            {
                ListItem<ExcelReadIntervalType> Item = (ListItem<ExcelReadIntervalType>)CmbReadIntervalType.SelectedItem;

                switch (Item.Value)
                {
                    case ExcelReadIntervalType.ReadFromRowToRow:
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

                    case ExcelReadIntervalType.ReadFromRowToLastRow:
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

                    case ExcelReadIntervalType.ReadLastNRows:
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

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            using (WndColumn F = new WndColumn())
            {
                F.DynamicDataObjectSamples = DynamicDataObjectSamples;
                F.CallerID = _PluginConfig.ID;
                if (F.ShowDialog() == DialogResult.OK)
                {
                    ExcelFileColumnDefinition ColDef = new ExcelFileColumnDefinition(F.HeaderTitle, F.CellValue);
                    LstColumns.Items.Add(ColDef);
                }
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            ManageEditColumn();
        }

        private void LstColumns_DoubleClick(object sender, EventArgs e)
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
            ExcelFileColumnDefinition ColDef = (ExcelFileColumnDefinition)LstColumns.Items[SelectedIndex - 1];

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
            ExcelFileColumnDefinition ColDef = (ExcelFileColumnDefinition)LstColumns.Items[SelectedIndex];

            LstColumns.Items.RemoveAt(SelectedIndex);
            LstColumns.Items.Insert(SelectedIndex + 1, ColDef);
            LstColumns.SelectedIndex = SelectedIndex + 1;
        }

        protected override void FillConfig(IPluginInstanceConfig config)
        {
            base.FillConfig(config);

            ExcelFileTaskConfig Config = (ExcelFileTaskConfig)config;

            Config.TaskType = ((ListItem<ExcelFileTaskType>)CmbTaskType.SelectedItem).Value;
            Config.FilePath = TxtFilePathName.Text;
            Config.SheetName = TxtSheetName.Text;

            // Append / Insert
            Config.ColumnsDefinition.Clear();
            foreach (ExcelFileColumnDefinition ColDef in LstColumns.Items)
            {
                Config.ColumnsDefinition.Add(ColDef);
            }
            Config.AddHeaderIfEmpty = ChkAddHeader.Checked;
            Config.InsertAtRow = TxtInsertAtRow.Text;

            // Read
            Config.ReadLastRowOption = RdbReadLastRow.Checked;
            
            Config.ReadRowNumberOption = RdbReadRowNumber.Checked;
            Config.ReadRowNumber = TxtReadRowNumber.Text;

            Config.ReadIntervalOption = RdbReadInterval.Checked;
            Config.ReadInterval = ((ListItem<ExcelReadIntervalType>)CmbReadIntervalType.SelectedItem).Value;
            Config.ReadFromRow = TxtReadFromRow.Text;
            Config.ReadToRow = TxtReadToRow.Text;
            Config.ReadNumberOfRows = TxtNumberOfRows.Text;
            Config.NumColumnsToRead = TxtNumColumnsToRead.Text;

            // Delete
            Config.DeleteRowNumber = TxtDeleteRowNumber.Text;

            // Find / Replace
            Config.FindText = TxtFindText.Text;
            Config.ReplaceWith = TxtReplaceWith.Text;
        }

        protected override void FillForm(IPluginInstanceConfig config)
        {
            base.FillForm(config);

            ExcelFileTaskConfig Config = (ExcelFileTaskConfig)config;

            CmbTaskType.SetSelectedItem(Config.TaskType);
            TxtFilePathName.Text = Config.FilePath;
            TxtSheetName.Text = Config.SheetName;

            // Append / Insert
            LstColumns.Items.Clear();
            foreach (ExcelFileColumnDefinition ColDef in Config.ColumnsDefinition)
            {
                LstColumns.Items.Add(ColDef);
            }
            ChkAddHeader.Checked = Config.AddHeaderIfEmpty;
            TxtInsertAtRow.Text = Config.InsertAtRow;

            // Read
            RdbReadLastRow.Checked = Config.ReadLastRowOption;

            RdbReadRowNumber.Checked = Config.ReadRowNumberOption;
            TxtReadRowNumber.Text = Config.ReadRowNumber;

            RdbReadInterval.Checked = Config.ReadIntervalOption;
            CmbReadIntervalType.SetSelectedItem(Config.ReadInterval);
            TxtReadFromRow.Text = Config.ReadFromRow;
            TxtReadToRow.Text = Config.ReadToRow;
            TxtNumberOfRows.Text = Config.ReadNumberOfRows;
            TxtNumColumnsToRead.Text = Config.NumColumnsToRead;

            // Delete
            TxtDeleteRowNumber.Text = Config.DeleteRowNumber;

            // Find / Replace
            TxtFindText.Text = Config.FindText;
            TxtReplaceWith.Text = Config.ReplaceWith;
        }

        protected override bool ValidateConfig(IPluginInstanceConfig config)
        {
            base.ValidateConfig(config);

            if (DataValidationHelper.IsEmptyString(TxtFilePathName.Text))
                SetError(TxtFilePathName, Resource.TxtFieldCannotBeEmpty);

            if (DataValidationHelper.IsEmptyString(TxtSheetName.Text))
                SetError(TxtSheetName, Resource.TxtFieldCannotBeEmpty);

            if (CmbTaskType.SelectedIndex < 0)
                SetError(CmbTaskType, Resource.TxtFieldCannotBeEmpty);
            else
            {
                ExcelFileTaskType TaskType = ((ListItem<ExcelFileTaskType>)CmbTaskType.SelectedItem).Value;

                switch (TaskType)
                {
                    case ExcelFileTaskType.InsertRow:
                    case ExcelFileTaskType.AppendRow:
                        if (LstColumns.Items.Count == 0)
                        {
                            SetError(LstColumns, Resource.TxtYouMustEnterAColumn);
                        }

                        if (TaskType == ExcelFileTaskType.InsertRow)
                        {
                            if (DataValidationHelper.IsEmptyString(TxtInsertAtRow.Text))
                                SetError(TxtInsertAtRow, Resource.TxtFieldCannotBeEmpty);
                            else if (!DynamicDataParser.ContainsDynamicData(TxtInsertAtRow.Text)
                                        && !DataValidationHelper.IsInteger(TxtInsertAtRow.Text, _ExcelRowLength, _MinExcelRow, _MaxExcelRow))
                                SetError(TxtInsertAtRow, string.Format(Resource.TxtThisFieldMustBeANumberBetweenXAndY, _MinExcelRow, _MaxExcelRow));
                        }
                        break;

                    case ExcelFileTaskType.ReadRow:
                        if (RdbReadRowNumber.Checked)
                        {
                            if (DataValidationHelper.IsEmptyString(TxtReadRowNumber.Text))
                                SetError(TxtReadRowNumber, Resource.TxtFieldCannotBeEmpty);
                            else if (!DynamicDataParser.ContainsDynamicData(TxtReadRowNumber.Text)
                                        && !DataValidationHelper.IsInteger(TxtReadRowNumber.Text, _ExcelRowLength, _MinExcelRow, _MaxExcelRow))
                                SetError(TxtReadRowNumber, string.Format(Resource.TxtThisFieldMustBeANumberBetweenXAndY, _MinExcelRow, _MaxExcelRow));
                        }

                        if (RdbReadInterval.Checked)
                        {
                            if (CmbReadIntervalType.SelectedIndex < 0)
                                SetError(TxtInsertAtRow, Resource.TxtFieldCannotBeEmpty);
                            else
                            {
                                ExcelReadIntervalType IntervalType = ((ListItem<ExcelReadIntervalType>)CmbReadIntervalType.SelectedItem).Value;

                                switch (IntervalType)
                                {
                                    case ExcelReadIntervalType.ReadFromRowToRow:
                                        if (DataValidationHelper.IsEmptyString(TxtReadFromRow.Text))
                                            SetError(TxtReadFromRow, Resource.TxtFieldCannotBeEmpty);
                                        else if (!DynamicDataParser.ContainsDynamicData(TxtReadFromRow.Text)
                                                    && !DataValidationHelper.IsInteger(TxtReadFromRow.Text, _ExcelRowLength, _MinExcelRow, _MaxExcelRow))
                                            SetError(TxtReadFromRow, string.Format(Resource.TxtThisFieldMustBeANumberBetweenXAndY, _MinExcelRow, _MaxExcelRow));

                                        if (DataValidationHelper.IsEmptyString(TxtReadToRow.Text))
                                            SetError(TxtReadToRow, Resource.TxtFieldCannotBeEmpty);
                                        else if (!DynamicDataParser.ContainsDynamicData(TxtReadToRow.Text)
                                                    && !DataValidationHelper.IsInteger(TxtReadToRow.Text, _ExcelRowLength, _MinExcelRow, _MaxExcelRow))
                                            SetError(TxtReadToRow, string.Format(Resource.TxtThisFieldMustBeANumberBetweenXAndY, _MinExcelRow, _MaxExcelRow));
                                        break;

                                    case ExcelReadIntervalType.ReadFromRowToLastRow:
                                        if (DataValidationHelper.IsEmptyString(TxtReadFromRow.Text))
                                            SetError(TxtReadFromRow, Resource.TxtFieldCannotBeEmpty);
                                        else if (!DynamicDataParser.ContainsDynamicData(TxtReadFromRow.Text)
                                                    && !DataValidationHelper.IsInteger(TxtReadFromRow.Text, _ExcelRowLength, _MinExcelRow, _MaxExcelRow))
                                            SetError(TxtReadFromRow, string.Format(Resource.TxtThisFieldMustBeANumberBetweenXAndY, _MinExcelRow, _MaxExcelRow));
                                        break;

                                    case ExcelReadIntervalType.ReadLastNRows:
                                        if (DataValidationHelper.IsEmptyString(TxtNumberOfRows.Text))
                                            SetError(TxtNumberOfRows, Resource.TxtFieldCannotBeEmpty);
                                        else if (!DynamicDataParser.ContainsDynamicData(TxtNumberOfRows.Text)
                                                    && !DataValidationHelper.IsInteger(TxtNumberOfRows.Text, _ExcelRowLength, _MinExcelRow, _MaxExcelRow))
                                            SetError(TxtNumberOfRows, string.Format(Resource.TxtThisFieldMustBeANumberBetweenXAndY, _MinExcelRow, _MaxExcelRow));
                                        break;
                                }
                            }
                        }

                        if (!DataValidationHelper.IsEmptyString(TxtNumberOfRows.Text))
                        {

                        }
                        break;

                    case ExcelFileTaskType.DeleteRow:
                        if (DataValidationHelper.IsEmptyString(TxtDeleteRowNumber.Text))
                            SetError(TxtDeleteRowNumber, Resource.TxtFieldCannotBeEmpty);
                        break;

                    case ExcelFileTaskType.FindAllRows:
                    case ExcelFileTaskType.FindFirstRow:
                    case ExcelFileTaskType.FindAndReplace:
                        if (DataValidationHelper.IsEmptyString(TxtFindText.Text))
                            SetError(TxtFindText, Resource.TxtFieldCannotBeEmpty);
                        break;
                }
            }

            return GetErrorCount() == 0;
        }
    }
}
