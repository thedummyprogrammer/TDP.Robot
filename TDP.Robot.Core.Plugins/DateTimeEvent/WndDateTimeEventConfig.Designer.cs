namespace TDP.Robot.Plugins.Core.DateTimeEvent
{
    partial class WndDateTimeEventConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WndDateTimeEventConfig));
            this.GrpPeriodicity = new System.Windows.Forms.GroupBox();
            this.ChkOnAllDays = new System.Windows.Forms.CheckBox();
            this.ChkOnSunday = new System.Windows.Forms.CheckBox();
            this.ChkOnSaturday = new System.Windows.Forms.CheckBox();
            this.ChkOnFriday = new System.Windows.Forms.CheckBox();
            this.ChkOnThursday = new System.Windows.Forms.CheckBox();
            this.ChkOnWednesday = new System.Windows.Forms.CheckBox();
            this.ChkOnTuesday = new System.Windows.Forms.CheckBox();
            this.ChkOnMonday = new System.Windows.Forms.CheckBox();
            this.OptEverySeconds = new System.Windows.Forms.RadioButton();
            this.OptEveryDaysHoursSecs = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.OptOneTime = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.TxtEveryNumSeconds = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.TxtEveryNumMinutes = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TxtEveryNumHours = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtEveryNumDays = new System.Windows.Forms.TextBox();
            this.DtAtTime = new System.Windows.Forms.DateTimePicker();
            this.DtAtDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrProvider)).BeginInit();
            this.GrpPeriodicity.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnSave
            // 
            resources.ApplyResources(this.BtnSave, "BtnSave");
            // 
            // BtnCancel
            // 
            resources.ApplyResources(this.BtnCancel, "BtnCancel");
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            // 
            // ChkDoNotLog
            // 
            resources.ApplyResources(this.ChkDoNotLog, "ChkDoNotLog");
            // 
            // ChkDisable
            // 
            resources.ApplyResources(this.ChkDisable, "ChkDisable");
            // 
            // TxtName
            // 
            resources.ApplyResources(this.TxtName, "TxtName");
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            // 
            // GrpPeriodicity
            // 
            this.GrpPeriodicity.Controls.Add(this.ChkOnAllDays);
            this.GrpPeriodicity.Controls.Add(this.ChkOnSunday);
            this.GrpPeriodicity.Controls.Add(this.ChkOnSaturday);
            this.GrpPeriodicity.Controls.Add(this.ChkOnFriday);
            this.GrpPeriodicity.Controls.Add(this.ChkOnThursday);
            this.GrpPeriodicity.Controls.Add(this.ChkOnWednesday);
            this.GrpPeriodicity.Controls.Add(this.ChkOnTuesday);
            this.GrpPeriodicity.Controls.Add(this.ChkOnMonday);
            this.GrpPeriodicity.Controls.Add(this.OptEverySeconds);
            this.GrpPeriodicity.Controls.Add(this.OptEveryDaysHoursSecs);
            this.GrpPeriodicity.Controls.Add(this.label3);
            this.GrpPeriodicity.Controls.Add(this.OptOneTime);
            this.GrpPeriodicity.Controls.Add(this.label8);
            this.GrpPeriodicity.Controls.Add(this.TxtEveryNumSeconds);
            this.GrpPeriodicity.Controls.Add(this.label7);
            this.GrpPeriodicity.Controls.Add(this.TxtEveryNumMinutes);
            this.GrpPeriodicity.Controls.Add(this.label6);
            this.GrpPeriodicity.Controls.Add(this.TxtEveryNumHours);
            this.GrpPeriodicity.Controls.Add(this.label5);
            this.GrpPeriodicity.Controls.Add(this.TxtEveryNumDays);
            this.GrpPeriodicity.Controls.Add(this.DtAtTime);
            this.GrpPeriodicity.Controls.Add(this.DtAtDate);
            this.GrpPeriodicity.Controls.Add(this.label2);
            resources.ApplyResources(this.GrpPeriodicity, "GrpPeriodicity");
            this.GrpPeriodicity.Name = "GrpPeriodicity";
            this.GrpPeriodicity.TabStop = false;
            // 
            // ChkOnAllDays
            // 
            resources.ApplyResources(this.ChkOnAllDays, "ChkOnAllDays");
            this.ChkOnAllDays.Name = "ChkOnAllDays";
            this.ChkOnAllDays.UseVisualStyleBackColor = true;
            this.ChkOnAllDays.CheckedChanged += new System.EventHandler(this.ChkOnAllDays_CheckedChanged);
            // 
            // ChkOnSunday
            // 
            resources.ApplyResources(this.ChkOnSunday, "ChkOnSunday");
            this.ChkOnSunday.Name = "ChkOnSunday";
            this.ChkOnSunday.UseVisualStyleBackColor = true;
            // 
            // ChkOnSaturday
            // 
            resources.ApplyResources(this.ChkOnSaturday, "ChkOnSaturday");
            this.ChkOnSaturday.Name = "ChkOnSaturday";
            this.ChkOnSaturday.UseVisualStyleBackColor = true;
            // 
            // ChkOnFriday
            // 
            resources.ApplyResources(this.ChkOnFriday, "ChkOnFriday");
            this.ChkOnFriday.Name = "ChkOnFriday";
            this.ChkOnFriday.UseVisualStyleBackColor = true;
            // 
            // ChkOnThursday
            // 
            resources.ApplyResources(this.ChkOnThursday, "ChkOnThursday");
            this.ChkOnThursday.Name = "ChkOnThursday";
            this.ChkOnThursday.UseVisualStyleBackColor = true;
            // 
            // ChkOnWednesday
            // 
            resources.ApplyResources(this.ChkOnWednesday, "ChkOnWednesday");
            this.ChkOnWednesday.Name = "ChkOnWednesday";
            this.ChkOnWednesday.UseVisualStyleBackColor = true;
            // 
            // ChkOnTuesday
            // 
            resources.ApplyResources(this.ChkOnTuesday, "ChkOnTuesday");
            this.ChkOnTuesday.Name = "ChkOnTuesday";
            this.ChkOnTuesday.UseVisualStyleBackColor = true;
            // 
            // ChkOnMonday
            // 
            resources.ApplyResources(this.ChkOnMonday, "ChkOnMonday");
            this.ChkOnMonday.Name = "ChkOnMonday";
            this.ChkOnMonday.UseVisualStyleBackColor = true;
            // 
            // OptEverySeconds
            // 
            resources.ApplyResources(this.OptEverySeconds, "OptEverySeconds");
            this.OptEverySeconds.Name = "OptEverySeconds";
            this.OptEverySeconds.UseVisualStyleBackColor = true;
            this.OptEverySeconds.CheckedChanged += new System.EventHandler(this.OptEverySeconds_CheckedChanged);
            // 
            // OptEveryDaysHoursSecs
            // 
            resources.ApplyResources(this.OptEveryDaysHoursSecs, "OptEveryDaysHoursSecs");
            this.OptEveryDaysHoursSecs.Name = "OptEveryDaysHoursSecs";
            this.OptEveryDaysHoursSecs.UseVisualStyleBackColor = true;
            this.OptEveryDaysHoursSecs.CheckedChanged += new System.EventHandler(this.OptEveryDaysHoursSecs_CheckedChanged);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // OptOneTime
            // 
            resources.ApplyResources(this.OptOneTime, "OptOneTime");
            this.OptOneTime.Checked = true;
            this.OptOneTime.Name = "OptOneTime";
            this.OptOneTime.TabStop = true;
            this.OptOneTime.UseVisualStyleBackColor = true;
            this.OptOneTime.CheckedChanged += new System.EventHandler(this.OptOneTime_CheckedChanged);
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // TxtEveryNumSeconds
            // 
            resources.ApplyResources(this.TxtEveryNumSeconds, "TxtEveryNumSeconds");
            this.TxtEveryNumSeconds.Name = "TxtEveryNumSeconds";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // TxtEveryNumMinutes
            // 
            resources.ApplyResources(this.TxtEveryNumMinutes, "TxtEveryNumMinutes");
            this.TxtEveryNumMinutes.Name = "TxtEveryNumMinutes";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // TxtEveryNumHours
            // 
            resources.ApplyResources(this.TxtEveryNumHours, "TxtEveryNumHours");
            this.TxtEveryNumHours.Name = "TxtEveryNumHours";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // TxtEveryNumDays
            // 
            resources.ApplyResources(this.TxtEveryNumDays, "TxtEveryNumDays");
            this.TxtEveryNumDays.Name = "TxtEveryNumDays";
            // 
            // DtAtTime
            // 
            resources.ApplyResources(this.DtAtTime, "DtAtTime");
            this.DtAtTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtAtTime.Name = "DtAtTime";
            this.DtAtTime.ShowUpDown = true;
            // 
            // DtAtDate
            // 
            resources.ApplyResources(this.DtAtDate, "DtAtDate");
            this.DtAtDate.Name = "DtAtDate";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // WndDateTimeEventConfig
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.GrpPeriodicity);
            this.Name = "WndDateTimeEventConfig";
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.BtnCancel, 0);
            this.Controls.SetChildIndex(this.BtnSave, 0);
            this.Controls.SetChildIndex(this.GrpPeriodicity, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrProvider)).EndInit();
            this.GrpPeriodicity.ResumeLayout(false);
            this.GrpPeriodicity.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GrpPeriodicity;
        private System.Windows.Forms.RadioButton OptEverySeconds;
        private System.Windows.Forms.RadioButton OptEveryDaysHoursSecs;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton OptOneTime;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TxtEveryNumSeconds;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TxtEveryNumMinutes;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TxtEveryNumHours;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtEveryNumDays;
        private System.Windows.Forms.DateTimePicker DtAtTime;
        private System.Windows.Forms.DateTimePicker DtAtDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox ChkOnMonday;
        private System.Windows.Forms.CheckBox ChkOnSunday;
        private System.Windows.Forms.CheckBox ChkOnSaturday;
        private System.Windows.Forms.CheckBox ChkOnFriday;
        private System.Windows.Forms.CheckBox ChkOnThursday;
        private System.Windows.Forms.CheckBox ChkOnWednesday;
        private System.Windows.Forms.CheckBox ChkOnTuesday;
        private System.Windows.Forms.CheckBox ChkOnAllDays;
    }
}