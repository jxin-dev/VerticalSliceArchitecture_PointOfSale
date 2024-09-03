using MediatR;
using Web.Api.Common;

namespace Web.Api.Features.Suppliers.CreateSupplier
{
    public record GetSupplierQuery(
        string SupplierName, 
        string ContactName,
        string Phone,
        string Address) : IRequest<Result<GetSupplierResponse>>;
}
