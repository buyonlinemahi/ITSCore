using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace T4Scaffolding.Configuration
{
    public partial class ConfigurationTemplate
    {
        private string NameSpace;
        private string _ModelName;
        public string BaseNameSpace
        {
            get
            {
                return NameSpace;
            }
        }

        public string ModelName
        {
            get { return _ModelName; }
        }

        public string FileName
        {
            get { return string.Format("{0}Configuration.cs", _ModelName); }
        }

        public string ClassName
        {
            get { return string.Format("{0}Configuration", _ModelName); }
        }

        public ConfigurationTemplate(string name, string @namespace)
        {
            _ModelName = name;
            NameSpace = @namespace;
        }
    }
}
