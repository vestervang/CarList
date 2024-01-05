using ConsoleApp.Core.Models.Enums;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleApp.Core.Models
{
    public record Car
    {
        public Car(int id, string make, string model, int year)
        {
            Id = id;
            Make = make;
            Model = model;
            Year = year;
        }

        public Car(int id, string make, string model, int year, int? numberOfTires) : this(id,make, model, year)
        {
            this.NumberOfTires = numberOfTires;
        }

        public Car(int id, string make, string model, int year, Fuel fuel) : this(id, make, model, year)
        {
            Fuel = fuel;
        }

        public Car(int id,string make, string model, int year, int? numberOfTires, Fuel fuel) : this(id, make, model, year, numberOfTires)
        {
            Fuel = fuel;
        }

        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int? NumberOfTires { get; set; }
        public Fuel Fuel { get; set; }
    }
}
