
namespace TDP.Robot.Core
{
    partial class WndDynamicDataBrowser
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
            this.LsvObjects = new System.Windows.Forms.ListView();
            this.ColObjectName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColObjectID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColObjectType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.LsvDynData = new System.Windows.Forms.ListView();
            this.ColDynDataName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColDynDataExample = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.BtnSelect = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // LsvObjects
            // 
            this.LsvObjects.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColObjectName,
            this.ColObjectID,
            this.ColObjectType});
            this.LsvObjects.FullRowSelect = true;
            this.LsvObjects.HideSelection = false;
            this.LsvObjects.Location = new System.Drawing.Point(6, 19);
            this.LsvObjects.MultiSelect = false;
            this.LsvObjects.Name = "LsvObjects";
            this.LsvObjects.Size = new System.Drawing.Size(526, 182);
            this.LsvObjects.TabIndex = 0;
            this.LsvObjects.UseCompatibleStateImageBehavior = false;
            this.LsvObjects.View = System.Windows.Forms.View.Details;
            this.LsvObjects.SelectedIndexChanged += new System.EventHandler(this.LsvObjects_SelectedIndexChanged);
            this.LsvObjects.Click += new System.EventHandler(this.LsvObjects_Click);
            // 
            // ColObjectName
            // 
            this.ColObjectName.Text = "Name";
            this.ColObjectName.Width = 200;
            // 
            // ColObjectID
            // 
            this.ColObjectID.Text = "ID";
            this.ColObjectID.Width = 80;
            // 
            // ColObjectType
            // 
            this.ColObjectType.Text = "Type";
            this.ColObjectType.Width = 120;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LsvObjects);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(546, 210);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Objects";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.LsvDynData);
            this.groupBox2.Location = new System.Drawing.Point(12, 229);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(547, 210);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Dynamic data";
            // 
            // LsvDynData
            // 
            this.LsvDynData.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColDynDataName,
            this.ColDynDataExample});
            this.LsvDynData.FullRowSelect = true;
            this.LsvDynData.HideSelection = false;
            this.LsvDynData.Location = new System.Drawing.Point(6, 19);
            this.LsvDynData.Name = "LsvDynData";
            this.LsvDynData.Size = new System.Drawing.Size(526, 182);
            this.LsvDynData.TabIndex = 0;
            this.LsvDynData.UseCompatibleStateImageBehavior = false;
            this.LsvDynData.View = System.Windows.Forms.View.Details;
            this.LsvDynData.DoubleClick += new System.EventHandler(this.LsvDynData_DoubleClick);
            // 
            // ColDynDataName
            // 
            this.ColDynDataName.Text = "Name";
            this.ColDynDataName.Width = 200;
            // 
            // ColDynDataExample
            // 
            this.ColDynDataExample.Text = "Example value";
            this.ColDynDataExample.Width = 200;
            // 
            // BtnSelect
            // 
            this.BtnSelect.Location = new System.Drawing.Point(389, 445);
            this.BtnSelect.Name = "BtnSelect";
            this.BtnSelect.Size = new System.Drawing.Size(75, 23);
            this.BtnSelect.TabIndex = 2;
            this.BtnSelect.Text = "Select";
            this.BtnSelect.UseVisualStyleBackColor = true;
            this.BtnSelect.Click += new System.EventHandler(this.BtnSelect_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.Location = new System.Drawing.Point(470, 445);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 3;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            // 
            // WndDynamicDataBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 482);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnSelect);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WndDynamicDataBrowser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dynamic data browser";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView LsvObjects;
        private System.Windows.Forms.ColumnHeader ColObjectName;
        private System.Windows.Forms.ColumnHeader ColObjectID;
        private System.Windows.Forms.ColumnHeader ColObjectType;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView LsvDynData;
        private System.Windows.Forms.ColumnHeader ColDynDataName;
        private System.Windows.Forms.ColumnHeader ColDynDataExample;
        private System.Windows.Forms.Button BtnSelect;
        private System.Windows.Forms.Button BtnCancel;
    }
}