using CarList.Converters;
using Spectre.Console;

namespace CarList.Menus;

public class CarSelectionMenu
{
    public static Car Create(List<Car> carList)
    {
        var selectionPrompt = new SelectionPrompt<Car>()
            .Title("Select a list of cars")
            .PageSize(15)
            .MoreChoicesText("There are more items")
            .UseConverter(CarConverter.Converter);

        foreach (var car in carList)
        {
            selectionPrompt.AddChoice(car);
        }

        selectionPrompt.AddChoice(new Car{Make = Constants.NullCarMake, Model = Constants.NullCarModel});

        Car selectedCar = AnsiConsole.Prompt(selectionPrompt);

        return selectedCar;
    }
}