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
        public bool ValidateJsonAnswer(string jsonData) 
        {
            var jsObject = JObject.Parse(jsonData);
            return !jsObject.ContainsKey("success");
        }

        public bool ValidateSearchQuery(string text) 
        {
            return text.Any();
        }
    }
}
