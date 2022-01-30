namespace TDP.Robot.Plugins.Core.ExcelFileTask
{
    partial class WndColumn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WndColumn));
            this.label1 = new System.Windows.Forms.Label();
            this.TxtHeaderTitle = new System.Windows.Forms.TextBox();
            this.TxtCellValue = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnOk = new System.Windows.Forms.Button();
            this.BtnDynDataHeaderTitle = new System.Windows.Forms.Button();
            this.BtnDynDataCellValue = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Header title";
            // 
            // TxtHeaderTitle
            // 
            this.TxtHeaderTitle.Location = new System.Drawing.Point(88, 17);
            this.TxtHeaderTitle.MaxLength = 1000;
            this.TxtHeaderTitle.Name = "TxtHeaderTitle";
            this.TxtHeaderTitle.Size = new System.Drawing.Size(306, 20);
            this.TxtHeaderTitle.TabIndex = 1;
            // 
            // TxtCellValue
            // 
            this.TxtCellValue.Location = new System.Drawing.Point(88, 43);
            this.TxtCellValue.MaxLength = 1000;
            this.TxtCellValue.Name = "TxtCellValue";
            this.TxtCellValue.Size = new System.Drawing.Size(306, 20);
            this.TxtCellValue.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Cell value";
            // 
            // BtnCancel
            // 
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.Location = new System.Drawing.Point(348, 69);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 5;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            // 
            // BtnOk
            // 
            this.BtnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BtnOk.Location = new System.Drawing.Point(267, 69);
            this.BtnOk.Name = "BtnOk";
            this.BtnOk.Size = new System.Drawing.Size(75, 23);
            this.BtnOk.TabIndex = 4;
            this.BtnOk.Text = "OK";
            this.BtnOk.UseVisualStyleBackColor = true;
            // 
            // BtnDynDataHeaderTitle
            // 
            this.BtnDynDataHeaderTitle.Image = global::TDP.Robot.Plugins.Core.Resource.LightningAdd;
            this.BtnDynDataHeaderTitle.Location = new System.Drawing.Point(400, 16);
            this.BtnDynDataHeaderTitle.Name = "BtnDynDataHeaderTitle";
            this.BtnDynDataHeaderTitle.Size = new System.Drawing.Size(23, 21);
            this.BtnDynDataHeaderTitle.TabIndex = 39;
            this.BtnDynDataHeaderTitle.Text = "...";
            this.BtnDynDataHeaderTitle.UseVisualStyleBackColor = true;
            // 
            // BtnDynDataCellValue
            // 
            this.BtnDynDataCellValue.Image = global::TDP.Robot.Plugins.Core.Resource.LightningAdd;
            this.BtnDynDataCellValue.Location = new System.Drawing.Point(400, 42);
            this.BtnDynDataCellValue.Name = "BtnDynDataCellValue";
            this.BtnDynDataCellValue.Size = new System.Drawing.Size(23, 21);
            this.BtnDynDataCellValue.TabIndex = 40;
            this.BtnDynDataCellValue.Text = "...";
            this.BtnDynDataCellValue.UseVisualStyleBackColor = true;
            // 
            // WndColumn
            // 
            this.AcceptButton = this.BtnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 112);
            this.Controls.Add(this.BtnDynDataCellValue);
            this.Controls.Add(this.BtnDynDataHeaderTitle);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnOk);
            this.Controls.Add(this.TxtCellValue);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtHeaderTitle);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WndColumn";
            this.Text = "Add / Edit column";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtHeaderTitle;
        private System.Windows.Forms.TextBox TxtCellValue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnOk;
        private System.Windows.Forms.Button BtnDynDataHeaderTitle;
        private System.Windows.Forms.Button BtnDynDataCellValue;
    }
}