using RestaurantApp.Entities;

namespace RestaurantApp.DataProviders
{

    public interface ISupplierProvider
    {
        string GetSupplierInfo(int id);
        List<IGrouping<SupplyCategories?, Supplier>>? GroupByCategory();
        List<Supplier>? SortByCategory();
        List<Supply>? GetSupplies(int id);
    }
}
