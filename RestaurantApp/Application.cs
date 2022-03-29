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
        SeedEmployees(empRepo, context);
        SeedSuppliers(supplierRepo, context);
        SeedSupplies(seedDate, supplyRepo, context);
        SeedDishes(dishesRepo, context);
        SeedOrders(seedDate, orderRepo, context);
    }

    private void SeedDishes(DishRepository dishesRepo, RestaurantAppDbContext context)
    {
        dishesRepo.Add(new Dish
        {
            Name = "MeatBomb",
            Supplies = new List<Supply>()
        {
        context.Supplies.Find(1),
        context.Supplies.Find(2),
        context.Supplies.Find(5),
        context.Supplies.Find(9),
        },
            Price = 15.0m
        });
        dishesRepo.Add(new Dish
        {
            Name = "Ricerini",
            Supplies = new List<Supply>()
        {
        context.Supplies.Find(3),
        context.Supplies.Find(6),
        context.Supplies.Find(7),
        context.Supplies.Find(10),
        },
            Price = 12.0m
        });
        dishesRepo.Add(new Dish
        {
            Name = "SpiceBag",
            Supplies = new List<Supply>()
        {
        context.Supplies.Find(4),
        context.Supplies.Find(5),
        context.Supplies.Find(9),
        context.Supplies.Find(10),
        context.Supplies.Find(11)
        },
            Price = 11.0m
        });
        dishesRepo.Add(new Dish
        {
            Name = "OatyGoodness",
            Supplies = new List<Supply>()
        {
        context.Supplies.Find(7),
        context.Supplies.Find(8),
        context.Supplies.Find(9),
        context.Supplies.Find(10)
        },
            Price = 17.0m
        });
        dishesRepo.Add(new Dish
        {
            Name = "OhMyGroat",
            Supplies = new List<Supply>()
        {
        context.Supplies.Find(5),
        context.Supplies.Find(6),
        context.Supplies.Find(7),
        context.Supplies.Find(8),
         context.Supplies.Find(9)
        },
            Price = 20.0m
        });
        context.SaveChanges();
    }

    private void SeedOrders(string seedDate, OrderRepository orderRepo, RestaurantAppDbContext context)
    {
        orderRepo.Add(new Order
        {
            Status = OrderStatus.Uncompleted.ToString(),
            ToGo = true,
            OrderDateTime = BaseEntityUI<IEntity>.ParseStringToDateTime(seedDate),
            EmployeeId = 1,
            Dishes = new List<Dish>()
            {
                context.Dishes.Find(1),
                context.Dishes.Find(1),
                context.Dishes.Find(2),
            }
        });

        orderRepo.Add(new Order
        {
            Status = OrderStatus.Completed.ToString(),
            ToGo = false,
            OrderDateTime = BaseEntityUI<IEntity>.ParseStringToDateTime(seedDate),
            EmployeeId = 2,
            Dishes = new List<Dish>()
            {
                context.Dishes.Find(3),
                context.Dishes.Find(5),
                context.Dishes.Find(2),
            }
        });

        orderRepo.Add(new Order
        {
            Status = OrderStatus.Canceled.ToString(),
            ToGo = true,
            OrderDateTime = BaseEntityUI<IEntity>.ParseStringToDateTime(seedDate),
            EmployeeId = 2,
            Dishes = new List<Dish>()
            {
                context.Dishes.Find(3),
                context.Dishes.Find(3),
                context.Dishes.Find(2),
            }
        });

        orderRepo.Add(new Order
        {
            Status = OrderStatus.Uncompleted.ToString(),
            ToGo = false,
            OrderDateTime = BaseEntityUI<IEntity>.ParseStringToDateTime(seedDate),
            EmployeeId = null,
            Dishes = new List<Dish>()
            {
                context.Dishes.Find(1),
                context.Dishes.Find(4),
                context.Dishes.Find(2),
            }
        });

        orderRepo.Add(new Order
        {
            Status = OrderStatus.Completed.ToString(),
            ToGo = true,
            OrderDateTime = BaseEntityUI<IEntity>.ParseStringToDateTime(seedDate),
            EmployeeId = 1,
            Dishes = new List<Dish>()
            {
                context.Dishes.Find(4),
                context.Dishes.Find(2),
                context.Dishes.Find(2),
            }
        });
        context.SaveChanges();
    }

    private void SeedSupplies(string seedDate, SqlRepository<Supply> supplyRepo, RestaurantAppDbContext context)
    {
        SeedSupplies_Meat(seedDate, supplyRepo);
        SeedSupplies_Groats(seedDate, supplyRepo);
        SeedSupplies_Sanitation(seedDate, supplyRepo);
        SeedSupplies_Spices(seedDate, supplyRepo);
        context.SaveChanges();
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

    private void SeedEmployees(EmployeeRepository empRepo, RestaurantAppDbContext context)
    {
        empRepo.Add(new Employee { FirstName = "Bob", LastName = "Bobby", Role = EmployeeRole.Employee.ToString() });
        empRepo.Add(new Employee { FirstName = "Josh", LastName = "Joshy", Role = EmployeeRole.Employee.ToString() });
        empRepo.Add(new Employee { FirstName = "Meg", LastName = "Meggy", Role = EmployeeRole.Manager.ToString() });
        empRepo.Add(new Employee { FirstName = "Martha", LastName = "Marthens", Role = EmployeeRole.Cashier.ToString() });
        context.SaveChanges();
    }

    private void SeedSuppliers(SupplierRepository supplierRepo, RestaurantAppDbContext context)
    {
        supplierRepo.Add(new Supplier { Name = "Meatto", SupplyCategory = SupplyCategory.Meat.ToString() });
        supplierRepo.Add(new Supplier { Name = "Ricee", SupplyCategory = SupplyCategory.Groats.ToString() });
        supplierRepo.Add(new Supplier { Name = "Cleany", SupplyCategory = SupplyCategory.Sanitation.ToString() });
        supplierRepo.Add(new Supplier { Name = "Spicy", SupplyCategory = SupplyCategory.Spices.ToString() });
        context.SaveChanges();
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


