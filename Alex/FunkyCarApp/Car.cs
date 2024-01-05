
namespace FunkyCarApp
{
    public class Car
    {
        public string Make { get; set; } = "";
        public string Model { get; set; } = "";
        public int Year { get; set; }
        public int NumberOfTires { get; set; }
        public FuelType Fuel { get; set; }

        public Car(string make, string model, int year, int numberOfTires, FuelType fuel)
        {
            Make = make;
            Model = model;
            Year = year;
            NumberOfTires = numberOfTires;
            Fuel = fuel;
        }
    }

    public enum FuelType
    {
        Petrol,
        Diesel,
        Electric,
    }
}
