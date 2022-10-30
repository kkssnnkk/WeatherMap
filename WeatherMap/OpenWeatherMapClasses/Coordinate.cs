using Newtonsoft.Json.Linq;

namespace WeatherMap
{
    public class Coordinates
    {
        public double Longitude { get; }
        
        public double Latitude { get; }
        
        public Coordinates(JToken coordinateData)
        {
            Longitude = double.Parse(coordinateData.SelectToken("lon")?.ToString() ?? "0");
            
            Latitude = double.Parse(coordinateData.SelectToken("lat")?.ToString() ?? "0");
        }
    }
}
