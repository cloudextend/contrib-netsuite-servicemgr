using RazorLight;
using StubGenerator.Common;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace StubGenerator
{
    class TemplatingEngine
    {
        private readonly string templatePath;
        private readonly Context context;

        private readonly IRazorLightEngine engine;

        public TemplatingEngine(Assembly source)
        {
            this.context = new Context() {
                Configuration = new Configuration() {
                    SourceAssembly = source,
                    SourceNamespace = "SuiteTalk",
                    TargetNamespace = "SuiteTalk",
                }
            };
            this.templatePath = new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName;
            this.engine = new RazorLightEngineBuilder()
                                .UseFilesystemProject(this.templatePath)
                                .Build();
        }

        public async Task<string> Transform<T>(string templateName, T model)
        {
            return await TransformAndWrite(templateName, new Context<T>(model));
        }

        public async Task<string> Transform(string templateName)
        {
            return await TransformAndWrite(templateName, new Context());
        }

        private async Task<string> TransformAndWrite(string templateName, Context context)
        {
            context.Configuration = this.context.Configuration;
            return await engine.CompileRenderAsync(templateName, context);
        }
    }
}
