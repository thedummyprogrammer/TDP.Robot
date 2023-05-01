/*======================================================================================
    Copyright 2021 - 2023 by TheDummyProgrammer (https://www.thedummyprogrammer.com)

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

using System;
using System.Windows.Forms;
using TDP.Robot.JobEditor.Infrastructure.Workspace;
using TDP.Robot.JobEditor.Infrastructure.Workspace.Abstract;
using TDP.Robot.JobEditor.Properties;

namespace TDP.Robot.JobEditor
{
    public partial class WndWorkspace : Form
    {
        private WorkspaceManager _workspaceManager;
        
        private IWorkspaceFolder _rootFolderData;

        internal IWorkspaceFolder RootFolderData
        {
            get
            {
                return _rootFolderData;
            }
            set 
            {
                _rootFolderData = value;
                _workspaceManager = new WorkspaceManager(JobContainer, _rootFolderData);
            }
        }

        public WndWorkspace()
        {
            InitializeComponent();
            Common.RootFolder.CurrentFolderChanged += RootFolder_CurrentFolderChanged;
        }

        private void RootFolder_CurrentFolderChanged(object sender, CurrentFolderChangedEventArgs e)
        {
            Text = Resources.TxtWorkspace + " - " + e.Folder.GetFullPath();
            Refresh();
        }

        private void WndWorkspace_SizeChanged(object sender, EventArgs e)
        {
            if (_workspaceManager != null)
            {
                JobContainer.Width = Convert.ToInt32(Math.Max(ClientSize.Width, _workspaceManager.CanvasWidth));
                JobContainer.Height = Convert.ToInt32(Math.Max(ClientSize.Height, _workspaceManager.CanvasHeight));

                _workspaceManager.WindowClientWidth = ClientSize.Width;
                _workspaceManager.WindowClientHeight = ClientSize.Height;
            }
        }

        private void WndWorkspace_KeyDown(object sender, KeyEventArgs e)
        {
            _workspaceManager.ManageKeyDown(e);
        }
    }
}
