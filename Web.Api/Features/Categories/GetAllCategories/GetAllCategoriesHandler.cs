using MediatR;
using Microsoft.EntityFrameworkCore;
using Web.Api.Common;
using Web.Api.Entities.Categories;

namespace Web.Api.Features.Categories.GetAllCategories
{
    public class GetAllProductsHandler(
        ICategoryRepository categoryRepository)
        : IRequestHandler<GetAllProductsQuery, Result<PaginatedList<GetAllCategoriesResponse>>>
    {
        public async Task<Result<PaginatedList<GetAllCategoriesResponse>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var categories = await categoryRepository.GetCategoriesAsync();
            if (categories is null)
            {
                return Result.Failure<PaginatedList<GetAllCategoriesResponse>>(CategoryErrors.NotFound(), ErrorType.NotFound);
            }   

     
            var pagination = PaginatedList<GetAllCategoriesResponse>.CreateAsync(
                categories.Select(c => 
                    new GetAllCategoriesResponse(c.Id, c.CategoryName, c.Description)).ToList(),
                request.PageNumber, 
                request.PageSize);

            return Result.Success(pagination);
        }
    }
}
