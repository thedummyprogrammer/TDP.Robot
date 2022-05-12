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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using TDP.BaseServices.Infrastructure.Security;

namespace TDP.Robot.Core.Persistence
{
    public class XmlSerialization
    {
        class ObjectSerialized
        {
            public int ID;
            public object Obj;
        }

        private int _LastObjectID;
        private List<ObjectSerialized> _ObjectsSerialized;
        private int _LastTypeID;
        private Dictionary<string, int> _ReferencedTypes;
        private XmlDocument _XmlDoc;
        private XmlElement _XmlObjectsElement;
        private XmlElement _XmlReferencesElement;

        public XmlSerialization()
        {
            _ObjectsSerialized = new List<ObjectSerialized>();
            _ReferencedTypes = new Dictionary<string, int>();
        }

        private bool TrackObject(object objectRef, out int objectID)
        {
            ObjectSerialized ObjectTracked = _ObjectsSerialized.Where(O => object.ReferenceEquals(O.Obj, objectRef)).FirstOrDefault();

            if (ObjectTracked == null)
            {
                _LastObjectID++;
                ObjectTracked = new ObjectSerialized() { ID = _LastObjectID, Obj = objectRef };
                _ObjectsSerialized.Add(ObjectTracked);
                objectID = _LastObjectID;

                return false;
            }
            else
            {
                objectID = ObjectTracked.ID;
                return true;
            }
        }

        private XmlAttribute CreateTypeAttribute(object objectToSerialize)
        {
            int RefTypeID;
            string ObjectType = objectToSerialize.GetType().AssemblyQualifiedName;
            if (!_ReferencedTypes.ContainsKey(ObjectType))
            {
                _LastTypeID++;
                _ReferencedTypes.Add(ObjectType, _LastTypeID);
                XmlElement XmlRefElement = _XmlDoc.CreateElement(XmlCommon.ReferenceTagName);
                XmlRefElement.SetAttribute(XmlCommon.RefTypeIDAttributeName, _LastTypeID.ToString());
                XmlRefElement.InnerText = ObjectType;
                _XmlReferencesElement.AppendChild(XmlRefElement);

                RefTypeID = _LastTypeID;
            }
            else
            {
                RefTypeID = _ReferencedTypes[ObjectType];
            }

            XmlAttribute XmlTypeAttr = _XmlDoc.CreateAttribute(XmlCommon.RefTypeIDAttributeName);
            XmlTypeAttr.Value = RefTypeID.ToString();

            return XmlTypeAttr;
        }

        private XmlElement SerializePrimitive(object objectToSerialize, string tagName)
        {
            XmlElement XmlEl = _XmlDoc.CreateElement(tagName);
            XmlEl.InnerText = objectToSerialize.ToString();
            XmlEl.Attributes.Append(CreateTypeAttribute(objectToSerialize));

            return XmlEl;
        }

        private XmlElement SerializeEnum(object objectToSerialize, string tagName)
        {
            XmlElement XmlEl = _XmlDoc.CreateElement(tagName);
            XmlEl.InnerText = objectToSerialize.ToString();
            XmlEl.Attributes.Append(CreateTypeAttribute(objectToSerialize));

            return XmlEl;
        }

        private XmlElement SerializeString(string objectToSerialize, string tagName, bool encrypt)
        {
            XmlElement XmlEl = _XmlDoc.CreateElement(tagName);
            
            if (encrypt)
            {
                byte[] StringBytes = Encoding.UTF8.GetBytes(objectToSerialize.ToString());
                XmlEl.InnerText = Convert.ToBase64String(AsymmetricCryptography.EncryptData(StringBytes, XmlCommon.KeyContainerName, true, true));
                XmlEl.SetAttribute(XmlCommon.EncryptedAttributeName, true.ToString());
            }
            else
                XmlEl.InnerText = objectToSerialize.ToString();

            XmlEl.Attributes.Append(CreateTypeAttribute(objectToSerialize));

            return XmlEl;
        }

        private XmlElement SerializeIcon(Icon objectToSerialize, string tagName, int objectID)
        {
            XmlElement XmlEl = _XmlDoc.CreateElement(tagName);

            XmlAttribute XmlRefAttr = _XmlDoc.CreateAttribute(XmlCommon.RefIDAttributeName);
            XmlRefAttr.Value = objectID.ToString();
            XmlEl.Attributes.Append(XmlRefAttr);
            XmlEl.Attributes.Append(CreateTypeAttribute(objectToSerialize));

            using (MemoryStream MS = new MemoryStream())
            {
                objectToSerialize.Save(MS);
                XmlEl.InnerText = Convert.ToBase64String(MS.ToArray());
            }

            return XmlEl;
        }

        private XmlElement SerializeObjectRef(int objectID, string tagName)
        {
            XmlElement XmlEl = _XmlDoc.CreateElement(tagName);
            XmlEl.SetAttribute(XmlCommon.RefIDAttributeName, objectID.ToString());
            return XmlEl;
        }

        private XmlElement SerializeInnerObject(object objectToSerialize, string tagName, bool encrypt)
        {
            XmlElement XmlEl;
            Type ObjType = objectToSerialize.GetType();

            if (ObjType.IsPrimitive)
            {
                XmlEl = SerializePrimitive(objectToSerialize, tagName);
            }
            else if (ObjType.IsValueType && !ObjType.IsEnum)
            {
                XmlEl = SerializeStruct(objectToSerialize, tagName);
            }
            else if (ObjType.IsValueType && ObjType.IsEnum)
            {
                XmlEl = SerializeEnum(objectToSerialize, tagName);
            }
            else if (ObjType.IsArray && ObjType == typeof(byte[]))
            {
                bool ObjectExists = TrackObject(objectToSerialize, out int ObjectID);

                if (!ObjectExists)
                {
                    _XmlObjectsElement.AppendChild(SerializeByteArray((byte[])objectToSerialize, XmlCommon.ObjectTagName, ObjectID));
                }

                XmlEl = SerializeObjectRef(ObjectID, tagName);
            }
            else if (ObjType.IsArray)
            {
                bool ObjectExists = TrackObject(objectToSerialize, out int ObjectID);

                if (!ObjectExists)
                {
                    _XmlObjectsElement.AppendChild(SerializeArray(objectToSerialize, XmlCommon.ObjectTagName, ObjectID));
                }

                XmlEl = SerializeObjectRef(ObjectID, tagName);
            }
            else if (ObjType.IsClass && ObjType == typeof(string))
            {
                XmlEl = SerializeString((string)objectToSerialize, tagName, encrypt);
            }
            else if (ObjType.IsClass && ObjType == typeof(Icon))
            {
                bool ObjectExists = TrackObject(objectToSerialize, out int ObjectID);

                if (!ObjectExists)
                {
                    _XmlObjectsElement.AppendChild(SerializeIcon((Icon)objectToSerialize, XmlCommon.ObjectTagName, ObjectID));
                }

                XmlEl = SerializeObjectRef(ObjectID, tagName);
            }
            else if (XmlCommon.Type_IsList(ObjType))
            {
                bool ObjectExists = TrackObject(objectToSerialize, out int ObjectID);

                if (!ObjectExists)
                {
                    _XmlObjectsElement.AppendChild(SerializeList(objectToSerialize, XmlCommon.ObjectTagName, ObjectID));
                }

                XmlEl = SerializeObjectRef(ObjectID, tagName);
            }
            else if (ObjType.IsClass || ObjType.IsInterface)
            {
                bool ObjectExists = TrackObject(objectToSerialize, out int ObjectID);

                if (!ObjectExists)
                {
                    _XmlObjectsElement.AppendChild(SerializeObject(objectToSerialize, XmlCommon.ObjectTagName, ObjectID));
                }

                XmlEl = SerializeObjectRef(ObjectID, tagName);
            }
            else
            {
                XmlEl = _XmlDoc.CreateElement(tagName);
            }

            return XmlEl;
        }

        private XmlElement SerializeList(object objectToSerialize, string tagName, int objectID)
        {
            XmlElement XmlEl = _XmlDoc.CreateElement(tagName);

            XmlAttribute XmlRefAttr = _XmlDoc.CreateAttribute(XmlCommon.RefIDAttributeName);
            XmlRefAttr.Value = objectID.ToString();
            XmlEl.Attributes.Append(XmlRefAttr);
            XmlEl.Attributes.Append(CreateTypeAttribute(objectToSerialize));

            XmlElement XmlElItems = _XmlDoc.CreateElement(XmlCommon.ListItemsTagName);
            XmlEl.AppendChild(XmlElItems);

            IEnumerable List = (IEnumerable)objectToSerialize;
            foreach (object ListItem in List)
            {
                XmlElement XmlListItem = SerializeInnerObject(ListItem, XmlCommon.ListItemTagName, false);
                XmlElItems.AppendChild(XmlListItem);
            }

            return XmlEl;
        }

        private XmlElement SerializeArray(object objectToSerialize, string tagName, int objectID)
        {
            XmlElement XmlEl = _XmlDoc.CreateElement(tagName);

            XmlAttribute XmlRefAttr = _XmlDoc.CreateAttribute(XmlCommon.RefIDAttributeName);
            XmlRefAttr.Value = objectID.ToString();
            XmlEl.Attributes.Append(XmlRefAttr);
            XmlEl.Attributes.Append(CreateTypeAttribute(objectToSerialize));

            XmlElement XmlElItems = _XmlDoc.CreateElement(XmlCommon.ListItemsTagName);
            XmlEl.AppendChild(XmlElItems);

            IEnumerable List = (IEnumerable)objectToSerialize;
            foreach (object ListItem in List)
            {
                if (ListItem != null)
                {
                    XmlElement XmlListItem = SerializeInnerObject(ListItem, XmlCommon.ListItemTagName, false);
                    XmlElItems.AppendChild(XmlListItem);
                }
            }

            return XmlEl;
        }

        private XmlElement SerializeByteArray(byte[] objectToSerialize, string tagName, int objectID)
        {
            XmlElement XmlEl = _XmlDoc.CreateElement(tagName);

            XmlAttribute XmlRefAttr = _XmlDoc.CreateAttribute(XmlCommon.RefIDAttributeName);
            XmlRefAttr.Value = objectID.ToString();
            XmlEl.Attributes.Append(XmlRefAttr);
            XmlEl.Attributes.Append(CreateTypeAttribute(objectToSerialize));

            XmlEl.InnerText = Convert.ToBase64String(objectToSerialize);

            return XmlEl;
        }

        private XmlElement SerializeNullValue(string tagName)
        {
            XmlElement XmlEl = _XmlDoc.CreateElement(tagName);
            XmlAttribute XmlIsNullAttr = _XmlDoc.CreateAttribute(XmlCommon.IsNullAttributeName);
            XmlIsNullAttr.Value = "true";
            XmlEl.Attributes.Append(XmlIsNullAttr);
            
            return XmlEl;
        }

        private XmlElement SerializeObject(object objectToSerialize, string tagName, int objectID)
        {
            Type ObjectType = objectToSerialize.GetType();

            XmlElement XmlEl = _XmlDoc.CreateElement(tagName);

            XmlAttribute XmlRefAttr = _XmlDoc.CreateAttribute(XmlCommon.RefIDAttributeName);
            XmlRefAttr.Value = objectID.ToString();
            XmlEl.Attributes.Append(XmlRefAttr);
            XmlEl.Attributes.Append(CreateTypeAttribute(objectToSerialize));

            // Take care of parent classes!
            Type CurrentType = ObjectType;
            do
            {
                FieldInfo[] Fields = CurrentType.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

                foreach (FieldInfo FI in Fields)
                {
                    if (XmlCommon.Field_IsEvent(FI)
                        || XmlCommon.Field_IsPtr(FI)
                        || !XmlCommon.Field_IsSerializable(FI))
                        continue;

                    string FieldName = XmlCommon.Field_GetFieldName(FI);

                    if (XmlCommon.Field_IsNull(objectToSerialize, FI))
                        XmlEl.AppendChild(SerializeNullValue(FieldName));
                    else
                        XmlEl.AppendChild(SerializeInnerObject(FI.GetValue(objectToSerialize), FieldName, XmlCommon.Field_HasAttribute(FI, typeof(XmlEncryptFieldAttribute))));
                }

                CurrentType = CurrentType.BaseType;
            } while (CurrentType != null);

            return XmlEl;
        }

        private XmlElement SerializeStruct(object objectToSerialize, string tagName)
        {
            XmlElement XmlEl = _XmlDoc.CreateElement(tagName);
            XmlEl.Attributes.Append(CreateTypeAttribute(objectToSerialize));

            Type ObjectType = objectToSerialize.GetType();
            FieldInfo[] Fields = ObjectType.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (FieldInfo FI in Fields)
            {
                if (XmlCommon.Field_IsNull(objectToSerialize, FI)
                    || XmlCommon.Field_IsEvent(FI)
                    || XmlCommon.Field_IsPtr(FI)
                    || !XmlCommon.Field_IsSerializable(FI))
                    continue;

                string FieldName = XmlCommon.Field_GetFieldName(FI);

                if (XmlCommon.Field_IsNull(objectToSerialize, FI))
                    XmlEl.AppendChild(SerializeNullValue(FieldName));
                else
                    XmlEl.AppendChild(SerializeInnerObject(FI.GetValue(objectToSerialize), FieldName, XmlCommon.Field_HasAttribute(FI, typeof(XmlEncryptFieldAttribute))));
            }

            return XmlEl;
        }

        private XmlElement SerializeRootObject(object objectToSerialize)
        {
            XmlElement XmlEl;
            Type ObjectType = objectToSerialize.GetType();

            if (ObjectType.IsPrimitive)
            {
                XmlEl = SerializePrimitive(objectToSerialize, XmlCommon.ObjectTagName);
            }
            else if (ObjectType.IsValueType && !ObjectType.IsEnum)
            {
                XmlEl = SerializeStruct(objectToSerialize, XmlCommon.ObjectTagName);
            }
            else if (ObjectType.IsClass && ObjectType == typeof(string))
            {
                XmlEl = SerializeString((string)objectToSerialize, XmlCommon.ObjectTagName, false);
            }
            else if (XmlCommon.Type_IsList(ObjectType))
            {
                TrackObject(objectToSerialize, out int ObjectID);
                XmlEl = SerializeList(objectToSerialize, XmlCommon.ObjectTagName, ObjectID);
            }
            else if (ObjectType.IsClass || ObjectType.IsInterface)
            {
                TrackObject(objectToSerialize, out int ObjectID);
                XmlEl = SerializeObject(objectToSerialize, XmlCommon.ObjectTagName, ObjectID);
            }
            else
            {
                throw new ApplicationException("Unrecognized object type.");
            }

            XmlEl.SetAttribute(XmlCommon.RootObjectAttributeName, true.ToString());

            return XmlEl;
        }

        public XmlDocument Serialize(object objectGraph, string rootElementName)
        {
            _LastObjectID = 0;
            _ObjectsSerialized.Clear();
            _XmlDoc = new XmlDocument();

            XmlElement XmlRootEl = _XmlDoc.CreateElement(rootElementName);
            _XmlDoc.AppendChild(XmlRootEl);

            // Create Objects element
            _XmlObjectsElement = _XmlDoc.CreateElement(XmlCommon.ObjectsTagName);
            XmlRootEl.AppendChild(_XmlObjectsElement);

            // Create References element
            _XmlReferencesElement = _XmlDoc.CreateElement(XmlCommon.ReferencesTagName);
            XmlRootEl.AppendChild(_XmlReferencesElement);

            _XmlObjectsElement.AppendChild(SerializeRootObject(objectGraph));

            return _XmlDoc;
        }
    }
}
