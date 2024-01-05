using ConsoleApp.Core.Models;

namespace ConsoleApp.Core
{
    public class CarListService
    {
        public List<Car> Cars { get; set; } = new List<Car>();

        public bool CreateCar(Car car)
        {
            //validation
            if (car == null)
            {
                return false;
            }

            car.Id = Cars.Any() ? Cars.Max(c => c.Id)  + 1 : 1;

            Cars.Add(car);
            return true;
        }

        public bool UpdateCar(Car car)
        {
            var originalCar = Cars.SingleOrDefault(c => c.Id == car.Id);

            if (originalCar == null)
            {
                return false;
            }

            Cars.Remove(originalCar);
            Cars.Add(car);
            return true;
        }

        public bool SaveCarList(IReadOnlyList<Car> cars)
        {
            throw new NotImplementedException();
        }

        //TODO hvordan laver man et fedt interface
        public List<Car> ImportCarList()
        {
            throw new NotImplementedException();
        }
    }
}
