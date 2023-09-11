using Alura.Adopet.Console.HttpClient;

namespace Alura.Adopet.Testes
{
    public class HttpClientPetTest
    {
        [Fact]
        public async Task ListPetsNotEmpty()
        {
            //Arrange
            var client = new HttpClientPet();

            //Act
            var petList = await client.ListPetsAsync();

            //Assert
            Assert.NotNull(petList);
            Assert.NotEmpty(petList);
        }

        [Fact]
        public async Task APIHealthyCheck()
        {
            //Arrange
            var client = new HttpClientPet(uri: "http://localhost:1111");

            //Act+Assert
            await Assert.ThrowsAnyAsync<Exception>(client.ListPetsAsync);
        }
    }
}