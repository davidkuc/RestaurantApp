using RestaurantApp.Entities;
using RestaurantApp.Repositories;

namespace RestaurantApp.DataProviders
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
            var supplies = _supplyRepository.GetAll();
            var result = supplies.GroupBy(x => x.Category)
                .Where(p => p.Key != Enum.GetName(typeof(SupplyCategories), 6) && p.Key != Enum.GetName(typeof(SupplyCategories), 7))
                .ToList();
            return result;
        }

        public List<IGrouping<string?, Supply>>? GroupByCategory()
        {
            var supplies = _supplyRepository.GetAll();
            var result = supplies.GroupBy(x => x.Category).ToList();
            return result;
        }

        public List<IGrouping<int, Supply>> GroupBySupplier()
        {
            var supplies = _supplyRepository.GetAll();
            var result = supplies.GroupBy(x => x.SupplierID).ToList();
            return result;
        }

        public List<Supply> SortByCategory()
        {
            var supplies = _supplyRepository.GetAll();
            var result = supplies.OrderBy(x => x.Category).ToList();
            return result;
        }

        public List<Supply> SortByExpirationDate()
        {
            var supplies = _supplyRepository.GetAll();
            var result = supplies.OrderBy(x => x.ExpirationDate).ToList();
            return result;
        }

        public List<Supply> SortByPurchaseDate()
        {
            var supplies = _supplyRepository.GetAll();
            var result = supplies.OrderBy(x => x.PurchaseDate).ToList();
            return result;
        }

        public List<Supply> SortByQuantity()
        {
            var supplies = _supplyRepository.GetAll();
            var result = supplies.OrderBy(x => x.Quantity).ToList();
            return result;
        }
    }
}
