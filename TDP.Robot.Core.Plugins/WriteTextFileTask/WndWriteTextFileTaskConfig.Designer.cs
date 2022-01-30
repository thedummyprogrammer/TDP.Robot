
namespace TDP.Robot.Plugins.Core.WriteTextFileTask
{
    partial class WndWriteTextFileTaskConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WndWriteTextFileTaskConfig));
            this.TabGeneral = new System.Windows.Forms.TabPage();
            this.BtnDynDataFilePathName = new System.Windows.Forms.Button();
            this.BtnBrowseFile = new System.Windows.Forms.Button();
            this.TxtFilePathName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ChkFormatDelimited = new System.Windows.Forms.CheckBox();
            this.GrpDelimiters = new System.Windows.Forms.GroupBox();
            this.ChkUseDoubleQuotes = new System.Windows.Forms.CheckBox();
            this.TxtDelOther = new System.Windows.Forms.TextBox();
            this.ChkDelOther = new System.Windows.Forms.CheckBox();
            this.ChkDelSpace = new System.Windows.Forms.CheckBox();
            this.ChkDelComma = new System.Windows.Forms.CheckBox();
            this.ChkDelSemicolon = new System.Windows.Forms.CheckBox();
            this.ChkDelTab = new System.Windows.Forms.CheckBox();
            this.ChkFormatFixedLength = new System.Windows.Forms.CheckBox();
            this.CmbTaskType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnDynDataInsertAtRow = new System.Windows.Forms.Button();
            this.ChkAddHeader = new System.Windows.Forms.CheckBox();
            this.TxtInsertAtRow = new System.Windows.Forms.TextBox();
            this.LblInsertAtRow = new System.Windows.Forms.Label();
            this.BtnMoveDown = new System.Windows.Forms.Button();
            this.BtnMoveUp = new System.Windows.Forms.Button();
            this.BtnRemove = new System.Windows.Forms.Button();
            this.BtnEdit = new System.Windows.Forms.Button();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.LstColumns = new System.Windows.Forms.ListBox();
            this.TabConfig2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrProvider)).BeginInit();
            this.TabGeneral.SuspendLayout();
            this.GrpDelimiters.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabConfig2
            // 
            this.TabConfig2.Controls.Add(this.TabGeneral);
            this.TabConfig2.Size = new System.Drawing.Size(563, 537);
            this.TabConfig2.Controls.SetChildIndex(this.TabGeneral, 0);
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(415, 625);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(496, 625);
            // 
            // groupBox1
            // 
            this.groupBox1.Size = new System.Drawing.Size(559, 64);
            // 
            // TabGeneral
            // 
            this.TabGeneral.Controls.Add(this.BtnDynDataFilePathName);
            this.TabGeneral.Controls.Add(this.BtnBrowseFile);
            this.TabGeneral.Controls.Add(this.TxtFilePathName);
            this.TabGeneral.Controls.Add(this.label3);
            this.TabGeneral.Controls.Add(this.ChkFormatDelimited);
            this.TabGeneral.Controls.Add(this.GrpDelimiters);
            this.TabGeneral.Controls.Add(this.ChkFormatFixedLength);
            this.TabGeneral.Controls.Add(this.CmbTaskType);
            this.TabGeneral.Controls.Add(this.label2);
            this.TabGeneral.Controls.Add(this.BtnDynDataInsertAtRow);
            this.TabGeneral.Controls.Add(this.ChkAddHeader);
            this.TabGeneral.Controls.Add(this.TxtInsertAtRow);
            this.TabGeneral.Controls.Add(this.LblInsertAtRow);
            this.TabGeneral.Controls.Add(this.BtnMoveDown);
            this.TabGeneral.Controls.Add(this.BtnMoveUp);
            this.TabGeneral.Controls.Add(this.BtnRemove);
            this.TabGeneral.Controls.Add(this.BtnEdit);
            this.TabGeneral.Controls.Add(this.BtnAdd);
            this.TabGeneral.Controls.Add(this.label4);
            this.TabGeneral.Controls.Add(this.LstColumns);
            this.TabGeneral.Location = new System.Drawing.Point(4, 22);
            this.TabGeneral.Name = "TabGeneral";
            this.TabGeneral.Size = new System.Drawing.Size(555, 511);
            this.TabGeneral.TabIndex = 3;
            this.TabGeneral.Text = "General";
            this.TabGeneral.UseVisualStyleBackColor = true;
            // 
            // BtnDynDataFilePathName
            // 
            this.BtnDynDataFilePathName.Image = global::TDP.Robot.Plugins.Core.Resource.LightningAdd;
            this.BtnDynDataFilePathName.Location = new System.Drawing.Point(494, 64);
            this.BtnDynDataFilePathName.Name = "BtnDynDataFilePathName";
            this.BtnDynDataFilePathName.Size = new System.Drawing.Size(23, 21);
            this.BtnDynDataFilePathName.TabIndex = 55;
            this.BtnDynDataFilePathName.Text = "...";
            this.BtnDynDataFilePathName.UseVisualStyleBackColor = true;
            // 
            // BtnBrowseFile
            // 
            this.BtnBrowseFile.Location = new System.Drawing.Point(457, 64);
            this.BtnBrowseFile.Name = "BtnBrowseFile";
            this.BtnBrowseFile.Size = new System.Drawing.Size(31, 20);
            this.BtnBrowseFile.TabIndex = 54;
            this.BtnBrowseFile.Text = "...";
            this.BtnBrowseFile.UseVisualStyleBackColor = true;
            this.BtnBrowseFile.Click += new System.EventHandler(this.BtnBrowseFile_Click);
            // 
            // TxtFilePathName
            // 
            this.TxtFilePathName.Location = new System.Drawing.Point(66, 64);
            this.TxtFilePathName.MaxLength = 1000;
            this.TxtFilePathName.Name = "TxtFilePathName";
            this.TxtFilePathName.Size = new System.Drawing.Size(387, 20);
            this.TxtFilePathName.TabIndex = 53;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 52;
            this.label3.Text = "File path";
            // 
            // ChkFormatDelimited
            // 
            this.ChkFormatDelimited.AutoSize = true;
            this.ChkFormatDelimited.Location = new System.Drawing.Point(16, 276);
            this.ChkFormatDelimited.Name = "ChkFormatDelimited";
            this.ChkFormatDelimited.Size = new System.Drawing.Size(141, 17);
            this.ChkFormatDelimited.TabIndex = 49;
            this.ChkFormatDelimited.Text = "Format as a delimited file";
            this.ChkFormatDelimited.UseVisualStyleBackColor = true;
            this.ChkFormatDelimited.CheckedChanged += new System.EventHandler(this.ChkFormatDelimited_CheckedChanged);
            // 
            // GrpDelimiters
            // 
            this.GrpDelimiters.Controls.Add(this.ChkUseDoubleQuotes);
            this.GrpDelimiters.Controls.Add(this.TxtDelOther);
            this.GrpDelimiters.Controls.Add(this.ChkDelOther);
            this.GrpDelimiters.Controls.Add(this.ChkDelSpace);
            this.GrpDelimiters.Controls.Add(this.ChkDelComma);
            this.GrpDelimiters.Controls.Add(this.ChkDelSemicolon);
            this.GrpDelimiters.Controls.Add(this.ChkDelTab);
            this.GrpDelimiters.Enabled = false;
            this.GrpDelimiters.Location = new System.Drawing.Point(16, 299);
            this.GrpDelimiters.Name = "GrpDelimiters";
            this.GrpDelimiters.Size = new System.Drawing.Size(526, 94);
            this.GrpDelimiters.TabIndex = 50;
            this.GrpDelimiters.TabStop = false;
            this.GrpDelimiters.Text = "Delimiters";
            // 
            // ChkUseDoubleQuotes
            // 
            this.ChkUseDoubleQuotes.AutoSize = true;
            this.ChkUseDoubleQuotes.Location = new System.Drawing.Point(12, 71);
            this.ChkUseDoubleQuotes.Name = "ChkUseDoubleQuotes";
            this.ChkUseDoubleQuotes.Size = new System.Drawing.Size(165, 17);
            this.ChkUseDoubleQuotes.TabIndex = 6;
            this.ChkUseDoubleQuotes.Text = "Enclose text in double quotes";
            this.ChkUseDoubleQuotes.UseVisualStyleBackColor = true;
            // 
            // TxtDelOther
            // 
            this.TxtDelOther.Location = new System.Drawing.Point(257, 17);
            this.TxtDelOther.MaxLength = 1;
            this.TxtDelOther.Name = "TxtDelOther";
            this.TxtDelOther.Size = new System.Drawing.Size(36, 20);
            this.TxtDelOther.TabIndex = 5;
            // 
            // ChkDelOther
            // 
            this.ChkDelOther.AutoSize = true;
            this.ChkDelOther.Location = new System.Drawing.Point(201, 19);
            this.ChkDelOther.Name = "ChkDelOther";
            this.ChkDelOther.Size = new System.Drawing.Size(52, 17);
            this.ChkDelOther.TabIndex = 4;
            this.ChkDelOther.Text = "Other";
            this.ChkDelOther.UseVisualStyleBackColor = true;
            // 
            // ChkDelSpace
            // 
            this.ChkDelSpace.AutoSize = true;
            this.ChkDelSpace.Location = new System.Drawing.Point(114, 42);
            this.ChkDelSpace.Name = "ChkDelSpace";
            this.ChkDelSpace.Size = new System.Drawing.Size(57, 17);
            this.ChkDelSpace.TabIndex = 3;
            this.ChkDelSpace.Text = "Space";
            this.ChkDelSpace.UseVisualStyleBackColor = true;
            // 
            // ChkDelComma
            // 
            this.ChkDelComma.AutoSize = true;
            this.ChkDelComma.Location = new System.Drawing.Point(114, 19);
            this.ChkDelComma.Name = "ChkDelComma";
            this.ChkDelComma.Size = new System.Drawing.Size(61, 17);
            this.ChkDelComma.TabIndex = 2;
            this.ChkDelComma.Text = "Comma";
            this.ChkDelComma.UseVisualStyleBackColor = true;
            // 
            // ChkDelSemicolon
            // 
            this.ChkDelSemicolon.AutoSize = true;
            this.ChkDelSemicolon.Location = new System.Drawing.Point(12, 42);
            this.ChkDelSemicolon.Name = "ChkDelSemicolon";
            this.ChkDelSemicolon.Size = new System.Drawing.Size(75, 17);
            this.ChkDelSemicolon.TabIndex = 1;
            this.ChkDelSemicolon.Text = "Semicolon";
            this.ChkDelSemicolon.UseVisualStyleBackColor = true;
            // 
            // ChkDelTab
            // 
            this.ChkDelTab.AutoSize = true;
            this.ChkDelTab.Location = new System.Drawing.Point(12, 19);
            this.ChkDelTab.Name = "ChkDelTab";
            this.ChkDelTab.Size = new System.Drawing.Size(45, 17);
            this.ChkDelTab.TabIndex = 0;
            this.ChkDelTab.Text = "Tab";
            this.ChkDelTab.UseVisualStyleBackColor = true;
            // 
            // ChkFormatFixedLength
            // 
            this.ChkFormatFixedLength.AutoSize = true;
            this.ChkFormatFixedLength.Location = new System.Drawing.Point(16, 403);
            this.ChkFormatFixedLength.Name = "ChkFormatFixedLength";
            this.ChkFormatFixedLength.Size = new System.Drawing.Size(196, 17);
            this.ChkFormatFixedLength.TabIndex = 51;
            this.ChkFormatFixedLength.Text = "Format as a fixed length columns file";
            this.ChkFormatFixedLength.UseVisualStyleBackColor = true;
            this.ChkFormatFixedLength.CheckedChanged += new System.EventHandler(this.ChkFormatFixedLength_CheckedChanged);
            // 
            // CmbTaskType
            // 
            this.CmbTaskType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbTaskType.FormattingEnabled = true;
            this.CmbTaskType.Location = new System.Drawing.Point(66, 14);
            this.CmbTaskType.Name = "CmbTaskType";
            this.CmbTaskType.Size = new System.Drawing.Size(228, 21);
            this.CmbTaskType.TabIndex = 48;
            this.CmbTaskType.SelectedIndexChanged += new System.EventHandler(this.CmbTaskType_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 47;
            this.label2.Text = "Type";
            // 
            // BtnDynDataInsertAtRow
            // 
            this.BtnDynDataInsertAtRow.Image = global::TDP.Robot.Plugins.Core.Resource.LightningAdd;
            this.BtnDynDataInsertAtRow.Location = new System.Drawing.Point(189, 463);
            this.BtnDynDataInsertAtRow.Name = "BtnDynDataInsertAtRow";
            this.BtnDynDataInsertAtRow.Size = new System.Drawing.Size(23, 21);
            this.BtnDynDataInsertAtRow.TabIndex = 46;
            this.BtnDynDataInsertAtRow.Text = "...";
            this.BtnDynDataInsertAtRow.UseVisualStyleBackColor = true;
            // 
            // ChkAddHeader
            // 
            this.ChkAddHeader.AutoSize = true;
            this.ChkAddHeader.Location = new System.Drawing.Point(16, 426);
            this.ChkAddHeader.Name = "ChkAddHeader";
            this.ChkAddHeader.Size = new System.Drawing.Size(146, 17);
            this.ChkAddHeader.TabIndex = 45;
            this.ChkAddHeader.Text = "Add header if file is empty";
            this.ChkAddHeader.UseVisualStyleBackColor = true;
            // 
            // TxtInsertAtRow
            // 
            this.TxtInsertAtRow.Location = new System.Drawing.Point(83, 464);
            this.TxtInsertAtRow.MaxLength = 1000;
            this.TxtInsertAtRow.Name = "TxtInsertAtRow";
            this.TxtInsertAtRow.Size = new System.Drawing.Size(100, 20);
            this.TxtInsertAtRow.TabIndex = 44;
            // 
            // LblInsertAtRow
            // 
            this.LblInsertAtRow.AutoSize = true;
            this.LblInsertAtRow.Location = new System.Drawing.Point(12, 467);
            this.LblInsertAtRow.Name = "LblInsertAtRow";
            this.LblInsertAtRow.Size = new System.Drawing.Size(65, 13);
            this.LblInsertAtRow.TabIndex = 43;
            this.LblInsertAtRow.Text = "Insert at row";
            // 
            // BtnMoveDown
            // 
            this.BtnMoveDown.Location = new System.Drawing.Point(457, 236);
            this.BtnMoveDown.Name = "BtnMoveDown";
            this.BtnMoveDown.Size = new System.Drawing.Size(86, 23);
            this.BtnMoveDown.TabIndex = 42;
            this.BtnMoveDown.Text = "Move down";
            this.BtnMoveDown.UseVisualStyleBackColor = true;
            this.BtnMoveDown.Click += new System.EventHandler(this.BtnMoveDown_Click);
            // 
            // BtnMoveUp
            // 
            this.BtnMoveUp.Location = new System.Drawing.Point(457, 210);
            this.BtnMoveUp.Name = "BtnMoveUp";
            this.BtnMoveUp.Size = new System.Drawing.Size(86, 23);
            this.BtnMoveUp.TabIndex = 41;
            this.BtnMoveUp.Text = "Move up";
            this.BtnMoveUp.UseVisualStyleBackColor = true;
            this.BtnMoveUp.Click += new System.EventHandler(this.BtnMoveUp_Click);
            // 
            // BtnRemove
            // 
            this.BtnRemove.Location = new System.Drawing.Point(457, 171);
            this.BtnRemove.Name = "BtnRemove";
            this.BtnRemove.Size = new System.Drawing.Size(86, 23);
            this.BtnRemove.TabIndex = 40;
            this.BtnRemove.Text = "Remove";
            this.BtnRemove.UseVisualStyleBackColor = true;
            this.BtnRemove.Click += new System.EventHandler(this.BtnRemove_Click);
            // 
            // BtnEdit
            // 
            this.BtnEdit.Location = new System.Drawing.Point(457, 142);
            this.BtnEdit.Name = "BtnEdit";
            this.BtnEdit.Size = new System.Drawing.Size(86, 23);
            this.BtnEdit.TabIndex = 39;
            this.BtnEdit.Text = "Edit...";
            this.BtnEdit.UseVisualStyleBackColor = true;
            this.BtnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
            // 
            // BtnAdd
            // 
            this.BtnAdd.Location = new System.Drawing.Point(457, 113);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(86, 23);
            this.BtnAdd.TabIndex = 38;
            this.BtnAdd.Text = "Add...";
            this.BtnAdd.UseVisualStyleBackColor = true;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 37;
            this.label4.Text = "Fields definition";
            // 
            // LstColumns
            // 
            this.LstColumns.FormattingEnabled = true;
            this.LstColumns.Location = new System.Drawing.Point(16, 113);
            this.LstColumns.Name = "LstColumns";
            this.LstColumns.Size = new System.Drawing.Size(436, 147);
            this.LstColumns.TabIndex = 36;
            this.LstColumns.DoubleClick += new System.EventHandler(this.LstColumns_DoubleClick);
            // 
            // WndWriteTextFileTaskConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 655);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WndWriteTextFileTaskConfig";
            this.Text = "Write text file configuration";
            this.TabConfig2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrProvider)).EndInit();
            this.TabGeneral.ResumeLayout(false);
            this.TabGeneral.PerformLayout();
            this.GrpDelimiters.ResumeLayout(false);
            this.GrpDelimiters.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage TabGeneral;
        private System.Windows.Forms.Button BtnDynDataInsertAtRow;
        private System.Windows.Forms.CheckBox ChkAddHeader;
        private System.Windows.Forms.TextBox TxtInsertAtRow;
        private System.Windows.Forms.Label LblInsertAtRow;
        private System.Windows.Forms.Button BtnMoveDown;
        private System.Windows.Forms.Button BtnMoveUp;
        private System.Windows.Forms.Button BtnRemove;
        private System.Windows.Forms.Button BtnEdit;
        private System.Windows.Forms.Button BtnAdd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox LstColumns;
        private System.Windows.Forms.ComboBox CmbTaskType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox ChkFormatDelimited;
        private System.Windows.Forms.GroupBox GrpDelimiters;
        private System.Windows.Forms.CheckBox ChkUseDoubleQuotes;
        private System.Windows.Forms.TextBox TxtDelOther;
        private System.Windows.Forms.CheckBox ChkDelOther;
        private System.Windows.Forms.CheckBox ChkDelSpace;
        private System.Windows.Forms.CheckBox ChkDelComma;
        private System.Windows.Forms.CheckBox ChkDelSemicolon;
        private System.Windows.Forms.CheckBox ChkDelTab;
        private System.Windows.Forms.CheckBox ChkFormatFixedLength;
        private System.Windows.Forms.Button BtnDynDataFilePathName;
        private System.Windows.Forms.Button BtnBrowseFile;
        private System.Windows.Forms.TextBox TxtFilePathName;
        private System.Windows.Forms.Label label3;
    }
}