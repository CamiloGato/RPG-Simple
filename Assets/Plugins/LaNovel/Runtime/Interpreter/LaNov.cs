using Plugins.LaNovel.Runtime.Interpreter.Instructions;

namespace Plugins.LaNovel.Runtime.Interpreter
{
    public class LaNov
    {
        private static LaNov _instance;
        public static LaNov Instance => _instance ?? new LaNov();

        public readonly LaNovInterpreter Interpreter;
        
        private LaNov()
        {
            Interpreter = new LaNovInterpreterBuilder()
                .AddCommand("sample", new SampleCommand())
                .Build();
        }

    }
}