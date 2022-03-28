using RestaurantApp.Components.DataProviders.Models;
using RestaurantApp.Data.Entities;

namespace RestaurantApp.Components.DataProviders
{
    public interface ISupplyProvider 
    {
        List<IGrouping<string?, Supply>>? GroupByCategory();

        List<GroupedSupplies>? GroupBySupplier();

        List<Supply>? SortByCategory();

        List<Supply>? SortByExpirationDate();

        List<Supply>? SortByPurchaseDate();

        List<Supply>? SortByQuantity();

        List<IGrouping<string, Supply>>? GetIngredientsGroupedByCategory();


    }
}
