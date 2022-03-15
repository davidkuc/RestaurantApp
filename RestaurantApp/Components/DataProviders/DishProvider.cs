using RestaurantApp.Components.DataProviders;
using RestaurantApp.Data.Entities;
using RestaurantApp.Data.Repositories;

namespace RestaurantApp.Components.DataProviders
{
    public class DishProvider : IDishProvider
    {
        private readonly IRepository<Dish> _dishRepository;
        private readonly IRepository<Order> _orderRepository;

        public DishProvider(IRepository<Dish> dishRepository,
            IRepository<Order> orderRepository)
        {
            _dishRepository = dishRepository;
            _orderRepository = orderRepository;
        }
        public List<Dish> DishesAboveValue(decimal minPrice)
        {
            return _dishRepository.GetAll()
                .Select(x => x)
                .Where(p => p.Price > minPrice)
                .ToList();
        }

        public List<Dish> DishesBelowValue(decimal maxPrice)
        {
            return _dishRepository.GetAll()
                .Select(x => x)
                .Where(p => p.Price < maxPrice)
                .ToList();
        }

        public List<Dish> SortByPriceAsc()
        {
            return _dishRepository.GetAll()
                .Select(p => p)
                .OrderBy(p => p.Price)
                .ToList();
        }

        public List<Dish> SortByPriceDesc()
        {
            return _dishRepository.GetAll()
                .Select(p => p)
                .OrderByDescending(p => p.Price)
                .ToList();
        }

        public List<Supply>? GetDishIngredients(Dish dish)
        {
            return _dishRepository.GetAll()
                .SingleOrDefault(p => p.Id == dish.Id)
                .Supplies?.ToList();
        }

    }
}
