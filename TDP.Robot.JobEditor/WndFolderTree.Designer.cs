namespace TDP.Robot.JobEditor
{
    partial class WndFolderTree
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Workspace Root");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WndFolderTree));
            this.TrFolderTree = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // TrFolderTree
            // 
            this.TrFolderTree.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TrFolderTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TrFolderTree.HideSelection = false;
            this.TrFolderTree.ImageIndex = 1;
            this.TrFolderTree.ImageList = this.imageList1;
            this.TrFolderTree.Location = new System.Drawing.Point(0, 0);
            this.TrFolderTree.Name = "TrFolderTree";
            treeNode1.Name = "WorkspaceRoot";
            treeNode1.Text = "Workspace Root";
            this.TrFolderTree.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.TrFolderTree.SelectedImageIndex = 1;
            this.TrFolderTree.Size = new System.Drawing.Size(353, 450);
            this.TrFolderTree.StateImageList = this.imageList1;
            this.TrFolderTree.TabIndex = 0;
            this.TrFolderTree.BeforeCollapse += new System.Windows.Forms.TreeViewCancelEventHandler(this.TrFolderTree_BeforeCollapse);
            this.TrFolderTree.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.TrFolderTree_BeforeExpand);
            this.TrFolderTree.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TrFolderTree_NodeMouseClick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "FolderOpened_16x.png");
            this.imageList1.Images.SetKeyName(1, "FolderClosed_16x.png");
            // 
            // WndFolderTree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 450);
            this.Controls.Add(this.TrFolderTree);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WndFolderTree";
            this.Text = "Folders";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView TrFolderTree;
        private System.Windows.Forms.ImageList imageList1;
    }
}