namespace TDP.Robot.Plugins.Core.ExcelFileTask
{
    partial class WndExcelFileTaskConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WndExcelFileTaskConfig));
            this.TabGeneral = new System.Windows.Forms.TabPage();
            this.CmbTaskType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.GrpProperties = new System.Windows.Forms.GroupBox();
            this.GrpInsertAppend = new System.Windows.Forms.GroupBox();
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
            this.BtnDynDataSheetName = new System.Windows.Forms.Button();
            this.BtnDynDataFilePathName = new System.Windows.Forms.Button();
            this.TxtSheetName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.BtnBrowseFile = new System.Windows.Forms.Button();
            this.TxtFilePathName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.GrpFind = new System.Windows.Forms.GroupBox();
            this.BtnDynDataReplaceWith = new System.Windows.Forms.Button();
            this.BtnDynDataFindText = new System.Windows.Forms.Button();
            this.TxtReplaceWith = new System.Windows.Forms.TextBox();
            this.LblReplaceWith = new System.Windows.Forms.Label();
            this.TxtFindText = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.GrpRead = new System.Windows.Forms.GroupBox();
            this.BtnDynDataNumColumnsToRead = new System.Windows.Forms.Button();
            this.BtnDynDataReadToRow = new System.Windows.Forms.Button();
            this.BtnDynDataReadFromRow = new System.Windows.Forms.Button();
            this.BtnDynDataNumberOfRows = new System.Windows.Forms.Button();
            this.BtnDynDataReadRowNumber = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.TxtNumColumnsToRead = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.LblNumberOfRows = new System.Windows.Forms.Label();
            this.TxtNumberOfRows = new System.Windows.Forms.TextBox();
            this.LblReadToRow = new System.Windows.Forms.Label();
            this.TxtReadToRow = new System.Windows.Forms.TextBox();
            this.LblReadFromRow = new System.Windows.Forms.Label();
            this.TxtReadFromRow = new System.Windows.Forms.TextBox();
            this.CmbReadIntervalType = new System.Windows.Forms.ComboBox();
            this.RdbReadInterval = new System.Windows.Forms.RadioButton();
            this.TxtReadRowNumber = new System.Windows.Forms.TextBox();
            this.RdbReadRowNumber = new System.Windows.Forms.RadioButton();
            this.RdbReadLastRow = new System.Windows.Forms.RadioButton();
            this.GrpDelete = new System.Windows.Forms.GroupBox();
            this.BtnDynDataDeleteRowNumber = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.TxtDeleteRowNumber = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.TabConfig2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrProvider)).BeginInit();
            this.TabGeneral.SuspendLayout();
            this.GrpProperties.SuspendLayout();
            this.GrpInsertAppend.SuspendLayout();
            this.GrpFind.SuspendLayout();
            this.GrpRead.SuspendLayout();
            this.GrpDelete.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabConfig2
            // 
            this.TabConfig2.Controls.Add(this.TabGeneral);
            this.TabConfig2.Size = new System.Drawing.Size(563, 413);
            this.TabConfig2.Controls.SetChildIndex(this.TabGeneral, 0);
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(419, 501);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(500, 501);
            // 
            // TabGeneral
            // 
            this.TabGeneral.Controls.Add(this.CmbTaskType);
            this.TabGeneral.Controls.Add(this.label2);
            this.TabGeneral.Controls.Add(this.GrpProperties);
            this.TabGeneral.Location = new System.Drawing.Point(4, 22);
            this.TabGeneral.Name = "TabGeneral";
            this.TabGeneral.Size = new System.Drawing.Size(555, 387);
            this.TabGeneral.TabIndex = 3;
            this.TabGeneral.Text = "General";
            this.TabGeneral.UseVisualStyleBackColor = true;
            // 
            // CmbTaskType
            // 
            this.CmbTaskType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbTaskType.FormattingEnabled = true;
            this.CmbTaskType.Location = new System.Drawing.Point(66, 13);
            this.CmbTaskType.Name = "CmbTaskType";
            this.CmbTaskType.Size = new System.Drawing.Size(228, 21);
            this.CmbTaskType.TabIndex = 1;
            this.CmbTaskType.SelectedIndexChanged += new System.EventHandler(this.CmbTaskType_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Type";
            // 
            // GrpProperties
            // 
            this.GrpProperties.Controls.Add(this.GrpInsertAppend);
            this.GrpProperties.Controls.Add(this.BtnDynDataSheetName);
            this.GrpProperties.Controls.Add(this.BtnDynDataFilePathName);
            this.GrpProperties.Controls.Add(this.TxtSheetName);
            this.GrpProperties.Controls.Add(this.label5);
            this.GrpProperties.Controls.Add(this.BtnBrowseFile);
            this.GrpProperties.Controls.Add(this.TxtFilePathName);
            this.GrpProperties.Controls.Add(this.label3);
            this.GrpProperties.Controls.Add(this.GrpFind);
            this.GrpProperties.Controls.Add(this.GrpRead);
            this.GrpProperties.Controls.Add(this.GrpDelete);
            this.GrpProperties.Location = new System.Drawing.Point(17, 40);
            this.GrpProperties.Name = "GrpProperties";
            this.GrpProperties.Size = new System.Drawing.Size(526, 337);
            this.GrpProperties.TabIndex = 2;
            this.GrpProperties.TabStop = false;
            this.GrpProperties.Text = "Properties";
            // 
            // GrpInsertAppend
            // 
            this.GrpInsertAppend.Controls.Add(this.BtnDynDataInsertAtRow);
            this.GrpInsertAppend.Controls.Add(this.ChkAddHeader);
            this.GrpInsertAppend.Controls.Add(this.TxtInsertAtRow);
            this.GrpInsertAppend.Controls.Add(this.LblInsertAtRow);
            this.GrpInsertAppend.Controls.Add(this.BtnMoveDown);
            this.GrpInsertAppend.Controls.Add(this.BtnMoveUp);
            this.GrpInsertAppend.Controls.Add(this.BtnRemove);
            this.GrpInsertAppend.Controls.Add(this.BtnEdit);
            this.GrpInsertAppend.Controls.Add(this.BtnAdd);
            this.GrpInsertAppend.Controls.Add(this.label4);
            this.GrpInsertAppend.Controls.Add(this.LstColumns);
            this.GrpInsertAppend.Location = new System.Drawing.Point(9, 74);
            this.GrpInsertAppend.Name = "GrpInsertAppend";
            this.GrpInsertAppend.Size = new System.Drawing.Size(503, 248);
            this.GrpInsertAppend.TabIndex = 4;
            this.GrpInsertAppend.TabStop = false;
            this.GrpInsertAppend.Text = "Insert / Append configuration";
            // 
            // BtnDynDataInsertAtRow
            // 
            this.BtnDynDataInsertAtRow.Image = global::TDP.Robot.Plugins.Core.Resource.LightningAdd;
            this.BtnDynDataInsertAtRow.Location = new System.Drawing.Point(183, 217);
            this.BtnDynDataInsertAtRow.Name = "BtnDynDataInsertAtRow";
            this.BtnDynDataInsertAtRow.Size = new System.Drawing.Size(23, 21);
            this.BtnDynDataInsertAtRow.TabIndex = 35;
            this.BtnDynDataInsertAtRow.Text = "...";
            this.BtnDynDataInsertAtRow.UseVisualStyleBackColor = true;
            // 
            // ChkAddHeader
            // 
            this.ChkAddHeader.AutoSize = true;
            this.ChkAddHeader.Location = new System.Drawing.Point(9, 176);
            this.ChkAddHeader.Name = "ChkAddHeader";
            this.ChkAddHeader.Size = new System.Drawing.Size(146, 17);
            this.ChkAddHeader.TabIndex = 9;
            this.ChkAddHeader.Text = "Add header if file is empty";
            this.ChkAddHeader.UseVisualStyleBackColor = true;
            // 
            // TxtInsertAtRow
            // 
            this.TxtInsertAtRow.Location = new System.Drawing.Point(77, 218);
            this.TxtInsertAtRow.MaxLength = 1000;
            this.TxtInsertAtRow.Name = "TxtInsertAtRow";
            this.TxtInsertAtRow.Size = new System.Drawing.Size(100, 20);
            this.TxtInsertAtRow.TabIndex = 8;
            // 
            // LblInsertAtRow
            // 
            this.LblInsertAtRow.AutoSize = true;
            this.LblInsertAtRow.Location = new System.Drawing.Point(6, 221);
            this.LblInsertAtRow.Name = "LblInsertAtRow";
            this.LblInsertAtRow.Size = new System.Drawing.Size(65, 13);
            this.LblInsertAtRow.TabIndex = 7;
            this.LblInsertAtRow.Text = "Insert at row";
            // 
            // BtnMoveDown
            // 
            this.BtnMoveDown.Location = new System.Drawing.Point(411, 148);
            this.BtnMoveDown.Name = "BtnMoveDown";
            this.BtnMoveDown.Size = new System.Drawing.Size(86, 23);
            this.BtnMoveDown.TabIndex = 6;
            this.BtnMoveDown.Text = "Move down";
            this.BtnMoveDown.UseVisualStyleBackColor = true;
            this.BtnMoveDown.Click += new System.EventHandler(this.BtnMoveDown_Click);
            // 
            // BtnMoveUp
            // 
            this.BtnMoveUp.Location = new System.Drawing.Point(411, 122);
            this.BtnMoveUp.Name = "BtnMoveUp";
            this.BtnMoveUp.Size = new System.Drawing.Size(86, 23);
            this.BtnMoveUp.TabIndex = 5;
            this.BtnMoveUp.Text = "Move up";
            this.BtnMoveUp.UseVisualStyleBackColor = true;
            this.BtnMoveUp.Click += new System.EventHandler(this.BtnMoveUp_Click);
            // 
            // BtnRemove
            // 
            this.BtnRemove.Location = new System.Drawing.Point(411, 94);
            this.BtnRemove.Name = "BtnRemove";
            this.BtnRemove.Size = new System.Drawing.Size(86, 23);
            this.BtnRemove.TabIndex = 4;
            this.BtnRemove.Text = "Remove";
            this.BtnRemove.UseVisualStyleBackColor = true;
            this.BtnRemove.Click += new System.EventHandler(this.BtnRemove_Click);
            // 
            // BtnEdit
            // 
            this.BtnEdit.Location = new System.Drawing.Point(411, 65);
            this.BtnEdit.Name = "BtnEdit";
            this.BtnEdit.Size = new System.Drawing.Size(86, 23);
            this.BtnEdit.TabIndex = 3;
            this.BtnEdit.Text = "Edit...";
            this.BtnEdit.UseVisualStyleBackColor = true;
            this.BtnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
            // 
            // BtnAdd
            // 
            this.BtnAdd.Location = new System.Drawing.Point(411, 36);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(86, 23);
            this.BtnAdd.TabIndex = 2;
            this.BtnAdd.Text = "Add...";
            this.BtnAdd.UseVisualStyleBackColor = true;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Columns definition";
            // 
            // LstColumns
            // 
            this.LstColumns.FormattingEnabled = true;
            this.LstColumns.Location = new System.Drawing.Point(6, 36);
            this.LstColumns.Name = "LstColumns";
            this.LstColumns.Size = new System.Drawing.Size(399, 134);
            this.LstColumns.TabIndex = 0;
            this.LstColumns.DoubleClick += new System.EventHandler(this.LstColumns_DoubleClick);
            // 
            // BtnDynDataSheetName
            // 
            this.BtnDynDataSheetName.Image = global::TDP.Robot.Plugins.Core.Resource.LightningAdd;
            this.BtnDynDataSheetName.Location = new System.Drawing.Point(283, 51);
            this.BtnDynDataSheetName.Name = "BtnDynDataSheetName";
            this.BtnDynDataSheetName.Size = new System.Drawing.Size(23, 21);
            this.BtnDynDataSheetName.TabIndex = 35;
            this.BtnDynDataSheetName.Text = "...";
            this.BtnDynDataSheetName.UseVisualStyleBackColor = true;
            // 
            // BtnDynDataFilePathName
            // 
            this.BtnDynDataFilePathName.Image = global::TDP.Robot.Plugins.Core.Resource.LightningAdd;
            this.BtnDynDataFilePathName.Location = new System.Drawing.Point(489, 25);
            this.BtnDynDataFilePathName.Name = "BtnDynDataFilePathName";
            this.BtnDynDataFilePathName.Size = new System.Drawing.Size(23, 21);
            this.BtnDynDataFilePathName.TabIndex = 34;
            this.BtnDynDataFilePathName.Text = "...";
            this.BtnDynDataFilePathName.UseVisualStyleBackColor = true;
            // 
            // TxtSheetName
            // 
            this.TxtSheetName.Location = new System.Drawing.Point(75, 51);
            this.TxtSheetName.MaxLength = 31;
            this.TxtSheetName.Name = "TxtSheetName";
            this.TxtSheetName.Size = new System.Drawing.Size(202, 20);
            this.TxtSheetName.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Sheet name";
            // 
            // BtnBrowseFile
            // 
            this.BtnBrowseFile.Location = new System.Drawing.Point(452, 25);
            this.BtnBrowseFile.Name = "BtnBrowseFile";
            this.BtnBrowseFile.Size = new System.Drawing.Size(31, 20);
            this.BtnBrowseFile.TabIndex = 3;
            this.BtnBrowseFile.Text = "...";
            this.BtnBrowseFile.UseVisualStyleBackColor = true;
            this.BtnBrowseFile.Click += new System.EventHandler(this.TxtBrowseFile_Click);
            // 
            // TxtFilePathName
            // 
            this.TxtFilePathName.Location = new System.Drawing.Point(75, 25);
            this.TxtFilePathName.MaxLength = 1000;
            this.TxtFilePathName.Name = "TxtFilePathName";
            this.TxtFilePathName.Size = new System.Drawing.Size(370, 20);
            this.TxtFilePathName.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "File path";
            // 
            // GrpFind
            // 
            this.GrpFind.Controls.Add(this.BtnDynDataReplaceWith);
            this.GrpFind.Controls.Add(this.BtnDynDataFindText);
            this.GrpFind.Controls.Add(this.TxtReplaceWith);
            this.GrpFind.Controls.Add(this.LblReplaceWith);
            this.GrpFind.Controls.Add(this.TxtFindText);
            this.GrpFind.Controls.Add(this.label10);
            this.GrpFind.Location = new System.Drawing.Point(9, 74);
            this.GrpFind.Name = "GrpFind";
            this.GrpFind.Size = new System.Drawing.Size(503, 84);
            this.GrpFind.TabIndex = 9;
            this.GrpFind.TabStop = false;
            this.GrpFind.Text = "Find configuration";
            this.GrpFind.Visible = false;
            // 
            // BtnDynDataReplaceWith
            // 
            this.BtnDynDataReplaceWith.Image = global::TDP.Robot.Plugins.Core.Resource.LightningAdd;
            this.BtnDynDataReplaceWith.Location = new System.Drawing.Point(394, 45);
            this.BtnDynDataReplaceWith.Name = "BtnDynDataReplaceWith";
            this.BtnDynDataReplaceWith.Size = new System.Drawing.Size(23, 21);
            this.BtnDynDataReplaceWith.TabIndex = 36;
            this.BtnDynDataReplaceWith.Text = "...";
            this.BtnDynDataReplaceWith.UseVisualStyleBackColor = true;
            // 
            // BtnDynDataFindText
            // 
            this.BtnDynDataFindText.Image = global::TDP.Robot.Plugins.Core.Resource.LightningAdd;
            this.BtnDynDataFindText.Location = new System.Drawing.Point(394, 19);
            this.BtnDynDataFindText.Name = "BtnDynDataFindText";
            this.BtnDynDataFindText.Size = new System.Drawing.Size(23, 21);
            this.BtnDynDataFindText.TabIndex = 35;
            this.BtnDynDataFindText.Text = "...";
            this.BtnDynDataFindText.UseVisualStyleBackColor = true;
            // 
            // TxtReplaceWith
            // 
            this.TxtReplaceWith.Location = new System.Drawing.Point(116, 46);
            this.TxtReplaceWith.MaxLength = 1000;
            this.TxtReplaceWith.Name = "TxtReplaceWith";
            this.TxtReplaceWith.Size = new System.Drawing.Size(272, 20);
            this.TxtReplaceWith.TabIndex = 3;
            // 
            // LblReplaceWith
            // 
            this.LblReplaceWith.AutoSize = true;
            this.LblReplaceWith.Location = new System.Drawing.Point(41, 49);
            this.LblReplaceWith.Name = "LblReplaceWith";
            this.LblReplaceWith.Size = new System.Drawing.Size(69, 13);
            this.LblReplaceWith.TabIndex = 2;
            this.LblReplaceWith.Text = "Replace with";
            // 
            // TxtFindText
            // 
            this.TxtFindText.Location = new System.Drawing.Point(116, 20);
            this.TxtFindText.MaxLength = 1000;
            this.TxtFindText.Name = "TxtFindText";
            this.TxtFindText.Size = new System.Drawing.Size(272, 20);
            this.TxtFindText.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(63, 23);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Find text";
            // 
            // GrpRead
            // 
            this.GrpRead.Controls.Add(this.BtnDynDataNumColumnsToRead);
            this.GrpRead.Controls.Add(this.BtnDynDataReadToRow);
            this.GrpRead.Controls.Add(this.BtnDynDataReadFromRow);
            this.GrpRead.Controls.Add(this.BtnDynDataNumberOfRows);
            this.GrpRead.Controls.Add(this.BtnDynDataReadRowNumber);
            this.GrpRead.Controls.Add(this.label7);
            this.GrpRead.Controls.Add(this.TxtNumColumnsToRead);
            this.GrpRead.Controls.Add(this.label6);
            this.GrpRead.Controls.Add(this.LblNumberOfRows);
            this.GrpRead.Controls.Add(this.TxtNumberOfRows);
            this.GrpRead.Controls.Add(this.LblReadToRow);
            this.GrpRead.Controls.Add(this.TxtReadToRow);
            this.GrpRead.Controls.Add(this.LblReadFromRow);
            this.GrpRead.Controls.Add(this.TxtReadFromRow);
            this.GrpRead.Controls.Add(this.CmbReadIntervalType);
            this.GrpRead.Controls.Add(this.RdbReadInterval);
            this.GrpRead.Controls.Add(this.TxtReadRowNumber);
            this.GrpRead.Controls.Add(this.RdbReadRowNumber);
            this.GrpRead.Controls.Add(this.RdbReadLastRow);
            this.GrpRead.Location = new System.Drawing.Point(9, 75);
            this.GrpRead.Name = "GrpRead";
            this.GrpRead.Size = new System.Drawing.Size(503, 211);
            this.GrpRead.TabIndex = 7;
            this.GrpRead.TabStop = false;
            this.GrpRead.Text = "Read configuration";
            this.GrpRead.Visible = false;
            // 
            // BtnDynDataNumColumnsToRead
            // 
            this.BtnDynDataNumColumnsToRead.Image = global::TDP.Robot.Plugins.Core.Resource.LightningAdd;
            this.BtnDynDataNumColumnsToRead.Location = new System.Drawing.Point(238, 155);
            this.BtnDynDataNumColumnsToRead.Name = "BtnDynDataNumColumnsToRead";
            this.BtnDynDataNumColumnsToRead.Size = new System.Drawing.Size(23, 21);
            this.BtnDynDataNumColumnsToRead.TabIndex = 40;
            this.BtnDynDataNumColumnsToRead.Text = "...";
            this.BtnDynDataNumColumnsToRead.UseVisualStyleBackColor = true;
            // 
            // BtnDynDataReadToRow
            // 
            this.BtnDynDataReadToRow.Enabled = false;
            this.BtnDynDataReadToRow.Image = global::TDP.Robot.Plugins.Core.Resource.LightningAdd;
            this.BtnDynDataReadToRow.Location = new System.Drawing.Point(238, 127);
            this.BtnDynDataReadToRow.Name = "BtnDynDataReadToRow";
            this.BtnDynDataReadToRow.Size = new System.Drawing.Size(23, 21);
            this.BtnDynDataReadToRow.TabIndex = 39;
            this.BtnDynDataReadToRow.Text = "...";
            this.BtnDynDataReadToRow.UseVisualStyleBackColor = true;
            // 
            // BtnDynDataReadFromRow
            // 
            this.BtnDynDataReadFromRow.Enabled = false;
            this.BtnDynDataReadFromRow.Image = global::TDP.Robot.Plugins.Core.Resource.LightningAdd;
            this.BtnDynDataReadFromRow.Location = new System.Drawing.Point(238, 100);
            this.BtnDynDataReadFromRow.Name = "BtnDynDataReadFromRow";
            this.BtnDynDataReadFromRow.Size = new System.Drawing.Size(23, 21);
            this.BtnDynDataReadFromRow.TabIndex = 38;
            this.BtnDynDataReadFromRow.Text = "...";
            this.BtnDynDataReadFromRow.UseVisualStyleBackColor = true;
            // 
            // BtnDynDataNumberOfRows
            // 
            this.BtnDynDataNumberOfRows.Enabled = false;
            this.BtnDynDataNumberOfRows.Image = global::TDP.Robot.Plugins.Core.Resource.LightningAdd;
            this.BtnDynDataNumberOfRows.Location = new System.Drawing.Point(474, 100);
            this.BtnDynDataNumberOfRows.Name = "BtnDynDataNumberOfRows";
            this.BtnDynDataNumberOfRows.Size = new System.Drawing.Size(23, 21);
            this.BtnDynDataNumberOfRows.TabIndex = 37;
            this.BtnDynDataNumberOfRows.Text = "...";
            this.BtnDynDataNumberOfRows.UseVisualStyleBackColor = true;
            // 
            // BtnDynDataReadRowNumber
            // 
            this.BtnDynDataReadRowNumber.Enabled = false;
            this.BtnDynDataReadRowNumber.Image = global::TDP.Robot.Plugins.Core.Resource.LightningAdd;
            this.BtnDynDataReadRowNumber.Location = new System.Drawing.Point(238, 51);
            this.BtnDynDataReadRowNumber.Name = "BtnDynDataReadRowNumber";
            this.BtnDynDataReadRowNumber.Size = new System.Drawing.Size(23, 21);
            this.BtnDynDataReadRowNumber.TabIndex = 36;
            this.BtnDynDataReadRowNumber.Text = "...";
            this.BtnDynDataReadRowNumber.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(270, 156);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(165, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "(Leave empty to read all columns)";
            // 
            // TxtNumColumnsToRead
            // 
            this.TxtNumColumnsToRead.Location = new System.Drawing.Point(132, 156);
            this.TxtNumColumnsToRead.MaxLength = 1000;
            this.TxtNumColumnsToRead.Name = "TxtNumColumnsToRead";
            this.TxtNumColumnsToRead.Size = new System.Drawing.Size(100, 20);
            this.TxtNumColumnsToRead.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 156);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(122, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Num. of columns to read";
            // 
            // LblNumberOfRows
            // 
            this.LblNumberOfRows.AutoSize = true;
            this.LblNumberOfRows.Location = new System.Drawing.Point(281, 104);
            this.LblNumberOfRows.Name = "LblNumberOfRows";
            this.LblNumberOfRows.Size = new System.Drawing.Size(81, 13);
            this.LblNumberOfRows.TabIndex = 10;
            this.LblNumberOfRows.Text = "Number of rows";
            // 
            // TxtNumberOfRows
            // 
            this.TxtNumberOfRows.Enabled = false;
            this.TxtNumberOfRows.Location = new System.Drawing.Point(368, 101);
            this.TxtNumberOfRows.MaxLength = 1000;
            this.TxtNumberOfRows.Name = "TxtNumberOfRows";
            this.TxtNumberOfRows.Size = new System.Drawing.Size(100, 20);
            this.TxtNumberOfRows.TabIndex = 9;
            // 
            // LblReadToRow
            // 
            this.LblReadToRow.AutoSize = true;
            this.LblReadToRow.Location = new System.Drawing.Point(86, 127);
            this.LblReadToRow.Name = "LblReadToRow";
            this.LblReadToRow.Size = new System.Drawing.Size(40, 13);
            this.LblReadToRow.TabIndex = 8;
            this.LblReadToRow.Text = "To row";
            // 
            // TxtReadToRow
            // 
            this.TxtReadToRow.Enabled = false;
            this.TxtReadToRow.Location = new System.Drawing.Point(132, 127);
            this.TxtReadToRow.MaxLength = 1000;
            this.TxtReadToRow.Name = "TxtReadToRow";
            this.TxtReadToRow.Size = new System.Drawing.Size(100, 20);
            this.TxtReadToRow.TabIndex = 7;
            // 
            // LblReadFromRow
            // 
            this.LblReadFromRow.AutoSize = true;
            this.LblReadFromRow.Location = new System.Drawing.Point(76, 104);
            this.LblReadFromRow.Name = "LblReadFromRow";
            this.LblReadFromRow.Size = new System.Drawing.Size(50, 13);
            this.LblReadFromRow.TabIndex = 6;
            this.LblReadFromRow.Text = "From row";
            // 
            // TxtReadFromRow
            // 
            this.TxtReadFromRow.Enabled = false;
            this.TxtReadFromRow.Location = new System.Drawing.Point(132, 101);
            this.TxtReadFromRow.MaxLength = 1000;
            this.TxtReadFromRow.Name = "TxtReadFromRow";
            this.TxtReadFromRow.Size = new System.Drawing.Size(100, 20);
            this.TxtReadFromRow.TabIndex = 5;
            // 
            // CmbReadIntervalType
            // 
            this.CmbReadIntervalType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbReadIntervalType.Enabled = false;
            this.CmbReadIntervalType.FormattingEnabled = true;
            this.CmbReadIntervalType.Location = new System.Drawing.Point(132, 74);
            this.CmbReadIntervalType.Name = "CmbReadIntervalType";
            this.CmbReadIntervalType.Size = new System.Drawing.Size(304, 21);
            this.CmbReadIntervalType.TabIndex = 4;
            this.CmbReadIntervalType.SelectedIndexChanged += new System.EventHandler(this.CmbReadIntervalType_SelectedIndexChanged);
            // 
            // RdbReadInterval
            // 
            this.RdbReadInterval.AutoSize = true;
            this.RdbReadInterval.Location = new System.Drawing.Point(17, 75);
            this.RdbReadInterval.Name = "RdbReadInterval";
            this.RdbReadInterval.Size = new System.Drawing.Size(103, 17);
            this.RdbReadInterval.TabIndex = 3;
            this.RdbReadInterval.Text = "Read an interval";
            this.RdbReadInterval.UseVisualStyleBackColor = true;
            this.RdbReadInterval.CheckedChanged += new System.EventHandler(this.RdbReadInterval_CheckedChanged);
            // 
            // TxtReadRowNumber
            // 
            this.TxtReadRowNumber.Enabled = false;
            this.TxtReadRowNumber.Location = new System.Drawing.Point(132, 51);
            this.TxtReadRowNumber.MaxLength = 1000;
            this.TxtReadRowNumber.Name = "TxtReadRowNumber";
            this.TxtReadRowNumber.Size = new System.Drawing.Size(100, 20);
            this.TxtReadRowNumber.TabIndex = 2;
            // 
            // RdbReadRowNumber
            // 
            this.RdbReadRowNumber.AutoSize = true;
            this.RdbReadRowNumber.Location = new System.Drawing.Point(17, 52);
            this.RdbReadRowNumber.Name = "RdbReadRowNumber";
            this.RdbReadRowNumber.Size = new System.Drawing.Size(109, 17);
            this.RdbReadRowNumber.TabIndex = 1;
            this.RdbReadRowNumber.Text = "Read row number";
            this.RdbReadRowNumber.UseVisualStyleBackColor = true;
            this.RdbReadRowNumber.CheckedChanged += new System.EventHandler(this.RdbReadRowNumber_CheckedChanged);
            // 
            // RdbReadLastRow
            // 
            this.RdbReadLastRow.AutoSize = true;
            this.RdbReadLastRow.Checked = true;
            this.RdbReadLastRow.Location = new System.Drawing.Point(17, 29);
            this.RdbReadLastRow.Name = "RdbReadLastRow";
            this.RdbReadLastRow.Size = new System.Drawing.Size(108, 17);
            this.RdbReadLastRow.TabIndex = 0;
            this.RdbReadLastRow.TabStop = true;
            this.RdbReadLastRow.Text = "Read the last row";
            this.RdbReadLastRow.UseVisualStyleBackColor = true;
            this.RdbReadLastRow.CheckedChanged += new System.EventHandler(this.RdbReadLastRow_CheckedChanged);
            // 
            // GrpDelete
            // 
            this.GrpDelete.Controls.Add(this.BtnDynDataDeleteRowNumber);
            this.GrpDelete.Controls.Add(this.label9);
            this.GrpDelete.Controls.Add(this.TxtDeleteRowNumber);
            this.GrpDelete.Controls.Add(this.label8);
            this.GrpDelete.Location = new System.Drawing.Point(9, 74);
            this.GrpDelete.Name = "GrpDelete";
            this.GrpDelete.Size = new System.Drawing.Size(503, 97);
            this.GrpDelete.TabIndex = 8;
            this.GrpDelete.TabStop = false;
            this.GrpDelete.Text = "Delete configuration";
            this.GrpDelete.Visible = false;
            // 
            // BtnDynDataDeleteRowNumber
            // 
            this.BtnDynDataDeleteRowNumber.Image = global::TDP.Robot.Plugins.Core.Resource.LightningAdd;
            this.BtnDynDataDeleteRowNumber.Location = new System.Drawing.Point(394, 23);
            this.BtnDynDataDeleteRowNumber.Name = "BtnDynDataDeleteRowNumber";
            this.BtnDynDataDeleteRowNumber.Size = new System.Drawing.Size(23, 21);
            this.BtnDynDataDeleteRowNumber.TabIndex = 36;
            this.BtnDynDataDeleteRowNumber.Text = "...";
            this.BtnDynDataDeleteRowNumber.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(116, 54);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(272, 35);
            this.label9.TabIndex = 10;
            this.label9.Text = "Enter line numbers or ranges separated by commas (example 1, 2, 3, 10-20)";
            // 
            // TxtDeleteRowNumber
            // 
            this.TxtDeleteRowNumber.Location = new System.Drawing.Point(116, 23);
            this.TxtDeleteRowNumber.MaxLength = 5000;
            this.TxtDeleteRowNumber.Name = "TxtDeleteRowNumber";
            this.TxtDeleteRowNumber.Size = new System.Drawing.Size(272, 20);
            this.TxtDeleteRowNumber.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Delete row number";
            // 
            // WndExcelFileTaskConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 535);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WndExcelFileTaskConfig";
            this.Text = "Excel file task configuration";
            this.TabConfig2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrProvider)).EndInit();
            this.TabGeneral.ResumeLayout(false);
            this.TabGeneral.PerformLayout();
            this.GrpProperties.ResumeLayout(false);
            this.GrpProperties.PerformLayout();
            this.GrpInsertAppend.ResumeLayout(false);
            this.GrpInsertAppend.PerformLayout();
            this.GrpFind.ResumeLayout(false);
            this.GrpFind.PerformLayout();
            this.GrpRead.ResumeLayout(false);
            this.GrpRead.PerformLayout();
            this.GrpDelete.ResumeLayout(false);
            this.GrpDelete.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage TabGeneral;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CmbTaskType;
        private System.Windows.Forms.GroupBox GrpProperties;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtFilePathName;
        private System.Windows.Forms.Button BtnBrowseFile;
        private System.Windows.Forms.GroupBox GrpInsertAppend;
        private System.Windows.Forms.ListBox LstColumns;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button BtnAdd;
        private System.Windows.Forms.Button BtnEdit;
        private System.Windows.Forms.Button BtnRemove;
        private System.Windows.Forms.Button BtnMoveUp;
        private System.Windows.Forms.Button BtnMoveDown;
        private System.Windows.Forms.Label LblInsertAtRow;
        private System.Windows.Forms.TextBox TxtInsertAtRow;
        private System.Windows.Forms.GroupBox GrpRead;
        private System.Windows.Forms.RadioButton RdbReadLastRow;
        private System.Windows.Forms.RadioButton RdbReadRowNumber;
        private System.Windows.Forms.TextBox TxtReadRowNumber;
        private System.Windows.Forms.RadioButton RdbReadInterval;
        private System.Windows.Forms.ComboBox CmbReadIntervalType;
        private System.Windows.Forms.TextBox TxtReadFromRow;
        private System.Windows.Forms.Label LblReadToRow;
        private System.Windows.Forms.TextBox TxtReadToRow;
        private System.Windows.Forms.Label LblReadFromRow;
        private System.Windows.Forms.GroupBox GrpDelete;
        private System.Windows.Forms.TextBox TxtDeleteRowNumber;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox GrpFind;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox TxtFindText;
        private System.Windows.Forms.TextBox TxtReplaceWith;
        private System.Windows.Forms.Label LblReplaceWith;
        private System.Windows.Forms.CheckBox ChkAddHeader;
        private System.Windows.Forms.Label LblNumberOfRows;
        private System.Windows.Forms.TextBox TxtNumberOfRows;
        private System.Windows.Forms.TextBox TxtSheetName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtNumColumnsToRead;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button BtnDynDataFilePathName;
        private System.Windows.Forms.Button BtnDynDataSheetName;
        private System.Windows.Forms.Button BtnDynDataNumColumnsToRead;
        private System.Windows.Forms.Button BtnDynDataReadToRow;
        private System.Windows.Forms.Button BtnDynDataReadFromRow;
        private System.Windows.Forms.Button BtnDynDataNumberOfRows;
        private System.Windows.Forms.Button BtnDynDataReadRowNumber;
        private System.Windows.Forms.Button BtnDynDataDeleteRowNumber;
        private System.Windows.Forms.Button BtnDynDataReplaceWith;
        private System.Windows.Forms.Button BtnDynDataFindText;
        private System.Windows.Forms.Button BtnDynDataInsertAtRow;
    }
}