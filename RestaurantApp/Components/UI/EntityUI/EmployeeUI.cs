using RestaurantApp.Components.DataProviders;
using RestaurantApp.Data.Entities.Enums;
using RestaurantApp.Data.Entities;
using RestaurantApp.Data.Repositories;
using RestaurantApp.Data.Repositories.RepositoryExtensions;
using RestaurantApp.Components.Audit;

namespace RestaurantApp.Components.UI.EntityUI
{
    public class EmployeeUI : BaseEntityUI<Employee>
    {
        private readonly IEmployeeProvider _provider;

        public EmployeeUI(IRepository<Employee> baseRepository
            , IEmployeeProvider provider
            , IAuditWriter auditWriter) : base(baseRepository, auditWriter)
        {
            _provider = provider;
        }

        public override List<Employee> Add()
        {
            Console.WriteLine();
            Console.WriteLine("---   Add employee   ---");
            Console.WriteLine();
            var employeesToAdd = new List<Employee>();
            while (true)
            {
                Console.WriteLine("Enter first name");
                var firstName = Console.ReadLine();
                Console.WriteLine("Enter last name");
                var lastName = Console.ReadLine();
                Console.WriteLine("Enter role number");
                DisplayEmployeeRoles();
                var roleNumber = Int32.Parse(Console.ReadLine());
                var role = Enum.GetName(typeof(EmployeeRoles), roleNumber);
                var newEmployee = CreateEmployee(firstName: firstName, lastName: lastName, role: role);
                employeesToAdd.Add(newEmployee);
                Console.WriteLine();
                Console.WriteLine("1 - Add another employee");
                Console.WriteLine("2 - exit");
                Console.WriteLine();
                var addEmployeeChoice = Console.ReadLine();

                if (addEmployeeChoice == "2")
                {
                    break;
                }
            }
            RepositoryExtensions.AddBatch(_baseRepository, employeesToAdd);

            return employeesToAdd;
        }

        private Employee CreateEmployee(string firstName, string lastName, string role)
        {
            var newEmployee = new Employee
            {
                FirstName = firstName,
                LastName = lastName,
                Role = role
            };

            return newEmployee;
        }

        public override List<Employee> Delete()
        {
            Console.WriteLine();
            Console.WriteLine("---   Delete employee   ---");
            Console.WriteLine();
            var employeesToDelete = new List<Employee>();
            while (true)
            {
                DisplayEmployees(_baseRepository);
                var employeeToDelete = ChooseEntityByID(_baseRepository);
                employeesToDelete.Add(employeeToDelete);
                Console.WriteLine();
                Console.WriteLine("1 - Add another employee to delete list");
                Console.WriteLine("2 - exit");
                Console.WriteLine();
                var addEmployeeChoice = Console.ReadLine();

                if (addEmployeeChoice == "2")
                {
                    break;
                }
            }
            RepositoryExtensions.DeleteBatch(_baseRepository, employeesToDelete);

            return employeesToDelete;
        }

        public override void Display()
        {
            Console.WriteLine();
            Console.WriteLine("---   Display employee data  ---");
            Console.WriteLine();
            while (true)
            {
                Console.WriteLine("1 - Get employee information");
                Console.WriteLine("2 - Get orders assigned to employee");
                Console.WriteLine("3 - Get list of employees grouped by roles");
                Console.WriteLine("4 - Get list of employees sorted by roles");
                Console.WriteLine("5 - Get list of all employees");
                Console.WriteLine("6 - Exit");
                Console.WriteLine();
                var userInput = Int32.Parse(Console.ReadLine());

                if (userInput == 6)
                {
                    return;
                }
                try
                {
                    switch (userInput)
                    {
                        case 1:
                            DisplayEmployeeInfo();
                            break;
                        case 2:
                            DisplayEmployeeOrders();
                            break;
                        case 3:
                            DisplayEmployeesGroupedByRole();
                            break;
                        case 4:
                            DisplayEmployeesSortedByRole();
                            break;
                        case 5:
                            DisplayEmployees(_baseRepository);
                            break;
                        default:
                            break;
                    }
                }
                catch (NullReferenceException ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }

        }

        private void DisplayEmployeesSortedByRole()
        {
            var sortedEmployees = _provider.SortByRole();
            foreach (var employee in sortedEmployees)
            {
                Console.WriteLine(employee.ToString());
            }
        }

        private void DisplayEmployeesGroupedByRole()
        {
            var groupedEmployees = _provider.GroupByRole();
            foreach (var group in groupedEmployees)
            {
                Console.WriteLine();
                Console.WriteLine(group.Key);
                foreach (var employee in group)
                {
                    Console.WriteLine(employee.ToString);
                }
            }
        }

        private void DisplayEmployeeOrders()
        {
            Console.WriteLine("Enter employee Id");
            var employeeID = Int32.Parse(Console.ReadLine());
            var employeeOrders = _provider.GetEmployeeOrders(employeeID);
            foreach (var item in employeeOrders)
            {
                Console.WriteLine(item.ToString);
            }
        }

        private void DisplayEmployeeInfo()
        {
            var chosenEmployee = ChooseEntityByID(_baseRepository);
            Console.WriteLine(chosenEmployee.ToString());
        }

        public override void Update()
        {
            Console.WriteLine();
            Console.WriteLine("---   Update employee   ---");
            Console.WriteLine();
            while (true)
            {
                DisplayEmployees(_baseRepository);
                var chosenEmployee = ChooseEntityByID(_baseRepository);
                Console.WriteLine();
                Console.WriteLine("What data do you wish to modify?");
                Console.WriteLine("1 - First name");
                Console.WriteLine("2 - Last name");
                Console.WriteLine("3 - Role");
                Console.WriteLine("4 - exit");
                Console.WriteLine();
                var modifyEmployeeMenuChoice = Console.ReadLine();

                if (modifyEmployeeMenuChoice == "4")
                {
                    return;
                }
                else
                {
                    switch (modifyEmployeeMenuChoice)
                    {
                        case "1":
                            Console.WriteLine("Enter new employee first name");
                            var newFirstName = Console.ReadLine();
                            chosenEmployee.FirstName = newFirstName;
                            break;
                        case "2":
                            Console.WriteLine("Enter new employee last name");
                            var newLastName = Console.ReadLine();
                            chosenEmployee.LastName = newLastName;
                            break;
                        case "3":
                            Console.WriteLine("Enter new employee role");
                            var newRole = Console.ReadLine();
                            chosenEmployee.Role = newRole;
                            break;
                        default:
                            break;
                    }
                    _baseRepository.Update(chosenEmployee);
                }
            }
        }

        protected override void OnEntityAdded(object? sender, Employee item)
        {
            var message = $"Employee {item.FirstName} {item.LastName} added by {nameof(_baseRepository)}";
            Console.WriteLine(message);
            _auditWriter.AddToAuditBatch(message);
        }

        protected override void OnEntityRemoved(object? sender, Employee item)
        {
            var message = $"Employee {item.FirstName} {item.LastName} removed by {nameof(_baseRepository)}";
            Console.WriteLine(message);
            _auditWriter.AddToAuditBatch(message);
        }

        protected override void OnEntityUpdated(object? sender, Employee item)
        {
            var message = $"Employee {item.FirstName} {item.LastName} at ID: {item.Id} updated by {nameof(_baseRepository)}";
            Console.WriteLine(message);
            _auditWriter.AddToAuditBatch(message);
        }
    }
}
