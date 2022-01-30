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
using TDP.Robot.Core;

namespace TDP.Robot.Plugins.Core.DateTimeEvent
{
    [Serializable]
    public class DateTimeEventConfig : IEventConfig
    {
        public DateTimeEventConfig()
        {
            AtDate = DateTime.Now;
            EveryNumMinutes = 5;
            EveryNumSeconds = 5;
            OneTime = true;
            OnDays = new List<DayOfWeek>() { DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday,
                                            DayOfWeek.Thursday, DayOfWeek.Friday, DayOfWeek.Saturday, DayOfWeek.Sunday };
            OnAllDays = true;
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public bool Disable { get; set; }
        public bool DoNotLog { get; set; }
        public DateTime AtDate { get; set; }
        public bool OneTime { get; set; }
        
        public bool EveryDaysHoursSecs { get; set; }
        public int EveryNumDays { get; set; }
        public int EveryNumHours { get; set; }
        public int EveryNumMinutes { get; set; }

        public bool EverySeconds { get; set; }
        public int EveryNumSeconds { get; set; }

        public List<DayOfWeek> OnDays { get; }
        public bool OnAllDays { get; set; }
    }
}
