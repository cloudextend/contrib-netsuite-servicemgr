using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace StubGenerator.Common
{
    public class MethodStub
    {
        public string Name { get; set; }
        public TypeStub ReturnType { get; set; }
        public IList<ParameterStub> Parameters { get; }

        public TypeStub Owner { get; }

        protected MethodInfo ActualMethod { get; }

        public MethodStub(MethodInfo methodInfo, TypeStub owner)
        {
            this.Owner = owner;
            this.ActualMethod = methodInfo;

            var parameters = methodInfo.GetParameters();
            this.Parameters = new List<ParameterStub>(parameters.Length);
            foreach (var param in parameters)
            {
                Parameters.Add(new ParameterStub(this, param));
            }
        }

        public override int GetHashCode()
        {
            return this.ActualMethod.GetHashCode();
        }

        public override string ToString()
        {
            return this.ToString(null);
        }

        public string ToString(NamespaceStub relativeTo)
        {
            var signatureBuilder = new StringBuilder(100);
            if (!this.Owner.IsInterface) signatureBuilder.Append("public ");

            signatureBuilder.Append(this.ReturnType.ToString(relativeTo));
            signatureBuilder.Append(" ");
            signatureBuilder.Append(this.Name);
            signatureBuilder.Append("(");

            int paramCount = this.Parameters.Count;
            for (int i = 1; i < paramCount; i++)
            {
                signatureBuilder.Append(",");
                signatureBuilder.Append(this.Parameters[i].ToString(relativeTo));
            }

            signatureBuilder.Append(")");
            return signatureBuilder.ToString();
        }
    }
}
