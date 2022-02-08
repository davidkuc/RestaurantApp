using RestaurantApp.Data;
using RestaurantApp.Entities;
using RestaurantApp.Repositories;
using RestaurantApp.Repositories.Extensions;

var employeeRepository = new SqlRepository<Employee>(new RestaurantAppDbContext());
var supplierRepository = new SqlRepository<Supplier>(new RestaurantAppDbContext());
var supplyRepository = new SqlRepository<Supply>(new RestaurantAppDbContext());

#region UI
void MainMenuUI()
{
    Console.WriteLine("Hello!");
    Console.WriteLine();
    Console.WriteLine("What do you wish to do?");
    Console.WriteLine();
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

void DisplayEntityDataUI()
{
    Console.WriteLine();
    Console.WriteLine("---   Modify entity   ---");
    Console.WriteLine();
    while (true)
    {
        Console.WriteLine("Choose an entity to display");
        Console.WriteLine();
        Console.WriteLine("1 - List of employees");
        Console.WriteLine("2 - List of supplier");
        Console.WriteLine("3 - List of supplies");
        Console.WriteLine("4 - exit");
        Console.WriteLine();

        var displayEntityMenuChoice = Console.ReadLine();

        if (displayEntityMenuChoice == "4")
        {
            return;
        }
        else
        {
            switch (displayEntityMenuChoice)
            {
                case "1":
                    DisplayEmployees(employeeRepository);
                    break;
                case "2":
                    DisplaySuppliers(supplierRepository);
                    break;
                case "3":
                    DisplaySupplies(supplyRepository);
                    Console.WriteLine();
                    Console.WriteLine("1 - Choose supply");
                    Console.WriteLine("2 - exit");

                    var displaySuppliesMenuChoice = Console.ReadLine();

                    if (displaySuppliesMenuChoice == "2")
                    {
                        return;
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Enter supply Id");
                        var supplyId = Int32.Parse(Console.ReadLine());
                        var chosenSupply = supplyRepository.GetById(supplyId);
                        Console.WriteLine();
                        Console.WriteLine("Supply info");
                        Console.WriteLine($"Name: {chosenSupply.Name}");
                        Console.WriteLine($"Category: {chosenSupply.Category}");
                        Console.WriteLine($"Quantity: {chosenSupply.Quantity}");
                        Console.WriteLine($"Purchase date: {chosenSupply.PurchaseDate}");
                        Console.WriteLine($"Expiration date: {chosenSupply.ExpirationDate}");
                        Console.WriteLine($"Supplier Id: {chosenSupply.SupplierId}");
                        Console.WriteLine();

                    }
                    break;
                default:
                    break;
            }
        }
    }
}
#region ModifyEntityUI
void ModifyEntityUI()
{
    while (true)
    {
        Console.WriteLine();
        Console.WriteLine("---   Modify entity   ---");
        Console.WriteLine();
        Console.WriteLine("What entity do you wish to modify?");
        Console.WriteLine("1 - Employee");
        Console.WriteLine("2 - Supplier");
        Console.WriteLine("3 - Supply");
        Console.WriteLine("4 - exit");

        var modifyEntityMenuChoice = Console.ReadLine();

        if (modifyEntityMenuChoice == "4")
        {
            return;
        }
        else
        {
            switch (modifyEntityMenuChoice)
            {
                case "1":
                    ModifyEmployeeUI();
                    break;
                case "2":
                    ModifySupplierUI();
                    break;
                case "3":
                    ModifySupplyUI();
                    break;
                default:
                    break;
            }
        }
    }

}

void ModifySupplyUI()
{
    Console.WriteLine();
    Console.WriteLine("---   Modify supply   ---");
    Console.WriteLine();
    while (true)
    {
        Console.WriteLine("Choose supply by Id");
        Console.WriteLine();
        DisplaySupplies(supplyRepository);
        Console.WriteLine();
        var supplyId = Int32.Parse(Console.ReadLine());
        var chosenSupply = supplyRepository.GetById(supplyId);
        Console.WriteLine();
        Console.WriteLine("What data do you wish to modify?");
        Console.WriteLine("1 - Name");
        Console.WriteLine("2 - Category");
        Console.WriteLine("3 - Supplier Id");
        Console.WriteLine("4 - Purchase date");
        Console.WriteLine("5 - Expiration date");
        Console.WriteLine("6 - Quantity");
        Console.WriteLine("7 - Exit");
        Console.WriteLine();

        var modifySupplyMenuChoice = Console.ReadLine();

        if (modifySupplyMenuChoice == "7")
        {
            return;
        }
        else
        {
            switch (modifySupplyMenuChoice)
            {
                case "1":
                    Console.WriteLine("Enter new supply name name");
                    var newSupplyName = Console.ReadLine();
                    chosenSupply.Name = newSupplyName;
                    break;
                case "2":
                    Console.WriteLine("Enter new supply category");
                    var newCategory = Console.ReadLine();
                    chosenSupply.Category = newCategory;
                    break;
                case "3":
                    Console.WriteLine("Enter new supplier Id");
                    var newSupplierId = Int32.Parse(Console.ReadLine());
                    chosenSupply.SupplierId = newSupplierId;
                    break;
                case "4":
                    Console.WriteLine("Enter new purchase date");
                    var newPurchaseDate = Console.ReadLine();
                    chosenSupply.PurchaseDate = newPurchaseDate;
                    break;
                case "5":
                    Console.WriteLine("Enter new expiration date");
                    var newExpirationDate = Console.ReadLine();
                    chosenSupply.ExpirationDate = newExpirationDate;
                    break;
                case "6":
                    Console.WriteLine("Enter new quantity");
                    var newQuantity = Int32.Parse(Console.ReadLine());
                    chosenSupply.Quantity = newQuantity;
                    break;

                default:
                    break;
            }
        }
    }
    supplierRepository.Save();
}

void ModifySupplierUI()
{
    Console.WriteLine();
    Console.WriteLine("---   Modify supplier   ---");
    Console.WriteLine();
    while (true)
    {
        Console.WriteLine("Choose supplier by Id");
        Console.WriteLine();
        DisplaySuppliers(supplierRepository);
        Console.WriteLine();
        var supplierId = Int32.Parse(Console.ReadLine());
        var chosenSupplier = supplierRepository.GetById(supplierId);
        Console.WriteLine();
        Console.WriteLine("What data do you wish to modify?");
        Console.WriteLine("1 - Firm name");
        Console.WriteLine("2 - Supply category");
        Console.WriteLine("3 - Exit");
        Console.WriteLine();

        var modifySupplierMenuChoice = Console.ReadLine();

        if (modifySupplierMenuChoice == "3")
        {
            return;
        }
        else
        {
            switch (modifySupplierMenuChoice)
            {
                case "1":
                    Console.WriteLine("Enter new supplier firm name");
                    var newFirmName = Console.ReadLine();
                    chosenSupplier.Firm = newFirmName;
                    break;
                case "2":
                    Console.WriteLine("Enter new supply category");
                    var newSupplyCategory = Console.ReadLine();
                    chosenSupplier.SupplyCategory = newSupplyCategory;
                    break;
                default:
                    break;
            }
        }
    }
    supplierRepository.Save();

}

void ModifyEmployeeUI()
{
    Console.WriteLine();
    Console.WriteLine("---   Modify employee   ---");
    Console.WriteLine();
    while (true)
    {
        Console.WriteLine("Choose employee by Id");
        Console.WriteLine();
        DisplayEmployees(employeeRepository);
        Console.WriteLine();
        var chosenEmployeeId = Int32.Parse(Console.ReadLine());
        var chosenEmployee = employeeRepository.GetById(chosenEmployeeId);
        Console.WriteLine();
        Console.WriteLine("What data do you wish to modify?");
        Console.WriteLine("1 - First name");
        Console.WriteLine("2 - Last name");
        Console.WriteLine("3 - Role");
        Console.WriteLine("4 - exit");
        Console.WriteLine();

        var modifyEmployeeMenuChoice = Console.ReadLine();

        if (modifyEmployeeMenuChoice == "4")
        {
            return;
        }
        else
        {
            switch (modifyEmployeeMenuChoice)
            {
                case "1":
                    Console.WriteLine("Enter new employee first name");
                    var newFirstName = Console.ReadLine();
                    chosenEmployee.FirstName = newFirstName;
                    break;
                case "2":
                    Console.WriteLine("Enter new employee last name");
                    var newLastName = Console.ReadLine();
                    chosenEmployee.LastName = newLastName;
                    break;
                case "3":
                    Console.WriteLine("Enter new employee role");
                    var newRole = Console.ReadLine();
                    chosenEmployee.Role = newRole;
                    break;
                default:
                    break;
            }
        }
    }
    employeeRepository.Save();

}

static void DisplayEmployees(IRepository<Employee> employeeRepository)
{
    var employeeList = employeeRepository.GetAll();
    Console.WriteLine("                 Employee list                  ");
    Console.WriteLine("   Id -- First name -- Last name -- Role   ");
    foreach (var employee in employeeList)
    {
        Console.WriteLine($"   {employee.Id} -- {employee.FirstName} -- {employee.LastName} -- {employee.Role}  ");
    }
}

static void DisplaySuppliers(IRepository<Supplier> supplierRepository)
{
    var supplierList = supplierRepository.GetAll();
    Console.WriteLine("                 Supplier list                  ");
    Console.WriteLine("   Id -- Firm name -- Supply category   ");
    foreach (var supplier in supplierList)
    {
        Console.WriteLine($"   {supplier.Id} -- {supplier.Firm} -- {supplier.SupplyCategory}  ");
    }
}

static void DisplaySupplies(IRepository<Supply> supplierRepository)
{
    var supplyList = supplierRepository.GetAll();
    Console.WriteLine("                 Supply list                  ");
    Console.WriteLine("   Id -- Name -- Category -- Supplier Id   ");
    foreach (var supply in supplyList)
    {
        Console.WriteLine($"   {supply.Id} -- {supply.Name} -- {supply.Category} -- {supply.SupplierId}   ");
    }
}
#endregion

#region AddEntityUI
void AddEntityUI()
{
    Console.WriteLine();
    Console.WriteLine("---   Add entity   ---");
    Console.WriteLine();
    while (true)
    {
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

}

List<Supply> AddSupplyUI()
{
    Console.WriteLine();
    Console.WriteLine("---   Add supply   ---");
    Console.WriteLine();
    var suppliesToAdd = new List<Supply>();
    while (true)
    {
        Console.WriteLine("Enter supplier Id");
        Console.WriteLine();
        DisplaySuppliers(supplierRepository);
        Console.WriteLine();
        var supplySupplierId = Int32.Parse(Console.ReadLine());
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
            ExpirationDate = expirationDate,
            SupplierId = supplySupplierId
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
    Console.WriteLine();
    Console.WriteLine("---   Add supplier   ---");
    Console.WriteLine();
    var suppliersToAdd = new List<Supplier>();
    while (true)
    {
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
    Console.WriteLine();
    Console.WriteLine("---   Add employee   ---");
    Console.WriteLine();
    var employeesToAdd = new List<Employee>();
    while (true)
    {
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
#endregion


#endregion

