
namespace TDP.Robot.Plugins.Core.RESTApiTask
{
    partial class WndHeader
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
            this.BtnDynDataHeaderValue = new System.Windows.Forms.Button();
            this.BtnDynDataHeaderName = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnOk = new System.Windows.Forms.Button();
            this.TxtHeaderValue = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtHeaderName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BtnDynDataHeaderValue
            // 
            this.BtnDynDataHeaderValue.Image = global::TDP.Robot.Plugins.Core.Resource.LightningAdd;
            this.BtnDynDataHeaderValue.Location = new System.Drawing.Point(391, 37);
            this.BtnDynDataHeaderValue.Name = "BtnDynDataHeaderValue";
            this.BtnDynDataHeaderValue.Size = new System.Drawing.Size(23, 21);
            this.BtnDynDataHeaderValue.TabIndex = 48;
            this.BtnDynDataHeaderValue.Text = "...";
            this.BtnDynDataHeaderValue.UseVisualStyleBackColor = true;
            // 
            // BtnDynDataHeaderName
            // 
            this.BtnDynDataHeaderName.Image = global::TDP.Robot.Plugins.Core.Resource.LightningAdd;
            this.BtnDynDataHeaderName.Location = new System.Drawing.Point(391, 11);
            this.BtnDynDataHeaderName.Name = "BtnDynDataHeaderName";
            this.BtnDynDataHeaderName.Size = new System.Drawing.Size(23, 21);
            this.BtnDynDataHeaderName.TabIndex = 47;
            this.BtnDynDataHeaderName.Text = "...";
            this.BtnDynDataHeaderName.UseVisualStyleBackColor = true;
            // 
            // BtnCancel
            // 
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.Location = new System.Drawing.Point(339, 64);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 46;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            // 
            // BtnOk
            // 
            this.BtnOk.Location = new System.Drawing.Point(258, 64);
            this.BtnOk.Name = "BtnOk";
            this.BtnOk.Size = new System.Drawing.Size(75, 23);
            this.BtnOk.TabIndex = 45;
            this.BtnOk.Text = "OK";
            this.BtnOk.UseVisualStyleBackColor = true;
            this.BtnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // TxtHeaderValue
            // 
            this.TxtHeaderValue.Location = new System.Drawing.Point(79, 38);
            this.TxtHeaderValue.MaxLength = 1000;
            this.TxtHeaderValue.Name = "TxtHeaderValue";
            this.TxtHeaderValue.Size = new System.Drawing.Size(306, 20);
            this.TxtHeaderValue.TabIndex = 44;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 43;
            this.label2.Text = "Value";
            // 
            // TxtHeaderName
            // 
            this.TxtHeaderName.Location = new System.Drawing.Point(79, 12);
            this.TxtHeaderName.MaxLength = 1000;
            this.TxtHeaderName.Name = "TxtHeaderName";
            this.TxtHeaderName.Size = new System.Drawing.Size(306, 20);
            this.TxtHeaderName.TabIndex = 42;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 41;
            this.label1.Text = "Name";
            // 
            // WndHeader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 104);
            this.Controls.Add(this.BtnDynDataHeaderValue);
            this.Controls.Add(this.BtnDynDataHeaderName);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnOk);
            this.Controls.Add(this.TxtHeaderValue);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtHeaderName);
            this.Controls.Add(this.label1);
            this.Name = "WndHeader";
            this.Text = "Add / Edit header";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnDynDataHeaderValue;
        private System.Windows.Forms.Button BtnDynDataHeaderName;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnOk;
        private System.Windows.Forms.TextBox TxtHeaderValue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtHeaderName;
        private System.Windows.Forms.Label label1;
    }
}