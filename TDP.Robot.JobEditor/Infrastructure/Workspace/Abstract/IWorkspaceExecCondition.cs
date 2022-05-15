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

using TDP.Robot.Core;

namespace TDP.Robot.JobEditor.Infrastructure.Workspace.Abstract
{
    interface IWorkspaceExecCondition
    {
        IWorkspaceItem Item { get; set; }

        string DynamicDataCode { get; set; }
        EnumExecutionConditionOperator Operator { get; set; }
        string MinValue { get; set; }
        string MaxValue { get; set; }
    }
}
