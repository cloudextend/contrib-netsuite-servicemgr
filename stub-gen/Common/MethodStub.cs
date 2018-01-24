using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace StubGenerator.Common
{
    public class MethodStub
    {
        public string Name { get; }
        public TypeStub ReturnType { get; set; }
        public IList<ParameterStub> Parameters { get; } = new List<ParameterStub>();

        public IList<string> MethodBody { get; set; } = new List<string>();

        public MethodStub(string name)
        {
            this.Name = name;
        }

        public MethodStub(MethodInfo methodInfo)
        {
            var parameters = methodInfo.GetParameters();
            this.Parameters = new List<ParameterStub>(parameters.Length);
            foreach (var param in parameters)
            {
                Parameters.Add(new ParameterStub(param));
            }
        }

        public override string ToString()
        {
            return this.ToString(null);
        }

        public string ToString(string accessor)
        {
            return this.ToString(null, accessor);
        }

        public string ToString(string relativeTo, string accessor = "public")
        {
            var signatureBuilder = new StringBuilder(100);
            if (accessor != null) signatureBuilder.Append(accessor + " ");

            signatureBuilder.Append(this.ReturnType.ToString(relativeTo));
            signatureBuilder.Append(" ");
            signatureBuilder.Append(this.Name);
            signatureBuilder.Append("(");

            int paramCount = this.Parameters.Count;
            if (paramCount > 0)
            {
                signatureBuilder.Append(this.Parameters[0].ToString(relativeTo));
                for (int i = 1; i < paramCount; i++)
                {
                    signatureBuilder.Append(",");
                    signatureBuilder.Append(this.Parameters[i].ToString(relativeTo));
                }
            }
            
            signatureBuilder.Append(")");
            return signatureBuilder.ToString();
        }
    }
}
