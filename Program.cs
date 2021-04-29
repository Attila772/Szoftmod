using System;


namespace SzoftMod
{
    
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hell!");
            Loader loader = new Loader();
            Subscribers subscribers = loader.loadSubscribers();
            Driver driver = new Driver();
            foreach(var subscriber in subscribers.subscribers)
            {
                int response = driver.sendCommand(subscriber, true, true);
                Console.WriteLine(response);
            }
        }
    }



   
}
