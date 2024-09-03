using Web.Api.Common;

namespace Web.Api.Entities.Categories
{
    public class CategoryErrors
    {
        public static Error NotFound()
        {
            return new Error("Category.NotFound", "The requested resource could not be found.");
        }
        public static Error NotFound(Guid categoryId)
        {
            return new Error("Category.NotFound", $"The category with Id = {categoryId} was not found.");
        }


    }
}
