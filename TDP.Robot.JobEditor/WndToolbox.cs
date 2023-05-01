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
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TDP.Robot.Core;

namespace TDP.Robot.JobEditor
{
    public partial class WndToolbox : Form
    {
        private int _LstPluginsItemHeight = 48;
        private int _LstPluginsItemMargin = 4;
        private int _LstPluginsItemTextMargin = 8;

        private List<IPlugin> _Plugins;
        private Rectangle _DragBoxFromMouseDown;
        private int _IndexOfItemToDrag;

        public List<IPlugin> Plugins 
        {
            get { return _Plugins; }
            
            set 
            {
                _Plugins = value;
                LstPlugins.ValueMember = "ID";
                LstPlugins.DisplayMember = "Title";
                LstPlugins.DataSource = _Plugins;
            } 
        } 

        public WndToolbox()
        {
            InitializeComponent();
            LstPlugins.ItemHeight = _LstPluginsItemHeight;
        }

        private void LstPlugins_MouseDown(object sender, MouseEventArgs e)
        {
            // Get the index of the item the mouse is below.
            _IndexOfItemToDrag = LstPlugins.IndexFromPoint(e.X, e.Y);

            if (_IndexOfItemToDrag != ListBox.NoMatches)
            {

                // Remember the point where the mouse down occurred. The DragSize indicates
                // the size that the mouse can move before a drag event should be started.                
                Size DragSize = SystemInformation.DragSize;

                // Create a rectangle using the DragSize, with the mouse position being
                // at the center of the rectangle.
                _DragBoxFromMouseDown = new Rectangle(new Point(e.X - (DragSize.Width / 2), e.Y - (DragSize.Height / 2)), DragSize);
            }
            else
            {
                // Reset the rectangle if the mouse is not over an item in the ListBox.
                _DragBoxFromMouseDown = Rectangle.Empty;
            }
        }

        private void LstPlugins_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                // If the mouse moves outside the rectangle, start the drag.
                if (_DragBoxFromMouseDown != Rectangle.Empty && !_DragBoxFromMouseDown.Contains(e.X, e.Y))
                {
                    IPlugin SelectedPlugin = (IPlugin)LstPlugins.Items[_IndexOfItemToDrag];
                    LstPlugins.DoDragDrop(SelectedPlugin.ID, DragDropEffects.Move);
                }
            }
        }

        private void LstPlugins_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0)
                return;

            e.DrawBackground();

            IPlugin ItemPlugin = (IPlugin)LstPlugins.Items[e.Index];
            e.Graphics.DrawIcon(ItemPlugin.PluginIcon, _LstPluginsItemMargin, e.Bounds.Y + (e.Bounds.Height - ItemPlugin.PluginIcon.Height) / 2);

            Brush ItemBrush;
            Point TextLocation = new Point(ItemPlugin.PluginIcon.Width + _LstPluginsItemTextMargin, e.Bounds.Y + (e.Bounds.Height - Convert.ToInt32(e.Graphics.MeasureString(ItemPlugin.Title, e.Font).Height)) / 2);

            if ((e.State & DrawItemState.Selected) > 0)
                ItemBrush = Brushes.White;
            else
                ItemBrush = Brushes.Black;

            e.Graphics.DrawString(ItemPlugin.Title, e.Font, ItemBrush, TextLocation);

            e.DrawFocusRectangle();
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtSearch.Text))
                LstPlugins.DataSource = _Plugins;
            else
                LstPlugins.DataSource = _Plugins.Where(t => t.Title.ToLower().Contains(TxtSearch.Text.ToLower())).ToList();
        }
    }
}
