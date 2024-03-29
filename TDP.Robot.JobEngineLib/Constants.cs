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

namespace TDP.Robot.JobEngineLib
{
    static class Constants
    {
        internal const string DefaultLogPath = @"Log\";
        internal const string DefaultLibPath = @"Lib\";
        internal const string DefaultDataPath = @"Data\";
        internal const bool DefaultSerialExecution = false;
        internal const int CleanUpLogsOlderThanHours = 0;
        internal const int CleanUpLogsIntervalHours = 0;
        internal const int HttpListenerPort = 44300;
    }
}
