using MediatR;
using Web.Api.Common;
using Web.Api.Entities.Suppliers;

namespace Web.Api.Features.Suppliers.CreateSupplier
{
    public class GetSupplierHandler(ISupplierRepository supplierRepository) 
        : IRequestHandler<GetSupplierQuery, Result<GetSupplierResponse>>
    {
        public async Task<Result<GetSupplierResponse>> Handle(GetSupplierQuery request, CancellationToken cancellationToken)
        {
            var supplier = new Supplier()
            {
                Id = Guid.NewGuid(),
                SupplierName = request.SupplierName,
                ContactName = request.ContactName,
                Phone = request.Phone,
                Address = request.Address,
            };

            await supplierRepository.AddSupplierAsync(supplier);

            return Result.Success(new GetSupplierResponse(supplier.Id));
        }
    }
}
