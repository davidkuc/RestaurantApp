
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantApp.Data.Entities;
using RestaurantApp.Data.Entities.Enums;

namespace RestaurantApp.Data.Entities
{
    public class Employee : EntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }

        public ICollection<Order>? Orders { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine();
            sb.AppendLine($" {this.GetType().Name}");
            sb.AppendLine($" {FirstName} {LastName} ID: {Id}");
            sb.AppendLine($" Role: {Role}");
            sb.AppendLine();

            return sb.ToString();
        }

    }
}
