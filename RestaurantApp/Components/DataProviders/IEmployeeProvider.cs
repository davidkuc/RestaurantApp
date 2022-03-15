using RestaurantApp.Data.Entities;

namespace RestaurantApp.Components.DataProviders
{

    public interface IEmployeeProvider
    {
        List<IGrouping<string?, Employee>>? GroupByRole();

        List<Employee>? SortByRole();

        List<Order>? GetEmployeeOrders(int? id);
    }

}
