using System.Globalization;
using RestaurantApp.Components.DataProviders;
using RestaurantApp.Data.Entities.Enums;
using RestaurantApp.Data.Entities;
using RestaurantApp.Data.Repositories;
using RestaurantApp.Components.Audit;

namespace RestaurantApp.Components.UI.EntityUI
{
    public abstract class BaseEntityUI<T> : IEntityUI<T> where T : class, IEntity
    {
        protected readonly IRepository<T> _baseRepository;
        protected readonly IAuditWriter _auditWriter;

        protected BaseEntityUI(IRepository<T> baseRepository
            , IAuditWriter auditWriter)
        {
            _baseRepository = baseRepository;
            _baseRepository.ItemAdded += OnEntityAdded;
            _baseRepository.ItemUpdated += OnEntityUpdated;
            _baseRepository.ItemRemoved += OnEntityRemoved;
            _auditWriter = auditWriter;
        }

        public abstract List<T> Add();

        public abstract List<T> Delete();

        public abstract void Display();

        public abstract void Update();

        protected abstract void OnEntityAdded(object? sender, T item);

        protected abstract void OnEntityRemoved(object? sender, T item);

        protected abstract void OnEntityUpdated(object? sender, T item);



        protected static void DisplayEmployees(IRepository<Employee> employeeRepository)
        {
            var employeeList = employeeRepository.GetAll();
            Console.WriteLine();
            Console.WriteLine("                 Employee list                  ");
            Console.WriteLine();
            foreach (var employee in employeeList)
            {
                Console.WriteLine(employee.ToString());
            }
            Console.WriteLine();
        }

        protected IEnumerable<Supplier>? DisplaySuppliers(IRepository<Supplier> supplierRepository)
        {
            var supplierList = supplierRepository.GetAll();
            if (supplierList == null || supplierList.Count() == 0)
            {
                Console.WriteLine();
                Console.WriteLine("No suppliers in the database - please add a supplier before adding a supply");
                Console.WriteLine();
                return null;
            }
            Console.WriteLine();
            Console.WriteLine("                 Supplier list                  ");
            Console.WriteLine();
            foreach (var supplier in supplierList)
            {
                Console.WriteLine(supplier.ToString());
            }
            Console.WriteLine();
            return supplierList;
        }

        protected static void DisplaySupplies(IRepository<Supply> supplyRepository)
        {
            var supplyList = supplyRepository.GetAll();
            Console.WriteLine();
            Console.WriteLine("                 Supply list                  ");
            Console.WriteLine();
            foreach (var supply in supplyList)
            {
                Console.WriteLine(supply.ToString());
            }
            Console.WriteLine();
        }

        public static void DisplayOrders(IRepository<Order> orderRepository, IOrderProvider orderProvider)
        {
            var orderList = orderRepository.GetAll();
            Console.WriteLine();
            Console.WriteLine("                 Order list                  ");
            Console.WriteLine();
            foreach (var order in orderList)
            {
                Console.WriteLine(order.ToString());
                Console.WriteLine(orderProvider.GetOrderValue(order.Id));
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        protected static void DisplayOrders(IRepository<Order> orderRepository)
        {
            var orderList = orderRepository.GetAll();
            Console.WriteLine();
            Console.WriteLine("                 Order list                  ");
            Console.WriteLine();
            foreach (var order in orderList)
            {
                Console.WriteLine(order.ToString());
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        protected static void DisplayDishes(IRepository<Dish> dishRepository)
        {
            var dishList = dishRepository.GetAll();
            Console.WriteLine();
            Console.WriteLine("                 Dish list                  ");
            Console.WriteLine();
            foreach (var dish in dishList)
            {
                Console.WriteLine(dish.ToString());
            }
            Console.WriteLine();
        }

        protected static void DisplayEmployeeRoles()
        {
            var roles = Enum.GetNames(typeof(EmployeeRole));

            Console.WriteLine();
            foreach (var item in roles)
            {
                Console.WriteLine($"{(int)Enum.Parse(typeof(EmployeeRole), item)} = {item} ");
            }
            Console.WriteLine();
        }

        protected static void DisplaySupplyCategories()
        {
            var categories = Enum.GetNames(typeof(SupplyCategory));

            Console.WriteLine();
            foreach (var category in categories)
            {
                Console.WriteLine($"{(int)Enum.Parse(typeof(SupplyCategory), category)} = {category} ");
            }
            Console.WriteLine();
        }

        protected static void DisplayOrderStatuses()
        {
            var statuses = Enum.GetNames(typeof(OrderStatus));

            Console.WriteLine();
            foreach (var status in statuses)
            {
                Console.WriteLine($"{(int)Enum.Parse(typeof(OrderStatus), status)} = {status} ");
            }
            Console.WriteLine();
        }

        public static DateTime ParseStringToDateTime(string input)
        {
            DateTime dt;
            if (!DateTime.TryParseExact(input, "dd-MM-yyyy", null, DateTimeStyles.None, out dt))
            {
                Console.WriteLine($"Parsing failed - Invalid input, try again");
                while (!DateTime.TryParseExact(Console.ReadLine(), "dd-MM-yyyy", null, DateTimeStyles.None, out dt))
                {
                    Console.WriteLine($"Parsing failed - Invalid input, try again");
                }
            }

            Console.WriteLine("Date parsed correctly!");
            return dt;
        }

        protected static T ChooseEntityByID<T>(IRepository<T> repository)
            where T : class, IEntity
        {
            Console.WriteLine("Choose entity by Id");
            Console.WriteLine("q - exit");
            Console.WriteLine();
            try
            {
                var entityID = Console.ReadLine();
                Console.WriteLine();
                Console.WriteLine("q - exit");
                if (entityID == "q")
                {
                    return null;
                }
                var chosenEntity = repository.GetById(int.Parse(entityID));
                return chosenEntity;
            }
            catch (FormatException)
            {

                Console.WriteLine("Invalid input - try again");
            }

            return null;
        }

        protected int CheckIfEntityExistsByID<T>(IRepository<T> repository)
            where T : class, IEntity
        {
            try
            {
                var inputId = int.Parse(Console.ReadLine());
                if (repository.GetById(inputId) == null)
                {
                    Console.WriteLine($"Entity at ID {inputId} does not exist");
                    int correctedId;
                    while (true)
                    {
                        correctedId = int.Parse(Console.ReadLine());
                        if (repository.GetById(correctedId) == null)
                        {
                            Console.WriteLine($"Entity at ID {correctedId} does not exist");
                        }
                        else
                        {
                            break;
                        }
                    }

                    Console.WriteLine($"Entity at ID {correctedId} found!");
                    return correctedId;
                }
                else
                {
                    Console.WriteLine($"Entity at ID {inputId} found!");
                    return inputId;
                }
            }
            catch (FormatException)
            {

                Console.WriteLine("Invalid input - try again");
                return CheckIfEntityExistsByID(repository);
            }
        }
    }
}
