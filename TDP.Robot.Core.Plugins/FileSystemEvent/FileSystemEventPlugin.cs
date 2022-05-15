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
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDP.Robot.Core;
using TDP.Robot.Core.DynamicData;

namespace TDP.Robot.Plugins.Core.FileSystemEvent
{
    public class FileSystemEventPlugin : IPlugin
    {
        public string ID { get { return "FileSystemEvent"; } }

        public string Title { get { return Resource.TxtFileSystemEvent; } }

        public EnumPluginType PluginType { get { return EnumPluginType.Event; } }

        public Icon PluginIcon { get { return Resource.IcoFolderEvent32x32; } }

        public List<DynamicDataSample> SampleDynamicData
        {
            get
            {
                List<DynamicDataSample> Samples = CommonDynamicData.BuildStandardDynamicDataSamples("File system event 1");
                Samples.Add(new DynamicDataSample(FileSystemEventCommon.DynDataKeyFullPathName, Resource.TxtDynDataFullPathName, @"C:\MyFolder\MyFile.txt"));
                Samples.Add(new DynamicDataSample(FileSystemEventCommon.DynDataKeyFileName, Resource.TxtDynDataFileName, "MyFile.txt"));
                Samples.Add(new DynamicDataSample(FileSystemEventCommon.DynDataKeyFileNameWithoutExtension, Resource.TxtDynDataFileNameWithoutExtension, @"MyFile"));
                Samples.Add(new DynamicDataSample(FileSystemEventCommon.DynDataKeyFileExtension, Resource.TxtDynDataFileExtension, @"txt"));
                Samples.Add(new DynamicDataSample(FileSystemEventCommon.DynDataKeyChangeType, Resource.TxtDynDataChangeType, @"Created"));
                return Samples;
            }
        }

        public WndPluginConfigBase GetConfigWindow(IPluginInstanceConfig config, List<DynamicDataObjectSamples> dynDataObjectSamples)
        {
            WndFileSystemEventConfig F = new WndFileSystemEventConfig();
            F.PluginConfig = config;
            F.DynamicDataObjectSamples = dynDataObjectSamples;
            return F;
        }

        public IPluginInstance GetInstance()
        {
            return new FileSystemEvent();
        }

        public IPluginInstanceConfig GetPluginDefaultConfig()
        {
            return new FileSystemEventConfig();
        }

        public Type[] GetPluginTypes()
        {
            return new Type[] { typeof(FileSystemEvent), typeof(FileSystemEventConfig), typeof(FolderToMonitor), typeof(List<FolderToMonitor>), typeof(MonitorActionType) };
        }
    }
}
