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

namespace TDP.Robot.Core
{
    [Serializable]
    public class PluginInstanceConnection
    {
        public PluginInstanceConnection(IPluginInstance connectTo, bool disable, int? waitSeconds, List<ExecutionCondition> executeConditions, List<ExecutionCondition> dontExecuteConditions)
        {
            ConnectTo = connectTo;
            Disable = disable;
            WaitSeconds = waitSeconds;
            ExecuteConditions = executeConditions;
            DontExecuteConditions = dontExecuteConditions;            
        }

        public IPluginInstance ConnectTo { get; private set; }
        public bool Disable { get; private set; }
        public int? WaitSeconds { get; private set; }
        public List<ExecutionCondition> ExecuteConditions { get; private set; }
        public List<ExecutionCondition> DontExecuteConditions { get; private set; }

        public bool EvaluateExecConditions(ExecResult execResult)
        {
            // First of all check DontExecuteCondtions
            foreach (ExecutionCondition ExecCond in DontExecuteConditions)
            {
                if (ExecCond.EvaluateCondition(execResult))
                {
                    return false;
                }
            }

            // Now check ExecuteConditions
            foreach (ExecutionCondition ExecCond in ExecuteConditions)
            {
                if (ExecCond.EvaluateCondition(execResult))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
