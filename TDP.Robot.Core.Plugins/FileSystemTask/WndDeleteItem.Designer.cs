
namespace TDP.Robot.Plugins.Core.FileSystemTask
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
            this.BtnDynDataDeletePath = new System.Windows.Forms.Button();
            this.TxtDeletePath = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnOk = new System.Windows.Forms.Button();
            this.BtnBrowserDeletePath = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnDynDataDeletePath
            // 
            this.BtnDynDataDeletePath.Image = global::TDP.Robot.Plugins.Core.Resource.LightningAdd;
            this.BtnDynDataDeletePath.Location = new System.Drawing.Point(565, 20);
            this.BtnDynDataDeletePath.Name = "BtnDynDataDeletePath";
            this.BtnDynDataDeletePath.Size = new System.Drawing.Size(23, 21);
            this.BtnDynDataDeletePath.TabIndex = 57;
            this.BtnDynDataDeletePath.Text = "...";
            this.BtnDynDataDeletePath.UseVisualStyleBackColor = true;
            // 
            // TxtDeletePath
            // 
            this.TxtDeletePath.Location = new System.Drawing.Point(54, 21);
            this.TxtDeletePath.MaxLength = 5000;
            this.TxtDeletePath.Name = "TxtDeletePath";
            this.TxtDeletePath.Size = new System.Drawing.Size(469, 20);
            this.TxtDeletePath.TabIndex = 56;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(19, 24);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 13);
            this.label9.TabIndex = 55;
            this.label9.Text = "Path";
            // 
            // BtnCancel
            // 
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.Location = new System.Drawing.Point(513, 60);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 54;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            // 
            // BtnOk
            // 
            this.BtnOk.Location = new System.Drawing.Point(432, 60);
            this.BtnOk.Name = "BtnOk";
            this.BtnOk.Size = new System.Drawing.Size(75, 23);
            this.BtnOk.TabIndex = 53;
            this.BtnOk.Text = "OK";
            this.BtnOk.UseVisualStyleBackColor = true;
            this.BtnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // BtnBrowserDeletePath
            // 
            this.BtnBrowserDeletePath.Location = new System.Drawing.Point(529, 21);
            this.BtnBrowserDeletePath.Name = "BtnBrowserDeletePath";
            this.BtnBrowserDeletePath.Size = new System.Drawing.Size(31, 20);
            this.BtnBrowserDeletePath.TabIndex = 60;
            this.BtnBrowserDeletePath.Text = "...";
            this.BtnBrowserDeletePath.UseVisualStyleBackColor = true;
            this.BtnBrowserDeletePath.Click += new System.EventHandler(this.BtnBrowserDeletePath_Click);
            // 
            // WndDeleteItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 108);
            this.Controls.Add(this.BtnBrowserDeletePath);
            this.Controls.Add(this.BtnDynDataDeletePath);
            this.Controls.Add(this.TxtDeletePath);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnOk);
            this.Name = "WndDeleteItem";
            this.Text = "Add / Edit delete item";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnDynDataDeletePath;
        private System.Windows.Forms.TextBox TxtDeletePath;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnOk;
        private System.Windows.Forms.Button BtnBrowserDeletePath;
    }
}