using System;
using System.Collections.Generic;
using System.Globalization;
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
    public class SupplyUI : BaseEntityUI<Supply>
    {
        private readonly ISupplyProvider _provider;
        private readonly IRepository<Supplier> _supplierRepository;

        public SupplyUI(IRepository<Supply> baseRepository
            , IRepository<Supplier> supplierRepository
            , ISupplyProvider provider
            , IAuditWriter auditWriter) : base(baseRepository, auditWriter)
        {
            _provider = provider;
            _supplierRepository = supplierRepository;
        }

        public override List<Supply> Add()
        {
            Console.WriteLine();
            Console.WriteLine("---   Add supply   ---");
            Console.WriteLine();
            var suppliesToAdd = new List<Supply>();
            while (true)
            {
                Console.WriteLine("Enter supplier Id");
                Console.WriteLine();
                var suppliers = DisplaySuppliers(_supplierRepository);
                if (suppliers == null)
                {
                    break;
                }
                Console.WriteLine();
                var supplySupplierID = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Enter supply name");
                var supplyName = Console.ReadLine();
                Console.WriteLine("Enter supply category");
                var category = Console.ReadLine();
                Console.WriteLine("Enter quantity");
                var quantity = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Enter purchase date (DD-MM-YYYY)");
                DateTime purchaseDate;
                ParseStringToDateTime(input: Console.ReadLine(), dateTimeVariable: out purchaseDate);
                Console.WriteLine("Enter expiration date (DD-MM-YYYY)");
                DateTime expirationDate;
                ParseStringToDateTime(input: Console.ReadLine(), dateTimeVariable: out expirationDate);
                var newSupply = CreateSupply(name: supplyName
                    , category: category
                    , quantity: quantity
                    , purchaseDate: purchaseDate
                    , expirationDate: expirationDate
                    , supplierID: supplySupplierID);
                suppliesToAdd.Add(newSupply);
                Console.WriteLine();
                Console.WriteLine("1 - Add another supply");
                Console.WriteLine("q - exit");
                Console.WriteLine();
                var addSupplyChoice = Console.ReadLine();

                if (addSupplyChoice == "q")
                {
                    break;
                }
            }

            RepositoryExtensions.AddBatch(_baseRepository, suppliesToAdd);
            return suppliesToAdd;
        }

        private Supply CreateSupply(string name, string? category, int? quantity, DateTime? purchaseDate, DateTime? expirationDate, int supplierID)
        {
            var newSupply = new Supply
            {
                Name = name,
                Category = category,
                Quantity = quantity,
                PurchaseDate = purchaseDate,
                ExpirationDate = expirationDate,
                SupplierID = supplierID
            };

            return newSupply;
        }

        public override List<Supply> Delete()
        {
            Console.WriteLine();
            Console.WriteLine("---   Delete supply   ---");
            Console.WriteLine();
            var suppliesToDelete = new List<Supply>();
            while (true)
            {
                DisplaySupplies(_baseRepository);
                var supplyToDelete = ChooseEntityByID(_baseRepository);
                suppliesToDelete.Add(supplyToDelete);
                Console.WriteLine();
                Console.WriteLine("1 - Add another supply to delete list");
                Console.WriteLine("q - exit");
                Console.WriteLine();
                var addSupplierChoice = Console.ReadLine();

                if (addSupplierChoice == "q")
                {
                    break;
                }
            }

            RepositoryExtensions.DeleteBatch(_baseRepository, suppliesToDelete);
            return suppliesToDelete;
        }

        public override void Display()
        {
            Console.WriteLine();
            Console.WriteLine("---   Display supply data  ---");
            Console.WriteLine();
            while (true)
            {
                Console.WriteLine("1 - Get supply information");
                Console.WriteLine("2 - Get supplies grouped by category");
                Console.WriteLine("3 - Get supplies grouped by supplier");
                Console.WriteLine("4 - Get supplies sorted by category");
                Console.WriteLine("5 - Get supplies sorted by expiration date");
                Console.WriteLine("6 - Get supplies sorted by purchase date");
                Console.WriteLine("7 - Get supplies sorted by quantity");
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
                        DisplaySupplyInfo();
                        break;
                    case "2":
                        DisplaySuppliesGroupedByCategory();
                        break;
                    case "3":
                        DisplaySuppliesGroupedBySupplier();
                        break;
                    case "4":
                        DisplaySuppliesSortedByCategory();
                        break;
                    case "5":
                        DisplaySuppliesSortedByExpirationDate();
                        break;
                    case "6":
                        DisplaySuppliesSortedByPurchaseDate();
                        break;
                    case "7":
                        DisplaySuppliesSortedByQuantity();
                        break;
                    default:
                        break;
                }
            }
        }

        private void DisplaySuppliesSortedByQuantity()
        {
            var sortedSupplies = _provider.SortByQuantity();
            foreach (var supply in sortedSupplies)
            {
                Console.WriteLine(supply.ToString());
            }
        }

        private void DisplaySuppliesSortedByPurchaseDate()
        {
            var sortedSupplies = _provider.SortByPurchaseDate();
            foreach (var supply in sortedSupplies)
            {
                Console.WriteLine(supply.ToString());
            }
        }

        private void DisplaySuppliesSortedByExpirationDate()
        {
            var sortedSupplies = _provider.SortByExpirationDate();
            foreach (var supply in sortedSupplies)
            {
                Console.WriteLine(supply.ToString());
            }
        }

        private void DisplaySuppliesSortedByCategory()
        {
            var sortedSupplies = _provider.SortByCategory();
            foreach (var supply in sortedSupplies)
            {
                Console.WriteLine(supply.ToString());
            }
        }

        private void DisplaySuppliesGroupedBySupplier()
        {
            var groupedSupplies = _provider.GroupBySupplier();
            foreach (var group in groupedSupplies)
            {
                Console.WriteLine();
                Console.WriteLine(group.Key);
                foreach (var supply in group)
                {
                    Console.WriteLine(supply.ToString);
                }
            }
        }

        private void DisplaySuppliesGroupedByCategory()
        {
            var groupedSupplies = _provider.GroupByCategory();
            foreach (var group in groupedSupplies)
            {
                Console.WriteLine();
                Console.WriteLine(group.Key);
                foreach (var supply in group)
                {
                    Console.WriteLine(supply.ToString);
                }
            }
        }

        private void DisplaySupplyInfo()
        {
            var chosenSupply = ChooseEntityByID(_baseRepository);
            Console.WriteLine(chosenSupply.ToString());
        }

        public override void Update()
        {
            Console.WriteLine();
            Console.WriteLine("---   Update supply   ---");
            Console.WriteLine();
            while (true)
            {
                DisplaySupplies(_baseRepository);
                var chosenSupply = ChooseEntityByID(_baseRepository);
                Console.WriteLine();
                Console.WriteLine("What data do you wish to modify?");
                Console.WriteLine("1 - Name");
                Console.WriteLine("2 - Category");
                Console.WriteLine("3 - Quantity");
                Console.WriteLine("4 - Expiration date");
                Console.WriteLine("5 - Purchase date");
                Console.WriteLine("6 - Supplier ID");
                Console.WriteLine("7 - Exit");
                Console.WriteLine();

                var updateSupplyChoice = Console.ReadLine();

                if (updateSupplyChoice == "7")
                {
                    return;
                }
                else
                {
                    switch (updateSupplyChoice)
                    {
                        case "1":
                            UpdateSupplyName(chosenSupply);
                            break;
                        case "2":
                            UpdateSupplyCategory(chosenSupply);
                            break;
                        case "3":
                            UpdateSupplyQuantity(chosenSupply);
                            break;
                        case "4":
                            UpdateSupplyExpirationDate(chosenSupply);
                            break;
                        case "5":
                            UpdateSupplyPurchaseDate(chosenSupply);
                            break;
                        case "6":
                            UpdateSupplierID(chosenSupply);
                            break;
                        default:
                            break;
                    }
                    _baseRepository.Update(chosenSupply);
                }
            }
        }

        private void UpdateSupplierID(Supply chosenSupply)
        {
            Console.WriteLine("Enter new supplier ID");
            DisplaySuppliers(_supplierRepository);
            var newSupplierID = Int32.Parse(Console.ReadLine());
            chosenSupply.SupplierID = newSupplierID;
        }

        private static void UpdateSupplyPurchaseDate(Supply chosenSupply)
        {
            Console.WriteLine("Enter new purchase date");
            DateTime newSupplyPurchDate;
            ParseStringToDateTime(input: Console.ReadLine(), dateTimeVariable: out newSupplyPurchDate);
            chosenSupply.PurchaseDate = newSupplyPurchDate;
        }

        private static void UpdateSupplyExpirationDate(Supply chosenSupply)
        {
            Console.WriteLine("Enter new expiration date");
            DateTime newSupplyExpDate;
            ParseStringToDateTime(input: Console.ReadLine(), dateTimeVariable: out newSupplyExpDate);
            chosenSupply.ExpirationDate = newSupplyExpDate;
        }

        private static void UpdateSupplyQuantity(Supply chosenSupply)
        {
            Console.WriteLine("Enter new quantity");
            var newSupplyQuantity = Int32.Parse(Console.ReadLine());
            chosenSupply.Quantity = newSupplyQuantity;
        }

        private void UpdateSupplyCategory(Supply chosenSupply)
        {
            Console.WriteLine("Enter category");
            DisplaySupplyCategories();
            var supplyCategoryNumber = Int32.Parse(Console.ReadLine());
            var newSupplyCategory = Enum.GetName(typeof(SupplyCategories), supplyCategoryNumber);
            chosenSupply.Category = newSupplyCategory;
        }

        private void UpdateSupplyName(Supply chosenSupply)
        {
            Console.WriteLine("Enter new supply firm name");
            var newSupplyName = Console.ReadLine();
            chosenSupply.Name = newSupplyName;
        }

        protected override void OnEntityAdded(object? sender, Supply item)
        {
            var message = $"Supply |{item.Name}| Category: {item.Category} added by {nameof(_baseRepository)}";
            Console.WriteLine(message);
            _auditWriter.AddToAuditBatch(message);
        }

        protected override void  OnEntityRemoved(object? sender, Supply item)
        {
            var message = $"Supply |{item.Name}| Category: {item.Category} removed by {nameof(_baseRepository)}";
            Console.WriteLine(message);
            _auditWriter.AddToAuditBatch(message);
        }

        protected override void OnEntityUpdated(object? sender, Supply item)
        {
            var message = $"Supply |{item.Name}| Category: {item.Category} at ID: {item.Id} updated by {nameof(_baseRepository)}";
            Console.WriteLine(message);
            _auditWriter.AddToAuditBatch(message);
        }

    }
}
