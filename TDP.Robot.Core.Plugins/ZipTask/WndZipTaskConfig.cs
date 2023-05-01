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
using TDP.Robot.Plugins.Core.Infrastructure;

namespace TDP.Robot.Plugins.Core.ZipTask
{
    public partial class WndZipTaskConfig : WndPluginTaskConfig
    {
        public WndZipTaskConfig()
        {
            InitializeComponent();

            MoveBaseTabs();

            CmbIfArchiveExists.Items.Add(new ListItem<IfArchiveExistsType>(IfArchiveExistsType.AddOrOverwriteFilesInTheArchive, Resource.TxtAddOrOverwriteFilesInTheArchive));
            CmbIfArchiveExists.Items.Add(new ListItem<IfArchiveExistsType>(IfArchiveExistsType.CreateWithUniqueNames, Resource.TxtCreateWithUniqueNames));
            CmbIfArchiveExists.Items.Add(new ListItem<IfArchiveExistsType>(IfArchiveExistsType.Fail, Resource.TxtFail));

            CmbCompressionLevel.Items.Add(new ListItem<CompressionLevelType>(CompressionLevelType.Low, Resource.TxtLow));
            CmbCompressionLevel.Items.Add(new ListItem<CompressionLevelType>(CompressionLevelType.Medium, Resource.TxtMedium));
            CmbCompressionLevel.Items.Add(new ListItem<CompressionLevelType>(CompressionLevelType.High, Resource.TxtHigh));

            BtnDynDataSource.Click += BtnDynDataButton_Click;
            BtnDynDataDestArchive.Click += BtnDynDataButton_Click;
        }

        protected override bool ValidateConfig(IPluginInstanceConfig config)
        {
            base.ValidateConfig(config);

            if (DataValidationHelper.IsEmptyString(TxtSource.Text))
                SetError(TxtSource, Resource.TxtFieldCannotBeEmpty);

            if (DataValidationHelper.IsEmptyString(TxtDestArchive.Text))
                SetError(TxtDestArchive, Resource.TxtFieldCannotBeEmpty);

            if (CmbIfArchiveExists.SelectedIndex < 0)
                SetError(CmbIfArchiveExists, Resource.TxtFieldCannotBeEmpty);

            if (CmbCompressionLevel.SelectedIndex < 0)
                SetError(CmbCompressionLevel, Resource.TxtFieldCannotBeEmpty);

            return GetErrorCount() == 0;
        }

        protected override void FillConfig(IPluginInstanceConfig config)
        {
            base.FillConfig(config);

            ZipTaskConfig Config = (ZipTaskConfig)config;

            Config.Source = TxtSource.Text;
            Config.Destination = TxtDestArchive.Text;

            Config.IncludeFilesInSubFolders = ChkIncludeFilesInSubFolders.Checked;
            Config.StoreFullPath = ChkStoreFullpath.Checked;
            Config.IncludeFilesInSubFolders = ChkIncludeFilesInSubFolders.Checked;

            Config.IfArchiveExists = ((ListItem<IfArchiveExistsType>)CmbIfArchiveExists.SelectedItem).Value;
            Config.CompressionLevel = ((ListItem<CompressionLevelType>)CmbCompressionLevel.SelectedItem).Value;
        }

        protected override void FillForm(IPluginInstanceConfig config)
        {
            base.FillForm(config);

            ZipTaskConfig Config = (ZipTaskConfig)config;

            TxtSource.Text = Config.Source;
            TxtDestArchive.Text = Config.Destination;

            ChkIncludeFilesInSubFolders.Checked = Config.IncludeFilesInSubFolders;
            ChkStoreFullpath.Checked = Config.StoreFullPath;
            ChkIncludeFilesInSubFolders.Checked = Config.IncludeFilesInSubFolders;

            CmbIfArchiveExists.SetSelectedItem(Config.IfArchiveExists);
            CmbCompressionLevel.SetSelectedItem(Config.CompressionLevel);
        }

        private void BtnBrowseSource_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog F = new FolderBrowserDialog())
            {
                if (F.ShowDialog() == DialogResult.OK)
                {
                    TxtSource.Text = F.SelectedPath;
                }
            }
        }

        private void BtnBrowseDestArchive_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog F = new OpenFileDialog())
            {
                F.Filter = "zip files (*.zip)|*.zip";
                F.RestoreDirectory = true;
                F.CheckPathExists = false;
                F.CheckFileExists = false;

                if (F.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    TxtDestArchive.Text = F.FileName;
                }
            }
        }
    }
}
