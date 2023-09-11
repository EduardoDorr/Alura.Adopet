using Alura.Adopet.Console.HttpClient;

namespace Alura.Adopet.Console.Commands
{
    [CommandDoc("list", "adopet list comando que exibe no terminal o conteúdo cadastrado na base de dados da AdoPet")]
    public class ListCommand : ICommand
    {
        private HttpClientPet _client;

        public ListCommand()
        {
            _client = new HttpClientPet();
        }

        public async Task ExecuteAsync(string[] args)
        {
            await PrintListAsync();
        }

        private async Task PrintListAsync()
        {
            var pets = await _client.ListPetsAsync();

            foreach (var pet in pets)
            {
                System.Console.WriteLine(pet);
            }
        }
    }
}
