using Microsoft.EntityFrameworkCore;
using RestaurantApp.Components.CsvReader;
using RestaurantApp.Components.DataProviders;
using RestaurantApp.Components.UserCommunication;
using RestaurantApp.Components.UserInterface;
using RestaurantApp.Data.Entities;
using RestaurantApp.Data.Repositories;
using System.Xml.Linq;

public class Application : IApplication
{
    private readonly IUserInterface _userInterface;
    private readonly ICsvReader _csvReader;

    public Application(IUserInterface userInterface
        , ICsvReader csvReader)
    {
        _userInterface = userInterface;
        _csvReader = csvReader;
    }

    public void Run()
    {
        var CarsList = _csvReader.ProcessCars("Resources\\Files\\fuel.csv");
        var ManufacturersList = _csvReader.ProcessManufacturers("Resources\\Files\\manufacturers.csv");

        var document = XDocument.Load("fuel.xml");
        var cars = document.Element("Cars")
            .Elements("Car")
            .Where(x => int.Parse(x.Attribute("Combined").Value) > 30)
            .Select(x => x.Attribute("Name").Value);

        foreach (var car in cars)
        {
            Console.WriteLine(car);
        }

        //_userInterface.StartUI();
    }
}

