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
using TDP.Robot.Core;
using TDP.Robot.Plugins.Core.Infrastructure;

namespace TDP.Robot.Plugins.Core.FileSystemTask
{
    public partial class WndFileSystemTaskConfig : WndPluginTaskConfig
    {
        public WndFileSystemTaskConfig()
        {
            InitializeComponent();

            MoveBaseTabs();

            CmbCommand.Items.Add(new ListItem<FileSystemTaskCommandType>(FileSystemTaskCommandType.Copy, Resource.TxtCopy));
            CmbCommand.Items.Add(new ListItem<FileSystemTaskCommandType>(FileSystemTaskCommandType.Delete, Resource.TxtDelete));
            CmbCommand.SelectedIndex = 0;
        }

        private void ManageEditCopyPath()
        {
            if (LstCopyPaths.SelectedIndex < 0)
            {
                MessageBox.Show(Resource.TxtYouMustSelectItem, Resource.TxtTheDummyProgrammerRobot, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            FileSystemTaskCopyItem CopyItem = (FileSystemTaskCopyItem)LstCopyPaths.SelectedItem;

            using (WndCopyItem F = new WndCopyItem())
            {
                F.SourcePath = CopyItem.SourcePath;
                F.DestinationPath = CopyItem.DestinationPath;
                F.OverwriteFileIfExists = CopyItem.OverwriteFileIfExists;
                F.RecursivelyCopyDirectories = CopyItem.RecursivelyCopyDirectories;
                F.DynamicDataObjectSamples = DynamicDataObjectSamples;
                F.CallerID = _PluginConfig.ID;
                if (F.ShowDialog() == DialogResult.OK)
                {
                    CopyItem.SourcePath= F.SourcePath;
                    CopyItem.DestinationPath = F.DestinationPath;
                    CopyItem.OverwriteFileIfExists = F.OverwriteFileIfExists;
                    CopyItem.RecursivelyCopyDirectories = F.RecursivelyCopyDirectories;
                    LstCopyPaths.Items[LstCopyPaths.SelectedIndex] = CopyItem;
                }
            }
        }

        private void ManageEditDeletePath()
        {
            if (LstDeletePaths.SelectedIndex < 0)
            {
                MessageBox.Show(Resource.TxtYouMustSelectItem, Resource.TxtTheDummyProgrammerRobot, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            FileSystemTaskDeleteItem DeleteItem = (FileSystemTaskDeleteItem)LstDeletePaths.SelectedItem;

            using (WndDeleteItem F = new WndDeleteItem())
            {
                F.DeletePath = DeleteItem.DeletePath;
                F.DynamicDataObjectSamples = DynamicDataObjectSamples;
                F.CallerID = _PluginConfig.ID;
                if (F.ShowDialog() == DialogResult.OK)
                {
                    DeleteItem.DeletePath = F.DeletePath;
                    LstDeletePaths.Items[LstDeletePaths.SelectedIndex] = DeleteItem;
                }
            }
        }

        protected override void FillConfig(IPluginInstanceConfig config)
        {
            base.FillConfig(config);

            FileSystemTaskConfig Config = (FileSystemTaskConfig)config;

            Config.Command = ((ListItem<FileSystemTaskCommandType>)CmbCommand.SelectedItem).Value;

            Config.CopyItems.Clear();
            foreach (FileSystemTaskCopyItem CopyItem in LstCopyPaths.Items)
            {
                Config.CopyItems.Add(CopyItem);
            }

            Config.DeleteItems.Clear();
            foreach (FileSystemTaskDeleteItem DeleteItem in LstDeletePaths.Items)
            {
                Config.DeleteItems.Add(DeleteItem);
            }
        }

        protected override void FillForm(IPluginInstanceConfig config)
        {
            base.FillForm(config);

            FileSystemTaskConfig Config = (FileSystemTaskConfig)config;

            CmbCommand.SetSelectedItem(Config.Command);

            LstCopyPaths.Items.Clear();
            foreach (FileSystemTaskCopyItem CopyItem in Config.CopyItems)
            {
                LstCopyPaths.Items.Add(CopyItem);
            }

            LstDeletePaths.Items.Clear();
            foreach (FileSystemTaskDeleteItem DeleteItem in Config.DeleteItems)
            {
                LstDeletePaths.Items.Add(DeleteItem);
            }
        }

        protected override bool ValidateConfig(IPluginInstanceConfig config)
        {
            if (CmbCommand.SelectedIndex < 0)
                SetError(CmbCommand, Resource.TxtFieldCannotBeEmpty);

            if (GrpCopyMove.Visible)
            {
                if (LstCopyPaths.Items.Count == 0)
                    SetError(LstCopyPaths, Resource.TxtFieldCannotBeEmpty);
            }
            else if (GrpDelete.Visible)
            {
                if (LstDeletePaths.Items.Count == 0)
                    SetError(LstDeletePaths, Resource.TxtFieldCannotBeEmpty);
            }

            return GetErrorCount() == 0;
        }

        private void CmbCommand_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListItem<FileSystemTaskCommandType> Item = (ListItem<FileSystemTaskCommandType>)CmbCommand.SelectedItem;

            switch (Item.Value)
            {
                case FileSystemTaskCommandType.Copy:
                    GrpCopyMove.Visible = true;
                    GrpDelete.Visible = false;
                    break;

                case FileSystemTaskCommandType.Delete:
                    GrpCopyMove.Visible = false;
                    GrpDelete.Visible = true;
                    break;
            }
        }

        private void BtnAddCopyPath_Click(object sender, EventArgs e)
        {
            using (WndCopyItem F = new WndCopyItem())
            {
                F.DynamicDataObjectSamples = DynamicDataObjectSamples;
                F.CallerID = _PluginConfig.ID;
                if (F.ShowDialog() == DialogResult.OK)
                {
                    FileSystemTaskCopyItem CopyItem = new FileSystemTaskCopyItem(F.SourcePath, F.DestinationPath, F.OverwriteFileIfExists, F.RecursivelyCopyDirectories);
                    LstCopyPaths.Items.Add(CopyItem);
                }
            }
        }

        private void BtnEditCopyPath_Click(object sender, EventArgs e)
        {
            ManageEditCopyPath();
        }

        private void LstCopyPaths_DoubleClick(object sender, EventArgs e)
        {
            ManageEditCopyPath();
        }

        private void BtnRemoveCopyPath_Click(object sender, EventArgs e)
        {
            if (LstCopyPaths.SelectedIndex < 0)
            {
                MessageBox.Show(Resource.TxtYouMustSelectItem, Resource.TxtTheDummyProgrammerRobot, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            LstCopyPaths.Items.RemoveAt(LstCopyPaths.SelectedIndex);
        }

        private void BtnAddDeletePath_Click(object sender, EventArgs e)
        {
            using (WndDeleteItem F = new WndDeleteItem())
            {
                F.DynamicDataObjectSamples = DynamicDataObjectSamples;
                F.CallerID = _PluginConfig.ID;
                if (F.ShowDialog() == DialogResult.OK)
                {
                    FileSystemTaskDeleteItem DeleteItem = new FileSystemTaskDeleteItem(F.DeletePath);
                    LstDeletePaths.Items.Add(DeleteItem);
                }
            }
        }

        private void BtnEditDeletePath_Click(object sender, EventArgs e)
        {
            ManageEditDeletePath();
        }

        private void BtnRemoveDeletePath_Click(object sender, EventArgs e)
        {
            if (LstDeletePaths.SelectedIndex < 0)
            {
                MessageBox.Show(Resource.TxtYouMustSelectItem, Resource.TxtTheDummyProgrammerRobot, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            LstDeletePaths.Items.RemoveAt(LstDeletePaths.SelectedIndex);
        }

        private void LstDeletePaths_DoubleClick(object sender, EventArgs e)
        {
            ManageEditDeletePath();
        }
    }
}
