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

using System;
using System.Collections.Generic;
using System.Drawing;
using TDP.Infrastructure.Workspace.Abstract;
using TDP.Robot.Core;
using TDP.Robot.JobEditor.Infrastructure.GraphicsHelper;
using TDP.Robot.JobEditor.Infrastructure.Workspace.Abstract;

namespace TDP.Robot.JobEditor.Infrastructure.Workspace
{
    [Serializable]
    class WorkspaceItem : IWorkspaceItem
    {
        public float NameHeight { get; set; }
        public int ID { get; set; }
        public Icon ItemIcon { get; }
        public bool AllowItemsIn { get; }
        public string PluginID { get; }
        public EnumPluginType PluginType { get; }

        public List<IWorkspaceLine> ItemsIn { get; } = new List<IWorkspaceLine>(); 

        public List<IWorkspaceLine> ItemsOut { get; } = new List<IWorkspaceLine>();

        public string Name { get; set; }
        public PointF Location { get; set; }
        public bool Selected { get; set; }
        public IPluginInstanceConfig PluginConfig { get; set; }
        public IWorkspaceFolder ParentFolder { get; set; }
        public IWorkspaceFolder RootFolder { get; set; }

        public WorkspaceItem(string pluginID, Icon itemIcon, bool allowsItemIn, string name, PointF location, IPluginInstanceConfig config)
        {
            PluginID = pluginID;
            ItemIcon = itemIcon;
            AllowItemsIn = allowsItemIn;
            Name = name;
            Location = location;
            PluginConfig = config;
        }

        public EnumHitTestResult HitTest(Point p)
        {
            Rectangle RectIcon = new Rectangle(StructConvert.ToPoint(GetIconPos()), new Size(ItemIcon.Width, ItemIcon.Height));
            if (RectIcon.Contains(p))
                return EnumHitTestResult.Body;

            RectangleF RectTitle = new RectangleF(Location.X, Location.Y + ItemIcon.Height, Config.ItemWidth, NameHeight);
            if (RectTitle.Contains(p))
                return EnumHitTestResult.Title;

            Rectangle RectLeftHandlePos = new Rectangle(StructConvert.ToPoint(GetLeftHandlePos()), new Size((int)Config.ItemHandleSize, (int)Config.ItemHandleSize));
            if (RectLeftHandlePos.Contains(p))
                return EnumHitTestResult.LeftHandle;

            Rectangle RectRightHandlePos = new Rectangle(StructConvert.ToPoint(GetRightHandlePos()), new Size((int)Config.ItemHandleSize, (int)Config.ItemHandleSize));
            if (RectRightHandlePos.Contains(p))
                return EnumHitTestResult.RightHandle;

            return EnumHitTestResult.Outside;
        }

        private PointF GetIconPos()
        {
            return new PointF(Location.X + ((Config.ItemWidth - ItemIcon.Width) / 2), Location.Y);
        }

        private PointF GetLeftHandlePos()
        {
            PointF IconPos = GetIconPos();
            return new PointF(IconPos.X - Config.ItemHandleDistance - Config.ItemHandleSize, IconPos.Y + ((ItemIcon.Height - Config.ItemHandleSize) / 2));
        }

        private PointF GetRightHandlePos()
        {
            PointF IconPos = GetIconPos();
            return new PointF(IconPos.X + ItemIcon.Width + Config.ItemHandleDistance, IconPos.Y + ((ItemIcon.Height - Config.ItemHandleSize) / 2));
        }

        public PointF GetLeftHandleCenterPos()
        {
            PointF LeftHandlePos = GetLeftHandlePos();
            return new PointF(LeftHandlePos.X + (Config.ItemHandleSize / 2) , LeftHandlePos.Y + (Config.ItemHandleSize / 2));
        }

        public PointF GetRightHandleCenterPos()
        {
            PointF RightHandlePos = GetRightHandlePos();
            return new PointF(RightHandlePos.X + (Config.ItemHandleSize / 2), RightHandlePos.Y + (Config.ItemHandleSize / 2));
        }

        public void Draw(Graphics gr)
        {
            PointF IconPos = GetIconPos();
            gr.DrawIcon(ItemIcon, (int)IconPos.X, (int)IconPos.Y);

            if (AllowItemsIn)
            {
                PointF LeftHandlePos = GetLeftHandlePos();
                Rectangle RectLeftHandle = new Rectangle((int)LeftHandlePos.X, (int)LeftHandlePos.Y, (int)Config.ItemHandleSize, (int)Config.ItemHandleSize);
                gr.DrawRectangle(Pens.Black, RectLeftHandle);
            }

            PointF RightHandlePos = GetRightHandlePos();
            Rectangle RectRightHandle = new Rectangle((int)RightHandlePos.X, (int)RightHandlePos.Y, (int)Config.ItemHandleSize, (int)Config.ItemHandleSize);
            gr.DrawRectangle(Pens.Black, RectRightHandle);

            PointF TextPos = new PointF(Location.X, Location.Y + ItemIcon.Height);
            using (Font ItemFont = new Font(FontFamily.GenericSansSerif, Config.ItemFontSize))
            {
                if (!Selected)
                    NameHeight = Drawing.DrawStringInColumn(gr, Name, ItemFont, Brushes.Black, TextPos, Config.ItemWidth, false);
                else
                {
                    NameHeight = Drawing.DrawStringInColumn(gr, Name, ItemFont, Brushes.White, TextPos, Config.ItemWidth, true);
                    RectangleF RectText = new RectangleF(TextPos, new SizeF(Config.ItemWidth, NameHeight));
                    gr.FillRectangle(Brushes.Blue, RectText);
                    Drawing.DrawStringInColumn(gr, Name, ItemFont, Brushes.White, TextPos, Config.ItemWidth, false);
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
    }
}
