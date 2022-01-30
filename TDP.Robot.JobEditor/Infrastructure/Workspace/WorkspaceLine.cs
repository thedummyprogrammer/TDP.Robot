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
using System.Collections.Generic;
using System.Drawing;
using TDP.Infrastructure.Workspace.Abstract;
using TDP.Robot.Core;
using TDP.Robot.JobEditor.Infrastructure.GraphicsHelper;
using TDP.Robot.JobEditor.Infrastructure.Workspace.Abstract;

namespace TDP.Robot.JobEditor.Infrastructure.Workspace
{
    [Serializable]
    class WorkspaceLine : IWorkspaceLine
    {
        public bool Disable { get; set; }
        public int ID { get; set; }
        public PointF LocationEnd { get; set; }
        public IWorkspaceItem StartItem { get; set; }
        public IWorkspaceItem EndItem { get; set; }
        public string Name { get; set; }
        public PointF Location { get; set; }
        public bool Selected { get; set; }
        public IPluginInstanceConfig PluginConfig { get; set; }
        public IWorkspaceFolder ParentFolder { get; set; }
        public IWorkspaceFolder RootFolder { get; set; }

        public List<IWorkspaceExecCondition> ExecuteConditions { get; set; }
        public List<IWorkspaceExecCondition> DontExecuteConditions { get; set; }
        public int? WaitSeconds { get; set; }

        public WorkspaceLine()
        {
            ExecuteConditions = new List<IWorkspaceExecCondition>();
            DontExecuteConditions = new List<IWorkspaceExecCondition>();
        }

        public EnumHitTestResult HitTest(Point p)
        {
            // Check for vertically or horizontally aligned points with some tolerance (ConnectionLineDetectPrecision parameter)
            PointF CurrentPoint = StructConvert.ToPointF(p);

            if (Math.Abs(LocationEnd.Y - Location.Y) <= Config.ConnectionLineDetectPrecision)
            {
                if (CurrentPoint.Y >= Math.Min(Location.Y, LocationEnd.Y)
                    && CurrentPoint.Y <= Math.Max(Location.Y, LocationEnd.Y)
                    && CurrentPoint.X >= Math.Min(Location.X, LocationEnd.X) 
                    && CurrentPoint.X <= Math.Max(Location.X, LocationEnd.X))
                {
                    return EnumHitTestResult.Body;
                }
            }

            if (Math.Abs(LocationEnd.X - Location.X) <= Config.ConnectionLineDetectPrecision)
            {
                if (CurrentPoint.X >= Math.Min(Location.X, LocationEnd.X)
                    && CurrentPoint.X <= Math.Max(Location.X, LocationEnd.X)
                    && CurrentPoint.Y >= Math.Min(Location.Y, LocationEnd.Y) 
                    && CurrentPoint.Y <= Math.Max(Location.Y, LocationEnd.Y))
                {
                    return EnumHitTestResult.Body;
                }
            }


            // Calculate angular coefficient (M) and distance from the center (C) of the rect
            // Then check if the point is in the rect with some tolerance (ConnectionLineDetectPrecision parameter)
            float M = (LocationEnd.Y - Location.Y) / (LocationEnd.X - Location.X);
            float C = LocationEnd.Y - (M * LocationEnd.X);

            if (CurrentPoint.X >= Math.Min(Location.X, LocationEnd.X)
                    && CurrentPoint.X <= Math.Max(Location.X, LocationEnd.X)
                    && CurrentPoint.Y >= Math.Min(Location.Y, LocationEnd.Y)
                    && CurrentPoint.Y <= Math.Max(Location.Y, LocationEnd.Y)
                    && (
                            (Math.Abs(Math.Abs(CurrentPoint.Y) - Math.Abs((M * CurrentPoint.X) + C)) <= Config.ConnectionLineDetectPrecision)
                            || (Math.Abs(Math.Abs(CurrentPoint.X) - (Math.Abs(CurrentPoint.Y) - C) / M) <= Config.ConnectionLineDetectPrecision)
                        )
                    )
            {
                return EnumHitTestResult.Body;
            }

            return EnumHitTestResult.Outside;
        }

        public void Draw(Graphics gr)
        {
            Location = StartItem.GetRightHandleCenterPos();
            LocationEnd = EndItem.GetLeftHandleCenterPos();
            
            if (!Selected)
                gr.DrawLine(Pens.Black, StartItem.GetRightHandleCenterPos(), EndItem.GetLeftHandleCenterPos());
            else
                gr.DrawLine(Pens.Blue, StartItem.GetRightHandleCenterPos(), EndItem.GetLeftHandleCenterPos());
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
