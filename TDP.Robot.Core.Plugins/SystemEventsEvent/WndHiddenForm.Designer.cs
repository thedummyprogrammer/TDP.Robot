﻿
namespace TDP.Robot.Plugins.Core.SystemEventsEvent
{
    partial class WndHiddenForm
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
            this.SuspendLayout();
            // 
            // WndHiddenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(190, 119);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Location = new System.Drawing.Point(-100, -100);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WndHiddenForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "WndHiddenForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WndHiddenForm_FormClosing);
            this.Load += new System.EventHandler(this.WndHiddenForm_Load);
            this.ResumeLayout(false);

        }

        #endregion
    }
}