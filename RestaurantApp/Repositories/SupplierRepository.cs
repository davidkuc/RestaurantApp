using Microsoft.EntityFrameworkCore;
using RestaurantApp.Entities;

namespace RestaurantApp.Repositories
{
    public class SupplierRepository : SqlRepository<Order>
    {
        public SupplierRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public override IEnumerable<Order> GetAll()
        {
            return _dbSet.Include(p => p.Supplies)
                .ToList();
        }
    }
}
