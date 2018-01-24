using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace StubGenerator
{
    class ClientGenerator
    {
        private string assemblyPath;

        public ClientGenerator(string assemblyPath)
        {
            this.assemblyPath = assemblyPath;
        }

        public ClientFile GenerateClient()
        {
            var clientFile = new ClientFile();

            var sourceAssembly = ClientGenerator.LoadSourceAssembly(this.assemblyPath);
            WriteMethodSignatures(clientFile, GetPublicMethods(sourceAssembly));

            return clientFile;
        }

        private void WriteMethodSignatures(ClientFile client, IEnumerable<MethodInfo> methods)
        {
            var signatureBuilder = new StringBuilder(150);
            foreach (var mthd in methods)
            {
                AppendType(mthd.ReturnType, signatureBuilder, client);
                signatureBuilder.Append(" ");

                signatureBuilder.Append(mthd.Name);

                signatureBuilder.Append("(");
                AppendParameters(mthd.GetParameters(), signatureBuilder, client);
                signatureBuilder.Append(")");

                client.PublicMethods.Add(signatureBuilder.ToString());
                signatureBuilder.Clear();
            }
        }

        private void AppendParameters(ParameterInfo[] parameters, StringBuilder signatureBuilder, ClientFile client)
        {
            for (int i = 0; i < parameters.Length; i++)
            {
                if (i != 0) signatureBuilder.Append(", ");
                AppendType(parameters[i].ParameterType, signatureBuilder, client);
                signatureBuilder.Append(" ");
                signatureBuilder.Append(parameters[i].Name);
            }
        }

        private void AppendType(Type type, StringBuilder signatureBuilder, ClientFile client)
        {
            if (type.IsGenericType)
            {
                AppendGenericTypeSignature(type, signatureBuilder, client);
            }
            else
            {
                AppendAsSimpleType(type, signatureBuilder, client);
            }
        }

        private void AppendAsSimpleType(Type type, StringBuilder signatureBuilder, ClientFile client, bool isGeneric = false)
        {
            var typeName = isGeneric ? type.Name.Substring(0, type.Name.IndexOf('`')) :  type.Name;

            if (type.Namespace == client.Namespace)
            {
                signatureBuilder.Append(typeName);
            }
            else
            {
                signatureBuilder.Append($"{type.Namespace}.{typeName}");
            }
        }

        private void AppendGenericTypeSignature(Type genericType, StringBuilder signatureBuilder, ClientFile client)
        {
            AppendAsSimpleType(genericType, signatureBuilder, client, true);
            signatureBuilder.Append("<");

            var genArgs = genericType.GetGenericArguments();
            for (int i = 0; i < genArgs.Length; i++)
            {
                if (i != 0) signatureBuilder.Append(", ");
                AppendType(genArgs[i], signatureBuilder, client);
            }

            signatureBuilder.Append(">");
        }

        private IEnumerable<MethodInfo> GetPublicMethods(Assembly sourceAssembly)
        {
            var clientType = sourceAssembly.GetType("SuiteTalk.NetSuitePortTypeClient");

            if (clientType == null)
            {
                throw new InvalidOperationException($"Assembly at {this.assemblyPath} does not contain a SuiteTalk.NetSuitePortTypeClient type.");
            }
            else if (!clientType.IsClass)
            {
                throw new InvalidOperationException($"Provided assembly contains a SuiteTalk.NetSuitePortTypeClient. But, it is not a Class.");
            }

            return clientType.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly)
                .Where(m => !m.IsSpecialName && !m.IsVirtual);
        }

        private static Assembly LoadSourceAssembly(string assemblyPath)
        {
            try
            {
                return Assembly.LoadFrom(assemblyPath);
            }
            catch (Exception)
            {
                Console.Error.WriteLine("An exception occurred while loading the assembly from " + assemblyPath);
                throw;
            } 
        }
    }
}
