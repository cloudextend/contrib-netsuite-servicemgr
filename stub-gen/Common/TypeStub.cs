using System;
using System.Collections.Generic;
using System.Text;

namespace StubGenerator.Common
{
    public class TypeStub
    {
        public string Namespace { get; set; }

        public string Name { get; set; }

        public string FullName => TypeStub.GetTypeName(this);

        public bool IsInterface { get; set; }

        public bool IsGeneric { get; set; }
        public IList<TypeStub> GenericParameters { get; set; }

        public IList<MethodStub> Methods { get; } = new List<MethodStub>();
        public IList<PropertyStub> Properties { get; } = new List<PropertyStub>();

        public TypeStub()
        {
        }

        public TypeStub(Type type)
        {
            IsInterface = type.IsInterface;

            this.Namespace = type.Namespace;

            IsGeneric = type.IsGenericType;
            if (IsGeneric)
            {
                var genericParams = type.GetGenericArguments();
                this.GenericParameters = new List<TypeStub>(genericParams.Length);
                foreach (var param in genericParams)
                {
                    this.GenericParameters.Add(new TypeStub(param));
                }
                this.Name = type.Name.Substring(0, type.Name.IndexOf('`'));
            }
            else
            {
                this.Name = type.Name;
            }
        }

        public override string ToString()
        {
            return this.FullName;
        }

        public string ToString(string relativeTo)
        {
            return GetTypeName(this, relativeTo);
        }

        private static string GetTypeName(TypeStub type, string relativeTo = null)
        {
            if (type.IsGeneric)
            {
                return GetGenericTypeSignature(type, relativeTo);
            }
            else
            {
                return GetSimpleType(type, relativeTo);
            }
        }

        private static string GetSimpleType(TypeStub type, string relativeTo = null, bool isGeneric = false)
        {
            string relativeNamespace;
            if (relativeTo != null)
            {
                return string.Concat(type.Namespace, ".", type.Name);
            }
            else if (string.IsNullOrEmpty(relativeNamespace = Namespaces.GetRelativeNamespace(type.Namespace, relativeTo)))
            {
                return type.Name;
            }
            else
            {
                return string.Concat(relativeNamespace, ".", type.Name);
            }
        }

        private static string GetGenericTypeSignature(TypeStub genericType, string relativeTo = null)
        {
            var signatureBuilder = new StringBuilder(25);
            signatureBuilder.Append(GetSimpleType(genericType, relativeTo, true));
            signatureBuilder.Append("<");

            var genArgs = genericType.GenericParameters;
            var paramCount = genArgs.Count;
            signatureBuilder.Append(GetTypeName(genArgs[0]));
            for (int i = 1; i < paramCount; i++)
            {
                signatureBuilder.Append(", ");
                signatureBuilder.Append(GetTypeName(genArgs[i]));
            }

            signatureBuilder.Append(">");
            return signatureBuilder.ToString();
        }
    }
}
