namespace TDP.Robot.JobEditor
{
    partial class WndToolbox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WndToolbox));
            this.ImgList1 = new System.Windows.Forms.ImageList(this.components);
            this.LstPlugins = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtSearch = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ImgList1
            // 
            this.ImgList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImgList1.ImageStream")));
            this.ImgList1.TransparentColor = System.Drawing.Color.Transparent;
            this.ImgList1.Images.SetKeyName(0, "DateTime");
            // 
            // LstPlugins
            // 
            resources.ApplyResources(this.LstPlugins, "LstPlugins");
            this.LstPlugins.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LstPlugins.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.LstPlugins.FormattingEnabled = true;
            this.LstPlugins.Name = "LstPlugins";
            this.LstPlugins.Sorted = true;
            this.LstPlugins.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.LstPlugins_DrawItem);
            this.LstPlugins.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LstPlugins_MouseDown);
            this.LstPlugins.MouseMove += new System.Windows.Forms.MouseEventHandler(this.LstPlugins_MouseMove);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // TxtSearch
            // 
            resources.ApplyResources(this.TxtSearch, "TxtSearch");
            this.TxtSearch.Name = "TxtSearch";
            this.TxtSearch.TextChanged += new System.EventHandler(this.TxtSearch_TextChanged);
            // 
            // WndToolbox
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.TxtSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LstPlugins);
            this.Name = "WndToolbox";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ImageList ImgList1;
        private System.Windows.Forms.ListBox LstPlugins;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtSearch;
    }
}