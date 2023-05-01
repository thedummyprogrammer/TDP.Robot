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
using System.IO;
using System.Windows.Forms;
using TDP.Robot.JobEditor.Infrastructure.Workspace.Abstract;
using TDP.Robot.JobEditor.Properties;

namespace TDP.Robot.JobEditor
{
    public partial class WndLog : Form
    {
        public WndLog()
        {
            InitializeComponent();
            Common.RootFolder.CurrentFolderChanged += RootFolder_CurrentFolderChanged;
            UpdateLogList();
        }

        private string GetFolderLogPath(IWorkspaceFolder folder)
        {
            string EventsLogPath;
            if (Path.IsPathRooted(Config.EventsLogPath))
                EventsLogPath = Config.EventsLogPath;
            else
                EventsLogPath = Path.Combine(Application.StartupPath, Config.EventsLogPath);

            return Path.Combine(EventsLogPath, folder.GetIDFullPath());
        }

        private void RootFolder_CurrentFolderChanged(object sender, CurrentFolderChangedEventArgs e)
        {
            UpdateLogList();
        }

        private void ClearLogList()
        {
            try
            {
                string FolderPath = GetFolderLogPath(Common.RootFolder.CurrentFolder);
                DirectoryInfo DI = new DirectoryInfo(FolderPath);

                foreach (FileInfo FI in DI.GetFiles())
                {
                    FI.Delete();
                }
            }
            catch
            {
                MessageBox.Show(Resources.TxtErrorWhileClearingLogs, Resources.TxtTheDummyProgrammerRobot, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateLogList()
        {
            LstLog.Items.Clear();
            string FolderPath = GetFolderLogPath(Common.RootFolder.CurrentFolder);
            
            if (Directory.Exists(FolderPath))
            {
                LogFileWatcher.Path = FolderPath;

                string[] FileEntries = Directory.GetFiles(FolderPath);
                foreach (string FileName in FileEntries)
                {
                    FileInfo FI = new FileInfo(FileName);
                    LstLog.Items.Add(FI.Name);
                }
            }            
        }

        private void LogFileWatcher_Created(object sender, FileSystemEventArgs e)
        {
            LstLog.Items.Add(e.Name);
        }

        private void LogFileWatcher_Deleted(object sender, FileSystemEventArgs e)
        {
            for (int i = 0; i < LstLog.Items.Count; i++)
            {
                if (LstLog.Items[i].ToString() == e.Name)
                {
                    LstLog.Items.RemoveAt(i);
                    break;
                }
            }
        }

        private void LstLog_DoubleClick(object sender, EventArgs e)
        {
            if (LstLog.SelectedIndex >= 0)
            {
                try
                {
                    string FolderPath = GetFolderLogPath(Common.RootFolder.CurrentFolder);
                    System.Diagnostics.Process.Start(FolderPath + LstLog.SelectedItem.ToString());
                }
                catch
                {
                    MessageBox.Show(Resources.TxtErrorWhileOpeningLogFile, Resources.TxtTheDummyProgrammerRobot, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void MnuClearAll_Click(object sender, EventArgs e)
        {
            ClearLogList();
        }
    }
}
