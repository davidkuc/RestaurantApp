using RestaurantApp.Components.DataProviders;
using RestaurantApp.Data.Entities;
using RestaurantApp.Data.Repositories;

namespace RestaurantApp.Components.DataProviders
{
    public class EmployeeProvider : IEmployeeProvider
    {
        private readonly IRepository<Employee> _employeeRepository;


        public EmployeeProvider(IRepository<Employee> employeeRepository)
        {
            _employeeRepository = employeeRepository;

        }

        public List<Order>? GetEmployeeOrders(int? id)
        {                
            return _employeeRepository.GetAll().
                SingleOrDefault(p => p.Id == id)?
                .Orders?.ToList();
        }

        public List<IGrouping<string?, Employee>>? GroupByRole()
        {
            return _employeeRepository.GetAll().GroupBy(p => p.Role)
                .ToList();
        }

        public List<Employee> SortByRole()
        {
            return _employeeRepository.GetAll().OrderBy(p => p.Role)
                .ToList();
        }
    }

}
