using CarList;
using CarList.Menus;
using CarList.Services;
using Spectre.Console;

var carLists = new Dictionary<string, List<Car>>(StringComparer.InvariantCultureIgnoreCase);
var selectedListName = "";



await ShowMainMenu();

async Task ShowMainMenu()
{
    var shouldExit = false;

    while (!shouldExit)
    {
        AnsiConsole.Clear();
        
        var selectedMenuItem = MainMenu.Create(selectedListName);

        switch (selectedMenuItem)
        {
            case MainMenuItem.CreateNewList:
                selectedListName = CreateNewList(carLists);
                InputService.WaitForAnyKeyPress();
                break;
            case MainMenuItem.ChangeCurrentList:
                selectedListName = CarListSelectionMenu.Create(carLists);
                break;
            case MainMenuItem.ViewCurrentList:
                ViewList(selectedListName, carLists);
                break;
            case MainMenuItem.AddCarToCurrentList:
                carLists[selectedListName].Add(DataCollection.CollectCarData());
                break;
            case MainMenuItem.EditCarInCurrentList:
                EditCar(carLists, selectedListName);
                break;
            case MainMenuItem.SaveData:
                SaveData(selectedListName, carLists);
                break;
            case MainMenuItem.LoadData:
                await LoadData();
                break;
            case MainMenuItem.Exit:
                shouldExit = true;
                break;
        }
    }
}

static void ViewList(string listName, Dictionary<string, List<Car>> carLists)
{
    if (!carLists.ContainsKey(listName))
    {
        AnsiConsole.WriteLine($"""No list with the name "{listName}" """);
        Console.ReadKey();
        return;
    }

    foreach (var car in carLists[listName])
    {
        AnsiConsole.WriteLine(car.ToString());
    }

    if (carLists[listName].Count == 0)
    {
        AnsiConsole.WriteLine($"""The "{listName}" list is empty""");
    }

    InputService.WaitForAnyKeyPress();
}

string CreateNewList(Dictionary<string, List<Car>> dictionary)
{
    var newListName = DataCollection.GetNewListName(dictionary);
    dictionary.Add(newListName, []);

    AnsiConsole.WriteLine("Your list has been created and selected as the current list.");
    
    return newListName;
}

void EditCar(Dictionary<string, List<Car>> dictionary, string listName)
{
    var selectedCar = CarSelectionMenu.Create(dictionary[listName]);

    if (selectedCar is { Make: Constants.NullCarMake, Model: Constants.NullCarModel })
    {
        return;
    }
    
    DataCollection.CollectCarData(selectedCar);
    InputService.WaitForAnyKeyPress();
}

void SaveData(string selectedList, Dictionary<string, List<Car>> dictionary)
{
    var filePath = AnsiConsole.Ask<string>("Enter a file path:");

    FileService.WriteDictToFile(filePath, selectedList, dictionary);
}

async Task LoadData()
{
    var filePathToRead = AnsiConsole.Ask<string>("Enter a file path:");
    var fileContent = await FileService.ReadDictFromFile(filePathToRead);

    if (fileContent is null)
    {
        AnsiConsole.MarkupLine($"[maroon]Couldn't read content from {filePathToRead}, data invalid![/]");
        InputService.WaitForAnyKeyPress();
        return;
    }
                
    carLists = fileContent.Lists;
    selectedListName = fileContent.CurrentList;
}