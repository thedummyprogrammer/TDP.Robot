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
using System.Collections.Generic;
using TDP.BaseServices.Infrastructure.Logging;
using TDP.BaseServices.Infrastructure.Logging.Abstract;
using TDP.Robot.Core;
using TDP.Robot.JobEditor.Infrastructure.Workspace.Abstract;

namespace TDP.Robot.JobEditor
{
    static class Common
    {
        public static ILogger Log { get; set; }

        // Plugin types list
        public static Dictionary<string, Type> PluginTypes { get; set; }

        // Plugin list and plugin dictionary: same content stored in different way
        public static List<IPlugin> PluginList { get; set; }
        public static Dictionary<string, IPlugin> PluginDict { get; set; }

        //Root folder: contains all events, tasks, folders...
        public static IWorkspaceFolder RootFolder { get; set; }

        public static void Init()
        {
            Log = new Logger();
            PluginTypes = new Dictionary<string, Type>();
            PluginList = new List<IPlugin>();
            PluginDict = new Dictionary<string, IPlugin>();
            RootFolder = null;
        }
    }
}
