namespace TDP.Robot.JobEditor
{
    partial class WndLog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WndLog));
            this.LogFileWatcher = new System.IO.FileSystemWatcher();
            this.LstLog = new TDP.Robot.JobEditor.Infrastructure.Controls.LogListBox();
            this.MnuLstLog = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MnuClearAll = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.LogFileWatcher)).BeginInit();
            this.MnuLstLog.SuspendLayout();
            this.SuspendLayout();
            // 
            // LogFileWatcher
            // 
            this.LogFileWatcher.EnableRaisingEvents = true;
            this.LogFileWatcher.Filter = "*.log";
            this.LogFileWatcher.SynchronizingObject = this;
            this.LogFileWatcher.Created += new System.IO.FileSystemEventHandler(this.LogFileWatcher_Created);
            this.LogFileWatcher.Deleted += new System.IO.FileSystemEventHandler(this.LogFileWatcher_Deleted);
            // 
            // LstLog
            // 
            this.LstLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LstLog.ContextMenuStrip = this.MnuLstLog;
            this.LstLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LstLog.FormattingEnabled = true;
            this.LstLog.Location = new System.Drawing.Point(0, 0);
            this.LstLog.Name = "LstLog";
            this.LstLog.Size = new System.Drawing.Size(800, 450);
            this.LstLog.Sorted = true;
            this.LstLog.TabIndex = 0;
            this.LstLog.DoubleClick += new System.EventHandler(this.LstLog_DoubleClick);
            // 
            // MnuLstLog
            // 
            this.MnuLstLog.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuClearAll});
            this.MnuLstLog.Name = "MnuLstLog";
            this.MnuLstLog.Size = new System.Drawing.Size(181, 48);
            // 
            // MnuClearAll
            // 
            this.MnuClearAll.Name = "MnuClearAll";
            this.MnuClearAll.Size = new System.Drawing.Size(180, 22);
            this.MnuClearAll.Text = "Clear all";
            this.MnuClearAll.Click += new System.EventHandler(this.MnuClearAll_Click);
            // 
            // WndLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.LstLog);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WndLog";
            this.Text = "Log";
            ((System.ComponentModel.ISupportInitialize)(this.LogFileWatcher)).EndInit();
            this.MnuLstLog.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.IO.FileSystemWatcher LogFileWatcher;
        private Infrastructure.Controls.LogListBox LstLog;
        private System.Windows.Forms.ContextMenuStrip MnuLstLog;
        private System.Windows.Forms.ToolStripMenuItem MnuClearAll;
    }
}