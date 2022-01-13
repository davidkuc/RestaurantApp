using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Entities
{
    public class SupplyBatch : EntityBase
    {

        string? Name { get; set; }
        DateOnly? ExpirationDate { get; set; }
        DateOnly? PurchaseDate { get; set; }
        string? Category { get; set; }
        int? Quantity { get; set; }

        public override string ToString() => $"Id : {Id}, Name: {Name}, Category: {Category}";
        
            
        
          
       


    }
}
