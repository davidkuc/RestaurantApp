using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantApp.Components.DataProviders;
using RestaurantApp.Components.Exceptions;
using RestaurantApp.Data.Entities.Enums;
using RestaurantApp.Data.Entities;
using RestaurantApp.Data.Repositories;
using RestaurantApp.Components.UI.EntityUI;
using RestaurantApp.Data.Repositories.RepositoryExtensions;
using RestaurantApp.Components.Audit;

namespace RestaurantApp.Components.UI.EntityUI
{
    public class OrderUI : BaseEntityUI<Order>
    {

        private readonly IOrderProvider _orderProvider;
        private readonly IRepository<Order> _baseRepository;
        private readonly IRepository<Employee> _employeeRepository;
        private readonly IRepository<Dish> _dishRepository;

        public OrderUI(IRepository<Order> baseRepository
            , IOrderProvider orderProvider
            , IRepository<Employee> employeeRepository
            , IRepository<Dish> dishRepository
            , IAuditWriter auditWriter) : base(baseRepository, auditWriter)
        {
            _orderProvider = orderProvider;
            _employeeRepository = employeeRepository;
            _dishRepository = dishRepository;
        }

        public override List<Order> Add()
        {
            Console.WriteLine();
            Console.WriteLine("---   Add order   ---");
            Console.WriteLine();
            var ordersToAdd = new List<Order>();
            while (true)
            {
                DisplayEmployees(_employeeRepository);
                Console.WriteLine();
                Console.WriteLine("Choose an employee handling the order (or null)");
                int? employeeID = int.Parse(Console.ReadLine());
                Console.WriteLine("Is the order To Go? (Y/N)");
                bool isToGo;
                var isToGoChoice = Console.ReadLine();
                if (isToGoChoice == "Y")
                {
                    isToGo = true;
                }
                else if (isToGoChoice == "N")
                {
                    isToGo = false;
                }
                else
                {
                    throw new InvalidInputException("Enter Y or N");
                }

                var dishCollection = ChooseDishes();
                var newOrder = CreateOrder(employeeID: employeeID
                    ,isToGo: isToGo
                    ,dishCollection: dishCollection);              
                ordersToAdd.Add(newOrder);
                Console.WriteLine();
                Console.WriteLine("1 - Add another order");
                Console.WriteLine("q - exit");
                Console.WriteLine();
                var addEmployeeChoice = Console.ReadLine();
                if (addEmployeeChoice == "q")
                {
                    break;
                }

            }

            RepositoryExtensions.AddBatch(_baseRepository, ordersToAdd);
            return ordersToAdd;
        }

        private Order CreateOrder(int? employeeID, bool isToGo, ICollection<Dish> dishCollection)
        {
            var newOrder = new Order
                {
                    EmployeeId = employeeID,
                    ToGo = isToGo,
                    OrderDateTime = DateTime.Now,
                    Dishes = dishCollection,
                    Status = Enum.GetName(typeof(OrderStatuses), 1)
                };

            return newOrder;
        }

        private ICollection<Dish> ChooseDishes()
        {
            ICollection<Dish> dishCollection = new List<Dish>();

            Console.WriteLine("Choose dishes for the order");
            DisplayDishes(_dishRepository);

            while (true)
            {
                var chosenDishId = CheckIfEntityExistsByID(_dishRepository);
                dishCollection.Add(_dishRepository.GetById(chosenDishId));

                Console.WriteLine("1 - Add more dishes");
                Console.WriteLine("q - exit");

                var chooseDishesChoice = Console.ReadLine();
                if (chooseDishesChoice == "q")
                {
                    break;
                }
            }

            return dishCollection;
        }

        public override List<Order> Delete()
        {
            Console.WriteLine();
            Console.WriteLine("---   Delete order   ---");
            Console.WriteLine();
            var ordersToDelete = new List<Order>();
            while (true)
            {
                DisplayOrders(_baseRepository);
                var orderToDelete = ChooseEntityByID(_baseRepository);
                ordersToDelete.Add(orderToDelete);
                Console.WriteLine();
                Console.WriteLine("1 - Add another order to delete list");
                Console.WriteLine("q - exit");
                Console.WriteLine();
                var deleteOrderChoice = Console.ReadLine();

                if (deleteOrderChoice == "q")
                {
                    break;
                }
            }

            RepositoryExtensions.DeleteBatch(_baseRepository, ordersToDelete);
            return ordersToDelete;
        }

        public override void Display()
        {
            Console.WriteLine();
            Console.WriteLine("---   Display order data  ---");
            Console.WriteLine();
            while (true)
            {
                Console.WriteLine("1 - Get order information");
                Console.WriteLine("2 - Get orders on site");
                Console.WriteLine("3 - Get orders to go");
                Console.WriteLine("4 - Get orders above value");
                Console.WriteLine("5 - Get orders below value");
                Console.WriteLine("6 - Get orders sorted by datetime asc");
                Console.WriteLine("7 - Get orders sorted by datetime desc");
                Console.WriteLine("8 - Get completed orders");
                Console.WriteLine("9 - Get uncompoleted orders");
                Console.WriteLine("10 - Get orders grouped by employee");
                Console.WriteLine("11 - Get all orders");
                Console.WriteLine("q - Exit");
                Console.WriteLine();
                var displayOrderChoice = Console.ReadLine();

                if (displayOrderChoice == "q")
                {
                    return;
                }

                switch (displayOrderChoice)
                {
                    case "1":
                        DisplayOrderInfo();
                        break;
                    case "2":
                        DisplayOrdersOnSite();
                        break;
                    case "3":
                        DisplayOrdersToGo();
                        break;
                    case "4":
                        DisplayOrdersAboveValue();
                        break;
                    case "5":
                        DisplayOrdersBelowValue();
                        break;
                    case "6":
                        DisplayOrdersSortedByDateTimeAsc();
                        break;
                    case "7":
                        DisplayOrdersSortedByDateTimeDesc();
                        break;
                    case "8":
                        DisplayCompletedOrders();
                        break;
                    case "9":
                        DisplayUncompletedOrders();
                        break;
                    case "10":
                        DisplayOrdersGroupedByEmployee();
                        break;
                    case "11":
                        DisplayOrders(_baseRepository);
                        break;
                    default:
                        break;
                }
            }
        }

        private void DisplayOrdersGroupedByEmployee()
        {
            var orders = _orderProvider.GroupByEmployee();
            foreach (var employee in orders)
            {
                Console.WriteLine(employee.Key);

                foreach (var order in employee)
                {
                    Console.WriteLine(order.ToString());
                }
            }
        }

        private void DisplayUncompletedOrders()
        {
            var orders = _orderProvider.GetUncompletedOrders();
            foreach (var order in orders)
            {
                Console.WriteLine(order.ToString());
            }
        }

        private void DisplayCompletedOrders()
        {
            var orders = _orderProvider.GetCompletedOrders();
            foreach (var order in orders)
            {
                Console.WriteLine(order.ToString());
            }
        }

        private void DisplayOrdersSortedByDateTimeDesc()
        {
            var orders = _orderProvider.SortByOrderDateTimeDesc();
            foreach (var order in orders)
            {
                Console.WriteLine(order.ToString());
            }
        }

        private void DisplayOrdersSortedByDateTimeAsc()
        {
            var orders = _orderProvider.SortByOrderDateTimeAsc();
            foreach (var order in orders)
            {
                Console.WriteLine(order.ToString());
            }
        }

        private void DisplayOrdersBelowValue()
        {
            Console.WriteLine("Enter maximal value");
            var maximalValue = Decimal.Parse(Console.ReadLine());
            var orders = _orderProvider.OrdersBelowValue(maximalValue);
            foreach (var order in orders)
            {
                Console.WriteLine(order.ToString());
            }
        }

        private void DisplayOrdersAboveValue()
        {
            Console.WriteLine("Enter minimal value");
            var minimalValue = Decimal.Parse(Console.ReadLine());
            var orders = _orderProvider.OrdersAboveValue(minimalValue);
            foreach (var order in orders)
            {
                Console.WriteLine(order.ToString());
            }
        }

        private void DisplayOrdersToGo()
        {
            var orders = _orderProvider.GetOrdersToGo();
            foreach (var order in orders)
            {
                Console.WriteLine(order.ToString());
            }
        }

        private void DisplayOrdersOnSite()
        {

            var orders = _orderProvider.GetOrdersOnSite();
            foreach (var order in orders)
            {
                Console.WriteLine(order.ToString());
            }
        }

        private void DisplayOrderInfo()
        {
            var chosenOrder = ChooseEntityByID(_baseRepository);
            Console.WriteLine(chosenOrder.ToString());
            Console.WriteLine(_orderProvider.GetOrderValue(chosenOrder.Id));
        }

        public override void Update()
        {
            Console.WriteLine();
            Console.WriteLine("---   Update order   ---");
            Console.WriteLine();
            while (true)
            {

                DisplayOrders(_baseRepository);
                var chosenEntity = ChooseEntityByID(_baseRepository);
                Console.WriteLine();
                Console.WriteLine("What data do you wish to modify?");
                Console.WriteLine("1 - Employee handling the order");
                Console.WriteLine("2 - Order status");
                Console.WriteLine("3 - Order dishes");
                Console.WriteLine("4 - Exit");
                Console.WriteLine();

                var updateOrderChoice = Console.ReadLine();

                if (updateOrderChoice == "3")
                {
                    return;
                }
                else
                {
                    switch (updateOrderChoice)
                    {
                        case "1":
                            UpdateOrderEmployeeID(chosenEntity);
                            break;
                        case "2":
                            UpdateOrderStatus(chosenEntity);
                            break;
                        default:
                            break;
                    }
                    _baseRepository.Update(chosenEntity);
                }
            }
        }

        private void UpdateOrderStatus(Order chosenEntity)
        {
            Console.WriteLine("Enter order status");
            DisplayOrderStatuses();
            var orderStatusNumber = Int32.Parse(Console.ReadLine());
            var newOrderStatus = Enum.GetName(typeof(SupplyCategories), orderStatusNumber);
            chosenEntity.Status = newOrderStatus;
        }

        private void UpdateOrderEmployeeID(Order chosenEntity)
        {
            Console.WriteLine("Enter employee ID");
            var newEmployeeID = Int32.Parse(Console.ReadLine());
            chosenEntity.EmployeeId = newEmployeeID;
        }

        protected override void OnEntityAdded(object? sender, Order item)
        {
            var message = $"Order {item.Id} added by {nameof(_baseRepository)}";
            Console.WriteLine(message);
            _auditWriter.AddToAuditBatch(message);
        }

        protected override void OnEntityRemoved(object? sender, Order item)
        {
            var message = $"Order {item.Id} removed by {nameof(_baseRepository)}";
            Console.WriteLine(message);
            _auditWriter.AddToAuditBatch(message);
        }

        protected override void OnEntityUpdated(object? sender, Order item)
        {
            var message = $"Order {item.Id} updated by {nameof(_baseRepository)}";
            Console.WriteLine(message);
            _auditWriter.AddToAuditBatch(message);
        }
    }
}
