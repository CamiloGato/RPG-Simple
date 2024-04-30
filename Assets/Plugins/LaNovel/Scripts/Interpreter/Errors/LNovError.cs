using System;

namespace Plugins.LaNovel.Scripts.Interpreter.Errors
{
    public class LNovSyntaxError : Exception
    {
        public LNovSyntaxError(int line) : base(
            $"Error on command line {line} Syntax Error"
        ) {}
    }
}