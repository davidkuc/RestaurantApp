using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantApp.Data.Entities;
using RestaurantApp.Data.Entities.Enums;

namespace RestaurantApp.Data.Entities
{
    public class Supplier : EntityBase
    {
        public string Name { get; set; }
        public string SupplyCategory { get; set; }

        public ICollection<Supply>? Supplies { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(100);

            sb.AppendLine();
            sb.AppendLine($" {this.GetType().Name}");
            sb.AppendLine($" {Name} ID: {Id}");
            sb.AppendLine($" Supply Categories: {SupplyCategory}");            
            sb.AppendLine();

            return sb.ToString();
        }
    }
}
