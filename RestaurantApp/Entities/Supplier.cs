using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Entities
{
    public class Supplier : EntityBase
    {

        public string Firm { get; set; }
        public string SupplyCategory { get; set; }

        public ICollection<Supply> Supplies { get; set; }

    }
}
