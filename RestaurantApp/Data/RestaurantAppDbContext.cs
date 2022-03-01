using Microsoft.EntityFrameworkCore;
using RestaurantApp.Entities;



namespace RestaurantApp.Data
{
    public partial class RestaurantAppDbContext : DbContext
    {
        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<Order> Suppliers => Set<Order>();
        public DbSet<Supply> Supplies => Set<Supply>();
        public DbSet<Dish> Dishes => Set<Dish>();
        public DbSet<Order> Orders => Set<Order>();

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
            this.MapModels(modelBuilder);        
        }
    }
}


