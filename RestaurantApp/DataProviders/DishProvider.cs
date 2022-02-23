using RestaurantApp.Entities;
using RestaurantApp.Repositories;

namespace RestaurantApp.DataProviders
{
    public class DishProvider : IDishProvider
    {
        private readonly IRepository<Dish> _dishRepository;

        public DishProvider(IRepository<Dish> dishRepository,
            IRepository<Order> orderRepository)
        {
            _dishRepository = dishRepository;
        }
        public List<Dish> DishesAboveValue(decimal minPrice)
        {
            var dishes = _dishRepository.GetAll();
            return dishes.Select(x => x).Where(p => p.Price > minPrice).ToList();
        }

        public List<Dish> DishesBelowValue(decimal maxPrice)
        {
            var dishes = _dishRepository.GetAll();
            return dishes.Select(x => x).Where(p => p.Price < maxPrice).ToList();
        }

        public List<Dish> SortByPriceAsc()
        {
            var dishes = _dishRepository.GetAll();
            return dishes.Select(p => p).OrderBy(p => p.Price).ToList();
        }

        public List<Dish> SortByPriceDesc()
        {
            var dishes = _dishRepository.GetAll();
            return dishes.Select(p => p).OrderByDescending(p => p.Price).ToList();
        }

        public string GetDishInfo(int id)
        {
            var dishInfo = _dishRepository.GetById(id).ToString();          
            return dishInfo;          
        }

        public List<Supply>? GetDishIngredients(int id)
        {
            var dishes = _dishRepository.GetAll();
            return dishes.SingleOrDefault(p => p.Id == id)
                .Supplies?.ToList();
        }

    }
}
