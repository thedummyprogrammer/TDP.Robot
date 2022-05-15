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

namespace TDP.Robot.Plugins.Core.SystemEventsEvent
{
    internal class SystemEventsEventCommon
    {
        public const string DynDataKeyEventCode = "EventCode";

        public const string EventCodeUserPreferenceChanged = "UserPreferenceChanged";
        public const string EventCodeTimeChanged = "TimeChanged";
        public const string EventCodeSessionSwitch = "SessionSwitch";
        public const string EventCodeSessionEnded = "SessionEnded";
        public const string EventCodePowerModeChanged = "PowerModeChanged";
        public const string EventCodePaletteChanged = "PaletteChanged";
        public const string EventCodeInstalledFontsChanged = "InstalledFontsChanged";
        public const string EventCodeDisplaySettingsChanged = "DisplaySettingsChanged";
    }
}
