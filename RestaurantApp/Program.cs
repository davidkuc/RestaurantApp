using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RestaurantApp.Audit;
using RestaurantApp.Const;
using RestaurantApp.Data;
using RestaurantApp.DataProviders;
using RestaurantApp.Entities;
using RestaurantApp.Repositories;
using RestaurantApp.Repositories.Extensions;
using RestaurantApp.UserCommunication;
using RestaurantApp.UserInterface;

var services = new ServiceCollection();
services.AddSingleton<IApplication, Application>();
services.AddSingleton<IRepository<Employee>, EmployeeRepository>();
services.AddSingleton<IRepository<Supplier>, SqlRepository<Supplier>>();
services.AddSingleton<IRepository<Supply>, SqlRepository<Supply>>();
services.AddSingleton<IRepository<Dish>, SqlRepository<Dish>>();
services.AddSingleton<IRepository<Order>, OrderRepository>();

services.AddSingleton<IEntityComm<Employee>, EmployeeComm>();
services.AddSingleton<IEntityComm<Supplier>, SupplierComm>();
services.AddSingleton<IEntityComm<Supply>, SupplyComm>();
services.AddSingleton<IEntityComm<Dish>, DishComm>();
services.AddSingleton<IEntityComm<Order>, OrderComm>();

services.AddSingleton<IEmployeeProvider, EmployeeProvider>();
services.AddSingleton<ISupplierProvider, SupplierProvider>();
services.AddSingleton<ISupplyProvider, SupplyProvider>();
services.AddSingleton<IDishProvider, DishProvider>();
services.AddSingleton<IOrderProvider, OrderProvider>();

services.AddSingleton<IUserInterface, UserInterface>();
services.AddDbContext<DbContext, RestaurantAppDbContext>();


var serviceProvider = services.BuildServiceProvider();
var app = serviceProvider.GetService<IApplication>()!;
app.Run();









