using BlazingShop.Server.Services.ProductService;
using BlazingShop.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazingShop.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetAllProducts()
        {
            return Ok(await _productService.GetAllProducts());
        }
        [HttpGet("Category/{categoryUrl}")]
        public async Task<ActionResult<List<Product>>> GetProductByCategory(string categoryUrl)
        {
            return Ok(await _productService.GetProductByCategory(categoryUrl));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Product>>> GetProduct(int id)
        {
            return Ok(await _productService.GetProductById(id));
        }
    }
}
