namespace Plugins.LaNovel.Scripts.Interpreter.Instructions
{
    public interface ICommand
    {
        object Execute( string[] args );
    }
}