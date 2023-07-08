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
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using TDP.Infrastructure.Workspace.Abstract;
using TDP.Robot.Core;
using TDP.Robot.JobEditor.Infrastructure.GraphicsHelper;
using TDP.Robot.JobEditor.Infrastructure.Workspace.Abstract;
using TDP.Robot.JobEditor.Properties;

namespace TDP.Robot.JobEditor.Infrastructure.Workspace
{
    [Serializable]
    class WorkspaceFolder : IWorkspaceFolder
    {
        private List<IWorkspaceItemBase> Items { get; } = new List<IWorkspaceItemBase>();
        public float NameHeight { get; set; }
        public int ID { get; set; }
        public Icon ItemIcon { get { return Resources.IcoFolder; } }

        private string _Name;
        public string Name 
        { 
            get
            {
                return _Name;
            } 
            set 
            {
                _Name = value;
                OnFolderNameChanged(new FolderNameChangedEventArgs(this));
            } 
        }
        
        
        public PointF Location { get; set; }
        public bool Selected { get; set; }
        public IPluginInstanceConfig PluginConfig { get; set; }
        public IWorkspaceFolder ParentFolder { get; set; }
        public IWorkspaceFolder RootFolder { get; set; }
        public int LastFolderID { get; set; }
        
        private IWorkspaceFolder _CurrentFolder;
        public IWorkspaceFolder CurrentFolder 
        { 
            get
            {
                return _CurrentFolder;
            }
            set
            {
                _CurrentFolder = value;
                OnCurrentFolderChanged(new CurrentFolderChangedEventArgs(_CurrentFolder));
            }
        }

        public WorkspaceFolder()
        {
        }

        public WorkspaceFolder(string name, PointF location)
        {
            _Name = name;
            Location = location;
        }

        [field: NonSerialized]
        public event ObjectsAddedDelegate ObjectsAdded;

        protected virtual void OnObjectsAdded(ObjectsAddedEventArgs e)
        {
            ObjectsAddedDelegate handler = ObjectsAdded;
            if (handler != null)
            {
                foreach (ObjectsAddedDelegate singleCast in handler.GetInvocationList())
                {
                    ISynchronizeInvoke syncInvoke = singleCast.Target as ISynchronizeInvoke;
                    if ((syncInvoke != null) && (syncInvoke.InvokeRequired))
                        syncInvoke.Invoke(singleCast, new object[] { this, e });
                    else
                        singleCast(this, e);
                }
            }

            if (RootFolder != null)
                Helpers.CallPrivateMethod(RootFolder, "OnObjectsAdded", new object[] { e });
        }

        [field: NonSerialized]
        public event ObjectsRemovedDelegate ObjectsRemoved;

        protected virtual void OnObjectsRemoved(ObjectsRemovedEventArgs e)
        {
            ObjectsRemovedDelegate handler = ObjectsRemoved;
            if (handler != null)
            {
                foreach (ObjectsRemovedDelegate singleCast in handler.GetInvocationList())
                {
                    ISynchronizeInvoke syncInvoke = singleCast.Target as ISynchronizeInvoke;
                    if ((syncInvoke != null) && (syncInvoke.InvokeRequired))
                        syncInvoke.Invoke(singleCast, new object[] { this, e });
                    else
                        singleCast(this, e);
                }
            }

            if (RootFolder != null)
                Helpers.CallPrivateMethod(RootFolder, "OnObjectsRemoved", new object[] { e });
        }

        [field: NonSerialized]
        public event CurrentFolderChangedDelegate CurrentFolderChanged;

        protected virtual void OnCurrentFolderChanged(CurrentFolderChangedEventArgs e)
        {
            CurrentFolderChangedDelegate handler = CurrentFolderChanged;
            if (handler != null)
            {
                foreach (CurrentFolderChangedDelegate singleCast in handler.GetInvocationList())
                {
                    ISynchronizeInvoke syncInvoke = singleCast.Target as ISynchronizeInvoke;
                    if ((syncInvoke != null) && (syncInvoke.InvokeRequired))
                        syncInvoke.Invoke(singleCast, new object[] { this, e });
                    else
                        singleCast(this, e);
                }
            }

            if (RootFolder != null)
                Helpers.CallPrivateMethod(RootFolder, "OnCurrentFolderChanged", new object[] { e });
        }

        [field: NonSerialized]
        public event FolderNameChangedDelegate FolderNameChanged;

        protected virtual void OnFolderNameChanged(FolderNameChangedEventArgs e)
        {
            FolderNameChangedDelegate handler = FolderNameChanged;
            if (handler != null)
            {
                foreach (FolderNameChangedDelegate singleCast in handler.GetInvocationList())
                {
                    ISynchronizeInvoke syncInvoke = singleCast.Target as ISynchronizeInvoke;
                    if ((syncInvoke != null) && (syncInvoke.InvokeRequired))
                        syncInvoke.Invoke(singleCast, new object[] { this, e });
                    else
                        singleCast(this, e);
                }
            }

            if (RootFolder != null)
                Helpers.CallPrivateMethod(RootFolder, "OnFolderNameChanged", new object[] { e });
        }

        public EnumHitTestResult HitTest(Point p)
        {
            Rectangle RectIcon = new Rectangle(StructConvert.ToPoint(GetIconPos()), new Size(ItemIcon.Width, ItemIcon.Height));
            if (RectIcon.Contains(p))
                return EnumHitTestResult.Body;
            
            RectangleF RectTitle = new RectangleF(Location.X, Location.Y + ItemIcon.Height, Config.ItemWidth, NameHeight);
            if (RectTitle.Contains(p))
                return EnumHitTestResult.Title;

            return EnumHitTestResult.Outside;
        }

        private PointF GetIconPos()
        {
            return new PointF(Location.X + ((Config.ItemWidth - ItemIcon.Width) / 2), Location.Y);
        }

        public void Draw(Graphics gr)
        {
            PointF IconPos = GetIconPos();
            gr.DrawIcon(ItemIcon, (int)IconPos.X, (int)IconPos.Y);

            PointF TextPos = new PointF(Location.X, Location.Y + ItemIcon.Height);
            using (Font ItemFont = new Font(FontFamily.GenericSansSerif, Config.ItemFontSize))
            {
                if (!Selected)
                    NameHeight = Drawing.DrawStringInColumn(gr, _Name, ItemFont, Brushes.Black, TextPos, Config.ItemWidth, false);
                else
                {
                    NameHeight = Drawing.DrawStringInColumn(gr, _Name, ItemFont, Brushes.White, TextPos, Config.ItemWidth, true);
                    RectangleF RectText = new RectangleF(TextPos, new SizeF(Config.ItemWidth, NameHeight));
                    gr.FillRectangle(Brushes.Blue, RectText);
                    Drawing.DrawStringInColumn(gr, _Name, ItemFont, Brushes.White, TextPos, Config.ItemWidth, false);
                }
            }
        }

        public override bool Equals(Object obj)
        {
            if (obj == null || !typeof(IWorkspaceItemBase).IsAssignableFrom(obj.GetType()))
                return false;

            return (ID == ((IWorkspaceItemBase)obj).ID);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public bool Equals(IWorkspaceItemBase other)
        {
            if (other == null)
                return false;

            return (ID == other.ID);
        }

        public IEnumerator<IWorkspaceItemBase> GetEnumerator()
        {
            return Items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Items.GetEnumerator();
        }

        public void Add(IWorkspaceItemBase item, bool overrideID = true)
        {
            if (overrideID)
            {
                item.ID = RootFolder != null ? ++RootFolder.LastFolderID : ++LastFolderID;
                if (item.PluginConfig != null)
                    item.PluginConfig.ID = item.ID;
            }
                
            item.RootFolder = RootFolder != null ? RootFolder : this;
            item.ParentFolder = this;
            
            if (string.IsNullOrEmpty(item.Name))
            {
                if (item is IWorkspaceFolder)
                    item.Name = $"{Resources.TxtFolder}_{item.ID}";
                else
                    item.Name = $"{Resources.TxtObject}_{item.ID}";
            }

            Items.Add(item);
            OnObjectsAdded(new ObjectsAddedEventArgs(this, new List<IWorkspaceItemBase>() { item }));
        }

        public void Remove(IWorkspaceItemBase item)
        {
            Items.Remove(item);
            OnObjectsRemoved(new ObjectsRemovedEventArgs(this, new List<IWorkspaceItemBase>() { item }));
        }

        public string GetFullPath()
        {
            IWorkspaceFolder Folder = this;
            string FullPath = string.Empty;
            
            while (Folder != null)
            {
                FullPath = Folder.Name + @"\" + FullPath;
                Folder = Folder.ParentFolder;
            }

            return Resources.TxtRoot + FullPath;
        }

        public string GetIDFullPath()
        {
            IWorkspaceFolder Folder = this;
            string FullPathID = string.Empty;

            while (Folder != null)
            {
                FullPathID = Folder.ID.ToString() + @"\" + FullPathID;
                Folder = Folder.ParentFolder;
            }

            return FullPathID;
        }
    }
}
