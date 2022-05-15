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
using TDP.Robot.Core.DynamicData;

namespace TDP.Robot.Core
{
    [Serializable]
    public abstract class IterationTask : BaseTask
    {
        [NonSerialized]
        protected DateTime _startDateTime;
        protected ITaskConfig _iterationConfig;

        protected abstract void RunIteration(int currentIteration);

        protected virtual void PostIterationSucceded(int currentIteration, ExecResult result, DynamicDataSet dDataSet)
        {

        }

        protected virtual void PostIterationFailed(int currentIteration, ExecResult result, DynamicDataSet dDataSet)
        {

        }

        protected override void RunTask()
        {
            for (int i = 0; i < _iterationsCount; i++)
            {
                DateTime _startDateTime = DateTime.Now;

                try
                {
                    _iterationConfig = (ITaskConfig)CoreHelpers.CloneObjects(Config);
                    DynamicDataParser.Parse(_iterationConfig, _dataChain, i);

                    RunIteration(i);

                    DynamicDataSet DDataSet = CommonDynamicData.BuildStandardDynamicDataSet(this, true, 0, _startDateTime, DateTime.Now, _iterationsCount);
                    ExecResult Result = new ExecResult(true, DDataSet);

                    PostIterationSucceded(i, Result, DDataSet);

                    _execResults.Add(Result);
                }
                catch (Exception ex)
                {
                    if (!Config.DoNotLog)
                        _instanceLogger.TaskError(this, ex);

                    DynamicDataSet DDataSet = CommonDynamicData.BuildStandardDynamicDataSet(this, false, -1, _startDateTime, DateTime.Now, i + 1);
                    ExecResult Result = new ExecResult(false, DDataSet);

                    PostIterationFailed(i, Result, DDataSet);

                    _execResults.Add(Result);
                }
            }
        }
    }
}
