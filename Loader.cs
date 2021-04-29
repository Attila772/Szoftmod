using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.IO;

namespace SzoftMod
{
    interface ILoader
    {
        public Subscribers loadSubscribers();
    }

   class Loader :ILoader
    {
        public Subscribers loadSubscribers()
        {
            Subscribers subscribers = JsonConvert.DeserializeObject<Subscribers>(File.ReadAllText(@"subscribers.json"));

            foreach(Subscriber b in subscribers.subscribers) {
                Console.WriteLine(b.airConditionerType);
            }
            return subscribers;
        }
        
    }

    public class Temperature
    {
        public string period { get; set; }
        public double temperature { get; set; }
    }
    public class Subscriber
    {
        public string subscriber { get; set; }
        public string homeId { get; set; }
        public string boilerType { get; set; }
        public string airConditionerType { get; set; }
        public List<Temperature> temperatures { get; set; }
    }
    public class Subscribers
    {
        public List<Subscriber> subscribers { get; set; }
    }
}
