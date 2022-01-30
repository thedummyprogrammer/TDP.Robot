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
using System.Windows.Forms;
using TDP.BaseServices.Infrastructure.DataValidation;
using TDP.Robot.Core;
using TDP.Robot.Core.DynamicData;
using TDP.Robot.JobEditor.Infrastructure.Workspace;
using TDP.Robot.JobEditor.Infrastructure.Workspace.Abstract;
using TDP.Robot.JobEditor.Properties;

namespace TDP.Robot.JobEditor
{
    partial class WndLineProperties : Form
    {
        private const int _WaitSecondsMaxLength = 3;
        private const int _WaitSecondsMinValue = 1;
        private const int _WaitSecondsMaxValue = 999;


        public IWorkspaceItem Item { get; set; }
        /*
        public int ObjectID { get; set; }

        public string ObjectName { get; set; }
        */

        public List<DynamicDataSample> DynamicDataSampleList { get; set; }

        protected List<IWorkspaceExecCondition> _ExecuteConditions;

        public List<IWorkspaceExecCondition> ExecutionConditions
        {
            get { return _ExecuteConditions; }
            set 
            { 
                _ExecuteConditions = value;
                LstExecConditions.Items.Clear();
                foreach (IWorkspaceExecCondition ExecCond in _ExecuteConditions)
                {
                    LstExecConditions.Items.Add(ExecCond);
                }
            }
        }

        protected List<IWorkspaceExecCondition> _DontExecuteConditions;

        public List<IWorkspaceExecCondition> DontExecuteConditions
        {
            get { return _DontExecuteConditions; }
            set
            {
                _DontExecuteConditions = value;
                LstDontExecConditions.Items.Clear();
                foreach (IWorkspaceExecCondition ExecCond in _DontExecuteConditions)
                {
                    LstDontExecConditions.Items.Add(ExecCond);
                }
            }
        }

        public int? WaitSeconds 
        { 
            get 
            {
                if (DataValidationHelper.IsEmptyString(TxtWaitSeconds.Text))
                    return null;

                return int.Parse(TxtWaitSeconds.Text); 
            } 
            set
            {
                if (value == null)
                {
                    ChkWait.Checked = false;
                    TxtWaitSeconds.Text = string.Empty;
                    return;
                }

                ChkWait.Checked = (value > 0);
                TxtWaitSeconds.Text = value.ToString();
            }
        }

        public bool Disable 
        { 
            get
            {
                return ChkDisable.Checked;
            }
            set
            {
                ChkDisable.Checked = value;
            }
        }

        public WndLineProperties()
        {
            InitializeComponent();
        }

        private void ManageEditExecCondition()
        {
            if (LstExecConditions.SelectedIndex < 0)
            {
                MessageBox.Show(Resources.TxtYouMustSelectItem, Resources.TxtTheDummyProgrammerRobot, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (WndExecutionCondition WndExecCond = new WndExecutionCondition())
            {
                WndExecCond.Item = Item;
                WndExecCond.DynamicDataSampleList = DynamicDataSampleList;

                WorkspaceExecCondition ExecCondition = (WorkspaceExecCondition)LstExecConditions.SelectedItem;
                WndExecCond.DynamicData = ExecCondition.DynamicDataCode;
                WndExecCond.Operator = ExecCondition.Operator;
                WndExecCond.Value = ExecCondition.MinValue;
                WndExecCond.MaxValue = ExecCondition.MaxValue;

                if (WndExecCond.ShowDialog() == DialogResult.OK)
                {
                    ExecCondition = new WorkspaceExecCondition(Item, WndExecCond.DynamicData, WndExecCond.Operator, WndExecCond.Value, WndExecCond.MaxValue);

                    LstExecConditions.Items[LstExecConditions.SelectedIndex] = ExecCondition;
                }
            }
        }

        private void BtnAddExecCondition_Click(object sender, EventArgs e)
        {
            using (WndExecutionCondition WndExecCond = new WndExecutionCondition())
            {
                WndExecCond.Item = Item;
                WndExecCond.DynamicDataSampleList = DynamicDataSampleList;
                if (WndExecCond.ShowDialog() == DialogResult.OK)
                {
                    WorkspaceExecCondition ExecCondition = new WorkspaceExecCondition(Item, WndExecCond.DynamicData, WndExecCond.Operator, WndExecCond.Value, WndExecCond.MaxValue);

                    LstExecConditions.Items.Add(ExecCondition);
                }
            }
        }

        private void BtnEditExecCondition_Click(object sender, EventArgs e)
        {
            ManageEditExecCondition();
        }

        private void LstExecConditions_DoubleClick(object sender, EventArgs e)
        {
            ManageEditExecCondition();
        }

        private void BtnRemoveExecCondition_Click(object sender, EventArgs e)
        {
            if (LstExecConditions.SelectedIndex < 0)
            {
                MessageBox.Show(Resources.TxtYouMustSelectItem, Resources.TxtTheDummyProgrammerRobot, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            LstExecConditions.Items.RemoveAt(LstExecConditions.SelectedIndex);
        }

        private void ManageEditDontExecCondition()
        {
            if (LstDontExecConditions.SelectedIndex < 0)
            {
                MessageBox.Show(Resources.TxtYouMustSelectItem, Resources.TxtTheDummyProgrammerRobot, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (WndExecutionCondition WndExecCond = new WndExecutionCondition())
            {
                WndExecCond.Item = Item;
                WndExecCond.DynamicDataSampleList = DynamicDataSampleList;

                WorkspaceExecCondition ExecCondition = (WorkspaceExecCondition)LstDontExecConditions.SelectedItem;
                WndExecCond.DynamicData = ExecCondition.DynamicDataCode;
                WndExecCond.Operator = ExecCondition.Operator;
                WndExecCond.Value = ExecCondition.MinValue;
                WndExecCond.MaxValue = ExecCondition.MaxValue;

                if (WndExecCond.ShowDialog() == DialogResult.OK)
                {
                    ExecCondition = new WorkspaceExecCondition(Item, WndExecCond.DynamicData, WndExecCond.Operator, WndExecCond.Value, WndExecCond.MaxValue);

                    LstDontExecConditions.Items[LstDontExecConditions.SelectedIndex] = ExecCondition;
                }
            }
        }

        private void BtnAddDontExecCondition_Click(object sender, EventArgs e)
        {
            using (WndExecutionCondition WndExecCond = new WndExecutionCondition())
            {
                WndExecCond.Item = Item;
                WndExecCond.DynamicDataSampleList = DynamicDataSampleList;
                if (WndExecCond.ShowDialog() == DialogResult.OK)
                {
                    WorkspaceExecCondition ExecCondition = new WorkspaceExecCondition(Item, WndExecCond.DynamicData, WndExecCond.Operator, WndExecCond.Value, WndExecCond.MaxValue);

                    LstDontExecConditions.Items.Add(ExecCondition);
                }
            }
        }

        private void BtnEditDontExecCondition_Click(object sender, EventArgs e)
        {
            ManageEditDontExecCondition();
        }

        private void LstDontExecConditions_DoubleClick(object sender, EventArgs e)
        {
            ManageEditDontExecCondition();
        }

        private void BtnRemoveDontExecCondition_Click(object sender, EventArgs e)
        {
            if (LstDontExecConditions.SelectedIndex < 0)
            {
                MessageBox.Show(Resources.TxtYouMustSelectItem, Resources.TxtTheDummyProgrammerRobot, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            LstDontExecConditions.Items.RemoveAt(LstDontExecConditions.SelectedIndex);
        }
        private void ChkWait_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkWait.Checked)
            {
                TxtWaitSeconds.Enabled = true;
            }
            else
            {
                TxtWaitSeconds.Enabled = false;
                TxtWaitSeconds.Text = string.Empty;
            }
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            int ErrorCount = 0;
            ErrorProvider.Clear();

            if (ChkWait.Checked && DataValidationHelper.IsEmptyString(TxtWaitSeconds.Text))
            {
                ErrorCount++;
                ErrorProvider.SetError(TxtWaitSeconds, Resources.TxtFieldCannotBeEmpty);
            }

            if (!DataValidationHelper.IsEmptyString(TxtWaitSeconds.Text)
                && !DataValidationHelper.IsInteger(TxtWaitSeconds.Text, _WaitSecondsMaxLength, _WaitSecondsMinValue, _WaitSecondsMaxValue))
            {
                ErrorCount++;
                ErrorProvider.SetError(TxtWaitSeconds, string.Format(Resources.TxtMustBeANumberBetweenXAndY, _WaitSecondsMinValue, _WaitSecondsMaxValue));
            }

            if (LstExecConditions.Items.Count == 0)
            {
                ErrorCount++;
                ErrorProvider.SetError(LstExecConditions, Resources.TxtYouMustEnterAnExecCondition);
            }

            if (ErrorCount > 0)
            {
                MessageBox.Show(Resources.TxtThereAreSomeErrors, Resources.TxtTheDummyProgrammerRobot, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _ExecuteConditions.Clear();
            foreach (IWorkspaceExecCondition EC in LstExecConditions.Items)
            {
                _ExecuteConditions.Add(EC);
            }

            _DontExecuteConditions.Clear();
            foreach (IWorkspaceExecCondition EC in LstDontExecConditions.Items)
            {
                _DontExecuteConditions.Add(EC);
            }

            DialogResult = DialogResult.OK;
        }
    }
}
