using System.Collections.Generic;
using System.IO;
using Plugins.LaNovel.Runtime.Interpreter.Instructions;

namespace Plugins.LaNovel.Runtime.Interpreter
{
    public class LNovInterpreter
    {
        private Dictionary<string, ICommand> _commands;
        private Dictionary<string, object> _variables;

        private List<string> _temporalData;
        private string _currentCommand;

        public LNovInterpreter(Dictionary<string, ICommand> commands)
        {
            _commands = commands;
            _variables = new Dictionary<string, object>();
        }

        public void ExecuteCommand(string command)
        {
            char code = command[0];
            string instruction = command.Substring(2);
            
        }

        public void ExecuteFile(string filePath)
        {
            using StreamReader reader = new StreamReader(filePath);

            while (reader.ReadLine() is { } line)
            {
                ExecuteCommand(line);
            }
            
        }
        
    }
}