﻿/*======================================================================================
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
using System.ServiceProcess;
using TDP.Robot.JobEngineLib;

namespace TDP.Robot.JobEngineService
{
    public partial class TDPRobotJobEngine : ServiceBase
    {
        private JobEngine _JobEngine;

        public TDPRobotJobEngine()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;

            _JobEngine = new JobEngine();
            _JobEngine.Start(AppDomain.CurrentDomain.BaseDirectory);
        }

        protected override void OnStop()
        {
            _JobEngine.Stop();
        }
    }
}
