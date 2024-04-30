using System;

namespace Plugins.LaNovel.Runtime.Interpreter.Errors
{
    public class LNovSyntaxError : Exception
    {
        public LNovSyntaxError(int line) : base(
            $"Error on command line {line} Syntax Error"
        ) {}
    }
}