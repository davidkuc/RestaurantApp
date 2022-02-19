using Microsoft.EntityFrameworkCore;
using RestaurantApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Repositories
{

    public delegate void ItemAdded<T>(T sender);

    public class SqlRepository<T> : IRepository<T> where T : class, IEntity, new()
    {
        public event ItemAdded<T>? _itemAddedCallBack;

        private readonly DbSet<T> _dbSet;
        private readonly DbContext _dbContext;

        public SqlRepository(DbContext dbContext, ItemAdded<T>? itemAddedCallBack = null)
        {

            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
            this._itemAddedCallBack = itemAddedCallBack;
        }

        public T? GetById(int id)
        {

            return _dbSet.Find(id);
        }


        public void Add(T item)
        {

            _dbSet.Add(item);
            _itemAddedCallBack?.Invoke(item);

        }
        public void Remove(T item)
        {

            _dbSet.Remove(item);

        }
        public void Save()
        {

            _dbContext.SaveChanges();

        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }
    }
}
