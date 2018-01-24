using System;
using System.Collections.Generic;
using System.Text;

namespace StubGenerator.ClientStub
{
    public class ClientInterfaceStub
    {
        public IList<string> MemberSignatures { get; } = new List<string>(50);
    }
}
