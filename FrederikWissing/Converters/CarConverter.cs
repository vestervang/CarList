namespace CarList.Converters;

public static class CarConverter
{
    public static readonly Func<Car, string> Converter = car =>
    {
        if (car is {Make: Constants.NullCarMake, Model: Constants.NullCarModel})
        {
            return "Return to main menu";
        }

        return car.ToString();
    };
}