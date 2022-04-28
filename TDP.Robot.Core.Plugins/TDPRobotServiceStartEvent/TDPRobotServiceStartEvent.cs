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
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TDP.Robot.Core;
using TDP.Robot.Core.DynamicData;
using TDP.Robot.Core.Logging;

namespace TDP.Robot.Plugins.Core.TDPRobotServiceStartEvent
{
    [Serializable]
    public class TDPRobotServiceStartEvent : IEvent
    {
        [DllImport("kernel32")]
        extern static ulong GetTickCount64();

        public IFolder ParentFolder { get; set; }
        public int ID { get; set; }

        public IPluginInstanceConfig Config { get; set; }

        public List<PluginInstanceConnection> Connections { get; } = new List<PluginInstanceConnection>();

        [field: NonSerialized]
        public event EventTriggeredDelegate EventTriggered;

        protected virtual void OnEventTriggered(EventTriggeredEventArgs e)
        {
            EventTriggeredDelegate handler = EventTriggered;
            if (handler != null)
            {
                foreach (EventTriggeredDelegate singleCast in handler.GetInvocationList())
                {
                    ISynchronizeInvoke syncInvoke = singleCast.Target as ISynchronizeInvoke;
                    if ((syncInvoke != null) && (syncInvoke.InvokeRequired))
                        syncInvoke.Invoke(singleCast, new object[] { this, e });
                    else
                        singleCast(this, e);
                }
            }
        }

        private int GetSystemStartedForMinutes()
        {
            /*
            According to: https://docs.microsoft.com/en-us/dotnet/api/system.environment.tickcount?view=netframework-4.8 
            Because the value of the TickCount property value is a 32-bit signed integer, if the system runs continuously, TickCount will increment from zero 
            to Int32.MaxValue for approximately 24.9 days, then jump to Int32.MinValue, which is a negative number, then increment back 
            to zero during the next 24.9 days. You can work around this issue by calling the Windows GetTickCount function, which resets to zero after approximately 49.7 days, 
            or by calling the GetTickCount64 function.

            So we use GetTickCount64, not very cross platform but maybe we will improve later...
            */


            ulong MinutesUptime = GetTickCount64() / 1000 / 64;

            // Int is sufficient for our purpose
            if (MinutesUptime > int.MaxValue)
                return int.MaxValue;

            return (int)MinutesUptime;
        }

        public void Init()
        {
            
        }

        public void Destroy()
        {
            
        }

        public InstanceExecResult Run(DynamicDataChain dataChain, DynamicDataSet lastDynamicDataSet, IPluginInstanceLogger instanceLogger)
        {
            IPluginInstanceLogger Logger = PluginInstanceLogger.GetLogger(this);

            try
            {
                TDPRobotServiceStartEventConfig TConfig = (TDPRobotServiceStartEventConfig)Config;

                int SystemStartedForMinutes = GetSystemStartedForMinutes();

                if ((TConfig.MinutesWithin != null && SystemStartedForMinutes <= TConfig.MinutesWithin)
                    || (TConfig.MinutesAfter != null && SystemStartedForMinutes >= TConfig.MinutesAfter))
                {
                    DateTime Now = DateTime.Now;
                    DynamicDataSet DDataSet = CommonDynamicData.BuildStandardDynamicDataSet(this, true, 0, Now, Now, 1);

                    if (!TConfig.DoNotLog)
                    {
                        Logger.Info(this, $"System up time (minutes): {SystemStartedForMinutes}");
                        Logger.EventTriggering(this);
                    }
                        
                    OnEventTriggered(new EventTriggeredEventArgs(DDataSet, Logger));
                }
            }
            catch (Exception ex)
            {
                if (!Config.DoNotLog)
                    Logger.EventError(this, ex);
            }

            List<ExecResult> execResults = new List<ExecResult>();
            execResults.Add(new ExecResult(true, null));
            return new InstanceExecResult(execResults);
        }
    }
}
