
namespace TDP.Robot.JobEditor
{
    partial class WndLineProperties
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BtnEditDontExecCondition = new System.Windows.Forms.Button();
            this.BtnEditExecCondition = new System.Windows.Forms.Button();
            this.BtnRemoveDontExecCondition = new System.Windows.Forms.Button();
            this.BtnAddDontExecCondition = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.LstDontExecConditions = new System.Windows.Forms.ListBox();
            this.BtnRemoveExecCondition = new System.Windows.Forms.Button();
            this.BtnAddExecCondition = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.LstExecConditions = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ChkDisable = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ChkWait = new System.Windows.Forms.CheckBox();
            this.TxtWaitSeconds = new System.Windows.Forms.TextBox();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnOk = new System.Windows.Forms.Button();
            this.ErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BtnEditDontExecCondition);
            this.groupBox1.Controls.Add(this.BtnEditExecCondition);
            this.groupBox1.Controls.Add(this.BtnRemoveDontExecCondition);
            this.groupBox1.Controls.Add(this.BtnAddDontExecCondition);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.LstDontExecConditions);
            this.groupBox1.Controls.Add(this.BtnRemoveExecCondition);
            this.groupBox1.Controls.Add(this.BtnAddExecCondition);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.LstExecConditions);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(594, 308);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Conditions";
            // 
            // BtnEditDontExecCondition
            // 
            this.BtnEditDontExecCondition.Location = new System.Drawing.Point(508, 217);
            this.BtnEditDontExecCondition.Name = "BtnEditDontExecCondition";
            this.BtnEditDontExecCondition.Size = new System.Drawing.Size(75, 23);
            this.BtnEditDontExecCondition.TabIndex = 9;
            this.BtnEditDontExecCondition.Text = "Edit...";
            this.BtnEditDontExecCondition.UseVisualStyleBackColor = true;
            this.BtnEditDontExecCondition.Click += new System.EventHandler(this.BtnEditDontExecCondition_Click);
            // 
            // BtnEditExecCondition
            // 
            this.BtnEditExecCondition.Location = new System.Drawing.Point(509, 74);
            this.BtnEditExecCondition.Name = "BtnEditExecCondition";
            this.BtnEditExecCondition.Size = new System.Drawing.Size(75, 23);
            this.BtnEditExecCondition.TabIndex = 8;
            this.BtnEditExecCondition.Text = "Edit...";
            this.BtnEditExecCondition.UseVisualStyleBackColor = true;
            this.BtnEditExecCondition.Click += new System.EventHandler(this.BtnEditExecCondition_Click);
            // 
            // BtnRemoveDontExecCondition
            // 
            this.BtnRemoveDontExecCondition.Location = new System.Drawing.Point(508, 246);
            this.BtnRemoveDontExecCondition.Name = "BtnRemoveDontExecCondition";
            this.BtnRemoveDontExecCondition.Size = new System.Drawing.Size(75, 23);
            this.BtnRemoveDontExecCondition.TabIndex = 7;
            this.BtnRemoveDontExecCondition.Text = "Remove";
            this.BtnRemoveDontExecCondition.UseVisualStyleBackColor = true;
            this.BtnRemoveDontExecCondition.Click += new System.EventHandler(this.BtnRemoveDontExecCondition_Click);
            // 
            // BtnAddDontExecCondition
            // 
            this.BtnAddDontExecCondition.Location = new System.Drawing.Point(509, 188);
            this.BtnAddDontExecCondition.Name = "BtnAddDontExecCondition";
            this.BtnAddDontExecCondition.Size = new System.Drawing.Size(75, 23);
            this.BtnAddDontExecCondition.TabIndex = 6;
            this.BtnAddDontExecCondition.Text = "Add...";
            this.BtnAddDontExecCondition.UseVisualStyleBackColor = true;
            this.BtnAddDontExecCondition.Click += new System.EventHandler(this.BtnAddDontExecCondition_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 172);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(261, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Don\'t execute if one of the following conditions is true:";
            // 
            // LstDontExecConditions
            // 
            this.LstDontExecConditions.FormattingEnabled = true;
            this.LstDontExecConditions.Location = new System.Drawing.Point(6, 188);
            this.LstDontExecConditions.Name = "LstDontExecConditions";
            this.LstDontExecConditions.Size = new System.Drawing.Size(496, 108);
            this.LstDontExecConditions.TabIndex = 4;
            this.LstDontExecConditions.DoubleClick += new System.EventHandler(this.LstDontExecConditions_DoubleClick);
            // 
            // BtnRemoveExecCondition
            // 
            this.BtnRemoveExecCondition.Location = new System.Drawing.Point(509, 103);
            this.BtnRemoveExecCondition.Name = "BtnRemoveExecCondition";
            this.BtnRemoveExecCondition.Size = new System.Drawing.Size(75, 23);
            this.BtnRemoveExecCondition.TabIndex = 3;
            this.BtnRemoveExecCondition.Text = "Remove";
            this.BtnRemoveExecCondition.UseVisualStyleBackColor = true;
            this.BtnRemoveExecCondition.Click += new System.EventHandler(this.BtnRemoveExecCondition_Click);
            // 
            // BtnAddExecCondition
            // 
            this.BtnAddExecCondition.Location = new System.Drawing.Point(509, 45);
            this.BtnAddExecCondition.Name = "BtnAddExecCondition";
            this.BtnAddExecCondition.Size = new System.Drawing.Size(75, 23);
            this.BtnAddExecCondition.TabIndex = 2;
            this.BtnAddExecCondition.Text = "Add...";
            this.BtnAddExecCondition.UseVisualStyleBackColor = true;
            this.BtnAddExecCondition.Click += new System.EventHandler(this.BtnAddExecCondition_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(234, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Execute if one of the following conditions is true:";
            // 
            // LstExecConditions
            // 
            this.LstExecConditions.FormattingEnabled = true;
            this.LstExecConditions.Location = new System.Drawing.Point(6, 45);
            this.LstExecConditions.Name = "LstExecConditions";
            this.LstExecConditions.Size = new System.Drawing.Size(496, 108);
            this.LstExecConditions.TabIndex = 0;
            this.LstExecConditions.DoubleClick += new System.EventHandler(this.LstExecConditions_DoubleClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ChkDisable);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.ChkWait);
            this.groupBox2.Controls.Add(this.TxtWaitSeconds);
            this.groupBox2.Location = new System.Drawing.Point(12, 327);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(594, 73);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Options";
            // 
            // ChkDisable
            // 
            this.ChkDisable.AutoSize = true;
            this.ChkDisable.Location = new System.Drawing.Point(18, 46);
            this.ChkDisable.Name = "ChkDisable";
            this.ChkDisable.Size = new System.Drawing.Size(61, 17);
            this.ChkDisable.TabIndex = 4;
            this.ChkDisable.Text = "Disable";
            this.ChkDisable.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(135, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(202, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "seconds before executing the next object";
            // 
            // ChkWait
            // 
            this.ChkWait.AutoSize = true;
            this.ChkWait.Location = new System.Drawing.Point(18, 22);
            this.ChkWait.Name = "ChkWait";
            this.ChkWait.Size = new System.Drawing.Size(48, 17);
            this.ChkWait.TabIndex = 2;
            this.ChkWait.Text = "Wait";
            this.ChkWait.UseVisualStyleBackColor = true;
            this.ChkWait.CheckedChanged += new System.EventHandler(this.ChkWait_CheckedChanged);
            // 
            // TxtWaitSeconds
            // 
            this.TxtWaitSeconds.Enabled = false;
            this.TxtWaitSeconds.Location = new System.Drawing.Point(72, 19);
            this.TxtWaitSeconds.MaxLength = 3;
            this.TxtWaitSeconds.Name = "TxtWaitSeconds";
            this.TxtWaitSeconds.Size = new System.Drawing.Size(57, 20);
            this.TxtWaitSeconds.TabIndex = 1;
            // 
            // BtnCancel
            // 
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.Location = new System.Drawing.Point(531, 406);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 14;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            // 
            // BtnOk
            // 
            this.BtnOk.Location = new System.Drawing.Point(450, 406);
            this.BtnOk.Name = "BtnOk";
            this.BtnOk.Size = new System.Drawing.Size(75, 23);
            this.BtnOk.TabIndex = 13;
            this.BtnOk.Text = "OK";
            this.BtnOk.UseVisualStyleBackColor = true;
            this.BtnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // ErrorProvider
            // 
            this.ErrorProvider.ContainerControl = this;
            // 
            // WndLineProperties
            // 
            this.AcceptButton = this.BtnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 440);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnOk);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WndLineProperties";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Line properties";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox LstExecConditions;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnRemoveExecCondition;
        private System.Windows.Forms.Button BtnAddExecCondition;
        private System.Windows.Forms.Button BtnRemoveDontExecCondition;
        private System.Windows.Forms.Button BtnAddDontExecCondition;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox LstDontExecConditions;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox TxtWaitSeconds;
        private System.Windows.Forms.CheckBox ChkWait;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox ChkDisable;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnOk;
        private System.Windows.Forms.Button BtnEditExecCondition;
        private System.Windows.Forms.Button BtnEditDontExecCondition;
        private System.Windows.Forms.ErrorProvider ErrorProvider;
    }
}