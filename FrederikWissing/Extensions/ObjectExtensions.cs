namespace CarList.Extensions;

public static class ObjectExtensions
{
    public static T? GetAttributeOfType<T>(this object obj) where T:Attribute
    {
        var type = obj.GetType();
        var memInfo = type.GetMember(obj.ToString() ?? string.Empty);
        var attributes = memInfo[0].GetCustomAttributes(typeof(T), false);
        
        return attributes.Length > 0 ? (T)attributes[0] : null;
    }
}