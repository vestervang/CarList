using DAL.Contexts.Interfaces;
using DAL.Utilities;
using Domain.Models;
using System.Reflection;

namespace DAL.Contexts
{
    public class CarContext : ICarContext
    {
        public CarContext(CarListContext carListContext)
        {
            CarListContext = carListContext;
        }

        public CarListContext CarListContext { get; }

        public void AddCar(Car car, Guid listingId)
        {
            var listing = CurrentListings.Instance.Listings.FirstOrDefault(listing => listing.Id == listingId);

            if (listing == null)
            {
                throw new Exception("Listing not found");//todo: pick exception type
            }

            listing.Cars.Add(car);
        }

        public void UpdateCar(Car newcar, Guid listingId)
        {
            var car = CurrentListings.Instance.Listings.FirstOrDefault(listing => listing.Id == listingId)?.Cars.FirstOrDefault(car => car.Id == newcar.Id);

            if (car == null)
            {
                throw new Exception("Listing not found");//todo: pick exception type
            }

            car = newcar;//todo: test om dette virker grundet call by refrence
        }
    }
}
