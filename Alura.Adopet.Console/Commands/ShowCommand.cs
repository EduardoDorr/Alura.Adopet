using Alura.Adopet.Console.Utils;

namespace Alura.Adopet.Console.Commands
{
    [CommandDoc("show", "adopet show <ARQUIVO> comando que exibe no terminal o conteúdo do arquivo importado.")]
    public class ShowCommand : ICommand
    {
        public Task ExecuteAsync(string[] args)
        {
            ShowFile(pathFileToBeShow: args[1]);

            return Task.CompletedTask;
        }

        private void ShowFile(string pathFileToBeShow)
        {
            var petList = FileReader.ReadFromFile(pathFileToBeShow);

            foreach (var pet in petList)
            {
                System.Console.WriteLine(pet);
            }
        }
    }
}
