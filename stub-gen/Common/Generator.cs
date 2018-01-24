using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace StubGenerator.Common
{
    public class Context
    {
        public Configuration Configuration { get; set; }
    }

    public class Context<T>: Context
    {
        T Data { get; }

        public Context(T data)
        {
            this.Data = data;
        }
    }

    class Generator
    {
        private readonly string outputPath;

        public Generator(string outputPath)
        {
            this.outputPath = outputPath;
        }

        public async Task Generate(TemplatingEngine engine, string templateName)
        {
            var content = await engine.Transform("INetSuiteRequest");
            File.WriteAllText(Path.Combine(outputPath, templateName + ".cs"), content);
        }
    }
}
