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
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using TDP.Robot.Core;
using TDP.Robot.Core.DynamicData;
using TDP.Robot.Core.Logging;

namespace TDP.Robot.Plugins.Core.RunProgramTask
{
    [Serializable]
    public class RunProgramTask : ITask
    {
        public int ID { get; set; }
        public IFolder ParentFolder { get; set; }
        public IPluginInstanceConfig Config { get; set; }
        public List<PluginInstanceConnection> Connections { get; } = new List<PluginInstanceConnection>();        
        

        public void Init()
        {
            
        }

        public void Destroy()
        {
            
        }

        public ExecResult Run(DynamicDataChain dataChain, DynamicDataSet lastDynamicDataSet, IPluginInstanceLogger instanceLogger)
        {
            ExecResult Result;
            DateTime StartDateTime = DateTime.Now;

            int ActualIterations = 0;

            try
            {
                if (!Config.DoNotLog)
                    instanceLogger.TaskStarted(this);

                RunProgramTaskConfig TConfig = (RunProgramTaskConfig)Config;
                int IterationsCount = DynamicDataParser.GetIterationCount(TConfig, dataChain, lastDynamicDataSet);

                for (int i = 0; i < IterationsCount; i++)
                {
                    RunProgramTaskConfig ConfigCopy = (RunProgramTaskConfig)CoreHelpers.CloneObjects(Config);
                    DynamicDataParser.Parse(ConfigCopy, dataChain, i);

                    ProcessStartInfo PInfo = new ProcessStartInfo(ConfigCopy.ProgramPath, ConfigCopy.Parameters);
                    string DefaultWorkingFolder = Path.GetDirectoryName(ConfigCopy.ProgramPath);
                    PInfo.WorkingDirectory = string.IsNullOrEmpty(ConfigCopy.WorkingFolder) ? DefaultWorkingFolder : ConfigCopy.WorkingFolder;
                    instanceLogger.Info(this, $"Running program: {ConfigCopy.ProgramPath} Parameters: {ConfigCopy.Parameters} Working folder: {PInfo.WorkingDirectory}");
                    using (Process NewProc = Process.Start(PInfo))
                    {
                        NewProc.WaitForExit();
                    }

                    ActualIterations++;
                }

                DynamicDataSet DDataSet = CommonDynamicData.BuildStandardDynamicDataSet(this, true, 0, StartDateTime, DateTime.Now, ActualIterations);
                Result = new ExecResult(true, DDataSet);

                if (!Config.DoNotLog)
                    instanceLogger.TaskCompleted(this);
            }
            catch (Exception ex)
            {
                if (!Config.DoNotLog)
                    instanceLogger.TaskError(this, ex);

                DynamicDataSet DDataSet = CommonDynamicData.BuildStandardDynamicDataSet(this, false, -1, StartDateTime, DateTime.Now, ActualIterations);
                Result = new ExecResult(false, DDataSet);
            }

            return Result;
        }
    }
}
