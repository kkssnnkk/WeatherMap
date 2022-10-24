using System;
using System.Globalization;
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
                throw new ArgumentNullException(nameof(sysData));
            
            Type = int.Parse(sysData.SelectToken("type")?.ToString() ?? throw new ArgumentNullException(), CultureInfo.InvariantCulture);

            ID = int.Parse(sysData.SelectToken("id")?.ToString() ?? throw new ArgumentNullException(), CultureInfo.InvariantCulture);
        
            Message = double.Parse(sysData.SelectToken("message")?.ToString() ?? throw new ArgumentNullException(), CultureInfo.InvariantCulture);
            
            Country = sysData.SelectToken("country")?.ToString();
            
            Sunrise = ConvertUnixToDateTime(double.Parse(sysData.SelectToken("sunrise")?.ToString() ?? throw new ArgumentNullException(), CultureInfo.InvariantCulture));
            
            Sunset = ConvertUnixToDateTime(double.Parse(sysData.SelectToken("sunset")?.ToString() ?? throw new ArgumentNullException(), CultureInfo.InvariantCulture));
        }

        private static DateTime ConvertUnixToDateTime(double unixTime)
        {
            var dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

            return dateTime.AddSeconds(unixTime).ToLocalTime();
        }
    }
}