using RestaurantApp.Entities;

namespace RestaurantApp.DataProviders
{

    public interface ISupplierProvider
    {
        List<IGrouping<string?, Supplier>>? GroupByCategory();
        List<Supplier>? SortByCategory();
        List<Supply>? GetSupplies(int id);
    }
}
