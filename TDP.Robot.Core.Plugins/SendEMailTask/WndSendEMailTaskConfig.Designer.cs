namespace TDP.Robot.Plugins.Core.SendEMailTask
{
    partial class WndSendEMailTaskConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WndSendEMailTaskConfig));
            this.TabMessage = new System.Windows.Forms.TabPage();
            this.BtnDynDataMessage = new System.Windows.Forms.Button();
            this.BtnDynDataSubject = new System.Windows.Forms.Button();
            this.BtnRemoveAttachment = new System.Windows.Forms.Button();
            this.BtnAddAttachment = new System.Windows.Forms.Button();
            this.BtnRemoveCC = new System.Windows.Forms.Button();
            this.BtnAddCC = new System.Windows.Forms.Button();
            this.BtnRemoveRecipient = new System.Windows.Forms.Button();
            this.BtnAddRecipient = new System.Windows.Forms.Button();
            this.LstCC = new System.Windows.Forms.ListBox();
            this.LstRecipients = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.LstAttachments = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TxtMessage = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtSubject = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TabConnection = new System.Windows.Forms.TabPage();
            this.BtnDynDataPassword = new System.Windows.Forms.Button();
            this.BtnDynDataUserName = new System.Windows.Forms.Button();
            this.BtnDynDataPort = new System.Windows.Forms.Button();
            this.BtnDynDataSMTPServer = new System.Windows.Forms.Button();
            this.BtnDynDataSender = new System.Windows.Forms.Button();
            this.ChkAuthenticate = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.TxtConfirmPassword = new System.Windows.Forms.TextBox();
            this.ChkUseSSL = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.TxtPort = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.TxtPassword = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.TxtUserName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.TxtSMTPServer = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.TxtSender = new System.Windows.Forms.TextBox();
            this.TabConfig2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrProvider)).BeginInit();
            this.TabMessage.SuspendLayout();
            this.TabConnection.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabConfig2
            // 
            this.TabConfig2.Controls.Add(this.TabMessage);
            this.TabConfig2.Controls.Add(this.TabConnection);
            this.TabConfig2.Size = new System.Drawing.Size(559, 441);
            this.TabConfig2.Controls.SetChildIndex(this.TabConnection, 0);
            this.TabConfig2.Controls.SetChildIndex(this.TabMessage, 0);
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(412, 530);
            this.BtnSave.TabIndex = 3;
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(493, 530);
            this.BtnCancel.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Size = new System.Drawing.Size(559, 64);
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
            // TabMessage
            // 
            this.TabMessage.Controls.Add(this.BtnDynDataMessage);
            this.TabMessage.Controls.Add(this.BtnDynDataSubject);
            this.TabMessage.Controls.Add(this.BtnRemoveAttachment);
            this.TabMessage.Controls.Add(this.BtnAddAttachment);
            this.TabMessage.Controls.Add(this.BtnRemoveCC);
            this.TabMessage.Controls.Add(this.BtnAddCC);
            this.TabMessage.Controls.Add(this.BtnRemoveRecipient);
            this.TabMessage.Controls.Add(this.BtnAddRecipient);
            this.TabMessage.Controls.Add(this.LstCC);
            this.TabMessage.Controls.Add(this.LstRecipients);
            this.TabMessage.Controls.Add(this.label7);
            this.TabMessage.Controls.Add(this.LstAttachments);
            this.TabMessage.Controls.Add(this.label6);
            this.TabMessage.Controls.Add(this.TxtMessage);
            this.TabMessage.Controls.Add(this.label5);
            this.TabMessage.Controls.Add(this.TxtSubject);
            this.TabMessage.Controls.Add(this.label3);
            this.TabMessage.Controls.Add(this.label2);
            this.TabMessage.Location = new System.Drawing.Point(4, 22);
            this.TabMessage.Name = "TabMessage";
            this.TabMessage.Padding = new System.Windows.Forms.Padding(3);
            this.TabMessage.Size = new System.Drawing.Size(551, 415);
            this.TabMessage.TabIndex = 3;
            this.TabMessage.Text = "Message";
            this.TabMessage.UseVisualStyleBackColor = true;
            // 
            // BtnDynDataMessage
            // 
            this.BtnDynDataMessage.Image = global::TDP.Robot.Plugins.Core.Resource.LightningAdd;
            this.BtnDynDataMessage.Location = new System.Drawing.Point(488, 185);
            this.BtnDynDataMessage.Name = "BtnDynDataMessage";
            this.BtnDynDataMessage.Size = new System.Drawing.Size(23, 21);
            this.BtnDynDataMessage.TabIndex = 33;
            this.BtnDynDataMessage.Text = "...";
            this.BtnDynDataMessage.UseVisualStyleBackColor = true;
            // 
            // BtnDynDataSubject
            // 
            this.BtnDynDataSubject.Image = global::TDP.Robot.Plugins.Core.Resource.LightningAdd;
            this.BtnDynDataSubject.Location = new System.Drawing.Point(488, 158);
            this.BtnDynDataSubject.Name = "BtnDynDataSubject";
            this.BtnDynDataSubject.Size = new System.Drawing.Size(23, 21);
            this.BtnDynDataSubject.TabIndex = 32;
            this.BtnDynDataSubject.Text = "...";
            this.BtnDynDataSubject.UseVisualStyleBackColor = true;
            // 
            // BtnRemoveAttachment
            // 
            this.BtnRemoveAttachment.Location = new System.Drawing.Point(439, 322);
            this.BtnRemoveAttachment.Name = "BtnRemoveAttachment";
            this.BtnRemoveAttachment.Size = new System.Drawing.Size(75, 23);
            this.BtnRemoveAttachment.TabIndex = 31;
            this.BtnRemoveAttachment.Text = "Remove";
            this.BtnRemoveAttachment.UseVisualStyleBackColor = true;
            this.BtnRemoveAttachment.Click += new System.EventHandler(this.BtnRemoveAttachment_Click);
            // 
            // BtnAddAttachment
            // 
            this.BtnAddAttachment.Location = new System.Drawing.Point(439, 293);
            this.BtnAddAttachment.Name = "BtnAddAttachment";
            this.BtnAddAttachment.Size = new System.Drawing.Size(75, 23);
            this.BtnAddAttachment.TabIndex = 30;
            this.BtnAddAttachment.Text = "Add...";
            this.BtnAddAttachment.UseVisualStyleBackColor = true;
            this.BtnAddAttachment.Click += new System.EventHandler(this.BtnAddAttachment_Click);
            // 
            // BtnRemoveCC
            // 
            this.BtnRemoveCC.Location = new System.Drawing.Point(439, 113);
            this.BtnRemoveCC.Name = "BtnRemoveCC";
            this.BtnRemoveCC.Size = new System.Drawing.Size(75, 23);
            this.BtnRemoveCC.TabIndex = 23;
            this.BtnRemoveCC.Text = "Remove";
            this.BtnRemoveCC.UseVisualStyleBackColor = true;
            this.BtnRemoveCC.Click += new System.EventHandler(this.BtnRemoveCC_Click);
            // 
            // BtnAddCC
            // 
            this.BtnAddCC.Location = new System.Drawing.Point(439, 84);
            this.BtnAddCC.Name = "BtnAddCC";
            this.BtnAddCC.Size = new System.Drawing.Size(75, 23);
            this.BtnAddCC.TabIndex = 22;
            this.BtnAddCC.Text = "Add...";
            this.BtnAddCC.UseVisualStyleBackColor = true;
            this.BtnAddCC.Click += new System.EventHandler(this.BtnAddCC_Click);
            // 
            // BtnRemoveRecipient
            // 
            this.BtnRemoveRecipient.Location = new System.Drawing.Point(439, 51);
            this.BtnRemoveRecipient.Name = "BtnRemoveRecipient";
            this.BtnRemoveRecipient.Size = new System.Drawing.Size(75, 23);
            this.BtnRemoveRecipient.TabIndex = 19;
            this.BtnRemoveRecipient.Text = "Remove";
            this.BtnRemoveRecipient.UseVisualStyleBackColor = true;
            this.BtnRemoveRecipient.Click += new System.EventHandler(this.BtnRemoveRecipient_Click);
            // 
            // BtnAddRecipient
            // 
            this.BtnAddRecipient.Location = new System.Drawing.Point(439, 22);
            this.BtnAddRecipient.Name = "BtnAddRecipient";
            this.BtnAddRecipient.Size = new System.Drawing.Size(75, 23);
            this.BtnAddRecipient.TabIndex = 18;
            this.BtnAddRecipient.Text = "Add...";
            this.BtnAddRecipient.UseVisualStyleBackColor = true;
            this.BtnAddRecipient.Click += new System.EventHandler(this.BtnAddRecipient_Click);
            // 
            // LstCC
            // 
            this.LstCC.FormattingEnabled = true;
            this.LstCC.Location = new System.Drawing.Point(86, 84);
            this.LstCC.Name = "LstCC";
            this.LstCC.Size = new System.Drawing.Size(346, 56);
            this.LstCC.TabIndex = 21;
            // 
            // LstRecipients
            // 
            this.LstRecipients.FormattingEnabled = true;
            this.LstRecipients.Location = new System.Drawing.Point(86, 22);
            this.LstRecipients.Name = "LstRecipients";
            this.LstRecipients.Size = new System.Drawing.Size(346, 56);
            this.LstRecipients.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 293);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 13);
            this.label7.TabIndex = 28;
            this.label7.Text = "Attachments";
            // 
            // LstAttachments
            // 
            this.LstAttachments.FormattingEnabled = true;
            this.LstAttachments.Location = new System.Drawing.Point(84, 293);
            this.LstAttachments.Name = "LstAttachments";
            this.LstAttachments.Size = new System.Drawing.Size(348, 56);
            this.LstAttachments.TabIndex = 29;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(29, 185);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 26;
            this.label6.Text = "Message";
            // 
            // TxtMessage
            // 
            this.TxtMessage.Location = new System.Drawing.Point(85, 185);
            this.TxtMessage.Multiline = true;
            this.TxtMessage.Name = "TxtMessage";
            this.TxtMessage.Size = new System.Drawing.Size(397, 90);
            this.TxtMessage.TabIndex = 27;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(36, 159);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "Subject";
            // 
            // TxtSubject
            // 
            this.TxtSubject.Location = new System.Drawing.Point(85, 159);
            this.TxtSubject.MaxLength = 1000;
            this.TxtSubject.Name = "TxtSubject";
            this.TxtSubject.Size = new System.Drawing.Size(397, 20);
            this.TxtSubject.TabIndex = 25;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(59, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "CC";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Recipients";
            // 
            // TabConnection
            // 
            this.TabConnection.Controls.Add(this.BtnDynDataPassword);
            this.TabConnection.Controls.Add(this.BtnDynDataUserName);
            this.TabConnection.Controls.Add(this.BtnDynDataPort);
            this.TabConnection.Controls.Add(this.BtnDynDataSMTPServer);
            this.TabConnection.Controls.Add(this.BtnDynDataSender);
            this.TabConnection.Controls.Add(this.ChkAuthenticate);
            this.TabConnection.Controls.Add(this.label13);
            this.TabConnection.Controls.Add(this.TxtConfirmPassword);
            this.TabConnection.Controls.Add(this.ChkUseSSL);
            this.TabConnection.Controls.Add(this.label12);
            this.TabConnection.Controls.Add(this.TxtPort);
            this.TabConnection.Controls.Add(this.label11);
            this.TabConnection.Controls.Add(this.TxtPassword);
            this.TabConnection.Controls.Add(this.label10);
            this.TabConnection.Controls.Add(this.TxtUserName);
            this.TabConnection.Controls.Add(this.label9);
            this.TabConnection.Controls.Add(this.TxtSMTPServer);
            this.TabConnection.Controls.Add(this.label8);
            this.TabConnection.Controls.Add(this.TxtSender);
            this.TabConnection.Location = new System.Drawing.Point(4, 22);
            this.TabConnection.Name = "TabConnection";
            this.TabConnection.Size = new System.Drawing.Size(551, 415);
            this.TabConnection.TabIndex = 4;
            this.TabConnection.Text = "Connection";
            this.TabConnection.UseVisualStyleBackColor = true;
            // 
            // BtnDynDataPassword
            // 
            this.BtnDynDataPassword.Image = global::TDP.Robot.Plugins.Core.Resource.LightningAdd;
            this.BtnDynDataPassword.Location = new System.Drawing.Point(428, 163);
            this.BtnDynDataPassword.Name = "BtnDynDataPassword";
            this.BtnDynDataPassword.Size = new System.Drawing.Size(23, 21);
            this.BtnDynDataPassword.TabIndex = 37;
            this.BtnDynDataPassword.Text = "...";
            this.BtnDynDataPassword.UseVisualStyleBackColor = true;
            // 
            // BtnDynDataUserName
            // 
            this.BtnDynDataUserName.Image = global::TDP.Robot.Plugins.Core.Resource.LightningAdd;
            this.BtnDynDataUserName.Location = new System.Drawing.Point(428, 138);
            this.BtnDynDataUserName.Name = "BtnDynDataUserName";
            this.BtnDynDataUserName.Size = new System.Drawing.Size(23, 21);
            this.BtnDynDataUserName.TabIndex = 36;
            this.BtnDynDataUserName.Text = "...";
            this.BtnDynDataUserName.UseVisualStyleBackColor = true;
            // 
            // BtnDynDataPort
            // 
            this.BtnDynDataPort.Image = global::TDP.Robot.Plugins.Core.Resource.LightningAdd;
            this.BtnDynDataPort.Location = new System.Drawing.Point(186, 80);
            this.BtnDynDataPort.Name = "BtnDynDataPort";
            this.BtnDynDataPort.Size = new System.Drawing.Size(23, 21);
            this.BtnDynDataPort.TabIndex = 35;
            this.BtnDynDataPort.Text = "...";
            this.BtnDynDataPort.UseVisualStyleBackColor = true;
            // 
            // BtnDynDataSMTPServer
            // 
            this.BtnDynDataSMTPServer.Image = global::TDP.Robot.Plugins.Core.Resource.LightningAdd;
            this.BtnDynDataSMTPServer.Location = new System.Drawing.Point(428, 53);
            this.BtnDynDataSMTPServer.Name = "BtnDynDataSMTPServer";
            this.BtnDynDataSMTPServer.Size = new System.Drawing.Size(23, 21);
            this.BtnDynDataSMTPServer.TabIndex = 34;
            this.BtnDynDataSMTPServer.Text = "...";
            this.BtnDynDataSMTPServer.UseVisualStyleBackColor = true;
            // 
            // BtnDynDataSender
            // 
            this.BtnDynDataSender.Image = global::TDP.Robot.Plugins.Core.Resource.LightningAdd;
            this.BtnDynDataSender.Location = new System.Drawing.Point(428, 12);
            this.BtnDynDataSender.Name = "BtnDynDataSender";
            this.BtnDynDataSender.Size = new System.Drawing.Size(23, 21);
            this.BtnDynDataSender.TabIndex = 33;
            this.BtnDynDataSender.Text = "...";
            this.BtnDynDataSender.UseVisualStyleBackColor = true;
            // 
            // ChkAuthenticate
            // 
            this.ChkAuthenticate.AutoSize = true;
            this.ChkAuthenticate.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ChkAuthenticate.Location = new System.Drawing.Point(30, 115);
            this.ChkAuthenticate.Name = "ChkAuthenticate";
            this.ChkAuthenticate.Size = new System.Drawing.Size(86, 17);
            this.ChkAuthenticate.TabIndex = 21;
            this.ChkAuthenticate.Text = "Authenticate";
            this.ChkAuthenticate.UseVisualStyleBackColor = true;
            this.ChkAuthenticate.CheckedChanged += new System.EventHandler(this.ChkAuthenticate_CheckedChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 190);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(90, 13);
            this.label13.TabIndex = 26;
            this.label13.Text = "Confirm password";
            // 
            // TxtConfirmPassword
            // 
            this.TxtConfirmPassword.Enabled = false;
            this.TxtConfirmPassword.Location = new System.Drawing.Point(102, 190);
            this.TxtConfirmPassword.MaxLength = 200;
            this.TxtConfirmPassword.Name = "TxtConfirmPassword";
            this.TxtConfirmPassword.PasswordChar = '*';
            this.TxtConfirmPassword.Size = new System.Drawing.Size(320, 20);
            this.TxtConfirmPassword.TabIndex = 27;
            // 
            // ChkUseSSL
            // 
            this.ChkUseSSL.AutoSize = true;
            this.ChkUseSSL.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ChkUseSSL.Location = new System.Drawing.Point(247, 82);
            this.ChkUseSSL.Name = "ChkUseSSL";
            this.ChkUseSSL.Size = new System.Drawing.Size(68, 17);
            this.ChkUseSSL.TabIndex = 20;
            this.ChkUseSSL.Text = "Use SSL";
            this.ChkUseSSL.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(70, 80);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(26, 13);
            this.label12.TabIndex = 18;
            this.label12.Text = "Port";
            // 
            // TxtPort
            // 
            this.TxtPort.Location = new System.Drawing.Point(102, 80);
            this.TxtPort.MaxLength = 5;
            this.TxtPort.Name = "TxtPort";
            this.TxtPort.Size = new System.Drawing.Size(78, 20);
            this.TxtPort.TabIndex = 19;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(43, 164);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 13);
            this.label11.TabIndex = 24;
            this.label11.Text = "Password";
            // 
            // TxtPassword
            // 
            this.TxtPassword.Enabled = false;
            this.TxtPassword.Location = new System.Drawing.Point(102, 164);
            this.TxtPassword.MaxLength = 200;
            this.TxtPassword.Name = "TxtPassword";
            this.TxtPassword.PasswordChar = '*';
            this.TxtPassword.Size = new System.Drawing.Size(320, 20);
            this.TxtPassword.TabIndex = 25;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(38, 138);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(58, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "User name";
            // 
            // TxtUserName
            // 
            this.TxtUserName.Enabled = false;
            this.TxtUserName.Location = new System.Drawing.Point(102, 138);
            this.TxtUserName.MaxLength = 100;
            this.TxtUserName.Name = "TxtUserName";
            this.TxtUserName.Size = new System.Drawing.Size(320, 20);
            this.TxtUserName.TabIndex = 23;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(25, 54);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "SMTP Server";
            // 
            // TxtSMTPServer
            // 
            this.TxtSMTPServer.Location = new System.Drawing.Point(102, 54);
            this.TxtSMTPServer.MaxLength = 100;
            this.TxtSMTPServer.Name = "TxtSMTPServer";
            this.TxtSMTPServer.Size = new System.Drawing.Size(320, 20);
            this.TxtSMTPServer.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(55, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Sender";
            // 
            // TxtSender
            // 
            this.TxtSender.Location = new System.Drawing.Point(102, 12);
            this.TxtSender.MaxLength = 1000;
            this.TxtSender.Name = "TxtSender";
            this.TxtSender.Size = new System.Drawing.Size(320, 20);
            this.TxtSender.TabIndex = 15;
            // 
            // WndSendEMailTaskConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 567);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WndSendEMailTaskConfig";
            this.Text = "Send e-mail task configuration";
            this.TabConfig2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrProvider)).EndInit();
            this.TabMessage.ResumeLayout(false);
            this.TabMessage.PerformLayout();
            this.TabConnection.ResumeLayout(false);
            this.TabConnection.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabPage TabMessage;
        private System.Windows.Forms.TabPage TabConnection;
        private System.Windows.Forms.Button BtnRemoveAttachment;
        private System.Windows.Forms.Button BtnAddAttachment;
        private System.Windows.Forms.Button BtnRemoveCC;
        private System.Windows.Forms.Button BtnAddCC;
        private System.Windows.Forms.Button BtnRemoveRecipient;
        private System.Windows.Forms.Button BtnAddRecipient;
        private System.Windows.Forms.ListBox LstCC;
        private System.Windows.Forms.ListBox LstRecipients;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListBox LstAttachments;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TxtMessage;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtSubject;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox ChkAuthenticate;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox TxtConfirmPassword;
        private System.Windows.Forms.CheckBox ChkUseSSL;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox TxtPort;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox TxtPassword;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox TxtUserName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox TxtSMTPServer;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TxtSender;
        private System.Windows.Forms.Button BtnDynDataSubject;
        private System.Windows.Forms.Button BtnDynDataMessage;
        private System.Windows.Forms.Button BtnDynDataSMTPServer;
        private System.Windows.Forms.Button BtnDynDataSender;
        private System.Windows.Forms.Button BtnDynDataPassword;
        private System.Windows.Forms.Button BtnDynDataUserName;
        private System.Windows.Forms.Button BtnDynDataPort;
    }
}