using System.Linq.Expressions;
using Web.Api.Entities.Products;

namespace Web.Api.Entities.Suppliers
{
    public interface ISupplierRepository
    {
        Task AddSupplierAsync(Supplier supplier);
        Task<Supplier?> GetSupplierAsync(Expression<Func<Supplier, bool>> predicate);
        Task<IEnumerable<Supplier>?> GetSuppliersAsync(Expression<Func<Supplier, bool>>? predicate = null);
    }
}
