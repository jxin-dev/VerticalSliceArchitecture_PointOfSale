using MediatR;
using Web.Api.Common;
using Web.Api.Entities.Categories;

namespace Web.Api.Features.Categories.CreateCategory
{
    public class CreateCategoryHandler(
        ICategoryRepository categoryRepository) : IRequestHandler<CreateCategoryCommand, Result<CreateCategoryResponse>>
    {
        public async Task<Result<CreateCategoryResponse>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = new Category()
            {
                Id = Guid.NewGuid(),
                CategoryName = request.CategoryName,
                Description = request.Description
            };

            await categoryRepository.AddCategoryAsync(category);

            return Result.Success(new CreateCategoryResponse(category.Id));
        }
    }
}
