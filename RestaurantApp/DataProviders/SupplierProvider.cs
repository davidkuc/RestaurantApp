using RestaurantApp.Entities;
using RestaurantApp.Repositories;

namespace RestaurantApp.DataProviders
{
    public class SupplierProvider : ISupplierProvider
    {
        private readonly IRepository<Order> _supplierRepository;

        public SupplierProvider(IRepository<Order> supplierRepository)
        {
            _supplierRepository = supplierRepository;

        }
        public string GetSupplierInfo(int id)
        {
            var supplier = _supplierRepository.GetById(id);
            return supplier.ToString();
        }

        public List<Supply>? GetSupplies(int id)
        {
            var suppliers = _supplierRepository.GetAll();
            return suppliers.SingleOrDefault(p => p.Id == id)
                .Supplies.ToList();
        }

        public List<IGrouping<SupplyCategories?,Order>> GroupByCategory()
        {
            var suppliers = _supplierRepository.GetAll();
            var result = suppliers.GroupBy(x => x.SupplyCategory).ToList();
            return result;
        }

        public List<Order> SortByCategory()
        {
            var suppliers = _supplierRepository.GetAll();
            var result = suppliers.OrderBy(x => x.SupplyCategory).ToList();
            return result;
        }   
    }
}
