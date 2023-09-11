using Alura.Adopet.Console.Models;
using Alura.Adopet.Console.Commands;

namespace Alura.Adopet.Testes
{
    public class CsvToPetTest
    {
        [Fact]
        public void ConvertFromCsvToPet()
        {
            //Arrange
            var validCsv = "456b24f4-19e2-4423-845d-4a80e8854a41;Lima Limão;1";

            //Act
            Pet pet = Pet.CreateFromCsv(validCsv);

            //Assert
            Assert.NotNull(pet);
        }

        [Fact]
        public void ConvertFromCsvToPetWhenNullString()
        {
            //Arrange
            string? validCsv = null;

            //Act+Assert
            Assert.ThrowsAny<ArgumentNullException>(() => Pet.CreateFromCsv(validCsv));
        }

        [Fact]
        public void ConvertFromCsvToPetWhenEmptyString()
        {
            //Arrange
            string? validCsv = string.Empty;

            //Act+Assert
            Assert.ThrowsAny<ArgumentException>(() => Pet.CreateFromCsv(validCsv));
        }

        [Fact]
        public void ConvertFromCsvToPetWhenInvalidGuid()
        {
            //Arrange
            var validCsv = "4a80e8854a41;Lima Limão;1";

            //Act+Assert
            Assert.ThrowsAny<ArgumentException>(() => Pet.CreateFromCsv(validCsv));
        }

        [Fact]
        public void ConvertFromCsvToPetWhenInvalidPetType()
        {
            //Arrange
            var validCsv = "456b24f4-19e2-4423-845d-4a80e8854a41;Lima Limão;3";

            //Act+Assert
            Assert.ThrowsAny<ArgumentException>(() => Pet.CreateFromCsv(validCsv));
        }

        [Fact]
        public void ConvertFromCsvToPetWhenMissingParameters()
        {
            //Arrange
            var validCsv = "456b24f4-19e2-4423-845d-4a80e8854a41; Lima Limão";

            //Act+Assert
            Assert.ThrowsAny<ArgumentException>(() => Pet.CreateFromCsv(validCsv));
        }

        [Fact]
        public void ShowCommandTest()
        {
            //Arrange
            var command = new ShowCommand();
            string[] args = { "show", "lista.csv" };

            //Act+Assert
            Assert.ThrowsAnyAsync<Exception>(() =>
            {
                return command.ExecuteAsync(args);
            });
        }
    }
}
