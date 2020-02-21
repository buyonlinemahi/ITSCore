using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace T4Scaffolding.ContextFactory
{
    public partial class DBContextFactoryTemplate
    {
        private string _DBContextName;
        private string _NameSpace;

        public string FileName
        {
            get { return "ContextFactory.cs"; }
        }

        public string DBContextName
        {
            get { return string.Format("{0}DBContext", _DBContextName); }
            set { _DBContextName = value; }
        }

        public string NameSpace
        {
            get { return _NameSpace; }
            set { _NameSpace = value; }
        }


        public DBContextFactoryTemplate(string _dbContextName, string _nameSpace)
        {
            _DBContextName = _dbContextName;
            _NameSpace = _nameSpace;
        }
    }
}
