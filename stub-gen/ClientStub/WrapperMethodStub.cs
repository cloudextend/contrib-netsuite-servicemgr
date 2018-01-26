using StubGenerator.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace StubGenerator.ClientStub
{
    public class WrapperMethodStub: MethodStub
    {
        public TypeStub WrappedParameterType { get; set; }
        public List<string> WrappedParameterProperties { get; set; } = new List<string>(7);

        public WrapperMethodStub(string methodName): base(methodName)
        {
        }
    }
}
