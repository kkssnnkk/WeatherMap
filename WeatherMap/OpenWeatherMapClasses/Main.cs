using System;
using System.Globalization;
using Newtonsoft.Json.Linq;

namespace WeatherMap
{
    public class Main
    {
        public TemperatureObj Temperature { get; }
        public double Pressure { get; }
        public double Humidity { get; }
        public double SeaLevelAtm { get; }
        public double GroundLevelAtm { get; }

        public Main(JToken mainData)
        {
            if (mainData is null)
                throw new ArgumentNullException(nameof(mainData));

            Temperature = new TemperatureObj(double.Parse(mainData.SelectToken("temp")?.ToString() ?? throw new ArgumentNullException(), CultureInfo.InvariantCulture));
            
            Pressure = double.Parse(mainData.SelectToken("pressure")?.ToString() ?? throw new ArgumentNullException(), CultureInfo.InvariantCulture);
            
            Humidity = double.Parse(mainData.SelectToken("humidity")?.ToString() ?? throw new ArgumentNullException(), CultureInfo.InvariantCulture);
            
            SeaLevelAtm = double.Parse(mainData.SelectToken("sea_level")?.ToString() ?? throw new ArgumentNullException(), CultureInfo.InvariantCulture);
            
            GroundLevelAtm = double.Parse(mainData.SelectToken("ground_level")?.ToString() ?? throw new ArgumentNullException(), CultureInfo.InvariantCulture);
        }
    }
}
