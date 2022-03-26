using Microsoft.EntityFrameworkCore;
using RestaurantApp.Data.Entities;
using RestaurantApp.Data.Repositories;

namespace RestaurantApp.Data.Repositories
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
