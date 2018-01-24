using System;
using System.Collections.Generic;
using System.Text;

namespace StubGenerator.Common
{
    public static class Namespaces
    {
        public static string GetRelativeNamespace(string otherNamespace, string relativeTo)
        {
            if (otherNamespace == relativeTo || string.IsNullOrWhiteSpace(otherNamespace))
            {
                return "";
            }
            else if (string.IsNullOrWhiteSpace(relativeTo))
            {
                return otherNamespace;
            }

            var rootNamespace = relativeTo + ".";
            if (otherNamespace.Contains(rootNamespace))
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
    }
}
