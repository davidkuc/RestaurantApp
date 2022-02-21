using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Entities
{
    public class Supply : EntityBase
    {
        public string Name { get; set; }
        public string? ExpirationDate { get; set; }
        public string? PurchaseDate { get; set; }
        public string? Category { get; set; }
        public int Quantity { get; set; }

       
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }

        public ICollection<Dish>? Dishes { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine();
            sb.AppendLine($" {this.GetType().Name}");
            sb.AppendLine($" {Name} ID: {Id}");
            sb.AppendLine($" Expiration Date: {ExpirationDate}");
            sb.AppendLine($" Purchase Date: {PurchaseDate}");
            sb.AppendLine($" Category: {Category}");
            sb.AppendLine($" Quantity: {Quantity}");
            sb.AppendLine($" Supplier Id: {SupplierId}");
            sb.AppendLine();

            return sb.ToString();
        }
    }
}
