using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantApp.Data.Entities;
using RestaurantApp.Data.Repositories;

namespace RestaurantApp.Data.Repositories
{
    public class SqlRepository<T> : IRepository<T> where T : class, IEntity, new()
    {
        protected readonly DbSet<T> _dbSet;
        protected readonly DbContext _dbContext;

        public SqlRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public event EventHandler<T>? ItemAdded;
        public event EventHandler<T>? ItemRemoved;
        public event EventHandler<T>? ItemUpdated;

        public virtual T? GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public virtual void Add(T item)
        {
            if (item == null)
            {
                Console.WriteLine("Cannot add 'null'");
                return;
            }

            _dbSet.Add(item);
            ItemAdded?.Invoke(this, item);
        }

        public virtual void Remove(T item)
        {
            if (item == null)
            {
                Console.WriteLine("Cannot remove 'null'");
                return;
            }

            _dbSet.Remove(item);
            ItemRemoved?.Invoke(this, item);
        }

        public virtual void Save()
        {
            _dbContext.SaveChanges();
        }

        public virtual void Update(T itemChanges)
        {
            if (itemChanges == null)
            {
                Console.WriteLine("Cannot update 'null'");
                return;
            }

            var item = _dbSet.Attach(itemChanges);
            item.State = EntityState.Modified;
            Save();
            ItemUpdated?.Invoke(this, itemChanges);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }
    }
}
