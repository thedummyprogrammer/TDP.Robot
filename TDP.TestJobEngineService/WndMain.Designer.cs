
namespace TDP.Robot.TestJobEngineService
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
            this.BtnStopJobEngine = new System.Windows.Forms.Button();
            this.BtnStartJobEngine = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnStopJobEngine
            // 
            this.BtnStopJobEngine.Location = new System.Drawing.Point(104, 148);
            this.BtnStopJobEngine.Name = "BtnStopJobEngine";
            this.BtnStopJobEngine.Size = new System.Drawing.Size(221, 66);
            this.BtnStopJobEngine.TabIndex = 5;
            this.BtnStopJobEngine.Text = "End Job Engine";
            this.BtnStopJobEngine.UseVisualStyleBackColor = true;
            this.BtnStopJobEngine.Click += new System.EventHandler(this.BtnStopJobEngine_Click);
            // 
            // BtnStartJobEngine
            // 
            this.BtnStartJobEngine.Location = new System.Drawing.Point(104, 66);
            this.BtnStartJobEngine.Name = "BtnStartJobEngine";
            this.BtnStartJobEngine.Size = new System.Drawing.Size(221, 66);
            this.BtnStartJobEngine.TabIndex = 4;
            this.BtnStartJobEngine.Text = "Start Job Engine";
            this.BtnStartJobEngine.UseVisualStyleBackColor = true;
            this.BtnStartJobEngine.Click += new System.EventHandler(this.BtnStartJobEngine_Click);
            // 
            // WndMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 269);
            this.Controls.Add(this.BtnStopJobEngine);
            this.Controls.Add(this.BtnStartJobEngine);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "WndMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Test Job Engine service";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnStopJobEngine;
        private System.Windows.Forms.Button BtnStartJobEngine;
    }
}

