
namespace TDP.Robot.Plugins.Core.WriteTextFileTask
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
            this.BtnDynDataFieldValue = new System.Windows.Forms.Button();
            this.BtnDynDataHeaderTitle = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnOk = new System.Windows.Forms.Button();
            this.TxtFieldValue = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtHeaderTitle = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnDynDataFieldWidth = new System.Windows.Forms.Button();
            this.TxtFieldWidth = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BtnDynDataFieldValue
            // 
            this.BtnDynDataFieldValue.Image = global::TDP.Robot.Plugins.Core.Resource.LightningAdd;
            this.BtnDynDataFieldValue.Location = new System.Drawing.Point(567, 42);
            this.BtnDynDataFieldValue.Name = "BtnDynDataFieldValue";
            this.BtnDynDataFieldValue.Size = new System.Drawing.Size(23, 21);
            this.BtnDynDataFieldValue.TabIndex = 5;
            this.BtnDynDataFieldValue.Text = "...";
            this.BtnDynDataFieldValue.UseVisualStyleBackColor = true;
            // 
            // BtnDynDataHeaderTitle
            // 
            this.BtnDynDataHeaderTitle.Image = global::TDP.Robot.Plugins.Core.Resource.LightningAdd;
            this.BtnDynDataHeaderTitle.Location = new System.Drawing.Point(567, 16);
            this.BtnDynDataHeaderTitle.Name = "BtnDynDataHeaderTitle";
            this.BtnDynDataHeaderTitle.Size = new System.Drawing.Size(23, 21);
            this.BtnDynDataHeaderTitle.TabIndex = 2;
            this.BtnDynDataHeaderTitle.Text = "...";
            this.BtnDynDataHeaderTitle.UseVisualStyleBackColor = true;
            // 
            // BtnCancel
            // 
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.Location = new System.Drawing.Point(514, 97);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 10;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            // 
            // BtnOk
            // 
            this.BtnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BtnOk.Location = new System.Drawing.Point(433, 97);
            this.BtnOk.Name = "BtnOk";
            this.BtnOk.Size = new System.Drawing.Size(75, 23);
            this.BtnOk.TabIndex = 9;
            this.BtnOk.Text = "OK";
            this.BtnOk.UseVisualStyleBackColor = true;
            // 
            // TxtFieldValue
            // 
            this.TxtFieldValue.Location = new System.Drawing.Point(86, 43);
            this.TxtFieldValue.MaxLength = 1000;
            this.TxtFieldValue.Name = "TxtFieldValue";
            this.TxtFieldValue.Size = new System.Drawing.Size(475, 20);
            this.TxtFieldValue.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Field value";
            // 
            // TxtHeaderTitle
            // 
            this.TxtHeaderTitle.Location = new System.Drawing.Point(86, 17);
            this.TxtHeaderTitle.MaxLength = 1000;
            this.TxtHeaderTitle.Name = "TxtHeaderTitle";
            this.TxtHeaderTitle.Size = new System.Drawing.Size(475, 20);
            this.TxtHeaderTitle.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Header title";
            // 
            // BtnDynDataFieldWidth
            // 
            this.BtnDynDataFieldWidth.Image = global::TDP.Robot.Plugins.Core.Resource.LightningAdd;
            this.BtnDynDataFieldWidth.Location = new System.Drawing.Point(567, 68);
            this.BtnDynDataFieldWidth.Name = "BtnDynDataFieldWidth";
            this.BtnDynDataFieldWidth.Size = new System.Drawing.Size(23, 21);
            this.BtnDynDataFieldWidth.TabIndex = 8;
            this.BtnDynDataFieldWidth.Text = "...";
            this.BtnDynDataFieldWidth.UseVisualStyleBackColor = true;
            // 
            // TxtFieldWidth
            // 
            this.TxtFieldWidth.Location = new System.Drawing.Point(86, 69);
            this.TxtFieldWidth.MaxLength = 1000;
            this.TxtFieldWidth.Name = "TxtFieldWidth";
            this.TxtFieldWidth.Size = new System.Drawing.Size(475, 20);
            this.TxtFieldWidth.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Field width";
            // 
            // WndColumn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 132);
            this.Controls.Add(this.BtnDynDataFieldWidth);
            this.Controls.Add(this.TxtFieldWidth);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BtnDynDataFieldValue);
            this.Controls.Add(this.BtnDynDataHeaderTitle);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnOk);
            this.Controls.Add(this.TxtFieldValue);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtHeaderTitle);
            this.Controls.Add(this.label1);
            this.Name = "WndColumn";
            this.Text = "Add / Edit column";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnDynDataFieldValue;
        private System.Windows.Forms.Button BtnDynDataHeaderTitle;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnOk;
        private System.Windows.Forms.TextBox TxtFieldValue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtHeaderTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnDynDataFieldWidth;
        private System.Windows.Forms.TextBox TxtFieldWidth;
        private System.Windows.Forms.Label label3;
    }
}