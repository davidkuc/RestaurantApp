using RestaurantApp.Data;
using RestaurantApp.Entities;
using RestaurantApp.Repositories;


var empRepo = new SqlRepository<Employee>(new RestaurantAppDbContext());

empRepo.Add(new Employee() { FirstName = "david" });
empRepo.Add(new Employee() { FirstName = "Brian" });
empRepo.Add(new Employee() { FirstName = "Kurt" });


GetEmployee(empRepo, 5);

static void GetEmployee(IRepository<IEntity> repository, int id)
{
    var emp = repository.GetById(id);

}