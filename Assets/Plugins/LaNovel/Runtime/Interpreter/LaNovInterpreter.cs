using System.Collections.Generic;
using System.IO;
using Plugins.LaNovel.Runtime.Interpreter.Errors;
using Plugins.LaNovel.Runtime.Interpreter.Instructions;

namespace Plugins.LaNovel.Runtime.Interpreter
{
    public class LaNovInterpreter
    {
        private readonly Dictionary<string, ICommand> _commands;
        private Dictionary<string, object> _variables;

        private List<string> _temporalData = new List<string>();
        private ICommand _currentCommand;

        public LaNovInterpreter(Dictionary<string, ICommand> commands)
        {
            _commands = commands;
            _variables = new Dictionary<string, object>();
        }

        public string ExecuteFile(string filePath)
        {
            string result = "";
            using StreamReader reader = new StreamReader(filePath);

            int lineAmount = 0;
            while (reader.ReadLine() is { } line)
            {
                char code = line[0];
                if (code == '-')
                {
                    if (_currentCommand == null)
                    {
                        throw new LaNovSyntaxError(lineAmount);
                    }
                    _temporalData?.Add(line[1..]);
                }
                else if (code == '@')
                {
                    if (_temporalData?.Count >= 1)
                    {
                        result += _currentCommand.Execute(_temporalData.ToArray());

                    }
                    
                    string[] command = line[1..].Split(' ');
                    string[] arguments = command[1..];
                    _currentCommand = _commands[command[0]];
                    
                    result += _currentCommand.Execute(arguments);
                    
                    _temporalData = new List<string>();
                }
                else
                {
                    throw new LaNovSyntaxError(lineAmount);
                }
                
                lineAmount++;
            }

            if (_temporalData?.Count >= 0)
                result += _currentCommand.Execute(_temporalData.ToArray());

            return result;
        }
        
    }
}