namespace Web.Api.Features.Suppliers.GetSupplier
{
    public record GetSupplierResponse(
        Guid Id,
        string SupplierName,
        string ContactName,
        string Phone,
        string Address);
}
