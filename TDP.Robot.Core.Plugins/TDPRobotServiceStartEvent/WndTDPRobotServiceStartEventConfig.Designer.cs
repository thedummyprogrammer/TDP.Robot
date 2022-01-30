
namespace TDP.Robot.Plugins.Core.TDPRobotServiceStartEvent
{
    partial class WndTDPRobotServiceStartEventConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WndTDPRobotServiceStartEventConfig));
            this.RdbTriggerEventWithin = new System.Windows.Forms.RadioButton();
            this.TxtMinutesWithin = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtMinutesAfter = new System.Windows.Forms.TextBox();
            this.RdbTriggerEventAfter = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(419, 178);
            this.BtnSave.TabIndex = 7;
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(500, 178);
            this.BtnCancel.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.TabIndex = 0;
            // 
            // ChkDoNotLog
            // 
            this.ChkDoNotLog.TabIndex = 3;
            // 
            // ChkDisable
            // 
            this.ChkDisable.TabIndex = 2;
            // 
            // TxtName
            // 
            this.TxtName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.TabIndex = 0;
            // 
            // LblID
            // 
            this.LblID.TabIndex = 0;
            // 
            // RdbTriggerEventWithin
            // 
            this.RdbTriggerEventWithin.AutoSize = true;
            this.RdbTriggerEventWithin.Checked = true;
            this.RdbTriggerEventWithin.Location = new System.Drawing.Point(15, 93);
            this.RdbTriggerEventWithin.Name = "RdbTriggerEventWithin";
            this.RdbTriggerEventWithin.Size = new System.Drawing.Size(194, 17);
            this.RdbTriggerEventWithin.TabIndex = 1;
            this.RdbTriggerEventWithin.TabStop = true;
            this.RdbTriggerEventWithin.Text = "Trigger event if service starts within ";
            this.RdbTriggerEventWithin.UseVisualStyleBackColor = true;
            this.RdbTriggerEventWithin.CheckedChanged += new System.EventHandler(this.RdbTriggerEventWithin_CheckedChanged);
            // 
            // TxtMinutesWithin
            // 
            this.TxtMinutesWithin.Location = new System.Drawing.Point(215, 92);
            this.TxtMinutesWithin.MaxLength = 3;
            this.TxtMinutesWithin.Name = "TxtMinutesWithin";
            this.TxtMinutesWithin.Size = new System.Drawing.Size(60, 20);
            this.TxtMinutesWithin.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(281, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "minutes from computer boot";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(281, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "minutes from computer boot";
            // 
            // TxtMinutesAfter
            // 
            this.TxtMinutesAfter.Enabled = false;
            this.TxtMinutesAfter.Location = new System.Drawing.Point(215, 118);
            this.TxtMinutesAfter.MaxLength = 3;
            this.TxtMinutesAfter.Name = "TxtMinutesAfter";
            this.TxtMinutesAfter.Size = new System.Drawing.Size(60, 20);
            this.TxtMinutesAfter.TabIndex = 5;
            // 
            // RdbTriggerEventAfter
            // 
            this.RdbTriggerEventAfter.AutoSize = true;
            this.RdbTriggerEventAfter.Location = new System.Drawing.Point(15, 119);
            this.RdbTriggerEventAfter.Name = "RdbTriggerEventAfter";
            this.RdbTriggerEventAfter.Size = new System.Drawing.Size(185, 17);
            this.RdbTriggerEventAfter.TabIndex = 4;
            this.RdbTriggerEventAfter.Text = "Trigger event if service starts after";
            this.RdbTriggerEventAfter.UseVisualStyleBackColor = true;
            // 
            // WndTDPRobotServiceStartEventConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 220);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtMinutesAfter);
            this.Controls.Add(this.RdbTriggerEventAfter);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TxtMinutesWithin);
            this.Controls.Add(this.RdbTriggerEventWithin);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WndTDPRobotServiceStartEventConfig";
            this.Text = "TDP Robot service start event configuration";
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.BtnCancel, 0);
            this.Controls.SetChildIndex(this.BtnSave, 0);
            this.Controls.SetChildIndex(this.RdbTriggerEventWithin, 0);
            this.Controls.SetChildIndex(this.TxtMinutesWithin, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.RdbTriggerEventAfter, 0);
            this.Controls.SetChildIndex(this.TxtMinutesAfter, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RadioButton RdbTriggerEventWithin;
        private System.Windows.Forms.TextBox TxtMinutesWithin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtMinutesAfter;
        private System.Windows.Forms.RadioButton RdbTriggerEventAfter;
    }
}