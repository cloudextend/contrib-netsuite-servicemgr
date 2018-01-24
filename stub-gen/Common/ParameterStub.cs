using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace StubGenerator.Common
{
    public class ParameterStub
    {
        public string Name { get; set; }
        public TypeStub ParameterType { get; set; }

        public ParameterStub(ParameterInfo parameter)
        {
            this.Name = parameter.Name;
            this.ParameterType = new TypeStub(parameter.ParameterType);
        }

        public ParameterStub()
        {
        }

        public override string ToString()
        {
            return this.ToString(null);
        }

        public string ToString(string relativeTo)
        {
            return string.Concat(this.ParameterType.ToString(relativeTo), " ", this.Name);
        }
    }
}
