using Alura.Adopet.Console.Models;

namespace Alura.Adopet.Console.Utils
{
    public class FileReader
    {
        public static List<Pet> ReadFromFile(string filePathToBeRead)
        {
            var petList = new List<Pet>();

            using (var sr = new StreamReader(filePathToBeRead))
            {
                System.Console.WriteLine("----- Dados importados -----");

                while (!sr.EndOfStream)
                {
                    var pet = Pet.CreateFromCsv(sr.ReadLine());

                    petList.Add(pet);
                }
            }

            return petList;
        }
    }
}
