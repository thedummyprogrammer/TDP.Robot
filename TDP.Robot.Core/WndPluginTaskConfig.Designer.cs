namespace TDP.Robot.Core
{
    partial class WndPluginTaskConfig
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
            this.TabConfig2 = new System.Windows.Forms.TabControl();
            this.TabIterations = new System.Windows.Forms.TabPage();
            this.TxtObjectRecordset = new System.Windows.Forms.TextBox();
            this.RdbIterateObjectRecordset = new System.Windows.Forms.RadioButton();
            this.TxtIterationsNumber = new System.Windows.Forms.TextBox();
            this.RdbIteratesExactNumber = new System.Windows.Forms.RadioButton();
            this.RdbIteratesDefaultRecordset = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrProvider)).BeginInit();
            this.TabConfig2.SuspendLayout();
            this.TabIterations.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(415, 544);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(496, 544);
            // 
            // TabConfig2
            // 
            this.TabConfig2.Controls.Add(this.TabIterations);
            this.TabConfig2.Location = new System.Drawing.Point(12, 82);
            this.TabConfig2.Name = "TabConfig2";
            this.TabConfig2.SelectedIndex = 0;
            this.TabConfig2.Size = new System.Drawing.Size(563, 441);
            this.TabConfig2.TabIndex = 6;
            // 
            // TabIterations
            // 
            this.TabIterations.Controls.Add(this.TxtObjectRecordset);
            this.TabIterations.Controls.Add(this.RdbIterateObjectRecordset);
            this.TabIterations.Controls.Add(this.TxtIterationsNumber);
            this.TabIterations.Controls.Add(this.RdbIteratesExactNumber);
            this.TabIterations.Controls.Add(this.RdbIteratesDefaultRecordset);
            this.TabIterations.Location = new System.Drawing.Point(4, 22);
            this.TabIterations.Name = "TabIterations";
            this.TabIterations.Padding = new System.Windows.Forms.Padding(3);
            this.TabIterations.Size = new System.Drawing.Size(555, 415);
            this.TabIterations.TabIndex = 2;
            this.TabIterations.Text = "Iterations";
            this.TabIterations.UseVisualStyleBackColor = true;
            // 
            // TxtObjectRecordset
            // 
            this.TxtObjectRecordset.Enabled = false;
            this.TxtObjectRecordset.Location = new System.Drawing.Point(366, 82);
            this.TxtObjectRecordset.MaxLength = 1000;
            this.TxtObjectRecordset.Name = "TxtObjectRecordset";
            this.TxtObjectRecordset.Size = new System.Drawing.Size(177, 20);
            this.TxtObjectRecordset.TabIndex = 4;
            // 
            // RdbIterateObjectRecordset
            // 
            this.RdbIterateObjectRecordset.Location = new System.Drawing.Point(16, 62);
            this.RdbIterateObjectRecordset.Name = "RdbIterateObjectRecordset";
            this.RdbIterateObjectRecordset.Size = new System.Drawing.Size(344, 59);
            this.RdbIterateObjectRecordset.TabIndex = 3;
            this.RdbIterateObjectRecordset.Text = "Iterates as many times as the records contained here (write in the format {Object" +
    "ID.FieldName})";
            this.RdbIterateObjectRecordset.UseVisualStyleBackColor = true;
            this.RdbIterateObjectRecordset.CheckedChanged += new System.EventHandler(this.RdbIterateObjectRecordset_CheckedChanged);
            // 
            // TxtIterationsNumber
            // 
            this.TxtIterationsNumber.Enabled = false;
            this.TxtIterationsNumber.Location = new System.Drawing.Point(366, 137);
            this.TxtIterationsNumber.MaxLength = 5;
            this.TxtIterationsNumber.Name = "TxtIterationsNumber";
            this.TxtIterationsNumber.Size = new System.Drawing.Size(70, 20);
            this.TxtIterationsNumber.TabIndex = 2;
            this.TxtIterationsNumber.Text = "1";
            // 
            // RdbIteratesExactNumber
            // 
            this.RdbIteratesExactNumber.Location = new System.Drawing.Point(16, 127);
            this.RdbIteratesExactNumber.Name = "RdbIteratesExactNumber";
            this.RdbIteratesExactNumber.Size = new System.Drawing.Size(199, 38);
            this.RdbIteratesExactNumber.TabIndex = 1;
            this.RdbIteratesExactNumber.Text = "Iterates this exact number of times";
            this.RdbIteratesExactNumber.UseVisualStyleBackColor = true;
            this.RdbIteratesExactNumber.CheckedChanged += new System.EventHandler(this.RdbIteratesExactNumber_CheckedChanged);
            // 
            // RdbIteratesDefaultRecordset
            // 
            this.RdbIteratesDefaultRecordset.Checked = true;
            this.RdbIteratesDefaultRecordset.Location = new System.Drawing.Point(16, 18);
            this.RdbIteratesDefaultRecordset.Name = "RdbIteratesDefaultRecordset";
            this.RdbIteratesDefaultRecordset.Size = new System.Drawing.Size(527, 38);
            this.RdbIteratesDefaultRecordset.TabIndex = 0;
            this.RdbIteratesDefaultRecordset.TabStop = true;
            this.RdbIteratesDefaultRecordset.Text = "Iterates as many times as the records contained in the default recordset of the p" +
    "revious task, or 1 if no default recordset exists";
            this.RdbIteratesDefaultRecordset.UseVisualStyleBackColor = true;
            this.RdbIteratesDefaultRecordset.CheckedChanged += new System.EventHandler(this.RdbIteratesDefaultRecordset_CheckedChanged);
            // 
            // WndPluginTaskConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 579);
            this.Controls.Add(this.TabConfig2);
            this.Name = "WndPluginTaskConfig";
            this.Text = "WndPluginTaskConfig";
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.BtnCancel, 0);
            this.Controls.SetChildIndex(this.BtnSave, 0);
            this.Controls.SetChildIndex(this.TabConfig2, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrProvider)).EndInit();
            this.TabConfig2.ResumeLayout(false);
            this.TabIterations.ResumeLayout(false);
            this.TabIterations.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabPage TabIterations;
        private System.Windows.Forms.TextBox TxtIterationsNumber;
        private System.Windows.Forms.RadioButton RdbIteratesExactNumber;
        private System.Windows.Forms.RadioButton RdbIteratesDefaultRecordset;
        protected System.Windows.Forms.TabControl TabConfig2;
        private System.Windows.Forms.RadioButton RdbIterateObjectRecordset;
        private System.Windows.Forms.TextBox TxtObjectRecordset;
    }
}