using System.Net.Http.Json;
using System.Net.Http.Headers;
using Alura.Adopet.Console.Models;

namespace Alura.Adopet.Console.HttpClient
{
    public class HttpClientPet
    {
        private static System.Net.Http.HttpClient _client;

        public HttpClientPet(string uri = "http://localhost:5057")
        {
            _client = ConfiguraHttpClient(uri);
        }

        public async Task<HttpResponseMessage> CreatePetAsync(Pet pet)
        {
            HttpResponseMessage? response = null;
            using (response = new HttpResponseMessage())
            {
                return await _client.PostAsJsonAsync("pet/add", pet);
            }
        }

        public async Task<IEnumerable<Pet>?> ListPetsAsync()
        {
            HttpResponseMessage response = await _client.GetAsync("pet/list");
            return await response.Content.ReadFromJsonAsync<IEnumerable<Pet>>();
        }

        private System.Net.Http.HttpClient ConfiguraHttpClient(string url)
        {
            var client = new System.Net.Http.HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            client.BaseAddress = new Uri(url);

            return client;
        }
    }
}
