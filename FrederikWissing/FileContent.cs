namespace CarList;

public record FileContent
{
    public required string CurrentList { get; init; }
    public required Dictionary<string, List<Car>> Lists { get; init; }
}