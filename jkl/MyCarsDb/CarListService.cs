namespace MyCarsDb
{
    public class CarListService : ICarListService
    {
        public CarListService()
        {
            cars.Add(new Car()
            {
                Make = "Ford",
                Model = "Mondeo",
                Year = 2012,
                Tires = 4,
                Fuel = Fuel.Diesel
            });
        }

        private List<Car> cars = new List<Car>();

        public bool Changed { get; private set; } = false;

        public void AddCar(Car car)
        {
            cars.Add(car);
        }

        /// <exception cref="ArgumentOutOfRangeException">Thrown if car with specified Id does not exist in list</exception>
        public void UpdateCar(Car car)
        {
            var element = cars.SingleOrDefault(c => c.Id == car.Id);
            if (element != null)
            {
                element = car;
            } else
            {
                throw new ArgumentOutOfRangeException(nameof(car), "Car with id " + car.Id + " not found");
            }
        }

        public void ExportList()
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return cars;
        }

        public void ImportList()
        {
            throw new NotImplementedException();
        }

        public void ResetList()
        {
            Changed = false;
            cars = new List<Car>();
        }
    }
}
