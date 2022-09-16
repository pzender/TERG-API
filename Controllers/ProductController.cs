using Microsoft.AspNetCore.Mvc;
using TERG_Rekrutacja_API.Models;
using TERG_Rekrutacja_API.Services;

namespace TERG_Rekrutacja_API.Controllers
{
    [ApiController]
    [Route("products")]
    public class ProductController : ControllerBase
    {

        private readonly ILogger<ProductController> _logger;
        private readonly IProductStore _productStore;

        public ProductController(ILogger<ProductController> logger, IProductStore productStore)
        {
            _logger = logger;
            _productStore = productStore;
        }

        [HttpGet]
        public IEnumerable<Product> Get(
                [FromQuery] int limit = 10,
                [FromQuery] int offset = 0,
                [FromQuery] string? search = "",
                [FromQuery] float priceFrom = 0.0f,
                [FromQuery] float priceTo = 500.0f 
            )
        {
            return _productStore.GetProducts(limit, offset, (search ?? ""), priceFrom, priceTo);
        }

        [Route("{guid}")]
        [HttpGet]
        public Product GetById([FromRoute] Guid guid)
        {
            return _productStore.GetById(guid);
        }

        [HttpPost]
        public void AddProduct([FromBody] Product product)
        {
            product.Id = Guid.NewGuid();
            _productStore.AddProduct(product); 
        }
    }
}