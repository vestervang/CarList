using CarList.Models;

namespace CarList.Converters;

public static class EnumMenuItemConverter
{
    public static readonly Func<EnumMenuItem, string> Converter = menuItem => menuItem.Label ?? "No label exists";
}