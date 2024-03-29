﻿/*======================================================================================
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
using System.Collections;
using System.Collections.Generic;

namespace TDP.Robot.Core.DynamicData
{
    [Serializable]
    public class DynamicDataSet
    {
        private Dictionary<string, object> _Data = new Dictionary<string, object>();

        public void Add(string key, object value)
        {
            _Data.Add(key, value);
        }

        public object this[string key]
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

        public bool Remove(string key)
        {
            return _Data.Remove(key);
        }

        public bool ContainsKey(string key)
        {
            return _Data.ContainsKey(key);
        }

        public IEnumerator GetEnumerator()
        {
            return _Data.GetEnumerator();
        }
    }
}
