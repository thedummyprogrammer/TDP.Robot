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

using System.Drawing;
using System.Windows.Forms;

namespace TDP.Robot.JobEditor.Infrastructure.GraphicsHelper
{
    static class StructConvert
    {
        public static RectangleF ToRectangleF(Rectangle rect)
        {
            return new RectangleF((float)rect.X, (float)rect.Y, (float)rect.Width, (float)rect.Height);
        }

        public static RectangleF ToRectangleF(Rectangle? rect)
        {
            Rectangle T = (Rectangle)rect;
            return new RectangleF((float)T.X, (float)T.Y, (float)T.Width, (float)T.Height);
        }

        public static Rectangle ToRectangle(RectangleF rect)
        {
            return new Rectangle((int)rect.X, (int)rect.Y, (int)rect.Width, (int)rect.Height);
        }

        public static Point ToPoint(PointF pt)
        {
            return new Point((int)pt.X, (int)pt.Y);
        }

        public static PointF ToPointF(Point pt)
        {
            return new PointF(pt.X, pt.Y);
        }

        public static Size ToSize(SizeF size)
        {
            return new Size((int)size.Width, (int)size.Height);
        }

        public static Rectangle RectangleToScreen(Control control, Rectangle rect)
        {
            return new Rectangle(control.PointToScreen(rect.Location), rect.Size);
        }
    }
}
