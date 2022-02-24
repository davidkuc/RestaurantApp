using RestaurantApp.Entities;
using RestaurantApp.Repositories;

namespace RestaurantApp.DataProviders
{
    public class EmployeeProvider : IEmployeeProvider
    {
        private readonly IRepository<Employee> _employeeRepository;


        public EmployeeProvider(IRepository<Employee> employeeRepository)
        {
            _employeeRepository = employeeRepository;

        }


        public string GetEmployeeInfo(int id)
        {
            var employee = _employeeRepository.GetById(id);
            return employee.ToString();
        }

        public List<Order>? GetEmployeeOrders(int? id)
        {
            var employees = _employeeRepository.GetAll();
            
            return employees.SingleOrDefault(p => p.Id == id)?
                .Orders?.ToList();
        }

        public List<IGrouping<string?, Employee>>? GroupByRole()
        {
            var employees = _employeeRepository.GetAll();

            return employees.GroupBy(p => p.Role)
                .ToList();
        }

        public List<Employee> SortByRole()
        {
            var employees = _employeeRepository.GetAll();

            return employees.OrderBy(p => p.Role)
                .ToList();
        }
    }

}
