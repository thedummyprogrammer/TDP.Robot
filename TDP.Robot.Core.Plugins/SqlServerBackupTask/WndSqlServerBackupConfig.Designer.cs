
namespace TDP.Robot.Plugins.Core.SqlServerBackupTask
{
    partial class WndSqlServerBackupConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WndSqlServerBackupConfig));
            this.TabGeneral = new System.Windows.Forms.TabPage();
            this.GrpConnection = new System.Windows.Forms.GroupBox();
            this.TxtPassword = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.TxtUserName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.BtnTestRefresh = new System.Windows.Forms.Button();
            this.TxtConnectionStringOptions = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.GrpDatabases = new System.Windows.Forms.GroupBox();
            this.CmbBackupType = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.ChkDatabaseList = new System.Windows.Forms.CheckedListBox();
            this.RdbSelectedDatabases = new System.Windows.Forms.RadioButton();
            this.RdbAllUserDatabases = new System.Windows.Forms.RadioButton();
            this.RdbAllDatabases = new System.Windows.Forms.RadioButton();
            this.TabOptions = new System.Windows.Forms.TabPage();
            this.GrpCompression = new System.Windows.Forms.GroupBox();
            this.CmbCompression = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.GrpReliability = new System.Windows.Forms.GroupBox();
            this.ChkContinueOnError = new System.Windows.Forms.CheckBox();
            this.ChkPerformChecksum = new System.Windows.Forms.CheckBox();
            this.ChkVerifyBackup = new System.Windows.Forms.CheckBox();
            this.GrpBackupDestination = new System.Windows.Forms.GroupBox();
            this.BtnDynDataFileNameTemplate = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.TxtFileNameTemplate = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.RdbIfExistsOverwrite = new System.Windows.Forms.RadioButton();
            this.RdbIfExistsAppend = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.BtnDynDataDestPath = new System.Windows.Forms.Button();
            this.BtnBrowseDestPath = new System.Windows.Forms.Button();
            this.TxtDestPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtServer = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.TabConfig2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrProvider)).BeginInit();
            this.TabGeneral.SuspendLayout();
            this.GrpConnection.SuspendLayout();
            this.GrpDatabases.SuspendLayout();
            this.TabOptions.SuspendLayout();
            this.GrpCompression.SuspendLayout();
            this.GrpReliability.SuspendLayout();
            this.GrpBackupDestination.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabConfig2
            // 
            this.TabConfig2.Controls.Add(this.TabGeneral);
            this.TabConfig2.Controls.Add(this.TabOptions);
            this.TabConfig2.TabIndex = 1;
            this.TabConfig2.Controls.SetChildIndex(this.TabOptions, 0);
            this.TabConfig2.Controls.SetChildIndex(this.TabGeneral, 0);
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(415, 529);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(496, 529);
            // 
            // groupBox1
            // 
            this.groupBox1.TabIndex = 0;
            // 
            // ChkDoNotLog
            // 
            this.ChkDoNotLog.TabIndex = 3;
            // 
            // ChkDisable
            // 
            this.ChkDisable.TabIndex = 2;
            // 
            // TxtName
            // 
            this.TxtName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.TabIndex = 0;
            // 
            // LblID
            // 
            this.LblID.TabIndex = 0;
            // 
            // TabGeneral
            // 
            this.TabGeneral.Controls.Add(this.GrpConnection);
            this.TabGeneral.Controls.Add(this.GrpDatabases);
            this.TabGeneral.Location = new System.Drawing.Point(4, 22);
            this.TabGeneral.Name = "TabGeneral";
            this.TabGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.TabGeneral.Size = new System.Drawing.Size(555, 415);
            this.TabGeneral.TabIndex = 3;
            this.TabGeneral.Text = "General";
            this.TabGeneral.UseVisualStyleBackColor = true;
            // 
            // GrpConnection
            // 
            this.GrpConnection.Controls.Add(this.TxtServer);
            this.GrpConnection.Controls.Add(this.label12);
            this.GrpConnection.Controls.Add(this.TxtPassword);
            this.GrpConnection.Controls.Add(this.label11);
            this.GrpConnection.Controls.Add(this.TxtUserName);
            this.GrpConnection.Controls.Add(this.label10);
            this.GrpConnection.Controls.Add(this.BtnTestRefresh);
            this.GrpConnection.Controls.Add(this.TxtConnectionStringOptions);
            this.GrpConnection.Controls.Add(this.label5);
            this.GrpConnection.Location = new System.Drawing.Point(9, 15);
            this.GrpConnection.Name = "GrpConnection";
            this.GrpConnection.Size = new System.Drawing.Size(534, 159);
            this.GrpConnection.TabIndex = 0;
            this.GrpConnection.TabStop = false;
            this.GrpConnection.Text = "Connection";
            // 
            // TxtPassword
            // 
            this.TxtPassword.Location = new System.Drawing.Point(164, 73);
            this.TxtPassword.Name = "TxtPassword";
            this.TxtPassword.PasswordChar = '*';
            this.TxtPassword.Size = new System.Drawing.Size(269, 20);
            this.TxtPassword.TabIndex = 5;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(103, 76);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 13);
            this.label11.TabIndex = 4;
            this.label11.Text = "Password";
            // 
            // TxtUserName
            // 
            this.TxtUserName.Location = new System.Drawing.Point(164, 47);
            this.TxtUserName.Name = "TxtUserName";
            this.TxtUserName.Size = new System.Drawing.Size(269, 20);
            this.TxtUserName.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(103, 50);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 13);
            this.label10.TabIndex = 2;
            this.label10.Text = "Username";
            // 
            // BtnTestRefresh
            // 
            this.BtnTestRefresh.Location = new System.Drawing.Point(224, 125);
            this.BtnTestRefresh.Name = "BtnTestRefresh";
            this.BtnTestRefresh.Size = new System.Drawing.Size(209, 23);
            this.BtnTestRefresh.TabIndex = 8;
            this.BtnTestRefresh.Text = "Test / Refresh";
            this.BtnTestRefresh.UseVisualStyleBackColor = true;
            this.BtnTestRefresh.Click += new System.EventHandler(this.BtnTestRefresh_Click);
            // 
            // TxtConnectionStringOptions
            // 
            this.TxtConnectionStringOptions.Location = new System.Drawing.Point(164, 99);
            this.TxtConnectionStringOptions.Name = "TxtConnectionStringOptions";
            this.TxtConnectionStringOptions.Size = new System.Drawing.Size(269, 20);
            this.TxtConnectionStringOptions.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 102);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Connection string options";
            // 
            // GrpDatabases
            // 
            this.GrpDatabases.Controls.Add(this.CmbBackupType);
            this.GrpDatabases.Controls.Add(this.label7);
            this.GrpDatabases.Controls.Add(this.ChkDatabaseList);
            this.GrpDatabases.Controls.Add(this.RdbSelectedDatabases);
            this.GrpDatabases.Controls.Add(this.RdbAllUserDatabases);
            this.GrpDatabases.Controls.Add(this.RdbAllDatabases);
            this.GrpDatabases.Location = new System.Drawing.Point(9, 180);
            this.GrpDatabases.Name = "GrpDatabases";
            this.GrpDatabases.Size = new System.Drawing.Size(534, 229);
            this.GrpDatabases.TabIndex = 1;
            this.GrpDatabases.TabStop = false;
            this.GrpDatabases.Text = "Databases";
            // 
            // CmbBackupType
            // 
            this.CmbBackupType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbBackupType.FormattingEnabled = true;
            this.CmbBackupType.Location = new System.Drawing.Point(112, 21);
            this.CmbBackupType.Name = "CmbBackupType";
            this.CmbBackupType.Size = new System.Drawing.Size(255, 21);
            this.CmbBackupType.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(34, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Backup type";
            // 
            // ChkDatabaseList
            // 
            this.ChkDatabaseList.FormattingEnabled = true;
            this.ChkDatabaseList.Location = new System.Drawing.Point(6, 79);
            this.ChkDatabaseList.Name = "ChkDatabaseList";
            this.ChkDatabaseList.Size = new System.Drawing.Size(522, 139);
            this.ChkDatabaseList.TabIndex = 5;
            // 
            // RdbSelectedDatabases
            // 
            this.RdbSelectedDatabases.AutoSize = true;
            this.RdbSelectedDatabases.Location = new System.Drawing.Point(224, 56);
            this.RdbSelectedDatabases.Name = "RdbSelectedDatabases";
            this.RdbSelectedDatabases.Size = new System.Drawing.Size(143, 17);
            this.RdbSelectedDatabases.TabIndex = 4;
            this.RdbSelectedDatabases.Text = "The following databases:";
            this.RdbSelectedDatabases.UseVisualStyleBackColor = true;
            this.RdbSelectedDatabases.CheckedChanged += new System.EventHandler(this.RdbSelectedDatabases_CheckedChanged);
            // 
            // RdbAllUserDatabases
            // 
            this.RdbAllUserDatabases.AutoSize = true;
            this.RdbAllUserDatabases.Location = new System.Drawing.Point(107, 56);
            this.RdbAllUserDatabases.Name = "RdbAllUserDatabases";
            this.RdbAllUserDatabases.Size = new System.Drawing.Size(111, 17);
            this.RdbAllUserDatabases.TabIndex = 3;
            this.RdbAllUserDatabases.Text = "All user databases";
            this.RdbAllUserDatabases.UseVisualStyleBackColor = true;
            this.RdbAllUserDatabases.CheckedChanged += new System.EventHandler(this.RdbAllUserDatabases_CheckedChanged);
            // 
            // RdbAllDatabases
            // 
            this.RdbAllDatabases.AutoSize = true;
            this.RdbAllDatabases.Checked = true;
            this.RdbAllDatabases.Location = new System.Drawing.Point(13, 56);
            this.RdbAllDatabases.Name = "RdbAllDatabases";
            this.RdbAllDatabases.Size = new System.Drawing.Size(88, 17);
            this.RdbAllDatabases.TabIndex = 2;
            this.RdbAllDatabases.TabStop = true;
            this.RdbAllDatabases.Text = "All databases";
            this.RdbAllDatabases.UseVisualStyleBackColor = true;
            this.RdbAllDatabases.CheckedChanged += new System.EventHandler(this.RdbAllDatabases_CheckedChanged);
            // 
            // TabOptions
            // 
            this.TabOptions.Controls.Add(this.GrpCompression);
            this.TabOptions.Controls.Add(this.GrpReliability);
            this.TabOptions.Controls.Add(this.GrpBackupDestination);
            this.TabOptions.Location = new System.Drawing.Point(4, 22);
            this.TabOptions.Name = "TabOptions";
            this.TabOptions.Padding = new System.Windows.Forms.Padding(3);
            this.TabOptions.Size = new System.Drawing.Size(555, 415);
            this.TabOptions.TabIndex = 4;
            this.TabOptions.Text = "Options";
            this.TabOptions.UseVisualStyleBackColor = true;
            // 
            // GrpCompression
            // 
            this.GrpCompression.Controls.Add(this.CmbCompression);
            this.GrpCompression.Controls.Add(this.label4);
            this.GrpCompression.Location = new System.Drawing.Point(8, 273);
            this.GrpCompression.Name = "GrpCompression";
            this.GrpCompression.Size = new System.Drawing.Size(533, 58);
            this.GrpCompression.TabIndex = 2;
            this.GrpCompression.TabStop = false;
            this.GrpCompression.Text = "Other";
            // 
            // CmbCompression
            // 
            this.CmbCompression.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbCompression.FormattingEnabled = true;
            this.CmbCompression.Location = new System.Drawing.Point(126, 23);
            this.CmbCompression.Name = "CmbCompression";
            this.CmbCompression.Size = new System.Drawing.Size(320, 21);
            this.CmbCompression.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Compression";
            // 
            // GrpReliability
            // 
            this.GrpReliability.Controls.Add(this.ChkContinueOnError);
            this.GrpReliability.Controls.Add(this.ChkPerformChecksum);
            this.GrpReliability.Controls.Add(this.ChkVerifyBackup);
            this.GrpReliability.Location = new System.Drawing.Point(8, 178);
            this.GrpReliability.Name = "GrpReliability";
            this.GrpReliability.Size = new System.Drawing.Size(533, 89);
            this.GrpReliability.TabIndex = 1;
            this.GrpReliability.TabStop = false;
            this.GrpReliability.Text = "Reliability";
            // 
            // ChkContinueOnError
            // 
            this.ChkContinueOnError.Location = new System.Drawing.Point(6, 59);
            this.ChkContinueOnError.Name = "ChkContinueOnError";
            this.ChkContinueOnError.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ChkContinueOnError.Size = new System.Drawing.Size(269, 23);
            this.ChkContinueOnError.TabIndex = 2;
            this.ChkContinueOnError.Text = "Continue backup if checksum error encountered";
            this.ChkContinueOnError.UseVisualStyleBackColor = true;
            // 
            // ChkPerformChecksum
            // 
            this.ChkPerformChecksum.Location = new System.Drawing.Point(24, 39);
            this.ChkPerformChecksum.Name = "ChkPerformChecksum";
            this.ChkPerformChecksum.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ChkPerformChecksum.Size = new System.Drawing.Size(251, 23);
            this.ChkPerformChecksum.TabIndex = 1;
            this.ChkPerformChecksum.Text = "Perform checksum";
            this.ChkPerformChecksum.UseVisualStyleBackColor = true;
            // 
            // ChkVerifyBackup
            // 
            this.ChkVerifyBackup.Location = new System.Drawing.Point(25, 19);
            this.ChkVerifyBackup.Name = "ChkVerifyBackup";
            this.ChkVerifyBackup.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ChkVerifyBackup.Size = new System.Drawing.Size(250, 24);
            this.ChkVerifyBackup.TabIndex = 0;
            this.ChkVerifyBackup.Text = "Verify backup when finished";
            this.ChkVerifyBackup.UseVisualStyleBackColor = true;
            // 
            // GrpBackupDestination
            // 
            this.GrpBackupDestination.Controls.Add(this.BtnDynDataFileNameTemplate);
            this.GrpBackupDestination.Controls.Add(this.label9);
            this.GrpBackupDestination.Controls.Add(this.TxtFileNameTemplate);
            this.GrpBackupDestination.Controls.Add(this.label8);
            this.GrpBackupDestination.Controls.Add(this.label6);
            this.GrpBackupDestination.Controls.Add(this.RdbIfExistsOverwrite);
            this.GrpBackupDestination.Controls.Add(this.RdbIfExistsAppend);
            this.GrpBackupDestination.Controls.Add(this.label3);
            this.GrpBackupDestination.Controls.Add(this.BtnDynDataDestPath);
            this.GrpBackupDestination.Controls.Add(this.BtnBrowseDestPath);
            this.GrpBackupDestination.Controls.Add(this.TxtDestPath);
            this.GrpBackupDestination.Controls.Add(this.label2);
            this.GrpBackupDestination.Location = new System.Drawing.Point(8, 11);
            this.GrpBackupDestination.Name = "GrpBackupDestination";
            this.GrpBackupDestination.Size = new System.Drawing.Size(533, 160);
            this.GrpBackupDestination.TabIndex = 0;
            this.GrpBackupDestination.TabStop = false;
            this.GrpBackupDestination.Text = "Destination";
            // 
            // BtnDynDataFileNameTemplate
            // 
            this.BtnDynDataFileNameTemplate.Image = global::TDP.Robot.Plugins.Core.Resource.LightningAdd;
            this.BtnDynDataFileNameTemplate.Location = new System.Drawing.Point(457, 101);
            this.BtnDynDataFileNameTemplate.Name = "BtnDynDataFileNameTemplate";
            this.BtnDynDataFileNameTemplate.Size = new System.Drawing.Size(23, 21);
            this.BtnDynDataFileNameTemplate.TabIndex = 8;
            this.BtnDynDataFileNameTemplate.Text = "...";
            this.BtnDynDataFileNameTemplate.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(30, 81);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(480, 13);
            this.label9.TabIndex = 5;
            this.label9.Text = "Note: leave blank for the default behaviour, use {DatabaseName} as placeholder fo" +
    "r database name";
            // 
            // TxtFileNameTemplate
            // 
            this.TxtFileNameTemplate.Location = new System.Drawing.Point(131, 102);
            this.TxtFileNameTemplate.MaxLength = 1000;
            this.TxtFileNameTemplate.Name = "TxtFileNameTemplate";
            this.TxtFileNameTemplate.Size = new System.Drawing.Size(320, 20);
            this.TxtFileNameTemplate.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(30, 105);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "File name template";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(32, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(459, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Note: if your are connecting to a remote server, you must enter a valid path on t" +
    "he remote server";
            // 
            // RdbIfExistsOverwrite
            // 
            this.RdbIfExistsOverwrite.AutoSize = true;
            this.RdbIfExistsOverwrite.Checked = true;
            this.RdbIfExistsOverwrite.Location = new System.Drawing.Point(131, 128);
            this.RdbIfExistsOverwrite.Name = "RdbIfExistsOverwrite";
            this.RdbIfExistsOverwrite.Size = new System.Drawing.Size(70, 17);
            this.RdbIfExistsOverwrite.TabIndex = 10;
            this.RdbIfExistsOverwrite.TabStop = true;
            this.RdbIfExistsOverwrite.Text = "Overwrite";
            this.RdbIfExistsOverwrite.UseVisualStyleBackColor = true;
            // 
            // RdbIfExistsAppend
            // 
            this.RdbIfExistsAppend.AutoSize = true;
            this.RdbIfExistsAppend.Location = new System.Drawing.Point(207, 128);
            this.RdbIfExistsAppend.Name = "RdbIfExistsAppend";
            this.RdbIfExistsAppend.Size = new System.Drawing.Size(62, 17);
            this.RdbIfExistsAppend.TabIndex = 11;
            this.RdbIfExistsAppend.Text = "Append";
            this.RdbIfExistsAppend.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "If destination exists";
            // 
            // BtnDynDataDestPath
            // 
            this.BtnDynDataDestPath.Image = global::TDP.Robot.Plugins.Core.Resource.LightningAdd;
            this.BtnDynDataDestPath.Location = new System.Drawing.Point(491, 43);
            this.BtnDynDataDestPath.Name = "BtnDynDataDestPath";
            this.BtnDynDataDestPath.Size = new System.Drawing.Size(23, 21);
            this.BtnDynDataDestPath.TabIndex = 4;
            this.BtnDynDataDestPath.Text = "...";
            this.BtnDynDataDestPath.UseVisualStyleBackColor = true;
            // 
            // BtnBrowseDestPath
            // 
            this.BtnBrowseDestPath.Location = new System.Drawing.Point(454, 43);
            this.BtnBrowseDestPath.Name = "BtnBrowseDestPath";
            this.BtnBrowseDestPath.Size = new System.Drawing.Size(31, 20);
            this.BtnBrowseDestPath.TabIndex = 3;
            this.BtnBrowseDestPath.Text = "...";
            this.BtnBrowseDestPath.UseVisualStyleBackColor = true;
            this.BtnBrowseDestPath.Click += new System.EventHandler(this.TxtBrowseDestPath_Click);
            // 
            // TxtDestPath
            // 
            this.TxtDestPath.Location = new System.Drawing.Point(131, 43);
            this.TxtDestPath.MaxLength = 1000;
            this.TxtDestPath.Name = "TxtDestPath";
            this.TxtDestPath.Size = new System.Drawing.Size(320, 20);
            this.TxtDestPath.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Destination folder";
            // 
            // TxtServer
            // 
            this.TxtServer.Location = new System.Drawing.Point(164, 21);
            this.TxtServer.Name = "TxtServer";
            this.TxtServer.Size = new System.Drawing.Size(269, 20);
            this.TxtServer.TabIndex = 1;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(118, 24);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(38, 13);
            this.label12.TabIndex = 0;
            this.label12.Text = "Server";
            // 
            // WndSqlServerBackupConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 564);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WndSqlServerBackupConfig";
            this.Text = "Sql Server backup task configuration";
            this.TabConfig2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrProvider)).EndInit();
            this.TabGeneral.ResumeLayout(false);
            this.GrpConnection.ResumeLayout(false);
            this.GrpConnection.PerformLayout();
            this.GrpDatabases.ResumeLayout(false);
            this.GrpDatabases.PerformLayout();
            this.TabOptions.ResumeLayout(false);
            this.GrpCompression.ResumeLayout(false);
            this.GrpCompression.PerformLayout();
            this.GrpReliability.ResumeLayout(false);
            this.GrpBackupDestination.ResumeLayout(false);
            this.GrpBackupDestination.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage TabGeneral;
        private System.Windows.Forms.GroupBox GrpDatabases;
        private System.Windows.Forms.TabPage TabOptions;
        private System.Windows.Forms.GroupBox GrpCompression;
        private System.Windows.Forms.ComboBox CmbCompression;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox GrpReliability;
        private System.Windows.Forms.CheckBox ChkContinueOnError;
        private System.Windows.Forms.CheckBox ChkPerformChecksum;
        private System.Windows.Forms.CheckBox ChkVerifyBackup;
        private System.Windows.Forms.GroupBox GrpBackupDestination;
        private System.Windows.Forms.RadioButton RdbIfExistsOverwrite;
        private System.Windows.Forms.RadioButton RdbIfExistsAppend;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BtnDynDataDestPath;
        private System.Windows.Forms.Button BtnBrowseDestPath;
        private System.Windows.Forms.TextBox TxtDestPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox GrpConnection;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtConnectionStringOptions;
        private System.Windows.Forms.Button BtnTestRefresh;
        private System.Windows.Forms.RadioButton RdbAllDatabases;
        private System.Windows.Forms.RadioButton RdbAllUserDatabases;
        private System.Windows.Forms.RadioButton RdbSelectedDatabases;
        private System.Windows.Forms.CheckedListBox ChkDatabaseList;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox CmbBackupType;
        private System.Windows.Forms.TextBox TxtFileNameTemplate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button BtnDynDataFileNameTemplate;
        private System.Windows.Forms.TextBox TxtPassword;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox TxtUserName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox TxtServer;
        private System.Windows.Forms.Label label12;
    }
}