namespace Synchronous_vs._Asynchronous_Execution
{
    internal class Program
    {
        //static void Main(string[] args)
        //{
        //    Console.WriteLine("Start");
        //    DoWork(); // This takes 5 seconds and BLOCKS everything
        //    Console.WriteLine("End");
        //}
        //static void DoWork()
        //{
        //    Thread.Sleep(5000); // Simulating a long task (5 sec)
        //    Console.WriteLine("Work completed!");
        //}

        static async Task Main(string[] args)
        {
            Console.WriteLine("Start");
            await DoWork();  // Runs asynchronously without blocking
            Console.WriteLine("End");
        }
        static async Task DoWork()
        {
            await Task.Delay(5000); // Simulating a long task (5 sec)
            Console.WriteLine("Work completed!");
        }
    }
}
