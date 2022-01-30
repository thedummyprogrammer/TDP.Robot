
namespace TDP.Robot.Plugins.Core.SystemEventsEvent
{
    partial class WndSystemEventsEventConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WndSystemEventsEventConfig));
            this.GrpEventsToMonitor = new System.Windows.Forms.GroupBox();
            this.ChkEventDisplaySettingsChanged = new System.Windows.Forms.CheckBox();
            this.ChkEventInstalledFontsChanged = new System.Windows.Forms.CheckBox();
            this.ChkEventPaletteChanges = new System.Windows.Forms.CheckBox();
            this.ChkEventPowerModeChanged = new System.Windows.Forms.CheckBox();
            this.ChkEventSessionEnded = new System.Windows.Forms.CheckBox();
            this.ChkEventSessionSwitch = new System.Windows.Forms.CheckBox();
            this.ChkEventTimeChanged = new System.Windows.Forms.CheckBox();
            this.ChkEventUserPreferenceChanged = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrProvider)).BeginInit();
            this.GrpEventsToMonitor.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(419, 215);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(500, 215);
            // 
            // GrpEventsToMonitor
            // 
            this.GrpEventsToMonitor.Controls.Add(this.ChkEventUserPreferenceChanged);
            this.GrpEventsToMonitor.Controls.Add(this.ChkEventTimeChanged);
            this.GrpEventsToMonitor.Controls.Add(this.ChkEventSessionSwitch);
            this.GrpEventsToMonitor.Controls.Add(this.ChkEventSessionEnded);
            this.GrpEventsToMonitor.Controls.Add(this.ChkEventPowerModeChanged);
            this.GrpEventsToMonitor.Controls.Add(this.ChkEventPaletteChanges);
            this.GrpEventsToMonitor.Controls.Add(this.ChkEventInstalledFontsChanged);
            this.GrpEventsToMonitor.Controls.Add(this.ChkEventDisplaySettingsChanged);
            this.GrpEventsToMonitor.Location = new System.Drawing.Point(12, 82);
            this.GrpEventsToMonitor.Name = "GrpEventsToMonitor";
            this.GrpEventsToMonitor.Size = new System.Drawing.Size(563, 127);
            this.GrpEventsToMonitor.TabIndex = 6;
            this.GrpEventsToMonitor.TabStop = false;
            this.GrpEventsToMonitor.Text = "Events to monitor";
            // 
            // ChkEventDisplaySettingsChanged
            // 
            this.ChkEventDisplaySettingsChanged.AutoSize = true;
            this.ChkEventDisplaySettingsChanged.Location = new System.Drawing.Point(31, 28);
            this.ChkEventDisplaySettingsChanged.Name = "ChkEventDisplaySettingsChanged";
            this.ChkEventDisplaySettingsChanged.Size = new System.Drawing.Size(144, 17);
            this.ChkEventDisplaySettingsChanged.TabIndex = 0;
            this.ChkEventDisplaySettingsChanged.Text = "Display settings changed";
            this.ChkEventDisplaySettingsChanged.UseVisualStyleBackColor = true;
            // 
            // ChkEventInstalledFontsChanged
            // 
            this.ChkEventInstalledFontsChanged.AutoSize = true;
            this.ChkEventInstalledFontsChanged.Location = new System.Drawing.Point(31, 51);
            this.ChkEventInstalledFontsChanged.Name = "ChkEventInstalledFontsChanged";
            this.ChkEventInstalledFontsChanged.Size = new System.Drawing.Size(136, 17);
            this.ChkEventInstalledFontsChanged.TabIndex = 1;
            this.ChkEventInstalledFontsChanged.Text = "Installed fonts changed";
            this.ChkEventInstalledFontsChanged.UseVisualStyleBackColor = true;
            // 
            // ChkEventPaletteChanges
            // 
            this.ChkEventPaletteChanges.AutoSize = true;
            this.ChkEventPaletteChanges.Location = new System.Drawing.Point(31, 74);
            this.ChkEventPaletteChanges.Name = "ChkEventPaletteChanges";
            this.ChkEventPaletteChanges.Size = new System.Drawing.Size(104, 17);
            this.ChkEventPaletteChanges.TabIndex = 2;
            this.ChkEventPaletteChanges.Text = "Palette changed";
            this.ChkEventPaletteChanges.UseVisualStyleBackColor = true;
            // 
            // ChkEventPowerModeChanged
            // 
            this.ChkEventPowerModeChanged.AutoSize = true;
            this.ChkEventPowerModeChanged.Location = new System.Drawing.Point(31, 97);
            this.ChkEventPowerModeChanged.Name = "ChkEventPowerModeChanged";
            this.ChkEventPowerModeChanged.Size = new System.Drawing.Size(130, 17);
            this.ChkEventPowerModeChanged.TabIndex = 3;
            this.ChkEventPowerModeChanged.Text = "Power mode changed";
            this.ChkEventPowerModeChanged.UseVisualStyleBackColor = true;
            // 
            // ChkEventSessionEnded
            // 
            this.ChkEventSessionEnded.AutoSize = true;
            this.ChkEventSessionEnded.Location = new System.Drawing.Point(310, 28);
            this.ChkEventSessionEnded.Name = "ChkEventSessionEnded";
            this.ChkEventSessionEnded.Size = new System.Drawing.Size(96, 17);
            this.ChkEventSessionEnded.TabIndex = 4;
            this.ChkEventSessionEnded.Text = "Session ended";
            this.ChkEventSessionEnded.UseVisualStyleBackColor = true;
            // 
            // ChkEventSessionSwitch
            // 
            this.ChkEventSessionSwitch.AutoSize = true;
            this.ChkEventSessionSwitch.Location = new System.Drawing.Point(310, 51);
            this.ChkEventSessionSwitch.Name = "ChkEventSessionSwitch";
            this.ChkEventSessionSwitch.Size = new System.Drawing.Size(96, 17);
            this.ChkEventSessionSwitch.TabIndex = 5;
            this.ChkEventSessionSwitch.Text = "Session switch";
            this.ChkEventSessionSwitch.UseVisualStyleBackColor = true;
            // 
            // ChkEventTimeChanged
            // 
            this.ChkEventTimeChanged.AutoSize = true;
            this.ChkEventTimeChanged.Location = new System.Drawing.Point(310, 74);
            this.ChkEventTimeChanged.Name = "ChkEventTimeChanged";
            this.ChkEventTimeChanged.Size = new System.Drawing.Size(94, 17);
            this.ChkEventTimeChanged.TabIndex = 6;
            this.ChkEventTimeChanged.Text = "Time changed";
            this.ChkEventTimeChanged.UseVisualStyleBackColor = true;
            // 
            // ChkEventUserPreferenceChanged
            // 
            this.ChkEventUserPreferenceChanged.AutoSize = true;
            this.ChkEventUserPreferenceChanged.Location = new System.Drawing.Point(310, 97);
            this.ChkEventUserPreferenceChanged.Name = "ChkEventUserPreferenceChanged";
            this.ChkEventUserPreferenceChanged.Size = new System.Drawing.Size(147, 17);
            this.ChkEventUserPreferenceChanged.TabIndex = 7;
            this.ChkEventUserPreferenceChanged.Text = "User preference changed";
            this.ChkEventUserPreferenceChanged.UseVisualStyleBackColor = true;
            // 
            // WndSystemEventsEventConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 249);
            this.Controls.Add(this.GrpEventsToMonitor);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WndSystemEventsEventConfig";
            this.Text = "System events event config";
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.BtnCancel, 0);
            this.Controls.SetChildIndex(this.BtnSave, 0);
            this.Controls.SetChildIndex(this.GrpEventsToMonitor, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrProvider)).EndInit();
            this.GrpEventsToMonitor.ResumeLayout(false);
            this.GrpEventsToMonitor.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GrpEventsToMonitor;
        private System.Windows.Forms.CheckBox ChkEventDisplaySettingsChanged;
        private System.Windows.Forms.CheckBox ChkEventInstalledFontsChanged;
        private System.Windows.Forms.CheckBox ChkEventPowerModeChanged;
        private System.Windows.Forms.CheckBox ChkEventPaletteChanges;
        private System.Windows.Forms.CheckBox ChkEventSessionEnded;
        private System.Windows.Forms.CheckBox ChkEventSessionSwitch;
        private System.Windows.Forms.CheckBox ChkEventTimeChanged;
        private System.Windows.Forms.CheckBox ChkEventUserPreferenceChanged;
    }
}