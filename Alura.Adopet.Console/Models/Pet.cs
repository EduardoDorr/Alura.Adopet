using Alura.Adopet.Console.Enums;
using static System.Net.Mime.MediaTypeNames;

namespace Alura.Adopet.Console.Models
{
    public class Pet
    {
        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public TipoPet Tipo { get; set; }

        public Pet(Guid id, string? nome, TipoPet tipo)
        {
            Id = id;
            Nome = nome;
            Tipo = tipo;
        }

        public static Pet CreateFromCsv(string? csvRow)
        {
            var properties = csvRow?.Split(';') ?? throw new ArgumentNullException($"{nameof(csvRow)} is null");

            if (string.IsNullOrWhiteSpace(csvRow))
                throw new ArgumentException($"{nameof(csvRow)} is empty");

            if (properties.Length != 3)
                throw new ArgumentException($"{nameof(csvRow)} has missing parameters");

            if (!Guid.TryParse(properties[0], out Guid petId))
                throw new ArgumentException($"Guid is invalid");

            if (!Enum.IsDefined(typeof(TipoPet), Convert.ToInt32(properties[2])))
                throw new ArgumentException($"{nameof(TipoPet)} is invalid");

            Enum.TryParse(properties[2], out TipoPet petType);

            return new Pet(
                petId,
                properties[1],
                petType
             );
        }

        public override string ToString()
        {
            return $"{Id} - {Nome} - {Tipo}";
        }
    }
}
