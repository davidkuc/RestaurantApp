using Microsoft.EntityFrameworkCore;
using RestaurantApp.Data.Entities;
using RestaurantApp.Data.Repositories;

namespace RestaurantApp.Data.Repositories
{
    public class DishRepository : SqlRepository<Dish>
    {
        public DishRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public override IEnumerable<Dish> GetAll()
        {
            return _dbSet
                .Include(p => p.Supplies)
                .Include(p => p.Orders)
                .ToList();
        }
    }
}
