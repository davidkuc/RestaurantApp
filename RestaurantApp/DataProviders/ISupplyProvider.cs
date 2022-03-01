using RestaurantApp.Entities;

namespace RestaurantApp.DataProviders
{
    public interface ISupplyProvider 
    {
        List<IGrouping<string?, Supply>>? GroupByCategory();

        List<IGrouping<int, Supply>>? GroupBySupplier();

        List<Supply>? SortByCategory();

        List<Supply>? SortByExpirationDate();

        List<Supply>? SortByPurchaseDate();

        List<Supply>? SortByQuantity();

        List<IGrouping<string, Supply>>? GetIngredientsGroupedByCategory();


    }
}
