using System.Reflection;

namespace Alura.Adopet.Console.Commands
{
    [CommandDoc("help", "adopet help comando que exibe informações da ajuda. \nadopet help <NOME_COMANDO> para acessar a ajuda de um comando específico.")]
    public class HelpCommand : ICommand
    {
        private Dictionary<string, CommandDocAttribute> _docs;

        public HelpCommand()
        {
            _docs = Assembly.GetExecutingAssembly()
                            .GetTypes()
                            .Where(d => d.GetCustomAttributes<CommandDocAttribute>().Any())
                            .Select(d => d.GetCustomAttribute<CommandDocAttribute>()!)
                            .ToDictionary(d => d.Command);
        }

        public Task ExecuteAsync(string[] args)
        {
            ShowHelp(args);
            
            return Task.CompletedTask;
        }

        private void ShowHelp(string[] command)
        {
            if (command.Length == 1)
            {
                System.Console.WriteLine($"Adopet (1.0) - Aplicativo de linha de comando (CLI).");
                System.Console.WriteLine($"Realiza a importação em lote de um arquivos de pets.");
                System.Console.WriteLine($"Comando possíveis: ");

                foreach (var doc in _docs.Values)
                {
                    System.Console.WriteLine(doc.Documentation);
                }
            }
            else if (command.Length == 2)
            {
                var commandsToBeShow = command[1];
                if (_docs.ContainsKey(commandsToBeShow))
                    System.Console.WriteLine(_docs[commandsToBeShow].Documentation);
            }
        }
    }
}
