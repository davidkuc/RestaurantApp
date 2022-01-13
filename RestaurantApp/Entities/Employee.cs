using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Entities
{
    public class Employee : EntityBase
    {

        string? FirstName { get; set; }
        string? LastName { get; set; }

        string? Role { get; set; }


        public override string ToString() => $"Id : {Id}, FirstName: {FirstName}";
    }
}
