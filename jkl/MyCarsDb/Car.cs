
namespace MyCarsDb
{
    public class Car
    {
        public Car()
        {
            Id = Guid.NewGuid();
        }

        private Guid Id;
        public required string Make { get; set; }
        public required string Model { get; set; }
        public int? Year { get; set; }
        public int? Tires { get; set; }
        //public required Fuel Fuel { get; set; }
    }
}
