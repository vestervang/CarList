using System.Reflection;
using System.Runtime.Serialization;
using CarList.Attributes;
using CarList.Converters;
using CarList.Extensions;
using CarList.Models;
using Spectre.Console;

namespace CarList.Menus;

public class EnumMenu
{
    public static object? Create(PropertyInfo property)
    {
        if (!property.PropertyType.IsEnum)
        {
            return "";
        }

        var values = property.PropertyType.GetEnumValues();
        var question = property.PropertyType.GetCustomAttribute<QuestionAttribute>();

        var selectionPrompt = new SelectionPrompt<EnumMenuItem>()
            .Title(question?.Question)
            .PageSize(10)
            .UseConverter(EnumMenuItemConverter.Converter);

        foreach (var value in values)
        {
            var attr = value.GetAttributeOfType<EnumMemberAttribute>();
            selectionPrompt.AddChoice(new EnumMenuItem(value, attr?.Value));
        }

        var answer = AnsiConsole.Prompt(selectionPrompt);

        return answer.Value?.ToString();
    }
}