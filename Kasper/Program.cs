using System.Text;

List<Car> Carlist = [];

string Menu = """
---------------------------------------------
1: View cars
2: Add car
3: Edit car
4: Save list of cars
5: Load list of cars

Please select a option, or use <esc> to quit.
""";

Console.Clear();
bool Exit = false;
while (!Exit)
{
  string MenuOption = string.Empty;
  Console.WriteLine(Menu);
  Exit = !CancelableReadLine(out MenuOption);

  switch (MenuOption)
  {
    case "1":
      Console.WriteLine("Cars: ");

      for (int i = 0; i < Carlist.Count; i++)
      {
        Console.Write($"{i}: ");
        Console.WriteLine(Carlist[i].ToString());
      }

      Console.WriteLine();
      break;
    case "2":
      Console.WriteLine();
      // loop over Car property
      // When done add new Car to Carlist

      // Some holder object
      // var car = new Car();
      foreach (var property in typeof(Car).GetProperties())
      {
        Console.WriteLine($"Please enter {property.Name}: ");
        Console.ReadLine();
      }

      // Use holder object to add new Car
      // Carlist.Add(holderObject);

      Carlist.Add(new Car("Ford", "Fiesta", 2019, 4, FuelType.Petrol, "XX XX XXX"));

      break;
    case "3":
      Console.Clear();
      Console.WriteLine("Cars: ");
      Console.Write(Carlist.ToString());
      Console.WriteLine("Select a car");

      // Select index
      // Select property
      // Enter new property
      // Save and return

      break;
    case "4":
      Console.WriteLine();

      // Save to file

      break;
    case "5":
      Console.WriteLine();

      // Read from file, populate Carlist

      break;
    default:
      Console.WriteLine();
      break;
  }
}

static bool CancelableReadLine(out string value)
{
  value = string.Empty;
  var buffer = new StringBuilder();
  var key = Console.ReadKey(true);
  while (key.Key != ConsoleKey.Enter && key.Key != ConsoleKey.Escape)
  {
    if (key.Key == ConsoleKey.Backspace && Console.CursorLeft > 0)
    {
      var cli = --Console.CursorLeft;
      buffer.Remove(cli, 1);
      Console.CursorLeft = 0;
      Console.Write(new String(Enumerable.Range(0, buffer.Length + 1).Select(o => ' ').ToArray()));
      Console.CursorLeft = 0;
      Console.Write(buffer.ToString());
      Console.CursorLeft = cli;
      key = Console.ReadKey(true);
    }
    else if (Char.IsLetterOrDigit(key.KeyChar) || Char.IsWhiteSpace(key.KeyChar))
    {
      var cli = Console.CursorLeft;
      buffer.Insert(cli, key.KeyChar);
      Console.CursorLeft = 0;
      Console.Write(buffer.ToString());
      Console.CursorLeft = cli + 1;
      key = Console.ReadKey(true);
    }
    else if (key.Key == ConsoleKey.LeftArrow && Console.CursorLeft > 0)
    {
      Console.CursorLeft--;
      key = Console.ReadKey(true);
    }
    else if (key.Key == ConsoleKey.RightArrow && Console.CursorLeft < buffer.Length)
    {
      Console.CursorLeft++;
      key = Console.ReadKey(true);
    }
    else
    {
      key = Console.ReadKey(true);
    }
  }

  if (key.Key == ConsoleKey.Enter)
  {
    Console.WriteLine();
    value = buffer.ToString();
    return true;
  }

  return false;
}