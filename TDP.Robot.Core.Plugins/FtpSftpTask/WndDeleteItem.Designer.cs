
namespace TDP.Robot.Plugins.Core.FtpSftpTask
{
    partial class WndDeleteItem
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
            this.BtnDynDataCopyRemotePath = new System.Windows.Forms.Button();
            this.TxtCopyRemotePath = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnDynDataCopyRemotePath
            // 
            this.BtnDynDataCopyRemotePath.Image = global::TDP.Robot.Plugins.Core.Resource.LightningAdd;
            this.BtnDynDataCopyRemotePath.Location = new System.Drawing.Point(567, 30);
            this.BtnDynDataCopyRemotePath.Name = "BtnDynDataCopyRemotePath";
            this.BtnDynDataCopyRemotePath.Size = new System.Drawing.Size(23, 21);
            this.BtnDynDataCopyRemotePath.TabIndex = 52;
            this.BtnDynDataCopyRemotePath.Text = "...";
            this.BtnDynDataCopyRemotePath.UseVisualStyleBackColor = true;
            // 
            // TxtCopyRemotePath
            // 
            this.TxtCopyRemotePath.Location = new System.Drawing.Point(101, 31);
            this.TxtCopyRemotePath.MaxLength = 5000;
            this.TxtCopyRemotePath.Name = "TxtCopyRemotePath";
            this.TxtCopyRemotePath.Size = new System.Drawing.Size(460, 20);
            this.TxtCopyRemotePath.TabIndex = 51;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(27, 34);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 13);
            this.label9.TabIndex = 50;
            this.label9.Text = "Remote path";
            // 
            // BtnCancel
            // 
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.Location = new System.Drawing.Point(515, 69);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 49;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            // 
            // BtnOk
            // 
            this.BtnOk.Location = new System.Drawing.Point(434, 69);
            this.BtnOk.Name = "BtnOk";
            this.BtnOk.Size = new System.Drawing.Size(75, 23);
            this.BtnOk.TabIndex = 48;
            this.BtnOk.Text = "OK";
            this.BtnOk.UseVisualStyleBackColor = true;
            this.BtnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // WndDeleteItem
            // 
            this.AcceptButton = this.BtnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 123);
            this.Controls.Add(this.BtnDynDataCopyRemotePath);
            this.Controls.Add(this.TxtCopyRemotePath);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnOk);
            this.Name = "WndDeleteItem";
            this.Text = "Add / Edit delete item";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnDynDataCopyRemotePath;
        private System.Windows.Forms.TextBox TxtCopyRemotePath;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnOk;
    }
}