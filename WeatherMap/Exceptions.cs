using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;


namespace WeatherMap
{
    public class Exceptions
    {
        public bool validateJsonAnswer(string json_data) 
        {
            var jsObject = JObject.Parse(json_data);
            if (jsObject.ContainsKey("success") && jsObject["success"].Value<bool>() == false) return false;
            else return true;
        }
    }
}
