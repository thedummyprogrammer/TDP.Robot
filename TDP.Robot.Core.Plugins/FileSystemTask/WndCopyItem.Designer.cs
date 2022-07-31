
namespace TDP.Robot.Plugins.Core.FileSystemTask
{
    partial class WndCopyItem
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
            this.ChkRecursivelyCopyDirectories = new System.Windows.Forms.CheckBox();
            this.ChkOverwriteFileIfExists = new System.Windows.Forms.CheckBox();
            this.BtnDynDataDestinationPath = new System.Windows.Forms.Button();
            this.BtnDynDataSourcePath = new System.Windows.Forms.Button();
            this.BtnBrowserSourcePath = new System.Windows.Forms.Button();
            this.TxtDestinationPath = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.TxtSourcePath = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnOk = new System.Windows.Forms.Button();
            this.BtnBrowseDestinationPath = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.TxtFilesOlderThanMinutes = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TxtFilesOlderThanHours = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtFilesOlderThanDays = new System.Windows.Forms.TextBox();
            this.BtnDynDataFilesOlderThanDays = new System.Windows.Forms.Button();
            this.BtnDynDataFilesOlderThanHours = new System.Windows.Forms.Button();
            this.BtnDynDataFilesOlderThanMinutes = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ChkRecursivelyCopyDirectories
            // 
            this.ChkRecursivelyCopyDirectories.AutoSize = true;
            this.ChkRecursivelyCopyDirectories.Location = new System.Drawing.Point(160, 117);
            this.ChkRecursivelyCopyDirectories.Name = "ChkRecursivelyCopyDirectories";
            this.ChkRecursivelyCopyDirectories.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ChkRecursivelyCopyDirectories.Size = new System.Drawing.Size(158, 17);
            this.ChkRecursivelyCopyDirectories.TabIndex = 19;
            this.ChkRecursivelyCopyDirectories.Text = "Recursively copy directories";
            this.ChkRecursivelyCopyDirectories.UseVisualStyleBackColor = true;
            // 
            // ChkOverwriteFileIfExists
            // 
            this.ChkOverwriteFileIfExists.AutoSize = true;
            this.ChkOverwriteFileIfExists.Location = new System.Drawing.Point(17, 117);
            this.ChkOverwriteFileIfExists.Name = "ChkOverwriteFileIfExists";
            this.ChkOverwriteFileIfExists.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ChkOverwriteFileIfExists.Size = new System.Drawing.Size(124, 17);
            this.ChkOverwriteFileIfExists.TabIndex = 18;
            this.ChkOverwriteFileIfExists.Text = "Overwrite file if exists";
            this.ChkOverwriteFileIfExists.UseVisualStyleBackColor = true;
            // 
            // BtnDynDataDestinationPath
            // 
            this.BtnDynDataDestinationPath.Image = global::TDP.Robot.Plugins.Core.Resource.LightningAdd;
            this.BtnDynDataDestinationPath.Location = new System.Drawing.Point(562, 61);
            this.BtnDynDataDestinationPath.Name = "BtnDynDataDestinationPath";
            this.BtnDynDataDestinationPath.Size = new System.Drawing.Size(23, 21);
            this.BtnDynDataDestinationPath.TabIndex = 7;
            this.BtnDynDataDestinationPath.Text = "...";
            this.BtnDynDataDestinationPath.UseVisualStyleBackColor = true;
            // 
            // BtnDynDataSourcePath
            // 
            this.BtnDynDataSourcePath.Image = global::TDP.Robot.Plugins.Core.Resource.LightningAdd;
            this.BtnDynDataSourcePath.Location = new System.Drawing.Point(562, 35);
            this.BtnDynDataSourcePath.Name = "BtnDynDataSourcePath";
            this.BtnDynDataSourcePath.Size = new System.Drawing.Size(23, 21);
            this.BtnDynDataSourcePath.TabIndex = 3;
            this.BtnDynDataSourcePath.Text = "...";
            this.BtnDynDataSourcePath.UseVisualStyleBackColor = true;
            // 
            // BtnBrowserSourcePath
            // 
            this.BtnBrowserSourcePath.Location = new System.Drawing.Point(525, 35);
            this.BtnBrowserSourcePath.Name = "BtnBrowserSourcePath";
            this.BtnBrowserSourcePath.Size = new System.Drawing.Size(31, 20);
            this.BtnBrowserSourcePath.TabIndex = 2;
            this.BtnBrowserSourcePath.Text = "...";
            this.BtnBrowserSourcePath.UseVisualStyleBackColor = true;
            this.BtnBrowserSourcePath.Click += new System.EventHandler(this.BtnBrowserSourcePath_Click);
            // 
            // TxtDestinationPath
            // 
            this.TxtDestinationPath.Location = new System.Drawing.Point(124, 61);
            this.TxtDestinationPath.MaxLength = 5000;
            this.TxtDestinationPath.Name = "TxtDestinationPath";
            this.TxtDestinationPath.Size = new System.Drawing.Size(395, 20);
            this.TxtDestinationPath.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(34, 64);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "Destination path";
            // 
            // TxtSourcePath
            // 
            this.TxtSourcePath.Location = new System.Drawing.Point(124, 35);
            this.TxtSourcePath.MaxLength = 5000;
            this.TxtSourcePath.Name = "TxtSourcePath";
            this.TxtSourcePath.Size = new System.Drawing.Size(395, 20);
            this.TxtSourcePath.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(53, 38);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Source path";
            // 
            // BtnCancel
            // 
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.Location = new System.Drawing.Point(510, 159);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 21;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            // 
            // BtnOk
            // 
            this.BtnOk.Location = new System.Drawing.Point(429, 159);
            this.BtnOk.Name = "BtnOk";
            this.BtnOk.Size = new System.Drawing.Size(75, 23);
            this.BtnOk.TabIndex = 20;
            this.BtnOk.Text = "OK";
            this.BtnOk.UseVisualStyleBackColor = true;
            this.BtnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // BtnBrowseDestinationPath
            // 
            this.BtnBrowseDestinationPath.Location = new System.Drawing.Point(525, 62);
            this.BtnBrowseDestinationPath.Name = "BtnBrowseDestinationPath";
            this.BtnBrowseDestinationPath.Size = new System.Drawing.Size(31, 20);
            this.BtnBrowseDestinationPath.TabIndex = 6;
            this.BtnBrowseDestinationPath.Text = "...";
            this.BtnBrowseDestinationPath.UseVisualStyleBackColor = true;
            this.BtnBrowseDestinationPath.Click += new System.EventHandler(this.BtnBrowseDestinationPath_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Files older than";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(514, 92);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "minutes";
            // 
            // TxtFilesOlderThanMinutes
            // 
            this.TxtFilesOlderThanMinutes.Location = new System.Drawing.Point(412, 88);
            this.TxtFilesOlderThanMinutes.MaxLength = 2;
            this.TxtFilesOlderThanMinutes.Name = "TxtFilesOlderThanMinutes";
            this.TxtFilesOlderThanMinutes.Size = new System.Drawing.Size(75, 20);
            this.TxtFilesOlderThanMinutes.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(369, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "hours";
            // 
            // TxtFilesOlderThanHours
            // 
            this.TxtFilesOlderThanHours.Location = new System.Drawing.Point(265, 88);
            this.TxtFilesOlderThanHours.MaxLength = 2;
            this.TxtFilesOlderThanHours.Name = "TxtFilesOlderThanHours";
            this.TxtFilesOlderThanHours.Size = new System.Drawing.Size(75, 20);
            this.TxtFilesOlderThanHours.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(226, 92);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "days";
            // 
            // TxtFilesOlderThanDays
            // 
            this.TxtFilesOlderThanDays.Location = new System.Drawing.Point(124, 88);
            this.TxtFilesOlderThanDays.MaxLength = 3;
            this.TxtFilesOlderThanDays.Name = "TxtFilesOlderThanDays";
            this.TxtFilesOlderThanDays.Size = new System.Drawing.Size(75, 20);
            this.TxtFilesOlderThanDays.TabIndex = 9;
            // 
            // BtnDynDataFilesOlderThanDays
            // 
            this.BtnDynDataFilesOlderThanDays.Image = global::TDP.Robot.Plugins.Core.Resource.LightningAdd;
            this.BtnDynDataFilesOlderThanDays.Location = new System.Drawing.Point(201, 88);
            this.BtnDynDataFilesOlderThanDays.Name = "BtnDynDataFilesOlderThanDays";
            this.BtnDynDataFilesOlderThanDays.Size = new System.Drawing.Size(23, 21);
            this.BtnDynDataFilesOlderThanDays.TabIndex = 10;
            this.BtnDynDataFilesOlderThanDays.Text = "...";
            this.BtnDynDataFilesOlderThanDays.UseVisualStyleBackColor = true;
            // 
            // BtnDynDataFilesOlderThanHours
            // 
            this.BtnDynDataFilesOlderThanHours.Image = global::TDP.Robot.Plugins.Core.Resource.LightningAdd;
            this.BtnDynDataFilesOlderThanHours.Location = new System.Drawing.Point(342, 88);
            this.BtnDynDataFilesOlderThanHours.Name = "BtnDynDataFilesOlderThanHours";
            this.BtnDynDataFilesOlderThanHours.Size = new System.Drawing.Size(23, 21);
            this.BtnDynDataFilesOlderThanHours.TabIndex = 13;
            this.BtnDynDataFilesOlderThanHours.Text = "...";
            this.BtnDynDataFilesOlderThanHours.UseVisualStyleBackColor = true;
            // 
            // BtnDynDataFilesOlderThanMinutes
            // 
            this.BtnDynDataFilesOlderThanMinutes.Image = global::TDP.Robot.Plugins.Core.Resource.LightningAdd;
            this.BtnDynDataFilesOlderThanMinutes.Location = new System.Drawing.Point(489, 88);
            this.BtnDynDataFilesOlderThanMinutes.Name = "BtnDynDataFilesOlderThanMinutes";
            this.BtnDynDataFilesOlderThanMinutes.Size = new System.Drawing.Size(23, 21);
            this.BtnDynDataFilesOlderThanMinutes.TabIndex = 16;
            this.BtnDynDataFilesOlderThanMinutes.Text = "...";
            this.BtnDynDataFilesOlderThanMinutes.UseVisualStyleBackColor = true;
            // 
            // WndCopyItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 199);
            this.Controls.Add(this.BtnDynDataFilesOlderThanMinutes);
            this.Controls.Add(this.BtnDynDataFilesOlderThanHours);
            this.Controls.Add(this.BtnDynDataFilesOlderThanDays);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.TxtFilesOlderThanMinutes);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.TxtFilesOlderThanHours);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TxtFilesOlderThanDays);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnBrowseDestinationPath);
            this.Controls.Add(this.ChkRecursivelyCopyDirectories);
            this.Controls.Add(this.ChkOverwriteFileIfExists);
            this.Controls.Add(this.BtnDynDataDestinationPath);
            this.Controls.Add(this.BtnDynDataSourcePath);
            this.Controls.Add(this.BtnBrowserSourcePath);
            this.Controls.Add(this.TxtDestinationPath);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.TxtSourcePath);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnOk);
            this.Name = "WndCopyItem";
            this.Text = "Add / Edit copy item";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox ChkRecursivelyCopyDirectories;
        private System.Windows.Forms.CheckBox ChkOverwriteFileIfExists;
        private System.Windows.Forms.Button BtnDynDataDestinationPath;
        private System.Windows.Forms.Button BtnDynDataSourcePath;
        private System.Windows.Forms.Button BtnBrowserSourcePath;
        private System.Windows.Forms.TextBox TxtDestinationPath;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox TxtSourcePath;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnOk;
        private System.Windows.Forms.Button BtnBrowseDestinationPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TxtFilesOlderThanMinutes;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TxtFilesOlderThanHours;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtFilesOlderThanDays;
        private System.Windows.Forms.Button BtnDynDataFilesOlderThanDays;
        private System.Windows.Forms.Button BtnDynDataFilesOlderThanHours;
        private System.Windows.Forms.Button BtnDynDataFilesOlderThanMinutes;
    }
}