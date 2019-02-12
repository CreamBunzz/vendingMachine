namespace vendingMachine
{
    sealed class Program
    {
        static void Main(string[] args)
        {
            Controller controller = new Controller();
            controller.Run();

        }
              
    }
}
