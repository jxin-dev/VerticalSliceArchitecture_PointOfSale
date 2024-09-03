using Web.Api.Common;

namespace Web.Api.Entities.Suppliers
{
    public static class SupplierErrors
    {
        public static Error NotFound(Guid supplierId)
        {
            return new Error("Supplier.NotFound", $"The supplier with Id = {supplierId} was not found.");
        }
    }
}