using System;
using System.IO;
namespace SzoftMod
{
    
    class Program
    {
        static void Main(string[] args)
        {
            bool boiler = false;
            bool ac = false;
            Console.WriteLine("Start");
            Loader loader = new Loader();
            Subscribers subscribers = loader.loadSubscribers();
            Monitor monitor = new Monitor();
            

            
            Driver driver = new Driver();
            /*foreach(var subscriber in subscribers.subscribers)
            {
                int response = driver.sendCommand(subscriber, true, true);
                Console.WriteLine(response);
            }*/

            while (true)
            {
                foreach (Subscriber i in subscribers.subscribers)
                {
                    Session session = monitor.getSession(i.homeId);
                    Temperature current_period = new Temperature();
                    foreach (Temperature j in i.temperatures) 
                    {
                        if (int.Parse(j.period.Split("-")[0]) <= DateTime.Now.Hour && int.Parse(j.period.Split("-")[1]) > DateTime.Now.Hour) //shit works yo
                        {
                            current_period = j;
                            break;
                        }
                    }
                    if (current_period.temperature-0.2>session.temperature) 
                    {
                        boiler = true;
                    }
                    if (current_period.temperature + 0.2 < session.temperature) 
                    {
                        ac = true;
                    }
                    if (current_period.temperature * 1.2 <= session.temperature) 
                    {
                        log(DateTime.Now.ToString() + " : HIBA- homeID: " + i.homeId + " Temp: " + session.temperature + " Túl magas");
                    }
                    if (current_period.temperature * 0.8 >= session.temperature)
                    {
                        log(DateTime.Now.ToString() + " : HIBA- homeID: " + i.homeId + " Temp: "  + session.temperature + " Túl alacsony");
                    }
                    int response = driver.sendCommand(i, boiler, ac);
                    Console.WriteLine(response);
                }
                Console.WriteLine();
                System.Threading.Thread.Sleep(1000);
            }
        }
        public static void log(string log) 
        {
            using (StreamWriter w = File.AppendText("log.txt")) 
            {
                w.WriteLine(log);
            }
        }
    }
}
