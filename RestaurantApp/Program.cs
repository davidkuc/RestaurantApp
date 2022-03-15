using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RestaurantApp.Data;
using RestaurantApp.Components.DataProviders;
using RestaurantApp.Components.UserCommunication;
using RestaurantApp.Components.UserInterface;
using RestaurantApp.Data.Entities;
using RestaurantApp.Data.Repositories;

var services = new ServiceCollection();
services.AddSingleton<IApplication, Application>();
services.AddSingleton<IRepository<Employee>, EmployeeRepository>();
services.AddSingleton<IRepository<Supplier>, SqlRepository<Supplier>>();
services.AddSingleton<IRepository<Supply>, SqlRepository<Supply>>();
services.AddSingleton<IRepository<Dish>, SqlRepository<Dish>>();
services.AddSingleton<IRepository<Order>, OrderRepository>();

services.AddSingleton<IEntityUI<Employee>, BaseEmployeeUI>();
services.AddSingleton<IEntityUI<Supplier>, SupplierUI>();
services.AddSingleton<IEntityUI<Supply>, SupplyUI>();
services.AddSingleton<IEntityUI<Dish>, BaseDishUI>();
services.AddSingleton<IEntityUI<Order>, OrderUI>();

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









