using RestaurantApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Components.DataProviders.Models
{
    public class GroupedSupplies
    {
        public string SupplierName { get; set; }

        public IEnumerable<Supply> Supplies { get; set; }
    }
}
