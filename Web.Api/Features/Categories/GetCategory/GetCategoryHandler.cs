using MediatR;
using Web.Api.Common;
using Web.Api.Entities.Categories;
using Web.Api.Features.Categories.GetAllCategories;

namespace Web.Api.Features.Categories.GetCategory
{
    public class GetAllCategoriesQueryHandler(
        ICategoryRepository categoryRepository)
        : IRequestHandler<GetCategoryQuery, Result<GetCategoryResponse>>
    {
        public async Task<Result<GetCategoryResponse>> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            var category = await categoryRepository.GetCategoryAsync(category => category.Id == request.Id);
            if (category is null)
            {
                return Result.Failure<GetCategoryResponse>(CategoryErrors.NotFound(request.Id), ErrorType.NotFound);
            }

            return Result.Success(new GetCategoryResponse(
                category.Id,
                category.CategoryName,
                category.Description));
        }
    }
}
