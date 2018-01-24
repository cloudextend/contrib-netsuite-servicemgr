using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
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
        public T Data { get; }

        public Context(T data)
        {
            this.Data = data;
        }
    }

    class Generator
    {
        private readonly string outputPath;
        protected Context Context { get; }

        public Generator(Assembly source,  string outputPath)
        {
            this.outputPath = outputPath;
            this.Context = new Context() {
                Configuration = new Configuration() {
                    SourceAssembly = source,
                    SourceNamespace = "SuiteTalk",
                    TargetNamespace = "SuiteTalk",
                }
            };
        }

        protected virtual Context CreateContext()
        {
            return this.Context;
        }

        public async Task Generate(TemplatingEngine engine, string templateName)
        {
            try
            {
                string content;
                Context context = this.CreateContext();
                content = await engine.Transform(templateName, context);
            
                File.WriteAllText(Path.Combine(outputPath, templateName + ".gen.cs"), content);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
                throw;
            }

        }
    }
}
