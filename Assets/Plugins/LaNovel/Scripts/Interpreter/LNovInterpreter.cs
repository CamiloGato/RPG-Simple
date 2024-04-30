using System.Collections.Generic;
using System.IO;
using Plugins.LaNovel.Scripts.Interpreter.Errors;
using Plugins.LaNovel.Scripts.Interpreter.Instructions;

namespace Plugins.LaNovel.Scripts.Interpreter
{
    public class LNovInterpreter
    {
        private const string CommandInitial = "@ ";
        private const string CommandList = "- ";

        private Dictionary<string, ICommand> _commands;
        private Dictionary<string, object> _variables;

        private List<string> _temporalData;
        
        public LNovInterpreter(Dictionary<string, ICommand> commands)
        {
            _commands = commands;
            _variables = new Dictionary<string, object>();
        }

        public void ExecuteCommand(int line, string command)
        {
            char code = command[0];
            string instruction = command.Substring(2);
            
        }

        public void ExecuteFile(string filePath)
        {
            using StreamReader reader = new StreamReader(filePath);
            
            int currentLine = 0;
            while (reader.ReadLine() is { } line)
            {
                ExecuteCommand(currentLine, line);
                currentLine++;
            }
            
        }
        
    }
}