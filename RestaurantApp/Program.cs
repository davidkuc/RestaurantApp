using Microsoft.Extensions.DependencyInjection;
using RestaurantApp.Audit;
using RestaurantApp.Const;
using RestaurantApp.Data;
using RestaurantApp.Entities;
using RestaurantApp.Repositories;
using RestaurantApp.Repositories.Extensions;


var services = new ServiceCollection();
services.AddSingleton<IApplication, Application>();
services.AddSingleton<IRepository<Employee>, SqlRepository<Employee>>();
//services.AddSingleton<IRepository<Supplier>, SqlRepository<Supplier>>();
//services.AddSingleton<IRepository<Supply>, SqlRepository<Supply>>();

var serviceProvider = services.BuildServiceProvider();
var app = serviceProvider.GetService<IApplication>()!;
app.Run();









