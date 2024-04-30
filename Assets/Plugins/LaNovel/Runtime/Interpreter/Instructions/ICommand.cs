namespace Plugins.LaNovel.Runtime.Interpreter.Instructions
{
    public interface ICommand
    {
        object Execute( string[] args );
    }
}