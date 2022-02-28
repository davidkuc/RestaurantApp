using RestaurantApp.Entities;

namespace RestaurantApp.DataProviders
{

    public interface ISupplierProvider
    {
        string GetSupplierInfo(int id);
        List<IGrouping<SupplyCategories?, Order>>? GroupByCategory();
        List<Order>? SortByCategory();
        List<Supply>? GetSupplies(int id);
    }
}
