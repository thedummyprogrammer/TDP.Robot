
namespace TDP.Robot.Plugins.Core.Unzip
{
    partial class WndUnzipTaskConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WndUnzipTaskConfig));
            this.TabGeneral = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.CmbIfDestinationFileExists = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BtnDynDataDestination = new System.Windows.Forms.Button();
            this.BtnBrowseDestination = new System.Windows.Forms.Button();
            this.TxtDestination = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnDynDataSourceArchive = new System.Windows.Forms.Button();
            this.BtnBrowseSourceArchive = new System.Windows.Forms.Button();
            this.TxtSourceArchive = new System.Windows.Forms.TextBox();
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
            this.TabConfig2.Size = new System.Drawing.Size(675, 252);
            this.TabConfig2.Controls.SetChildIndex(this.TabGeneral, 0);
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(527, 354);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(608, 354);
            // 
            // groupBox1
            // 
            this.groupBox1.Size = new System.Drawing.Size(671, 64);
            // 
            // ChkDoNotLog
            // 
            this.ChkDoNotLog.Location = new System.Drawing.Point(591, 35);
            // 
            // ChkDisable
            // 
            this.ChkDisable.Location = new System.Drawing.Point(591, 12);
            // 
            // TxtName
            // 
            this.TxtName.Size = new System.Drawing.Size(392, 20);
            // 
            // TabGeneral
            // 
            this.TabGeneral.Controls.Add(this.groupBox3);
            this.TabGeneral.Controls.Add(this.groupBox2);
            this.TabGeneral.Location = new System.Drawing.Point(4, 22);
            this.TabGeneral.Name = "TabGeneral";
            this.TabGeneral.Size = new System.Drawing.Size(667, 226);
            this.TabGeneral.TabIndex = 3;
            this.TabGeneral.Text = "General";
            this.TabGeneral.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.CmbIfDestinationFileExists);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Location = new System.Drawing.Point(14, 108);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(638, 79);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Options";
            // 
            // CmbIfDestinationFileExists
            // 
            this.CmbIfDestinationFileExists.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbIfDestinationFileExists.FormattingEnabled = true;
            this.CmbIfDestinationFileExists.Location = new System.Drawing.Point(163, 28);
            this.CmbIfDestinationFileExists.Name = "CmbIfDestinationFileExists";
            this.CmbIfDestinationFileExists.Size = new System.Drawing.Size(328, 21);
            this.CmbIfDestinationFileExists.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "If destination file exists";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BtnDynDataDestination);
            this.groupBox2.Controls.Add(this.BtnBrowseDestination);
            this.groupBox2.Controls.Add(this.TxtDestination);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.BtnDynDataSourceArchive);
            this.groupBox2.Controls.Add(this.BtnBrowseSourceArchive);
            this.groupBox2.Controls.Add(this.TxtSourceArchive);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(14, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(637, 90);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Source && destination";
            // 
            // BtnDynDataDestination
            // 
            this.BtnDynDataDestination.Image = global::TDP.Robot.Plugins.Core.Resource.LightningAdd;
            this.BtnDynDataDestination.Location = new System.Drawing.Point(604, 50);
            this.BtnDynDataDestination.Name = "BtnDynDataDestination";
            this.BtnDynDataDestination.Size = new System.Drawing.Size(23, 21);
            this.BtnDynDataDestination.TabIndex = 8;
            this.BtnDynDataDestination.Text = "...";
            this.BtnDynDataDestination.UseVisualStyleBackColor = true;
            // 
            // BtnBrowseDestination
            // 
            this.BtnBrowseDestination.Location = new System.Drawing.Point(567, 50);
            this.BtnBrowseDestination.Name = "BtnBrowseDestination";
            this.BtnBrowseDestination.Size = new System.Drawing.Size(31, 20);
            this.BtnBrowseDestination.TabIndex = 7;
            this.BtnBrowseDestination.Text = "...";
            this.BtnBrowseDestination.UseVisualStyleBackColor = true;
            this.BtnBrowseDestination.Click += new System.EventHandler(this.BtnBrowseDestination_Click);
            // 
            // TxtDestination
            // 
            this.TxtDestination.Location = new System.Drawing.Point(116, 50);
            this.TxtDestination.MaxLength = 1000;
            this.TxtDestination.Name = "TxtDestination";
            this.TxtDestination.Size = new System.Drawing.Size(445, 20);
            this.TxtDestination.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Destination folder";
            // 
            // BtnDynDataSourceArchive
            // 
            this.BtnDynDataSourceArchive.Image = global::TDP.Robot.Plugins.Core.Resource.LightningAdd;
            this.BtnDynDataSourceArchive.Location = new System.Drawing.Point(604, 22);
            this.BtnDynDataSourceArchive.Name = "BtnDynDataSourceArchive";
            this.BtnDynDataSourceArchive.Size = new System.Drawing.Size(23, 21);
            this.BtnDynDataSourceArchive.TabIndex = 4;
            this.BtnDynDataSourceArchive.Text = "...";
            this.BtnDynDataSourceArchive.UseVisualStyleBackColor = true;
            // 
            // BtnBrowseSourceArchive
            // 
            this.BtnBrowseSourceArchive.Location = new System.Drawing.Point(567, 22);
            this.BtnBrowseSourceArchive.Name = "BtnBrowseSourceArchive";
            this.BtnBrowseSourceArchive.Size = new System.Drawing.Size(31, 20);
            this.BtnBrowseSourceArchive.TabIndex = 3;
            this.BtnBrowseSourceArchive.Text = "...";
            this.BtnBrowseSourceArchive.UseVisualStyleBackColor = true;
            this.BtnBrowseSourceArchive.Click += new System.EventHandler(this.BtnBrowseSourceArchive_Click);
            // 
            // TxtSourceArchive
            // 
            this.TxtSourceArchive.Location = new System.Drawing.Point(116, 22);
            this.TxtSourceArchive.MaxLength = 1000;
            this.TxtSourceArchive.Name = "TxtSourceArchive";
            this.TxtSourceArchive.Size = new System.Drawing.Size(445, 20);
            this.TxtSourceArchive.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Source archive";
            // 
            // WndUnzipTaskConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 389);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WndUnzipTaskConfig";
            this.Text = "Unzip task configuration";
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
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox CmbIfDestinationFileExists;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button BtnDynDataDestination;
        private System.Windows.Forms.Button BtnBrowseDestination;
        private System.Windows.Forms.TextBox TxtDestination;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnDynDataSourceArchive;
        private System.Windows.Forms.Button BtnBrowseSourceArchive;
        private System.Windows.Forms.TextBox TxtSourceArchive;
        private System.Windows.Forms.Label label3;
    }
}