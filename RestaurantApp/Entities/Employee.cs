using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Entities
{
    public class Employee : EntityBase
    {

       public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public string? Role { get; set; }


       
    }
}
