using RestaurantApp.Entities;
using RestaurantApp.Repositories;
using System.Linq;

namespace RestaurantApp.DataProviders
{
    public class OrderProvider : IOrderProvider
    {
        private readonly IRepository<Order> _orderRepository;


        public OrderProvider(IRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;

        }

        public List<Order> GetOrdersOnSite()
        {
            return _orderRepository.GetAll()
                     .Select(p => p)
                     .Where(p => p.ToGo == false)
                     .ToList();
        }

        public List<Order> GetOrdersToGo()
        {
            return _orderRepository.GetAll()
                .Select(p => p)
                .Where(p => p.ToGo == true)
                .ToList();
        }

        public decimal? GetOrderValue(int id)
        {
            return _orderRepository.GetAll()
                .SingleOrDefault(x => x.Id == id)
                .Dishes?.Sum(p => p.Price);
        }

        public List<Order> OrdersAboveValue(decimal minPrice)
        {

            return _orderRepository.GetAll()
                .Select(p => new Order
                {
                    Id = p.Id,
                    ToGo = p.ToGo,
                    OrderDateTime = p.OrderDateTime,
                    EmployeeId = p.EmployeeId,
                    OrderValue = p.Dishes?.Sum(p => p.Price)
                }
            ).Where(p => p.OrderValue > minPrice)
            .ToList();

        }

        public List<Order> OrdersBelowValue(decimal maxPrice)
        {

            return _orderRepository.GetAll()
                .Select(p => new Order
                {
                    Id = p.Id,
                    ToGo = p.ToGo,
                    OrderDateTime = p.OrderDateTime,
                    EmployeeId = p.EmployeeId,
                    OrderValue = p.Dishes?.Sum(p => p.Price)
                }
            ).Where(p => p.OrderValue < maxPrice)
            .ToList();
        }

        public List<Order> SortByOrderDateTimeAsc()
        {
            return _orderRepository.GetAll()
                .OrderBy(p => p.OrderDateTime)
                .ToList();
        }

        public List<Order> SortByOrderDateTimeDesc()
        {
            return _orderRepository.GetAll()
               .OrderByDescending(p => p.OrderDateTime)
               .ToList();
        }

        public List<Order>? GetCompletedOrders()
        {
            return _orderRepository.GetAll()
                .Where(p => p.Status == Enum.GetName(typeof(OrderStatuses), 1))
                .ToList();
        }

        public List<Order>? GetUncompletedOrders()
        {
            return _orderRepository.GetAll()
                .Where(p => p.Status != Enum.GetName(typeof(OrderStatuses), 1))
                .ToList();
        }

        public List<IGrouping<int?, Order>> GroupByEmployee()
        {
            return _orderRepository.GetAll()
                .GroupBy(p => p.EmployeeId)
                .ToList();
        }
    }
}
