using System;

public record Car(string Make, string Model, int Year, int NumberOfTires, FuelType Fuel, string? LicensePlate)
{
	// Override ToString()
	// Add new line after each car

	        public override string ToString()
        {
            return $"{Make} {Model} from {Year} with {NumberOfTires} tires running on {Fuel}. License plate: {LicensePlate}";
        }
}		
