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
                Tires = 4
            });
        }

        private List<Car> cars = new List<Car>();

        public bool Changed { get; private set; } = false;

        public void AddCar(Car car)
        {
            cars.Add(car);
        }

        public void UpdateCar(Car car)
        {
            //var element = cars.SingleOrDefault(c => c.Id == car.Id);
            throw new NotImplementedException();
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
