using Microsoft.EntityFrameworkCore;
using RestaurantApp.Entities;



namespace RestaurantApp.Data
{
    public class RestaurantAppDbContext : DbContext
    {
        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<Supplier> Suppliers => Set<Supplier>();
        public DbSet<Supply> Supplies => Set<Supply>();

        public RestaurantAppDbContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=EFCore_CodeFirst_RestaurantApp;" +
    "Trusted_Connection = True;");


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dish>().Property(p => p.PricePerDish).HasColumnType("smallmoney");
            modelBuilder.Entity<Dish>().Property(p => p.TotalSales).HasColumnType("money");
            modelBuilder.Entity<Order>().Property(p => p.OrderValue).HasColumnType("smallmoney");
        }
    }
}


