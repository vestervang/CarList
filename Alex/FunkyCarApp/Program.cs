namespace FunkyCarApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var globalInventory = new GlobalInventory();
            var carHelper = new CarHelper();

            while (true)
            {
                try
                {
                    Console.Clear();

                    Console.WriteLine($"""
                        Welcome to the CarList(tm) App
                        Lists of cars existing: {globalInventory.ListOfCarLists.Count}
                        Please select an option by entering a number and pressing enter:

                        1. Create a new list of cars.
                        2. View a specific list of cars.
                        3. Export all car lists to a file.
                        4. Import car lists from a file.
                        5. Exit the program.

                        """);

                    string userInput = Console.ReadLine()!;

                    switch (userInput)
                    {
                        case "1":
                            globalInventory.ListOfCarLists.Add(carHelper.CreateNewCarList());
                            break;
                        case "2":
                            carHelper.ChooseListToInspect(globalInventory);
                            break;
                        case "3":
                            carHelper.ExportToFile(globalInventory);
                            break;
                        case "4":
                            var importedInventory = carHelper.ImportFile();
                            if (importedInventory != null)
                            {
                                globalInventory = importedInventory;
                                break;
                            }

                            Console.WriteLine("Could not import!");
                            Thread.Sleep(2000);
                            break;
                        case "5":
                            CloseProgram();
                            break;
                        default:
                            Console.WriteLine("Not a valid option! Try again.");
                            Thread.Sleep(2000);
                            break;
                    }


                    // nice to have:
                    // delete a list + edit list name
                }
                catch(Exception)
                {
                    Console.WriteLine("An unexpected error has occurred. Returning to main menu in 5 seconds.");
                    Thread.Sleep(5000);
                }
            }
        }

        public static void CloseProgram() 
        {
            Console.WriteLine("""
                               Are you sure you want to close the program?
                               To confirm, type "close"
                               """);

            string closeInput = Console.ReadLine()!;
            if (closeInput.ToLower() == "close")
            {
                Environment.Exit(0);
            }

            Console.WriteLine("""
                Returning to main menu...
                """);
            Thread.Sleep(2000);
        }
    }
}
