using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FunkyCarApp
{
    public class CarHelper
    {
        public CarList CreateNewCarList()
        {
            var newList = new CarList("Unnamed list");

            while (true)
            {
                Console.Clear();

                try
                {
                    Console.WriteLine("""
                        Creating new car list. 
                        Please enter a name for this list:
                        
                        """);

                    string userInput = Console.ReadLine()!;
                    if(!String.IsNullOrWhiteSpace(userInput)) 
                    { 
                        newList.Name = userInput;
                        Console.WriteLine($"""
                            New car list "{newList.Name}" added!
                            Returning to main menu...
                            """);
                        Thread.Sleep(2500);
                        return newList;
                    }
                    else
                    {
                        Console.WriteLine("List name cannot be empty! Try again.");
                        Thread.Sleep(2000);
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("""
                        Unknown error while creating new car list. Returning to main menu in 5 seconds...
                        """);

                    Thread.Sleep(5000);
                    return newList;
                }
            }
        }

        public void ChooseListToInspect(GlobalInventory globalInventory)
        {
            while (true)
            {
                try
                {
                    Console.Clear();

                    Console.WriteLine("""
                        Welcome to car list inspection.
                        Please select a list to inspect from the options below, by entering its number:
                        Type in "back" to go back to the main menu

                        """);
                    foreach(var carList in globalInventory.ListOfCarLists)
                    {
                        Console.WriteLine($"{globalInventory.ListOfCarLists.IndexOf(carList) + 1}. {carList.Name} - Cars in list: {carList.Cars.Count}");
                    }
                    Console.WriteLine(); // spacing

                    string userInput = Console.ReadLine()!;

                    if (userInput.ToLower() == "back")
                    {
                        return;
                    }

                    bool inputIsInt = int.TryParse(userInput, out int selectedListNumber);
                    if (!inputIsInt || selectedListNumber > globalInventory.ListOfCarLists.Count)
                    {
                        Console.WriteLine("Input does not match a car list index! Try again.");
                        Thread.Sleep(2000);
                        continue;
                    }

                    InspectCarList(globalInventory.ListOfCarLists[selectedListNumber - 1]);
                }
                catch(Exception)
                {
                    Console.WriteLine("""
                        Unknown error while choosing car list. Returning to main menu in 5 seconds...
                        """);

                    Thread.Sleep(5000);
                    return;
                }
            }
        }

        public void InspectCarList(CarList currentCarList)
        {
            while(true)
            {
                try
                {
                    Console.Clear();

                    Console.WriteLine($"List: {currentCarList.Name}");
                    if (currentCarList.Cars.Count == 0)
                    {
                        Console.WriteLine("There ara no cars in the list, yet...");

                        Console.WriteLine("""
                                          What would you like to do?
                                          1. Go back to all car lists
                                          2. Add a new car to this list
                                          
                                          """);
                    }
                    else
                    {
                        Console.WriteLine("Cars:");
                        foreach (var car in currentCarList.Cars)
                        {
                            Console.WriteLine($"{car.Make} {car.Model} - Fuel Type: {car.Fuel} - Built in year: {car.Year} - Number of tires: {(car.NumberOfTires > 0 ? car.NumberOfTires : "Unknown")}");
                        }

                        Console.WriteLine("""

                                          What would you like to do?
                                          1. Go back to all car lists
                                          2. Add a new car to this list
                                          3. Change data on a car in this list
                                          
                                          """);
                    }

                    string userInput = Console.ReadLine()!;

                    switch (userInput)
                    {
                        case "1":
                            return;

                        case "2":
                            var newCar = CreateNewCar();
                            if (newCar != null)
                            {
                                currentCarList.Cars.Add(newCar);
                                Console.WriteLine($"New car \"{newCar.Make} {newCar.Model}\" added to list: {currentCarList.Name}");
                                Thread.Sleep(3000);
                            }
                            break;
                        case "3":
                            if (!currentCarList.Cars.Any())
                            {
                                Console.WriteLine("No cars to edit! Going back to list...");
                                Thread.Sleep(2000);
                                continue;
                            }

                            Console.WriteLine("Select a car to edit from list:");
                            foreach(var car in currentCarList.Cars)
                            {
                                Console.WriteLine($"{currentCarList.Cars.IndexOf(car) + 1} Make: {car.Make} - Model: {car.Model} - Year: {car.Year} - Tires: {car.NumberOfTires} - Fuel: {car.Fuel}");
                            }

                            bool editIndexIsInt = int.TryParse(Console.ReadLine(), out var editIndex);
                            if (!editIndexIsInt || editIndex > currentCarList.Cars.Count)
                            {
                                Console.WriteLine("Input does not match a car index! Try again.");
                                continue;
                            }

                            var newCarToReplaceOld = CreateNewCar();
                            if (newCarToReplaceOld == null)
                            {
                                Console.WriteLine("Failed to edit car. Returning to list.");
                                Thread.Sleep(2000);
                                continue;
                            }

                            currentCarList.Cars[editIndex - 1] = newCarToReplaceOld!;
                            break;
                        default:
                            Console.WriteLine("Unknown command! Try again.");
                            Thread.Sleep(2000);
                            break;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("""
                        Unknown error while inspecting car list. Returning to main menu...
                        """);

                    Thread.Sleep(5000);
                    return;
                }
            }
        }

        public Car CreateNewCar()
        {
            try
            {
                Console.Clear();

                Console.WriteLine("Please enter the car's make:");
                string newCarMake = Console.ReadLine()!;

                Console.WriteLine("Please enter the car's model:");
                string newCarModel = Console.ReadLine()!;

                int newCaryear = 0;
                while (true)
                {
                    Console.WriteLine("Please enter the year the car was built:");
                    bool isNumber = int.TryParse(Console.ReadLine(), out newCaryear);
                    if (!isNumber)
                    {
                        Console.WriteLine("Not a number! Try again.");
                        Thread.Sleep(2000);
                        continue;
                    }

                    break;
                }

                int newCartires = 0;
                while (true)
                {
                    Console.WriteLine("Please specify how many tires the car has:");
                    bool isNumber = int.TryParse(Console.ReadLine(), out var numberOfTires);
                    if (!isNumber)
                    {
                        Console.WriteLine("Not a number! Try again.");
                        Thread.Sleep(2000);
                        continue;
                    }

                    newCartires = numberOfTires;
                    break;
                }

                FuelType newFuelType = new FuelType();
                while(true)
                {
                    Console.WriteLine("Please specify what type of fuel the car runs on, by selecting from the list below:");
                    Console.WriteLine();
                    foreach (var fuelTypeNames in Enum.GetNames<FuelType>())
                    {
                        Console.WriteLine(fuelTypeNames);
                    }

                    string userInput = Console.ReadLine()!;

                    if (String.IsNullOrEmpty(userInput) || userInput.Length < 2)
                    {
                        Console.WriteLine("Input cannot be empty! Try again");
                        continue;
                    }

                    userInput = userInput.Substring(0, 1).ToUpper() + userInput.Trim().Substring(1);
                    if (!Enum.IsDefined(typeof(FuelType), userInput))
                    {
                        Console.WriteLine("Not an accepted fuel type! Try again");
                        continue;
                    }

                    newFuelType = (FuelType)Enum.Parse(typeof(FuelType), userInput);
                    break;
                }

                return new Car(newCarMake, newCarModel, newCaryear, newCartires, newFuelType);
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong when creating car. No new car created. Returning to car list in 3 seconds");
                Thread.Sleep(3000);
                return null;
            }
        }

        public void ExportToFile(GlobalInventory globalInventory)
        {
            try
            {
                string path = Path.Combine(Environment.CurrentDirectory, "Exported Car Inventory " + DateTime.Now.ToShortDateString());
                var exportText = JsonSerializer.Serialize(globalInventory);
                using (StreamWriter writer = new StreamWriter(path))
                {
                    writer.WriteLine(exportText);
                }

                Console.WriteLine("Inventory successfully exported to " + path);
            }
            catch (Exception)
            {
                Console.WriteLine("Failed to export inventory. Returning to main menu...");
                Thread.Sleep(3000);
            }
        }

        public GlobalInventory ImportFile()
        {
            try
            {
                // todo-ah: Open dialog. Select file. Deserialize text to class.
                return null;
            }
            catch
            {
                return null;
            }
        }
    }
}
