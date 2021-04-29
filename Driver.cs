using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace SzoftMod
{
    interface IDriver
    {
        public int sendCommand(Subscriber sub, bool boiler, bool ac);
    }
    class Driver : IDriver
    {
        public int sendCommand(Subscriber sub, bool boiler, bool ac)
        {
            string boilerCommand = "", airConditionerCommand = "";
            switch (sub.boilerType)
            {
                case "Boiler 1200W":
                    if (boiler) boilerCommand = "bX3434";
                    else boilerCommand = "bX1232";
                    break;
                case "Boiler p5600":
                    if (boiler) boilerCommand = "cX7898";
                    else boilerCommand = "cX3452";
                    break;
                case "Boiler tw560":
                    if (boiler) boilerCommand = "dX3422";
                    else boilerCommand = "dX111";
                    break;
                case "Boiler 1400L":
                    if (boiler) boilerCommand = "kx8417";
                    else boilerCommand = "kx4823";
                    break;
            }
            switch (sub.airConditionerType)
            {
                case "Air p5600":
                    if (ac) airConditionerCommand = "bX5676";
                    else airConditionerCommand = "bX3421";
                    break;
                case "Air c3200":
                    if (ac) airConditionerCommand = "cX3452";
                    else airConditionerCommand = "cX5423";
                    break;
                case "Air rk110":
                    if (ac) airConditionerCommand = "eX1111";
                    else airConditionerCommand = "eX2222";
                    break;
            }
            int resp = 0;
            string url = "http://193.6.19.58:8182/smarthome/";
            url += sub.homeId;
            WebRequest request = WebRequest.Create(url);
            request.Method = "POST";
            string postData = "{" +
                "\"homeID\":\"" + sub.homeId + "\"," +
                "\"boilerCommand\":\"" + boilerCommand + "\"," +
                "\"airConditionerCommand\":\"" + airConditionerCommand + "\"" +
                "}";
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            request.ContentType = "text/plain";
            request.ContentLength = byteArray.Length;
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
            WebResponse response = request.GetResponse();
            if (((HttpWebResponse)response).StatusDescription.Equals("OK"))
            {
                using (dataStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(dataStream);
                    string responseFromServer = reader.ReadToEnd();
                    resp = Convert.ToInt32(responseFromServer);
                }
            }
            else
            {
                Console.WriteLine("There was an error in the connection!!");
            }
            response.Close();
            return resp;
        }
    }
}
