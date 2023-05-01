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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDP.Robot.Core;
using TDP.Robot.JobEditor.Infrastructure.Workspace.Abstract;
using TDP.Robot.JobEditor.Properties;

namespace TDP.Robot.JobEditor.Infrastructure.Workspace
{
    [Serializable]
    class WorkspaceExecCondition : IWorkspaceExecCondition
    {
        public WorkspaceExecCondition(IWorkspaceItem item, string dynamicDataCode, EnumExecutionConditionOperator conditionOperator,
                            string minValue, string maxValue)
        {
            Item = item;
            DynamicDataCode = dynamicDataCode;
            Operator = conditionOperator;
            MinValue = minValue;
            MaxValue = maxValue;
        }

        public IWorkspaceItem Item { get; set; }
        public string DynamicDataCode { get; set; }
        public EnumExecutionConditionOperator Operator { get; set; }
        public string MinValue { get; set; }
        public string MaxValue { get; set; }

        public override string ToString()
        {
            string Result = string.Empty;

            switch (Operator)
            {
                case EnumExecutionConditionOperator.ObjectExecutes:
                    Result = string.Format(Resources.TxtExecCondObjectExecutes, Item.Name, Item.ID);
                    break;

                case EnumExecutionConditionOperator.ObjectDoesNotExecute:
                    Result = string.Format(Resources.TxtExecCondObjectDoesNotExecute, Item.Name, Item.ID);
                    break;

                case EnumExecutionConditionOperator.ValueEqualsTo:
                    Result = string.Format(Resources.TxtDynamicDataEquals, Item.Name, DynamicDataCode, MinValue);
                    break;

                case EnumExecutionConditionOperator.ValueGreaterThan:
                    Result = string.Format(Resources.TxtDynamicDataGreaterThan, Item.Name, DynamicDataCode, MinValue);
                    break;

                case EnumExecutionConditionOperator.ValueLessThan:
                    Result = string.Format(Resources.TxtDynamicDataLessThan, Item.Name, DynamicDataCode, MinValue);
                    break;

                case EnumExecutionConditionOperator.ValueContains:
                    Result = string.Format(Resources.TxtDynamicDataContains, Item.Name, DynamicDataCode, MinValue);
                    break;

                case EnumExecutionConditionOperator.ValueStartsWith:
                    Result = string.Format(Resources.TxtDynamicDataStartsWith, Item.Name, DynamicDataCode, MinValue);
                    break;

                case EnumExecutionConditionOperator.ValueEndsWith:
                    Result = string.Format(Resources.TxtDynamicDataEndsWith, Item.Name, DynamicDataCode, MinValue);
                    break;

                case EnumExecutionConditionOperator.ValueBetween:
                    Result = string.Format(Resources.TxtDynamicDataBetween, Item.Name, DynamicDataCode, MinValue, MaxValue);
                    break;
            }

            return Result;
        }
    }
}
