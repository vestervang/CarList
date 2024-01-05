using Domain.Models.Enums;

namespace Domain.Models
{
    public record Car(string Make, string Model, string? Year, string? NumberOfTires, FuelType Fuel)
    {
    }
}
