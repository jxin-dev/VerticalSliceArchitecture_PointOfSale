using MediatR;
using Web.Api.Common;

namespace Web.Api.Features.Products.CreateProduct
{
    public record CreateProductCommand(
        string Name,
        Guid CategoryId, 
        decimal Price, 
        int StockQuantity, 
        Guid SupplierId) : IRequest<Result<CreateProductResponse>>;
    
}
