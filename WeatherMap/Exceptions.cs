using System.Linq;
using Newtonsoft.Json.Linq;

namespace WeatherMap
{
    public class Exceptions
    {
        public bool ValidateJsonAnswer(string jsonData)
        {
            return !JObject.Parse(jsonData).ContainsKey("success");
        }

        public bool ValidateJsonAnswer(JObject jsonData)
        {
            return !jsonData.ContainsKey("success");
        }

        public bool ValidateSearchQuery(string text)
        {
            return text.Any();
        }
    }
}