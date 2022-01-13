using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Entities
{
    public class Supplier : EntityBase
    {

        string? Firm { get; set; }
        string? SupplyCategory { get; set; }

        public override string ToString() => $"Id : {Id}, Firm: {Firm}, Supply Category: {SupplyCategory} ";

    }
}
