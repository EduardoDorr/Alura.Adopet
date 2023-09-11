namespace Alura.Adopet.Console.Commands
{
    public interface ICommand
    {
        public Task ExecuteAsync(string[] args);
    }
}
