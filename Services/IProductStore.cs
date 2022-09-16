using TERG_Rekrutacja_API.Models;

namespace TERG_Rekrutacja_API.Services
{
    public interface IProductStore
    {
        public List<Product> GetProducts(int limit, int offset, string name, float priceFrom, float priceTo);
        public Product GetById(Guid guid);
        public void AddProduct(Product product);
    }
}
