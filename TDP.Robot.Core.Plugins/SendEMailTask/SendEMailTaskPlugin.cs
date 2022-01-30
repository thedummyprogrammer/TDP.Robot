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
using System.Drawing;
using TDP.Robot.Core;
using TDP.Robot.Core.DynamicData;

namespace TDP.Robot.Plugins.Core.SendEMailTask
{
    public class SendEMailTaskPlugin : IPlugin
    {
        public string ID { get { return "SendEMailTask"; } }
        public string Title { get { return Resource.TxtSendEMailTask; } }
        public EnumPluginType PluginType { get { return EnumPluginType.Task; } }
        public Icon PluginIcon { get { return Resource.IcoMail32x32; } }

        public List<DynamicDataSample> SampleDynamicData
        {
            get
            {
                return CommonDynamicData.BuildStandardDynamicDataSamples("Send email task 1");
            }
        }

        public WndPluginConfigBase GetConfigWindow(IPluginInstanceConfig config, List<DynamicDataObjectSamples> dynDataObjectSamples)
        {
            WndSendEMailTaskConfig F = new WndSendEMailTaskConfig();
            F.PluginConfig = config;
            F.DynamicDataObjectSamples = dynDataObjectSamples;
            return F;
        }

        public IPluginInstance GetInstance()
        {
            return new SendEMailTask();
        }

        public IPluginInstanceConfig GetPluginDefaultConfig()
        {
            return new SendEMailTaskConfig();
        }

        public Type[] GetPluginTypes()
        {
            return new Type[] { typeof(SendEMailTask), typeof(SendEMailTaskConfig) };
        }
    }
}
