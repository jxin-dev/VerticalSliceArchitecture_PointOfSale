using System.Linq.Expressions;

namespace Web.Api.Entities.Categories
{
    public interface ICategoryRepository
    {
        Task<Category?> GetCategoryAsync(Expression<Func<Category, bool>> predicate);
        Task<List<Category>?> GetCategoriesAsync(Expression<Func<Category, bool>>? predicate = null);
        Task AddCategoryAsync(Category category);
    }
}
