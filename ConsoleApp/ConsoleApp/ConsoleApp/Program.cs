using ConsoleApp.Core;
using ConsoleApp.Core.Models;
using ConsoleApp.Core.Models.Enums;
using ConsoleApp.UI;

CarListService carListService = new CarListService();

Console.WriteLine("Welcome to THE Car List Application(CLA)");
while (true)
{
    MainMenu.Show();
    var mainMenuChoice = MainMenu.ReadMainMenuChoice();
    while (mainMenuChoice == 0)
    {
        Console.WriteLine("Invalid choice, try again");
        mainMenuChoice = MainMenu.ReadMainMenuChoice();
    }

    switch (mainMenuChoice)
    {
        case 1:
            MainMenu.ShowCarList(carListService.Cars);
            break;
        case 2:
            var car = MainMenu.AddNewCar();
            carListService.CreateCar(car);
            MainMenu.CarAdded();
            break;
        case 3:
            break;
    }
}
