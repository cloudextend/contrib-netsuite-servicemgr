using System;
using System.Collections.Generic;
using System.Text;

namespace StubGenerator.Common
{
    public class NamespaceStub
    {
        public string Name { get; set; }

        public NamespaceStub(string name)
        {
            this.Name = name;
        }

        public string GetRelativeNamespace(string otherNamespace)
        {
            var rootNamespace = this.Name + ".";
            if (string.IsNullOrWhiteSpace(otherNamespace))
            {
                return otherNamespace;
            }
            else if (otherNamespace.Contains(rootNamespace))
            {
                return otherNamespace.Substring(rootNamespace.Length);
            }
            else if (rootNamespace.Contains(otherNamespace))
            {
                return rootNamespace;
            }
            else
            {
                return otherNamespace;
            }
        }

        public string GetRelativeTypeName(Type type)
        {
            var relativeNamespace = GetRelativeNamespace(type.Namespace);
            return string.Concat(relativeNamespace, ".", type.Name);
        }

        public string GetRelativeTypeName(TypeStub type)
        {
            var relativeNamespace = GetRelativeNamespace(type.Namespace.Name);
            return string.Concat(relativeNamespace, ".", type.Name);
        }
    }
}
