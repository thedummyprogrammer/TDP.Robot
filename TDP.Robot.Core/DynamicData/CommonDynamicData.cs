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
using TDP.Robot.Core.DynamicData;

namespace TDP.Robot.Core
{
    public static class CommonDynamicData
    {
        public const string DefaultRecordsetName = "DefaultRecordset";

        public const string ObjectName = "ObjectName";
        public const string ObjectID = "ObjectID";
        public const string ExecutionResult = "ExecutionResult";
        public const string ExecutionReturnValue = "ExecutionReturnValue";
        
        public const string ExecutionStartDate = "ExecutionStartDate";
        public const string ExecutionStartDateYear = "ExecutionStartDateYear";
        public const string ExecutionStartDateMonth = "ExecutionStartDateMonth";
        public const string ExecutionStartDateDay = "ExecutionStartDateDay";
        public const string ExecutionStartDateHour = "ExecutionStartDateHour";
        public const string ExecutionStartDateMinute = "ExecutionStartDateMinute";
        public const string ExecutionStartDateSecond = "ExecutionStartDateSecond";
        public const string ExecutionStartDateTicks = "ExecutionStartDateTicks";
        public const string ExecutionStartDateUnderscore = "ExecutionStartDateUnderscore";
        public const string ExecutionStartDateUnderscoreDate = "ExecutionStartDateUnderscoreDate";
        public const string ExecutionStartDateUnderscoreTime = "ExecutionStartDateUnderscoreTime";

        public const string ExecutionEndDate = "ExecutionEndDate";
        public const string ExecutionEndDateYear = "ExecutionEndDateYear";
        public const string ExecutionEndDateMonth = "ExecutionEndDateMonth";
        public const string ExecutionEndDateDay = "ExecutionEndDateDay";
        public const string ExecutionEndDateHour = "ExecutionEndDateHour";
        public const string ExecutionEndDateMinute = "ExecutionEndDateMinute";
        public const string ExecutionEndDateSecond = "ExecutionEndDateSecond";
        public const string ExecutionEndDateTicks = "ExecutionEndDateTicks";
        public const string ExecutionEndDateUnderscore = "ExecutionEndDateUnderscore";
        public const string ExecutionEndDateUnderscoreDate = "ExecutionEndDateUnderscoreDate";
        public const string ExecutionEndDateUnderscoreTime = "ExecutionEndDateUnderscoreTime";

        public const string NumberOfIterations = "NumberOfIterations";

        public static DynamicDataSet BuildStandardDynamicDataSet(IPluginInstance pluginInstance, 
                                                            bool executionResult, int executionReturnValue,
                                                            DateTime executionStartDate, DateTime executionEndDate,
                                                            int numberOfIterations)
        {
            DynamicDataSet DDataSet = new DynamicDataSet();
            DDataSet.Add(ObjectName, pluginInstance.Config.Name);
            DDataSet.Add(ObjectID, pluginInstance.Config.ID);
            DDataSet.Add(ExecutionResult, executionResult);
            DDataSet.Add(ExecutionReturnValue, executionReturnValue);
            
            DDataSet.Add(ExecutionStartDate, executionStartDate);
            DDataSet.Add(ExecutionStartDateYear, executionStartDate.Year);
            DDataSet.Add(ExecutionStartDateMonth, executionStartDate.Month);
            DDataSet.Add(ExecutionStartDateDay, executionStartDate.Day);
            DDataSet.Add(ExecutionStartDateHour, executionStartDate.Hour);
            DDataSet.Add(ExecutionStartDateMinute, executionStartDate.Minute);
            DDataSet.Add(ExecutionStartDateSecond, executionStartDate.Second);
            DDataSet.Add(ExecutionStartDateTicks, executionStartDate.Ticks);
            DDataSet.Add(ExecutionStartDateUnderscore, $"{executionStartDate:dd_MM_yyyy_HH_mm_ss}");
            DDataSet.Add(ExecutionStartDateUnderscoreDate, $"{executionStartDate:dd_MM_yyyy}");
            DDataSet.Add(ExecutionStartDateUnderscoreTime, $"{executionStartDate:HH_mm_ss}");

            DDataSet.Add(ExecutionEndDate, executionEndDate);
            DDataSet.Add(ExecutionEndDateYear, executionEndDate.Year);
            DDataSet.Add(ExecutionEndDateMonth, executionEndDate.Month);
            DDataSet.Add(ExecutionEndDateDay, executionEndDate.Day);
            DDataSet.Add(ExecutionEndDateHour, executionEndDate.Hour);
            DDataSet.Add(ExecutionEndDateMinute, executionEndDate.Minute);
            DDataSet.Add(ExecutionEndDateSecond, executionEndDate.Second);
            DDataSet.Add(ExecutionEndDateTicks, executionEndDate.Ticks);
            DDataSet.Add(ExecutionEndDateUnderscore, $"{executionEndDate:dd_MM_yyyy_HH_mm_ss}");
            DDataSet.Add(ExecutionEndDateUnderscoreDate, $"{executionEndDate:dd_MM_yyyy}");
            DDataSet.Add(ExecutionEndDateUnderscoreTime, $"{executionEndDate:HH_mm_ss}");

            DDataSet.Add(NumberOfIterations, numberOfIterations);

            return DDataSet;
        }

        public static List<DynamicDataSample> BuildStandardDynamicDataSamples(string objectName)
        {
            return new List<DynamicDataSample>()
            {
                new DynamicDataSample(ObjectName, Resource.TxtDynDataObjectName, objectName),
                new DynamicDataSample(ObjectID, Resource.TxtDynDataObjectID, "123"),
                new DynamicDataSample(ExecutionResult, Resource.TxtDynDataExecutionResult, "1"),
                new DynamicDataSample(ExecutionReturnValue, Resource.TxtDynDataExecutionReturnValue, "1"),

                new DynamicDataSample(ExecutionStartDate, Resource.TxtDynDataExecutionStartDate, "02/20/2021 18:30:00"),
                new DynamicDataSample(ExecutionStartDateYear, Resource.TxtDynDataExecutionStartDateYear, "2021"),
                new DynamicDataSample(ExecutionStartDateMonth, Resource.TxtDynDataExecutionStartDateMonth, "2"),
                new DynamicDataSample(ExecutionStartDateDay, Resource.TxtDynDataExecutionStartDateDay, "20"),
                new DynamicDataSample(ExecutionStartDateHour, Resource.TxtDynDataExecutionStartDateHour, "18"),
                new DynamicDataSample(ExecutionStartDateMinute, Resource.TxtDynDataExecutionStartDateMinute, "30"),
                new DynamicDataSample(ExecutionStartDateSecond, Resource.TxtDynDataExecutionStartDateSecond, "0"),
                new DynamicDataSample(ExecutionStartDateTicks, Resource.TxtDynDataExecutionStartDateTicks, "3847458755"),
                new DynamicDataSample(ExecutionStartDateUnderscore, Resource.TxtDynDataExecutionStartDateUnderscore, "2021_02_20_18_30_00"),
                new DynamicDataSample(ExecutionStartDateUnderscoreDate, Resource.TxtDynDataExecutionStartDateUnderscoreDate, "2021_02_20"),
                new DynamicDataSample(ExecutionStartDateUnderscoreTime, Resource.TxtDynDataExecutionStartDateUnderscoreTime, "18_30_00"),

                new DynamicDataSample(ExecutionEndDate, Resource.TxtDynDataExecutionEndDate, "02/20/2021 18:30:00"),
                new DynamicDataSample(ExecutionEndDateYear, Resource.TxtDynDataExecutionEndDateYear, "2021"),
                new DynamicDataSample(ExecutionEndDateMonth, Resource.TxtDynDataExecutionEndDateMonth, "2"),
                new DynamicDataSample(ExecutionEndDateDay, Resource.TxtDynDataExecutionEndDateDay, "20"),
                new DynamicDataSample(ExecutionEndDateHour, Resource.TxtDynDataExecutionEndDateHour, "18"),
                new DynamicDataSample(ExecutionEndDateMinute, Resource.TxtDynDataExecutionEndDateMinute, "30"),
                new DynamicDataSample(ExecutionEndDateSecond, Resource.TxtDynDataExecutionEndDateSecond, "0"),
                new DynamicDataSample(ExecutionEndDateTicks, Resource.TxtDynDataExecutionEndDateTicks, "3847458755"),
                new DynamicDataSample(ExecutionEndDateUnderscore, Resource.TxtDynDataExecutionEndDateUnderscore, "2021_02_20_18_30_00"),
                new DynamicDataSample(ExecutionEndDateUnderscoreDate, Resource.TxtDynDataExecutionEndDateUnderscoreDate, "2021_02_20"),
                new DynamicDataSample(ExecutionEndDateUnderscoreTime, Resource.TxtDynDataExecutionEndDateUnderscoreTime, "18_30_00"),

                new DynamicDataSample(NumberOfIterations, Resource.TxtDynDataNumberOfIterations, "10")
            };
        }
    }
}
