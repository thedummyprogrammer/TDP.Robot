
namespace TDP.Robot.Plugins.Core.FtpSftpTask
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
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnOk = new System.Windows.Forms.Button();
            this.BtnDynDataCopyRemotePath = new System.Windows.Forms.Button();
            this.BtnDynDataCopyLocalPath = new System.Windows.Forms.Button();
            this.BtnBrowserCopyLocalPath = new System.Windows.Forms.Button();
            this.RdbCopyRemoteToLocal = new System.Windows.Forms.RadioButton();
            this.RdbCopyLocalToRemote = new System.Windows.Forms.RadioButton();
            this.label10 = new System.Windows.Forms.Label();
            this.TxtCopyRemotePath = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.TxtCopyLocalPath = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.ChkOverwriteFileIfExists = new System.Windows.Forms.CheckBox();
            this.ChkRecursivelyCopyDirectories = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // BtnCancel
            // 
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.Location = new System.Drawing.Point(507, 133);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 7;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            // 
            // BtnOk
            // 
            this.BtnOk.Location = new System.Drawing.Point(426, 133);
            this.BtnOk.Name = "BtnOk";
            this.BtnOk.Size = new System.Drawing.Size(75, 23);
            this.BtnOk.TabIndex = 6;
            this.BtnOk.Text = "OK";
            this.BtnOk.UseVisualStyleBackColor = true;
            this.BtnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // BtnDynDataCopyRemotePath
            // 
            this.BtnDynDataCopyRemotePath.Image = global::TDP.Robot.Plugins.Core.Resource.LightningAdd;
            this.BtnDynDataCopyRemotePath.Location = new System.Drawing.Point(522, 72);
            this.BtnDynDataCopyRemotePath.Name = "BtnDynDataCopyRemotePath";
            this.BtnDynDataCopyRemotePath.Size = new System.Drawing.Size(23, 21);
            this.BtnDynDataCopyRemotePath.TabIndex = 47;
            this.BtnDynDataCopyRemotePath.Text = "...";
            this.BtnDynDataCopyRemotePath.UseVisualStyleBackColor = true;
            // 
            // BtnDynDataCopyLocalPath
            // 
            this.BtnDynDataCopyLocalPath.Image = global::TDP.Robot.Plugins.Core.Resource.LightningAdd;
            this.BtnDynDataCopyLocalPath.Location = new System.Drawing.Point(559, 47);
            this.BtnDynDataCopyLocalPath.Name = "BtnDynDataCopyLocalPath";
            this.BtnDynDataCopyLocalPath.Size = new System.Drawing.Size(23, 21);
            this.BtnDynDataCopyLocalPath.TabIndex = 46;
            this.BtnDynDataCopyLocalPath.Text = "...";
            this.BtnDynDataCopyLocalPath.UseVisualStyleBackColor = true;
            // 
            // BtnBrowserCopyLocalPath
            // 
            this.BtnBrowserCopyLocalPath.Location = new System.Drawing.Point(522, 47);
            this.BtnBrowserCopyLocalPath.Name = "BtnBrowserCopyLocalPath";
            this.BtnBrowserCopyLocalPath.Size = new System.Drawing.Size(31, 20);
            this.BtnBrowserCopyLocalPath.TabIndex = 45;
            this.BtnBrowserCopyLocalPath.Text = "...";
            this.BtnBrowserCopyLocalPath.UseVisualStyleBackColor = true;
            this.BtnBrowserCopyLocalPath.Click += new System.EventHandler(this.BtnBrowserCopyLocalPath_Click);
            // 
            // RdbCopyRemoteToLocal
            // 
            this.RdbCopyRemoteToLocal.AutoSize = true;
            this.RdbCopyRemoteToLocal.Location = new System.Drawing.Point(236, 24);
            this.RdbCopyRemoteToLocal.Name = "RdbCopyRemoteToLocal";
            this.RdbCopyRemoteToLocal.Size = new System.Drawing.Size(99, 17);
            this.RdbCopyRemoteToLocal.TabIndex = 44;
            this.RdbCopyRemoteToLocal.Text = "Remote to local";
            this.RdbCopyRemoteToLocal.UseVisualStyleBackColor = true;
            // 
            // RdbCopyLocalToRemote
            // 
            this.RdbCopyLocalToRemote.AutoSize = true;
            this.RdbCopyLocalToRemote.Checked = true;
            this.RdbCopyLocalToRemote.Location = new System.Drawing.Point(121, 24);
            this.RdbCopyLocalToRemote.Name = "RdbCopyLocalToRemote";
            this.RdbCopyLocalToRemote.Size = new System.Drawing.Size(98, 17);
            this.RdbCopyLocalToRemote.TabIndex = 43;
            this.RdbCopyLocalToRemote.TabStop = true;
            this.RdbCopyLocalToRemote.Text = "Local to remote";
            this.RdbCopyLocalToRemote.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(66, 26);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 13);
            this.label10.TabIndex = 42;
            this.label10.Text = "Direction";
            // 
            // TxtCopyRemotePath
            // 
            this.TxtCopyRemotePath.Location = new System.Drawing.Point(121, 73);
            this.TxtCopyRemotePath.MaxLength = 5000;
            this.TxtCopyRemotePath.Name = "TxtCopyRemotePath";
            this.TxtCopyRemotePath.Size = new System.Drawing.Size(395, 20);
            this.TxtCopyRemotePath.TabIndex = 41;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(47, 76);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 13);
            this.label9.TabIndex = 40;
            this.label9.Text = "Remote path";
            // 
            // TxtCopyLocalPath
            // 
            this.TxtCopyLocalPath.Location = new System.Drawing.Point(121, 47);
            this.TxtCopyLocalPath.MaxLength = 5000;
            this.TxtCopyLocalPath.Name = "TxtCopyLocalPath";
            this.TxtCopyLocalPath.Size = new System.Drawing.Size(395, 20);
            this.TxtCopyLocalPath.TabIndex = 39;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(58, 50);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 13);
            this.label8.TabIndex = 38;
            this.label8.Text = "Local path";
            // 
            // ChkOverwriteFileIfExists
            // 
            this.ChkOverwriteFileIfExists.AutoSize = true;
            this.ChkOverwriteFileIfExists.Location = new System.Drawing.Point(11, 99);
            this.ChkOverwriteFileIfExists.Name = "ChkOverwriteFileIfExists";
            this.ChkOverwriteFileIfExists.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ChkOverwriteFileIfExists.Size = new System.Drawing.Size(124, 17);
            this.ChkOverwriteFileIfExists.TabIndex = 48;
            this.ChkOverwriteFileIfExists.Text = "Overwrite file if exists";
            this.ChkOverwriteFileIfExists.UseVisualStyleBackColor = true;
            // 
            // ChkRecursivelyCopyDirectories
            // 
            this.ChkRecursivelyCopyDirectories.AutoSize = true;
            this.ChkRecursivelyCopyDirectories.Location = new System.Drawing.Point(150, 99);
            this.ChkRecursivelyCopyDirectories.Name = "ChkRecursivelyCopyDirectories";
            this.ChkRecursivelyCopyDirectories.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ChkRecursivelyCopyDirectories.Size = new System.Drawing.Size(158, 17);
            this.ChkRecursivelyCopyDirectories.TabIndex = 49;
            this.ChkRecursivelyCopyDirectories.Text = "Recursively copy directories";
            this.ChkRecursivelyCopyDirectories.UseVisualStyleBackColor = true;
            // 
            // WndCopyItem
            // 
            this.AcceptButton = this.BtnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 180);
            this.Controls.Add(this.ChkRecursivelyCopyDirectories);
            this.Controls.Add(this.ChkOverwriteFileIfExists);
            this.Controls.Add(this.BtnDynDataCopyRemotePath);
            this.Controls.Add(this.BtnDynDataCopyLocalPath);
            this.Controls.Add(this.BtnBrowserCopyLocalPath);
            this.Controls.Add(this.RdbCopyRemoteToLocal);
            this.Controls.Add(this.RdbCopyLocalToRemote);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.TxtCopyRemotePath);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.TxtCopyLocalPath);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnOk);
            this.Name = "WndCopyItem";
            this.Text = "Add / Edit copy item";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnOk;
        private System.Windows.Forms.Button BtnDynDataCopyRemotePath;
        private System.Windows.Forms.Button BtnDynDataCopyLocalPath;
        private System.Windows.Forms.Button BtnBrowserCopyLocalPath;
        private System.Windows.Forms.RadioButton RdbCopyRemoteToLocal;
        private System.Windows.Forms.RadioButton RdbCopyLocalToRemote;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox TxtCopyRemotePath;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox TxtCopyLocalPath;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox ChkOverwriteFileIfExists;
        private System.Windows.Forms.CheckBox ChkRecursivelyCopyDirectories;
    }
}