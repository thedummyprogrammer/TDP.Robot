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
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TDP.Robot.Core.Persistence
{
    static class XmlCommon
    {
        public const string KeyContainerName = "TDPRobotCryptoKey3";

        public const string ObjectTagName = "Object";
        public const string ObjectsTagName = "Objects";
        public const string ListItemTagName = "ListItem";
        public const string ListItemsTagName = "ListItems";
        public const string ReferenceTagName = "Reference";
        public const string ReferencesTagName = "References";

        public const string RefIDAttributeName = "RefID";
        public const string TypeAttributeName = "Type";
        public const string RefTypeIDAttributeName = "RefTypeID";
        public const string RootObjectAttributeName = "RootObject";
        public const string EncryptedAttributeName = "Encrypted";
        public const string IsNullAttributeName = "IsNull";


        public static bool Field_IsNull(object objectRef, FieldInfo fieldInfo)
        {
            return (fieldInfo.GetValue(objectRef) == null);
        }

        public static bool Field_IsEvent(FieldInfo fieldInfo)
        {
            return (fieldInfo.FieldType.BaseType == typeof(MulticastDelegate));
        }

        public static bool Field_IsList(FieldInfo fieldInfo)
        {
            return (fieldInfo.FieldType.IsClass && fieldInfo.FieldType.IsGenericType && fieldInfo.FieldType.GetGenericTypeDefinition().IsAssignableFrom(typeof(List<>)));
        }

        public static bool Field_IsPtr(FieldInfo fieldInfo)
        {
            return (fieldInfo.FieldType == typeof(IntPtr) || fieldInfo.FieldType == typeof(UIntPtr));
        }

        public static bool Field_IsSerializable(FieldInfo fieldInfo)
        {
            return !fieldInfo.IsNotSerialized;
        }

        public static bool Field_HasAttribute(FieldInfo fieldInfo, Type attribute)
        {
            return fieldInfo.CustomAttributes.Where(A => A.AttributeType == attribute).FirstOrDefault() != null;
        }

        public static bool Type_IsList(Type objectType)
        {
            return (objectType.IsClass && objectType.IsGenericType && objectType.GetGenericTypeDefinition().IsAssignableFrom(typeof(List<>)));
        }

        public static string Field_GetFieldName(FieldInfo fieldInfo)
        {
            // Take care of automatic properties! (<{0}>k__BackingField)
            Match Mt = Regex.Match(fieldInfo.Name, @"^\<(\w+)\>k__BackingField$");

            if (Mt.Success)
                return Mt.Groups[1].Value;
            else
                return fieldInfo.Name;
        }

        public static string Field_GetAutomaticPropFieldName(string propertyName)
        {
            return $"<{propertyName}>k__BackingField";
        }
    }
}
