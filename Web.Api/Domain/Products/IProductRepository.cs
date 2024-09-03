using System.Linq.Expressions;

namespace Web.Api.Entities.Products
{
    public interface IProductRepository
    {
        Task AddProductAsync(Product product);
        Task<Product?> GetProductAsync(Expression<Func<Product, bool>> predicate);
        Task<IEnumerable<Product>?> GetProductsAsync(Expression<Func<Product, bool>>? predicate = null);

    }
}
