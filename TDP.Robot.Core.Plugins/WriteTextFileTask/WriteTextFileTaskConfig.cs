using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDP.Robot.Core;
using TDP.Robot.Core.DynamicData;

namespace TDP.Robot.Plugins.Core.WriteTextFileTask
{
    [Serializable]
    public enum WriteTextFileTaskType
    {
        AppendRow,
        InsertRow
    }

    [Serializable]
    public class WriteTextFileTaskConfig : ITaskConfig
    {
        public WriteTextFileTaskConfig()
        {
            ColumnsDefinition = new List<WriteTextFileColumnDefinition>();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public bool Disable { get; set; }
        public bool DoNotLog { get; set; }

        public IterationMode PluginIterationMode { get; set; }
        public string IterationObject { get; set; }
        public int IterationsCount { get; set; }

        [DynamicData]
        public string FilePath { get; set; }

        public WriteTextFileTaskType TaskType { get; set; }

        public List<WriteTextFileColumnDefinition> ColumnsDefinition { get; }

        public bool FormatAsDelimitedFile { get; set; }

        public bool DelimiterTab { get; set; }

        public bool DelimiterSemicolon { get; set; }

        public bool DelimiterComma { get; set; }

        public bool DelimiterSpace { get; set; }

        public bool DelimiterOther { get; set; }

        public string DelimiterOtherChar { get; set; }

        public bool EncloseInDoubleQuotes { get; set; }

        public bool FormatAsFixedLengthColumnsFile { get; set; }

        public bool AddHeaderIfEmpty { get; set; }

        [DynamicData]
        public string InsertAtRow { get; set; }


    }
}
