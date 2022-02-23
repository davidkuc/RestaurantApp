using Microsoft.EntityFrameworkCore;
using RestaurantApp.Entities;

namespace RestaurantApp.Repositories
{
    public class OrderRepository : SqlRepository<Order> 
    {
        public OrderRepository(DbContext dbContext) : base(dbContext)
        {         
        }     

        public override IEnumerable<Order> GetAll()
        {
            return _dbSet
                .Include(p => p.Dishes)
                .ToList();
        }

       
    }
}
