
namespace TDP.Robot.Plugins.Core.SqlServerBulkCopyTask
{
    partial class WndSqlServerBulkCopyTaskConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WndSqlServerBulkCopyTaskConfig));
            this.TabGeneral = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.BtnDynDataDestinationTable = new System.Windows.Forms.Button();
            this.TxtDestinationTable = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.GrpConnection = new System.Windows.Forms.GroupBox();
            this.TxtDatabase = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtServer = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtPassword = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.TxtUserName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.TxtCommandTimeout = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TxtConnectionStringOptions = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BtnDynDataSourceRecordset = new System.Windows.Forms.Button();
            this.TxtSourceRecordset = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TabConfig2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrProvider)).BeginInit();
            this.TabGeneral.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.GrpConnection.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabConfig2
            // 
            this.TabConfig2.Controls.Add(this.TabGeneral);
            this.TabConfig2.Size = new System.Drawing.Size(563, 404);
            this.TabConfig2.Controls.SetChildIndex(this.TabGeneral, 0);
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(415, 492);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(496, 492);
            // 
            // TabGeneral
            // 
            this.TabGeneral.Controls.Add(this.groupBox3);
            this.TabGeneral.Controls.Add(this.GrpConnection);
            this.TabGeneral.Controls.Add(this.groupBox2);
            this.TabGeneral.Location = new System.Drawing.Point(4, 22);
            this.TabGeneral.Name = "TabGeneral";
            this.TabGeneral.Size = new System.Drawing.Size(555, 378);
            this.TabGeneral.TabIndex = 3;
            this.TabGeneral.Text = "General";
            this.TabGeneral.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.BtnDynDataDestinationTable);
            this.groupBox3.Controls.Add(this.TxtDestinationTable);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Location = new System.Drawing.Point(15, 94);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(524, 73);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Destination";
            // 
            // BtnDynDataDestinationTable
            // 
            this.BtnDynDataDestinationTable.Image = global::TDP.Robot.Plugins.Core.Resource.LightningAdd;
            this.BtnDynDataDestinationTable.Location = new System.Drawing.Point(412, 28);
            this.BtnDynDataDestinationTable.Name = "BtnDynDataDestinationTable";
            this.BtnDynDataDestinationTable.Size = new System.Drawing.Size(23, 21);
            this.BtnDynDataDestinationTable.TabIndex = 33;
            this.BtnDynDataDestinationTable.Text = "...";
            this.BtnDynDataDestinationTable.UseVisualStyleBackColor = true;
            // 
            // TxtDestinationTable
            // 
            this.TxtDestinationTable.Location = new System.Drawing.Point(109, 28);
            this.TxtDestinationTable.Name = "TxtDestinationTable";
            this.TxtDestinationTable.Size = new System.Drawing.Size(297, 20);
            this.TxtDestinationTable.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Destination table";
            // 
            // GrpConnection
            // 
            this.GrpConnection.Controls.Add(this.TxtDatabase);
            this.GrpConnection.Controls.Add(this.label5);
            this.GrpConnection.Controls.Add(this.TxtServer);
            this.GrpConnection.Controls.Add(this.label4);
            this.GrpConnection.Controls.Add(this.TxtPassword);
            this.GrpConnection.Controls.Add(this.label11);
            this.GrpConnection.Controls.Add(this.TxtUserName);
            this.GrpConnection.Controls.Add(this.label10);
            this.GrpConnection.Controls.Add(this.TxtCommandTimeout);
            this.GrpConnection.Controls.Add(this.label6);
            this.GrpConnection.Controls.Add(this.TxtConnectionStringOptions);
            this.GrpConnection.Controls.Add(this.label3);
            this.GrpConnection.Location = new System.Drawing.Point(15, 173);
            this.GrpConnection.Name = "GrpConnection";
            this.GrpConnection.Size = new System.Drawing.Size(524, 188);
            this.GrpConnection.TabIndex = 2;
            this.GrpConnection.TabStop = false;
            this.GrpConnection.Text = "Connection";
            // 
            // TxtDatabase
            // 
            this.TxtDatabase.Location = new System.Drawing.Point(140, 51);
            this.TxtDatabase.Name = "TxtDatabase";
            this.TxtDatabase.Size = new System.Drawing.Size(269, 20);
            this.TxtDatabase.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(81, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Database";
            // 
            // TxtServer
            // 
            this.TxtServer.Location = new System.Drawing.Point(140, 25);
            this.TxtServer.Name = "TxtServer";
            this.TxtServer.Size = new System.Drawing.Size(269, 20);
            this.TxtServer.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(96, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Server";
            // 
            // TxtPassword
            // 
            this.TxtPassword.Location = new System.Drawing.Point(140, 103);
            this.TxtPassword.Name = "TxtPassword";
            this.TxtPassword.PasswordChar = '*';
            this.TxtPassword.Size = new System.Drawing.Size(269, 20);
            this.TxtPassword.TabIndex = 7;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(81, 106);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 13);
            this.label11.TabIndex = 6;
            this.label11.Text = "Password";
            // 
            // TxtUserName
            // 
            this.TxtUserName.Location = new System.Drawing.Point(140, 77);
            this.TxtUserName.Name = "TxtUserName";
            this.TxtUserName.Size = new System.Drawing.Size(269, 20);
            this.TxtUserName.TabIndex = 5;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(79, 80);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 13);
            this.label10.TabIndex = 4;
            this.label10.Text = "Username";
            // 
            // TxtCommandTimeout
            // 
            this.TxtCommandTimeout.Location = new System.Drawing.Point(140, 154);
            this.TxtCommandTimeout.Name = "TxtCommandTimeout";
            this.TxtCommandTimeout.Size = new System.Drawing.Size(91, 20);
            this.TxtCommandTimeout.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(43, 157);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Command timeout";
            // 
            // TxtConnectionStringOptions
            // 
            this.TxtConnectionStringOptions.Location = new System.Drawing.Point(140, 128);
            this.TxtConnectionStringOptions.Name = "TxtConnectionStringOptions";
            this.TxtConnectionStringOptions.Size = new System.Drawing.Size(269, 20);
            this.TxtConnectionStringOptions.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Connection string options";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BtnDynDataSourceRecordset);
            this.groupBox2.Controls.Add(this.TxtSourceRecordset);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(15, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(524, 65);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Source";
            // 
            // BtnDynDataSourceRecordset
            // 
            this.BtnDynDataSourceRecordset.Image = global::TDP.Robot.Plugins.Core.Resource.LightningAdd;
            this.BtnDynDataSourceRecordset.Location = new System.Drawing.Point(412, 25);
            this.BtnDynDataSourceRecordset.Name = "BtnDynDataSourceRecordset";
            this.BtnDynDataSourceRecordset.Size = new System.Drawing.Size(23, 21);
            this.BtnDynDataSourceRecordset.TabIndex = 33;
            this.BtnDynDataSourceRecordset.Text = "...";
            this.BtnDynDataSourceRecordset.UseVisualStyleBackColor = true;
            // 
            // TxtSourceRecordset
            // 
            this.TxtSourceRecordset.Location = new System.Drawing.Point(109, 25);
            this.TxtSourceRecordset.Name = "TxtSourceRecordset";
            this.TxtSourceRecordset.Size = new System.Drawing.Size(297, 20);
            this.TxtSourceRecordset.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Source recordset";
            // 
            // WndSqlServerBulkCopyTaskConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 540);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WndSqlServerBulkCopyTaskConfig";
            this.Text = "Sql server bulk copy task";
            this.TabConfig2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrProvider)).EndInit();
            this.TabGeneral.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.GrpConnection.ResumeLayout(false);
            this.GrpConnection.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage TabGeneral;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox TxtSourceRecordset;
        private System.Windows.Forms.GroupBox GrpConnection;
        private System.Windows.Forms.TextBox TxtDatabase;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtServer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtPassword;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox TxtUserName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox TxtCommandTimeout;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TxtConnectionStringOptions;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox TxtDestinationTable;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button BtnDynDataDestinationTable;
        private System.Windows.Forms.Button BtnDynDataSourceRecordset;
    }
}