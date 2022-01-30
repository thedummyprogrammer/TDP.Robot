namespace TDP.Robot.JobEditor
{
    partial class WndMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WndMain));
            this.MainWndMenuStrip = new System.Windows.Forms.MenuStrip();
            this.MnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuObjects = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuSave = new System.Windows.Forms.ToolStripMenuItem();
            this.windowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuWindowCascade = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuWindowTileHoriz = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuWindowTileVert = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuWindowArrange = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuWindowStdPositioning = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuWindowCloseAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.MnuWindowShowHide = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuWindowShowHideFolders = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuWindowShowHideWorkspace = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuWindowShowHideToolbox = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuWindowShowHideLog = new System.Windows.Forms.ToolStripMenuItem();
            this.MainWndMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainWndMenuStrip
            // 
            this.MainWndMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuFile,
            this.MnuObjects,
            this.windowToolStripMenuItem});
            resources.ApplyResources(this.MainWndMenuStrip, "MainWndMenuStrip");
            this.MainWndMenuStrip.Name = "MainWndMenuStrip";
            // 
            // MnuFile
            // 
            this.MnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuAbout,
            this.toolStripSeparator1,
            this.MnuExit});
            this.MnuFile.Name = "MnuFile";
            resources.ApplyResources(this.MnuFile, "MnuFile");
            // 
            // MnuAbout
            // 
            resources.ApplyResources(this.MnuAbout, "MnuAbout");
            this.MnuAbout.Name = "MnuAbout";
            this.MnuAbout.Click += new System.EventHandler(this.MnuAbout_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // MnuExit
            // 
            this.MnuExit.Name = "MnuExit";
            resources.ApplyResources(this.MnuExit, "MnuExit");
            this.MnuExit.Click += new System.EventHandler(this.MnuExit_Click);
            // 
            // MnuObjects
            // 
            this.MnuObjects.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuSave});
            this.MnuObjects.Name = "MnuObjects";
            resources.ApplyResources(this.MnuObjects, "MnuObjects");
            // 
            // MnuSave
            // 
            this.MnuSave.Name = "MnuSave";
            resources.ApplyResources(this.MnuSave, "MnuSave");
            this.MnuSave.Click += new System.EventHandler(this.MnuSave_Click);
            // 
            // windowToolStripMenuItem
            // 
            this.windowToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuWindowCascade,
            this.MnuWindowTileHoriz,
            this.MnuWindowTileVert,
            this.MnuWindowArrange,
            this.MnuWindowStdPositioning,
            this.MnuWindowCloseAll,
            this.toolStripMenuItem1,
            this.MnuWindowShowHide});
            this.windowToolStripMenuItem.Name = "windowToolStripMenuItem";
            resources.ApplyResources(this.windowToolStripMenuItem, "windowToolStripMenuItem");
            // 
            // MnuWindowCascade
            // 
            this.MnuWindowCascade.Name = "MnuWindowCascade";
            resources.ApplyResources(this.MnuWindowCascade, "MnuWindowCascade");
            this.MnuWindowCascade.Click += new System.EventHandler(this.MnuWindowCascade_Click);
            // 
            // MnuWindowTileHoriz
            // 
            this.MnuWindowTileHoriz.Name = "MnuWindowTileHoriz";
            resources.ApplyResources(this.MnuWindowTileHoriz, "MnuWindowTileHoriz");
            this.MnuWindowTileHoriz.Click += new System.EventHandler(this.MnuWindowTileHoriz_Click);
            // 
            // MnuWindowTileVert
            // 
            this.MnuWindowTileVert.Name = "MnuWindowTileVert";
            resources.ApplyResources(this.MnuWindowTileVert, "MnuWindowTileVert");
            this.MnuWindowTileVert.Click += new System.EventHandler(this.MnuWindowTileVert_Click);
            // 
            // MnuWindowArrange
            // 
            this.MnuWindowArrange.Name = "MnuWindowArrange";
            resources.ApplyResources(this.MnuWindowArrange, "MnuWindowArrange");
            this.MnuWindowArrange.Click += new System.EventHandler(this.MnuWindowArrange_Click);
            // 
            // MnuWindowStdPositioning
            // 
            this.MnuWindowStdPositioning.Name = "MnuWindowStdPositioning";
            resources.ApplyResources(this.MnuWindowStdPositioning, "MnuWindowStdPositioning");
            this.MnuWindowStdPositioning.Click += new System.EventHandler(this.MnuWindowStdPositioning_Click);
            // 
            // MnuWindowCloseAll
            // 
            this.MnuWindowCloseAll.Name = "MnuWindowCloseAll";
            resources.ApplyResources(this.MnuWindowCloseAll, "MnuWindowCloseAll");
            this.MnuWindowCloseAll.Click += new System.EventHandler(this.MnuWindowCloseAll_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
            // 
            // MnuWindowShowHide
            // 
            this.MnuWindowShowHide.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuWindowShowHideFolders,
            this.MnuWindowShowHideWorkspace,
            this.MnuWindowShowHideToolbox,
            this.MnuWindowShowHideLog});
            this.MnuWindowShowHide.Name = "MnuWindowShowHide";
            resources.ApplyResources(this.MnuWindowShowHide, "MnuWindowShowHide");
            // 
            // MnuWindowShowHideFolders
            // 
            this.MnuWindowShowHideFolders.Name = "MnuWindowShowHideFolders";
            resources.ApplyResources(this.MnuWindowShowHideFolders, "MnuWindowShowHideFolders");
            this.MnuWindowShowHideFolders.Click += new System.EventHandler(this.MnuWindowShowHideFolders_Click);
            // 
            // MnuWindowShowHideWorkspace
            // 
            this.MnuWindowShowHideWorkspace.Name = "MnuWindowShowHideWorkspace";
            resources.ApplyResources(this.MnuWindowShowHideWorkspace, "MnuWindowShowHideWorkspace");
            this.MnuWindowShowHideWorkspace.Click += new System.EventHandler(this.MnuWindowShowHideWorkspace_Click);
            // 
            // MnuWindowShowHideToolbox
            // 
            this.MnuWindowShowHideToolbox.Name = "MnuWindowShowHideToolbox";
            resources.ApplyResources(this.MnuWindowShowHideToolbox, "MnuWindowShowHideToolbox");
            this.MnuWindowShowHideToolbox.Click += new System.EventHandler(this.MnuWindowShowHideToolbox_Click);
            // 
            // MnuWindowShowHideLog
            // 
            this.MnuWindowShowHideLog.Name = "MnuWindowShowHideLog";
            resources.ApplyResources(this.MnuWindowShowHideLog, "MnuWindowShowHideLog");
            this.MnuWindowShowHideLog.Click += new System.EventHandler(this.MnuWindowShowHideLog_Click);
            // 
            // WndMain
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MainWndMenuStrip);
            this.IsMdiContainer = true;
            this.Name = "WndMain";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WndMain_FormClosing);
            this.MainWndMenuStrip.ResumeLayout(false);
            this.MainWndMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MainWndMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem MnuFile;
        private System.Windows.Forms.ToolStripMenuItem MnuAbout;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem MnuExit;
        private System.Windows.Forms.ToolStripMenuItem MnuObjects;
        private System.Windows.Forms.ToolStripMenuItem MnuSave;
        private System.Windows.Forms.ToolStripMenuItem windowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MnuWindowCascade;
        private System.Windows.Forms.ToolStripMenuItem MnuWindowTileHoriz;
        private System.Windows.Forms.ToolStripMenuItem MnuWindowTileVert;
        private System.Windows.Forms.ToolStripMenuItem MnuWindowArrange;
        private System.Windows.Forms.ToolStripMenuItem MnuWindowCloseAll;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem MnuWindowShowHide;
        private System.Windows.Forms.ToolStripMenuItem MnuWindowShowHideFolders;
        private System.Windows.Forms.ToolStripMenuItem MnuWindowShowHideWorkspace;
        private System.Windows.Forms.ToolStripMenuItem MnuWindowShowHideToolbox;
        private System.Windows.Forms.ToolStripMenuItem MnuWindowShowHideLog;
        private System.Windows.Forms.ToolStripMenuItem MnuWindowStdPositioning;
    }
}

