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

using TDP.BaseServices.Infrastructure.Configuration;
using TDP.Robot.JobEngineLib.Infrastructure.Configuration;

namespace TDP.Robot.JobEngineLib
{
    static class Config
    {
        internal static string LogPath { get; private set; }
        internal static string LibPath { get; private set; }
        internal static string DataPath { get; private set; }
        internal static bool SerialExecution { get; private set; }
        internal static int CleanUpLogsOlderThanHours { get; private set; }
        internal static int CleanUpLogsIntervalHours { get; private set; }

        

        internal static void Init()
        {
            ConfigReader CR = new ConfigReader();
            LogPath = CR.Get(ConfigReaderKeys.KeyLogPath, Constants.DefaultLogPath);
            LibPath = CR.Get(ConfigReaderKeys.KeyLibPath, Constants.DefaultLibPath);
            DataPath = CR.Get(ConfigReaderKeys.KeyDataPath, Constants.DefaultDataPath);
            SerialExecution = CR.Get(ConfigReaderKeys.KeySerialExecution, Constants.DefaultSerialExecution);
            CleanUpLogsOlderThanHours = CR.Get(ConfigReaderKeys.CleanUpLogsOlderThanHours, Constants.CleanUpLogsOlderThanHours);
            CleanUpLogsIntervalHours = CR.Get(ConfigReaderKeys.CleanUpLogsIntervalHours, Constants.CleanUpLogsIntervalHours);
        }
    }
}
