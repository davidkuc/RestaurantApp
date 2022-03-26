using Microsoft.EntityFrameworkCore;
using RestaurantApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAppTests
{
    public class RestaurantAppTestsDbContext : RestaurantAppDbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("RestaurantAppMemoryDb");
        }
    }
}
