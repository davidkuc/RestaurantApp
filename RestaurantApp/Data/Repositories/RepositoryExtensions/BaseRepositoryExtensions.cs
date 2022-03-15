using RestaurantApp.Data.Entities;

namespace RestaurantApp.Data.Repositories.RepositoryExtensions
{
    public static class RepositoryExtensions
    {
        public static void AddBatch<T>(IRepository<T> repository, IEnumerable<T> items)
              where T : class, IEntity
        {
            foreach (var item in items)
            {
                repository.Add(item);
            }
            repository.Save();
        }

        public static void DeleteBatch<T>(IRepository<T> repository, IEnumerable<T> items)
       where T : class, IEntity
        {
            foreach (var item in items)
            {
                repository.Remove(item);
            }
            repository.Save();
        }

    }
}
