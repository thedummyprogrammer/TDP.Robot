
namespace TDP.Robot.Plugins.Core.ReadTextFileTask
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
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnOk = new System.Windows.Forms.Button();
            this.TxtColumnName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.GrpColumnPos = new System.Windows.Forms.GroupBox();
            this.TxtColumnStartsFromChar = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtColumnNumber = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtColumnEndsAtChar = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.CmbColumnDatatype = new System.Windows.Forms.ComboBox();
            this.TxtColumnExpectedFormat = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TxtColumnExpectedCulture = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.ChkColumnIsIdentity = new System.Windows.Forms.CheckBox();
            this.ChkTreatNullStrAsNull = new System.Windows.Forms.CheckBox();
            this.GrpColumnPos.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnCancel
            // 
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.Location = new System.Drawing.Point(285, 302);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 11;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            // 
            // BtnOk
            // 
            this.BtnOk.Location = new System.Drawing.Point(204, 302);
            this.BtnOk.Name = "BtnOk";
            this.BtnOk.Size = new System.Drawing.Size(75, 23);
            this.BtnOk.TabIndex = 10;
            this.BtnOk.Text = "OK";
            this.BtnOk.UseVisualStyleBackColor = true;
            this.BtnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // TxtColumnName
            // 
            this.TxtColumnName.Location = new System.Drawing.Point(125, 12);
            this.TxtColumnName.MaxLength = 1000;
            this.TxtColumnName.Name = "TxtColumnName";
            this.TxtColumnName.Size = new System.Drawing.Size(235, 20);
            this.TxtColumnName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(84, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // GrpColumnPos
            // 
            this.GrpColumnPos.Controls.Add(this.TxtColumnStartsFromChar);
            this.GrpColumnPos.Controls.Add(this.label4);
            this.GrpColumnPos.Controls.Add(this.TxtColumnNumber);
            this.GrpColumnPos.Controls.Add(this.label3);
            this.GrpColumnPos.Controls.Add(this.TxtColumnEndsAtChar);
            this.GrpColumnPos.Controls.Add(this.label2);
            this.GrpColumnPos.Location = new System.Drawing.Point(12, 186);
            this.GrpColumnPos.Name = "GrpColumnPos";
            this.GrpColumnPos.Size = new System.Drawing.Size(240, 104);
            this.GrpColumnPos.TabIndex = 10;
            this.GrpColumnPos.TabStop = false;
            this.GrpColumnPos.Text = "Column position in source file";
            // 
            // TxtColumnStartsFromChar
            // 
            this.TxtColumnStartsFromChar.Location = new System.Drawing.Point(142, 48);
            this.TxtColumnStartsFromChar.MaxLength = 8;
            this.TxtColumnStartsFromChar.Name = "TxtColumnStartsFromChar";
            this.TxtColumnStartsFromChar.Size = new System.Drawing.Size(72, 20);
            this.TxtColumnStartsFromChar.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Starts from character n.";
            // 
            // TxtColumnNumber
            // 
            this.TxtColumnNumber.Location = new System.Drawing.Point(142, 22);
            this.TxtColumnNumber.MaxLength = 8;
            this.TxtColumnNumber.Name = "TxtColumnNumber";
            this.TxtColumnNumber.Size = new System.Drawing.Size(72, 20);
            this.TxtColumnNumber.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(54, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Column number";
            // 
            // TxtColumnEndsAtChar
            // 
            this.TxtColumnEndsAtChar.Location = new System.Drawing.Point(142, 78);
            this.TxtColumnEndsAtChar.MaxLength = 8;
            this.TxtColumnEndsAtChar.Name = "TxtColumnEndsAtChar";
            this.TxtColumnEndsAtChar.Size = new System.Drawing.Size(72, 20);
            this.TxtColumnEndsAtChar.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Ends at character n.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(66, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Data type";
            // 
            // CmbColumnDatatype
            // 
            this.CmbColumnDatatype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbColumnDatatype.FormattingEnabled = true;
            this.CmbColumnDatatype.Location = new System.Drawing.Point(125, 36);
            this.CmbColumnDatatype.Name = "CmbColumnDatatype";
            this.CmbColumnDatatype.Size = new System.Drawing.Size(235, 21);
            this.CmbColumnDatatype.TabIndex = 3;
            this.CmbColumnDatatype.SelectedIndexChanged += new System.EventHandler(this.CmbColumnDatatype_SelectedIndexChanged);
            // 
            // TxtColumnExpectedFormat
            // 
            this.TxtColumnExpectedFormat.Location = new System.Drawing.Point(125, 111);
            this.TxtColumnExpectedFormat.MaxLength = 100;
            this.TxtColumnExpectedFormat.Name = "TxtColumnExpectedFormat";
            this.TxtColumnExpectedFormat.Size = new System.Drawing.Size(235, 20);
            this.TxtColumnExpectedFormat.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(35, 111);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Expected format";
            // 
            // TxtColumnExpectedCulture
            // 
            this.TxtColumnExpectedCulture.Location = new System.Drawing.Point(125, 85);
            this.TxtColumnExpectedCulture.MaxLength = 5;
            this.TxtColumnExpectedCulture.Name = "TxtColumnExpectedCulture";
            this.TxtColumnExpectedCulture.Size = new System.Drawing.Size(64, 20);
            this.TxtColumnExpectedCulture.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(32, 85);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Expected culture";
            // 
            // ChkColumnIsIdentity
            // 
            this.ChkColumnIsIdentity.AutoSize = true;
            this.ChkColumnIsIdentity.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ChkColumnIsIdentity.Location = new System.Drawing.Point(69, 63);
            this.ChkColumnIsIdentity.Name = "ChkColumnIsIdentity";
            this.ChkColumnIsIdentity.Size = new System.Drawing.Size(70, 17);
            this.ChkColumnIsIdentity.TabIndex = 4;
            this.ChkColumnIsIdentity.Text = "Is identity";
            this.ChkColumnIsIdentity.UseVisualStyleBackColor = true;
            this.ChkColumnIsIdentity.CheckedChanged += new System.EventHandler(this.ChkColumnIsIdentity_CheckedChanged);
            // 
            // ChkTreatNullStrAsNull
            // 
            this.ChkTreatNullStrAsNull.AutoSize = true;
            this.ChkTreatNullStrAsNull.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ChkTreatNullStrAsNull.Location = new System.Drawing.Point(22, 137);
            this.ChkTreatNullStrAsNull.Name = "ChkTreatNullStrAsNull";
            this.ChkTreatNullStrAsNull.Size = new System.Drawing.Size(182, 17);
            this.ChkTreatNullStrAsNull.TabIndex = 9;
            this.ChkTreatNullStrAsNull.Text = "Treat \"NULL\" string as null value";
            this.ChkTreatNullStrAsNull.UseVisualStyleBackColor = true;
            // 
            // WndColumn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 338);
            this.Controls.Add(this.ChkTreatNullStrAsNull);
            this.Controls.Add(this.ChkColumnIsIdentity);
            this.Controls.Add(this.TxtColumnExpectedCulture);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.TxtColumnExpectedFormat);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.CmbColumnDatatype);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.GrpColumnPos);
            this.Controls.Add(this.TxtColumnName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnOk);
            this.Name = "WndColumn";
            this.Text = "Add / Edit column";
            this.GrpColumnPos.ResumeLayout(false);
            this.GrpColumnPos.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnOk;
        private System.Windows.Forms.TextBox TxtColumnName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox GrpColumnPos;
        private System.Windows.Forms.TextBox TxtColumnStartsFromChar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtColumnNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtColumnEndsAtChar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox CmbColumnDatatype;
        private System.Windows.Forms.TextBox TxtColumnExpectedFormat;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TxtColumnExpectedCulture;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox ChkColumnIsIdentity;
        private System.Windows.Forms.CheckBox ChkTreatNullStrAsNull;
    }
}