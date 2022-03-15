using Microsoft.EntityFrameworkCore;
using RestaurantApp.Data.Entities;
using RestaurantApp.Data.Repositories;

namespace RestaurantApp.Data.Repositories
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
