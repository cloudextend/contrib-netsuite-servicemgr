using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace StubGenerator.Common
{
    public class Configuration
    {
        public string TargetNamespace { get; set; }
        public string SourceNamespace { get; set; }

        public Assembly SourceAssembly { get; set; }

        public Configuration()
        {
            SourceNamespace = TargetNamespace = "SuiteTalk";
        }
    }
}
