using System;
using Newtonsoft.Json.Linq;

namespace WeatherMap
{
    public class Sys
    {
        public int Type { get; }
        public int ID { get; }
        public double Message { get; }
        public string Country { get; }
        public DateTime Sunrise { get; }
        public DateTime Sunset { get; }

        public Sys(JToken sysData)
        {
            if (sysData is null)
                return;
            
            Type = int.Parse(sysData.SelectToken("type")?.ToString() ?? "0");

            ID = int.Parse(sysData.SelectToken("id")?.ToString() ?? "0");
        
            Message = double.Parse(sysData.SelectToken("message")?.ToString() ?? "0");
            
            Country = sysData.SelectToken("country")?.ToString();
            
            Sunrise = ConvertUnixToDateTime(double.Parse(sysData.SelectToken("sunrise")?.ToString() ?? "0"));
            
            Sunset = ConvertUnixToDateTime(double.Parse(sysData.SelectToken("sunset")?.ToString() ?? "0"));
        }

        private static DateTime ConvertUnixToDateTime(double unixTime)
        {
            var dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

            return dateTime.AddSeconds(unixTime).ToLocalTime();
        }
    }
}