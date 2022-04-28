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
using TDP.Robot.Plugins.Core.Infrastructure;

namespace TDP.Robot.Plugins.Core.Unzip
{
    public partial class WndUnzipTaskConfig : WndPluginTaskConfig
    {
        public WndUnzipTaskConfig()
        {
            InitializeComponent();

            MoveBaseTabs();

            CmbIfDestinationFileExists.Items.Add(new ListItem<IfDestFileExistsType>(IfDestFileExistsType.Overwrite, Resource.TxtOverwrite));
            CmbIfDestinationFileExists.Items.Add(new ListItem<IfDestFileExistsType>(IfDestFileExistsType.CreateWithUniqueNames, Resource.TxtCreateWithUniqueNames));
            CmbIfDestinationFileExists.Items.Add(new ListItem<IfDestFileExistsType>(IfDestFileExistsType.Fail, Resource.TxtFail));

            BtnDynDataSourceArchive.Click += BtnDynDataButton_Click;
            BtnDynDataDestination.Click += BtnDynDataButton_Click;
        }

        private void BtnBrowseSourceArchive_Click(object sender, EventArgs e)
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
                    TxtSourceArchive.Text = F.FileName;
                }
            }
        }

        private void BtnBrowseDestination_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog F = new FolderBrowserDialog())
            {
                if (F.ShowDialog() == DialogResult.OK)
                {
                    TxtDestination.Text = F.SelectedPath;
                }
            }
        }

        protected override bool ValidateConfig(IPluginInstanceConfig config)
        {
            base.ValidateConfig(config);

            if (DataValidationHelper.IsEmptyString(TxtSourceArchive.Text))
                SetError(TxtSourceArchive, Resource.TxtFieldCannotBeEmpty);

            if (DataValidationHelper.IsEmptyString(TxtDestination.Text))
                SetError(TxtDestination, Resource.TxtFieldCannotBeEmpty);

            if (CmbIfDestinationFileExists.SelectedIndex < 0)
                SetError(CmbIfDestinationFileExists, Resource.TxtFieldCannotBeEmpty);
            
            return GetErrorCount() == 0;
        }

        protected override void FillConfig(IPluginInstanceConfig config)
        {
            base.FillConfig(config);

            UnzipTaskConfig Config = (UnzipTaskConfig)config;

            Config.Source = TxtSourceArchive.Text;
            Config.Destination = TxtDestination.Text;

            Config.IfDestFileExists = ((ListItem<IfDestFileExistsType>)CmbIfDestinationFileExists.SelectedItem).Value;
        }

        protected override void FillForm(IPluginInstanceConfig config)
        {
            base.FillForm(config);

            UnzipTaskConfig Config = (UnzipTaskConfig)config;

            TxtSourceArchive.Text = Config.Source;
            TxtDestination.Text = Config.Destination;

            CmbIfDestinationFileExists.SetSelectedItem(Config.IfDestFileExists);
        }
    }
}
