using RazorLight;
using StubGenerator.Common;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace StubGenerator.Common
{
    class TemplatingEngine
    {
        private readonly string templatePath;
        private readonly IRazorLightEngine engine;

        public TemplatingEngine()
        {
            this.templatePath = new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName;
            this.engine = new RazorLightEngineBuilder()
                                .UseFilesystemProject(this.templatePath)
                                .Build();
        }


        public async Task<string> Transform(string templateName, Context model)
        {
            return await engine.CompileRenderAsync(templateName, model);
        }
    }
}
