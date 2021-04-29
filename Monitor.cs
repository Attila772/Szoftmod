using System;
using System.Collections.Generic;
using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Reflection;
using System.IO;
using Newtonsoft.Json;
using ServiceStack;
using Newtonsoft.Json.Linq;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;


namespace SzoftMod
{
    
        interface IMonitor
        {
            public Session getSession(string homeId);
        }

        class Monitor : IMonitor
        {

            public Session getSession(string homeId)
            {

                string url = "http://193.6.19.58:8182/smarthome/" + homeId;
                Console.WriteLine(url);

                string todo = url.GetJsonFromUrl();

            // Session session = JsonConvert.DeserializeObject<Session>(todo);
            Console.WriteLine(todo);
            //var obj = JObject.Parse(todo);
            //Session session = obj.ToObject<Session>();






            Console.WriteLine(todo);
            string[] data = todo.Split('@', ',', '.', ';', '\'', '"');
            data[8] = data[8].Replace(":", "");
            string willbenumber = String.Join(",", data[8], data[9]);

            Session session = new Session();
            session.sessionId = (data[4].Replace('\'', ' ')).Trim();
            Console.WriteLine(willbenumber);
            session.temperature = float.Parse(willbenumber);
            session.boilerState = data[12].Contains("true");
            session.airConditionerState = data[15].Contains("true");





            return session;
            }

        }

    public class Session
    {
        public string sessionId { get; set; }
        public double temperature { get; set; }
        public bool boilerState { get; set; }
        public bool airConditionerState { get; set; }
    }

}

