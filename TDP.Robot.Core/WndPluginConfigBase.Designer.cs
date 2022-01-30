namespace TDP.Robot.Core
{
    partial class WndPluginConfigBase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WndPluginConfigBase));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LblID = new System.Windows.Forms.Label();
            this.TxtID = new System.Windows.Forms.TextBox();
            this.ChkDoNotLog = new System.Windows.Forms.CheckBox();
            this.ChkDisable = new System.Windows.Forms.CheckBox();
            this.TxtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnSave = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.ErrProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LblID);
            this.groupBox1.Controls.Add(this.TxtID);
            this.groupBox1.Controls.Add(this.ChkDoNotLog);
            this.groupBox1.Controls.Add(this.ChkDisable);
            this.groupBox1.Controls.Add(this.TxtName);
            this.groupBox1.Controls.Add(this.label1);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // LblID
            // 
            resources.ApplyResources(this.LblID, "LblID");
            this.LblID.Name = "LblID";
            // 
            // TxtID
            // 
            resources.ApplyResources(this.TxtID, "TxtID");
            this.TxtID.Name = "TxtID";
            this.TxtID.ReadOnly = true;
            // 
            // ChkDoNotLog
            // 
            resources.ApplyResources(this.ChkDoNotLog, "ChkDoNotLog");
            this.ChkDoNotLog.Name = "ChkDoNotLog";
            this.ChkDoNotLog.UseVisualStyleBackColor = true;
            // 
            // ChkDisable
            // 
            resources.ApplyResources(this.ChkDisable, "ChkDisable");
            this.ChkDisable.Name = "ChkDisable";
            this.ChkDisable.UseVisualStyleBackColor = true;
            // 
            // TxtName
            // 
            resources.ApplyResources(this.TxtName, "TxtName");
            this.TxtName.Name = "TxtName";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // BtnSave
            // 
            resources.ApplyResources(this.BtnSave, "BtnSave");
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.BtnCancel, "BtnCancel");
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            // 
            // ErrProvider
            // 
            this.ErrProvider.ContainerControl = this;
            // 
            // WndPluginConfigBase
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WndPluginConfigBase";
            this.ShowInTaskbar = false;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        protected System.Windows.Forms.Button BtnSave;
        protected System.Windows.Forms.Button BtnCancel;
        protected System.Windows.Forms.GroupBox groupBox1;
        protected System.Windows.Forms.CheckBox ChkDoNotLog;
        protected System.Windows.Forms.CheckBox ChkDisable;
        protected System.Windows.Forms.TextBox TxtName;
        protected System.Windows.Forms.Label label1;
        protected System.Windows.Forms.ErrorProvider ErrProvider;
        private System.Windows.Forms.TextBox TxtID;
        protected System.Windows.Forms.Label LblID;
    }
}