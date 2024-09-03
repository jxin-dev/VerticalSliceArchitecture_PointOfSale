using MediatR;
using Web.Api.Common;
using Web.Api.Features.Products.GetProduct;

namespace Web.Api.Features.Categories.GetAllProducts
{
    public record GetAllProductsQuery(int PageNumber, int PageSize) 
        : IRequest<Result<PaginatedList<GetProductResponse>>>;
}
