
namespace TDP.Robot.Plugins.Core.DiskSpaceEvent
{
    partial class WndDiskThreshold
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
            this.label1 = new System.Windows.Forms.Label();
            this.CmbDisk = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CmbCheckOperator = new System.Windows.Forms.ComboBox();
            this.TxtThreshold = new System.Windows.Forms.TextBox();
            this.CmbUnitMeasure = new System.Windows.Forms.ComboBox();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Disk";
            // 
            // CmbDisk
            // 
            this.CmbDisk.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbDisk.FormattingEnabled = true;
            this.CmbDisk.Location = new System.Drawing.Point(99, 18);
            this.CmbDisk.Name = "CmbDisk";
            this.CmbDisk.Size = new System.Drawing.Size(120, 21);
            this.CmbDisk.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Free space is";
            // 
            // CmbCheckOperator
            // 
            this.CmbCheckOperator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbCheckOperator.FormattingEnabled = true;
            this.CmbCheckOperator.Location = new System.Drawing.Point(99, 46);
            this.CmbCheckOperator.Name = "CmbCheckOperator";
            this.CmbCheckOperator.Size = new System.Drawing.Size(120, 21);
            this.CmbCheckOperator.TabIndex = 3;
            // 
            // TxtThreshold
            // 
            this.TxtThreshold.Location = new System.Drawing.Point(225, 47);
            this.TxtThreshold.MaxLength = 8;
            this.TxtThreshold.Name = "TxtThreshold";
            this.TxtThreshold.Size = new System.Drawing.Size(80, 20);
            this.TxtThreshold.TabIndex = 4;
            // 
            // CmbUnitMeasure
            // 
            this.CmbUnitMeasure.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbUnitMeasure.FormattingEnabled = true;
            this.CmbUnitMeasure.Location = new System.Drawing.Point(311, 46);
            this.CmbUnitMeasure.Name = "CmbUnitMeasure";
            this.CmbUnitMeasure.Size = new System.Drawing.Size(120, 21);
            this.CmbUnitMeasure.TabIndex = 5;
            // 
            // BtnCancel
            // 
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.Location = new System.Drawing.Point(356, 74);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 7;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            // 
            // BtnOk
            // 
            this.BtnOk.Location = new System.Drawing.Point(275, 74);
            this.BtnOk.Name = "BtnOk";
            this.BtnOk.Size = new System.Drawing.Size(75, 23);
            this.BtnOk.TabIndex = 6;
            this.BtnOk.Text = "OK";
            this.BtnOk.UseVisualStyleBackColor = true;
            this.BtnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // WndDiskThreshold
            // 
            this.AcceptButton = this.BtnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 113);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnOk);
            this.Controls.Add(this.CmbUnitMeasure);
            this.Controls.Add(this.TxtThreshold);
            this.Controls.Add(this.CmbCheckOperator);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CmbDisk);
            this.Controls.Add(this.label1);
            this.Name = "WndDiskThreshold";
            this.Text = "Add / Edit disk";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CmbDisk;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CmbCheckOperator;
        private System.Windows.Forms.TextBox TxtThreshold;
        private System.Windows.Forms.ComboBox CmbUnitMeasure;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnOk;
    }
}