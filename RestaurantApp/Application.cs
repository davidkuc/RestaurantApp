using Microsoft.EntityFrameworkCore;
using RestaurantApp.Components.DataProviders;
using RestaurantApp.Components.UserCommunication;
using RestaurantApp.Components.UserInterface;
using RestaurantApp.Data.Entities;
using RestaurantApp.Data.Repositories;

public class Application : IApplication
{
    private readonly IUserInterface _userInterface;

    public Application(IUserInterface userInterface)
    {
        _userInterface = userInterface;
    }

    public void Run()
    {
        _userInterface.StartUI();
    }
}

