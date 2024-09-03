using MediatR;
using Web.Api.Common;

namespace Web.Api.Features.Products.GetProduct
{
    public record GetProductQuery(Guid Id) : IRequest<Result<GetProductResponse>>;
}
