using RestaurantApp.Data.Entities;
using RestaurantApp.Components.UI.EntityUI;
using RestaurantApp.Components.UI;

namespace RestaurantApp.Components.UI
{
    public class StartUI : IStartUI
    {
        private readonly IEntityUI<Employee> _employeeUI;
        private readonly IEntityUI<Supplier> _supplierUI;
        private readonly IEntityUI<Supply> _supplyUI;
        private readonly IEntityUI<Dish> _dishUI;
        private readonly IEntityUI<Order> _orderUI;

        public StartUI(IEntityUI<Employee> employeeUI
            , IEntityUI<Supplier> supplierUI
            , IEntityUI<Supply> supplyUI
            , IEntityUI<Dish> dishUI
            , IEntityUI<Order> orderUI)
        {
            _employeeUI = employeeUI;
            _supplierUI = supplierUI;
            _supplyUI = supplyUI;
            _dishUI = dishUI;
            _orderUI = orderUI;
        }

        public void MainMenuUI<T>(IEntityUI<T> entityUI)
            where T : class, IEntity
        {
            Console.WriteLine("Hello!");
            Console.WriteLine();
            Console.WriteLine("What do you wish to do?");
            Console.WriteLine();

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("--------- Main Menu ---------");
                Console.WriteLine($"        ({typeof(T).Name})         ");
                Console.WriteLine();
                Console.WriteLine("1 - Add entity");
                Console.WriteLine("2 - Delete entity");
                Console.WriteLine("3 - Update entity data");
                Console.WriteLine("4 - Display entity data");
                Console.WriteLine("5 - Choose a different entity");
                Console.WriteLine();
                Console.WriteLine("------------------------------");
                Console.WriteLine();
                Console.WriteLine();
                var mainMenuChoice = Console.ReadLine();


                if (mainMenuChoice == "5")
                {
                    return;
                }
                else
                {
                    switch (mainMenuChoice)
                    {
                        case "1":
                            AddEntityUI(entityUI);
                            break;
                        case "2":
                            DeleteEntityUI(entityUI);
                            break;
                        case "3":
                            UpdateEntityUI(entityUI);
                            break;
                        case "4":
                            DisplayEntityUI(entityUI);
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        public void InitializeUI()
        {

            Console.WriteLine();
            Console.WriteLine("---   Welcome!   ---");
            Console.WriteLine();
            Console.WriteLine("Choose an entity to handle");
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("--------- Start Menu ---------");
                Console.WriteLine();
                Console.WriteLine("1 - Employee");
                Console.WriteLine("2 - Supplier");
                Console.WriteLine("3 - Supply");
                Console.WriteLine("4 - Order");
                Console.WriteLine("5 - Dish");
                Console.WriteLine("6 - exit");
                Console.WriteLine();
                Console.WriteLine("------------------------------");
                Console.WriteLine();
                Console.WriteLine();
                var chooseEntityMenuChoice = Console.ReadLine();
                if (chooseEntityMenuChoice == "6")
                {

                    break;
                }
                else
                {
                    switch (chooseEntityMenuChoice)
                    {
                        case "1":
                            MainMenuUI(_employeeUI);
                            break;
                        case "2":
                            MainMenuUI(_supplierUI);
                            break;
                        case "3":
                            MainMenuUI(_supplyUI);
                            break;
                        case "4":
                            MainMenuUI(_orderUI);
                            break;
                        case "5":
                            MainMenuUI(_dishUI);
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        public void AddEntityUI<T>(IEntityUI<T> entityComm)
            where T : class, IEntity
        {
            entityComm.Add();

        }

        public void DeleteEntityUI<T>(IEntityUI<T> entityComm)
            where T : class, IEntity
        {
            entityComm.Delete();
        }

        public void DisplayEntityUI<T>(IEntityUI<T> entityComm)
            where T : class, IEntity
        {
            entityComm.Display();
        }

        public void UpdateEntityUI<T>(IEntityUI<T> entityComm)
            where T : class, IEntity
        {
            entityComm.Update();
        }
    }
}
