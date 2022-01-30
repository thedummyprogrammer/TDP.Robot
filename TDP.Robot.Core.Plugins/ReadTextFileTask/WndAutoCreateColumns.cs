using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TDP.BaseServices.Infrastructure.DataValidation;
using TDP.Robot.Core;

namespace TDP.Robot.Plugins.Core.ReadTextFileTask
{
    public partial class WndAutoCreateColumns : WndPluginDetailConfigBase
    {
        private CancellationTokenSource _CancelSource;

        private void SetFormWorkingMode()
        {
            ChkFirstRowContainsHeader.Visible = false;
            ChkTreatNullStrAsNull.Visible = false;
            BtnOk.Visible = false;
            BtnCancel.Visible = false;
            TxtSampleFilePath.Enabled = false;
            BtnBrowseSampleFile.Enabled = false;
            BtnStopOperation.Visible = true;
        }

        private void SetFormDefaultMode()
        {
            ChkFirstRowContainsHeader.Visible = true;
            ChkTreatNullStrAsNull.Visible = true;
            BtnOk.Visible = true;
            BtnCancel.Visible = true;
            TxtSampleFilePath.Enabled = true;
            BtnBrowseSampleFile.Enabled = true;
            BtnStopOperation.Visible = false;
        }


        public WndAutoCreateColumns()
        {
            InitializeComponent();
        }

        public string[] DelimitersArray { get; set; }
        public bool UseDoubleQuotes { get; set; }

        public List<ReadTextFileColumnDefinition> ColumnsDefinition {get; private set; }

        private async void BtnOk_Click(object sender, EventArgs e)
        {
            ClearErrors();

            if (DataValidationHelper.IsEmptyString(TxtSampleFilePath.Text))
                SetError(TxtSampleFilePath, Resource.TxtFieldCannotBeEmpty);

            if (GetErrorCount() > 0)
                return;

            if (MessageBox.Show(Resource.TxtThisWillOverwriteCurrentColDef, Resource.TxtTheDummyProgrammerRobot, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;

            SetFormWorkingMode();

            List<ReadTextFileColumnDefinition> NewColumnDefinition = null;
            _CancelSource = new CancellationTokenSource();
            ReadTextFileTaskAutomaticColumnCreation AutoCreate = new ReadTextFileTaskAutomaticColumnCreation();

            try
            {
                NewColumnDefinition = await AutoCreate.DetectColumnsAsync(TxtSampleFilePath.Text, DelimitersArray, UseDoubleQuotes, ChkFirstRowContainsHeader.Checked, ChkTreatNullStrAsNull.Checked, _CancelSource.Token);
            }
            catch (OperationCanceledException)
            {
                SetFormDefaultMode();
                return;
            }
            catch (Exception)
            {
                MessageBox.Show(Resource.TxtAnErrorOccurredWhileProcessingTheFile, Resource.TxtTheDummyProgrammerRobot, MessageBoxButtons.OK, MessageBoxIcon.Error);
                SetFormDefaultMode();
                return;
            }

            if (NewColumnDefinition == null)
            {
                MessageBox.Show(Resource.TxtAnErrorOccurredWhileProcessingTheFile, Resource.TxtTheDummyProgrammerRobot, MessageBoxButtons.OK, MessageBoxIcon.Error);
                SetFormDefaultMode();
                return;
            }

            // Set new column definition list
            ColumnsDefinition = NewColumnDefinition;

            DialogResult = DialogResult.OK;
        }

        private void BtnBrowseSampleFile_Click(object sender, EventArgs e)
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
                    TxtSampleFilePath.Text = F.FileName;
                }
            }
        }

        private void BtnStopOperation_Click(object sender, EventArgs e)
        {
            _CancelSource.Cancel();
        }
    }
}
