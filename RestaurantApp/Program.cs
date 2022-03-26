using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RestaurantApp.Data;
using RestaurantApp.Components.DataProviders;
using RestaurantApp.Data.Entities;
using RestaurantApp.Data.Repositories;
using RestaurantApp.Components.UI.EntityUI;
using RestaurantApp.Components.UI;
using System.Configuration;
using RestaurantApp.Components.Audit;

var services = new ServiceCollection();
services.AddSingleton<IApplication, Application>();
services.AddSingleton<IRepository<Employee>, EmployeeRepository>();
services.AddSingleton<IRepository<Supplier>, SqlRepository<Supplier>>();
services.AddSingleton<IRepository<Supply>, SqlRepository<Supply>>();
services.AddSingleton<IRepository<Dish>, SqlRepository<Dish>>();
services.AddSingleton<IRepository<Order>, OrderRepository>();

services.AddSingleton<IEntityUI<Employee>, EmployeeUI>();
services.AddSingleton<IEntityUI<Supplier>, SupplierUI>();
services.AddSingleton<IEntityUI<Supply>, SupplyUI>();
services.AddSingleton<IEntityUI<Dish>, DishUI>();
services.AddSingleton<IEntityUI<Order>, OrderUI>();

services.AddSingleton<IEmployeeProvider, EmployeeProvider>();
services.AddSingleton<ISupplierProvider, SupplierProvider>();
services.AddSingleton<ISupplyProvider, SupplyProvider>();
services.AddSingleton<IDishProvider, DishProvider>();
services.AddSingleton<IOrderProvider, OrderProvider>();

services.AddSingleton<IStartUI, StartUI>();
services.AddDbContext<DbContext, RestaurantAppDbContext>();

services.AddSingleton<IAuditWriter, AuditWriter>();

var serviceProvider = services.BuildServiceProvider();
var app = serviceProvider.GetService<IApplication>()!;
app.Run();









