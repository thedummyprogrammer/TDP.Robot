namespace TDP.Robot.Plugins.Core.SqlServerCommandTask
{
    partial class WndSqlServerCommandTaskConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WndSqlServerCommandTaskConfig));
            this.TabGeneral = new System.Windows.Forms.TabPage();
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
            this.TxtConnectionString = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.GrpQuery = new System.Windows.Forms.GroupBox();
            this.ChkCommandReturnsRecordset = new System.Windows.Forms.CheckBox();
            this.BtnRemove = new System.Windows.Forms.Button();
            this.BtnEdit = new System.Windows.Forms.Button();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.LblType = new System.Windows.Forms.Label();
            this.RdbStoredProcedure = new System.Windows.Forms.RadioButton();
            this.RdbText = new System.Windows.Forms.RadioButton();
            this.LstParameters = new System.Windows.Forms.ListBox();
            this.LblParameters = new System.Windows.Forms.Label();
            this.TxtQuery = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TabConfig2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrProvider)).BeginInit();
            this.TabGeneral.SuspendLayout();
            this.GrpConnection.SuspendLayout();
            this.GrpQuery.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabConfig2
            // 
            this.TabConfig2.Controls.Add(this.TabGeneral);
            this.TabConfig2.Size = new System.Drawing.Size(621, 538);
            this.TabConfig2.TabIndex = 1;
            this.TabConfig2.Controls.SetChildIndex(this.TabGeneral, 0);
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(473, 626);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(554, 626);
            // 
            // groupBox1
            // 
            this.groupBox1.Size = new System.Drawing.Size(621, 64);
            this.groupBox1.TabIndex = 0;
            // 
            // ChkDoNotLog
            // 
            this.ChkDoNotLog.Location = new System.Drawing.Point(535, 35);
            this.ChkDoNotLog.TabIndex = 3;
            // 
            // ChkDisable
            // 
            this.ChkDisable.Location = new System.Drawing.Point(535, 12);
            this.ChkDisable.TabIndex = 2;
            // 
            // TxtName
            // 
            this.TxtName.Size = new System.Drawing.Size(337, 20);
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
            this.TabGeneral.Controls.Add(this.GrpQuery);
            this.TabGeneral.Location = new System.Drawing.Point(4, 22);
            this.TabGeneral.Name = "TabGeneral";
            this.TabGeneral.Size = new System.Drawing.Size(613, 512);
            this.TabGeneral.TabIndex = 3;
            this.TabGeneral.Text = "General";
            this.TabGeneral.UseVisualStyleBackColor = true;
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
            this.GrpConnection.Controls.Add(this.TxtConnectionString);
            this.GrpConnection.Controls.Add(this.label3);
            this.GrpConnection.Location = new System.Drawing.Point(9, 309);
            this.GrpConnection.Name = "GrpConnection";
            this.GrpConnection.Size = new System.Drawing.Size(597, 191);
            this.GrpConnection.TabIndex = 1;
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
            // TxtConnectionString
            // 
            this.TxtConnectionString.Location = new System.Drawing.Point(140, 128);
            this.TxtConnectionString.Name = "TxtConnectionString";
            this.TxtConnectionString.Size = new System.Drawing.Size(269, 20);
            this.TxtConnectionString.TabIndex = 9;
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
            // GrpQuery
            // 
            this.GrpQuery.Controls.Add(this.ChkCommandReturnsRecordset);
            this.GrpQuery.Controls.Add(this.BtnRemove);
            this.GrpQuery.Controls.Add(this.BtnEdit);
            this.GrpQuery.Controls.Add(this.BtnAdd);
            this.GrpQuery.Controls.Add(this.LblType);
            this.GrpQuery.Controls.Add(this.RdbStoredProcedure);
            this.GrpQuery.Controls.Add(this.RdbText);
            this.GrpQuery.Controls.Add(this.LstParameters);
            this.GrpQuery.Controls.Add(this.LblParameters);
            this.GrpQuery.Controls.Add(this.TxtQuery);
            this.GrpQuery.Controls.Add(this.label2);
            this.GrpQuery.Location = new System.Drawing.Point(9, 8);
            this.GrpQuery.Name = "GrpQuery";
            this.GrpQuery.Size = new System.Drawing.Size(597, 295);
            this.GrpQuery.TabIndex = 0;
            this.GrpQuery.TabStop = false;
            this.GrpQuery.Text = "Command configuration";
            // 
            // ChkCommandReturnsRecordset
            // 
            this.ChkCommandReturnsRecordset.AutoSize = true;
            this.ChkCommandReturnsRecordset.Location = new System.Drawing.Point(7, 263);
            this.ChkCommandReturnsRecordset.Name = "ChkCommandReturnsRecordset";
            this.ChkCommandReturnsRecordset.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ChkCommandReturnsRecordset.Size = new System.Drawing.Size(110, 17);
            this.ChkCommandReturnsRecordset.TabIndex = 10;
            this.ChkCommandReturnsRecordset.Text = "Returns recordset";
            this.ChkCommandReturnsRecordset.UseVisualStyleBackColor = true;
            // 
            // BtnRemove
            // 
            this.BtnRemove.Location = new System.Drawing.Point(505, 203);
            this.BtnRemove.Name = "BtnRemove";
            this.BtnRemove.Size = new System.Drawing.Size(86, 23);
            this.BtnRemove.TabIndex = 9;
            this.BtnRemove.Text = "Remove";
            this.BtnRemove.UseVisualStyleBackColor = true;
            this.BtnRemove.Click += new System.EventHandler(this.BtnRemove_Click);
            // 
            // BtnEdit
            // 
            this.BtnEdit.Location = new System.Drawing.Point(505, 174);
            this.BtnEdit.Name = "BtnEdit";
            this.BtnEdit.Size = new System.Drawing.Size(86, 23);
            this.BtnEdit.TabIndex = 8;
            this.BtnEdit.Text = "Edit...";
            this.BtnEdit.UseVisualStyleBackColor = true;
            this.BtnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
            // 
            // BtnAdd
            // 
            this.BtnAdd.Location = new System.Drawing.Point(505, 145);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(86, 23);
            this.BtnAdd.TabIndex = 7;
            this.BtnAdd.Text = "Add...";
            this.BtnAdd.UseVisualStyleBackColor = true;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // LblType
            // 
            this.LblType.AutoSize = true;
            this.LblType.Location = new System.Drawing.Point(60, 122);
            this.LblType.Name = "LblType";
            this.LblType.Size = new System.Drawing.Size(31, 13);
            this.LblType.TabIndex = 2;
            this.LblType.Text = "Type";
            // 
            // RdbStoredProcedure
            // 
            this.RdbStoredProcedure.AutoSize = true;
            this.RdbStoredProcedure.Location = new System.Drawing.Point(153, 120);
            this.RdbStoredProcedure.Name = "RdbStoredProcedure";
            this.RdbStoredProcedure.Size = new System.Drawing.Size(107, 17);
            this.RdbStoredProcedure.TabIndex = 4;
            this.RdbStoredProcedure.Text = "Stored procedure";
            this.RdbStoredProcedure.UseVisualStyleBackColor = true;
            // 
            // RdbText
            // 
            this.RdbText.AutoSize = true;
            this.RdbText.Checked = true;
            this.RdbText.Location = new System.Drawing.Point(101, 120);
            this.RdbText.Name = "RdbText";
            this.RdbText.Size = new System.Drawing.Size(46, 17);
            this.RdbText.TabIndex = 3;
            this.RdbText.TabStop = true;
            this.RdbText.Text = "Text";
            this.RdbText.UseVisualStyleBackColor = true;
            // 
            // LstParameters
            // 
            this.LstParameters.FormattingEnabled = true;
            this.LstParameters.Location = new System.Drawing.Point(101, 145);
            this.LstParameters.Name = "LstParameters";
            this.LstParameters.Size = new System.Drawing.Size(395, 108);
            this.LstParameters.TabIndex = 6;
            this.LstParameters.DoubleClick += new System.EventHandler(this.LstParameters_DoubleClick);
            // 
            // LblParameters
            // 
            this.LblParameters.AutoSize = true;
            this.LblParameters.Location = new System.Drawing.Point(35, 145);
            this.LblParameters.Name = "LblParameters";
            this.LblParameters.Size = new System.Drawing.Size(60, 13);
            this.LblParameters.TabIndex = 5;
            this.LblParameters.Text = "Parameters";
            // 
            // TxtQuery
            // 
            this.TxtQuery.Location = new System.Drawing.Point(101, 20);
            this.TxtQuery.Multiline = true;
            this.TxtQuery.Name = "TxtQuery";
            this.TxtQuery.Size = new System.Drawing.Size(490, 91);
            this.TxtQuery.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(60, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Query";
            // 
            // WndSqlServerCommandTaskConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 661);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WndSqlServerCommandTaskConfig";
            this.Text = "Sql Server command task configuration";
            this.TabConfig2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrProvider)).EndInit();
            this.TabGeneral.ResumeLayout(false);
            this.GrpConnection.ResumeLayout(false);
            this.GrpConnection.PerformLayout();
            this.GrpQuery.ResumeLayout(false);
            this.GrpQuery.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage TabGeneral;
        private System.Windows.Forms.TextBox TxtCommandTimeout;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button BtnRemove;
        private System.Windows.Forms.Button BtnEdit;
        private System.Windows.Forms.Button BtnAdd;
        private System.Windows.Forms.Label LblType;
        private System.Windows.Forms.RadioButton RdbStoredProcedure;
        private System.Windows.Forms.RadioButton RdbText;
        private System.Windows.Forms.ListBox LstParameters;
        private System.Windows.Forms.Label LblParameters;
        private System.Windows.Forms.TextBox TxtConnectionString;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtQuery;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox ChkCommandReturnsRecordset;
        private System.Windows.Forms.TextBox TxtPassword;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox TxtUserName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox TxtServer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox GrpQuery;
        private System.Windows.Forms.GroupBox GrpConnection;
        private System.Windows.Forms.TextBox TxtDatabase;
        private System.Windows.Forms.Label label5;
    }
}