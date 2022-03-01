using RestaurantApp.Entities;

namespace RestaurantApp.DataProviders
{

    public interface ISupplierProvider
    {
        List<IGrouping<SupplyCategories?, Order>>? GroupByCategory();
        List<Order>? SortByCategory();
        List<Supply>? GetSupplies(int id);
    }
}
