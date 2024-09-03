using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Web.Api.Database;
using Web.Api.Entities.Products;

namespace Web.Api.Features.Products
{
    public class ProductRepository(ApplicationDbContext dbContext) : IProductRepository
    {
        public async Task AddProductAsync(Product product)
        {
            await dbContext.Products.AddAsync(product);
            await dbContext.SaveChangesAsync();
        }

        public async Task<Product?> GetProductAsync(Expression<Func<Product, bool>> predicate)
        {
            return await dbContext.Products
                .Include(product => product.Category)
                .Include(product => product.Supplier)
                .SingleOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<Product>?> GetProductsAsync(Expression<Func<Product, bool>>? predicate = null)
        {
            if (predicate is null)
            {
                return await dbContext.Products
                    .Include(product => product.Category)
                    .Include(product => product.Supplier)
                    .ToListAsync();
            }
            return await dbContext.Products
                .Include(product => product.Category)
                .Include(product => product.Supplier)
                .Where(predicate)
                .ToListAsync();
        }
    }
}
