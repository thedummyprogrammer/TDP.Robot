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
using TDP.Robot.Core;

namespace TDP.Robot.Plugins.Core.FileSystemEvent
{
    public partial class WndFileSystemEventConfig : WndPluginEventConfig
    {
        public WndFileSystemEventConfig()
        {
            InitializeComponent();
        }

        private void ManageEditFolder()
        {
            if (LstFolders.SelectedIndex < 0)
            {
                MessageBox.Show(Resource.TxtYouMustSelectItem, Resource.TxtTheDummyProgrammerRobot, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            FolderToMonitor Folder = (FolderToMonitor)LstFolders.SelectedItem;

            using (WndFolderToMonitor F = new WndFolderToMonitor())
            {
                F.Path = Folder.Path;
                F.MonitorAction = Folder.MonitorAction;
                F.MonitorSubfolders = Folder.MonitorSubFolders;
                F.DynamicDataObjectSamples = DynamicDataObjectSamples;
                F.CallerID = _PluginConfig.ID;
                if (F.ShowDialog() == DialogResult.OK)
                {
                    Folder.Path = F.Path;
                    Folder.MonitorAction = F.MonitorAction;
                    Folder.MonitorSubFolders = F.MonitorSubfolders;
                    LstFolders.Items[LstFolders.SelectedIndex] = Folder;
                }
            }
        }

        protected override void FillConfig(IPluginInstanceConfig config)
        {
            base.FillConfig(config);

            FileSystemEventConfig Config = (FileSystemEventConfig)config;

            Config.FoldersToMonitor.Clear();
            foreach (FolderToMonitor Folder in LstFolders.Items)
            {
                Config.FoldersToMonitor.Add(Folder);
            }
        }

        protected override void FillForm(IPluginInstanceConfig config)
        {
            base.FillForm(config);

            FileSystemEventConfig Config = (FileSystemEventConfig)config;

            LstFolders.Items.Clear();
            foreach (FolderToMonitor ColDef in Config.FoldersToMonitor)
            {
                LstFolders.Items.Add(ColDef);
            }
        }

        protected override bool ValidateConfig(IPluginInstanceConfig config)
        {
            base.ValidateConfig(config);

            if (LstFolders.Items.Count == 0)
            {
                SetError(LstFolders, Resource.TxtYouMustEnterAFolder);
            }

            return GetErrorCount() == 0;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            using (WndFolderToMonitor F = new WndFolderToMonitor())
            {
                F.DynamicDataObjectSamples = DynamicDataObjectSamples;
                F.CallerID = _PluginConfig.ID;
                if (F.ShowDialog() == DialogResult.OK)
                {
                    FolderToMonitor Folder = new FolderToMonitor(F.Path, F.MonitorSubfolders, F.MonitorAction);
                    LstFolders.Items.Add(Folder);
                }
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            ManageEditFolder();
        }

        private void LstFolders_DoubleClick(object sender, EventArgs e)
        {
            ManageEditFolder();
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            if (LstFolders.SelectedIndex < 0)
            {
                MessageBox.Show(Resource.TxtYouMustSelectItem, Resource.TxtTheDummyProgrammerRobot, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            LstFolders.Items.RemoveAt(LstFolders.SelectedIndex);
        }
    }
}
