namespace MyCarsDb
{

    public static class Program
    {
        static void Main(string[] args)
        {
            var carprogram = new CarProgram(new CarListService());
            carprogram.MainMenu();
        }
    }
}
