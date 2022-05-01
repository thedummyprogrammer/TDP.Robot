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

using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace TDP.Robot.JobEditor.Infrastructure.Controls
{
    class LogListBox : ListBox
    {
        Regex _RegExLogFileName = new Regex(@"^\d+_\d{4}-\d{2}-\d{2}T\d{2}_\d{2}_\d{2}_(?<Ticks>\d{1,14}).log$");

        private long ExtractTicks(string fileName)
        {
            Match Mt = _RegExLogFileName.Match(fileName);
            if (Mt.Success)
                return long.Parse(Mt.Groups["Ticks"].Value);
            
            return 0;
        }

        protected override void Sort()
        {
            if (Items.Count > 1)
            {
                bool Swapped;
                do
                {
                    int Counter = Items.Count - 1;
                    Swapped = false;

                    while (Counter > 0)
                    {
                        // Compare the items' ticks
                        if (ExtractTicks(Items[Counter].ToString())
                            < ExtractTicks(Items[Counter - 1].ToString()))
                        {
                            // Swap the items.
                            object temp = Items[Counter];
                            Items[Counter] = Items[Counter - 1];
                            Items[Counter - 1] = temp;
                            Swapped = true;
                        }
                        // Decrement the counter.
                        Counter -= 1;
                    }
                }
                while ((Swapped == true));
            }
        }
    }
}
