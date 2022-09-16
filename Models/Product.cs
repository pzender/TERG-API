using System.Text.Json.Serialization;

namespace TERG_Rekrutacja_API.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public float Price { get; set; }


        public Product(Guid id, string name, string code, float price)
        {
            Id = id;
            Name = name;
            Code = code;
            Price = price;
        }

        [JsonConstructor]
        public Product(string name, string code, float price) : this(Guid.NewGuid(), name, code, price) { }

    }
}
