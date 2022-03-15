using Microsoft.EntityFrameworkCore;
using RestaurantApp.Data.Entities;
using RestaurantApp.Data.Repositories;
using RestaurantApp.Components.UI;

public class Application : IApplication
{
    private readonly IStartUI _userInterface;

    public Application(IStartUI userInterface)
    {
        _userInterface = userInterface;
    }

    public void Run()
    {
        _userInterface.InitializeUI();
    }
}

