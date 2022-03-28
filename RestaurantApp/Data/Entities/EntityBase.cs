using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantApp.Data.Entities;

namespace RestaurantApp.Data.Entities
{
    public class EntityBase : IEntity
    {
        public int Id { get; set; }
    }
}
