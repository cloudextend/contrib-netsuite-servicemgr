using System;
using System.Collections.Generic;
using System.Text;

namespace StubGenerator.Common
{
    public class TypeStub
    {
        public NamespaceStub Namespace { get; set; }

        public string Name { get; set; }
        public string FullName => string.Concat(this.Namespace.Name, ".", this.Name);

        public bool IsInterface { get; set; }

        public bool IsGeneric { get; set; }
        public IList<TypeStub> GenericParameters { get; set; }

        public IList<MethodStub> Methods { get; }

        public TypeStub()
        {
        }

        public TypeStub(Type type)
        {
            IsInterface = type.IsInterface;

            IsGeneric = type.IsGenericType;
            if (IsGeneric)
            {
                var genericParams = type.GetGenericArguments();
                this.GenericParameters = new List<TypeStub>(genericParams.Length);
                foreach (var param in genericParams)
                {
                    this.GenericParameters.Add(new TypeStub(param));
                }
            }

            Namespace = new NamespaceStub(type.Namespace);
            Methods = new List<MethodStub>();

            Name = TypeStub.GetTypeName(this, this.Namespace);
        }

        public override string ToString()
        {
            return this.FullName;
        }

        public string ToString(NamespaceStub relativeTo)
        {
            return TypeStub.GetTypeName(this, relativeTo);
        }

        public static string GetTypeName(TypeStub type, NamespaceStub relativeTo = null)
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

        private static string GetSimpleType(TypeStub type, NamespaceStub relativeTo = null, bool isGeneric = false)
        {
            var name = relativeTo == null ? type.FullName : relativeTo.GetRelativeTypeName(type);
            return isGeneric ? name.Substring(0, type.Name.IndexOf('`')) : name;
        }

        private static string GetGenericTypeSignature(TypeStub genericType, NamespaceStub relativeTo = null)
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
