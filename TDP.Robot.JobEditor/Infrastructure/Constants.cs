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

namespace TDP.Robot.JobEditor.Infrastructure
{
    static class Constants
    {
        internal const int RootFolderID = 0;
        internal const string DefaultEventsLogPath = @"..\JobEngine\";
        internal const string DefaultLibPath = @"Lib\";
        internal const string DefaultDataPath = @"Data\";
        internal const int DefaultItemWidth = 52;
        internal const float DefaultItemFontSize = 9;
        internal const float DefaultItemHandleDistance = 8;
        internal const float DefaultItemHandleSize = 2;
        internal const float DefaultConnectionLineDetectPrecision = 0.02F;
        internal const float DefaultConnectionLineDetectPerpendicularPrecision = 1F;
        internal const int NameMaxLength = 100;
    }
}
