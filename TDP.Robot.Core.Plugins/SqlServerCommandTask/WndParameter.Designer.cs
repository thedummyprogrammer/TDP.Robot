namespace TDP.Robot.Plugins.Core.SqlServerCommandTask
{
    partial class WndParameter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WndParameter));
            this.label1 = new System.Windows.Forms.Label();
            this.TxtParamName = new System.Windows.Forms.TextBox();
            this.TxtValue = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CmbType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtLength = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtScale = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnOk = new System.Windows.Forms.Button();
            this.ChkPassNullValue = new System.Windows.Forms.CheckBox();
            this.BtnDynDataValue = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Name";
            // 
            // TxtParamName
            // 
            this.TxtParamName.Location = new System.Drawing.Point(54, 39);
            this.TxtParamName.MaxLength = 1000;
            this.TxtParamName.Name = "TxtParamName";
            this.TxtParamName.Size = new System.Drawing.Size(217, 20);
            this.TxtParamName.TabIndex = 3;
            // 
            // TxtValue
            // 
            this.TxtValue.Location = new System.Drawing.Point(54, 65);
            this.TxtValue.MaxLength = 1000;
            this.TxtValue.Name = "TxtValue";
            this.TxtValue.Size = new System.Drawing.Size(190, 20);
            this.TxtValue.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Value";
            // 
            // CmbType
            // 
            this.CmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbType.FormattingEnabled = true;
            this.CmbType.Location = new System.Drawing.Point(54, 12);
            this.CmbType.Name = "CmbType";
            this.CmbType.Size = new System.Drawing.Size(217, 21);
            this.CmbType.TabIndex = 1;
            this.CmbType.SelectedIndexChanged += new System.EventHandler(this.CmbType_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Type";
            // 
            // TxtLength
            // 
            this.TxtLength.Location = new System.Drawing.Point(115, 114);
            this.TxtLength.MaxLength = 5;
            this.TxtLength.Name = "TxtLength";
            this.TxtLength.Size = new System.Drawing.Size(129, 20);
            this.TxtLength.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Length / Precision";
            // 
            // TxtScale
            // 
            this.TxtScale.Location = new System.Drawing.Point(115, 137);
            this.TxtScale.MaxLength = 5;
            this.TxtScale.Name = "TxtScale";
            this.TxtScale.Size = new System.Drawing.Size(129, 20);
            this.TxtScale.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(75, 137);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Scale";
            // 
            // BtnCancel
            // 
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.Location = new System.Drawing.Point(196, 175);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 12;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            // 
            // BtnOk
            // 
            this.BtnOk.Location = new System.Drawing.Point(115, 175);
            this.BtnOk.Name = "BtnOk";
            this.BtnOk.Size = new System.Drawing.Size(75, 23);
            this.BtnOk.TabIndex = 11;
            this.BtnOk.Text = "OK";
            this.BtnOk.UseVisualStyleBackColor = true;
            this.BtnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // ChkPassNullValue
            // 
            this.ChkPassNullValue.AutoSize = true;
            this.ChkPassNullValue.Location = new System.Drawing.Point(54, 91);
            this.ChkPassNullValue.Name = "ChkPassNullValue";
            this.ChkPassNullValue.Size = new System.Drawing.Size(109, 17);
            this.ChkPassNullValue.TabIndex = 6;
            this.ChkPassNullValue.Text = "Pass NULL value";
            this.ChkPassNullValue.UseVisualStyleBackColor = true;
            this.ChkPassNullValue.CheckedChanged += new System.EventHandler(this.ChkPassNullValue_CheckedChanged);
            // 
            // BtnDynDataValue
            // 
            this.BtnDynDataValue.Image = global::TDP.Robot.Plugins.Core.Resource.LightningAdd;
            this.BtnDynDataValue.Location = new System.Drawing.Point(250, 64);
            this.BtnDynDataValue.Name = "BtnDynDataValue";
            this.BtnDynDataValue.Size = new System.Drawing.Size(23, 21);
            this.BtnDynDataValue.TabIndex = 33;
            this.BtnDynDataValue.Text = "...";
            this.BtnDynDataValue.UseVisualStyleBackColor = true;
            // 
            // WndParameter
            // 
            this.AcceptButton = this.BtnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 210);
            this.Controls.Add(this.BtnDynDataValue);
            this.Controls.Add(this.ChkPassNullValue);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnOk);
            this.Controls.Add(this.TxtScale);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TxtLength);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CmbType);
            this.Controls.Add(this.TxtValue);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtParamName);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WndParameter";
            this.Text = "Add / Edit parameter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtParamName;
        private System.Windows.Forms.TextBox TxtValue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CmbType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtLength;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtScale;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnOk;
        private System.Windows.Forms.CheckBox ChkPassNullValue;
        private System.Windows.Forms.Button BtnDynDataValue;
    }
}