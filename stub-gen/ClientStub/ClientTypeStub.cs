using StubGenerator.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace StubGenerator.ClientStub
{
    public class ClientTypeStub : TypeStub
    {
        public TypeStub Interface { get; set; }

        public ClientTypeStub(Type clientType): base(clientType)
        {
        }
    }
}
