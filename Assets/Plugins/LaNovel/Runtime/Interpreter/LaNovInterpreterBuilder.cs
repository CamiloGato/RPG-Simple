using System.Collections.Generic;
using Plugins.LaNovel.Runtime.Interpreter.Instructions;

namespace Plugins.LaNovel.Runtime.Interpreter
{
    public class LaNovInterpreterBuilder
    {
        private readonly Dictionary<string, ICommand> _commands = new();

        public LaNovInterpreterBuilder AddCommand(string code, ICommand command)
        {
            _commands.TryAdd(code, command);
            return this;
        }
        
        public LaNovInterpreter Build()
        {
            return new LaNovInterpreter( _commands );
        }
    }
}