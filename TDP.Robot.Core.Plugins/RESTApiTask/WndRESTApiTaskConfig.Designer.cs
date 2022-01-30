
namespace TDP.Robot.Plugins.Core.RESTApiTask
{
    partial class WndRESTApiTaskConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WndRESTApiTaskConfig));
            this.General = new System.Windows.Forms.TabPage();
            this.BtnMoveDown = new System.Windows.Forms.Button();
            this.BtnMoveUp = new System.Windows.Forms.Button();
            this.BtnRemove = new System.Windows.Forms.Button();
            this.BtnEdit = new System.Windows.Forms.Button();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.LstHeaders = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ChkReturnsRecordset = new System.Windows.Forms.CheckBox();
            this.BtnDynDataParameters = new System.Windows.Forms.Button();
            this.TxtParameters = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.CmbMethod = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnDynDataURL = new System.Windows.Forms.Button();
            this.TxtURL = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TabConfig2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrProvider)).BeginInit();
            this.General.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabConfig2
            // 
            this.TabConfig2.Controls.Add(this.General);
            this.TabConfig2.Size = new System.Drawing.Size(630, 441);
            this.TabConfig2.Controls.SetChildIndex(this.General, 0);
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(482, 525);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(563, 525);
            // 
            // groupBox1
            // 
            this.groupBox1.Size = new System.Drawing.Size(626, 64);
            // 
            // ChkDoNotLog
            // 
            this.ChkDoNotLog.Location = new System.Drawing.Point(545, 35);
            // 
            // ChkDisable
            // 
            this.ChkDisable.Location = new System.Drawing.Point(545, 12);
            // 
            // TxtName
            // 
            this.TxtName.Size = new System.Drawing.Size(348, 20);
            // 
            // General
            // 
            this.General.Controls.Add(this.BtnMoveDown);
            this.General.Controls.Add(this.BtnMoveUp);
            this.General.Controls.Add(this.BtnRemove);
            this.General.Controls.Add(this.BtnEdit);
            this.General.Controls.Add(this.BtnAdd);
            this.General.Controls.Add(this.LstHeaders);
            this.General.Controls.Add(this.label5);
            this.General.Controls.Add(this.ChkReturnsRecordset);
            this.General.Controls.Add(this.BtnDynDataParameters);
            this.General.Controls.Add(this.TxtParameters);
            this.General.Controls.Add(this.label4);
            this.General.Controls.Add(this.CmbMethod);
            this.General.Controls.Add(this.label2);
            this.General.Controls.Add(this.BtnDynDataURL);
            this.General.Controls.Add(this.TxtURL);
            this.General.Controls.Add(this.label3);
            this.General.Location = new System.Drawing.Point(4, 22);
            this.General.Name = "General";
            this.General.Padding = new System.Windows.Forms.Padding(3);
            this.General.Size = new System.Drawing.Size(622, 415);
            this.General.TabIndex = 3;
            this.General.Text = "General";
            this.General.UseVisualStyleBackColor = true;
            // 
            // BtnMoveDown
            // 
            this.BtnMoveDown.Location = new System.Drawing.Point(520, 196);
            this.BtnMoveDown.Name = "BtnMoveDown";
            this.BtnMoveDown.Size = new System.Drawing.Size(86, 23);
            this.BtnMoveDown.TabIndex = 50;
            this.BtnMoveDown.Text = "Move down";
            this.BtnMoveDown.UseVisualStyleBackColor = true;
            this.BtnMoveDown.Click += new System.EventHandler(this.BtnMoveDown_Click);
            // 
            // BtnMoveUp
            // 
            this.BtnMoveUp.Location = new System.Drawing.Point(520, 170);
            this.BtnMoveUp.Name = "BtnMoveUp";
            this.BtnMoveUp.Size = new System.Drawing.Size(86, 23);
            this.BtnMoveUp.TabIndex = 49;
            this.BtnMoveUp.Text = "Move up";
            this.BtnMoveUp.UseVisualStyleBackColor = true;
            this.BtnMoveUp.Click += new System.EventHandler(this.BtnMoveUp_Click);
            // 
            // BtnRemove
            // 
            this.BtnRemove.Location = new System.Drawing.Point(520, 142);
            this.BtnRemove.Name = "BtnRemove";
            this.BtnRemove.Size = new System.Drawing.Size(86, 23);
            this.BtnRemove.TabIndex = 48;
            this.BtnRemove.Text = "Remove";
            this.BtnRemove.UseVisualStyleBackColor = true;
            this.BtnRemove.Click += new System.EventHandler(this.BtnRemove_Click);
            // 
            // BtnEdit
            // 
            this.BtnEdit.Location = new System.Drawing.Point(520, 113);
            this.BtnEdit.Name = "BtnEdit";
            this.BtnEdit.Size = new System.Drawing.Size(86, 23);
            this.BtnEdit.TabIndex = 47;
            this.BtnEdit.Text = "Edit...";
            this.BtnEdit.UseVisualStyleBackColor = true;
            this.BtnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
            // 
            // BtnAdd
            // 
            this.BtnAdd.Location = new System.Drawing.Point(520, 84);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(86, 23);
            this.BtnAdd.TabIndex = 46;
            this.BtnAdd.Text = "Add...";
            this.BtnAdd.UseVisualStyleBackColor = true;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // LstHeaders
            // 
            this.LstHeaders.FormattingEnabled = true;
            this.LstHeaders.Location = new System.Drawing.Point(104, 83);
            this.LstHeaders.Name = "LstHeaders";
            this.LstHeaders.Size = new System.Drawing.Size(410, 147);
            this.LstHeaders.TabIndex = 45;
            this.LstHeaders.DoubleClick += new System.EventHandler(this.LstHeaders_DoubleClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(51, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 44;
            this.label5.Text = "Headers";
            // 
            // ChkReturnsRecordset
            // 
            this.ChkReturnsRecordset.AutoSize = true;
            this.ChkReturnsRecordset.Location = new System.Drawing.Point(8, 376);
            this.ChkReturnsRecordset.Name = "ChkReturnsRecordset";
            this.ChkReturnsRecordset.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ChkReturnsRecordset.Size = new System.Drawing.Size(110, 17);
            this.ChkReturnsRecordset.TabIndex = 43;
            this.ChkReturnsRecordset.Text = "Returns recordset";
            this.ChkReturnsRecordset.UseVisualStyleBackColor = true;
            // 
            // BtnDynDataParameters
            // 
            this.BtnDynDataParameters.Image = global::TDP.Robot.Plugins.Core.Resource.LightningAdd;
            this.BtnDynDataParameters.Location = new System.Drawing.Point(520, 239);
            this.BtnDynDataParameters.Name = "BtnDynDataParameters";
            this.BtnDynDataParameters.Size = new System.Drawing.Size(23, 21);
            this.BtnDynDataParameters.TabIndex = 42;
            this.BtnDynDataParameters.Text = "...";
            this.BtnDynDataParameters.UseVisualStyleBackColor = true;
            // 
            // TxtParameters
            // 
            this.TxtParameters.Location = new System.Drawing.Point(104, 239);
            this.TxtParameters.Multiline = true;
            this.TxtParameters.Name = "TxtParameters";
            this.TxtParameters.Size = new System.Drawing.Size(410, 131);
            this.TxtParameters.TabIndex = 41;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(16, 242);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 48);
            this.label4.TabIndex = 40;
            this.label4.Text = "Parameters (JSON)";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // CmbMethod
            // 
            this.CmbMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbMethod.FormattingEnabled = true;
            this.CmbMethod.Location = new System.Drawing.Point(104, 56);
            this.CmbMethod.Name = "CmbMethod";
            this.CmbMethod.Size = new System.Drawing.Size(121, 21);
            this.CmbMethod.TabIndex = 39;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 38;
            this.label2.Text = "Method";
            // 
            // BtnDynDataURL
            // 
            this.BtnDynDataURL.Image = global::TDP.Robot.Plugins.Core.Resource.LightningAdd;
            this.BtnDynDataURL.Location = new System.Drawing.Point(520, 30);
            this.BtnDynDataURL.Name = "BtnDynDataURL";
            this.BtnDynDataURL.Size = new System.Drawing.Size(23, 21);
            this.BtnDynDataURL.TabIndex = 37;
            this.BtnDynDataURL.Text = "...";
            this.BtnDynDataURL.UseVisualStyleBackColor = true;
            // 
            // TxtURL
            // 
            this.TxtURL.Location = new System.Drawing.Point(104, 30);
            this.TxtURL.MaxLength = 1000;
            this.TxtURL.Name = "TxtURL";
            this.TxtURL.Size = new System.Drawing.Size(410, 20);
            this.TxtURL.TabIndex = 36;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(69, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 35;
            this.label3.Text = "URL";
            // 
            // WndRESTApiTaskConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 559);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WndRESTApiTaskConfig";
            this.Text = "REST api task configuration";
            this.TabConfig2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrProvider)).EndInit();
            this.General.ResumeLayout(false);
            this.General.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage General;
        private System.Windows.Forms.Button BtnDynDataURL;
        private System.Windows.Forms.TextBox TxtURL;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CmbMethod;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtParameters;
        private System.Windows.Forms.Button BtnDynDataParameters;
        private System.Windows.Forms.CheckBox ChkReturnsRecordset;
        private System.Windows.Forms.ListBox LstHeaders;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button BtnMoveDown;
        private System.Windows.Forms.Button BtnMoveUp;
        private System.Windows.Forms.Button BtnRemove;
        private System.Windows.Forms.Button BtnEdit;
        private System.Windows.Forms.Button BtnAdd;
    }
}