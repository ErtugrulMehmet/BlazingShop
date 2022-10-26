using BlazingShop.Server.Data;
using BlazingShop.Server.Services.CategoryService;
using BlazingShop.Shared;
using Microsoft.EntityFrameworkCore;

namespace BlazingShop.Server.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly DataContext _context;
        private readonly ICategoryService _categoryService;

        public ProductService(DataContext context,ICategoryService categoryService)
        {
            _context = context;
            _categoryService = categoryService;
        }
       
        public async Task<List<Product>> GetAllProducts()
        {
            return await _context.Products.Include(p => p.Variants).ToListAsync();
        }

        public async Task<List<Product>> GetProductByCategory(string categoryUrl)
        {
            Category ccategory = await _categoryService.GetCategoryByUrl(categoryUrl);
            return await _context.Products.Include(p => p.Variants).Where(p=>p.CategoryId==ccategory.Id).ToListAsync(); 
        }

        public async Task<Product> GetProductById(int productId)
        {
            Product product = await _context.Products
                .Include(p=>p.Variants)
                .ThenInclude(v=>v.Edition)
                .FirstOrDefaultAsync(p => p.Id == productId);

            product.Views++;

            await _context.SaveChangesAsync();
            return product;
        }
        


    }
}
