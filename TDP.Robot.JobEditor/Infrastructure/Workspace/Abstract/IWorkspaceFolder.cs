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
using System.Collections.Generic;

namespace TDP.Robot.JobEditor.Infrastructure.Workspace.Abstract
{
    class ObjectsAddedEventArgs : EventArgs
    {
        public IWorkspaceFolder Folder { get; set; }
        public List<IWorkspaceItemBase> ObjectsAdded { get; }

        public ObjectsAddedEventArgs(IWorkspaceFolder folder, List<IWorkspaceItemBase> objectsAdded)
        {
            Folder = folder;
            ObjectsAdded = objectsAdded;
        }
    }

    class ObjectsRemovedEventArgs : EventArgs
    {
        public IWorkspaceFolder Folder { get; set; }
        public List<IWorkspaceItemBase> ObjectsRemoved { get; }

        public ObjectsRemovedEventArgs(IWorkspaceFolder folder, List<IWorkspaceItemBase> objectsRemoved)
        {
            Folder = folder;
            ObjectsRemoved = objectsRemoved;
        }
    }

    class CurrentFolderChangedEventArgs : EventArgs
    {
        public IWorkspaceFolder Folder { get; set; }

        public CurrentFolderChangedEventArgs(IWorkspaceFolder folder)
        {
            Folder = folder;
        }
    }

    class FolderNameChangedEventArgs : EventArgs
    {
        public IWorkspaceFolder Folder { get; set; }

        public FolderNameChangedEventArgs(IWorkspaceFolder folder)
        {
            Folder = folder;
        }
    }

    delegate void ObjectsAddedDelegate(object sender, ObjectsAddedEventArgs e);

    delegate void ObjectsRemovedDelegate(object sender, ObjectsRemovedEventArgs e);

    delegate void CurrentFolderChangedDelegate(object sender, CurrentFolderChangedEventArgs e);

    delegate void FolderNameChangedDelegate(object sender, FolderNameChangedEventArgs e);

    interface IWorkspaceFolder : IWorkspaceItemIcon, IEnumerable<IWorkspaceItemBase>
    {
        int LastFolderID { get; set; }                  // Should be used only with root folder
        IWorkspaceFolder CurrentFolder { get; set; }    // Should be used only with root folder

        void Add(IWorkspaceItemBase item, bool overrideID = true);
        void Remove(IWorkspaceItemBase item);
        string GetFullPath();
        string GetIDFullPath();

        event ObjectsAddedDelegate ObjectsAdded;

        event ObjectsRemovedDelegate ObjectsRemoved;

        event CurrentFolderChangedDelegate CurrentFolderChanged;

        event FolderNameChangedDelegate FolderNameChanged;
    }
}
