namespace MyCarsDb
{
    public class CarProgram
    {
        public readonly ICarListService _carListService;
        public CarProgram(ICarListService carListService)
        {
            _carListService = carListService;
        }

        public void Header()
        {
            Console.Clear();
            Console.WriteLine("My Cars Db");
            Console.WriteLine();
        }

        public void MainMenu()
        {
            do
            {
                Header();

                Console.WriteLine("1. Create new list");
                Console.WriteLine("2. View current list");
                Console.WriteLine("3. Add a new car");
                Console.WriteLine("4. Edit existing car");
                Console.WriteLine("5. Export list to file");
                Console.WriteLine("6. Import list to file");
                Console.WriteLine("0. Quit");

                char selected = GetSelection(['1', '2', '3', '4', '5', '6', '0']);

                if (selected == '1')
                {
                    CreateNewList();
                }
                else if (selected == '2')
                {
                    ViewCurrentList();
                }
                else if (selected == '3')
                {
                    AddNewCar();
                }
                //else if (selected == '4')
                //{
                //    EditExistingCar();
                //}
                //else if (selected == '5')
                //{
                //    ExportListToFile();
                //}
                //else if (selected == '6')
                //{
                //    ImportListFromFile();
                //}
                else if (selected == '0')
                {
                    Quit();
                }

            } while (true);
        }

        private void Quit()
        {
            Header();

            if (_carListService.Changed == false)
            {
                Environment.Exit(0);
            }

            Console.WriteLine("Do you want to quit?");
            Console.WriteLine("List of cars has not been saved.");
            Console.WriteLine("Confirm [yes/no]");
            var possibleSelections = new string[] { "yes", "no" };
            string selected = GetSelection(possibleSelections);

            if (selected == "yes")
            {
                Environment.Exit(0);
            }
        }

        private void AddNewCar()
        {
            var properties = typeof(Car).GetProperties();
            var requiredProperties = new string[] { nameof(Car.Make), nameof(Car.Model)/*, nameof(Car.Fuel)*/ };
            foreach (var p in properties)
            {
                //var info = typeof(Car).GetProperty(p.Name);
                //var required = Attribute.IsDefined(p, typeof(RequiredAttribute));
                //var info = TypeDescriptor.GetProperties(typeof(Car)).Cast<PropertyDescriptor>().Any(p => p.Attributes.Cast<Attribute>().Any(a => a.GetType() == typeof(RequiredAttribute)));
                var required = requiredProperties.Contains(p.Name);

                Console.WriteLine(p.Name + (required ? " *" : "") + " [Type: " + p.PropertyType + "]");
            }

            var dict = new Dictionary<string, object>();

            foreach (var p in properties)
            {
                bool valid = false;
                do
                {
                    var required = requiredProperties.Contains(p.Name);
                    Console.Write(p.Name + (required ? " *" : "") + " > ");
                    var input = Console.ReadLine();
                    if (p.PropertyType == typeof(string))
                    {
                        if (required)
                        {
                            if (input != null)
                            {
                                valid = true;
                                dict.Add(p.Name, input);
                            }
                            else
                            {
                                Console.WriteLine("Try again");
                            }
                        }
                        else
                        {
                            valid = true;
                            dict.Add(p.Name, input!);
                        }
                    }
                    else if (p.PropertyType == typeof(int))
                    {
                        if (required)
                        {
                            if (input != null)
                            {
                                var parsed = int.TryParse(input!.ToString(), out var val);
                                if (parsed)
                                {
                                    valid = true;
                                    dict.Add(p.Name, val);
                                }
                                else
                                {
                                    Console.WriteLine("Try again");
                                }
                            }
                        }
                        else
                        {
                            var parsed = int.TryParse(input!.ToString(), out var val);
                            if (parsed)
                            {
                                valid = true;
                                dict.Add(p.Name, val);
                            }
                        }
                    }
                } while (!valid);

            }


            Console.WriteLine();

            Footer("New car added");
        }

        private void ViewCurrentList()
        {
            Header();

            var cars = _carListService.GetAll();
            foreach (var car in cars)
            {
                Console.WriteLine("---");
                //Console.WriteLine("Make: " + car.Make);
                //Console.WriteLine("Model: " + car.Model);
                //Console.WriteLine("Year: " + car.Year);
                //Console.WriteLine("Tires: " + car.Tires);
                //Console.WriteLine("Fuel: " + car.Fuel);

                var properties = typeof(Car).GetProperties();
                foreach(var property in properties)
                {
                    var propValue = car.GetType().GetProperty(property.Name)!.GetValue(car, null);
                    Console.WriteLine(property.Name + ": " + propValue);
                }
            }
            Console.WriteLine("---");
            Console.WriteLine("Total: " + cars.Count);

            Footer();
        }

        private void Footer(string? message = null)
        {
            if (!string.IsNullOrEmpty(message))
            {
                Console.WriteLine(message);
            }

            Console.WriteLine("Press <ENTER>");
            bool enterPressed;
            do
            {
                var key = Console.ReadKey(true);
                enterPressed = key.Key == ConsoleKey.Enter;
            } while (!enterPressed);
        }

        public void CreateNewList()
        {
            Header();

            if (_carListService.Changed == false)
            {
                _carListService.ResetList();
                Footer("New list created");
                return;
            }

            Console.WriteLine("Create new list?");
            Console.WriteLine("This will ERASE all cars in list");
            Console.WriteLine("Confirm [yes/no]");
            var possibleSelections = new string[] { "yes", "no" };
            string selected = GetSelection(possibleSelections);

            if (selected == "yes")
            {
                _carListService.ResetList();
            }

            Footer("New list created");
        }

        public string GetSelection(string[] validStrings)
        {
            string selected = "";
            do
            {
                Console.Write("> ");
                var input = Console.ReadLine();
                if (!string.IsNullOrEmpty(input))
                {
                    selected = input;
                }
            }
            while (!validStrings.Contains(selected));
            return selected;
        }

        public char GetSelection(char[] validChars)
        {
            ConsoleKeyInfo key;
            bool valid;
            do
            {
                Console.Write("> ");
                key = Console.ReadKey();
                Console.Write("\n");
                valid = validChars.Contains(key.KeyChar);
                if (!valid)
                {
                    Console.WriteLine("Invalid selection");
                }
            } while (!valid);
            return key.KeyChar;
        }
    }
}
