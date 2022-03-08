using Microsoft.EntityFrameworkCore;
using System.Configuration;
using RestaurantApp.Data.DataExtensions;
using RestaurantApp.Data.Entities;

namespace RestaurantApp.Data
{
    public partial class RestaurantAppDbContext : DbContext
    {
        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<Supplier> Suppliers => Set<Supplier>();
        public DbSet<Supply> Supplies => Set<Supply>();
        public DbSet<Dish> Dishes => Set<Dish>();
        public DbSet<Order> Orders => Set<Order>();

        public RestaurantAppDbContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(ConfigurationManager
                .ConnectionStrings["DefaultConnectionString"]
                .ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            this.MapModels(modelBuilder);        
        }
    }
}


