﻿/*======================================================================================
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

namespace TDP.Robot.Core.DynamicData
{
    [Serializable]
    public class DynamicDataChain : IEnumerable
    {
        private Dictionary<int, DynamicDataSet> _Data = new Dictionary<int, DynamicDataSet>();

        public void Add(int key, DynamicDataSet value)
        {
            _Data.Add(key, value);
        }

        public DynamicDataSet this[int key]
        {
            get
            {
                return _Data[key];
            }
            set
            {
                _Data[key] = value;
            }
        }

        public bool Remove(int key)
        {
            return _Data.Remove(key);
        }

        public IEnumerator GetEnumerator()
        {
            return _Data.GetEnumerator();
        }
    }
}
