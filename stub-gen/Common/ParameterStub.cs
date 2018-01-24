using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace StubGenerator.Common
{
    public class ParameterStub: TypeStub
    {
        public string ParameterName => ActualParameter.Name;

        protected ParameterInfo ActualParameter { get; }
        protected MethodStub Method { get; }

        public ParameterStub(MethodStub method, ParameterInfo parameter) : base(parameter.ParameterType)
        {
            this.ActualParameter = parameter;
            this.Method = method;
        }
    }
}
