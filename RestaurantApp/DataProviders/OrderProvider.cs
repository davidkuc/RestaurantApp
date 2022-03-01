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
            var orders = _orderRepository.GetAll();
            var result = orders.Select(p => p)
                .Where(p => p.ToGo == false)
                .ToList();
            return result;
        }

        public List<Order> GetOrdersToGo()
        {
            var orders = _orderRepository.GetAll();
            var result = orders.Select(p => p)
                .Where(p => p.ToGo == true)
                .ToList();
            return result;
        }

        public decimal? GetOrderValue(int id)
        {
            var orders = _orderRepository.GetAll();
            var order = _orderRepository.GetById(id);
            var result = order.Dishes?.Sum(p => p.Price);
            return result;
        }

        public List<Order> OrdersAboveValue(decimal minPrice)
        {
            var orders = _orderRepository.GetAll();
            var result = orders.Select(p => new Order
            { 
            Id = p.Id,
            ToGo = p.ToGo,
            OrderDateTime = p.OrderDateTime,
            EmployeeId = p.EmployeeId,
            OrderValue = p.Dishes?.Sum(p => p.Price)
            }
            ).Where(p => p.OrderValue > minPrice)
            .ToList();               
            return result;
        }

        public List<Order> OrdersBelowValue(decimal maxPrice)
        {
            var orders = _orderRepository.GetAll();
            var result = orders.Select(p => new Order
            {
                Id = p.Id,
                ToGo = p.ToGo,
                OrderDateTime = p.OrderDateTime,
                EmployeeId = p.EmployeeId,
                OrderValue = p.Dishes?.Sum(p => p.Price)
            }
            ).Where(p => p.OrderValue < maxPrice)
            .ToList();
            return result;
        }

        public List<Order> SortByOrderDateTimeAsc()
        {
            var orders = _orderRepository.GetAll();
            return orders.OrderBy(p => p.OrderDateTime)
                .ToList();
        }

        public List<Order> SortByOrderDateTimeDesc()
        {
            var orders = _orderRepository.GetAll();
            return orders.OrderByDescending(p => p.OrderDateTime)
                .ToList();
        }

        public List<Order>? GetCompletedOrders()
        {
            var orders = _orderRepository.GetAll();
            return orders.Select(p => p)
                .Where(p => p.Status == true)
                .ToList();
        }

        public List<Order>? GetUncompletedOrders()
        {
            var orders = _orderRepository.GetAll();
            return orders.Select(p => p)
                .Where(p => p.Status == false)
                .ToList();
        }

        public List<IGrouping<int,Order>> GroupByEmployee()
        {
            var orders = _orderRepository.GetAll();
            return orders.GroupBy(p => p.EmployeeId)
                .ToList();
        }
    }
}
