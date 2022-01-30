using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using TDP.Robot.Core;
using TDP.Robot.Plugins.Core.ExcelFileTask;
using System.Runtime.Serialization;
using System.Xml;
using System.Text.Json;

namespace TDP.Robot.UnitTests
{
    [TestClass]
    public class TestXMLSerialization
    {
        [TestMethod]
        public void TestXMLSerialization1()
        {
            ExcelFileTask TaskInstance = new ExcelFileTask();
            TaskInstance.ID = 1000;
            TaskInstance.Config = new ExcelFileTaskConfig();
            TaskInstance.Config.ID = 1000;
            TaskInstance.Config.Name = "Test";
            ITask IT = TaskInstance;
            object O = TaskInstance;


            string S = JsonSerializer.Serialize(O);
            System.Diagnostics.Debug.Write(S);


            /*
            XmlSerializer serializer = new XmlSerializer(O.GetType());
            TextWriter writer = new StreamWriter(@"C:\_Appoggio\test.xml");
            serializer.Serialize(writer, IT);
            writer.Close();
            */

            /*
            Type[] extraTypes = new Type[] { typeof(ExcelFileTaskConfig) };

            DataContractSerializer serializer = new DataContractSerializer(O.GetType(), extraTypes);
            StringWriter sw = new StringWriter();
            XmlTextWriter xw = new XmlTextWriter(sw);
            serializer.WriteObject(xw, O);
            System.Diagnostics.Debug.Write(sw.ToString());
            */
        }

    }
}
