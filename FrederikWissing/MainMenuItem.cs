using CarList.Attributes;

namespace CarList;

public enum MainMenuItem
{
    [MenuItemText("Create a new list")]
    CreateNewList,
    [MenuItemText("Change current list")]
    ChangeCurrentList,
    [MenuItemText("View current list")]
    ViewCurrentList,
    [MenuItemText("Add a car to the current list")]
    AddCarToCurrentList,
    [MenuItemText("Edit car in the current list")]
    EditCarInCurrentList,
    [MenuItemText("Save data")]
    SaveData,
    [MenuItemText("Load data")]
    LoadData,
    [MenuItemText("Exit")]
    Exit
}