using Spectre.Console;

namespace CarList.Menus;

public class CarListSelectionMenu
{
    public static string Create(Dictionary<string, List<Car>> carLists)
    {
        var selectionPrompt = new SelectionPrompt<string>()
            .Title("Select a list of cars")
            .PageSize(15)
            .MoreChoicesText("There are more items");

        foreach (var carList in carLists)
        {
            selectionPrompt.AddChoice(carList.Key);
        }

        var selectedMenuItem = AnsiConsole.Prompt(selectionPrompt);

        return selectedMenuItem;
    }
}