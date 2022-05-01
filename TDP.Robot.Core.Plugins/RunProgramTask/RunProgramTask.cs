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
using System.Diagnostics;
using System.IO;
using TDP.Robot.Core;
using TDP.Robot.Core.DynamicData;
using TDP.Robot.Core.Logging;

namespace TDP.Robot.Plugins.Core.RunProgramTask
{
    [Serializable]
    public class RunProgramTask : IterationTask
    {
        protected override void RunIteration(int currentIteration)
        {
            RunProgramTaskConfig TConfig = (RunProgramTaskConfig)_iterationConfig;

            ProcessStartInfo PInfo = new ProcessStartInfo(TConfig.ProgramPath, TConfig.Parameters);
            string DefaultWorkingFolder = Path.GetDirectoryName(TConfig.ProgramPath);
            PInfo.WorkingDirectory = string.IsNullOrEmpty(TConfig.WorkingFolder) ? DefaultWorkingFolder : TConfig.WorkingFolder;
            _instanceLogger.Info(this, $"Running program: {TConfig.ProgramPath} Parameters: {TConfig.Parameters} Working folder: {PInfo.WorkingDirectory}");
            using (Process NewProc = Process.Start(PInfo))
            {
                NewProc.WaitForExit();
            }
        }
    }
}
