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

namespace TDP.Robot.Plugins.Core.DiskSpaceEvent
{
    [Serializable]
    public enum DiskThresholdUnitMeasure
    {
        Megabytes,
        Gigabytes,
        Terabytes,
        Percentage
    }

    [Serializable]
    public enum CheckOperator
    {
        GreaterThan,
        LessThan
    }

    [Serializable]
    public class DiskThreshold
    {
        public DiskThreshold()
        {

        }

        public DiskThreshold(string disk, CheckOperator checkOperator, int thresholdValue, DiskThresholdUnitMeasure unitMeasure)
        {
            Disk = disk;
            CheckOperator = checkOperator;
            ThresholdValue = thresholdValue;
            UnitMeasure = unitMeasure;
        }

        public string Disk { get; set; }

        public CheckOperator CheckOperator { get; set; }

        public int ThresholdValue { get; set; }

        public DiskThresholdUnitMeasure UnitMeasure { get; set;}

        public override string ToString()
        {
            string Result = Disk;

            if (CheckOperator == CheckOperator.GreaterThan)
                Result += " " + Resource.TxtGreaterThan;
            else
                Result += " " + Resource.TxtLessThan;

            Result += " " + ThresholdValue;

            if (UnitMeasure == DiskThresholdUnitMeasure.Megabytes)
                Result += " " + Resource.TxtMegabytes;
            else if (UnitMeasure == DiskThresholdUnitMeasure.Gigabytes)
                Result += " " + Resource.TxtGigabytes;
            else if (UnitMeasure == DiskThresholdUnitMeasure.Terabytes)
                Result += " " + Resource.TxtTerabytes;
            else if (UnitMeasure == DiskThresholdUnitMeasure.Percentage)
                Result += " " + Resource.TxtPercentage;

            return Result;
        }
    }
}
