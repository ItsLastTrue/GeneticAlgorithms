using System.Collections.Generic;

namespace CL.KSAF.Entities
{
    public struct Log
    {
        public List<string> Simplification;
        public List<string> Preparation;
        public List<CompileError> CompileErrors;
    }

    public struct CompileError
    {
        public int? Iteration;
        public string Code;
        public string ErrorText;
    }
}
