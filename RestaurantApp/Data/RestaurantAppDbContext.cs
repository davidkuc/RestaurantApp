using Microsoft.EntityFrameworkCore;
using RestaurantApp.Entities;



namespace RestaurantApp.Data
{
    public class RestaurantAppDbContext : DbContext
    {


        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<Supplier> Suppliers => Set<Supplier>();

        public DbSet<Supply> Supplies => Set<Supply>();


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(System.Configuration.ConfigurationManager
                .ConnectionStrings["DefaultConnectionString"].ConnectionString);



        }
    }
}


