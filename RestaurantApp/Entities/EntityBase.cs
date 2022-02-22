using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Entities
{
    public class EntityBase : IEntity
    {        
        public int Id { get; set; }      
    }
}
