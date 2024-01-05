using System.Runtime.Serialization;
using CarList.Attributes;

namespace CarList;

[Question("What fuel does your car use?")]
public enum FuelTypes
{
    [EnumMember(Value = "Petrol")]
    Petrol = 0,
    [EnumMember(Value = "Diesel")]
    Diesel = 1,
    [EnumMember(Value = "Electric")]
    Electric = 2
}