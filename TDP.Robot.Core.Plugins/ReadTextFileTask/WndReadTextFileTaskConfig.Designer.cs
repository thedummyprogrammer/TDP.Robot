
namespace TDP.Robot.Plugins.Core.ReadTextFileTask
{
    partial class WndReadTextFileTaskConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WndReadTextFileTaskConfig));
            this.TabGeneral = new System.Windows.Forms.TabPage();
            this.GrpProperties = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.RdbReadAllTheRows = new System.Windows.Forms.RadioButton();
            this.BtnDynDataReadToRow = new System.Windows.Forms.Button();
            this.BtnDynDataReadFromRow = new System.Windows.Forms.Button();
            this.BtnDynDataNumberOfRows = new System.Windows.Forms.Button();
            this.BtnDynDataReadRowNumber = new System.Windows.Forms.Button();
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
            this.BtnDynDataFilePathName = new System.Windows.Forms.Button();
            this.BtnBrowseFile = new System.Windows.Forms.Button();
            this.TxtFilePathName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TabColumnsSplit = new System.Windows.Forms.TabPage();
            this.ChkSplitDelimiters = new System.Windows.Forms.CheckBox();
            this.GrpDelimiters = new System.Windows.Forms.GroupBox();
            this.ChkUseDoubleQuotes = new System.Windows.Forms.CheckBox();
            this.TxtDelOther = new System.Windows.Forms.TextBox();
            this.ChkDelOther = new System.Windows.Forms.CheckBox();
            this.ChkDelSpace = new System.Windows.Forms.CheckBox();
            this.ChkDelComma = new System.Windows.Forms.CheckBox();
            this.ChkDelSemicolon = new System.Windows.Forms.CheckBox();
            this.ChkDelTab = new System.Windows.Forms.CheckBox();
            this.ChkSplitUsingFixedLengthCols = new System.Windows.Forms.CheckBox();
            this.TabColumnsDefinition = new System.Windows.Forms.TabPage();
            this.GrpColumns = new System.Windows.Forms.GroupBox();
            this.BtnAutomaticCreation = new System.Windows.Forms.Button();
            this.BtnMoveDown = new System.Windows.Forms.Button();
            this.BtnMoveUp = new System.Windows.Forms.Button();
            this.BtnRemove = new System.Windows.Forms.Button();
            this.BtnEdit = new System.Windows.Forms.Button();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.LstColumns = new System.Windows.Forms.ListBox();
            this.ChkOverrideDefaultColumnDef = new System.Windows.Forms.CheckBox();
            this.ChkSkipFirstLine = new System.Windows.Forms.CheckBox();
            this.TabConfig2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrProvider)).BeginInit();
            this.TabGeneral.SuspendLayout();
            this.GrpProperties.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.TabColumnsSplit.SuspendLayout();
            this.GrpDelimiters.SuspendLayout();
            this.TabColumnsDefinition.SuspendLayout();
            this.GrpColumns.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabConfig2
            // 
            this.TabConfig2.Controls.Add(this.TabGeneral);
            this.TabConfig2.Controls.Add(this.TabColumnsSplit);
            this.TabConfig2.Controls.Add(this.TabColumnsDefinition);
            this.TabConfig2.Size = new System.Drawing.Size(563, 456);
            this.TabConfig2.TabIndex = 0;
            this.TabConfig2.Controls.SetChildIndex(this.TabColumnsDefinition, 0);
            this.TabConfig2.Controls.SetChildIndex(this.TabColumnsSplit, 0);
            this.TabConfig2.Controls.SetChildIndex(this.TabGeneral, 0);
            // 
            // groupBox1
            // 
            this.groupBox1.TabIndex = 0;
            // 
            // ChkDoNotLog
            // 
            this.ChkDoNotLog.TabIndex = 3;
            // 
            // ChkDisable
            // 
            this.ChkDisable.TabIndex = 2;
            // 
            // TxtName
            // 
            this.TxtName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.TabIndex = 0;
            // 
            // LblID
            // 
            this.LblID.TabIndex = 0;
            // 
            // TabGeneral
            // 
            this.TabGeneral.Controls.Add(this.GrpProperties);
            this.TabGeneral.Location = new System.Drawing.Point(4, 22);
            this.TabGeneral.Name = "TabGeneral";
            this.TabGeneral.Size = new System.Drawing.Size(555, 430);
            this.TabGeneral.TabIndex = 3;
            this.TabGeneral.Text = "General";
            this.TabGeneral.UseVisualStyleBackColor = true;
            // 
            // GrpProperties
            // 
            this.GrpProperties.Controls.Add(this.groupBox2);
            this.GrpProperties.Controls.Add(this.BtnDynDataFilePathName);
            this.GrpProperties.Controls.Add(this.BtnBrowseFile);
            this.GrpProperties.Controls.Add(this.TxtFilePathName);
            this.GrpProperties.Controls.Add(this.label3);
            this.GrpProperties.Location = new System.Drawing.Point(13, 13);
            this.GrpProperties.Name = "GrpProperties";
            this.GrpProperties.Size = new System.Drawing.Size(530, 414);
            this.GrpProperties.TabIndex = 0;
            this.GrpProperties.TabStop = false;
            this.GrpProperties.Text = "Properties";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ChkSkipFirstLine);
            this.groupBox2.Controls.Add(this.RdbReadAllTheRows);
            this.groupBox2.Controls.Add(this.BtnDynDataReadToRow);
            this.groupBox2.Controls.Add(this.BtnDynDataReadFromRow);
            this.groupBox2.Controls.Add(this.BtnDynDataNumberOfRows);
            this.groupBox2.Controls.Add(this.BtnDynDataReadRowNumber);
            this.groupBox2.Controls.Add(this.LblNumberOfRows);
            this.groupBox2.Controls.Add(this.TxtNumberOfRows);
            this.groupBox2.Controls.Add(this.LblReadToRow);
            this.groupBox2.Controls.Add(this.TxtReadToRow);
            this.groupBox2.Controls.Add(this.LblReadFromRow);
            this.groupBox2.Controls.Add(this.TxtReadFromRow);
            this.groupBox2.Controls.Add(this.CmbReadIntervalType);
            this.groupBox2.Controls.Add(this.RdbReadInterval);
            this.groupBox2.Controls.Add(this.TxtReadRowNumber);
            this.groupBox2.Controls.Add(this.RdbReadRowNumber);
            this.groupBox2.Controls.Add(this.RdbReadLastRow);
            this.groupBox2.Location = new System.Drawing.Point(12, 72);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(504, 214);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Row filter";
            // 
            // RdbReadAllTheRows
            // 
            this.RdbReadAllTheRows.AutoSize = true;
            this.RdbReadAllTheRows.Checked = true;
            this.RdbReadAllTheRows.Location = new System.Drawing.Point(17, 24);
            this.RdbReadAllTheRows.Name = "RdbReadAllTheRows";
            this.RdbReadAllTheRows.Size = new System.Drawing.Size(107, 17);
            this.RdbReadAllTheRows.TabIndex = 0;
            this.RdbReadAllTheRows.TabStop = true;
            this.RdbReadAllTheRows.Text = "Read all the rows";
            this.RdbReadAllTheRows.UseVisualStyleBackColor = true;
            this.RdbReadAllTheRows.CheckedChanged += new System.EventHandler(this.RdbReadAllTheRows_CheckedChanged);
            // 
            // BtnDynDataReadToRow
            // 
            this.BtnDynDataReadToRow.Enabled = false;
            this.BtnDynDataReadToRow.Image = global::TDP.Robot.Plugins.Core.Resource.LightningAdd;
            this.BtnDynDataReadToRow.Location = new System.Drawing.Point(238, 177);
            this.BtnDynDataReadToRow.Name = "BtnDynDataReadToRow";
            this.BtnDynDataReadToRow.Size = new System.Drawing.Size(23, 21);
            this.BtnDynDataReadToRow.TabIndex = 16;
            this.BtnDynDataReadToRow.Text = "...";
            this.BtnDynDataReadToRow.UseVisualStyleBackColor = true;
            // 
            // BtnDynDataReadFromRow
            // 
            this.BtnDynDataReadFromRow.Enabled = false;
            this.BtnDynDataReadFromRow.Image = global::TDP.Robot.Plugins.Core.Resource.LightningAdd;
            this.BtnDynDataReadFromRow.Location = new System.Drawing.Point(238, 150);
            this.BtnDynDataReadFromRow.Name = "BtnDynDataReadFromRow";
            this.BtnDynDataReadFromRow.Size = new System.Drawing.Size(23, 21);
            this.BtnDynDataReadFromRow.TabIndex = 10;
            this.BtnDynDataReadFromRow.Text = "...";
            this.BtnDynDataReadFromRow.UseVisualStyleBackColor = true;
            // 
            // BtnDynDataNumberOfRows
            // 
            this.BtnDynDataNumberOfRows.Enabled = false;
            this.BtnDynDataNumberOfRows.Image = global::TDP.Robot.Plugins.Core.Resource.LightningAdd;
            this.BtnDynDataNumberOfRows.Location = new System.Drawing.Point(460, 151);
            this.BtnDynDataNumberOfRows.Name = "BtnDynDataNumberOfRows";
            this.BtnDynDataNumberOfRows.Size = new System.Drawing.Size(23, 21);
            this.BtnDynDataNumberOfRows.TabIndex = 13;
            this.BtnDynDataNumberOfRows.Text = "...";
            this.BtnDynDataNumberOfRows.UseVisualStyleBackColor = true;
            // 
            // BtnDynDataReadRowNumber
            // 
            this.BtnDynDataReadRowNumber.Enabled = false;
            this.BtnDynDataReadRowNumber.Image = global::TDP.Robot.Plugins.Core.Resource.LightningAdd;
            this.BtnDynDataReadRowNumber.Location = new System.Drawing.Point(238, 101);
            this.BtnDynDataReadRowNumber.Name = "BtnDynDataReadRowNumber";
            this.BtnDynDataReadRowNumber.Size = new System.Drawing.Size(23, 21);
            this.BtnDynDataReadRowNumber.TabIndex = 5;
            this.BtnDynDataReadRowNumber.Text = "...";
            this.BtnDynDataReadRowNumber.UseVisualStyleBackColor = true;
            // 
            // LblNumberOfRows
            // 
            this.LblNumberOfRows.AutoSize = true;
            this.LblNumberOfRows.Location = new System.Drawing.Point(267, 154);
            this.LblNumberOfRows.Name = "LblNumberOfRows";
            this.LblNumberOfRows.Size = new System.Drawing.Size(81, 13);
            this.LblNumberOfRows.TabIndex = 11;
            this.LblNumberOfRows.Text = "Number of rows";
            // 
            // TxtNumberOfRows
            // 
            this.TxtNumberOfRows.Enabled = false;
            this.TxtNumberOfRows.Location = new System.Drawing.Point(354, 151);
            this.TxtNumberOfRows.MaxLength = 1000;
            this.TxtNumberOfRows.Name = "TxtNumberOfRows";
            this.TxtNumberOfRows.Size = new System.Drawing.Size(100, 20);
            this.TxtNumberOfRows.TabIndex = 12;
            // 
            // LblReadToRow
            // 
            this.LblReadToRow.AutoSize = true;
            this.LblReadToRow.Location = new System.Drawing.Point(86, 177);
            this.LblReadToRow.Name = "LblReadToRow";
            this.LblReadToRow.Size = new System.Drawing.Size(40, 13);
            this.LblReadToRow.TabIndex = 14;
            this.LblReadToRow.Text = "To row";
            // 
            // TxtReadToRow
            // 
            this.TxtReadToRow.Enabled = false;
            this.TxtReadToRow.Location = new System.Drawing.Point(132, 177);
            this.TxtReadToRow.MaxLength = 1000;
            this.TxtReadToRow.Name = "TxtReadToRow";
            this.TxtReadToRow.Size = new System.Drawing.Size(100, 20);
            this.TxtReadToRow.TabIndex = 15;
            // 
            // LblReadFromRow
            // 
            this.LblReadFromRow.AutoSize = true;
            this.LblReadFromRow.Location = new System.Drawing.Point(76, 154);
            this.LblReadFromRow.Name = "LblReadFromRow";
            this.LblReadFromRow.Size = new System.Drawing.Size(50, 13);
            this.LblReadFromRow.TabIndex = 8;
            this.LblReadFromRow.Text = "From row";
            // 
            // TxtReadFromRow
            // 
            this.TxtReadFromRow.Enabled = false;
            this.TxtReadFromRow.Location = new System.Drawing.Point(132, 151);
            this.TxtReadFromRow.MaxLength = 1000;
            this.TxtReadFromRow.Name = "TxtReadFromRow";
            this.TxtReadFromRow.Size = new System.Drawing.Size(100, 20);
            this.TxtReadFromRow.TabIndex = 9;
            // 
            // CmbReadIntervalType
            // 
            this.CmbReadIntervalType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbReadIntervalType.Enabled = false;
            this.CmbReadIntervalType.FormattingEnabled = true;
            this.CmbReadIntervalType.Location = new System.Drawing.Point(132, 124);
            this.CmbReadIntervalType.Name = "CmbReadIntervalType";
            this.CmbReadIntervalType.Size = new System.Drawing.Size(322, 21);
            this.CmbReadIntervalType.TabIndex = 7;
            this.CmbReadIntervalType.SelectedIndexChanged += new System.EventHandler(this.CmbReadIntervalType_SelectedIndexChanged);
            // 
            // RdbReadInterval
            // 
            this.RdbReadInterval.AutoSize = true;
            this.RdbReadInterval.Location = new System.Drawing.Point(17, 125);
            this.RdbReadInterval.Name = "RdbReadInterval";
            this.RdbReadInterval.Size = new System.Drawing.Size(103, 17);
            this.RdbReadInterval.TabIndex = 6;
            this.RdbReadInterval.Text = "Read an interval";
            this.RdbReadInterval.UseVisualStyleBackColor = true;
            this.RdbReadInterval.CheckedChanged += new System.EventHandler(this.RdbReadInterval_CheckedChanged);
            // 
            // TxtReadRowNumber
            // 
            this.TxtReadRowNumber.Enabled = false;
            this.TxtReadRowNumber.Location = new System.Drawing.Point(132, 101);
            this.TxtReadRowNumber.MaxLength = 1000;
            this.TxtReadRowNumber.Name = "TxtReadRowNumber";
            this.TxtReadRowNumber.Size = new System.Drawing.Size(100, 20);
            this.TxtReadRowNumber.TabIndex = 4;
            // 
            // RdbReadRowNumber
            // 
            this.RdbReadRowNumber.AutoSize = true;
            this.RdbReadRowNumber.Location = new System.Drawing.Point(17, 102);
            this.RdbReadRowNumber.Name = "RdbReadRowNumber";
            this.RdbReadRowNumber.Size = new System.Drawing.Size(109, 17);
            this.RdbReadRowNumber.TabIndex = 3;
            this.RdbReadRowNumber.Text = "Read row number";
            this.RdbReadRowNumber.UseVisualStyleBackColor = true;
            this.RdbReadRowNumber.CheckedChanged += new System.EventHandler(this.RdbReadRowNumber_CheckedChanged);
            // 
            // RdbReadLastRow
            // 
            this.RdbReadLastRow.AutoSize = true;
            this.RdbReadLastRow.Location = new System.Drawing.Point(17, 79);
            this.RdbReadLastRow.Name = "RdbReadLastRow";
            this.RdbReadLastRow.Size = new System.Drawing.Size(108, 17);
            this.RdbReadLastRow.TabIndex = 2;
            this.RdbReadLastRow.Text = "Read the last row";
            this.RdbReadLastRow.UseVisualStyleBackColor = true;
            this.RdbReadLastRow.CheckedChanged += new System.EventHandler(this.RdbReadLastRow_CheckedChanged);
            // 
            // BtnDynDataFilePathName
            // 
            this.BtnDynDataFilePathName.Image = global::TDP.Robot.Plugins.Core.Resource.LightningAdd;
            this.BtnDynDataFilePathName.Location = new System.Drawing.Point(501, 30);
            this.BtnDynDataFilePathName.Name = "BtnDynDataFilePathName";
            this.BtnDynDataFilePathName.Size = new System.Drawing.Size(23, 21);
            this.BtnDynDataFilePathName.TabIndex = 3;
            this.BtnDynDataFilePathName.Text = "...";
            this.BtnDynDataFilePathName.UseVisualStyleBackColor = true;
            // 
            // BtnBrowseFile
            // 
            this.BtnBrowseFile.Location = new System.Drawing.Point(464, 30);
            this.BtnBrowseFile.Name = "BtnBrowseFile";
            this.BtnBrowseFile.Size = new System.Drawing.Size(31, 20);
            this.BtnBrowseFile.TabIndex = 2;
            this.BtnBrowseFile.Text = "...";
            this.BtnBrowseFile.UseVisualStyleBackColor = true;
            this.BtnBrowseFile.Click += new System.EventHandler(this.BtnBrowseFile_Click);
            // 
            // TxtFilePathName
            // 
            this.TxtFilePathName.Location = new System.Drawing.Point(70, 30);
            this.TxtFilePathName.MaxLength = 1000;
            this.TxtFilePathName.Name = "TxtFilePathName";
            this.TxtFilePathName.Size = new System.Drawing.Size(388, 20);
            this.TxtFilePathName.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "File path";
            // 
            // TabColumnsSplit
            // 
            this.TabColumnsSplit.Controls.Add(this.ChkSplitDelimiters);
            this.TabColumnsSplit.Controls.Add(this.GrpDelimiters);
            this.TabColumnsSplit.Controls.Add(this.ChkSplitUsingFixedLengthCols);
            this.TabColumnsSplit.Location = new System.Drawing.Point(4, 22);
            this.TabColumnsSplit.Name = "TabColumnsSplit";
            this.TabColumnsSplit.Size = new System.Drawing.Size(555, 430);
            this.TabColumnsSplit.TabIndex = 4;
            this.TabColumnsSplit.Text = "Columns split";
            this.TabColumnsSplit.UseVisualStyleBackColor = true;
            // 
            // ChkSplitDelimiters
            // 
            this.ChkSplitDelimiters.AutoCheck = false;
            this.ChkSplitDelimiters.AutoSize = true;
            this.ChkSplitDelimiters.Location = new System.Drawing.Point(15, 15);
            this.ChkSplitDelimiters.Name = "ChkSplitDelimiters";
            this.ChkSplitDelimiters.Size = new System.Drawing.Size(120, 17);
            this.ChkSplitDelimiters.TabIndex = 0;
            this.ChkSplitDelimiters.Text = "Split using delimiters";
            this.ChkSplitDelimiters.UseVisualStyleBackColor = true;
            this.ChkSplitDelimiters.CheckedChanged += new System.EventHandler(this.ChkSplitDelimiters_CheckedChanged);
            this.ChkSplitDelimiters.Click += new System.EventHandler(this.ChkSplitDelimiters_Click);
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
            this.GrpDelimiters.Location = new System.Drawing.Point(15, 38);
            this.GrpDelimiters.Name = "GrpDelimiters";
            this.GrpDelimiters.Size = new System.Drawing.Size(526, 94);
            this.GrpDelimiters.TabIndex = 1;
            this.GrpDelimiters.TabStop = false;
            this.GrpDelimiters.Text = "Delimiters";
            // 
            // ChkUseDoubleQuotes
            // 
            this.ChkUseDoubleQuotes.AutoSize = true;
            this.ChkUseDoubleQuotes.Location = new System.Drawing.Point(12, 71);
            this.ChkUseDoubleQuotes.Name = "ChkUseDoubleQuotes";
            this.ChkUseDoubleQuotes.Size = new System.Drawing.Size(184, 17);
            this.ChkUseDoubleQuotes.TabIndex = 6;
            this.ChkUseDoubleQuotes.Text = "Text is enclosed in double quotes";
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
            // ChkSplitUsingFixedLengthCols
            // 
            this.ChkSplitUsingFixedLengthCols.AutoCheck = false;
            this.ChkSplitUsingFixedLengthCols.Location = new System.Drawing.Point(15, 138);
            this.ChkSplitUsingFixedLengthCols.Name = "ChkSplitUsingFixedLengthCols";
            this.ChkSplitUsingFixedLengthCols.Size = new System.Drawing.Size(173, 17);
            this.ChkSplitUsingFixedLengthCols.TabIndex = 2;
            this.ChkSplitUsingFixedLengthCols.Text = "Split using fixed length columns";
            this.ChkSplitUsingFixedLengthCols.UseVisualStyleBackColor = true;
            this.ChkSplitUsingFixedLengthCols.CheckedChanged += new System.EventHandler(this.ChkSplitUsingFixedLengthCols_CheckedChanged);
            this.ChkSplitUsingFixedLengthCols.Click += new System.EventHandler(this.ChkSplitUsingFixedLengthCols_Click);
            // 
            // TabColumnsDefinition
            // 
            this.TabColumnsDefinition.Controls.Add(this.GrpColumns);
            this.TabColumnsDefinition.Controls.Add(this.ChkOverrideDefaultColumnDef);
            this.TabColumnsDefinition.Location = new System.Drawing.Point(4, 22);
            this.TabColumnsDefinition.Name = "TabColumnsDefinition";
            this.TabColumnsDefinition.Size = new System.Drawing.Size(555, 430);
            this.TabColumnsDefinition.TabIndex = 5;
            this.TabColumnsDefinition.Text = "Columns definition";
            this.TabColumnsDefinition.UseVisualStyleBackColor = true;
            // 
            // GrpColumns
            // 
            this.GrpColumns.Controls.Add(this.BtnAutomaticCreation);
            this.GrpColumns.Controls.Add(this.BtnMoveDown);
            this.GrpColumns.Controls.Add(this.BtnMoveUp);
            this.GrpColumns.Controls.Add(this.BtnRemove);
            this.GrpColumns.Controls.Add(this.BtnEdit);
            this.GrpColumns.Controls.Add(this.BtnAdd);
            this.GrpColumns.Controls.Add(this.LstColumns);
            this.GrpColumns.Enabled = false;
            this.GrpColumns.Location = new System.Drawing.Point(5, 41);
            this.GrpColumns.Name = "GrpColumns";
            this.GrpColumns.Size = new System.Drawing.Size(547, 386);
            this.GrpColumns.TabIndex = 4;
            this.GrpColumns.TabStop = false;
            this.GrpColumns.Text = "Columns";
            // 
            // BtnAutomaticCreation
            // 
            this.BtnAutomaticCreation.Location = new System.Drawing.Point(415, 180);
            this.BtnAutomaticCreation.Name = "BtnAutomaticCreation";
            this.BtnAutomaticCreation.Size = new System.Drawing.Size(126, 23);
            this.BtnAutomaticCreation.TabIndex = 6;
            this.BtnAutomaticCreation.Text = "Automatic creation...";
            this.BtnAutomaticCreation.UseVisualStyleBackColor = true;
            this.BtnAutomaticCreation.Click += new System.EventHandler(this.BtnAutomaticCreation_Click);
            // 
            // BtnMoveDown
            // 
            this.BtnMoveDown.Location = new System.Drawing.Point(415, 141);
            this.BtnMoveDown.Name = "BtnMoveDown";
            this.BtnMoveDown.Size = new System.Drawing.Size(126, 23);
            this.BtnMoveDown.TabIndex = 5;
            this.BtnMoveDown.Text = "Move down";
            this.BtnMoveDown.UseVisualStyleBackColor = true;
            this.BtnMoveDown.Click += new System.EventHandler(this.BtnMoveDown_Click);
            // 
            // BtnMoveUp
            // 
            this.BtnMoveUp.Location = new System.Drawing.Point(415, 115);
            this.BtnMoveUp.Name = "BtnMoveUp";
            this.BtnMoveUp.Size = new System.Drawing.Size(126, 23);
            this.BtnMoveUp.TabIndex = 4;
            this.BtnMoveUp.Text = "Move up";
            this.BtnMoveUp.UseVisualStyleBackColor = true;
            this.BtnMoveUp.Click += new System.EventHandler(this.BtnMoveUp_Click);
            // 
            // BtnRemove
            // 
            this.BtnRemove.Location = new System.Drawing.Point(415, 76);
            this.BtnRemove.Name = "BtnRemove";
            this.BtnRemove.Size = new System.Drawing.Size(126, 23);
            this.BtnRemove.TabIndex = 3;
            this.BtnRemove.Text = "Remove";
            this.BtnRemove.UseVisualStyleBackColor = true;
            this.BtnRemove.Click += new System.EventHandler(this.BtnRemove_Click);
            // 
            // BtnEdit
            // 
            this.BtnEdit.Location = new System.Drawing.Point(415, 48);
            this.BtnEdit.Name = "BtnEdit";
            this.BtnEdit.Size = new System.Drawing.Size(126, 23);
            this.BtnEdit.TabIndex = 2;
            this.BtnEdit.Text = "Edit...";
            this.BtnEdit.UseVisualStyleBackColor = true;
            this.BtnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
            // 
            // BtnAdd
            // 
            this.BtnAdd.Location = new System.Drawing.Point(415, 19);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(126, 23);
            this.BtnAdd.TabIndex = 1;
            this.BtnAdd.Text = "Add...";
            this.BtnAdd.UseVisualStyleBackColor = true;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // LstColumns
            // 
            this.LstColumns.FormattingEnabled = true;
            this.LstColumns.Location = new System.Drawing.Point(6, 18);
            this.LstColumns.Name = "LstColumns";
            this.LstColumns.Size = new System.Drawing.Size(403, 355);
            this.LstColumns.TabIndex = 0;
            this.LstColumns.DoubleClick += new System.EventHandler(this.LstColumns_DoubleClick_1);
            // 
            // ChkOverrideDefaultColumnDef
            // 
            this.ChkOverrideDefaultColumnDef.AutoSize = true;
            this.ChkOverrideDefaultColumnDef.Location = new System.Drawing.Point(17, 18);
            this.ChkOverrideDefaultColumnDef.Name = "ChkOverrideDefaultColumnDef";
            this.ChkOverrideDefaultColumnDef.Size = new System.Drawing.Size(188, 17);
            this.ChkOverrideDefaultColumnDef.TabIndex = 0;
            this.ChkOverrideDefaultColumnDef.Text = "Override default columns definition";
            this.ChkOverrideDefaultColumnDef.UseVisualStyleBackColor = true;
            this.ChkOverrideDefaultColumnDef.CheckedChanged += new System.EventHandler(this.ChkOverrideDefaultColumnDef_CheckedChanged);
            // 
            // ChkSkipFirstLine
            // 
            this.ChkSkipFirstLine.AutoSize = true;
            this.ChkSkipFirstLine.Location = new System.Drawing.Point(31, 47);
            this.ChkSkipFirstLine.Name = "ChkSkipFirstLine";
            this.ChkSkipFirstLine.Size = new System.Drawing.Size(85, 17);
            this.ChkSkipFirstLine.TabIndex = 1;
            this.ChkSkipFirstLine.Text = "Skip first line";
            this.ChkSkipFirstLine.UseVisualStyleBackColor = true;
            // 
            // WndReadTextFileTaskConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 575);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WndReadTextFileTaskConfig";
            this.Text = "Read text file configuration";
            this.TabConfig2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrProvider)).EndInit();
            this.TabGeneral.ResumeLayout(false);
            this.GrpProperties.ResumeLayout(false);
            this.GrpProperties.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.TabColumnsSplit.ResumeLayout(false);
            this.TabColumnsSplit.PerformLayout();
            this.GrpDelimiters.ResumeLayout(false);
            this.GrpDelimiters.PerformLayout();
            this.TabColumnsDefinition.ResumeLayout(false);
            this.TabColumnsDefinition.PerformLayout();
            this.GrpColumns.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage TabGeneral;
        private System.Windows.Forms.GroupBox GrpProperties;
        private System.Windows.Forms.Button BtnDynDataFilePathName;
        private System.Windows.Forms.Button BtnBrowseFile;
        private System.Windows.Forms.TextBox TxtFilePathName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BtnDynDataReadToRow;
        private System.Windows.Forms.Button BtnDynDataReadFromRow;
        private System.Windows.Forms.Button BtnDynDataNumberOfRows;
        private System.Windows.Forms.Button BtnDynDataReadRowNumber;
        private System.Windows.Forms.Label LblNumberOfRows;
        private System.Windows.Forms.TextBox TxtNumberOfRows;
        private System.Windows.Forms.Label LblReadToRow;
        private System.Windows.Forms.TextBox TxtReadToRow;
        private System.Windows.Forms.Label LblReadFromRow;
        private System.Windows.Forms.TextBox TxtReadFromRow;
        private System.Windows.Forms.ComboBox CmbReadIntervalType;
        private System.Windows.Forms.RadioButton RdbReadInterval;
        private System.Windows.Forms.TextBox TxtReadRowNumber;
        private System.Windows.Forms.RadioButton RdbReadRowNumber;
        private System.Windows.Forms.RadioButton RdbReadLastRow;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TabPage TabColumnsSplit;
        private System.Windows.Forms.CheckBox ChkSplitDelimiters;
        private System.Windows.Forms.GroupBox GrpDelimiters;
        private System.Windows.Forms.TextBox TxtDelOther;
        private System.Windows.Forms.CheckBox ChkDelOther;
        private System.Windows.Forms.CheckBox ChkDelSpace;
        private System.Windows.Forms.CheckBox ChkDelComma;
        private System.Windows.Forms.CheckBox ChkDelSemicolon;
        private System.Windows.Forms.CheckBox ChkDelTab;
        private System.Windows.Forms.CheckBox ChkSplitUsingFixedLengthCols;
        private System.Windows.Forms.RadioButton RdbReadAllTheRows;
        private System.Windows.Forms.CheckBox ChkUseDoubleQuotes;
        private System.Windows.Forms.TabPage TabColumnsDefinition;
        private System.Windows.Forms.CheckBox ChkOverrideDefaultColumnDef;
        private System.Windows.Forms.GroupBox GrpColumns;
        private System.Windows.Forms.Button BtnMoveDown;
        private System.Windows.Forms.Button BtnMoveUp;
        private System.Windows.Forms.Button BtnRemove;
        private System.Windows.Forms.Button BtnEdit;
        private System.Windows.Forms.Button BtnAdd;
        private System.Windows.Forms.ListBox LstColumns;
        private System.Windows.Forms.Button BtnAutomaticCreation;
        private System.Windows.Forms.CheckBox ChkSkipFirstLine;
    }
}