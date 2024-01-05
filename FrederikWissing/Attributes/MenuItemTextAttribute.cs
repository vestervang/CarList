namespace CarList.Attributes;

public class MenuItemTextAttribute(string text) : Attribute
{
    public string Text { get; } = text;
}