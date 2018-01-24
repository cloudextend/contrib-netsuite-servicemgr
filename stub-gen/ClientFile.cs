using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StubGenerator
{
    public class ClientFile
    {
        public HashSet<string> ImportedNamespaces { get; } = new HashSet<string>();
        public HashSet<string> PublicMethods { get; } = new HashSet<string>();

        public string Namespace { get; set; } = "SuiteTalk";
        public string Name { get; set; } = "INetSuiteClient";

        public ClientFile()
        {
        }

        public string GetContent()
        {
            var content = new StringBuilder(500);
            foreach (var ns in ImportedNamespaces.OrderBy(s => s))
            {
                content.Append("using ");
                content.Append(ns);
                content.Append(";\r\n");
            }
            content.AppendLine();

            content.Append("namespace ");
            content.Append(Namespace ?? "SuiteTalk");
            content.AppendLine("{"); // Opens the namespace

            content.AppendLine($"\tpublic partial interface {Name ?? "INetSuiteClient"}");
            content.AppendLine("\t{"); // Opens the interface

            content.AppendLine("#pragma warning disable IDE1006 // Naming Styles");
            foreach (var mthd in PublicMethods)
            {
                content.AppendLine();
                content.AppendLine($"\t\t{mthd};");
                content.AppendLine();
            }
            content.AppendLine("#pragma warning restore IDE1006 // Naming Styles");

            content.AppendLine("\t}"); // Closes the interface

            content.AppendLine("}"); // Closes the namespace

            return content.ToString();
        }
    }
}
