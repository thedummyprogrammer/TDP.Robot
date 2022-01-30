
namespace TDP.Robot.Plugins.Core.FileSystemEvent
{
    partial class WndFolderToMonitor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WndFolderToMonitor));
            this.BtnBrowsePath = new System.Windows.Forms.Button();
            this.TxtFolderPath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnOk = new System.Windows.Forms.Button();
            this.ChkMonitorSubfolders = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CmbActionToMonitor = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // BtnBrowsePath
            // 
            this.BtnBrowsePath.Location = new System.Drawing.Point(537, 18);
            this.BtnBrowsePath.Name = "BtnBrowsePath";
            this.BtnBrowsePath.Size = new System.Drawing.Size(31, 20);
            this.BtnBrowsePath.TabIndex = 37;
            this.BtnBrowsePath.Text = "...";
            this.BtnBrowsePath.UseVisualStyleBackColor = true;
            this.BtnBrowsePath.Click += new System.EventHandler(this.BtnBrowsePath_Click);
            // 
            // TxtFolderPath
            // 
            this.TxtFolderPath.Location = new System.Drawing.Point(114, 18);
            this.TxtFolderPath.MaxLength = 1000;
            this.TxtFolderPath.Name = "TxtFolderPath";
            this.TxtFolderPath.Size = new System.Drawing.Size(417, 20);
            this.TxtFolderPath.TabIndex = 36;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 35;
            this.label3.Text = "Folder path";
            // 
            // BtnCancel
            // 
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.Location = new System.Drawing.Point(493, 107);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 40;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            // 
            // BtnOk
            // 
            this.BtnOk.Location = new System.Drawing.Point(412, 107);
            this.BtnOk.Name = "BtnOk";
            this.BtnOk.Size = new System.Drawing.Size(75, 23);
            this.BtnOk.TabIndex = 39;
            this.BtnOk.Text = "OK";
            this.BtnOk.UseVisualStyleBackColor = true;
            this.BtnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // ChkMonitorSubfolders
            // 
            this.ChkMonitorSubfolders.AutoSize = true;
            this.ChkMonitorSubfolders.Location = new System.Drawing.Point(16, 71);
            this.ChkMonitorSubfolders.Name = "ChkMonitorSubfolders";
            this.ChkMonitorSubfolders.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ChkMonitorSubfolders.Size = new System.Drawing.Size(112, 17);
            this.ChkMonitorSubfolders.TabIndex = 41;
            this.ChkMonitorSubfolders.Text = "Monitor subfolders";
            this.ChkMonitorSubfolders.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 42;
            this.label1.Text = "Action to monitor";
            // 
            // CmbActionToMonitor
            // 
            this.CmbActionToMonitor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbActionToMonitor.FormattingEnabled = true;
            this.CmbActionToMonitor.Location = new System.Drawing.Point(114, 44);
            this.CmbActionToMonitor.Name = "CmbActionToMonitor";
            this.CmbActionToMonitor.Size = new System.Drawing.Size(193, 21);
            this.CmbActionToMonitor.TabIndex = 43;
            // 
            // WndFolderToMonitor
            // 
            this.AcceptButton = this.BtnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 142);
            this.Controls.Add(this.CmbActionToMonitor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ChkMonitorSubfolders);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnOk);
            this.Controls.Add(this.BtnBrowsePath);
            this.Controls.Add(this.TxtFolderPath);
            this.Controls.Add(this.label3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WndFolderToMonitor";
            this.Text = "Add / edit folder to monitor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button BtnBrowsePath;
        private System.Windows.Forms.TextBox TxtFolderPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnOk;
        private System.Windows.Forms.CheckBox ChkMonitorSubfolders;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CmbActionToMonitor;
    }
}