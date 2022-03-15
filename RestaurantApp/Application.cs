using Microsoft.EntityFrameworkCore;
using RestaurantApp.Components.UserInterface;
using RestaurantApp.Data.Entities;
using RestaurantApp.Data.Repositories;

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

