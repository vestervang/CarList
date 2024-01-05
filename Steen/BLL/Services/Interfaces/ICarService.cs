using Domain.Models;

namespace BLL.Services.Interfaces
{
    public interface ICarService
    {
        void AddCar(Car car, Guid listingId);
        void UpdateCar(Car car, Guid listingId);
    }
}