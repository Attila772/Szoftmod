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

using System.Globalization;
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
                //Console.WriteLine(url);

                string todo = url.GetJsonFromUrl();

                var jsonResult = JsonConvert.DeserializeObject(todo).ToString();
                Session session = JsonConvert.DeserializeObject<Session>(jsonResult);



            return session;
            }

        }

    public partial class Session
    {
        [JsonProperty("sessionId")]
        public string sessionId { get; set; }

        [JsonProperty("temperature")]
        public double temperature { get; set; }

        [JsonProperty("boilerState")]
        public bool boilerState { get; set; }

        [JsonProperty("airConditionerState")]
        public bool airConditionerState { get; set; }
    }

}

