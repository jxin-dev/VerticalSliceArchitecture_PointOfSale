using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Web.Api.Database;
using Web.Api.Entities.Categories;

namespace Web.Api.Features.Categories
{

    public class CategoryRepository(ApplicationDbContext dbContext) : ICategoryRepository
    {
        public async Task AddCategoryAsync(Category category)
        {
            await dbContext.Categories.AddAsync(category);
            await dbContext.SaveChangesAsync();
        }

        public async Task<List<Category>?> GetCategoriesAsync(Expression<Func<Category, bool>>? predicate = null)
        {
            if (predicate is null)
            {
                return await dbContext.Categories.ToListAsync();
            }
            return await dbContext.Categories.Where(predicate).ToListAsync();

        }

        public async Task<Category?> GetCategoryAsync(Expression<Func<Category, bool>> predicate)
        {
          return await dbContext.Categories.SingleOrDefaultAsync(predicate);
        }
    }
}
