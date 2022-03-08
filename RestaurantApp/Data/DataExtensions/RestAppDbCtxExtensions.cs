using Microsoft.EntityFrameworkCore;
using RestaurantApp.Data;
using RestaurantApp.Data.Entities;

namespace RestaurantApp.Data.DataExtensions
{
   
        public static class RestAppDbCtxExtensions
        {
            public static void MapModels(this DbContext dbContext, ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Dish>()
                  .Property(p => p.Price)
                  .HasColumnType("smallmoney");
                modelBuilder.Entity<Order>()
                    .Property(p => p.OrderValue)
                    .HasColumnType("smallmoney");
                modelBuilder.Entity<Order>()
                    .Property(p => p.OrderDateTime)
                    .HasColumnType("smalldatetime");
                modelBuilder.Entity<Supply>()
                    .Property(p => p.ExpirationDate)
                    .HasColumnType("smalldatetime");
                modelBuilder.Entity<Supply>()
                    .Property(p => p.PurchaseDate)
                    .HasColumnType("smalldatetime");
     
                  
        }
        }
    
}


