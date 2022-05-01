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
using System.Data;
using TDP.Robot.Core.DynamicData;
using TDP.Robot.Core.Logging;

namespace TDP.Robot.Core
{
    [Serializable]
    public abstract class BaseTask : ITask
    {
        [NonSerialized]
        protected bool _taskReturnsRecordset = false;
        [NonSerialized]
        protected object _defaultRecordset = new DataTable();
        [NonSerialized]
        protected int _iterationsCount;
        [NonSerialized]
        protected DynamicDataChain _dataChain;
        [NonSerialized]
        protected DynamicDataSet _lastDynamicDataSet;
        [NonSerialized]
        protected IPluginInstanceLogger _instanceLogger;
        [NonSerialized]
        protected List<ExecResult> _execResults;



        public IFolder ParentFolder { get; set; }
        public int ID { get; set; }
        public IPluginInstanceConfig Config { get; set; }

        public List<PluginInstanceConnection> Connections { get; } = new List<PluginInstanceConnection>();

        public void Init()
        {
            InitTask();
        }

        public void Destroy()
        {
            DestroyTask();
        }

        protected virtual void InitTask()
        {

        }

        protected virtual void DestroyTask()
        {

        }

        protected abstract void RunTask();

        public InstanceExecResult Run(DynamicDataChain dataChain, DynamicDataSet lastDynamicDataSet, IPluginInstanceLogger instanceLogger)
        {
            _dataChain = dataChain;
            _lastDynamicDataSet = lastDynamicDataSet;
            _instanceLogger = instanceLogger;
            _execResults = new List<ExecResult>();

            try
            {
                if (!Config.DoNotLog)
                    instanceLogger.TaskStarted(this);

                _iterationsCount = DynamicDataParser.GetIterationCount((ITaskConfig)Config, dataChain, lastDynamicDataSet);

                if (_iterationsCount > 0)
                    RunTask();

                if (!Config.DoNotLog)
                    instanceLogger.TaskCompleted(this);
            }
            catch (Exception ex)
            {
                if (!Config.DoNotLog)
                    instanceLogger.TaskError(this, ex);
            }

            return new InstanceExecResult(_execResults);
        }
    }
}
