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
                return;
            
            Temperature = new TemperatureObj(
                double.Parse(mainData.SelectToken("temp")?.ToString() ?? "0"),
                double.Parse(mainData.SelectToken("temp_min")?.ToString() ?? "0"),
                double.Parse(mainData.SelectToken("temp_max")?.ToString() ?? "0"),
                double.Parse(mainData.SelectToken("feels_like")?.ToString() ?? "0"));
            
            Pressure = double.Parse(mainData.SelectToken("pressure")?.ToString() ?? "0");
            
            Humidity = double.Parse(mainData.SelectToken("humidity")?.ToString() ?? "0");
            
            SeaLevelAtm = double.Parse(mainData.SelectToken("sea_level")?.ToString() ?? "0");
            
            GroundLevelAtm = double.Parse(mainData.SelectToken("ground_level")?.ToString() ?? "0");
        }
    }
}
