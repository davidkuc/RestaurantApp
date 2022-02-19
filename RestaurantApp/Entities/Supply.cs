using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Entities
{
    public class Supply : EntityBase
    {

     
        public string ExpirationDate { get; set; }
        public string PurchaseDate { get; set; }
        public string? Category { get; set; }
        public int? Quantity { get; set; }

        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }




    }
}
