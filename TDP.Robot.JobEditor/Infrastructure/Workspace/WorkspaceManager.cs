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
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TDP.BaseServices.Infrastructure.DataValidation;
using TDP.Infrastructure.Workspace.Abstract;
using TDP.Robot.Core;
using TDP.Robot.Core.DynamicData;
using TDP.Robot.JobEditor.Infrastructure.GraphicsHelper;
using TDP.Robot.JobEditor.Infrastructure.Workspace.Abstract;
using TDP.Robot.JobEditor.Properties;

namespace TDP.Robot.JobEditor.Infrastructure.Workspace
{
    class ObjectDroppedEventArgs : EventArgs
    {
        public IWorkspaceFolder FolderData { get; set; }
        public string PluginID { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public ObjectDroppedEventArgs(IWorkspaceFolder folderData, string pluginID, int x, int y)
        {
            FolderData = folderData;
            PluginID = pluginID;
            X = x;
            Y = y;
        }
    }

    class WorkspaceManager
    {
        private class ItemInfo
        {
            internal IWorkspaceItemBase Item { get; set; }
            internal EnumHitTestResult HitTestValue { get; set; }
        }


        private Control _Container;
        private IWorkspaceFolder _RootFolder;
        
        private bool _CopyAndCut;
        private List<IWorkspaceItemBase> _CopyObjects;
        private IWorkspaceFolder _CopyFromFolder;

        private ContextMenu _ContextMenu;
        private MenuItem _MnuProperties;
        private MenuItem _MnuRename;
        private MenuItem _MnuCreateFolder;
        private MenuItem _MnuCut;
        private MenuItem _MnuCopy;
        private MenuItem _MnuPaste;
        private MenuItem _MnuDelete;

        private TextBox _TxtChangeName;
        private bool _ChangingName;

        private Point _ContextMenuPos;
        private ItemInfo _ContextLastClickedItemInfo;

        private bool _Moving;
        private bool _MoveInProgress;
        private PointF _MovingStartPos;
        private List<RectangleF> _MovingRectangles;
        private RectangleF[] _MovingPrevRects;

        private bool _AllowTitleChange;

        private bool _Selecting;
        private PointF _SelectingStartPos;
        private Rectangle? _SelectingPrevRect;

        private bool _Connecting;
        private WorkspaceItem _ConnectingStartItem;
        private PointF _ConnectingStartPos;
        private PointF? _ConnectingPrevEndPoint;

        public float CanvasWidth { get; set; }
        public float CanvasHeight { get; set; }

        public float WindowClientWidth { get; set; }
        public float WindowClientHeight { get; set; }



        public delegate void ObjectDroppedDelegate(object sender, ObjectDroppedEventArgs e);
        public event ObjectDroppedDelegate ObjectDropped;
        protected virtual void OnObjectDropped(ObjectDroppedEventArgs e)
        {
            ObjectDroppedDelegate handler = ObjectDropped;
            if (handler != null)
            {
                foreach (ObjectDroppedDelegate singleCast in handler.GetInvocationList())
                {
                    ISynchronizeInvoke syncInvoke = singleCast.Target as ISynchronizeInvoke;
                    if ((syncInvoke != null) && (syncInvoke.InvokeRequired))
                        syncInvoke.Invoke(singleCast, new object[] { this, e });
                    else
                        singleCast(this, e);
                }
            }
        }

        internal WorkspaceManager(Control container, IWorkspaceFolder _rootFolder)
        {
            _Container = container;
            _RootFolder = _rootFolder;
            _Container.Text = Resources.TxtWorkspace + " - " + _RootFolder.GetFullPath();
            _CopyObjects = new List<IWorkspaceItemBase>();

            _ContextMenu = BuildContextMenu();
            _ContextMenu.Popup += _ContextMenu_Popup;

            _TxtChangeName = new TextBox();
            _TxtChangeName.Multiline = true;
            _TxtChangeName.Visible = false;
            _TxtChangeName.KeyDown += _TxtChangeName_KeyDown;
            _TxtChangeName.MaxLength = Constants.NameMaxLength;
            _Container.Controls.Add(_TxtChangeName);


            _Container.DragDrop += _Container_DragDrop;
            _Container.DragOver += _Container_DragOver;
            _Container.MouseMove += _Container_MouseMove;
            _Container.MouseDown += _Container_MouseDown;
            _Container.MouseUp += _Container_MouseUp;
            _Container.MouseDoubleClick += _Container_MouseDoubleClick;
            _Container.Paint += _Container_Paint;
            _Container.KeyDown += _Container_KeyDown;

            _Container.AllowDrop = true;

            _MovingRectangles = new List<RectangleF>();

            UpdateCanvasSize();
        }

        private void UpdateCanvasSize()
        {
            CanvasHeight = 0;
            CanvasWidth = 0;
            IWorkspaceItemIcon AnIcon = null;
            Point InitialScrollPos = _Container.AutoScrollOffset;

            _RootFolder.CurrentFolder.Where(I => I is IWorkspaceItemBase)
                    .ToList().ForEach(I =>
                    {
                        if (I is IWorkspaceItemIcon)
                        {
                            IWorkspaceItemIcon IIcon = (IWorkspaceItemIcon)I;
                            if (AnIcon == null)
                                AnIcon = IIcon;

                            if ((IIcon.Location.X + IIcon.ItemIcon.Width + (Config.ItemHandleSize * 2)) > CanvasWidth)
                            {
                                CanvasWidth = IIcon.Location.X + IIcon.ItemIcon.Width + (Config.ItemHandleSize * 2);
                            }

                            if ((IIcon.Location.Y + IIcon.ItemIcon.Height + IIcon.NameHeight) > CanvasHeight)
                            {
                                CanvasHeight = IIcon.Location.Y + IIcon.ItemIcon.Height + IIcon.NameHeight;
                            }
                        }
                    });

            // Add more space...
            if (AnIcon != null)
            {
                CanvasWidth += AnIcon.ItemIcon.Width + (Config.ItemHandleSize * 2);
                CanvasHeight += AnIcon.ItemIcon.Height + AnIcon.NameHeight;
            }

            _Container.Width = Math.Max((int)CanvasWidth, (int)WindowClientWidth);
            _Container.Height = Math.Max((int)CanvasHeight, (int)WindowClientHeight);
            _Container.AutoScrollOffset = InitialScrollPos;
        }

        private ContextMenu BuildContextMenu()
        {
            ContextMenu CtxMenu = new ContextMenu();

            _MnuProperties = new MenuItem(Resources.TxtProperties);
            _MnuProperties.Click += MnuProperties_Click;
            CtxMenu.MenuItems.Add(_MnuProperties);

            _MnuRename = new MenuItem(Resources.TxtRename);
            _MnuRename.Shortcut = Shortcut.F2;
            _MnuRename.Click += _MnuRename_Click;
            CtxMenu.MenuItems.Add(_MnuRename);
            CtxMenu.MenuItems.Add("-");

            _MnuCreateFolder = new MenuItem(Resources.TxtCreateFolder);
            _MnuCreateFolder.Shortcut = Shortcut.CtrlF;
            _MnuCreateFolder.Click += MnuCreateFolder_Click;
            CtxMenu.MenuItems.Add(_MnuCreateFolder);

            CtxMenu.MenuItems.Add("-");

            _MnuCut = new MenuItem(Resources.TxtCut);
            _MnuCut.Shortcut = Shortcut.CtrlX;
            _MnuCut.Click += _MnuCut_Click;
            CtxMenu.MenuItems.Add(_MnuCut);

            _MnuCopy = new MenuItem(Resources.TxtCopy);
            _MnuCopy.Shortcut = Shortcut.CtrlC;
            _MnuCopy.Click += _MnuCopy_Click;
            CtxMenu.MenuItems.Add(_MnuCopy);

            _MnuPaste = new MenuItem(Resources.TxtPaste);
            _MnuPaste.Shortcut = Shortcut.CtrlV;
            _MnuPaste.Click += _MnuPaste_Click;
            CtxMenu.MenuItems.Add(_MnuPaste);

            _MnuDelete = new MenuItem(Resources.TxtDelete);
            _MnuDelete.Shortcut = Shortcut.Del;
            _MnuDelete.Click += MnuDelete_Click;
            CtxMenu.MenuItems.Add(_MnuDelete);

            return CtxMenu;
        }

        private List<DynamicDataObjectSamples> BuildDynamicDataObjectSamplesList(IWorkspaceFolder currentFolder)
        {
            List<DynamicDataObjectSamples> ObjectSamples = new List<DynamicDataObjectSamples>();

            foreach (IWorkspaceItemBase ItemBase in currentFolder)
            {
                if (ItemBase is IWorkspaceItem)
                {
                    IWorkspaceItem Item = (IWorkspaceItem)ItemBase;
                    IPlugin Plugin = Common.PluginDict[Item.PluginID];
                    DynamicDataObjectSamples ObjectSamplesItem = new DynamicDataObjectSamples(Item.ID, Item.Name, Plugin.PluginType, Plugin.SampleDynamicData);
                    ObjectSamples.Add(ObjectSamplesItem);
                }
            }

            return ObjectSamples;
        }

        private void _ContextMenu_Popup(object sender, EventArgs e)
        {
            // Check here which context menu items should be enabled
            bool SomeItemSelected = (_ContextLastClickedItemInfo != null && _ContextLastClickedItemInfo.Item != null);
            bool IsItem = SomeItemSelected && (_ContextLastClickedItemInfo.Item is IWorkspaceItem);
            bool IsFolder = SomeItemSelected && (_ContextLastClickedItemInfo.Item is IWorkspaceFolder);

            _MnuProperties.Enabled = SomeItemSelected && IsItem;
            _MnuRename.Enabled = SomeItemSelected && (IsItem || IsFolder);
            _MnuDelete.Enabled = SomeItemSelected;
            _MnuCut.Enabled = SomeItemSelected;
            _MnuCopy.Enabled = SomeItemSelected;
            _MnuPaste.Enabled = (_CopyObjects.Count > 0);
        }

        private void MnuCreateFolder_Click(object sender, EventArgs e)
        {
            CreateFolder();
        }

        private void MnuDelete_Click(object sender, EventArgs e)
        {
            ManageDeleteSelectedItems();
        }

        private void MnuProperties_Click(object sender, EventArgs e)
        {
            OpenProperties();
        }

        private void _MnuRename_Click(object sender, EventArgs e)
        {
            ChangeNameStart();
        }

        private void _MnuCut_Click(object sender, EventArgs e)
        {
            ManageCut();
        }

        private void _MnuCopy_Click(object sender, EventArgs e)
        {
            ManageCopy();
        }

        private void _MnuPaste_Click(object sender, EventArgs e)
        {
            ManagePaste();
        }

        private void OpenLineProperties()
        {
            if (_ContextLastClickedItemInfo != null
                && _ContextLastClickedItemInfo.Item != null
                && _ContextLastClickedItemInfo.HitTestValue == EnumHitTestResult.Body
                && _ContextLastClickedItemInfo.Item is IWorkspaceLine)
            {
                IWorkspaceLine Line = (IWorkspaceLine)_ContextLastClickedItemInfo.Item;
                IPlugin Plugin = Common.PluginDict[Line.StartItem.PluginID];
                
                using (WndLineProperties WndLineProp = new WndLineProperties())
                {
                    WndLineProp.Item = Line.StartItem;
                    WndLineProp.DynamicDataSampleList = Plugin.SampleDynamicData;
                    WndLineProp.ExecutionConditions = Line.ExecuteConditions;
                    WndLineProp.DontExecuteConditions = Line.DontExecuteConditions;
                    WndLineProp.Disable = Line.Disable;
                    WndLineProp.WaitSeconds = Line.WaitSeconds;
                    if (WndLineProp.ShowDialog() == DialogResult.OK)
                    {
                        Line.ExecuteConditions = WndLineProp.ExecutionConditions;
                        Line.DontExecuteConditions = WndLineProp.DontExecuteConditions;
                        Line.Disable = WndLineProp.Disable;
                        Line.WaitSeconds = WndLineProp.WaitSeconds;
                    }
                }
            }
        }

        private void OpenProperties()
        {
            if (_ContextLastClickedItemInfo != null
                && _ContextLastClickedItemInfo.Item != null
                && _ContextLastClickedItemInfo.HitTestValue == EnumHitTestResult.Body
                && _ContextLastClickedItemInfo.Item is IWorkspaceItem)
            {
                IWorkspaceItem Item = (IWorkspaceItem)_ContextLastClickedItemInfo.Item;
                IPlugin Plugin = Common.PluginDict[Item.PluginID];

                List<DynamicDataObjectSamples> DynDataObjectSampleList = BuildDynamicDataObjectSamplesList(_RootFolder.CurrentFolder);

                using (WndPluginConfigBase WndConfig = Plugin.GetConfigWindow(Item.PluginConfig, DynDataObjectSampleList))
                {
                    if (WndConfig.ShowDialog() == DialogResult.OK)
                    {
                        Item.Name = WndConfig.PluginConfig.Name;
                        Item.PluginConfig = WndConfig.PluginConfig;
                    }
                }

                RedrawContainer();
            }
        }

        private void CreateFolder()
        {
            Point DefaultLocation = new Point(Cursor.Position.X, Cursor.Position.Y);
            DefaultLocation = _Container.PointToClient(DefaultLocation);
            WorkspaceFolder WksFolder = new WorkspaceFolder(string.Empty, DefaultLocation);
            _RootFolder.CurrentFolder.Add(WksFolder);
            RedrawContainer();
        }

        private void ChangeFolder(IWorkspaceFolder folder)
        {
            _RootFolder.CurrentFolder = folder; 
        }

        private void ManageSelectAll()
        {
            SelectAllItems();
            RedrawContainer();
        }

        private void ManageDeleteSelectedItems()
        {
            if (MessageBox.Show(Resources.TxtDeleteSelectedItems, Resources.TxtTheDummyProgrammerRobot, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DeleteSelectedItems();
                RedrawContainer();
            }
        }

        private void ManageCut()
        {
            _CopyFromFolder = _RootFolder.CurrentFolder;
            _CopyAndCut = true;
            _CopyObjects.Clear();

            foreach (IWorkspaceItemBase Item in _RootFolder.CurrentFolder.Where(I => I.Selected))
            {
                _CopyObjects.Add(Item);
            }
        }

        private void ManageCopy()
        {
            _CopyFromFolder = _RootFolder.CurrentFolder;
            _CopyAndCut = false;
            _CopyObjects.Clear();

            foreach (IWorkspaceItemBase Item in _RootFolder.CurrentFolder.Where(I => I.Selected))
            {
                _CopyObjects.Add(Item);
            }
        }

        private void ManagePaste()
        {
            if (_CopyAndCut && _RootFolder.CurrentFolder.ID == _CopyFromFolder.ID)
            {
                MessageBox.Show(Resources.TxtCannotCutAndPasteSameFolder, Resources.TxtTheDummyProgrammerRobot, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Clone objects through serialization
            List<IWorkspaceItemBase> CopiedItems = WorkspacePersistence.CloneObjects(_CopyObjects);
            
            // Remove lines not present in _CopyObjects
            foreach (IWorkspaceItemBase I in CopiedItems)
            {
                if (I is IWorkspaceItem)
                {
                    IWorkspaceItem Item = (IWorkspaceItem)I;
                    int c = 0;
                    while (c < Item.ItemsIn.Count)
                    {
                        if (_CopyObjects.Where(t => t.ID == Item.ItemsIn[c].ID).FirstOrDefault() == null)
                            Item.ItemsIn.RemoveAt(c);
                        else
                            c++;
                    }

                    c = 0;
                    while (c < Item.ItemsOut.Count)
                    {
                        if (_CopyObjects.Where(t => t.ID == Item.ItemsOut[c].ID).FirstOrDefault() == null)
                            Item.ItemsOut.RemoveAt(c);
                        else
                            c++;
                    }
                }
            }

            if (CopiedItems.Count > 0)
            {
                // Calculate delta to translate copied objects positions
                float MinX, MinY;
                MinX = CopiedItems[0].Location.X;
                MinY = CopiedItems[0].Location.Y;

                foreach (IWorkspaceItemBase Item in CopiedItems)
                {
                    if (Item.Location.X < MinX)
                        MinX = Item.Location.X;
                    if (Item.Location.Y < MinY)
                        MinY = Item.Location.Y;
                }

                float DeltaX = (float)_ContextMenuPos.X - MinX;
                float DeltaY = (float)_ContextMenuPos.Y - MinY;

                foreach (IWorkspaceItemBase Item in CopiedItems)
                {
                    Item.Location = new PointF(Item.Location.X + DeltaX, Item.Location.Y + DeltaY);
                    _RootFolder.CurrentFolder.Add(Item, !_CopyAndCut);
                }

                if (_CopyAndCut)
                {
                    foreach (IWorkspaceItemBase Item in CopiedItems)
                    {
                        _CopyFromFolder.Remove(Item);
                    }
                }

                RedrawContainer();
                UpdateCanvasSize();
            }
        }

        public void ManageKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A && e.Control)
            {
                ManageSelectAll();
            }
            else if (e.KeyCode == Keys.F && e.Control)
            {
                CreateFolder();
            }
            else if (e.KeyCode == Keys.X && e.Control)
            {
                ManageCut();
            }
            else if (e.KeyCode == Keys.C && e.Control)
            {
                ManageCopy();
            }
            else if (e.KeyCode == Keys.V && e.Control)
            {
                ManagePaste();
            }
            else if (e.KeyCode == Keys.Delete)
            {
                ManageDeleteSelectedItems();
            }
            else if (e.KeyCode == Keys.F2)
            {
                ChangeNameStart();
            }
        }

        private void _Container_KeyDown(object sender, KeyEventArgs e)
        {
            ManageKeyDown(e);
        }

        private string GetDroppedPluginID(DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(string)))
            {
                string PluginID = e.Data.GetData(typeof(string)) as string;
                if (PluginID != null && Common.PluginDict.ContainsKey(PluginID))
                {
                    return PluginID;
                }
            }

            return null;
        }

        private void SetCursor(Cursor cursor)
        {
            if (Cursor.Current != null)
                Cursor.Current = cursor;
        }

        private void SelectAllItems()
        {
            _RootFolder.CurrentFolder.Where(I => I is IWorkspaceItem).ToList().ForEach(I => I.Selected = true);
        }

        private void SelectItemsInRectangle(RectangleF rect)
        {
            _RootFolder.CurrentFolder.Where(I =>
            {
                if (I is IWorkspaceItemIcon)
                {
                    IWorkspaceItemIcon Item = (IWorkspaceItemIcon)I;
                    RectangleF IconRect = new RectangleF(Item.Location.X, Item.Location.Y, Config.ItemWidth, Item.ItemIcon.Height);
                    if (rect.IntersectsWith(IconRect))
                        return true;
                }
                else if (I is WorkspaceLine)
                {
                    IWorkspaceLine Line = (WorkspaceLine)I;
                    if (Helpers.LineIntersectsRect(StructConvert.ToPoint(Line.Location), 
                                                    StructConvert.ToPoint(Line.LocationEnd), 
                                                    StructConvert.ToRectangle(rect)))
                        return true;
                }
                
                return false;
            }).ToList().ForEach(I => { I.Selected = true; });
        }

        private void UnselectAllItems()
        {
            foreach (IWorkspaceItemBase I in _RootFolder.CurrentFolder)
            {
                I.Selected = false;
            }
        }

        private void MoveSelectedItems(float offsetX, float offsetY)
        {
            _RootFolder.CurrentFolder.Where(I => I is IWorkspaceItemIcon && I.Selected).ToList().ForEach(I => { I.Location = new PointF(I.Location.X + offsetX, I.Location.Y + offsetY); });
        }

        private void DeleteItem(int id)
        {
            IWorkspaceItemBase ItemBase = _RootFolder.CurrentFolder.Where(I => I.ID == id).FirstOrDefault();
            if (ItemBase == null)
                return;

            _RootFolder.CurrentFolder.Remove(ItemBase);

            if (ItemBase is IWorkspaceLine)
            {
                IWorkspaceLine Line = (IWorkspaceLine)ItemBase;
                Line.StartItem.ItemsOut.Remove(Line);
                Line.EndItem.ItemsIn.Remove(Line);
            }
            else if (ItemBase is IWorkspaceItem)
            {
                IWorkspaceItem Item = (IWorkspaceItem)ItemBase;
                foreach (IWorkspaceLine Line in Item.ItemsIn.ToList())
                    DeleteItem(Line.ID);
                foreach (IWorkspaceLine Line in Item.ItemsOut.ToList())
                    DeleteItem(Line.ID);
            }

            UpdateCanvasSize();
        }

        private void DeleteSelectedItems()
        {
            List<IWorkspaceItemBase> SelectedItems = _RootFolder.CurrentFolder.Where(I => I.Selected).ToList();
            foreach (IWorkspaceItemBase Item in SelectedItems)
            {
                DeleteItem(Item.ID);
            }

            UpdateCanvasSize();
        }

        private void RedrawContainer()
        {
            _Container.Refresh();
        }

        private void DrawSelectionRectangle(RectangleF rect, bool redrawPreviousRect)
        {
            // Remove the previous rectangle and draw the new selection
            if (redrawPreviousRect && _SelectingPrevRect != null)
                Drawing.DrawXORRectangle(_Container, (Rectangle)_SelectingPrevRect);

            Rectangle Rect = StructConvert.ToRectangle(rect);
            Drawing.DrawXORRectangle(_Container, Rect);
            _SelectingPrevRect = Rect;
        }

        private void DrawMovingRectangles(RectangleF[] rect, bool redrawPreviousRects)
        {
            // Remove the previous rectangles and draw the new ones
            if (redrawPreviousRects && _MovingPrevRects != null)
                Drawing.DrawXORRectangles(_Container, _MovingPrevRects);

            Drawing.DrawXORRectangles(_Container, rect);
            _MovingPrevRects = rect;
        }

        private void DrawConnectingLine(PointF startPoint, PointF endPoint, bool redrawPreviousLine)
        {
            // Remove the previous rectangles and draw the new ones
            if (redrawPreviousLine && _ConnectingPrevEndPoint != null)
            {
                PointF Pt = (PointF)_ConnectingPrevEndPoint;
                Drawing.DrawXORLine(_Container, (int)startPoint.X, (int)startPoint.Y, (int)Pt.X, (int)Pt.Y);
            }

            Drawing.DrawXORLine(_Container, (int)startPoint.X, (int)startPoint.Y, (int)endPoint.X, (int)endPoint.Y);
            _ConnectingPrevEndPoint = endPoint;
        }

        private void _Container_DragOver(object sender, DragEventArgs e)
        {
            string PluginID = GetDroppedPluginID(e);
            if (PluginID == null)
                e.Effect = DragDropEffects.None;

            e.Effect = DragDropEffects.Move;
        }

        private void _Container_DragDrop(object sender, DragEventArgs e)
        {
            string PluginID = GetDroppedPluginID(e);
            if (PluginID != null)
            {
                Point Pt = _Container.PointToClient(new Point(e.X, e.Y));
                ObjectDroppedEventArgs EA = new ObjectDroppedEventArgs(_RootFolder.CurrentFolder, PluginID, Pt.X, Pt.Y);
                OnObjectDropped(EA);

                IPlugin Plugin = Common.PluginDict[PluginID];
                bool AllowItemsIn = (Plugin.PluginType == EnumPluginType.Task);
                PointF DefaultLocation = new PointF(Pt.X, Pt.Y);
                IPluginInstanceConfig DefaultConfig = Plugin.GetPluginDefaultConfig();
                WorkspaceItem NewItem = new WorkspaceItem(PluginID, Plugin.PluginIcon, AllowItemsIn, string.Empty, DefaultLocation, DefaultConfig);
                _RootFolder.CurrentFolder.Add(NewItem);
                NewItem.Name = Plugin.Title + "_" + NewItem.ID.ToString();
                DefaultConfig.Name = NewItem.Name;

                RedrawContainer();
            }
        }

        private ItemInfo GetItemByPosition(Point pos)
        {
            IWorkspaceItemBase Item = _RootFolder.CurrentFolder.Where(I => I.HitTest(pos) != EnumHitTestResult.Outside).FirstOrDefault();
            EnumHitTestResult HitTestValue = EnumHitTestResult.Outside;

            if (Item != null)
                HitTestValue = Item.HitTest(pos);

            ItemInfo IF = new ItemInfo();
            IF.Item = Item;
            IF.HitTestValue = HitTestValue;
            return IF;
        }

        private void SelectStart(Point pos)
        {
            _Selecting = true;
            _SelectingStartPos = pos;
        }

        private void SelectInProgress(Point pos)
        {
            // Object selection in progress...
            // Draw the selection rectangle
            RectangleF Rect = new RectangleF(Math.Min((int)_SelectingStartPos.X, pos.X),
                                Math.Min((int)_SelectingStartPos.Y, pos.Y),
                                Math.Abs(pos.X - (int)_SelectingStartPos.X),
                                Math.Abs(pos.Y - (int)_SelectingStartPos.Y));

            DrawSelectionRectangle(Rect, true);
        }

        private void SelectEnd()
        {
            // Stop objects selection...
            _Selecting = false;

            if (_SelectingPrevRect != null)
            {
                RectangleF Rect = StructConvert.ToRectangleF(_SelectingPrevRect);
                SelectItemsInRectangle(Rect);
                DrawSelectionRectangle(Rect, false);
            }

            RedrawContainer();
            _SelectingPrevRect = null;
        }

        private void MoveStart(Point pos)
        {
            // Object moving starting...
            _Moving = true;
            _MovingStartPos = pos;
            _MovingRectangles.Clear();

            // Prepare the 'shadow' rectangles now, they will be drawn in mouse move
            var SelectedItemsPos = _RootFolder.CurrentFolder.Where(I => I is IWorkspaceItemIcon && I.Selected == true).Select(I => new { I.Location, ((IWorkspaceItemIcon)I).ItemIcon.Height });
            foreach (var ItemPos in SelectedItemsPos)
            {
                _MovingRectangles.Add(new RectangleF(ItemPos.Location.X, ItemPos.Location.Y, Config.ItemWidth, ItemPos.Height));
            }
        }

        private void MoveInProgress(Point pos)
        {
            _MoveInProgress = true;
            // Object moving in progress...
            // Draw moving shadows, modify offset of moving rectangles depending on mouse current position
            RectangleF[] Rectangles = new RectangleF[_MovingRectangles.Count];
            int Idx = 0;
            foreach (RectangleF rect in _MovingRectangles)
            {
                rect.Offset(pos.X - _MovingStartPos.X, pos.Y - _MovingStartPos.Y);
                Rectangles[Idx] = rect;
                Idx++;
            }

            DrawMovingRectangles(Rectangles, true);
        }

        private void MoveEnd(Point pos)
        {
            // Stop objects moving...
            _Moving = false;
            _MoveInProgress = false;

            if (_MovingPrevRects != null)
            {
                DrawMovingRectangles(_MovingPrevRects, false);
            }

            MoveSelectedItems(pos.X - _MovingStartPos.X, pos.Y - _MovingStartPos.Y);

            RedrawContainer();
            _MovingPrevRects = null;

            _MovingRectangles.Clear();
            var SelectedItemsPos = _RootFolder.CurrentFolder.Where(I => I is IWorkspaceItemIcon && I.Selected == true).Select(I => new { I.Location, ((IWorkspaceItemIcon)I).ItemIcon.Height });
            foreach (var ItemPos in SelectedItemsPos)
            {
                _MovingRectangles.Add(new RectangleF(ItemPos.Location.X, ItemPos.Location.Y, Config.ItemWidth, ItemPos.Height));
            }
        }

        private void ConnectStart(ItemInfo itemInfo)
        {
            // The user clicked a right handle
            SetCursor(Cursors.Cross);

            // Object connection starting...
            _Connecting = true;
            _ConnectingStartPos = ((WorkspaceItem)itemInfo.Item).GetRightHandleCenterPos();
            _ConnectingStartItem = (WorkspaceItem)itemInfo.Item;
        }

        private void ConnectInProgress(Point pos)
        {
            // Object connection in progress...
            // Draw the connection line
            DrawConnectingLine(_ConnectingStartPos, pos, true);
        }

        private void ConnectEnd(Point pos)
        {
            // Stop connecting...
            _Connecting = false;

            if (_ConnectingPrevEndPoint != null)
            {
                DrawConnectingLine(_ConnectingStartPos, pos, false);
            }

            // Detect where the mouse pointer is
            ItemInfo ItemInfo = GetItemByPosition(pos);
            if (ItemInfo.Item is WorkspaceItem 
                    && (ItemInfo.HitTestValue == EnumHitTestResult.LeftHandle || ItemInfo.HitTestValue == EnumHitTestResult.Body || ItemInfo.HitTestValue == EnumHitTestResult.Title)
                    && ((WorkspaceItem)ItemInfo.Item).AllowItemsIn
                    && !ConnectionExists(_ConnectingStartItem, (WorkspaceItem)ItemInfo.Item))
            {
                WorkspaceLine WL = new WorkspaceLine();
                WL.StartItem = _ConnectingStartItem;
                WL.EndItem = (WorkspaceItem)ItemInfo.Item;
                WL.StartItem.ItemsOut.Add(WL);
                WL.EndItem.ItemsIn.Add(WL);
                WL.ExecuteConditions.Add(new WorkspaceExecCondition(WL.StartItem, null, EnumExecutionConditionOperator.ObjectExecutes, null, null));
                _RootFolder.CurrentFolder.Add(WL);
            }

            _ConnectingPrevEndPoint = null;
            _ConnectingStartItem = null;
        

            SetCursor(Cursors.Default);
            RedrawContainer();
        }

        private bool ConnectionExists(WorkspaceItem startItem, WorkspaceItem endItem)
        {
            WorkspaceLine WL = _RootFolder.CurrentFolder.Where(I => I is WorkspaceLine
                                    && ((WorkspaceLine)I).StartItem == startItem
                                    && ((WorkspaceLine)I).EndItem == endItem).FirstOrDefault() as WorkspaceLine;

            return (WL != null);
        }

        private void _Container_MouseDown(object sender, MouseEventArgs e)
        {
            // Detect where the mouse pointer is
            ItemInfo ItemInfo = GetItemByPosition(e.Location);
            _ContextLastClickedItemInfo = ItemInfo;

            if (_ChangingName)
            {
                ChangeNameCancel();
            }

            if (e.Button == MouseButtons.Left)
            {
                if (ItemInfo.Item == null)
                {
                    // The user clicked the window area, unselect all
                    UnselectAllItems();
                    RedrawContainer();

                    // Object selection starting...
                    SelectStart(e.Location);
                }
                else if ((ItemInfo.HitTestValue == EnumHitTestResult.Body || ItemInfo.HitTestValue == EnumHitTestResult.Title) && ItemInfo.Item.Selected)
                {
                    // The user clicked an item already selected
                    // In this case do nothing because (maybe) an object move is about to start...
                    MoveStart(e.Location);

                    if (_RootFolder.CurrentFolder.Where(I => I.Selected).Count() == 1)
                        _AllowTitleChange = true;
                }
                else if (ItemInfo.HitTestValue == EnumHitTestResult.RightHandle)
                {
                    // The user is starting a new connectino between objects
                    ConnectStart(ItemInfo);
                }
                else if (ItemInfo.HitTestValue == EnumHitTestResult.Body || ItemInfo.HitTestValue == EnumHitTestResult.Title)
                {
                    // The user clicked an unselected item
                    // unselect all and select the item which was clicked 
                    UnselectAllItems();

                    SetCursor(Cursors.SizeAll);
                    ItemInfo.Item.Selected = true;
                    RedrawContainer();

                    // In this case do nothing because (maybe) an object move is about to start...
                    MoveStart(e.Location);
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                if (ItemInfo.Item == null)
                {
                    // The user clicked the window area, unselect all
                    UnselectAllItems();
                    RedrawContainer();
                }
                else if ((ItemInfo.HitTestValue == EnumHitTestResult.Body || ItemInfo.HitTestValue == EnumHitTestResult.Title) && ItemInfo.Item.Selected)
                {
                    // Do nothing
                }
                else if (ItemInfo.HitTestValue == EnumHitTestResult.Body || ItemInfo.HitTestValue == EnumHitTestResult.Title)
                {
                    // Select the item clicked
                    UnselectAllItems();
                    ItemInfo.Item.Selected = true;
                    RedrawContainer();
                }

                _ContextMenuPos = new Point(e.X, e.Y);
                _ContextMenu.Show(_Container, _ContextMenuPos);
            }
        }

        private void _Container_MouseMove(object sender, MouseEventArgs e)
        {
            //System.Diagnostics.Debug.WriteLine("Starting _Container_MouseMove() ...");

            ItemInfo ItemInfo = GetItemByPosition(e.Location);

            if (_Moving)
            {
                MoveInProgress(e.Location);
            }
            else if (_Selecting)
            {
                SelectInProgress(e.Location);
            }
            else if (_Connecting)
            {
                ConnectInProgress(e.Location);
            }
            else if (e.Button == MouseButtons.None)
            {
                if (ItemInfo.Item != null)
                {
                    if (ItemInfo.HitTestValue == EnumHitTestResult.Body || ItemInfo.HitTestValue == EnumHitTestResult.Title)
                        SetCursor(Cursors.SizeAll);
                    else if (ItemInfo.HitTestValue == EnumHitTestResult.RightHandle)
                        SetCursor(Cursors.Cross);
                    else
                        SetCursor(Cursors.Default);
                }
                else
                    SetCursor(Cursors.Default);
            }
            
            //System.Diagnostics.Debug.WriteLine("Ending _Container_MouseMove() ...");
        }

        private void _Container_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (_Selecting)
                {
                    SelectEnd();
                }
                else if (_Moving && _MoveInProgress)
                {
                    MoveEnd(e.Location);

                    UpdateCanvasSize();
                }
                else if (_Moving)
                {
                    _Moving = false;
                    _MoveInProgress = false;

                    if (_ContextLastClickedItemInfo.HitTestValue == EnumHitTestResult.Title && _AllowTitleChange)
                    {
                        ChangeNameStart();
                    }

                    _AllowTitleChange = false;
                }
                else if (_Connecting)
                {
                    ConnectEnd(e.Location);
                }
            }
        }

        private void _Container_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (_ContextLastClickedItemInfo != null 
                && _ContextLastClickedItemInfo.Item != null
                && _ContextLastClickedItemInfo.HitTestValue == EnumHitTestResult.Body)
            {
                if (_ContextLastClickedItemInfo.Item is IWorkspaceFolder)
                {
                    ChangeFolder(((IWorkspaceFolder)_ContextLastClickedItemInfo.Item));
                }
                else if (_ContextLastClickedItemInfo.Item is IWorkspaceLine)
                {
                    OpenLineProperties();
                }
                else if (_ContextLastClickedItemInfo.Item is IWorkspaceItem)
                {
                    OpenProperties();
                }
            }
        }

        private void _Container_Paint(object sender, PaintEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Starting _Container_Paint() ...");

            //if (_RootFolder.CurrentFolder != null)
            _RootFolder.CurrentFolder.Where(I => I is IWorkspaceItemBase)
                    .ToList().ForEach(I =>
                    {
                        I.Draw(e.Graphics);
                    });

            System.Diagnostics.Debug.WriteLine("Ending _Container_Paint() ...");
        }

        private void ChangeNameStart()
        {
            if (_ContextLastClickedItemInfo != null
                                    && _ContextLastClickedItemInfo.Item != null
                                    && _ContextLastClickedItemInfo.Item is IWorkspaceItemIcon)
            {
                _ChangingName = true;

                IWorkspaceItemIcon ItemIconSelected = (IWorkspaceItemIcon)_ContextLastClickedItemInfo.Item;
                _TxtChangeName.Location = StructConvert.ToPoint(new PointF(ItemIconSelected.Location.X, ItemIconSelected.Location.Y + ItemIconSelected.ItemIcon.Height));
                _TxtChangeName.Size = StructConvert.ToSize(new SizeF(Config.ItemWidth, ItemIconSelected.NameHeight + 5));
                _TxtChangeName.Text = ItemIconSelected.Name;
                _TxtChangeName.Visible = true;
                _TxtChangeName.SelectAll();
                _TxtChangeName.Focus();
            }
        }

        private void ChangeNameCancel()
        {
            _ChangingName = false;
            _TxtChangeName.Visible = false;
            _Container.Focus();
        }

        private void ChangeNameConfirm()
        {
            if (DataValidationHelper.IsEmptyString(_TxtChangeName.Text))
            {
                MessageBox.Show(Resources.TxtYouMustEnterAName, Resources.TxtTheDummyProgrammerRobot, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _ChangingName = false;
            _TxtChangeName.Visible = false;
            _ContextLastClickedItemInfo.Item.Name = _TxtChangeName.Text;
            if (_ContextLastClickedItemInfo.Item.PluginConfig != null)
                _ContextLastClickedItemInfo.Item.PluginConfig.Name = _TxtChangeName.Text;
            _Container.Focus();
            RedrawContainer();
        }

        private void _TxtChangeName_KeyDown(object sender, KeyEventArgs e)
        {
            if (!_ChangingName)
                return;

            if (e.KeyCode == Keys.Escape)
                ChangeNameCancel();
            else if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
                ChangeNameConfirm();
        }

        public void Refresh()
        {
            RedrawContainer();
        }
    }
}
