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

namespace TDP.Robot.Plugins.Core
{
    static class Constants
    {
        public const string Zero = "0";

        public const int EveryNumDaysMaxLength = 3;
        public const int EveryNumDaysMin = 0;
        public const int EveryNumDaysMax = 999;

        public const int EveryNumHoursMin = 0;
        public const int EveryNumHoursMax = 23;
        public const int EveryNumHoursMaxLength = 2;

        public const int EveryNumMinutesMin = 0;
        public const int EveryNumMinutesMax = 59;
        public const int EveryNumMinutesMaxLength = 2;

        public const int EveryNumSecondsMin = 0;
        public const int EveryNumSecondsMax = 59;
        public const int EveryNumSecondsMaxLength = 2;

        public const int TcpPortNumberMin = 1;
        public const int TcpPortNumberMax = 65535;
        public const int TcpPortMaxLength = 5;
    }
}
