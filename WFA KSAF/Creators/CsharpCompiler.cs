using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Microsoft.CodeDom.Providers.DotNetCompilerPlatform;

namespace WFA.KSAF.Creators
{
    public sealed class CsharpCompiler
    {
        private readonly CompilerParameters _compilerParameters;
        private readonly CodeDomProvider _compileProvider;

        public CsharpCompiler()
        {
            var options = new Dictionary<string, string> { { "CompilerVersion", "v4.5" } };
            _compileProvider = new CSharpCodeProvider();//options);
            _compilerParameters = new CompilerParameters
            {
                //CompilerOptions = "/t:library",
                GenerateInMemory = true,
                IncludeDebugInformation = true,
                GenerateExecutable = false,
                OutputAssembly = "Estimator.dll",
                CompilerOptions = "/optimize",
                TempFiles = new TempFileCollection(".", false)
            };
            _compilerParameters.ReferencedAssemblies.AddRange(References.ToArray());
        }

        public CompilerResults Compile(string code) =>
            _compileProvider.CompileAssemblyFromSource(_compilerParameters, code);

        private List<string> References
        {
            get
            {
                string exePath = Assembly.GetExecutingAssembly().Location;
                string exeDir = Path.GetDirectoryName(exePath);

                AssemblyName[] assemRefs = Assembly.GetExecutingAssembly().GetReferencedAssemblies();
                List<string> references = new List<string>();

                foreach (AssemblyName assemblyName in assemRefs)
                    references.Add(assemblyName.Name + ".dll");

                for (int i = 0; i < references.Count; i++)
                {
                    string localName = Path.Combine(exeDir, references[i]);

                    if (File.Exists(localName))
                        references[i] = localName;
                }

                references.Add(exePath);
                return references;
            }
        }

    }
}
