using Microsoft.EntityFrameworkCore;
using RestaurantApp.Entities;

namespace RestaurantApp.Repositories
{
    public class EmployeeRepository : SqlRepository<Employee>
    {
        public EmployeeRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public override IEnumerable<Employee> GetAll()
        {
            return _dbSet
                .Include(p => p.Orders)
                .ToList();
        }
    }
}
