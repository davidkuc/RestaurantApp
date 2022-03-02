using Microsoft.EntityFrameworkCore;
using RestaurantApp.Entities;

namespace RestaurantApp.Repositories
{
    public class SupplierRepository : SqlRepository<Supplier>
    {
        public SupplierRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public override IEnumerable<Supplier> GetAll()
        {
            return _dbSet.Include(p => p.Supplies)
                .ToList();
        }
    }
}
