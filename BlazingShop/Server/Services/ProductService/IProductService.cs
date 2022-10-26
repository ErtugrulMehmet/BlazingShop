using BlazingShop.Shared;

namespace BlazingShop.Server.Services.ProductService
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProducts();
        Task<List<Product>> GetProductByCategory(string categoryUrl);
        Task<Product> GetProductById(int productId);
    }
}
