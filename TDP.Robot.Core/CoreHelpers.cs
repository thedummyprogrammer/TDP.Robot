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
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using TDP.BaseServices.Infrastructure.Logging.Abstract;
using TDP.Robot.Core.Persistence;

namespace TDP.Robot.Core
{
    public static class CoreHelpers
    {
        public static object _ObjectCloning = new object();

        public static Dictionary<string, Type> Plugins { get; set; }
        
        public static string ToIsoDate(this DateTime date)
        {
            return date.ToString("s", System.Globalization.CultureInfo.InvariantCulture);
        }

        public static void SetSelectedItem(this ComboBox comboBox, object value)
        {
            foreach (object obj in comboBox.Items)
            {
                if (obj.Equals(value))
                {
                    comboBox.SelectedItem = obj;
                }
            }
        }

        public static object CloneObjects(object items)
        {
            BinaryFormatter Serializer = new BinaryFormatter();

            if (Plugins != null)
                Serializer.Binder = new PluginBinder(Plugins);

            lock (_ObjectCloning)
            {
                using (MemoryStream Str = new MemoryStream())
                {
                    Serializer.Serialize(Str, items);
                    Str.Position = 0;
                    return Serializer.Deserialize(Str);
                }
            }
        }

        public static bool LoadPlugins(string libPath, ILogger logger, 
                                            Dictionary<string, Type> pluginTypes, List<IPlugin> pluginList, Dictionary<string, IPlugin> pluginDict)
        {
            logger.Info($"Loading plugins from directory: {libPath}");
            bool Result = true;

            foreach (string DirectoryName in Directory.GetDirectories(libPath))
            {
                string SubDirPath = Path.Combine(libPath, DirectoryName);
                logger.Info($"Scanning directory: {SubDirPath}");

                foreach (string FileLibName in Directory.GetFiles(SubDirPath))
                {
                    try
                    {
                        FileInfo FileLibInfo = new FileInfo(FileLibName);
                        if (FileLibInfo.Name.ToLower().StartsWith("tdp.robot.plugins") && FileLibInfo.Name.ToLower().EndsWith(".dll"))
                        {
                            logger.Info($"Loading library {FileLibName}...");
                            
                            Assembly Asx = Assembly.LoadFrom(FileLibName);
                            foreach (Type TypeExported in Asx.ExportedTypes)
                            {
                                if (typeof(IPlugin).IsAssignableFrom(TypeExported))
                                {
                                    IPlugin PluginObj = (IPlugin)Activator.CreateInstance(TypeExported);
                                    pluginList.Add(PluginObj);
                                    pluginDict.Add(PluginObj.ID, PluginObj);

                                    foreach (Type TypeDep in PluginObj.GetPluginTypes())
                                    {
                                        if (!pluginTypes.ContainsKey(TypeDep.AssemblyQualifiedName))
                                            pluginTypes.Add(TypeDep.AssemblyQualifiedName, TypeDep);
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        logger.Error($"Error loading library {FileLibName}", ex);
                        Result = false;
                    }
                }
            }

            return Result;
        }
    }
}
