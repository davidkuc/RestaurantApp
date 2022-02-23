using Microsoft.EntityFrameworkCore;
using RestaurantApp.Entities;
using RestaurantApp.Repositories;

public class Application : IApplication
{
    private readonly IRepository<Employee> _employeeRepository;
    private readonly IRepository<Supplier> _supplierRepository;
    private readonly IRepository<Supply> _supplyRepository;
    private readonly IRepository<Order> _orderRepository;
    private readonly IRepository<Dish> _dishRepository;
    private readonly DbContext _dbContext;

    public Application(IRepository<Employee> employeeRepository,
        DbContext dbContext,
        IRepository<Supplier> supplierRepository,
        IRepository<Supply> supplyRepository,
        IRepository<Dish> dishRepository,
        IRepository<Order> orderRepository)
    {
        _employeeRepository = employeeRepository;
        _supplierRepository = supplierRepository;
        _supplyRepository = supplyRepository;
        _orderRepository = orderRepository;
        _dishRepository = dishRepository;
        _dbContext = dbContext;

    }
    public void Run()
    {
        Console.WriteLine("Im in Run() method!");
    }
}

