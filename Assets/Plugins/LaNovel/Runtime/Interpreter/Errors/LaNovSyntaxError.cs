using System;

namespace Plugins.LaNovel.Runtime.Interpreter.Errors
{
    public class LaNovSyntaxError : Exception
    {
        public LaNovSyntaxError(int line) : base(
            $"Error on command line {line} Syntax Error"
        ) {}
    }
}