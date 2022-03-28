using RestaurantApp.Components.DataProviders;
using RestaurantApp.Data.Entities.Enums;
using RestaurantApp.Data.Entities;
using RestaurantApp.Data.Repositories;
using RestaurantApp.Components.DataProviders.Models;

namespace RestaurantApp.Components.DataProviders
{
    public class SupplyProvider : ISupplyProvider
    {
        private readonly IRepository<Supply> _supplyRepository;
        private readonly IRepository<Supplier> _supplierRepository;

        public SupplyProvider(IRepository<Supply> supplyRepository
            , IRepository<Supplier> supplierRepository)
        {
            _supplyRepository = supplyRepository;
            _supplierRepository = supplierRepository;
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
                .GroupBy(x => x.Category)
                .ToList();
        }

        public List<GroupedSupplies> GroupBySupplier()
        {
            return _supplierRepository.GetAll()
                .GroupJoin(_supplyRepository.GetAll(),
                supplier => supplier.Id,
                supply => supply.SupplierID,
                (supplier, supply) => new GroupedSupplies()
                {
                    SupplierName = supplier.Name,
                    Supplies = supply
                })
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
