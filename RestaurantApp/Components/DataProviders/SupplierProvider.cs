using RestaurantApp.Components.DataProviders;
using RestaurantApp.Data.Entities;
using RestaurantApp.Data.Repositories;

namespace RestaurantApp.Components.DataProviders
{
    public class SupplierProvider : ISupplierProvider
    {
        private readonly IRepository<Supplier> _supplierRepository;

        public SupplierProvider(IRepository<Supplier> supplierRepository)
        {
            _supplierRepository = supplierRepository;

        }

        public List<Supply>? GetSupplies(int id)
        {
            return _supplierRepository.GetAll()?
                .SingleOrDefault(p => p.Id == id)
                .Supplies?.ToList();
        }

        public List<IGrouping<string?, Supplier>> GroupByCategory()
        {
            return _supplierRepository.GetAll()
                 .GroupBy(x => x.SupplyCategory)
                 .ToList();
        }

        public List<Supplier> SortByCategory()
        {
            return _supplierRepository.GetAll()
                    .OrderBy(x => x.SupplyCategory)
                    .ToList();
        }
    }
}
