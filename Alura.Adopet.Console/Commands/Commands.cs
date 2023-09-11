namespace Alura.Adopet.Console.Commands
{
    public class Commands
    {
        private Dictionary<string, ICommand> _commands = new()
        {
            { "help", new HelpCommand() },
            { "import", new ImportCommand() },
            { "list", new ListCommand() },
            { "show", new ShowCommand() }
        };

        public ICommand? this[string key] => _commands.ContainsKey(key) ? _commands[key] : null;
    }
}
