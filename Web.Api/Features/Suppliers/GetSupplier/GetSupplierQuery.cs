using MediatR;
using Web.Api.Common;

namespace Web.Api.Features.Suppliers.GetSupplier
{
    public record GetSupplierQuery(Guid Id) : IRequest<Result<GetSupplierResponse>>;
}
