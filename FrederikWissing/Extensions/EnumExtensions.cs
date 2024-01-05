using System.Runtime.Serialization;

namespace CarList.Extensions;

public static class EnumExtensions
{
    public static T? GetAttributeOfType<T>(this Enum enumVal) where T:Attribute
    {
        var type = enumVal.GetType();
        var memInfo = type.GetMember(enumVal.ToString());
        var attributes = memInfo[0].GetCustomAttributes(typeof(T), false);
        
        return (attributes.Length > 0) ? (T)attributes[0] : null;
    }

    public static string? GetEnumValue(this Enum enumVal)
    {
        var attribute = enumVal.GetAttributeOfType<EnumMemberAttribute>();

        return attribute?.Value;
    }
}