using StubGenerator.Common;
using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace StubGenerator
{
    class Program
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args">
        /// Command Line Paramters:
        ///     -s Source Project to be duplicated
        ///     -t Trarget ServiceManager project path
        ///     -w Target WSDL version
        ///     -a Source Assembly path (optional)
        /// </param>
        static void Main(string[] args)
        {
            string sourceProjectPath = null;
            string targetProjectPath = null;
            string sourceAssemblyPath = null;
            string targetWSDL = null;

            for (int i = 0; i < args.Length; i++)
            {
                if (args[i].StartsWith("-s"))
                {
                    sourceProjectPath = ExtractParam(args[i]);
                }
                else if (args[i].StartsWith("-t"))
                {
                    targetProjectPath = ExtractParam(args[i]);
                }
                else if (args[i].StartsWith("-w"))
                {
                    targetWSDL = ExtractParam(args[i]);
                }
                else if (args[i].StartsWith("-a"))
                {
                    sourceAssemblyPath = ExtractParam(args[i]);
                }
            }

            if (string.IsNullOrWhiteSpace(sourceProjectPath))
            {
                throw new ArgumentException("Source Project Path was not specified with '-s' flag");
            }
            else if (string.IsNullOrEmpty(targetProjectPath))
            {
                throw new ArgumentException("Target Project Path was not specified with '-t' flag");
            }
            else if (string.IsNullOrWhiteSpace(targetWSDL))
            {
                throw new ArgumentException("Target WSDL Path was not specified with '-w' flag");
            }

            if (string.IsNullOrWhiteSpace(sourceAssemblyPath)) sourceAssemblyPath = string.Concat(sourceProjectPath, @"bin\Debug\netcoreapp2.0\", targetWSDL, ".dll");

            var engine = new TemplatingEngine(Assembly.LoadFile(sourceAssemblyPath));
            var generator = new Generator(Path.Combine(sourceProjectPath, "SuiteTalk"));

            Task.WaitAll(
                generator.Generate(engine, "INetSuiteRequest")
            );
            
            // TODO Steps: 
            // 1. Copy Source Project folder to a folder named SuiteTalk-<WSDL Version>
            // 2. Remove Reference.cs from Connected Services\SuiteTalk
            // 3. Run dotnet-svcutil for the new WSDL
        }

        //private static string GetClientContent(ClientFile clientFile)
        //{
        //    var templateText = File.ReadAllText("INetSuiteClient.cshtml");
        //    var srcDoc = RazorSourceDocument.Create(templateText, "INetSuiteClient.cs");
        //    var engine = RazorEngine.Create();
        //    engine.Process(RazorCodeDocument.Create(srcDoc));
        //}

        private static string ExtractParam(string param)
        {
            return Unquote(param.Substring(2));
        }

        private static string Unquote(string text)
        {
            if (text.Length > 2 && text[0] == '"')
            {
                return text.Substring(1, text.Length - 2);
            }
            else
            {
                return text;
            }
        }
    }
}
