using System.Runtime.InteropServices;

namespace CarList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Begin();
        }

        public static void Begin()
        {
            Console.WriteLine("Hello, Welcome to Carlistings. Your options are:");
            Console.WriteLine();
            Console.WriteLine("1. Create a new List.");
            Console.WriteLine("2. View all current lists a List.");
            Console.WriteLine("3. View a specific list.");
            Console.WriteLine("4. Add a car to a list.");
            Console.WriteLine("5. Edit a car in a list.");
            Console.WriteLine("6. Save a list to a file.");
            Console.WriteLine("7. Import a list from a file.");
            Console.WriteLine();
            Console.WriteLine("Please enter the number of the option you want to use.");


            bool failure = true;
            while (failure)
            {
                if (int.TryParse(Console.ReadLine(), out int option))
                {
                    switch (option)
                    {
                        case 1:
                            CreateListing();
                            break;
                        case 2:
                            ViewAllCurrentListings();
                            break;
                        case 3:
                            ViewSpecificListing();
                            break;
                        case 4:
                            AddACarToListing();
                            break;
                        case 5:
                            EditCarInListing();
                            break;
                        case 6:
                            SaveListingToFile();
                            break;
                        case 7:
                            ImportListingFromFile();
                            break;
                        default:
                            Console.WriteLine("Please enter a valid number.");
                            break;
                    }
                }
            }
        }

        private static void ImportListingFromFile()
        {
            throw new NotImplementedException();
        }

        private static void SaveListingToFile()
        {
            throw new NotImplementedException();
        }

        private static void EditCarInListing()
        {
            throw new NotImplementedException();
        }

        private static void AddACarToListing()
        {
            throw new NotImplementedException();
        }

        private static void ViewSpecificListing()
        {
            throw new NotImplementedException();
        }

        private static void ViewAllCurrentListings()
        {
            throw new NotImplementedException();
        }

        public static void CreateListing()
        {

        }
    }
}
