using CarList.Converters;
using Spectre.Console;

namespace CarList.Menus;

public class MainMenu
{
    public static MainMenuItem Create(string selectedListName)
    {
        return AnsiConsole.Prompt(
            CreateMainMenuPrompt(selectedListName)
        );
    }
    private static SelectionPrompt<MainMenuItem> CreateMainMenuPrompt(string listName)
    {
        var selectionPrompt = new SelectionPrompt<MainMenuItem>()
            .Title("Main menu")
            .PageSize(15)
            .MoreChoicesText("There are more items")
            .AddChoices(
                MainMenuItem.CreateNewList
            )
            .UseConverter(MainMenuItemConverter.Converter);

        if (!string.IsNullOrEmpty(listName))
        {
            selectionPrompt.AddChoices(
                MainMenuItem.ChangeCurrentList,
                MainMenuItem.ViewCurrentList,
                MainMenuItem.AddCarToCurrentList,
                MainMenuItem.EditCarInCurrentList,
                MainMenuItem.SaveData
            );
        }

        selectionPrompt.AddChoices(
            MainMenuItem.LoadData,
            MainMenuItem.Exit
        );
        return selectionPrompt;
    }
    
    
}