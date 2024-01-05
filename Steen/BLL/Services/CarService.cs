using BLL.Services.Interfaces;
using DAL.Contexts;
using Domain.Models;

namespace BLL.Services
{
    public class CarService : ICarService
    {
        private readonly CarListContext _carListContext;

        public CarService(CarListContext carListContext)
        {
            _carListContext = carListContext;
        }

        public void AddCar(Car car, Guid listingId)
        {
            _carListContext.CarContext.AddCar(car, listingId);
        }

        public void GetCars(Guid listingId)
        {
            throw new NotImplementedException();
        }

        public void UpdateCar(Car car, Guid listingId)
        {
            _carListContext.CarContext.UpdateCar(car, listingId);
        }

        public void SaveListingToFile(Guid listingId)
        {
            throw new NotImplementedException();
        }

        //public void SaveCarToFile(string listing, string WhichCar)
        //{
        //    throw new System.NotImplementedException();
        //}

        public void ReadListingFromFile(string FileToReadFrom)
        {
            throw new NotImplementedException();
        }

    }
}
