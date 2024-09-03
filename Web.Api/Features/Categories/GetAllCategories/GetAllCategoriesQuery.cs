using MediatR;
using Web.Api.Common;

namespace Web.Api.Features.Categories.GetAllCategories
{
    public record GetAllProductsQuery(int PageNumber, int PageSize) 
        : IRequest<Result<PaginatedList<GetAllCategoriesResponse>>>;
}
