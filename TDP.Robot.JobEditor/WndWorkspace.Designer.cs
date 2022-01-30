namespace TDP.Robot.JobEditor
{
    partial class WndWorkspace
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WndWorkspace));
            this.JobContainer = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // JobContainer
            // 
            this.JobContainer.Location = new System.Drawing.Point(0, 0);
            this.JobContainer.Name = "JobContainer";
            this.JobContainer.Size = new System.Drawing.Size(200, 100);
            this.JobContainer.TabIndex = 0;
            // 
            // WndWorkspace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.JobContainer);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WndWorkspace";
            this.Text = "Workspace";
            this.SizeChanged += new System.EventHandler(this.WndWorkspace_SizeChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.WndWorkspace_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel JobContainer;
    }
}