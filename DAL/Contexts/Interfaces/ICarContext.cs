using Domain.Models;

namespace DAL.Contexts.Interfaces
{
    public interface ICarContext
    {
        void AddCar(Car car, Guid listingId);
        void UpdateCar(Car newcar, Guid listingId);
    }
}