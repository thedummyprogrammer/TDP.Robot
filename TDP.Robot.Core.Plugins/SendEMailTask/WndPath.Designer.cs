
namespace TDP.Robot.Plugins.Core.SendEMailTask
{
    partial class WndPath
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
            this.BtnDynDataFilePathName = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnOk = new System.Windows.Forms.Button();
            this.TxtFilePathName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnBrowse = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnDynDataFilePathName
            // 
            this.BtnDynDataFilePathName.Image = global::TDP.Robot.Plugins.Core.Resource.LightningAdd;
            this.BtnDynDataFilePathName.Location = new System.Drawing.Point(555, 16);
            this.BtnDynDataFilePathName.Name = "BtnDynDataFilePathName";
            this.BtnDynDataFilePathName.Size = new System.Drawing.Size(23, 21);
            this.BtnDynDataFilePathName.TabIndex = 38;
            this.BtnDynDataFilePathName.Text = "...";
            this.BtnDynDataFilePathName.UseVisualStyleBackColor = true;
            // 
            // BtnCancel
            // 
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.Location = new System.Drawing.Point(503, 43);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 37;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            // 
            // BtnOk
            // 
            this.BtnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BtnOk.Location = new System.Drawing.Point(422, 43);
            this.BtnOk.Name = "BtnOk";
            this.BtnOk.Size = new System.Drawing.Size(75, 23);
            this.BtnOk.TabIndex = 36;
            this.BtnOk.Text = "OK";
            this.BtnOk.UseVisualStyleBackColor = true;
            // 
            // TxtFilePathName
            // 
            this.TxtFilePathName.Location = new System.Drawing.Point(68, 17);
            this.TxtFilePathName.Name = "TxtFilePathName";
            this.TxtFilePathName.Size = new System.Drawing.Size(444, 20);
            this.TxtFilePathName.TabIndex = 35;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 34;
            this.label1.Text = "File path";
            // 
            // BtnBrowse
            // 
            this.BtnBrowse.Location = new System.Drawing.Point(518, 16);
            this.BtnBrowse.Name = "BtnBrowse";
            this.BtnBrowse.Size = new System.Drawing.Size(31, 21);
            this.BtnBrowse.TabIndex = 39;
            this.BtnBrowse.Text = "...";
            this.BtnBrowse.UseVisualStyleBackColor = true;
            this.BtnBrowse.Click += new System.EventHandler(this.BtnBrowse_Click);
            // 
            // WndPath
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 83);
            this.Controls.Add(this.BtnBrowse);
            this.Controls.Add(this.BtnDynDataFilePathName);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnOk);
            this.Controls.Add(this.TxtFilePathName);
            this.Controls.Add(this.label1);
            this.Name = "WndPath";
            this.Text = "Add attachment";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnDynDataFilePathName;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnOk;
        private System.Windows.Forms.TextBox TxtFilePathName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnBrowse;
    }
}