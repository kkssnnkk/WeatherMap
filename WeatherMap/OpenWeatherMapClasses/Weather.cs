using Newtonsoft.Json.Linq;

// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable MemberCanBePrivate.Global

namespace WeatherMap.OpenWeatherMapClasses
{
    public class Weather
    {
        public int Id { get; }
        
        public string Main { get; }
        
        public string Description { get; }
        
        public string Icon { get; }

        public Weather(JToken weatherData)
        {
            if (weatherData is null)
                return;
            
            Id = int.Parse(weatherData.SelectToken("id")?.ToString() ?? "0");

            Main = weatherData.SelectToken("main")?.ToString();
            
            Description = weatherData.SelectToken("description")?.ToString();
            
            Icon = weatherData.SelectToken("icon")?.ToString();
        }
    }
    
    public class Clouds
    {
        public double All { get; }
        
        public Clouds(JToken cloudsData)
        {
            if (cloudsData is null)
                return;
            
            All = double.Parse(cloudsData.SelectToken("all")?.ToString() ?? "0");
        }
    }
    
    public class Rain
    {
        public double H3 { get; }
        
        public Rain(JToken rainData)
        {
            if (rainData is null)
                return;
            
            H3 = double.Parse(rainData.SelectToken("3h")?.ToString() ?? "0");
        }
    }
    
    public class Snow
    {
        public double H3 { get; }
        
        public Snow(JToken snowData)
        {
            if (snowData is null)
                return; 
            
            H3 = double.Parse(snowData.SelectToken("3h")?.ToString() ?? "0");
        }
    }
    
    public class Sun
    {
        public double All { get; }
        
        public Sun(JToken sunData)
        {
            if (sunData is null)
                return;
            
            All = double.Parse(sunData.SelectToken("all")?.ToString() ?? "0");
        }
    }

    public class Wind
    {
        public enum DirectionEnum
        {
            North,
            NorthNorthEast,
            NorthEast,
            EastNorthEast,
            East,
            EastSouthEast,
            SouthEast,
            SouthSouthEast,
            South,
            SouthSouthWest,
            SouthWest,
            WestSouthWest,
            West,
            WestNorthWest,
            NorthWest,
            NorthNorthWest,
            Unknown
        }

        public double SpeedMetersPerSecond { get; }
        public double SpeedFeetPerSecond { get; }
        public DirectionEnum Direction { get; }
        public double Degree { get; }
        public double Gust { get; }

        public Wind(JToken windData)
        {
            if (windData is null)
                return;
            
            SpeedMetersPerSecond = double.Parse(windData.SelectToken("speed")?.ToString() ?? "0");
            
            SpeedFeetPerSecond = SpeedMetersPerSecond * 3.28084;
            
            Degree = double.Parse(windData.SelectToken("deg")?.ToString() ?? "0");
            
            Direction = AssignDirection(Degree);
            
            Gust = double.Parse(windData.SelectToken("gust")?.ToString() ?? "0");
        }
        
        public static string DirectionEnumToString(DirectionEnum direction)
        {
            switch (direction)
            {
                case DirectionEnum.East:
                    return "East";

                case DirectionEnum.EastNorthEast:
                    return "East North-East";

                case DirectionEnum.EastSouthEast:
                    return "East South-East";

                case DirectionEnum.North:
                    return "North";

                case DirectionEnum.NorthEast:
                    return "North East";

                case DirectionEnum.NorthNorthEast:
                    return "North North-East";

                case DirectionEnum.NorthNorthWest:
                    return "North North-West";

                case DirectionEnum.NorthWest:
                    return "North West";

                case DirectionEnum.South:
                    return "South";

                case DirectionEnum.SouthEast:
                    return "South East";

                case DirectionEnum.SouthSouthEast:
                    return "South South_East";

                case DirectionEnum.SouthSouthWest:
                    return "South South_West";

                case DirectionEnum.SouthWest:
                    return "South West";

                case DirectionEnum.West:
                    return "West";

                case DirectionEnum.WestNorthWest:
                    return "West North_West";

                case DirectionEnum.WestSouthWest:
                    return "West South_West";

                case DirectionEnum.Unknown:
                    return "Unknown";

                default:
                    return "Unknown";
            }
        }
        
        private DirectionEnum AssignDirection(double degree)
        {
            if (CalcDirection(degree, 348.75, 360))
                return DirectionEnum.North;

            if (CalcDirection(degree, 0, 11.25))
                return DirectionEnum.North;

            if (CalcDirection(degree, 11.25, 33.75))
                return DirectionEnum.NorthNorthEast;

            if (CalcDirection(degree, 33.75, 56.25))
                return DirectionEnum.NorthEast;

            if (CalcDirection(degree, 56.25, 78.75))
                return DirectionEnum.EastNorthEast;

            if (CalcDirection(degree, 78.75, 101.25))
                return DirectionEnum.East;

            if (CalcDirection(degree, 101.25, 123.75))
                return DirectionEnum.EastSouthEast;

            if (CalcDirection(degree, 123.75, 146.25))
                return DirectionEnum.SouthEast;

            if (CalcDirection(degree, 168.75, 191.25))
                return DirectionEnum.South;

            if (CalcDirection(degree, 191.25, 213.75))
                return DirectionEnum.SouthSouthWest;

            if (CalcDirection(degree, 213.75, 236.25))
                return DirectionEnum.SouthWest;

            if (CalcDirection(degree, 236.25, 258.75))
                return DirectionEnum.WestSouthWest;

            if (CalcDirection(degree, 258.75, 281.25))
                return DirectionEnum.West;

            if (CalcDirection(degree, 281.25, 303.75))
                return DirectionEnum.WestNorthWest;

            if (CalcDirection(degree, 303.75, 326.25))
                return DirectionEnum.NorthWest;

            if (CalcDirection(degree, 326.25, 348.75))
                return DirectionEnum.NorthNorthWest;

            return DirectionEnum.Unknown;
        }
        
        private static bool CalcDirection(double val, double min, double max)
        {
            return min <= val && val <= max;
        }
    }
}