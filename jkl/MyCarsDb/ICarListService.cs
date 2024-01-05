namespace MyCarsDb
{
    public interface ICarListService
    {
        public bool Changed { get; }
        List<Car> GetAll();
        void ResetList();
        void AddCar(Car car);
        void UpdateCar(Car car);
        void ExportList();
        void ImportList();
    }
}
