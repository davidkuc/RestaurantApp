using Microsoft.EntityFrameworkCore;
using RestaurantApp.Data.Entities;
using RestaurantApp.Data.Repositories;
using RestaurantApp.Components.UI;
using RestaurantApp.Data;
using RestaurantApp.Data.Entities.Enums;

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
        var empRepo = new EmployeeRepository(context);
        var supplierRepo = new SupplierRepository(context);
        var supplyRepo = new SqlRepository<Supply>(context);
        var orderRepo = new OrderRepository(context);
        var dishesRepo = new DishRepository(context);

        empRepo.Add(new Employee { FirstName = "Bob", LastName = "Bobby", Role = EmployeeRoles.Employee });
        empRepo.Add(new Employee { FirstName = "Josh", LastName = "Joshy", Role = "Employee" });
        empRepo.Add(new Employee { FirstName = "Meg", LastName = "Meggy", Role = "Manager" });
        empRepo.Add(new Employee { FirstName = "Martha", LastName = "Marthens", Role = "Employee" });

        supplierRepo.Add(new Supplier { Name = "Binco", SupplyCategory = })
    }
}


