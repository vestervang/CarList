using ConsoleApp.Core;
using ConsoleApp.Core.Models;
using ConsoleApp.Core.Models.Enums;

namespace ConsoleApp.UI
{
    public static class MainMenu
    {
        public static void Show()
        {
            Console.WriteLine("Main Menu");
            Console.WriteLine($"Option 1: View the car list");
            Console.WriteLine($"Option 2: Add new car to the list");
            Console.WriteLine($"Option 3: Update car on the list");
        }

        public static int ReadMainMenuChoice()
        {
            Console.WriteLine($"Choose one of the options above and press enter");

            var choice = Console.ReadLine();

            if (int.TryParse(choice, out int result))
            {
                return result;
            }
            else
            {
                return 0;
            }
        }

        public static void ShowCarList(IReadOnlyList<Car> cars)
        {
            Console.WriteLine("Car List");
            foreach (var car in cars)
            {
                Console.WriteLine(
                    $"Id: {car.Id}, Make: {car.Make}, Model: {car.Model}, Year: {car.Year}, Fuel: {car.Fuel}, Number of tires: {car.NumberOfTires}"
                );
            }
        }

        public static Car AddNewCar()
        {
            Console.Clear();
            Console.WriteLine("Add new car");
            string make = GetStringInput("Make");
            string model = GetStringInput("Model");
            int year = GetIntegerInput("Year");
            //Console.WriteLine("Additional information but not required");
            //Console.WriteLine("Will you provide type of fuel? (yes/no)");
            //var willAddFuel = Console.ReadLine();
            //var willAddFuelInputCorrect = false;
            //while (willAddFuelInputCorrect == false)
            //{
            //    if(willAddFuel == null)
            //    {
            //        willAddFuelInputCorrect = false;
            //    }
            //    else if (willAddFuel.Equals("n", StringComparison.CurrentCultureIgnoreCase) || willAddFuel.Equals("no", StringComparison.CurrentCultureIgnoreCase))
            //    {
            //        willAddFuelInputCorrect = true;
            //    }
            //    else if (willAddFuel.Equals("y", StringComparison.CurrentCultureIgnoreCase) || willAddFuel.Equals("yes", StringComparison.CurrentCultureIgnoreCase))
            //    {
            //        willAddFuelInputCorrect = true;
            //    }
            //    else
            //    {
            //        willAddFuelInputCorrect = false;
            //    }

            //    willAddFuel = Console.ReadLine();
            //}
            return new Car(1, make, model, year);
        }

        public static void CarAdded()
        {
            Console.WriteLine("Car added to the list");
        }

        private static string GetStringInput(string inputName)
        {
            Console.WriteLine($"Enter {inputName} and press enter");
            string? input = Console.ReadLine();

            while (string.IsNullOrEmpty(input))
            {
                Console.WriteLine($"Wrong input try again");
                input = Console.ReadLine();
            }

            return input;
        }

        private static int GetIntegerInput(string inputName)
        {
            Console.WriteLine($"Enter {inputName} and press enter");
            var inputCorrect = false;
            var result = 0;
            string? input = Console.ReadLine();

            if (int.TryParse(input, out result))
            {
                inputCorrect = true;
            }
            else
            {
                inputCorrect = false;
            }

            while (string.IsNullOrEmpty(input) || !inputCorrect)
            {
                Console.WriteLine($"Wrong input try again");
                input = Console.ReadLine();

                if (int.TryParse(input, out result))
                {
                    inputCorrect = true;
                }
                else
                {
                    inputCorrect = false;
                }                
            }            

            return result;
        }
    }
}
