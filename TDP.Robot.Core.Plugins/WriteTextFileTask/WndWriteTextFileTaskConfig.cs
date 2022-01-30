/*======================================================================================
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
using TDP.Robot.Core.DynamicData;
using TDP.Robot.Plugins.Core.Infrastructure;

namespace TDP.Robot.Plugins.Core.WriteTextFileTask
{
    public partial class WndWriteTextFileTaskConfig : WndPluginTaskConfig
    {
        public WndWriteTextFileTaskConfig()
        {
            InitializeComponent();

            MoveBaseTabs();

            CmbTaskType.Items.Add(new ListItem<WriteTextFileTaskType>(WriteTextFileTaskType.AppendRow, Resource.TxtAppendRow));
            CmbTaskType.Items.Add(new ListItem<WriteTextFileTaskType>(WriteTextFileTaskType.InsertRow, Resource.TxtInsertRow));
            CmbTaskType.SelectedIndex = 0;

            BtnDynDataFilePathName.Click += BtnDynDataButton_Click;
            BtnDynDataInsertAtRow.Click += BtnDynDataButton_Click;
        }

        private void ManageEditColumn()
        {
            if (LstColumns.SelectedIndex < 0)
            {
                MessageBox.Show(Resource.TxtYouMustSelectItem, Resource.TxtTheDummyProgrammerRobot, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            WriteTextFileColumnDefinition ColDef = (WriteTextFileColumnDefinition)LstColumns.SelectedItem;

            using (WndColumn F = new WndColumn())
            {
                F.HeaderTitle = ColDef.HeaderTitle;
                F.FieldValue = ColDef.FieldValue;
                F.FieldWidth = ColDef.FieldWidth;
                F.DynamicDataObjectSamples = DynamicDataObjectSamples;
                F.CallerID = _PluginConfig.ID;
                if (F.ShowDialog() == DialogResult.OK)
                {
                    ColDef.HeaderTitle = F.HeaderTitle;
                    ColDef.FieldValue = F.FieldValue;
                    ColDef.FieldWidth = F.FieldWidth;
                    LstColumns.Items[LstColumns.SelectedIndex] = ColDef;
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
                    WriteTextFileColumnDefinition ColDef = new WriteTextFileColumnDefinition(F.HeaderTitle, F.FieldValue, F.FieldWidth);
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
            WriteTextFileColumnDefinition ColDef = (WriteTextFileColumnDefinition)LstColumns.Items[SelectedIndex - 1];

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
            WriteTextFileColumnDefinition ColDef = (WriteTextFileColumnDefinition)LstColumns.Items[SelectedIndex];

            LstColumns.Items.RemoveAt(SelectedIndex);
            LstColumns.Items.Insert(SelectedIndex + 1, ColDef);
            LstColumns.SelectedIndex = SelectedIndex + 1;
        }

        private void ChkFormatDelimited_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkFormatDelimited.Checked)
            {
                GrpDelimiters.Enabled = true;
                ChkFormatFixedLength.Checked = false;
            }
            else
            {
                GrpDelimiters.Enabled = false;
            }
        }

        private void ChkFormatFixedLength_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkFormatFixedLength.Checked)
            {
                GrpDelimiters.Enabled = false;
                ChkFormatDelimited.Checked = false;
            }
        }

        protected override void FillConfig(IPluginInstanceConfig config)
        {
            base.FillConfig(config);

            WriteTextFileTaskConfig Config = (WriteTextFileTaskConfig)config;
            Config.TaskType = ((ListItem<WriteTextFileTaskType>)CmbTaskType.SelectedItem).Value;
            Config.FilePath = TxtFilePathName.Text;

            // Append / Insert
            Config.ColumnsDefinition.Clear();
            foreach (WriteTextFileColumnDefinition ColDef in LstColumns.Items)
            {
                Config.ColumnsDefinition.Add(ColDef);
            }

            Config.FormatAsDelimitedFile = ChkFormatDelimited.Checked;
            Config.DelimiterTab = ChkDelTab.Checked;
            Config.DelimiterSemicolon = ChkDelSemicolon.Checked;
            Config.DelimiterComma = ChkDelComma.Checked;
            Config.DelimiterSpace = ChkDelSpace.Checked;
            Config.DelimiterOther = ChkDelOther.Checked;
            Config.DelimiterOtherChar = TxtDelOther.Text;
            Config.EncloseInDoubleQuotes = ChkUseDoubleQuotes.Checked;

            Config.FormatAsFixedLengthColumnsFile = ChkFormatFixedLength.Checked;
            Config.AddHeaderIfEmpty = ChkAddHeader.Checked;
            Config.InsertAtRow = TxtInsertAtRow.Text;
        }

        protected override void FillForm(IPluginInstanceConfig config)
        {
            base.FillForm(config);

            WriteTextFileTaskConfig Config = (WriteTextFileTaskConfig)config;
            CmbTaskType.SetSelectedItem(Config.TaskType);
            TxtFilePathName.Text = Config.FilePath;

            LstColumns.Items.Clear();
            foreach (WriteTextFileColumnDefinition ColDef in Config.ColumnsDefinition)
            {
                LstColumns.Items.Add(ColDef);
            }

            ChkFormatDelimited.Checked = Config.FormatAsDelimitedFile;
            ChkDelTab.Checked = Config.DelimiterTab;
            ChkDelSemicolon.Checked = Config.DelimiterSemicolon;
            ChkDelComma.Checked = Config.DelimiterComma;
            ChkDelSpace.Checked = Config.DelimiterSpace;
            ChkDelOther.Checked = Config.DelimiterOther;
            TxtDelOther.Text = Config.DelimiterOtherChar;
            ChkUseDoubleQuotes.Checked = Config.EncloseInDoubleQuotes;

            ChkFormatFixedLength.Checked = Config.FormatAsFixedLengthColumnsFile;
            ChkAddHeader.Checked = Config.AddHeaderIfEmpty;
            TxtInsertAtRow.Text = Config.InsertAtRow;
        }

        protected override bool ValidateConfig(IPluginInstanceConfig config)
        {
            base.ValidateConfig(config);

            if (DataValidationHelper.IsEmptyString(TxtFilePathName.Text))
                SetError(TxtFilePathName, Resource.TxtFieldCannotBeEmpty);

            if (LstColumns.Items.Count == 0)
            {
                SetError(LstColumns, Resource.TxtYouMustEnterAtLeastOneField);
            }

            if (ChkFormatDelimited.Checked)
            {
                if (!ChkDelTab.Checked && !ChkDelSemicolon.Checked && !ChkDelComma.Checked
                    && !ChkDelSpace.Checked && !ChkDelOther.Checked)
                {
                    SetError(ChkFormatDelimited, Resource.TxtYouMustSelectADelimiter);
                }

                if (ChkDelOther.Checked && DataValidationHelper.IsEmptyString(TxtDelOther.Text))
                {
                    SetError(ChkDelOther, Resource.TxtYouMustSpecifyACustomDelimiter);
                }
            }

            if (ChkFormatFixedLength.Checked)
            {
                foreach (WriteTextFileColumnDefinition Col in LstColumns.Items)
                {
                    if (DataValidationHelper.IsEmptyString(Col.FieldWidth))
                    {
                        SetError(LstColumns, Resource.TxtYouMustEnterAColumnWidthForAll);
                        break;
                    }
                }
            }

            ListItem<WriteTextFileTaskType> Item = (ListItem<WriteTextFileTaskType>)CmbTaskType.SelectedItem;
            if (Item.Value == WriteTextFileTaskType.InsertRow)
            {
                if (DataValidationHelper.IsEmptyString(TxtInsertAtRow.Text))
                    SetError(TxtInsertAtRow, Resource.TxtFieldCannotBeEmpty);
                else if (!DynamicDataParser.ContainsDynamicData(TxtInsertAtRow.Text)
                            && !DataValidationHelper.IsInteger(TxtInsertAtRow.Text, int.MaxValue.ToString().Length, 0, int.MaxValue))
                    SetError(TxtInsertAtRow, string.Format(Resource.TxtThisFieldMustBeANumberBetweenXAndY, 0, int.MaxValue));
            }

            return GetErrorCount() == 0;
        }

        private void CmbTaskType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbTaskType.SelectedIndex >= 0)
            {
                ListItem<WriteTextFileTaskType> Item = (ListItem<WriteTextFileTaskType>)CmbTaskType.SelectedItem;

                switch (Item.Value)
                {
                    case WriteTextFileTaskType.AppendRow:
                        LblInsertAtRow.Visible = false;
                        TxtInsertAtRow.Visible = false;
                        BtnDynDataInsertAtRow.Visible = false;
                        break;

                    case WriteTextFileTaskType.InsertRow:
                        LblInsertAtRow.Visible = true;
                        TxtInsertAtRow.Visible = true;
                        BtnDynDataInsertAtRow.Visible = true;
                        break;
                }
            }
        }

        private void BtnBrowseFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog F = new OpenFileDialog())
            {
                F.Filter = "Text files (*.txt)|*.txt|CSV files (*.csv)|*.csv";
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
    }
}
