/*======================================================================================
    Copyright 2021 - 2022 by TheDummyProgrammer (https://www.thedummyprogrammer.com)

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

using System.Data;
using System.Linq;
using System.Windows.Forms;
using TDP.Robot.JobEditor.Infrastructure;
using TDP.Robot.JobEditor.Infrastructure.Workspace.Abstract;
using TDP.Robot.JobEditor.Properties;

namespace TDP.Robot.JobEditor
{
    public partial class WndFolderTree : Form
    {
        private IWorkspaceFolder _RootFolder;

        internal IWorkspaceFolder RootFolder
        {
            get
            {
                return _RootFolder;
            }
            set
            {
                _RootFolder = value;
                TrFolderTree.Nodes.Clear();
                TreeNode RootNode = TrFolderTree.Nodes.Add(Constants.RootFolderID.ToString(), Resources.TxtWorkspaceRoot);
                RootNode.Tag = _RootFolder;
                FillTree(RootNode, _RootFolder);
                _RootFolder.ObjectsAdded += _RootFolderData_ObjectsAdded;
                _RootFolder.ObjectsRemoved += _RootFolderData_ObjectsRemoved;
                _RootFolder.CurrentFolderChanged += _RootFolder_CurrentFolderChanged;
                _RootFolder.FolderNameChanged += _RootFolder_FolderNameChanged;
            }
        }


        private void _RootFolderData_ObjectsAdded(object sender, ObjectsAddedEventArgs e)
        {
            TreeNode[] Result = TrFolderTree.Nodes.Find(e.Folder.ID.ToString(), true);
            if (Result.Length > 0)
            {
                TreeNode Node = Result[0];
                foreach (IWorkspaceFolder F in e.ObjectsAdded.Where(I => I is IWorkspaceFolder))
                {
                    TreeNode RootNode = Node.Nodes.Add(F.ID.ToString(), F.Name);
                    RootNode.Tag = F;
                    FillTree(RootNode, F);
                }
            }
        }

        private void _RootFolderData_ObjectsRemoved(object sender, ObjectsRemovedEventArgs e)
        {
            TreeNode[] Result = TrFolderTree.Nodes.Find(e.Folder.ID.ToString(), true);
            if (Result.Length > 0)
            {
                TreeNode Node = Result[0];
                foreach (IWorkspaceFolder F in e.ObjectsRemoved.Where(I => I is IWorkspaceFolder))
                {
                    TreeNode[] NodeToRemove = Node.Nodes.Find(F.ID.ToString(), false);
                    if (NodeToRemove.Length > 0)
                    {
                        Node.Nodes.Remove(NodeToRemove[0]);
                    }
                }
            }
        }

        private void _RootFolder_CurrentFolderChanged(object sender, CurrentFolderChangedEventArgs e)
        {
            TreeNode[] Result = TrFolderTree.Nodes.Find(e.Folder.ID.ToString(), true);
            if (Result.Length > 0)
            {
                TrFolderTree.SelectedNode = Result[0];
            }
        }

        private void _RootFolder_FolderNameChanged(object sender, FolderNameChangedEventArgs e)
        {
            TreeNode[] Result = TrFolderTree.Nodes.Find(e.Folder.ID.ToString(), true);
            if (Result.Length > 0)
            {
                Result[0].Text = e.Folder.Name;
            }
        }

        private void FillTree(TreeNode treeRoot, IWorkspaceFolder folderData)
        {
            foreach (IWorkspaceItemBase Item in folderData)
            {
                if (Item is IWorkspaceFolder)
                {
                    TreeNode NewFolder = treeRoot.Nodes.Add(Item.ID.ToString(), Item.Name);
                    NewFolder.Tag = Item;
                    FillTree(NewFolder, ((IWorkspaceFolder)Item));
                }
            }
        }

        public WndFolderTree()
        {
            InitializeComponent();
        }

        private void TrFolderTree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            _RootFolder.CurrentFolder = (IWorkspaceFolder)e.Node.Tag;
        }

        private void TrFolderTree_BeforeCollapse(object sender, TreeViewCancelEventArgs e)
        {
            e.Node.ImageIndex = 1;
            e.Node.SelectedImageIndex = 1;
        }

        private void TrFolderTree_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            e.Node.ImageIndex = 0;
            e.Node.SelectedImageIndex = 0;
        }
    }
}
