using Microsoft.EntityFrameworkCore;
using RestaurantApp.Entities;

namespace RestaurantApp.Repositories
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
                .ToList();
        }
    }
}
