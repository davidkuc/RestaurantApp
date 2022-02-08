using RestaurantApp.Data;
using RestaurantApp.Entities;
using RestaurantApp.Repositories;
using RestaurantApp.Repositories.Extensions;

var employeeRepository = new SqlRepository<Employee>(new RestaurantAppDbContext());
var supplierRepository = new SqlRepository<Supplier>(new RestaurantAppDbContext());
var supplyRepository = new SqlRepository<Supply>(new RestaurantAppDbContext());



void MainMenuUI()
{
    Console.WriteLine("Hello!");
    Console.WriteLine("What do you wish to do?");
    Console.WriteLine("1 - Add entity");
    Console.WriteLine("2 - Modify entity data");
    Console.WriteLine("3 - Display entity data");
    Console.WriteLine("4 - exit");

    var mainMenuChoice = Console.ReadLine();

    if (mainMenuChoice == "4")
    {
        return;
    }
    else
    {
        switch (mainMenuChoice)
        {
            case "1":
                AddEntityUI();
                break;
            case "2":
                ModifyEntityUI();
                break;
            case "3":
                DisplayEntityDataUI();
                break;
            default:
                break;
        }
    }

}

void AddEntityUI()
{
    Console.WriteLine();
    Console.WriteLine("---   Add entity   ---");
    Console.WriteLine();
    Console.WriteLine("Which entity do you wish to add?");
    Console.WriteLine("1 - Employee");
    Console.WriteLine("2 - Supplier");
    Console.WriteLine("3 - Supply");
    Console.WriteLine("4 - exit");
    Console.WriteLine();

    var addEntityMenuChoice = Console.ReadLine();

    if (addEntityMenuChoice == "4")
    {
        return;
    }
    else
    {
        switch (addEntityMenuChoice)
        {
            case "1":
               var employeesBatch = AddEmployeeUI();
                employeeRepository.AddBatch<Employee>(employeesBatch.ToArray());
                break;
            case "2":
                var suppliersBatch = AddSupplierUI();
                supplierRepository.AddBatch<Supplier>(suppliersBatch.ToArray());
                break;
            case "3":
                var suppliesBatch = AddSupplyUI();
                supplyRepository.AddBatch<Supply>(suppliesBatch.ToArray());
                break;
            default:
                break;
        }
    }
}

List<Supply> AddSupplyUI()
{
    var suppliesToAdd = new List<Supply>();
    while (true)
    {
        Console.WriteLine();
        Console.WriteLine("---   Add supply   ---");
        Console.WriteLine();
        Console.WriteLine("Enter supply name");
        var supplyName = Console.ReadLine();
        Console.WriteLine("Enter supply category");
        var category = Console.ReadLine();
        Console.WriteLine("Enter quantity");
        var quantity = Int32.Parse(Console.ReadLine());
        Console.WriteLine("Enter purchase date (DD/MM/YYYY)");
        var purchaseDate = Console.ReadLine();
        Console.WriteLine("Enter expiration date (DD/MM/YYYY)");
        var expirationDate = Console.ReadLine();       
        var newSupply = new Supply
        {
            Name = supplyName,
            Category = category,
            Quantity = quantity,
            PurchaseDate = purchaseDate,
            ExpirationDate = expirationDate
        };
        suppliesToAdd.Add(newSupply);
        Console.WriteLine();
        Console.WriteLine("1 - Add another supplier");
        Console.WriteLine("2 - exit");
        Console.WriteLine();
        var addEmployeeChoice = Console.ReadLine();

        if (addEmployeeChoice == "2")
        {
            break;
        }
        else if (addEmployeeChoice == "1")
        {
            continue;
        }
    }
    return suppliesToAdd;
}

List<Supplier> AddSupplierUI()
{
    var suppliersToAdd = new List<Supplier>();
    while (true)
    {
        Console.WriteLine();
        Console.WriteLine("---   Add supplier   ---");
        Console.WriteLine();
        Console.WriteLine("Enter firm name");
        var firmName = Console.ReadLine();
        Console.WriteLine("Enter supply category");
        var supplyCategory = Console.ReadLine();
        Console.WriteLine("Enter role");
        var role = Console.ReadLine();
        var newSupplier = new Supplier
        {
            Firm = firmName,
            SupplyCategory = supplyCategory,          
        };
       suppliersToAdd.Add(newSupplier);
        Console.WriteLine();
        Console.WriteLine("1 - Add another supplier");
        Console.WriteLine("2 - exit");
        Console.WriteLine();
        var addEmployeeChoice = Console.ReadLine();

        if (addEmployeeChoice == "2")
        {
            break;
        }
        else if (addEmployeeChoice == "1")
        {
            continue;
        }
    }
    return suppliersToAdd;
}

List<Employee> AddEmployeeUI()
{
    var employeesToAdd = new List<Employee>();
    while (true)
    {
        Console.WriteLine();
        Console.WriteLine("---   Add employee   ---");
        Console.WriteLine();
        Console.WriteLine("Enter first name");
        var firstName = Console.ReadLine();
        Console.WriteLine("Enter last name");
        var lastName = Console.ReadLine();
        Console.WriteLine("Enter role");
        var role = Console.ReadLine();
        var newEmployee = new Employee
        {
            FirstName = firstName,
            LastName = lastName,
            Role = role
        };
        employeesToAdd.Add(newEmployee);
        Console.WriteLine();
        Console.WriteLine("1 - Add another employee");
        Console.WriteLine("2 - exit");
        Console.WriteLine();
        var addEmployeeChoice = Console.ReadLine();

        if (addEmployeeChoice == "2")
        {
            break;
        }
        else if (addEmployeeChoice == "1")
        {
            continue;
        }
    }
    return employeesToAdd;
}