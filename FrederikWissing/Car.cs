using CarList.Attributes;

namespace CarList;

public class Car
{
    [Question("What make is the car?")]
    public string Make { get; set; }
    [Question("What model is the car?")]
    public string Model { get; set; }
    [Question("What year was the car made?")]
    public int? Year { get; set; }
    [Question("How many wheels does the car have?")]
    public int? NumberOfTires { get; set; }
    [Question("What fuel type does the car use to run?")]
    public FuelTypes FuelType { get; set; }
    
    [Question("What's the license plate?")]
    public string? LicensePlate { get; set; }

    public override string ToString()
    {
        return $"Make: {Make}, Model: {Model}, Year: {Year}, Number of tires: {NumberOfTires}, Fuel Type: {FuelType}, License plate: {LicensePlate}";
    }
}