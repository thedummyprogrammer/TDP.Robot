
namespace TDP.Robot.Plugins.Core.FtpSftpTask
{
    partial class WndFtpSftpTaskConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WndFtpSftpTaskConfig));
            this.TabGeneral = new System.Windows.Forms.TabPage();
            this.GrpConnection = new System.Windows.Forms.GroupBox();
            this.CmbCommand = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.TxtPassword = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TxtUsername = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtPort = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtHost = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CmbProtocol = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.GrpDelete = new System.Windows.Forms.GroupBox();
            this.BtnRemoveDeletePath = new System.Windows.Forms.Button();
            this.BtnEditDeletePath = new System.Windows.Forms.Button();
            this.BtnAddDeletePath = new System.Windows.Forms.Button();
            this.LblDeletePaths = new System.Windows.Forms.Label();
            this.LstDeletePaths = new System.Windows.Forms.ListBox();
            this.GrpCopyMove = new System.Windows.Forms.GroupBox();
            this.BtnRemoveCopyPath = new System.Windows.Forms.Button();
            this.BtnEditCopyPath = new System.Windows.Forms.Button();
            this.BtnAddCopyPath = new System.Windows.Forms.Button();
            this.LblCopyPaths = new System.Windows.Forms.Label();
            this.LstCopyPaths = new System.Windows.Forms.ListBox();
            this.TabConfig2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrProvider)).BeginInit();
            this.TabGeneral.SuspendLayout();
            this.GrpConnection.SuspendLayout();
            this.GrpDelete.SuspendLayout();
            this.GrpCopyMove.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabConfig2
            // 
            this.TabConfig2.Controls.Add(this.TabGeneral);
            this.TabConfig2.Controls.SetChildIndex(this.TabGeneral, 0);
            // 
            // TabGeneral
            // 
            this.TabGeneral.Controls.Add(this.GrpConnection);
            this.TabGeneral.Controls.Add(this.GrpCopyMove);
            this.TabGeneral.Controls.Add(this.GrpDelete);
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
            this.GrpConnection.Controls.Add(this.CmbCommand);
            this.GrpConnection.Controls.Add(this.label7);
            this.GrpConnection.Controls.Add(this.TxtPassword);
            this.GrpConnection.Controls.Add(this.label6);
            this.GrpConnection.Controls.Add(this.TxtUsername);
            this.GrpConnection.Controls.Add(this.label5);
            this.GrpConnection.Controls.Add(this.TxtPort);
            this.GrpConnection.Controls.Add(this.label4);
            this.GrpConnection.Controls.Add(this.TxtHost);
            this.GrpConnection.Controls.Add(this.label3);
            this.GrpConnection.Controls.Add(this.CmbProtocol);
            this.GrpConnection.Controls.Add(this.label2);
            this.GrpConnection.Location = new System.Drawing.Point(6, 10);
            this.GrpConnection.Name = "GrpConnection";
            this.GrpConnection.Size = new System.Drawing.Size(537, 173);
            this.GrpConnection.TabIndex = 10;
            this.GrpConnection.TabStop = false;
            this.GrpConnection.Text = "Connection";
            // 
            // CmbCommand
            // 
            this.CmbCommand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbCommand.FormattingEnabled = true;
            this.CmbCommand.Location = new System.Drawing.Point(77, 139);
            this.CmbCommand.Name = "CmbCommand";
            this.CmbCommand.Size = new System.Drawing.Size(209, 21);
            this.CmbCommand.TabIndex = 21;
            this.CmbCommand.SelectedIndexChanged += new System.EventHandler(this.CmbCommand_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 139);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Command";
            // 
            // TxtPassword
            // 
            this.TxtPassword.Location = new System.Drawing.Point(77, 113);
            this.TxtPassword.MaxLength = 1000;
            this.TxtPassword.Name = "TxtPassword";
            this.TxtPassword.PasswordChar = '*';
            this.TxtPassword.Size = new System.Drawing.Size(209, 20);
            this.TxtPassword.TabIndex = 19;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 113);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Password";
            // 
            // TxtUsername
            // 
            this.TxtUsername.Location = new System.Drawing.Point(77, 87);
            this.TxtUsername.MaxLength = 1000;
            this.TxtUsername.Name = "TxtUsername";
            this.TxtUsername.Size = new System.Drawing.Size(209, 20);
            this.TxtUsername.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Username";
            // 
            // TxtPort
            // 
            this.TxtPort.Location = new System.Drawing.Point(335, 61);
            this.TxtPort.MaxLength = 5;
            this.TxtPort.Name = "TxtPort";
            this.TxtPort.Size = new System.Drawing.Size(56, 20);
            this.TxtPort.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(303, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Port";
            // 
            // TxtHost
            // 
            this.TxtHost.Location = new System.Drawing.Point(77, 61);
            this.TxtHost.MaxLength = 1000;
            this.TxtHost.Name = "TxtHost";
            this.TxtHost.Size = new System.Drawing.Size(209, 20);
            this.TxtHost.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Host";
            // 
            // CmbProtocol
            // 
            this.CmbProtocol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbProtocol.FormattingEnabled = true;
            this.CmbProtocol.Location = new System.Drawing.Point(77, 33);
            this.CmbProtocol.Name = "CmbProtocol";
            this.CmbProtocol.Size = new System.Drawing.Size(209, 21);
            this.CmbProtocol.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Protocol";
            // 
            // GrpDelete
            // 
            this.GrpDelete.Controls.Add(this.BtnRemoveDeletePath);
            this.GrpDelete.Controls.Add(this.BtnEditDeletePath);
            this.GrpDelete.Controls.Add(this.BtnAddDeletePath);
            this.GrpDelete.Controls.Add(this.LblDeletePaths);
            this.GrpDelete.Controls.Add(this.LstDeletePaths);
            this.GrpDelete.Location = new System.Drawing.Point(5, 196);
            this.GrpDelete.Name = "GrpDelete";
            this.GrpDelete.Size = new System.Drawing.Size(537, 122);
            this.GrpDelete.TabIndex = 12;
            this.GrpDelete.TabStop = false;
            this.GrpDelete.Text = "Delete";
            this.GrpDelete.Visible = false;
            // 
            // BtnRemoveDeletePath
            // 
            this.BtnRemoveDeletePath.Location = new System.Drawing.Point(443, 85);
            this.BtnRemoveDeletePath.Name = "BtnRemoveDeletePath";
            this.BtnRemoveDeletePath.Size = new System.Drawing.Size(87, 23);
            this.BtnRemoveDeletePath.TabIndex = 9;
            this.BtnRemoveDeletePath.Text = "Remove";
            this.BtnRemoveDeletePath.UseVisualStyleBackColor = true;
            this.BtnRemoveDeletePath.Click += new System.EventHandler(this.BtnRemoveDeletePath_Click);
            // 
            // BtnEditDeletePath
            // 
            this.BtnEditDeletePath.Location = new System.Drawing.Point(443, 56);
            this.BtnEditDeletePath.Name = "BtnEditDeletePath";
            this.BtnEditDeletePath.Size = new System.Drawing.Size(87, 23);
            this.BtnEditDeletePath.TabIndex = 8;
            this.BtnEditDeletePath.Text = "Edit...";
            this.BtnEditDeletePath.UseVisualStyleBackColor = true;
            this.BtnEditDeletePath.Click += new System.EventHandler(this.BtnEditDeletePath_Click);
            // 
            // BtnAddDeletePath
            // 
            this.BtnAddDeletePath.Location = new System.Drawing.Point(444, 27);
            this.BtnAddDeletePath.Name = "BtnAddDeletePath";
            this.BtnAddDeletePath.Size = new System.Drawing.Size(87, 23);
            this.BtnAddDeletePath.TabIndex = 7;
            this.BtnAddDeletePath.Text = "Add...";
            this.BtnAddDeletePath.UseVisualStyleBackColor = true;
            this.BtnAddDeletePath.Click += new System.EventHandler(this.BtnAddDeletePath_Click);
            // 
            // LblDeletePaths
            // 
            this.LblDeletePaths.AutoSize = true;
            this.LblDeletePaths.Location = new System.Drawing.Point(6, 26);
            this.LblDeletePaths.Name = "LblDeletePaths";
            this.LblDeletePaths.Size = new System.Drawing.Size(34, 13);
            this.LblDeletePaths.TabIndex = 6;
            this.LblDeletePaths.Text = "Paths";
            // 
            // LstDeletePaths
            // 
            this.LstDeletePaths.FormattingEnabled = true;
            this.LstDeletePaths.Location = new System.Drawing.Point(46, 26);
            this.LstDeletePaths.Name = "LstDeletePaths";
            this.LstDeletePaths.Size = new System.Drawing.Size(391, 82);
            this.LstDeletePaths.TabIndex = 5;
            this.LstDeletePaths.DoubleClick += new System.EventHandler(this.LstDeletePaths_DoubleClick);
            // 
            // GrpCopyMove
            // 
            this.GrpCopyMove.Controls.Add(this.BtnRemoveCopyPath);
            this.GrpCopyMove.Controls.Add(this.BtnEditCopyPath);
            this.GrpCopyMove.Controls.Add(this.BtnAddCopyPath);
            this.GrpCopyMove.Controls.Add(this.LblCopyPaths);
            this.GrpCopyMove.Controls.Add(this.LstCopyPaths);
            this.GrpCopyMove.Location = new System.Drawing.Point(5, 196);
            this.GrpCopyMove.Name = "GrpCopyMove";
            this.GrpCopyMove.Size = new System.Drawing.Size(537, 122);
            this.GrpCopyMove.TabIndex = 11;
            this.GrpCopyMove.TabStop = false;
            this.GrpCopyMove.Text = "Copy / Move";
            // 
            // BtnRemoveCopyPath
            // 
            this.BtnRemoveCopyPath.Location = new System.Drawing.Point(443, 85);
            this.BtnRemoveCopyPath.Name = "BtnRemoveCopyPath";
            this.BtnRemoveCopyPath.Size = new System.Drawing.Size(87, 23);
            this.BtnRemoveCopyPath.TabIndex = 4;
            this.BtnRemoveCopyPath.Text = "Remove";
            this.BtnRemoveCopyPath.UseVisualStyleBackColor = true;
            this.BtnRemoveCopyPath.Click += new System.EventHandler(this.BtnRemoveCopyPath_Click);
            // 
            // BtnEditCopyPath
            // 
            this.BtnEditCopyPath.Location = new System.Drawing.Point(443, 56);
            this.BtnEditCopyPath.Name = "BtnEditCopyPath";
            this.BtnEditCopyPath.Size = new System.Drawing.Size(87, 23);
            this.BtnEditCopyPath.TabIndex = 3;
            this.BtnEditCopyPath.Text = "Edit...";
            this.BtnEditCopyPath.UseVisualStyleBackColor = true;
            this.BtnEditCopyPath.Click += new System.EventHandler(this.BtnEditCopyPath_Click);
            // 
            // BtnAddCopyPath
            // 
            this.BtnAddCopyPath.Location = new System.Drawing.Point(444, 27);
            this.BtnAddCopyPath.Name = "BtnAddCopyPath";
            this.BtnAddCopyPath.Size = new System.Drawing.Size(87, 23);
            this.BtnAddCopyPath.TabIndex = 2;
            this.BtnAddCopyPath.Text = "Add...";
            this.BtnAddCopyPath.UseVisualStyleBackColor = true;
            this.BtnAddCopyPath.Click += new System.EventHandler(this.BtnAddCopyPath_Click);
            // 
            // LblCopyPaths
            // 
            this.LblCopyPaths.AutoSize = true;
            this.LblCopyPaths.Location = new System.Drawing.Point(6, 26);
            this.LblCopyPaths.Name = "LblCopyPaths";
            this.LblCopyPaths.Size = new System.Drawing.Size(34, 13);
            this.LblCopyPaths.TabIndex = 1;
            this.LblCopyPaths.Text = "Paths";
            // 
            // LstCopyPaths
            // 
            this.LstCopyPaths.FormattingEnabled = true;
            this.LstCopyPaths.Location = new System.Drawing.Point(46, 26);
            this.LstCopyPaths.Name = "LstCopyPaths";
            this.LstCopyPaths.Size = new System.Drawing.Size(391, 82);
            this.LstCopyPaths.TabIndex = 0;
            this.LstCopyPaths.DoubleClick += new System.EventHandler(this.LstCopyPaths_DoubleClick);
            // 
            // WndFtpSftpTaskConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 578);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WndFtpSftpTaskConfig";
            this.Text = "FTP / SFTP task configuration";
            this.TabConfig2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrProvider)).EndInit();
            this.TabGeneral.ResumeLayout(false);
            this.GrpConnection.ResumeLayout(false);
            this.GrpConnection.PerformLayout();
            this.GrpDelete.ResumeLayout(false);
            this.GrpDelete.PerformLayout();
            this.GrpCopyMove.ResumeLayout(false);
            this.GrpCopyMove.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage TabGeneral;
        private System.Windows.Forms.GroupBox GrpConnection;
        private System.Windows.Forms.TextBox TxtPassword;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TxtUsername;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtPort;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtHost;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CmbProtocol;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox CmbCommand;
        private System.Windows.Forms.GroupBox GrpCopyMove;
        private System.Windows.Forms.GroupBox GrpDelete;
        private System.Windows.Forms.ListBox LstCopyPaths;
        private System.Windows.Forms.Label LblCopyPaths;
        private System.Windows.Forms.Button BtnAddCopyPath;
        private System.Windows.Forms.Button BtnEditCopyPath;
        private System.Windows.Forms.Button BtnRemoveCopyPath;
        private System.Windows.Forms.Button BtnRemoveDeletePath;
        private System.Windows.Forms.Button BtnEditDeletePath;
        private System.Windows.Forms.Button BtnAddDeletePath;
        private System.Windows.Forms.Label LblDeletePaths;
        private System.Windows.Forms.ListBox LstDeletePaths;
    }
}