/*======================================================================================
    Copyright 2021 by TheDummyProgrammer (https://www.thedummyprogrammer.com)

    This file is part of The Dummy Programmer Robot.

    The Dummy Programmer Robot is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    The Dummy Programmer Robot is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with The Dummy Programmer Robot.  If not, see <http://www.gnu.org/licenses/>.
======================================================================================*/


namespace TDP.Robot.Plugins.Core.FileSystemTask
{
    partial class WndFileSystemTaskConfig
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
            this.CmbCommand = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.TabGeneral = new System.Windows.Forms.TabPage();
            this.GrpCopyMove = new System.Windows.Forms.GroupBox();
            this.BtnRemoveCopyPath = new System.Windows.Forms.Button();
            this.BtnEditCopyPath = new System.Windows.Forms.Button();
            this.BtnAddCopyPath = new System.Windows.Forms.Button();
            this.LblCopyPaths = new System.Windows.Forms.Label();
            this.LstCopyPaths = new System.Windows.Forms.ListBox();
            this.GrpDelete = new System.Windows.Forms.GroupBox();
            this.BtnRemoveDeletePath = new System.Windows.Forms.Button();
            this.BtnEditDeletePath = new System.Windows.Forms.Button();
            this.BtnAddDeletePath = new System.Windows.Forms.Button();
            this.LblDeletePaths = new System.Windows.Forms.Label();
            this.LstDeletePaths = new System.Windows.Forms.ListBox();
            this.TabConfig2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrProvider)).BeginInit();
            this.TabGeneral.SuspendLayout();
            this.GrpCopyMove.SuspendLayout();
            this.GrpDelete.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabConfig2
            // 
            this.TabConfig2.Controls.Add(this.TabGeneral);
            this.TabConfig2.Controls.SetChildIndex(this.TabGeneral, 0);
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(415, 529);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(496, 529);
            // 
            // CmbCommand
            // 
            this.CmbCommand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbCommand.FormattingEnabled = true;
            this.CmbCommand.Location = new System.Drawing.Point(83, 15);
            this.CmbCommand.Name = "CmbCommand";
            this.CmbCommand.Size = new System.Drawing.Size(209, 21);
            this.CmbCommand.TabIndex = 23;
            this.CmbCommand.SelectedIndexChanged += new System.EventHandler(this.CmbCommand_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "Command";
            // 
            // TabGeneral
            // 
            this.TabGeneral.Controls.Add(this.label7);
            this.TabGeneral.Controls.Add(this.CmbCommand);
            this.TabGeneral.Controls.Add(this.GrpCopyMove);
            this.TabGeneral.Controls.Add(this.GrpDelete);
            this.TabGeneral.Location = new System.Drawing.Point(4, 22);
            this.TabGeneral.Name = "TabGeneral";
            this.TabGeneral.Size = new System.Drawing.Size(555, 415);
            this.TabGeneral.TabIndex = 3;
            this.TabGeneral.Text = "General";
            this.TabGeneral.UseVisualStyleBackColor = true;
            // 
            // GrpCopyMove
            // 
            this.GrpCopyMove.Controls.Add(this.BtnRemoveCopyPath);
            this.GrpCopyMove.Controls.Add(this.BtnEditCopyPath);
            this.GrpCopyMove.Controls.Add(this.BtnAddCopyPath);
            this.GrpCopyMove.Controls.Add(this.LblCopyPaths);
            this.GrpCopyMove.Controls.Add(this.LstCopyPaths);
            this.GrpCopyMove.Location = new System.Drawing.Point(8, 42);
            this.GrpCopyMove.Name = "GrpCopyMove";
            this.GrpCopyMove.Size = new System.Drawing.Size(535, 122);
            this.GrpCopyMove.TabIndex = 27;
            this.GrpCopyMove.TabStop = false;
            this.GrpCopyMove.Text = "Copy / Move";
            // 
            // BtnRemoveCopyPath
            // 
            this.BtnRemoveCopyPath.Location = new System.Drawing.Point(442, 85);
            this.BtnRemoveCopyPath.Name = "BtnRemoveCopyPath";
            this.BtnRemoveCopyPath.Size = new System.Drawing.Size(87, 23);
            this.BtnRemoveCopyPath.TabIndex = 4;
            this.BtnRemoveCopyPath.Text = "Remove";
            this.BtnRemoveCopyPath.UseVisualStyleBackColor = true;
            this.BtnRemoveCopyPath.Click += new System.EventHandler(this.BtnRemoveCopyPath_Click);
            // 
            // BtnEditCopyPath
            // 
            this.BtnEditCopyPath.Location = new System.Drawing.Point(442, 56);
            this.BtnEditCopyPath.Name = "BtnEditCopyPath";
            this.BtnEditCopyPath.Size = new System.Drawing.Size(87, 23);
            this.BtnEditCopyPath.TabIndex = 3;
            this.BtnEditCopyPath.Text = "Edit...";
            this.BtnEditCopyPath.UseVisualStyleBackColor = true;
            this.BtnEditCopyPath.Click += new System.EventHandler(this.BtnEditCopyPath_Click);
            // 
            // BtnAddCopyPath
            // 
            this.BtnAddCopyPath.Location = new System.Drawing.Point(442, 27);
            this.BtnAddCopyPath.Name = "BtnAddCopyPath";
            this.BtnAddCopyPath.Size = new System.Drawing.Size(87, 23);
            this.BtnAddCopyPath.TabIndex = 2;
            this.BtnAddCopyPath.Text = "Add...";
            this.BtnAddCopyPath.UseVisualStyleBackColor = true;
            this.BtnAddCopyPath.Click += new System.EventHandler(this.BtnAddCopyPath_Click);
            // 
            // LblCopyPaths
            // 
            this.LblCopyPaths.AutoSize = true;
            this.LblCopyPaths.Location = new System.Drawing.Point(6, 26);
            this.LblCopyPaths.Name = "LblCopyPaths";
            this.LblCopyPaths.Size = new System.Drawing.Size(34, 13);
            this.LblCopyPaths.TabIndex = 1;
            this.LblCopyPaths.Text = "Paths";
            // 
            // LstCopyPaths
            // 
            this.LstCopyPaths.FormattingEnabled = true;
            this.LstCopyPaths.Location = new System.Drawing.Point(46, 26);
            this.LstCopyPaths.Name = "LstCopyPaths";
            this.LstCopyPaths.Size = new System.Drawing.Size(390, 82);
            this.LstCopyPaths.TabIndex = 0;
            this.LstCopyPaths.DoubleClick += new System.EventHandler(this.LstCopyPaths_DoubleClick);
            // 
            // GrpDelete
            // 
            this.GrpDelete.Controls.Add(this.BtnRemoveDeletePath);
            this.GrpDelete.Controls.Add(this.BtnEditDeletePath);
            this.GrpDelete.Controls.Add(this.BtnAddDeletePath);
            this.GrpDelete.Controls.Add(this.LblDeletePaths);
            this.GrpDelete.Controls.Add(this.LstDeletePaths);
            this.GrpDelete.Location = new System.Drawing.Point(5, 42);
            this.GrpDelete.Name = "GrpDelete";
            this.GrpDelete.Size = new System.Drawing.Size(537, 122);
            this.GrpDelete.TabIndex = 28;
            this.GrpDelete.TabStop = false;
            this.GrpDelete.Text = "Delete";
            this.GrpDelete.Visible = false;
            // 
            // BtnRemoveDeletePath
            // 
            this.BtnRemoveDeletePath.Location = new System.Drawing.Point(443, 85);
            this.BtnRemoveDeletePath.Name = "BtnRemoveDeletePath";
            this.BtnRemoveDeletePath.Size = new System.Drawing.Size(87, 23);
            this.BtnRemoveDeletePath.TabIndex = 9;
            this.BtnRemoveDeletePath.Text = "Remove";
            this.BtnRemoveDeletePath.UseVisualStyleBackColor = true;
            this.BtnRemoveDeletePath.Click += new System.EventHandler(this.BtnRemoveDeletePath_Click);
            // 
            // BtnEditDeletePath
            // 
            this.BtnEditDeletePath.Location = new System.Drawing.Point(443, 56);
            this.BtnEditDeletePath.Name = "BtnEditDeletePath";
            this.BtnEditDeletePath.Size = new System.Drawing.Size(87, 23);
            this.BtnEditDeletePath.TabIndex = 8;
            this.BtnEditDeletePath.Text = "Edit...";
            this.BtnEditDeletePath.UseVisualStyleBackColor = true;
            this.BtnEditDeletePath.Click += new System.EventHandler(this.BtnEditDeletePath_Click);
            // 
            // BtnAddDeletePath
            // 
            this.BtnAddDeletePath.Location = new System.Drawing.Point(444, 27);
            this.BtnAddDeletePath.Name = "BtnAddDeletePath";
            this.BtnAddDeletePath.Size = new System.Drawing.Size(87, 23);
            this.BtnAddDeletePath.TabIndex = 7;
            this.BtnAddDeletePath.Text = "Add...";
            this.BtnAddDeletePath.UseVisualStyleBackColor = true;
            this.BtnAddDeletePath.Click += new System.EventHandler(this.BtnAddDeletePath_Click);
            // 
            // LblDeletePaths
            // 
            this.LblDeletePaths.AutoSize = true;
            this.LblDeletePaths.Location = new System.Drawing.Point(6, 26);
            this.LblDeletePaths.Name = "LblDeletePaths";
            this.LblDeletePaths.Size = new System.Drawing.Size(34, 13);
            this.LblDeletePaths.TabIndex = 6;
            this.LblDeletePaths.Text = "Paths";
            // 
            // LstDeletePaths
            // 
            this.LstDeletePaths.FormattingEnabled = true;
            this.LstDeletePaths.Location = new System.Drawing.Point(46, 26);
            this.LstDeletePaths.Name = "LstDeletePaths";
            this.LstDeletePaths.Size = new System.Drawing.Size(391, 82);
            this.LstDeletePaths.TabIndex = 5;
            this.LstDeletePaths.DoubleClick += new System.EventHandler(this.LstDeletePaths_DoubleClick);
            // 
            // WndFileSystemTaskConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 568);
            this.Name = "WndFileSystemTaskConfig";
            this.Text = "File system task config";
            this.TabConfig2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrProvider)).EndInit();
            this.TabGeneral.ResumeLayout(false);
            this.TabGeneral.PerformLayout();
            this.GrpCopyMove.ResumeLayout(false);
            this.GrpCopyMove.PerformLayout();
            this.GrpDelete.ResumeLayout(false);
            this.GrpDelete.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox CmbCommand;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TabPage TabGeneral;
        private System.Windows.Forms.GroupBox GrpCopyMove;
        private System.Windows.Forms.Button BtnRemoveCopyPath;
        private System.Windows.Forms.Button BtnEditCopyPath;
        private System.Windows.Forms.Button BtnAddCopyPath;
        private System.Windows.Forms.Label LblCopyPaths;
        private System.Windows.Forms.ListBox LstCopyPaths;
        private System.Windows.Forms.GroupBox GrpDelete;
        private System.Windows.Forms.Button BtnRemoveDeletePath;
        private System.Windows.Forms.Button BtnEditDeletePath;
        private System.Windows.Forms.Button BtnAddDeletePath;
        private System.Windows.Forms.Label LblDeletePaths;
        private System.Windows.Forms.ListBox LstDeletePaths;
    }
}