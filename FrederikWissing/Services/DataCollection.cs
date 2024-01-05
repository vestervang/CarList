using System.Reflection;
using CarList.Attributes;
using CarList.Menus;
using Spectre.Console;

namespace CarList.Services;

public class DataCollection
{
    public static Car CollectCarData(Car? car = null)
    {
        car ??= new Car();

        var properties = car.GetType().GetProperties();

        for (var index = 0; index < properties.Length; index++)
        {
            Console.Clear();
            var property = properties[index];

            var propertyValue = property.GetValue(car);

            var questionAttribute = property.GetCustomAttribute<QuestionAttribute>();

            object? answer;
        
            if (property.PropertyType.IsEnum)
            {
                answer = EnumMenu.Create(property);
            }
            else if (propertyValue is null)
            {
                answer = AnsiConsole.Ask<string>(questionAttribute?.Question ??
                                                 $"No question for property {property.Name}");
            }
            else
            {
                answer = AnsiConsole.Ask(questionAttribute?.Question ?? $"No question for property {property.Name}",
                    propertyValue
                );
            }


            if (!ConverterService.CanConvertValueToType(property.PropertyType, answer))
            {
                index--;

                continue;
            }

            var convertedAnswer = ConverterService.ConvertValueToType(property.PropertyType, answer);

            property.SetValue(car, convertedAnswer);
        }

        return car;
    }
    
    public static string GetNewListName(Dictionary<string, List<Car>> carLists)
    {
        AnsiConsole.Clear();

        string listName;

        while (true)
        {
            listName = AnsiConsole.Ask<string>("Name your list:").Trim();

            if (string.IsNullOrEmpty(listName))
            {
                AnsiConsole.MarkupLine("[maroon]Can't create a list with a empty name[/]");
                continue;
            }

            if (carLists.ContainsKey(listName))
            {
                AnsiConsole.MarkupLine("[maroon]A list with this name already exists[/]");
                continue;
            }

            break;
        }

        return listName;
    }
}