
namespace TDP.Robot.Plugins.Core.MemoryEvent
{
    partial class WndMemoryEventConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WndMemoryEventConfig));
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TxtCheckIntervalSeconds = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.GrpEventConfig = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtMinutesFromLastTrigger = new System.Windows.Forms.TextBox();
            this.ChkTriggerIfPassedXMinFromLastTrigger = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtAvgIntervalMinutes = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtThreshold2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtThreshold1 = new System.Windows.Forms.TextBox();
            this.RdbTriggerIfAvgUsageIsAboveThreshold = new System.Windows.Forms.RadioButton();
            this.RdbTriggerIfUsageIsAboveThreshold = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrProvider)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.GrpEventConfig.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(419, 324);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(500, 324);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.TxtCheckIntervalSeconds);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Location = new System.Drawing.Point(12, 240);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(563, 69);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Frequency test";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(181, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "seconds";
            // 
            // TxtCheckIntervalSeconds
            // 
            this.TxtCheckIntervalSeconds.Location = new System.Drawing.Point(100, 32);
            this.TxtCheckIntervalSeconds.Name = "TxtCheckIntervalSeconds";
            this.TxtCheckIntervalSeconds.Size = new System.Drawing.Size(75, 20);
            this.TxtCheckIntervalSeconds.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(27, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Check every";
            // 
            // GrpEventConfig
            // 
            this.GrpEventConfig.Controls.Add(this.label5);
            this.GrpEventConfig.Controls.Add(this.TxtMinutesFromLastTrigger);
            this.GrpEventConfig.Controls.Add(this.ChkTriggerIfPassedXMinFromLastTrigger);
            this.GrpEventConfig.Controls.Add(this.label4);
            this.GrpEventConfig.Controls.Add(this.TxtAvgIntervalMinutes);
            this.GrpEventConfig.Controls.Add(this.label3);
            this.GrpEventConfig.Controls.Add(this.TxtThreshold2);
            this.GrpEventConfig.Controls.Add(this.label2);
            this.GrpEventConfig.Controls.Add(this.TxtThreshold1);
            this.GrpEventConfig.Controls.Add(this.RdbTriggerIfAvgUsageIsAboveThreshold);
            this.GrpEventConfig.Controls.Add(this.RdbTriggerIfUsageIsAboveThreshold);
            this.GrpEventConfig.Location = new System.Drawing.Point(12, 82);
            this.GrpEventConfig.Name = "GrpEventConfig";
            this.GrpEventConfig.Size = new System.Drawing.Size(563, 152);
            this.GrpEventConfig.TabIndex = 8;
            this.GrpEventConfig.TabStop = false;
            this.GrpEventConfig.Text = "Event configuration";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(371, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "from the last trigger";
            // 
            // TxtMinutesFromLastTrigger
            // 
            this.TxtMinutesFromLastTrigger.Enabled = false;
            this.TxtMinutesFromLastTrigger.Location = new System.Drawing.Point(303, 104);
            this.TxtMinutesFromLastTrigger.Name = "TxtMinutesFromLastTrigger";
            this.TxtMinutesFromLastTrigger.Size = new System.Drawing.Size(62, 20);
            this.TxtMinutesFromLastTrigger.TabIndex = 9;
            // 
            // ChkTriggerIfPassedXMinFromLastTrigger
            // 
            this.ChkTriggerIfPassedXMinFromLastTrigger.AutoSize = true;
            this.ChkTriggerIfPassedXMinFromLastTrigger.Location = new System.Drawing.Point(20, 107);
            this.ChkTriggerIfPassedXMinFromLastTrigger.Name = "ChkTriggerIfPassedXMinFromLastTrigger";
            this.ChkTriggerIfPassedXMinFromLastTrigger.Size = new System.Drawing.Size(277, 17);
            this.ChkTriggerIfPassedXMinFromLastTrigger.TabIndex = 8;
            this.ChkTriggerIfPassedXMinFromLastTrigger.Text = "Trigger only if the following number of minutes passed";
            this.ChkTriggerIfPassedXMinFromLastTrigger.UseVisualStyleBackColor = true;
            this.ChkTriggerIfPassedXMinFromLastTrigger.CheckedChanged += new System.EventHandler(this.ChkTriggerIfPassedXMinFromLastTrigger_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(509, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "minutes";
            // 
            // TxtAvgIntervalMinutes
            // 
            this.TxtAvgIntervalMinutes.Enabled = false;
            this.TxtAvgIntervalMinutes.Location = new System.Drawing.Point(441, 62);
            this.TxtAvgIntervalMinutes.MaxLength = 3;
            this.TxtAvgIntervalMinutes.Name = "TxtAvgIntervalMinutes";
            this.TxtAvgIntervalMinutes.Size = new System.Drawing.Size(62, 20);
            this.TxtAvgIntervalMinutes.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(370, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "% in the last ";
            // 
            // TxtThreshold2
            // 
            this.TxtThreshold2.Enabled = false;
            this.TxtThreshold2.Location = new System.Drawing.Point(303, 62);
            this.TxtThreshold2.MaxLength = 3;
            this.TxtThreshold2.Name = "TxtThreshold2";
            this.TxtThreshold2.Size = new System.Drawing.Size(62, 20);
            this.TxtThreshold2.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(320, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "%";
            // 
            // TxtThreshold1
            // 
            this.TxtThreshold1.Location = new System.Drawing.Point(252, 27);
            this.TxtThreshold1.MaxLength = 3;
            this.TxtThreshold1.Name = "TxtThreshold1";
            this.TxtThreshold1.Size = new System.Drawing.Size(62, 20);
            this.TxtThreshold1.TabIndex = 2;
            // 
            // RdbTriggerIfAvgUsageIsAboveThreshold
            // 
            this.RdbTriggerIfAvgUsageIsAboveThreshold.AutoSize = true;
            this.RdbTriggerIfAvgUsageIsAboveThreshold.Location = new System.Drawing.Point(20, 62);
            this.RdbTriggerIfAvgUsageIsAboveThreshold.Name = "RdbTriggerIfAvgUsageIsAboveThreshold";
            this.RdbTriggerIfAvgUsageIsAboveThreshold.Size = new System.Drawing.Size(268, 17);
            this.RdbTriggerIfAvgUsageIsAboveThreshold.TabIndex = 1;
            this.RdbTriggerIfAvgUsageIsAboveThreshold.Text = "Trigger if memory usage average is above threshold";
            this.RdbTriggerIfAvgUsageIsAboveThreshold.UseVisualStyleBackColor = true;
            this.RdbTriggerIfAvgUsageIsAboveThreshold.CheckedChanged += new System.EventHandler(this.RdbTriggerIfAvgUsageIsAboveThreshold_CheckedChanged);
            // 
            // RdbTriggerIfUsageIsAboveThreshold
            // 
            this.RdbTriggerIfUsageIsAboveThreshold.AutoSize = true;
            this.RdbTriggerIfUsageIsAboveThreshold.Checked = true;
            this.RdbTriggerIfUsageIsAboveThreshold.Location = new System.Drawing.Point(20, 28);
            this.RdbTriggerIfUsageIsAboveThreshold.Name = "RdbTriggerIfUsageIsAboveThreshold";
            this.RdbTriggerIfUsageIsAboveThreshold.Size = new System.Drawing.Size(226, 17);
            this.RdbTriggerIfUsageIsAboveThreshold.TabIndex = 0;
            this.RdbTriggerIfUsageIsAboveThreshold.TabStop = true;
            this.RdbTriggerIfUsageIsAboveThreshold.Text = "Trigger if memory usage is above threshold";
            this.RdbTriggerIfUsageIsAboveThreshold.UseVisualStyleBackColor = true;
            this.RdbTriggerIfUsageIsAboveThreshold.CheckedChanged += new System.EventHandler(this.RdbTriggerIfUsageIsAboveThreshold_CheckedChanged);
            // 
            // WndMemoryEventConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 357);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.GrpEventConfig);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WndMemoryEventConfig";
            this.Text = "Memory event configuration";
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.BtnCancel, 0);
            this.Controls.SetChildIndex(this.BtnSave, 0);
            this.Controls.SetChildIndex(this.GrpEventConfig, 0);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrProvider)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.GrpEventConfig.ResumeLayout(false);
            this.GrpEventConfig.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TxtCheckIntervalSeconds;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox GrpEventConfig;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtMinutesFromLastTrigger;
        private System.Windows.Forms.CheckBox ChkTriggerIfPassedXMinFromLastTrigger;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtAvgIntervalMinutes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtThreshold2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtThreshold1;
        private System.Windows.Forms.RadioButton RdbTriggerIfAvgUsageIsAboveThreshold;
        private System.Windows.Forms.RadioButton RdbTriggerIfUsageIsAboveThreshold;
    }
}