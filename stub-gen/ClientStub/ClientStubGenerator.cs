using StubGenerator.Common;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;

namespace StubGenerator.ClientStub
{
    struct RequestWrap
    {
        public List<FieldInfo> configFields;
        public List<FieldInfo> dataFields;
        public Type requestType;

        public RequestWrap(Type requestType, int capacity)
        {
            this.requestType = requestType;
            configFields = new List<FieldInfo>(capacity);
            dataFields = new List<FieldInfo>(capacity);
        }
    }

    class ClientStubGenerator: Generator
    {
        private readonly HashSet<string> configurableProperties;

        public ClientStubGenerator(Assembly sourceAssembly, string outputPath): base(sourceAssembly, outputPath)
        {
            this.configurableProperties = new HashSet<string>(new[] {
                "applicationInfo",
                "partnerInfo",
                "passport",
                "preferences",
                "tokenPassport"
            });
        }

        protected override Context CreateContext()
        {
            var stub = this.CreateStub();
            return new Context<ClientTypeStub>(stub) { Configuration = this.Context.Configuration };
        }

        private ClientTypeStub CreateStub()
        {
            var assembly = this.Context.Configuration.SourceAssembly;

            var sourceNamespace = this.Context.Configuration.SourceNamespace;

            const string className = "NetSuitePortTypeClient";
            const string interfaceName = "NetSuitePortType";

            var nsClientType = assembly.GetType(string.Concat(sourceNamespace, ".", className));
            var nsClientInterface = assembly.GetType(string.Concat(sourceNamespace, ".", interfaceName));

            if (nsClientType == null) throw new InvalidOperationException("Source Assembly doesn't contain a definition for " + className);
            if (nsClientInterface == null) throw new InvalidOperationException("Source Assembly doens't contain a definition for " + interfaceName);

            var interfaceStub = new TypeStub(nsClientInterface) { Name = "INetSuiteClient" };
            var clientStub = new ClientTypeStub(nsClientType) { Interface = interfaceStub };

            foreach (var mthd in Reflector.GetPublicMethods(nsClientInterface))
            {
                AddMethod(mthd, interfaceStub, clientStub);
            }
            return clientStub;
        }

        private void AddMethod(MethodInfo methodInfo, TypeStub interfaceStub, TypeStub classStub)
        {
            var parameters = methodInfo.GetParameters();
            if (parameters.Length > 1)
            {
                interfaceStub.Methods.Add(new MethodStub(methodInfo));
                return;
            }

            var requestParam = parameters[0];

            var requestNamePattern = new Regex(@"^[a-z]\w+Request$", RegexOptions.Compiled | RegexOptions.Singleline);
            var responseNamePattern = new Regex(@"^[a-z]\w+Response$", RegexOptions.Compiled | RegexOptions.Singleline);

            var stub = new WrapperMethodStub(methodInfo.Name);
            bool useStub = false;

            if (requestNamePattern.IsMatch(requestParam.ParameterType.Name))
            {
                stub.WrappedParameterType = new TypeStub(requestParam.ParameterType);

                var allFields = Reflector.GetPublicFields(requestParam.ParameterType);
                foreach (var field in allFields)
                {
                    stub.WrappedParameterProperties.Add(field.Name);
                    // If the field can be set through configuration, don't include it as a parameter.
                    if (!this.configurableProperties.Contains(field.Name))
                    {
                        stub.Parameters.Add(new ParameterStub() {
                            Name = field.Name,
                            ParameterType = new TypeStub(field.FieldType)
                        });
                    }
                }
                useStub |= true;
            }

            // TODO: What does DocumentId return?
            //if (responseNamePattern.IsMatch(methodInfo.ReturnType.Name))
            //{
            //    // Unwrap the response object and return the actual response
            //}
            stub.ReturnType = new TypeStub(methodInfo.ReturnType);

            interfaceStub.Methods.Add(stub);
            if (useStub) classStub.Methods.Add(stub);
        }

        private RequestWrap UnwrapRequestType(Type requestType)
        {
            var allFields = Reflector.GetPublicFields(requestType);

            var unwrap = new RequestWrap(requestType, allFields.Length);

            for (int i = allFields.Length - 1; i >= 0; i--)
            {
                if (this.configurableProperties.Contains(allFields[i].Name))
                {
                    unwrap.configFields.Add(allFields[i]);
                }
                else
                {
                    unwrap.dataFields.Add(allFields[i]);
                }
            }
            return unwrap;
        }
    }
}
