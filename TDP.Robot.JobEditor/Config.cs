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

using TDP.BaseServices.Infrastructure.Configuration;
using TDP.Robot.JobEditor.Infrastructure;
using TDP.Robot.JobEditor.Infrastructure.Configuration;

namespace TDP.Robot.JobEditor
{
    static class Config
    {
        public static string EventsLogPath { get; private set; }
        public static string LibPath { get; private set; }
        public static string DataPath { get; private set; }
        public static int ItemWidth { get; private set; }
        public static float ItemFontSize { get; private set; }
        public static float ItemHandleDistance { get; private set; }
        public static float ItemHandleSize { get; private set; }
        public static float ConnectionLineDetectPrecision { get; private set; }

        public static float ConnectionLineDetectPerpendicularPrecision { get; private set; }

        public static void Init()
        {
            ConfigReader CR = new ConfigReader();
            EventsLogPath = CR.Get(ConfigReaderKeys.EventsLogPath, Constants.DefaultEventsLogPath);
            LibPath = CR.Get(ConfigReaderKeys.KeyLibPath, Constants.DefaultLibPath);
            DataPath = CR.Get(ConfigReaderKeys.KeyDataPath, Constants.DefaultDataPath);
            ItemWidth = CR.Get(ConfigReaderKeys.KeyItemWidth, Constants.DefaultItemWidth);
            ItemFontSize = CR.Get(ConfigReaderKeys.KeyItemFontSize, Constants.DefaultItemFontSize);
            ItemHandleDistance = CR.Get(ConfigReaderKeys.KeyItemHandleDistance, Constants.DefaultItemHandleDistance);
            ItemHandleSize = CR.Get(ConfigReaderKeys.KeyItemHandleSize, Constants.DefaultItemHandleSize);
            ConnectionLineDetectPrecision = CR.Get(ConfigReaderKeys.KeyConnectionLineDetectPrecision, Constants.DefaultConnectionLineDetectPrecision);
            ConnectionLineDetectPerpendicularPrecision = CR.Get(ConfigReaderKeys.KeyConnectionLineDetectPerpendicularPrecision, Constants.DefaultConnectionLineDetectPerpendicularPrecision);
        }
    }
}
