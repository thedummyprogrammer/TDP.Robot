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

using System.Windows.Forms;
using TDP.BaseServices.Infrastructure.DataValidation;
using TDP.Robot.Core;

namespace TDP.Robot.Plugins.Core.RunProgramTask
{
    public partial class WndRunProgramTaskWindowConfig : WndPluginTaskConfig
    {
        public WndRunProgramTaskWindowConfig()
        {
            InitializeComponent();

            MoveBaseTabs();

            BtnDynDataProgramPath.Click += BtnDynDataButton_Click;
            BtnDynDataParameters.Click += BtnDynDataButton_Click;
            BtnDynDataWorkingFolder.Click += BtnDynDataButton_Click;
        }

        protected override void FillConfig(IPluginInstanceConfig config)
        {
            base.FillConfig(config);

            RunProgramTaskConfig Config = (RunProgramTaskConfig)config;

            Config.ProgramPath = TxtProgramPath.Text;
            Config.Parameters = TxtParameters.Text;
            Config.WorkingFolder = TxtWorkingFolder.Text;
        }

        protected override void FillForm(IPluginInstanceConfig config)
        {
            base.FillForm(config);

            RunProgramTaskConfig Config = (RunProgramTaskConfig)config;

            TxtProgramPath.Text = Config.ProgramPath;
            TxtParameters.Text = Config.Parameters;
            TxtWorkingFolder.Text = Config.WorkingFolder;
        }

        protected override bool ValidateConfig(IPluginInstanceConfig config)
        {
            base.ValidateConfig(config);

            if (DataValidationHelper.IsEmptyString(TxtProgramPath.Text))
                SetError(TxtProgramPath, Resource.TxtFieldCannotBeEmpty);

            return GetErrorCount() == 0;
        }

        private void BtnBrowseProgramPath_Click(object sender, System.EventArgs e)
        {
            using (OpenFileDialog F = new OpenFileDialog())
            {
                F.Filter = "All file types (*.*)|*.*";
                F.RestoreDirectory = true;
                F.CheckPathExists = false;
                F.CheckFileExists = false;

                if (F.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    TxtProgramPath.Text = F.FileName;
                }
            }
        }

        private void BtnBrowseWorkingFolder_Click(object sender, System.EventArgs e)
        {
            using (FolderBrowserDialog F = new FolderBrowserDialog())
            {
                if (F.ShowDialog() == DialogResult.OK)
                {
                    TxtWorkingFolder.Text = F.SelectedPath;
                }
            }
        }
    }
}
