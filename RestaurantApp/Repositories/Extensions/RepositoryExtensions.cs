using Microsoft.EntityFrameworkCore;
using RestaurantApp.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Repositories.Extensions
{
    public static class RepositoryExtensions
    {
       
        public static T[] AddBatch<T>(this IRepository<T> repository, T[] items)
     where T : class, IEntity
        {
            foreach (var item in items)
            {
                repository.Add(item);
            }
            repository.Save();
            return items;
        }

        public static T[] DeleteBatch<T>(this IRepository<T> repository, T[] items)
       where T : class, IEntity
        {
            foreach (var item in items)
            {
                repository.Remove(item);
            }
            repository.Save();
            return items;
        }
    }
}
