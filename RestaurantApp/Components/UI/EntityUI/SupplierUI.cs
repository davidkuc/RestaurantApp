using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantApp.Components.DataProviders;
using RestaurantApp.Data.Entities.Enums;
using RestaurantApp.Data.Entities;
using RestaurantApp.Data.Repositories;
using RestaurantApp.Components.UI.EntityUI;
using RestaurantApp.Data.Repositories.RepositoryExtensions;
using RestaurantApp.Components.Audit;

namespace RestaurantApp.Components.UI.EntityUI
{
    public class SupplierUI : BaseEntityUI<Supplier>
    {
        private readonly ISupplierProvider _provider;

        public SupplierUI(IRepository<Supplier> baseRepository
            , ISupplierProvider provider
            , IAuditWriter auditWriter) : base(baseRepository, auditWriter)
        {
            _provider = provider;
        }

        public override List<Supplier> Add()
        {
            Console.WriteLine();
            Console.WriteLine("---   Add supplier   ---");
            Console.WriteLine();
            var suppliersToAdd = new List<Supplier>();
            while (true)
            {
                Console.WriteLine("Enter firm name");
                var firmName = Console.ReadLine();
                Console.WriteLine("Enter supply category ID");
                DisplaySupplyCategories();
                var supplyCategory = ValidateSupplyCategory(Console.ReadLine());
                var newSupplier = CreateSupplier(firmName: firmName, supplyCategory: supplyCategory);
                suppliersToAdd.Add(newSupplier);
                Console.WriteLine();
                Console.WriteLine("1 - Add another supplier");
                Console.WriteLine("q - exit");
                Console.WriteLine();
                var addSupplierChoice = Console.ReadLine();

                if (addSupplierChoice == "q")
                {
                    break;
                }
            }

            RepositoryExtensions.AddBatch(_baseRepository, suppliersToAdd);
            return suppliersToAdd;
        }    

        private Supplier CreateSupplier(string firmName, string supplyCategory)
        {
            var newSupplier = new Supplier
            {
                Name = firmName,
                SupplyCategory = supplyCategory,
            };

            return newSupplier;
        }

        public override List<Supplier> Delete()
        {
            Console.WriteLine();
            Console.WriteLine("---   Delete supplier   ---");
            Console.WriteLine();
            var suppliersToDelete = new List<Supplier>();
            while (true)
            {
                DisplaySuppliers(_baseRepository);
                var supplierToDeleteId = CheckIfEntityExistsByID(_baseRepository);
                var supplierToDelete = _baseRepository.GetById(supplierToDeleteId);
                suppliersToDelete.Add(supplierToDelete);
                Console.WriteLine();
                Console.WriteLine("1 - Add another supplier to delete list");
                Console.WriteLine("q - exit");
                Console.WriteLine();
                var addSupplierChoice = Console.ReadLine();

                if (addSupplierChoice == "q")
                {
                    break;
                }
            }

            RepositoryExtensions.DeleteBatch(_baseRepository, suppliersToDelete);
            return suppliersToDelete;
        }

        public override void Display()
        {
            Console.WriteLine();
            Console.WriteLine("---   Display supplier data  ---");
            Console.WriteLine();
            while (true)
            {
                Console.WriteLine("1 - Get supplier information");
                Console.WriteLine("2 - Get supplies from chosen supplier");
                Console.WriteLine("3 - Get suppliers grouped by category");
                Console.WriteLine("4 - Get suppliers sorted by category");
                Console.WriteLine("q - Exit");
                Console.WriteLine();
                var displayChoice = Console.ReadLine();

                if (displayChoice == "q")
                {
                    return;
                }

                switch (displayChoice)
                {
                    case "1":
                        DisplaySupplierInfo();
                        break;
                    case "2":
                        DisplaySuppliesFromChosenSupplier();
                        break;
                    case "3":
                        DisplaySuppliersGroupedByCategory();
                        break;
                    case "4":
                        DisplaySuppliersSortedByCategory();
                        break;
                    default:
                        break;
                }
            }
        }

        private void DisplaySuppliersSortedByCategory()
        {
            var sortedSuppliers = _provider.SortByCategory();
            foreach (var supplier in sortedSuppliers)
            {
                Console.WriteLine(supplier.ToString());
            }
        }

        private void DisplaySuppliersGroupedByCategory()
        {
            var groupedSuppliers = _provider.GroupByCategory();
            foreach (var group in groupedSuppliers)
            {
                Console.WriteLine();
                Console.WriteLine(group.Key);
                foreach (var supplier in group)
                {
                    Console.WriteLine(supplier.ToString());
                }
            }
        }

        private void DisplaySuppliesFromChosenSupplier()
        {
            Console.WriteLine("Enter supply Id");
            var supplyID = int.Parse(Console.ReadLine());
            var supplierSupplies = _provider.GetSupplies(supplyID);
            foreach (var item in supplierSupplies)
            {
                Console.WriteLine(item.ToString());
            }
        }

        private void DisplaySupplierInfo()
        {
            var chosenSupplierId = CheckIfEntityExistsByID(_baseRepository);
            var chosenSupplier = _baseRepository.GetById(chosenSupplierId);
            Console.WriteLine(chosenSupplier.ToString());
        }

        public override void Update()
        {
            Console.WriteLine();
            Console.WriteLine("---   Update supplier   ---");
            Console.WriteLine();
            while (true)
            {
                DisplaySuppliers(_baseRepository);
                var chosenSupplierId = CheckIfEntityExistsByID(_baseRepository);
                var chosenSupplier = _baseRepository.GetById(chosenSupplierId);
                Console.WriteLine();
                Console.WriteLine("What data do you wish to modify?");
                Console.WriteLine("1 - Firm name");
                Console.WriteLine("2 - Supply category");
                Console.WriteLine("q - Exit");
                Console.WriteLine();

                var modifySupplierMenuChoice = Console.ReadLine();

                if (modifySupplierMenuChoice == "q")
                {
                    return;
                }
                else
                {
                    switch (modifySupplierMenuChoice)
                    {
                        case "1":
                            UpdateSupplierFirmName(chosenSupplier);
                            break;
                        case "2":
                            UpdateSupplyCategory(chosenSupplier);
                            break;
                        default:
                            break;
                    }
                    _baseRepository.Update(chosenSupplier);
                }
            }
        }

        private void UpdateSupplyCategory(Supplier chosenSupplier)
        {
            Console.WriteLine("Enter supply category ID");
            DisplaySupplyCategories();
            var supplyCategoryNumber = int.Parse(Console.ReadLine());
            var newSupplyCategory = Enum.GetName(typeof(SupplyCategory), supplyCategoryNumber);
            chosenSupplier.SupplyCategory = newSupplyCategory;
        }

        private void UpdateSupplierFirmName(Supplier chosenSupplier)
        {
            Console.WriteLine("Enter new supplier firm name");
            var newFirmName = Console.ReadLine();
            chosenSupplier.Name = newFirmName;
        }

        protected override void OnEntityAdded(object? sender, Supplier item)
        {
            var message = $"Supplier {item.Name} added by {nameof(_baseRepository)}";
            Console.WriteLine(message);
            _auditWriter.AddToAuditBatch(message);
        }

        protected override void OnEntityRemoved(object? sender, Supplier item)
        {
            var message = $"Supplier {item.Name} removed by {nameof(_baseRepository)}";
            Console.WriteLine(message);
            _auditWriter.AddToAuditBatch(message);
        }

        protected override void OnEntityUpdated(object? sender, Supplier item)
        {
            var message = $"Supplier {item.Name} at ID: {item.Id} updated by {nameof(_baseRepository)}";
            Console.WriteLine(message);
            _auditWriter.AddToAuditBatch(message);
        }
    }
}
