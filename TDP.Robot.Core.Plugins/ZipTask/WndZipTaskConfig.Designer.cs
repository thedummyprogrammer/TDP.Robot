
namespace TDP.Robot.Plugins.Core.ZipTask
{
    partial class WndZipTaskConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WndZipTaskConfig));
            this.TabGeneral = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ChkSkipEmptyFolders = new System.Windows.Forms.CheckBox();
            this.CmbCompressionLevel = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.CmbIfArchiveExists = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ChkStoreFullpath = new System.Windows.Forms.CheckBox();
            this.ChkIncludeFilesInSubFolders = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.BtnDynDataDestArchive = new System.Windows.Forms.Button();
            this.BtnBrowseDestArchive = new System.Windows.Forms.Button();
            this.TxtDestArchive = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnDynDataSource = new System.Windows.Forms.Button();
            this.BtnBrowseSource = new System.Windows.Forms.Button();
            this.TxtSource = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TabConfig2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrProvider)).BeginInit();
            this.TabGeneral.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabConfig2
            // 
            this.TabConfig2.Controls.Add(this.TabGeneral);
            this.TabConfig2.Size = new System.Drawing.Size(657, 315);
            this.TabConfig2.TabIndex = 1;
            this.TabConfig2.Controls.SetChildIndex(this.TabGeneral, 0);
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(508, 409);
            this.BtnSave.TabIndex = 2;
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(589, 409);
            this.BtnCancel.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Size = new System.Drawing.Size(653, 64);
            this.groupBox1.TabIndex = 0;
            // 
            // ChkDoNotLog
            // 
            this.ChkDoNotLog.Location = new System.Drawing.Point(573, 35);
            this.ChkDoNotLog.TabIndex = 3;
            // 
            // ChkDisable
            // 
            this.ChkDisable.Location = new System.Drawing.Point(573, 12);
            this.ChkDisable.TabIndex = 2;
            // 
            // TxtName
            // 
            this.TxtName.Size = new System.Drawing.Size(374, 20);
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
            this.TabGeneral.Controls.Add(this.groupBox3);
            this.TabGeneral.Controls.Add(this.groupBox2);
            this.TabGeneral.Location = new System.Drawing.Point(4, 22);
            this.TabGeneral.Name = "TabGeneral";
            this.TabGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.TabGeneral.Size = new System.Drawing.Size(649, 289);
            this.TabGeneral.TabIndex = 3;
            this.TabGeneral.Text = "General";
            this.TabGeneral.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ChkSkipEmptyFolders);
            this.groupBox3.Controls.Add(this.CmbCompressionLevel);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.CmbIfArchiveExists);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.ChkStoreFullpath);
            this.groupBox3.Controls.Add(this.ChkIncludeFilesInSubFolders);
            this.groupBox3.Location = new System.Drawing.Point(5, 136);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(638, 135);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Options";
            // 
            // ChkSkipEmptyFolders
            // 
            this.ChkSkipEmptyFolders.AutoSize = true;
            this.ChkSkipEmptyFolders.Location = new System.Drawing.Point(196, 19);
            this.ChkSkipEmptyFolders.Name = "ChkSkipEmptyFolders";
            this.ChkSkipEmptyFolders.Size = new System.Drawing.Size(112, 17);
            this.ChkSkipEmptyFolders.TabIndex = 6;
            this.ChkSkipEmptyFolders.Text = "Skip empty folders";
            this.ChkSkipEmptyFolders.UseVisualStyleBackColor = true;
            // 
            // CmbCompressionLevel
            // 
            this.CmbCompressionLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbCompressionLevel.FormattingEnabled = true;
            this.CmbCompressionLevel.Location = new System.Drawing.Point(159, 93);
            this.CmbCompressionLevel.Name = "CmbCompressionLevel";
            this.CmbCompressionLevel.Size = new System.Drawing.Size(328, 21);
            this.CmbCompressionLevel.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(60, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Compression level";
            // 
            // CmbIfArchiveExists
            // 
            this.CmbIfArchiveExists.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbIfArchiveExists.FormattingEnabled = true;
            this.CmbIfArchiveExists.Location = new System.Drawing.Point(159, 66);
            this.CmbIfArchiveExists.Name = "CmbIfArchiveExists";
            this.CmbIfArchiveExists.Size = new System.Drawing.Size(328, 21);
            this.CmbIfArchiveExists.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(134, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "If destination archive exists";
            // 
            // ChkStoreFullpath
            // 
            this.ChkStoreFullpath.AutoSize = true;
            this.ChkStoreFullpath.Location = new System.Drawing.Point(22, 42);
            this.ChkStoreFullpath.Name = "ChkStoreFullpath";
            this.ChkStoreFullpath.Size = new System.Drawing.Size(91, 17);
            this.ChkStoreFullpath.TabIndex = 1;
            this.ChkStoreFullpath.Text = "Store full path";
            this.ChkStoreFullpath.UseVisualStyleBackColor = true;
            // 
            // ChkIncludeFilesInSubFolders
            // 
            this.ChkIncludeFilesInSubFolders.AutoSize = true;
            this.ChkIncludeFilesInSubFolders.Location = new System.Drawing.Point(22, 19);
            this.ChkIncludeFilesInSubFolders.Name = "ChkIncludeFilesInSubFolders";
            this.ChkIncludeFilesInSubFolders.Size = new System.Drawing.Size(144, 17);
            this.ChkIncludeFilesInSubFolders.TabIndex = 0;
            this.ChkIncludeFilesInSubFolders.Text = "Include files in subfolders";
            this.ChkIncludeFilesInSubFolders.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.BtnDynDataDestArchive);
            this.groupBox2.Controls.Add(this.BtnBrowseDestArchive);
            this.groupBox2.Controls.Add(this.TxtDestArchive);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.BtnDynDataSource);
            this.groupBox2.Controls.Add(this.BtnBrowseSource);
            this.groupBox2.Controls.Add(this.TxtSource);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(6, 16);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(637, 114);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Source && destination";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(539, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "In the \'Source\' field you can use wildcard characters to identify files and folde" +
    "rs you want to include in the archive";
            // 
            // BtnDynDataDestArchive
            // 
            this.BtnDynDataDestArchive.Image = global::TDP.Robot.Plugins.Core.Resource.LightningAdd;
            this.BtnDynDataDestArchive.Location = new System.Drawing.Point(604, 80);
            this.BtnDynDataDestArchive.Name = "BtnDynDataDestArchive";
            this.BtnDynDataDestArchive.Size = new System.Drawing.Size(23, 21);
            this.BtnDynDataDestArchive.TabIndex = 8;
            this.BtnDynDataDestArchive.Text = "...";
            this.BtnDynDataDestArchive.UseVisualStyleBackColor = true;
            // 
            // BtnBrowseDestArchive
            // 
            this.BtnBrowseDestArchive.Location = new System.Drawing.Point(567, 80);
            this.BtnBrowseDestArchive.Name = "BtnBrowseDestArchive";
            this.BtnBrowseDestArchive.Size = new System.Drawing.Size(31, 20);
            this.BtnBrowseDestArchive.TabIndex = 7;
            this.BtnBrowseDestArchive.Text = "...";
            this.BtnBrowseDestArchive.UseVisualStyleBackColor = true;
            this.BtnBrowseDestArchive.Click += new System.EventHandler(this.BtnBrowseDestArchive_Click);
            // 
            // TxtDestArchive
            // 
            this.TxtDestArchive.Location = new System.Drawing.Point(116, 80);
            this.TxtDestArchive.MaxLength = 1000;
            this.TxtDestArchive.Name = "TxtDestArchive";
            this.TxtDestArchive.Size = new System.Drawing.Size(445, 20);
            this.TxtDestArchive.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Destination archive";
            // 
            // BtnDynDataSource
            // 
            this.BtnDynDataSource.Image = global::TDP.Robot.Plugins.Core.Resource.LightningAdd;
            this.BtnDynDataSource.Location = new System.Drawing.Point(604, 52);
            this.BtnDynDataSource.Name = "BtnDynDataSource";
            this.BtnDynDataSource.Size = new System.Drawing.Size(23, 21);
            this.BtnDynDataSource.TabIndex = 4;
            this.BtnDynDataSource.Text = "...";
            this.BtnDynDataSource.UseVisualStyleBackColor = true;
            // 
            // BtnBrowseSource
            // 
            this.BtnBrowseSource.Location = new System.Drawing.Point(567, 52);
            this.BtnBrowseSource.Name = "BtnBrowseSource";
            this.BtnBrowseSource.Size = new System.Drawing.Size(31, 20);
            this.BtnBrowseSource.TabIndex = 3;
            this.BtnBrowseSource.Text = "...";
            this.BtnBrowseSource.UseVisualStyleBackColor = true;
            this.BtnBrowseSource.Click += new System.EventHandler(this.BtnBrowseSource_Click);
            // 
            // TxtSource
            // 
            this.TxtSource.Location = new System.Drawing.Point(116, 52);
            this.TxtSource.MaxLength = 1000;
            this.TxtSource.Name = "TxtSource";
            this.TxtSource.Size = new System.Drawing.Size(445, 20);
            this.TxtSource.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(69, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Source";
            // 
            // WndZipTaskConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 444);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WndZipTaskConfig";
            this.Text = "Zip task configuration";
            this.TabConfig2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrProvider)).EndInit();
            this.TabGeneral.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage TabGeneral;
        private System.Windows.Forms.CheckBox ChkIncludeFilesInSubFolders;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button BtnDynDataDestArchive;
        private System.Windows.Forms.Button BtnBrowseDestArchive;
        private System.Windows.Forms.TextBox TxtDestArchive;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnDynDataSource;
        private System.Windows.Forms.Button BtnBrowseSource;
        private System.Windows.Forms.TextBox TxtSource;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox ChkStoreFullpath;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox CmbIfArchiveExists;
        private System.Windows.Forms.ComboBox CmbCompressionLevel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox ChkSkipEmptyFolders;
    }
}