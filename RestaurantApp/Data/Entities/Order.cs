using System.Text;
using RestaurantApp.Data.Entities;
using RestaurantApp.Data.Entities.Enums;

namespace RestaurantApp.Data.Entities
{
    public class Order : EntityBase
    {
        public string Status { get; set; }
        public bool? ToGo { get; set; }
        public DateTime OrderDateTime { get; set; }
        public int? EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public ICollection<Dish>? Dishes { get; set; }
        public decimal? OrderValue { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine();
            sb.AppendLine($" {this.GetType().Name}");
            sb.AppendLine($" Order ID: {Id}");
            sb.AppendLine($" Order DateTime = {OrderDateTime}");
            sb.AppendLine($" Employee ID = {EmployeeId ?? 99999999}");
            sb.AppendLine();

            return sb.ToString();
        }
    }
}
