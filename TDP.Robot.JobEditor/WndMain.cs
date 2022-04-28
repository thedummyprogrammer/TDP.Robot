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

using System;
using System.Drawing;
using System.Windows.Forms;
using TDP.BaseServices.Infrastructure.Logging.Abstract;
using TDP.Robot.Core;
using TDP.Robot.JobEditor.Infrastructure;
using TDP.Robot.JobEditor.Infrastructure.Workspace;
using TDP.Robot.JobEditor.Properties;

namespace TDP.Robot.JobEditor
{
    public partial class WndMain : Form
    {
        private const int _WindowSpace = 10;

        private ILogger _Log;
        private WndToolbox _WndToolbox;
        private WndFolderTree _WndFolderTree;
        private WndWorkspace _WndWorkspace;
        private WndLog _WndLog;

        private Form OpenChildWindow(Type wndType)
        {
            Form ChildWindow = (Form)Activator.CreateInstance(wndType);
            ChildWindow.MdiParent = this;
            ChildWindow.Show();
            return ChildWindow;
        }

        private void ArrangeWindows()
        {
            _Log.Info("ArrangeWindows");
            _WndFolderTree.Location = new Point(0, 0);
            _WndFolderTree.Size = new Size(_WndFolderTree.Width, (ClientRectangle.Height / 2) - (_WindowSpace * 2));
            _WndWorkspace.Location = new Point(_WndFolderTree.Width + _WindowSpace, 0);
            _WndWorkspace.Size = new Size(ClientRectangle.Width - _WndFolderTree.Width - (_WindowSpace * 2), _WndFolderTree.Height);
            
            _WndToolbox.Location = new Point(0, _WndFolderTree.Height + _WindowSpace);
            _WndToolbox.Size = _WndFolderTree.Size;
            _WndLog.Location = new Point(_WndToolbox.Width + _WindowSpace, _WndToolbox.Location.Y);
            _WndLog.Size = new Size(_WndWorkspace.Width, _WndFolderTree.Height);
            _Log.Info("ArrangeWindows End");
        }

        private string GetLibPath()
        {
            return Helpers.PathAppendBackSlash(Application.StartupPath) + Config.LibPath;
        }

        private string GetDataPath()
        {
            return Helpers.PathAppendBackSlash(Application.StartupPath) + Config.DataPath;
        }

        

        private bool LoadJobData()
        {
            bool Result = true;
            string DataPath = GetDataPath();
            _Log.Info($"Loading jobs data from directory: {DataPath}");

            try
            {
                _Log.Info("Loading jobs data...");
                Common.RootFolder = WorkspacePersistence.Load(DataPath);
            }
            catch (Exception ex)
            {
                _Log.Error("Error loading data", ex);
                Result = false;
            }

            if (Common.RootFolder == null)
            {
                _Log.Info("No data found, creating an empty workspace...");
                Common.RootFolder = new WorkspaceFolder();
                Common.RootFolder.ID = Constants.RootFolderID;
            }

            Common.RootFolder.CurrentFolder = Common.RootFolder;

            return Result;
        }

        public WndMain()
        {
            InitializeComponent();
            
            Config.Init();
            Common.Init();

            _Log = Common.Log;
            _Log.Info("Starting TDP.Robot.JobEditor...");

            if (!CoreHelpers.LoadPlugins(GetLibPath(), _Log, Common.PluginTypes, Common.PluginList, Common.PluginDict))
            {
                MessageBox.Show(Resources.TxtPluginsNotLoadedCorrectly);
                _Log.Info("One ore more plugins were not loaded correctly");
            }

            if (!LoadJobData())
            {
                MessageBox.Show(Resources.TxtDataNotLoadedCorrectly);
                _Log.Info("Jobs data not loaded correctly");
            }

            _Log.Info("Creating child windows...");
            OpenMdiWindow(typeof(WndToolbox));
            OpenMdiWindow(typeof(WndWorkspace));
            OpenMdiWindow(typeof(WndFolderTree));
            OpenMdiWindow(typeof(WndLog));

            this.Shown += WndMain_Shown;
        }

        private void WndMain_Shown(object sender, EventArgs e)
        {
            ArrangeWindows();
        }

        private void OpenMdiWindow(Type window)
        {
            Form NewWindow = OpenChildWindow(window);

            if (NewWindow is WndToolbox)
            {
                _WndToolbox = (WndToolbox)NewWindow;
                _WndToolbox.Plugins = Common.PluginList;
                _WndToolbox.FormClosed += MdiWindowClosed;
            }
            else if (NewWindow is WndWorkspace)
            {
                _WndWorkspace = (WndWorkspace)NewWindow;
                _WndWorkspace.RootFolderData = Common.RootFolder;
                _WndWorkspace.FormClosed += MdiWindowClosed;
            }
            else if (NewWindow is WndFolderTree)
            {
                _WndFolderTree = (WndFolderTree)NewWindow;
                _WndFolderTree.RootFolder = Common.RootFolder;
                _WndFolderTree.FormClosed += MdiWindowClosed;
            }
            else if (NewWindow is WndLog)
            {
                _WndLog = (WndLog)NewWindow;
                _WndLog.FormClosed += MdiWindowClosed;
            }
        }

        private void MdiWindowClosed(object sender, FormClosedEventArgs e)
        {
            ResetMdiWindowRef((Form)sender);
        }

        private void ResetMdiWindowRef(Form window)
        {
            if (window is WndToolbox)
            {
                _WndToolbox = null;
            }
            else if (window is WndWorkspace)
            {
                _WndWorkspace = null;
            }
            else if (window is WndFolderTree)
            {
                _WndFolderTree = null;
            }
            else if (window is WndLog)
            {
                _WndLog = null;
            }
        }

        private void CloseMdiWindow(Form window)
        {
            ResetMdiWindowRef(window);

            window.Close();
        }

        private void MnuExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MnuSave_Click(object sender, EventArgs e)
        {
            try
            {
                WorkspacePersistence.Save(GetDataPath(), Common.RootFolder, true);
            }
            catch 
            {
                MessageBox.Show(Resources.TxtAnErrorOccurredWhileSaving, Resources.TxtTheDummyProgrammerRobot, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MnuAbout_Click(object sender, EventArgs e)
        {
            WndAbout WndAbout = new WndAbout();
            WndAbout.ShowDialog();
        }

        private void WndMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing 
                && MessageBox.Show(Resources.TxtDoYouReallyWantToCloseApplication, Resources.TxtTheDummyProgrammerRobot, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                e.Cancel = true;
        }

        private void MnuWindowCascade_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void MnuWindowTileHoriz_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void MnuWindowTileVert_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void MnuWindowArrange_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void MnuWindowCloseAll_Click(object sender, EventArgs e)
        {
            while (MdiChildren.Length > 0)
            {
                CloseMdiWindow(MdiChildren[0]);
            }
        }

        private void MnuWindowShowHideFolders_Click(object sender, EventArgs e)
        {
            if (_WndFolderTree == null)
                OpenMdiWindow(typeof(WndFolderTree));
            else
                CloseMdiWindow(_WndFolderTree);
        }

        private void MnuWindowShowHideWorkspace_Click(object sender, EventArgs e)
        {
            if (_WndWorkspace == null)
                OpenMdiWindow(typeof(WndWorkspace));
            else
                CloseMdiWindow(_WndWorkspace);
        }

        private void MnuWindowShowHideToolbox_Click(object sender, EventArgs e)
        {
            if (_WndToolbox == null)
                OpenMdiWindow(typeof(WndToolbox));
            else
                CloseMdiWindow(_WndToolbox);
        }

        private void MnuWindowShowHideLog_Click(object sender, EventArgs e)
        {
            if (_WndLog == null)
                OpenMdiWindow(typeof(WndLog));
            else
                CloseMdiWindow(_WndLog);
        }

        private void MnuWindowStdPositioning_Click(object sender, EventArgs e)
        {
            ArrangeWindows();
        }
    }
}
