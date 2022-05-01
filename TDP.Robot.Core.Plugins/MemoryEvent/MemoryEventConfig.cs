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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDP.Robot.Core;

namespace TDP.Robot.Plugins.Core.MemoryEvent
{
    [Serializable]
    public class MemoryEventConfig : IEventConfig
    {
        private const int _DefaultCheckIntervalSeconds = 1;

        public MemoryEventConfig()
        {
            CheckIntervalSeconds = _DefaultCheckIntervalSeconds;
            TriggerIfUsageIsAboveThreshold = true;
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public bool Disable { get; set; }
        public bool DoNotLog { get; set; }

        public bool TriggerIfUsageIsAboveThreshold { get; set; }

        public bool TriggerIfAvgUsageIsAboveThresholdLastXMin { get; set; }

        public float? Threshold { get; set; }

        public int? AvgIntervalMinutes { get; set; }

        public bool TriggerIfPassedXMinFromLastTrigger { get; set; }

        public int? MinutesFromLastTrigger { get; set; }

        public int CheckIntervalSeconds { get; set; }
    }
}


