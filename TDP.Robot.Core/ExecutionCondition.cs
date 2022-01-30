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
using TDP.Robot.Core.DynamicData;

namespace TDP.Robot.Core
{
    [Serializable]
    public class ExecutionCondition
    {
        public ExecutionCondition(IPluginInstance pluginInstance, string dynamicDataCode, EnumExecutionConditionOperator conditionOperator, 
                                    string minValue, string maxValue)
        {
            PluginInstance = pluginInstance;
            DynamicDataCode = dynamicDataCode;
            Operator = conditionOperator;
            MinValue = minValue;
            MaxValue = maxValue;
        }

        public IPluginInstance PluginInstance { get; set; }
        public int ObjectID { get; set; }
        public string ObjectName { get; set; }
        public string DynamicDataCode { get; set; }
        public EnumExecutionConditionOperator Operator {get; set; }
        public string MinValue { get; set; }
        public string MaxValue { get; set; }

        public bool EvaluateCondition(ExecResult execResult)
        {
            if (Operator == EnumExecutionConditionOperator.ObjectExecutes && execResult.Result)
                return true;

            if (Operator == EnumExecutionConditionOperator.ObjectDoesNotExecute && !execResult.Result)
                return true;

            if (Operator == EnumExecutionConditionOperator.ValueEqualsTo && execResult.Data[DynamicDataCode].ToString() == MinValue)
                return true;

            if (Operator == EnumExecutionConditionOperator.ValueGreaterThan && (int)execResult.Data[DynamicDataCode] > int.Parse(MinValue))
                return true;

            if (Operator == EnumExecutionConditionOperator.ValueLessThan && (int)execResult.Data[DynamicDataCode] < int.Parse(MinValue))
                return true;

            if (Operator == EnumExecutionConditionOperator.ValueContains && execResult.Data[DynamicDataCode].ToString().Contains(MinValue))
                return true;

            if (Operator == EnumExecutionConditionOperator.ValueStartsWith && execResult.Data[DynamicDataCode].ToString().StartsWith(MinValue))
                return true;

            if (Operator == EnumExecutionConditionOperator.ValueEndsWith && execResult.Data[DynamicDataCode].ToString().EndsWith(MinValue))
                return true;

            if (Operator == EnumExecutionConditionOperator.ValueBetween 
                    && (int)execResult.Data[DynamicDataCode] >= int.Parse(MinValue)
                    && (int)execResult.Data[DynamicDataCode] <= int.Parse(MaxValue)
                )
                return true;

            return false;
        }
    }
}
