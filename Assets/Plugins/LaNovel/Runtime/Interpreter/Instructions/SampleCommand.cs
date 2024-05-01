namespace Plugins.LaNovel.Runtime.Interpreter.Instructions
{
    public class SampleCommand : ICommand
    {
        public object Execute(string[] args)
        {
            return args;
        }
    }
}