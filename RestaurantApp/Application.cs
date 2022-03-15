using Microsoft.EntityFrameworkCore;
using RestaurantApp.Components.UserInterface;
using RestaurantApp.Data.Entities;
using RestaurantApp.Data.Repositories;

public class Application : IApplication
{
    private readonly IRepository<Employee> _employeeRepository;
    private readonly IRepository<Supplier> _supplierRepository;
    private readonly IRepository<Supply> _supplyRepository;
    private readonly IRepository<Order> _orderRepository;
    private readonly IRepository<Dish> _dishRepository;
    private readonly DbContext _dbContext;
    private readonly IStartUI _userInterface;

    public Application(IRepository<Employee> employeeRepository,
        DbContext dbContext,
        IRepository<Supplier> supplierRepository,
        IRepository<Supply> supplyRepository,
        IRepository<Dish> dishRepository,
        IRepository<Order> orderRepository,
        IStartUI userInterface)
    {
        _employeeRepository = employeeRepository;
        _supplierRepository = supplierRepository;
        _supplyRepository = supplyRepository;
        _orderRepository = orderRepository;
        _dishRepository = dishRepository;
        _dbContext = dbContext;
        _userInterface = userInterface;

    }

    public void Run()
    {
        _userInterface.InitializeUI();
    }
}

