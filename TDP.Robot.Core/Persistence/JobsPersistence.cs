/*======================================================================================
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
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;

namespace TDP.Robot.Core.Persistence
{
    public class JobsPersistence
    {

        public static void Save(string dataPath, Folder rootFolderData)
        {
            string FilePathName = Path.Combine(dataPath, "JobEngine.dat");
            BinaryFormatter Serializer = new BinaryFormatter();
            using (Stream Str = File.OpenWrite(FilePathName))
            {
                Serializer.Serialize(Str, rootFolderData);
            }
        }

        public static Folder Load(string dataPath, SerializationBinder binder)
        {
            string FilePathName = Path.Combine(dataPath, "JobEngine.dat");
            if (!File.Exists(FilePathName))
                return null;

            BinaryFormatter Serializer = new BinaryFormatter();
            Serializer.Binder = binder;
            using (Stream Str = File.OpenRead(FilePathName))
            {
                return (Folder)Serializer.Deserialize(Str);
            }
        }

        public static void SaveXML(string dataPath, Folder rootFolderData)
        {
            string FilePathName = Path.Combine(dataPath, "JobEngine.xml");
            XmlSerialization Serializer = new XmlSerialization();
            XmlDocument XmlDoc = Serializer.Serialize(rootFolderData, "TDPRobot");

            XmlDoc.Save(FilePathName);
        }

        public static Folder LoadXML(string dataPath, Dictionary<string, Type> pluginTypes)
        {
            string FilePathName = Path.Combine(dataPath, "JobEngine.xml");
            if (!File.Exists(FilePathName))
                return null;

            XmlDocument XmlDoc = new XmlDocument();
            XmlDoc.Load(FilePathName);

            XmlDeserialization Deserializer = new XmlDeserialization(pluginTypes);
            return (Folder)Deserializer.Deserialize(XmlDoc);
        }
    }
}
