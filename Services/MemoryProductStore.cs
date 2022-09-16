using TERG_Rekrutacja_API.Models;

namespace TERG_Rekrutacja_API.Services
{
    public class MemoryProductStore : IProductStore
    {
        private readonly List<Product> products = new() {
            new Product(Guid.NewGuid(), "Corsair K70 MK.2", "123456", 269.0f),
            new Product(Guid.NewGuid(), "Logitech MK235",   "234567", 39.0f)
        };

        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public List<Product> GetProducts(int limit, int offset, string name, float priceFrom, float priceTo)
        {
            IEnumerable<Product> filteredProducts = from product in products
                                            where (
                                                 product.Name.StartsWith(name) &&
                                                 product.Price > priceFrom &&
                                                 product.Price < priceTo
                                            )
                                            select product;
            return filteredProducts.Skip(offset).Take(limit).ToList();
        }

        public Product GetById(Guid guid)
        {
            return products.SingleOrDefault(product => product.Id == guid);
        }
    }
}
