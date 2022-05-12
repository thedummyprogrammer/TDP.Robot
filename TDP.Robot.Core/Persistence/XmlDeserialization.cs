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
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TDP.BaseServices.Infrastructure.Security;

namespace TDP.Robot.Core.Persistence
{
    public class XmlDeserialization
    {
        private XmlDocument _XmlDoc;
        private Dictionary<int, XmlElement> _XmlObjects;
        private XmlElement _XmlRootObject;
        private Dictionary<int, object> _ObjectsDeserialized;
        private Dictionary<int, string> _References;

        public Dictionary<string, Type> PluginTypes { get; set; }
        

        public XmlDeserialization()
        {
            _XmlObjects = new Dictionary<int, XmlElement>();
            _ObjectsDeserialized = new Dictionary<int, object>();
            _References = new Dictionary<int, string>();
        }

        public XmlDeserialization(Dictionary<string, Type> pluginTypes) : this()
        {
            PluginTypes = pluginTypes;
        }

        private bool CheckIfObjectExists(int objectID, out object objectRef)
        {
            if (!_ObjectsDeserialized.ContainsKey(objectID))
            {
                objectRef = null;
                return false;
            }
            else
            {
                objectRef = _ObjectsDeserialized[objectID];
                return true;
            }
        }

        private bool HasDefaultConstructor(Type objectType)
        {
            return objectType.IsValueType || objectType.GetConstructor(Type.EmptyTypes) != null;
        }

        private object CreateObjectInstance(Type objectType)
        {
            if (objectType == typeof(string))
                return new string(new char[] { });
            else if (HasDefaultConstructor(objectType))
                return Activator.CreateInstance(objectType);
            else
                return FormatterServices.GetUninitializedObject(objectType);
        }

        private FieldInfo FindField(FieldInfo[] fields, string fieldName)
        {
            return fields.Where(F => F.Name == fieldName || F.Name == XmlCommon.Field_GetAutomaticPropFieldName(fieldName)).FirstOrDefault();
        }

        private Type GetType(string refID)
        {
            string TypeAssemblyQualifiedName = _References[int.Parse(refID)];
            if (PluginTypes.ContainsKey(TypeAssemblyQualifiedName))
                return PluginTypes[TypeAssemblyQualifiedName];

            return Type.GetType(TypeAssemblyQualifiedName);
        }

        private object DeserializeArray(XmlElement xmlObject)
        {
            if (xmlObject.HasAttribute(XmlCommon.IsNullAttributeName))
                return null;

            Type ObjType = GetType(xmlObject.GetAttribute(XmlCommon.RefTypeIDAttributeName));
            XmlNodeList XmlItems = xmlObject.GetElementsByTagName(XmlCommon.ListItemTagName);

            IList ObjArray = (IList)Activator.CreateInstance(ObjType, new object[] { XmlItems.Count });

            for (int i = 0; i < XmlItems.Count; i++)
            {
                object ObjItem = DeserializeObject((XmlElement)XmlItems[i]);
                ObjArray[i] = ObjItem;
            }

            return ObjArray;
        }

        private object DeserializeStruct(XmlElement xmlObject)
        {
            Type ObjType = GetType(xmlObject.GetAttribute(XmlCommon.RefTypeIDAttributeName));
            FieldInfo[] Fields = ObjType.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            object ObjClass = CreateObjectInstance(ObjType);

            foreach (XmlElement XmlSubElement in xmlObject.ChildNodes)
            {
                XmlElement XmlObjectToDeserialize;
                FieldInfo FI = FindField(Fields, XmlSubElement.Name);

                if (FI != null)
                {
                    if (XmlSubElement.HasAttribute(XmlCommon.RefIDAttributeName))
                    {
                        int RefObjectID = int.Parse(XmlSubElement.GetAttribute(XmlCommon.RefIDAttributeName));
                        XmlObjectToDeserialize = _XmlObjects[RefObjectID];
                    }
                    else
                        XmlObjectToDeserialize = XmlSubElement;

                    FI.SetValue(ObjClass, DeserializeObject(XmlObjectToDeserialize));
                }
            }

            return ObjClass;
        }

        private object DeserializeList(XmlElement xmlObject)
        {
            if (xmlObject.HasAttribute(XmlCommon.IsNullAttributeName))
                return null;

            Type ObjType = GetType(xmlObject.GetAttribute(XmlCommon.RefTypeIDAttributeName));
            
            IList ObjList = (IList)Activator.CreateInstance(ObjType);
            
            int ThisObjectID = int.Parse(xmlObject.GetAttribute(XmlCommon.RefIDAttributeName));
            bool ObjectExists = CheckIfObjectExists(ThisObjectID, out object ThisObject);
            if (ObjectExists)
                return ThisObject;
            else
                _ObjectsDeserialized.Add(ThisObjectID, ObjList);

            XmlNodeList XmlItems = xmlObject.GetElementsByTagName(XmlCommon.ListItemTagName);
            for (int i = 0; i < XmlItems.Count; i++)
            {
                XmlElement XmlSubElement = (XmlElement)XmlItems[i];
                XmlElement XmlObjectToDeserialize;

                if (XmlSubElement.HasAttribute(XmlCommon.RefIDAttributeName))
                {
                    int RefObjectID = int.Parse(XmlSubElement.GetAttribute(XmlCommon.RefIDAttributeName));
                    XmlObjectToDeserialize = _XmlObjects[RefObjectID];
                }
                else
                    XmlObjectToDeserialize = XmlSubElement;

                object ObjItem = DeserializeObject(XmlObjectToDeserialize);
                ObjList.Add(ObjItem);
            }

            return ObjList;
        }

        private object DeserializeClass(XmlElement xmlObject)
        {
            if (xmlObject.HasAttribute(XmlCommon.IsNullAttributeName))
                return null;

            Type ObjType = GetType(xmlObject.GetAttribute(XmlCommon.RefTypeIDAttributeName));
            int RefObjectID = -1;
            int ThisObjectID = int.Parse(xmlObject.GetAttribute(XmlCommon.RefIDAttributeName));

            // Take care of parent classes!
            List<FieldInfo> FieldList = new List<FieldInfo>();
            Type CurrentType = ObjType;
            do
            {
                FieldInfo[] TypeFields = CurrentType.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                FieldList.AddRange(TypeFields);
                CurrentType = CurrentType.BaseType;
            } while (CurrentType != null);
            FieldInfo[] Fields = FieldList.ToArray();

            object ObjClass = CreateObjectInstance(ObjType);

            bool ObjectExists = CheckIfObjectExists(ThisObjectID, out object ThisObject);
            if (ObjectExists)
                return ThisObject;
            else
                _ObjectsDeserialized.Add(ThisObjectID, ObjClass);

            foreach (XmlElement XmlSubElement in xmlObject.ChildNodes)
            {
                XmlElement XmlObjectToDeserialize;
                FieldInfo FI = FindField(Fields, XmlSubElement.Name);

                if (FI != null)
                {
                    if (XmlSubElement.HasAttribute(XmlCommon.RefIDAttributeName))
                    {
                        RefObjectID = int.Parse(XmlSubElement.GetAttribute(XmlCommon.RefIDAttributeName));
                        XmlObjectToDeserialize = _XmlObjects[RefObjectID];
                    }
                    else
                        XmlObjectToDeserialize = XmlSubElement;

                    if (ThisObjectID != RefObjectID)
                        FI.SetValue(ObjClass, DeserializeObject(XmlObjectToDeserialize));
                    else
                        FI.SetValue(ObjClass, ObjClass);
                }
            }

            return ObjClass;
        }

        private object DeserializeObject(XmlElement xmlObject)
        {
            if (xmlObject.HasAttribute(XmlCommon.IsNullAttributeName))
                return null;

            Type ObjType = GetType(xmlObject.GetAttribute(XmlCommon.RefTypeIDAttributeName));

            if (ObjType.IsPrimitive)
            {
                TypeConverter Converter = TypeDescriptor.GetConverter(ObjType);
                return Converter.ConvertFromString(xmlObject.InnerText);
            }
            else if (ObjType.IsValueType && !ObjType.IsEnum)
            {
                return DeserializeStruct(xmlObject);
            }
            else if (ObjType.IsValueType && ObjType.IsEnum)
            {
                TypeConverter Converter = TypeDescriptor.GetConverter(ObjType);
                return Converter.ConvertFromString(xmlObject.InnerText);
            }
            else if (ObjType.IsArray && ObjType == typeof(byte[]))
            {
                return Convert.FromBase64String(xmlObject.InnerText);
            }
            else if (ObjType.IsArray)
            {
                return DeserializeArray(xmlObject);
            }
            else if (ObjType.IsClass && ObjType == typeof(string))
            {
                if (xmlObject.HasAttribute(XmlCommon.EncryptedAttributeName))
                {
                    byte[] EncryptedBytes = Convert.FromBase64String(xmlObject.InnerText);
                    byte[] DecryptedBytes = AsymmetricCryptography.DecryptData(EncryptedBytes, XmlCommon.KeyContainerName, true, true);
                    return Encoding.UTF8.GetString(DecryptedBytes, 0, DecryptedBytes.Length);
                }
                else
                    return xmlObject.InnerText;
            }
            else if (ObjType.IsClass && ObjType == typeof(Icon))
            {
                using (MemoryStream MS = new MemoryStream(Convert.FromBase64String(xmlObject.InnerText)))
                {
                    return new Icon(MS);
                }
            }
            else if (XmlCommon.Type_IsList(ObjType))
            {
                return DeserializeList(xmlObject);
            }
            else if (ObjType.IsClass || ObjType.IsInterface)
            {
                return DeserializeClass(xmlObject);
            }
            else
            {

            }

            return null;
        }

        private object DeserializeXmlDoc()
        {
            foreach (XmlElement XmlObject in _XmlDoc.GetElementsByTagName(XmlCommon.ObjectTagName))
            {
                _XmlObjects.Add(int.Parse(XmlObject.GetAttribute(XmlCommon.RefIDAttributeName)), XmlObject);
            }

            foreach (XmlElement XmlRef in _XmlDoc.GetElementsByTagName(XmlCommon.ReferenceTagName))
            {
                _References.Add(int.Parse(XmlRef.GetAttribute(XmlCommon.RefTypeIDAttributeName)), XmlRef.InnerText);
            }

            _XmlRootObject = (XmlElement)_XmlDoc.SelectSingleNode($"//{XmlCommon.ObjectTagName}[@{XmlCommon.RootObjectAttributeName}='True']");
            object FirstObject = DeserializeObject(_XmlRootObject);

            return FirstObject;
        }

        public object Deserialize(XmlDocument xmlDoc)
        {
            _XmlDoc = xmlDoc;
            return DeserializeXmlDoc();
        }
    }
}
