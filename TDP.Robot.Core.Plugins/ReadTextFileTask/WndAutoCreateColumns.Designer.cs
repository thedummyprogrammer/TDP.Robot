
namespace TDP.Robot.Plugins.Core.ReadTextFileTask
{
    partial class WndAutoCreateColumns
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.TxtSampleFilePath = new System.Windows.Forms.TextBox();
            this.BtnBrowseSampleFile = new System.Windows.Forms.Button();
            this.ChkFirstRowContainsHeader = new System.Windows.Forms.CheckBox();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnOk = new System.Windows.Forms.Button();
            this.ChkTreatNullStrAsNull = new System.Windows.Forms.CheckBox();
            this.BtnStopOperation = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sample file";
            // 
            // TxtSampleFilePath
            // 
            this.TxtSampleFilePath.Location = new System.Drawing.Point(85, 18);
            this.TxtSampleFilePath.Name = "TxtSampleFilePath";
            this.TxtSampleFilePath.Size = new System.Drawing.Size(321, 20);
            this.TxtSampleFilePath.TabIndex = 1;
            // 
            // BtnBrowseSampleFile
            // 
            this.BtnBrowseSampleFile.Location = new System.Drawing.Point(412, 16);
            this.BtnBrowseSampleFile.Name = "BtnBrowseSampleFile";
            this.BtnBrowseSampleFile.Size = new System.Drawing.Size(45, 23);
            this.BtnBrowseSampleFile.TabIndex = 2;
            this.BtnBrowseSampleFile.Text = "...";
            this.BtnBrowseSampleFile.UseVisualStyleBackColor = true;
            this.BtnBrowseSampleFile.Click += new System.EventHandler(this.BtnBrowseSampleFile_Click);
            // 
            // ChkFirstRowContainsHeader
            // 
            this.ChkFirstRowContainsHeader.AutoSize = true;
            this.ChkFirstRowContainsHeader.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ChkFirstRowContainsHeader.Checked = true;
            this.ChkFirstRowContainsHeader.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkFirstRowContainsHeader.Location = new System.Drawing.Point(24, 53);
            this.ChkFirstRowContainsHeader.Name = "ChkFirstRowContainsHeader";
            this.ChkFirstRowContainsHeader.Size = new System.Drawing.Size(144, 17);
            this.ChkFirstRowContainsHeader.TabIndex = 4;
            this.ChkFirstRowContainsHeader.Text = "First row contains header";
            this.ChkFirstRowContainsHeader.UseVisualStyleBackColor = true;
            // 
            // BtnCancel
            // 
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.Location = new System.Drawing.Point(382, 90);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 13;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            // 
            // BtnOk
            // 
            this.BtnOk.Location = new System.Drawing.Point(301, 90);
            this.BtnOk.Name = "BtnOk";
            this.BtnOk.Size = new System.Drawing.Size(75, 23);
            this.BtnOk.TabIndex = 12;
            this.BtnOk.Text = "OK";
            this.BtnOk.UseVisualStyleBackColor = true;
            this.BtnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // ChkTreatNullStrAsNull
            // 
            this.ChkTreatNullStrAsNull.AutoSize = true;
            this.ChkTreatNullStrAsNull.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ChkTreatNullStrAsNull.Checked = true;
            this.ChkTreatNullStrAsNull.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkTreatNullStrAsNull.Location = new System.Drawing.Point(194, 53);
            this.ChkTreatNullStrAsNull.Name = "ChkTreatNullStrAsNull";
            this.ChkTreatNullStrAsNull.Size = new System.Drawing.Size(182, 17);
            this.ChkTreatNullStrAsNull.TabIndex = 14;
            this.ChkTreatNullStrAsNull.Text = "Treat \"NULL\" string as null value";
            this.ChkTreatNullStrAsNull.UseVisualStyleBackColor = true;
            // 
            // BtnStopOperation
            // 
            this.BtnStopOperation.Location = new System.Drawing.Point(170, 88);
            this.BtnStopOperation.Name = "BtnStopOperation";
            this.BtnStopOperation.Size = new System.Drawing.Size(125, 26);
            this.BtnStopOperation.TabIndex = 15;
            this.BtnStopOperation.Text = "Stop operation";
            this.BtnStopOperation.UseVisualStyleBackColor = true;
            this.BtnStopOperation.Visible = false;
            this.BtnStopOperation.Click += new System.EventHandler(this.BtnStopOperation_Click);
            // 
            // WndAutoCreateColumns
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 121);
            this.Controls.Add(this.BtnStopOperation);
            this.Controls.Add(this.ChkTreatNullStrAsNull);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnOk);
            this.Controls.Add(this.ChkFirstRowContainsHeader);
            this.Controls.Add(this.BtnBrowseSampleFile);
            this.Controls.Add(this.TxtSampleFilePath);
            this.Controls.Add(this.label1);
            this.Name = "WndAutoCreateColumns";
            this.Text = "Automatic columns creation";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtSampleFilePath;
        private System.Windows.Forms.Button BtnBrowseSampleFile;
        private System.Windows.Forms.CheckBox ChkFirstRowContainsHeader;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnOk;
        private System.Windows.Forms.CheckBox ChkTreatNullStrAsNull;
        private System.Windows.Forms.Button BtnStopOperation;
    }
}