using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Web.Api.Database;
using Web.Api.Entities.Suppliers;

namespace Web.Api.Features.Suppliers
{
    public class SupplierRepository(ApplicationDbContext dbContext) : ISupplierRepository
    {
        public async Task AddSupplierAsync(Supplier supplier)
        {
            await dbContext.Suppliers.AddAsync(supplier);
            await dbContext.SaveChangesAsync();
        }

        public Task<Supplier?> GetSupplierAsync(Expression<Func<Supplier, bool>> predicate)
        {
            return dbContext.Suppliers.SingleOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<Supplier>?> GetSuppliersAsync(Expression<Func<Supplier, bool>>? predicate = null)
        {
            if (predicate is null)
            {
                return await dbContext.Suppliers.ToListAsync();
            }

            return await dbContext.Suppliers.Where(predicate).ToListAsync();

        }
    }
}