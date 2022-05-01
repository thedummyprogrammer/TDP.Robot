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
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TDP.Robot.JobEditor.Infrastructure.GraphicsHelper
{
    static class Drawing
    {
        public static void DrawStringCentered(Graphics gr, string s, Font font, Brush brush, PointF point, float columnWidth)
        {
            SizeF TextSize = gr.MeasureString(s, font);
            PointF RowPos = new PointF(point.X + ((columnWidth - TextSize.Width) / 2), point.Y);
            gr.DrawString(s, font, brush, RowPos);
        }

        public static float DrawStringInColumn(Graphics gr, string s, Font font, Brush brush, PointF point, float columnWidth, bool onlyMeasure)
        {
            if (s.Length == 0)
                return 0;

            if (gr.MeasureString(s[0].ToString(), font).Width > columnWidth)
                return 0;

            SizeF StringSize = gr.MeasureString(s, font);
            if (StringSize.Width <= columnWidth)
            {
                if (!onlyMeasure)
                    DrawStringCentered(gr, s, font, brush, point, columnWidth);
                return StringSize.Height;
            }

            string PrevWordsAccumulated;
            StringBuilder WordsAccumulated = new StringBuilder();
            string[] Words = s.Split(' ');
            string Word;
            int RowCount = 0;
            int WordIdx = 0;
            while (WordIdx < Words.Length)
            {
                Word = Words[WordIdx];

                // A word that is larger than the column width will always start in a new row
                if (gr.MeasureString(Word, font).Width > columnWidth)
                {
                    // Print everything accumulated in previous iterations
                    if (WordsAccumulated.Length > 0)
                    {
                        string RemainingText = WordsAccumulated.ToString();
                        PointF RowPos = new PointF(point.X, point.Y + (StringSize.Height * RowCount));
                        if (!onlyMeasure)
                            DrawStringCentered(gr, RemainingText, font, brush, RowPos, columnWidth);
                        RowCount++;
                        WordsAccumulated.Clear();
                    }

                    // Print the word char by char and use a new line when column width is reached
                    StringBuilder CharsAccumulated = new StringBuilder();
                    int CharCount = 0;
                    string PrevCharsAccumulated;
                    while (CharCount < Word.Length)
                    {
                        PrevCharsAccumulated = CharsAccumulated.ToString();
                        CharsAccumulated.Append(Word[CharCount]);
                        if (gr.MeasureString(CharsAccumulated.ToString(), font).Width > columnWidth)
                        {
                            PointF RowPos = new PointF(point.X, point.Y + (StringSize.Height * RowCount));
                            if (!onlyMeasure)
                                DrawStringCentered(gr, PrevCharsAccumulated, font, brush, RowPos, columnWidth);
                            RowCount++;
                            CharsAccumulated.Clear();
                        }
                        else
                        {
                            CharCount++;
                        }
                    }

                    if (CharsAccumulated.Length > 0)
                    {
                        // If a remainder is present, append as a word. If the next word
                        // is short enaugh they will be printed on the same line.
                        WordsAccumulated.Append(CharsAccumulated.ToString());
                        WordIdx++;
                    }
                    continue;
                }

                // Save the words accumulated until now. This is the string that will be
                // printed if adding the new word the string size will exceed column width
                PrevWordsAccumulated = WordsAccumulated.ToString();

                if (WordsAccumulated.Length == 0)
                    WordsAccumulated.Append(Word);
                else
                    WordsAccumulated.Append(" " + Word);

                // Print accumulated words...
                if (gr.MeasureString(WordsAccumulated.ToString(), font).Width > columnWidth)
                {
                    PointF RowPos = new PointF(point.X, point.Y + (StringSize.Height * RowCount));
                    if (!onlyMeasure)
                        DrawStringCentered(gr, PrevWordsAccumulated, font, brush, RowPos, columnWidth);
                    RowCount++;
                    WordsAccumulated.Clear();
                    WordsAccumulated.Append(Word);
                }

                WordIdx++;
            }

            // If a remainder exists, print...
            if (WordsAccumulated.Length > 0)
            {
                string RemainingText = WordsAccumulated.ToString();
                PointF RowPos = new PointF(point.X, point.Y + (StringSize.Height * RowCount));
                if (!onlyMeasure)
                    DrawStringCentered(gr, RemainingText, font, brush, RowPos, columnWidth);
                RowCount++;
            }

            // Return the total height of the text printed
            return StringSize.Height * RowCount;
        }

        public static void DrawXORRectangle(Control control, Rectangle rectangle)
        {
            Rectangle RectangleToDrawScreen = control.RectangleToScreen(rectangle);
            Rectangle ClientRectScreen = control.RectangleToScreen(control.ClientRectangle);

            int X1 = Math.Max(ClientRectScreen.Left, RectangleToDrawScreen.Left);
            int Y1 = Math.Max(ClientRectScreen.Top, RectangleToDrawScreen.Top);
            int X2 = Math.Min(ClientRectScreen.Left + ClientRectScreen.Width, RectangleToDrawScreen.Left + RectangleToDrawScreen.Width);
            int Y2 = Math.Min(ClientRectScreen.Top + ClientRectScreen.Height, RectangleToDrawScreen.Top + RectangleToDrawScreen.Height);

            Rectangle ClippedRectangle = new Rectangle(X1, Y1, X2 - X1, Y2 - Y1);

            ControlPaint.DrawReversibleFrame(ClippedRectangle, Color.Gray, FrameStyle.Thick);
        }

        public static void DrawXORRectangles(Control control, RectangleF[] rectangles)
        {
            foreach (RectangleF Rect in rectangles)
            {
                DrawXORRectangle(control, StructConvert.ToRectangle(Rect));
            }
        }

        public static void DrawXORLine(Control control, int x1, int y1, int x2, int y2)
        {
            Point PtStart = control.PointToScreen(new Point(x1, y1));
            Point PtEnd = control.PointToScreen(new Point(x2, y2));

            Rectangle ClientRectScreen = control.RectangleToScreen(control.ClientRectangle);

            int X2 = PtEnd.X;
            int Y2 = PtEnd.Y;

            if (PtEnd.X < ClientRectScreen.Location.X)
                X2 = ClientRectScreen.Location.X;
            else if (PtEnd.X > (ClientRectScreen.Location.X + ClientRectScreen.Width))
                X2 = ClientRectScreen.Location.X + ClientRectScreen.Width;

            if (PtEnd.Y < ClientRectScreen.Location.Y)
                Y2 = ClientRectScreen.Location.Y;
            else if (PtEnd.Y > (ClientRectScreen.Location.Y + ClientRectScreen.Height))
                Y2 = ClientRectScreen.Location.Y + ClientRectScreen.Height;

            ControlPaint.DrawReversibleLine(PtStart, new Point(X2, Y2), Color.Gray);
        }
    }
}
