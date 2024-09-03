using MediatR;
using Web.Api.Common;
using Web.Api.Entities.Suppliers;

namespace Web.Api.Features.Suppliers.GetSupplier
{
    public class GetSupplierHandler(ISupplierRepository supplierRepository) 
        : IRequestHandler<GetSupplierQuery, Result<GetSupplierResponse>>
    {
        public async Task<Result<GetSupplierResponse>> Handle(GetSupplierQuery request, CancellationToken cancellationToken)
        {
            var supplier = await supplierRepository.GetSupplierAsync(supplier => supplier.Id == request.Id);
            if (supplier is null)
            {
                return Result.Failure<GetSupplierResponse>(SupplierErrors.NotFound(request.Id), ErrorType.NotFound);
            }

            return Result.Success(new GetSupplierResponse(
                supplier.Id,
                supplier.SupplierName,
                supplier.ContactName,
                supplier.Phone,
                supplier.Address));
        }
    }
}
