using System.ComponentModel;

namespace CarList.Services;

public class ConverterService
{
    public static bool CanConvertValueToType(Type type, object? value)
    {
        try
        {
            ConvertValueToType(type, value);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public static object? ConvertValueToType(Type type, object? value)
    {
        return value is null ? null : TypeDescriptor.GetConverter(type).ConvertFrom(value);
    }
}