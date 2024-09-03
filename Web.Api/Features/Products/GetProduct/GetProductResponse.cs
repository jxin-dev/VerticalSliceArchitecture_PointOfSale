
namespace Web.Api.Features.Products.GetProduct
{
    public record GetProductResponse(
        Guid Id,
        string Name,
        CategoryResponse Category,
        decimal Price,
        int StockQuantity,
        SupplierResponse Supplier);

    public record CategoryResponse(Guid Id, string CategoryName, string Description);
    public record SupplierResponse(Guid Id, string SupplierName, string ContactName, 
        string Phone, string Address);

}
