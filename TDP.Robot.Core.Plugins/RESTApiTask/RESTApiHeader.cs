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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDP.Robot.Plugins.Core.RESTApiTask
{
    [Serializable]
    public class RESTApiHeader
    {
        public RESTApiHeader()
        {

        }

        public RESTApiHeader(string name, string value)
        {
            Name = name;
            Value = value;
        }

        public string Name {get; set;}

        public string Value { get; set; }

        public override string ToString()
        {
            return $"{Name}:{Value}";
        }
    }
}
