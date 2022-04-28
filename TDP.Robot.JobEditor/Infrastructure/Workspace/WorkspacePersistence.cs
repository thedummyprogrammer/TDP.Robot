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

using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;
using TDP.Robot.Core;
using TDP.Robot.Core.Persistence;
using TDP.Robot.JobEditor.Infrastructure.Workspace.Abstract;

namespace TDP.Robot.JobEditor.Infrastructure.Workspace
{
    class WorkspacePersistence
    {

        private static void CreateCoreInstances(IWorkspaceFolder workspaceFolder, Dictionary<int, IWorkspaceItem> wksItems, Folder coreFolder, Dictionary<int, IPluginInstance> coreItems)
        {
            foreach (IWorkspaceItemBase ItemBase in workspaceFolder)
            {
                if (ItemBase is IWorkspaceItem)
                {
                    IWorkspaceItem WksItem = (IWorkspaceItem)ItemBase;
                    wksItems.Add(WksItem.ID, WksItem);
                    IPlugin Plugin = Common.PluginDict[WksItem.PluginID];
                    IPluginInstance PluginInstance = Plugin.GetInstance();
                    PluginInstance.ID = WksItem.ID;
                    PluginInstance.Config = WksItem.PluginConfig;
                    PluginInstance.ParentFolder = coreFolder;
                    coreFolder.Add(PluginInstance);
                    coreItems.Add(WksItem.ID, PluginInstance);
                }
                else if (ItemBase is IWorkspaceFolder)
                {
                    IWorkspaceFolder WksFolder = (IWorkspaceFolder)ItemBase;
                    Folder CoreFolder = new Folder();
                    CoreFolder.ID = WksFolder.ID;
                    CoreFolder.ParentFolder = coreFolder;
                    coreFolder.Add(CoreFolder);
                    CreateCoreInstances(WksFolder, wksItems, coreFolder, coreItems);
                }
            }
        }

        private static Folder WorkspaceFolderToCoreFolder(IWorkspaceFolder workspaceFolder)
        {
            // Create core objects tree
            Dictionary<int, IWorkspaceItem> WksItems = new Dictionary<int, IWorkspaceItem>();
            Dictionary<int, IPluginInstance> CoreItems = new Dictionary<int, IPluginInstance>();
            
            Folder RootCoreFolder = new Folder();
            CreateCoreInstances(workspaceFolder, WksItems, RootCoreFolder, CoreItems);

            // Create connections between objects
            foreach (KeyValuePair<int, IWorkspaceItem> DE in WksItems)
            {
                IPluginInstance PISource = CoreItems[DE.Key];
                IWorkspaceItem WISource = DE.Value;
                foreach (IWorkspaceLine ItemLine in WISource.ItemsOut)
                {
                    IPluginInstance PIDest = CoreItems[ItemLine.EndItem.ID];
                    
                    List<ExecutionCondition> CoreExecConditions = new List<ExecutionCondition>();
                    foreach (IWorkspaceExecCondition EC in ItemLine.ExecuteConditions)
                    {
                        ExecutionCondition CoreEC = new ExecutionCondition(PISource, EC.DynamicDataCode, EC.Operator, EC.MinValue, EC.MaxValue);
                        CoreExecConditions.Add(CoreEC);
                    }

                    List<ExecutionCondition> CoreDontExecConditions = new List<ExecutionCondition>();
                    foreach (IWorkspaceExecCondition EC in ItemLine.DontExecuteConditions)
                    {
                        ExecutionCondition CoreDontEC = new ExecutionCondition(PISource, EC.DynamicDataCode, EC.Operator, EC.MinValue, EC.MaxValue);
                        CoreDontExecConditions.Add(CoreDontEC);
                    }

                    PISource.Connections.Add(new PluginInstanceConnection(PIDest, ItemLine.Disable, ItemLine.WaitSeconds,  CoreExecConditions, CoreDontExecConditions));
                }
            }

            return RootCoreFolder;
        }

        public static void Save(string dataPath, IWorkspaceFolder rootFolderData, bool generateJobEngineData)
        {
            //SaveXML(dataPath, rootFolderData, generateJobEngineData);

            string FilePathName = Path.Combine(dataPath, "Jobs.dat");
            BinaryFormatter Serializer = new BinaryFormatter();
            using (Stream Str = File.OpenWrite(FilePathName))
            {
                Serializer.Serialize(Str, rootFolderData);
            }

            if (generateJobEngineData)
            {
                Folder CoreFolder = WorkspaceFolderToCoreFolder(rootFolderData);
                JobsPersistence.Save(dataPath, CoreFolder);
            }
        }

        public static IWorkspaceFolder Load(string dataPath)
        {
            string FilePathName = Helpers.PathAppendBackSlash(dataPath) + "Jobs.dat";
            if (!File.Exists(FilePathName))
                return null;

            BinaryFormatter Serializer = new BinaryFormatter();
            Serializer.Binder = new PluginBinder(Common.PluginTypes);
            using (Stream Str = File.OpenRead(FilePathName))
            {
                return (IWorkspaceFolder)Serializer.Deserialize(Str);
            }
        }

        public static void SaveXML(string dataPath, IWorkspaceFolder rootFolderData, bool generateJobEngineData)
        {
            string FilePathName = Path.Combine(dataPath, "Jobs.xml");
            XmlSerialization Serializer = new XmlSerialization();
            XmlDocument XmlDoc = Serializer.Serialize(rootFolderData, "TDPRobot");

            XmlDoc.Save(FilePathName);

            if (generateJobEngineData)
            {
                Folder CoreFolder = WorkspaceFolderToCoreFolder(rootFolderData);
                JobsPersistence.SaveXML(dataPath, CoreFolder);
            }
        }

        public static IWorkspaceFolder LoadXML(string dataPath)
        {
            string FilePathName = Path.Combine(dataPath, "Jobs.xml");
            XmlDocument XmlDoc = new XmlDocument();
            XmlDoc.Load(FilePathName);

            XmlDeserialization Deserializer = new XmlDeserialization(Common.PluginTypes);
            return (IWorkspaceFolder)Deserializer.Deserialize(XmlDoc);
        }

        public static List<IWorkspaceItemBase> CloneObjects(List<IWorkspaceItemBase> items)
        {
            BinaryFormatter Serializer = new BinaryFormatter();
            Serializer.Binder = new PluginBinder(Common.PluginTypes);
            using (MemoryStream Str = new MemoryStream())
            {
                Serializer.Serialize(Str, items);
                Str.Position = 0;
                return (List<IWorkspaceItemBase>)Serializer.Deserialize(Str);
            }
        }
    }
}
