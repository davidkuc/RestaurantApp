using RestaurantApp.Entities;

namespace RestaurantApp.DataProviders
{

    public interface IEmployeeProvider
    {
        string GetEmployeeInfo(int id);

        List<IGrouping<string?, Employee>>? GroupByRole();

        List<Employee>? SortByRole();

        List<Order>? GetEmployeeOrders(int? id);
    }

}
