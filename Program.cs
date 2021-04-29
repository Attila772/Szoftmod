using System;


namespace SzoftMod
{
    
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hell!");
            Loader loader = new Loader();
            loader.loadSubscribers();
        }
    }



   
}
