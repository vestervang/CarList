using Spectre.Console;

namespace CarList.Services;

public class InputService
{
    public static void WaitForAnyKeyPress()
    {
        AnsiConsole.WriteLine("\npress any key to continue");
        Console.ReadKey();
    }
}