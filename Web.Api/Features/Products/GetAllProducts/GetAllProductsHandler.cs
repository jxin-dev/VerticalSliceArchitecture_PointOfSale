using MediatR;
using Microsoft.EntityFrameworkCore;
using Web.Api.Common;
using Web.Api.Entities.Categories;
using Web.Api.Entities.Products;
using Web.Api.Features.Products.GetProduct;

namespace Web.Api.Features.Categories.GetAllProducts
{
    public class GetAllProductsHandler(
        IProductRepository productRepository)
        : IRequestHandler<GetAllProductsQuery, Result<PaginatedList<GetProductResponse>>>
    {
        public async Task<Result<PaginatedList<GetProductResponse>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await productRepository.GetProductsAsync();
            if (products is null)
            {
                return Result.Failure<PaginatedList<GetProductResponse>>(ProductErrors.NotFound(), ErrorType.NotFound);
            }   

     
            var pagination = PaginatedList<GetProductResponse>.CreateAsync(
                products.Select(p =>
                    new GetProductResponse(
                p.Id,
                p.Name,
                new CategoryResponse(
                    p.Category.Id,
                    p.Category.CategoryName,
                    p.Category.Description),
                p.Price,
                p.StockQuantity,
                new SupplierResponse(
                    p.Supplier.Id,
                    p.Supplier.SupplierName,
                    p.Supplier.ContactName,
                    p.Supplier.Phone,
                    p.Supplier.Address))).ToList(),
                request.PageNumber, 
                request.PageSize);

            return Result.Success(pagination);
        }
    }
}
