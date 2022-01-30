
namespace TDP.Robot.JobEditor
{
    partial class WndExecutionCondition
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtObjectID = new System.Windows.Forms.TextBox();
            this.TxtValue = new System.Windows.Forms.TextBox();
            this.CmbDynamicData = new System.Windows.Forms.ComboBox();
            this.CmbOperator = new System.Windows.Forms.ComboBox();
            this.LblValue = new System.Windows.Forms.Label();
            this.LblMaxValue = new System.Windows.Forms.Label();
            this.TxtMaxValue = new System.Windows.Forms.TextBox();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnOk = new System.Windows.Forms.Button();
            this.TxtObjectName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Object ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Dynamic data";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Operator";
            // 
            // TxtObjectID
            // 
            this.TxtObjectID.Location = new System.Drawing.Point(94, 12);
            this.TxtObjectID.Name = "TxtObjectID";
            this.TxtObjectID.ReadOnly = true;
            this.TxtObjectID.Size = new System.Drawing.Size(166, 20);
            this.TxtObjectID.TabIndex = 1;
            // 
            // TxtValue
            // 
            this.TxtValue.Location = new System.Drawing.Point(94, 120);
            this.TxtValue.Name = "TxtValue";
            this.TxtValue.Size = new System.Drawing.Size(166, 20);
            this.TxtValue.TabIndex = 9;
            // 
            // CmbDynamicData
            // 
            this.CmbDynamicData.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbDynamicData.FormattingEnabled = true;
            this.CmbDynamicData.Location = new System.Drawing.Point(94, 64);
            this.CmbDynamicData.Name = "CmbDynamicData";
            this.CmbDynamicData.Size = new System.Drawing.Size(352, 21);
            this.CmbDynamicData.TabIndex = 5;
            // 
            // CmbOperator
            // 
            this.CmbOperator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbOperator.FormattingEnabled = true;
            this.CmbOperator.Location = new System.Drawing.Point(94, 93);
            this.CmbOperator.Name = "CmbOperator";
            this.CmbOperator.Size = new System.Drawing.Size(166, 21);
            this.CmbOperator.TabIndex = 7;
            this.CmbOperator.SelectedIndexChanged += new System.EventHandler(this.CmbOperator_SelectedIndexChanged);
            // 
            // LblValue
            // 
            this.LblValue.Location = new System.Drawing.Point(7, 120);
            this.LblValue.Name = "LblValue";
            this.LblValue.Size = new System.Drawing.Size(80, 13);
            this.LblValue.TabIndex = 8;
            this.LblValue.Text = "Value";
            this.LblValue.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // LblMaxValue
            // 
            this.LblMaxValue.AutoSize = true;
            this.LblMaxValue.Location = new System.Drawing.Point(32, 146);
            this.LblMaxValue.Name = "LblMaxValue";
            this.LblMaxValue.Size = new System.Drawing.Size(56, 13);
            this.LblMaxValue.TabIndex = 10;
            this.LblMaxValue.Text = "Max value";
            // 
            // TxtMaxValue
            // 
            this.TxtMaxValue.Location = new System.Drawing.Point(94, 146);
            this.TxtMaxValue.Name = "TxtMaxValue";
            this.TxtMaxValue.Size = new System.Drawing.Size(166, 20);
            this.TxtMaxValue.TabIndex = 11;
            // 
            // BtnCancel
            // 
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.Location = new System.Drawing.Point(371, 188);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 13;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            // 
            // BtnOk
            // 
            this.BtnOk.Location = new System.Drawing.Point(290, 188);
            this.BtnOk.Name = "BtnOk";
            this.BtnOk.Size = new System.Drawing.Size(75, 23);
            this.BtnOk.TabIndex = 12;
            this.BtnOk.Text = "OK";
            this.BtnOk.UseVisualStyleBackColor = true;
            this.BtnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // TxtObjectName
            // 
            this.TxtObjectName.Location = new System.Drawing.Point(94, 38);
            this.TxtObjectName.Name = "TxtObjectName";
            this.TxtObjectName.ReadOnly = true;
            this.TxtObjectName.Size = new System.Drawing.Size(352, 20);
            this.TxtObjectName.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Object name";
            // 
            // ErrorProvider
            // 
            this.ErrorProvider.ContainerControl = this;
            // 
            // WndExecutionCondition
            // 
            this.AcceptButton = this.BtnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 234);
            this.Controls.Add(this.TxtObjectName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnOk);
            this.Controls.Add(this.LblMaxValue);
            this.Controls.Add(this.TxtMaxValue);
            this.Controls.Add(this.LblValue);
            this.Controls.Add(this.CmbOperator);
            this.Controls.Add(this.CmbDynamicData);
            this.Controls.Add(this.TxtValue);
            this.Controls.Add(this.TxtObjectID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WndExecutionCondition";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Execution condition";
            this.Load += new System.EventHandler(this.WndExecutionCondition_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtObjectID;
        private System.Windows.Forms.TextBox TxtValue;
        private System.Windows.Forms.ComboBox CmbDynamicData;
        private System.Windows.Forms.ComboBox CmbOperator;
        private System.Windows.Forms.Label LblValue;
        private System.Windows.Forms.Label LblMaxValue;
        private System.Windows.Forms.TextBox TxtMaxValue;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnOk;
        private System.Windows.Forms.TextBox TxtObjectName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ErrorProvider ErrorProvider;
    }
}