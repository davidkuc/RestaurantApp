using System.Text;
using RestaurantApp.Data.Entities;

namespace RestaurantApp.Data.Entities
{
    public partial class Dish : EntityBase
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public ICollection<Supply>? Supplies{ get; set; }
        public ICollection<Order>? Orders { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine();
            sb.AppendLine($" {this.GetType().Name}");
            sb.AppendLine($" {Name} ID: {Id}");
            sb.AppendLine($" Price: {Price}");
            sb.AppendLine();

            return sb.ToString();
        }
    }
}
