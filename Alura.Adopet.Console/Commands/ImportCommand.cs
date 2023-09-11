using Alura.Adopet.Console.HttpClient;
using Alura.Adopet.Console.Utils;

namespace Alura.Adopet.Console.Commands
{
    [CommandDoc("import", "adopet import <arquivo> comando que realiza a importação do arquivo de pets.")]
    public class ImportCommand : ICommand
    {
        private HttpClientPet _client;

        public ImportCommand()
        {
            _client = new HttpClientPet();
        }

        public async Task ExecuteAsync(string[] args)
        {
            await ImportFileAsync(pathFileToBeImported: args[1]);
        }

        private async Task ImportFileAsync(string pathFileToBeImported)
        {
            var listaDePet = FileReader.ReadFromFile(pathFileToBeImported);

            foreach (var pet in listaDePet)
            {
                try
                {
                    System.Console.WriteLine(pet);
                    var resposta = await _client.CreatePetAsync(pet);
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
            }

            System.Console.WriteLine("Importação concluída!");
        }
    }
}
