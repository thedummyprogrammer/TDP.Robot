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

using System.Windows.Forms;
using TDP.BaseServices.Infrastructure.DataValidation;
using TDP.Robot.Core;
using TDP.Robot.Plugins.Core.Infrastructure;

namespace TDP.Robot.Plugins.Core.FileSystemEvent
{
    public partial class WndFolderToMonitor : WndPluginDetailConfigBase
    {
        public string Path
        {
            get { return TxtFolderPath.Text; }
            set { TxtFolderPath.Text = value; }
        }

        public bool MonitorSubfolders
        {
            get { return ChkMonitorSubfolders.Checked; }
            set { ChkMonitorSubfolders.Checked = value; }
        }

        public MonitorActionType MonitorAction
        {
            get { return ((ListItem<MonitorActionType>)CmbActionToMonitor.SelectedItem).Value; }
            set { CmbActionToMonitor.SetSelectedItem(value); }
        }

        public WndFolderToMonitor()
        {
            InitializeComponent();

            CmbActionToMonitor.Items.Add(new ListItem<MonitorActionType>(MonitorActionType.NewFiles, Resource.TxtNewFiles));
            CmbActionToMonitor.Items.Add(new ListItem<MonitorActionType>(MonitorActionType.ModifiedFiles, Resource.TxtModifiedFiles));
            CmbActionToMonitor.Items.Add(new ListItem<MonitorActionType>(MonitorActionType.DeletedFiles, Resource.TxtDeletedFiles));
            CmbActionToMonitor.SelectedIndex = 0;
        }

        private void BtnBrowsePath_Click(object sender, System.EventArgs e)
        {
            using (FolderBrowserDialog F = new FolderBrowserDialog())
            {
                if (F.ShowDialog() == DialogResult.OK)
                {
                    TxtFolderPath.Text = F.SelectedPath;
                }
            }
        }

        private void BtnOk_Click(object sender, System.EventArgs e)
        {
            ClearErrors();

            if (DataValidationHelper.IsEmptyString(TxtFolderPath.Text))
                SetError(TxtFolderPath, Resource.TxtFieldCannotBeEmpty);

            if (CmbActionToMonitor.SelectedIndex < 0)
                SetError(CmbActionToMonitor, Resource.TxtFieldCannotBeEmpty);

            if (GetErrorCount() == 0)
                DialogResult = DialogResult.OK;
        }
    }
}
