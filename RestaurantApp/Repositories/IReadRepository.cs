using RestaurantApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Repositories
{
    public interface IReadRepository<T> where T : class, IEntity
    {
        IEnumerable<T> GetAll();

        T GetById(int id);
    }
}
