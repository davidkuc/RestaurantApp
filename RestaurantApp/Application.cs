using Microsoft.EntityFrameworkCore;
using RestaurantApp.DataProviders;
using RestaurantApp.Entities;
using RestaurantApp.Repositories;
using RestaurantApp.UserCommunication;
using RestaurantApp.UserInterface;

public class Application : IApplication
{
    private readonly IRepository<Employee> _employeeRepository;
    private readonly IRepository<Supplier> _supplierRepository;
    private readonly IRepository<Supply> _supplyRepository;
    private readonly IRepository<Order> _orderRepository;
    private readonly IRepository<Dish> _dishRepository;
    private readonly IEntityComm<Employee> _employeeComm;
    private readonly IEntityComm<Supplier> _supplierComm;
    private readonly IEntityComm<Supply> _supplyComm;
    private readonly IEntityComm<Dish> _dishComm;
    private readonly IEntityComm<Order> _orderComm;
    private readonly IEmployeeProvider _employeeProvider;
    private readonly ISupplierProvider _supplierProvider;
    private readonly ISupplyProvider _supplyProvider;
    private readonly IDishProvider _dishProvider;
    private readonly IOrderProvider _orderProvider;
    private readonly IUserInterface _userInterface;
    private readonly DbContext _dbContext;

    public Application(IRepository<Employee> employeeRepository
        , IRepository<Supplier> supplierRepository
        , IRepository<Supply> supplyRepository
        , IRepository<Dish> dishRepository
        , IRepository<Order> orderRepository
        , IEntityComm<Employee> employeeComm
        , IEntityComm<Supplier> supplierComm
        , IEntityComm<Supply> supplyComm
        , IEntityComm<Dish> dishComm
        , IEntityComm<Order> orderComm
        , IUserInterface userInterface
        , IEmployeeProvider employeeProvider
        , ISupplierProvider supplierProvider
        , ISupplyProvider supplyProvider
        , IDishProvider dishProvider
        , IOrderProvider orderProvider
        , DbContext dbContext)
    {
        _employeeRepository = employeeRepository;
        _supplierRepository = supplierRepository;
        _supplyRepository = supplyRepository;
        _orderRepository = orderRepository;
        _dishRepository = dishRepository;
        _employeeComm = employeeComm;
        _supplierComm = supplierComm;
        _supplyComm = supplyComm;
        _dishComm = dishComm;
        _orderComm = orderComm;
        _employeeProvider = employeeProvider;
        _supplierProvider = supplierProvider;
        _supplyProvider = supplyProvider;
        _dishProvider = dishProvider;
        _orderProvider = orderProvider;
        _userInterface = userInterface;
        _dbContext = dbContext;
    }
    public void Run()
    {
        _userInterface.StartUI();
    }
}

