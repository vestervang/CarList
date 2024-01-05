using CarList.Attributes;
using CarList.Extensions;

namespace CarList.Converters;

public static class MainMenuItemConverter
{
    public static readonly Func<MainMenuItem, string> Converter = menuItem =>
    {
        var textToShow = menuItem.GetAttributeOfType<MenuItemTextAttribute>();

        return textToShow?.Text ?? "No text available for this menu item";
    };
}