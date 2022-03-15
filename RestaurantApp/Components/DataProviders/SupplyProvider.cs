using RestaurantApp.Components.DataProviders;
using RestaurantApp.Data.Entities.Enums;
using RestaurantApp.Data.Entities;
using RestaurantApp.Data.Repositories;

namespace RestaurantApp.Components.DataProviders
{
    public class SupplyProvider : ISupplyProvider
    {
        private readonly IRepository<Supply> _supplyRepository;

        public SupplyProvider(IRepository<Supply> supplyRepository)
        {
            _supplyRepository = supplyRepository;
        }

        public List<IGrouping<string, Supply>>? GetIngredientsGroupedByCategory()
        {
            return _supplyRepository.GetAll().
                GroupBy(x => x.Category)
                .Where(p => p.Key != Enum.GetName(typeof(SupplyCategories), 6) && p.Key != Enum.GetName(typeof(SupplyCategories), 7))
                .ToList();
        }

        public List<IGrouping<string?, Supply>>? GroupByCategory()
        {
            return _supplyRepository.GetAll()
                .GroupBy(x => x.Category).
                ToList();
        }

        public List<IGrouping<int, Supply>> GroupBySupplier()
        {
            return _supplyRepository.GetAll()
                .GroupBy(x => x.SupplierID)
                .ToList(); 
        }

        public List<Supply> SortByCategory()
        {
            return _supplyRepository.GetAll()
                .OrderBy(x => x.Category)
                .ToList();
        }

        public List<Supply> SortByExpirationDate()
        {
            return _supplyRepository.GetAll()
                .OrderBy(x => x.ExpirationDate)
                .ToList();
        }

        public List<Supply> SortByPurchaseDate()
        {
            return _supplyRepository.GetAll()
                .OrderBy(x => x.PurchaseDate)
                .ToList();
        }

        public List<Supply> SortByQuantity()
        {
            return _supplyRepository.GetAll()
                .OrderBy(x => x.Quantity)
                .ToList();
        }
    }
}
