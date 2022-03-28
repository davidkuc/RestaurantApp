using Microsoft.EntityFrameworkCore;
using RestaurantApp.Data.Entities;
using RestaurantApp.Data.Repositories;
using RestaurantApp.Components.UI;
using RestaurantApp.Data;
using RestaurantApp.Data.Entities.Enums;
using RestaurantApp.Components.UI.EntityUI;

public class Application : IApplication
{
    private readonly IStartUI _userInterface;

    public Application(IStartUI userInterface)
    {
        _userInterface = userInterface;
    }

    public void Run()
    {
        var context = new RestaurantAppDbContext();
        if (!context.Supplies.Any())
        {
            SeedDB(context);
        }

        _userInterface.InitializeUI();

    }

    private void SeedDB(RestaurantAppDbContext context)
    {
        var seedDate = "28-03-2022";

        var empRepo = new EmployeeRepository(context);
        var supplierRepo = new SupplierRepository(context);
        var supplyRepo = new SqlRepository<Supply>(context);
        var orderRepo = new OrderRepository(context);
        var dishesRepo = new DishRepository(context);
        SeedEmployees(empRepo);
        SeedSuppliers(supplierRepo);
        SeedSupplies(seedDate, supplyRepo);
        SeedOrders(seedDate, orderRepo);
        SeedDishes(dishesRepo);

    }


    private void SeedDishes(DishRepository dishesRepo)
    {
        dishesRepo.Add(new Dish { Name = "MeatBomb" });
        dishesRepo.Add(new Dish { Name = "Ricerini" });
        dishesRepo.Add(new Dish { Name = "SpiceBag" });
        dishesRepo.Add(new Dish { Name = "OatyGoodness" });
        dishesRepo.Add(new Dish { Name = "OhMyGroat" });
    }

    private void SeedOrders(string seedDate, OrderRepository orderRepo)
    {
        orderRepo.Add(new Order
        {
            Status = OrderStatus.Uncompleted.ToString(),
            ToGo = true,
            OrderDateTime = BaseEntityUI<IEntity>.ParseStringToDateTime(seedDate),
            EmployeeId = 1
        });

        orderRepo.Add(new Order
        {
            Status = OrderStatus.Completed.ToString(),
            ToGo = false,
            OrderDateTime = BaseEntityUI<IEntity>.ParseStringToDateTime(seedDate),
            EmployeeId = 2
        });

        orderRepo.Add(new Order
        {
            Status = OrderStatus.Canceled.ToString(),
            ToGo = true,
            OrderDateTime = BaseEntityUI<IEntity>.ParseStringToDateTime(seedDate),
            EmployeeId = 2
        });

        orderRepo.Add(new Order
        {
            Status = OrderStatus.Uncompleted.ToString(),
            ToGo = false,
            OrderDateTime = BaseEntityUI<IEntity>.ParseStringToDateTime(seedDate),
            EmployeeId = null
        });

        orderRepo.Add(new Order
        {
            Status = OrderStatus.Completed.ToString(),
            ToGo = true,
            OrderDateTime = BaseEntityUI<IEntity>.ParseStringToDateTime(seedDate),
            EmployeeId = 1
        });
    }

    private void SeedSupplies(string seedDate, SqlRepository<Supply> supplyRepo)
    {
        SeedSupplies_Meat(seedDate, supplyRepo);
        SeedSupplies_Groats(seedDate, supplyRepo);
        SeedSupplies_Sanitation(seedDate, supplyRepo);
        SeedSupplies_Spices(seedDate, supplyRepo);
    }

    private void SeedSupplies_Spices(string seedDate, SqlRepository<Supply> supplyRepo)
    {
        supplyRepo.Add(new Supply
        {
            Name = "Turmeric",
            Quantity = 5,
            Category = SupplyCategory.Spices.ToString(),
            PurchaseDate = BaseEntityUI<IEntity>.ParseStringToDateTime(seedDate),
            ExpirationDate = BaseEntityUI<IEntity>.ParseStringToDateTime(seedDate),
            SupplierID = 4
        });
        supplyRepo.Add(new Supply
        {
            Name = "Paprika",
            Quantity = 5,
            Category = SupplyCategory.Spices.ToString(),
            PurchaseDate = BaseEntityUI<IEntity>.ParseStringToDateTime(seedDate),
            ExpirationDate = BaseEntityUI<IEntity>.ParseStringToDateTime(seedDate),
            SupplierID = 4
        });
        supplyRepo.Add(new Supply
        {
            Name = "Chili",
            Quantity = 5,
            Category = SupplyCategory.Spices.ToString(),
            PurchaseDate = BaseEntityUI<IEntity>.ParseStringToDateTime(seedDate),
            ExpirationDate = BaseEntityUI<IEntity>.ParseStringToDateTime(seedDate),
            SupplierID = 4
        });
        supplyRepo.Add(new Supply
        {
            Name = "Pepper",
            Quantity = 5,
            Category = SupplyCategory.Spices.ToString(),
            PurchaseDate = BaseEntityUI<IEntity>.ParseStringToDateTime(seedDate),
            ExpirationDate = BaseEntityUI<IEntity>.ParseStringToDateTime(seedDate),
            SupplierID = 4
        });
    }

    private void SeedSupplies_Sanitation(string seedDate, SqlRepository<Supply> supplyRepo)
    {
        supplyRepo.Add(new Supply
        {
            Name = "Soap",
            Quantity = 5,
            Category = SupplyCategory.Sanitation.ToString(),
            PurchaseDate = BaseEntityUI<IEntity>.ParseStringToDateTime(seedDate),
            ExpirationDate = BaseEntityUI<IEntity>.ParseStringToDateTime(seedDate),
            SupplierID = 3
        });

        supplyRepo.Add(new Supply
        {
            Name = "Brush",
            Quantity = 5,
            Category = SupplyCategory.Sanitation.ToString(),
            PurchaseDate = BaseEntityUI<IEntity>.ParseStringToDateTime(seedDate),
            ExpirationDate = BaseEntityUI<IEntity>.ParseStringToDateTime(seedDate),
            SupplierID = 3
        });

        supplyRepo.Add(new Supply
        {
            Name = "Sponge",
            Quantity = 5,
            Category = SupplyCategory.Sanitation.ToString(),
            PurchaseDate = BaseEntityUI<IEntity>.ParseStringToDateTime(seedDate),
            ExpirationDate = BaseEntityUI<IEntity>.ParseStringToDateTime(seedDate),
            SupplierID = 3
        });

        supplyRepo.Add(new Supply
        {
            Name = "Ethanol",
            Quantity = 5,
            Category = SupplyCategory.Sanitation.ToString(),
            PurchaseDate = BaseEntityUI<IEntity>.ParseStringToDateTime(seedDate),
            ExpirationDate = BaseEntityUI<IEntity>.ParseStringToDateTime(seedDate),
            SupplierID = 3
        });
    }

    private void SeedSupplies_Groats(string seedDate, SqlRepository<Supply> supplyRepo)
    {
        supplyRepo.Add(new Supply
        {
            Name = "Grains",
            Quantity = 5,
            Category = SupplyCategory.Groats.ToString(),
            PurchaseDate = BaseEntityUI<IEntity>.ParseStringToDateTime(seedDate),
            ExpirationDate = BaseEntityUI<IEntity>.ParseStringToDateTime(seedDate),
            SupplierID = 2
        });
        supplyRepo.Add(new Supply
        {
            Name = "Rice",
            Quantity = 5,
            Category = SupplyCategory.Groats.ToString(),
            PurchaseDate = BaseEntityUI<IEntity>.ParseStringToDateTime(seedDate),
            ExpirationDate = BaseEntityUI<IEntity>.ParseStringToDateTime(seedDate),
            SupplierID = 2
        });
        supplyRepo.Add(new Supply
        {
            Name = "Oats",
            Quantity = 5,
            Category = SupplyCategory.Groats.ToString(),
            PurchaseDate = BaseEntityUI<IEntity>.ParseStringToDateTime(seedDate),
            ExpirationDate = BaseEntityUI<IEntity>.ParseStringToDateTime(seedDate),
            SupplierID = 2
        });
        supplyRepo.Add(new Supply
        {
            Name = "Nuts",
            Quantity = 5,
            Category = SupplyCategory.Groats.ToString(),
            PurchaseDate = BaseEntityUI<IEntity>.ParseStringToDateTime(seedDate),
            ExpirationDate = BaseEntityUI<IEntity>.ParseStringToDateTime(seedDate),
            SupplierID = 2
        });
    }

    private void SeedEmployees(EmployeeRepository empRepo)
    {
        empRepo.Add(new Employee { FirstName = "Bob", LastName = "Bobby", Role = EmployeeRole.Employee.ToString() });
        empRepo.Add(new Employee { FirstName = "Josh", LastName = "Joshy", Role = EmployeeRole.Employee.ToString() });
        empRepo.Add(new Employee { FirstName = "Meg", LastName = "Meggy", Role = EmployeeRole.Manager.ToString() });
        empRepo.Add(new Employee { FirstName = "Martha", LastName = "Marthens", Role = EmployeeRole.Cashier.ToString() });
    }

    private void SeedSuppliers(SupplierRepository supplierRepo)
    {
        supplierRepo.Add(new Supplier { Name = "Meatto", SupplyCategory = SupplyCategory.Meat.ToString() });
        supplierRepo.Add(new Supplier { Name = "Ricee", SupplyCategory = SupplyCategory.Groats.ToString() });
        supplierRepo.Add(new Supplier { Name = "Cleany", SupplyCategory = SupplyCategory.Sanitation.ToString() });
        supplierRepo.Add(new Supplier { Name = "Spicy", SupplyCategory = SupplyCategory.Spices.ToString() });
    }

    private void SeedSupplies_Meat(string seedDate, SqlRepository<Supply> supplyRepo)
    {
        supplyRepo.Add(new Supply
        {
            Name = "Pork",
            Quantity = 5,
            Category = SupplyCategory.Meat.ToString(),
            PurchaseDate = BaseEntityUI<IEntity>.ParseStringToDateTime(seedDate),
            ExpirationDate = BaseEntityUI<IEntity>.ParseStringToDateTime(seedDate),
            SupplierID = 1
        });

        supplyRepo.Add(new Supply
        {
            Name = "Chicken",
            Quantity = 5,
            Category = SupplyCategory.Meat.ToString(),
            PurchaseDate = BaseEntityUI<IEntity>.ParseStringToDateTime(seedDate),
            ExpirationDate = BaseEntityUI<IEntity>.ParseStringToDateTime(seedDate),
            SupplierID = 1
        });

        supplyRepo.Add(new Supply
        {
            Name = "Beef",
            Quantity = 5,
            Category = SupplyCategory.Meat.ToString(),
            PurchaseDate = BaseEntityUI<IEntity>.ParseStringToDateTime(seedDate),
            ExpirationDate = BaseEntityUI<IEntity>.ParseStringToDateTime(seedDate),
            SupplierID = 1
        });

        supplyRepo.Add(new Supply
        {
            Name = "Fish",
            Quantity = 5,
            Category = SupplyCategory.Meat.ToString(),
            PurchaseDate = BaseEntityUI<IEntity>.ParseStringToDateTime(seedDate),
            ExpirationDate = BaseEntityUI<IEntity>.ParseStringToDateTime(seedDate),
            SupplierID = 1
        });
    }
}


