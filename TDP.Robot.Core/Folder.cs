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
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace TDP.Robot.Core
{
    [Serializable]
    public class Folder : IFolder
    {
        private List<IPluginInstanceBase> Items { get; } = new List<IPluginInstanceBase>();

        public int ID { get; set; }
        public IFolder ParentFolder { get; set; }

        public void Add(IPluginInstanceBase item)
        {
            Items.Add(item);
        }

        public IEnumerator<IPluginInstanceBase> GetEnumerator()
        {
            return Items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Items.GetEnumerator();
        }

        public string GetPhysicalFullPath()
        {
            IFolder Folder = this;
            string FullPath = string.Empty;

            while (Folder != null)
            {
                FullPath = Folder.ID.ToString() + Path.DirectorySeparatorChar + FullPath;
                Folder = Folder.ParentFolder;
            }

            return FullPath;
        }
    }
}
