using StubGenerator.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StubGenerator.ClientStub
{
    public class ClientTypeStub : TypeStub
    {
        public TypeStub Interface { get; set; }

        public ClientTypeStub(Type clientType): base(clientType)
        {
        }

        public IEnumerable<WrapperMethodStub> GetWrapperMethods()
        {
            return from m in this.Methods
                   where m is WrapperMethodStub
                   select (WrapperMethodStub)m;
        }
    }
}
