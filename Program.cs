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

            Monitor monitor = new Monitor();
            Session session = monitor.getSession("KD34AF24DS");
            Console.WriteLine(session.sessionId);
            Console.WriteLine(session.boilerState);
            Console.WriteLine(session.temperature);
            Console.WriteLine(session.airConditionerState);
        }
    }



   
}
