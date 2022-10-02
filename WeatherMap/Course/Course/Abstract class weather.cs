using System;
using System.Globalization;
using Newtonsoft.Json.Linq;
namespace Course
{
        abstract public class Weather
        {
            public int ID { get; }
            public string Main { get; }
            public string Description { get; }
            public string Icon { get; }
            public Weather(JToken weatherData)
            {
                if (weatherData is null)
                    throw new System.ArgumentNullException(nameof(weatherData));
                ID = int.Parse(weatherData.SelectToken("id").ToString(), CultureInfo.InvariantCulture);
                Main = weatherData.SelectToken("main").ToString();
                Description = weatherData.SelectToken("description").ToString();
                Icon = weatherData.SelectToken("icon").ToString();
            }
        }
        public class Clouds : Weather
        {
            public Clouds(JToken cloudsData) : base(cloudsData)
        {
                if (cloudsData is null)
                    throw new System.ArgumentNullException(nameof(cloudsData));
                All = double.Parse(cloudsData.SelectToken("all").ToString(), CultureInfo.InvariantCulture);
            }
            public double All { get; }
        }
        public class Rain : Weather
        {
            public Rain(JToken rainData) : base(rainData)
        {
                if (rainData is null)
                    throw new System.ArgumentNullException(nameof(rainData));
                if (rainData.SelectToken("3h") != null)
                    H3 = double.Parse(rainData.SelectToken("3h").ToString(), CultureInfo.InvariantCulture);
            }
            public double H3 { get; }
        }
        public class Snow : Weather
        {
            public Snow(JToken snowData) : base(snowData)
        {
                if (snowData is null)
                    throw new System.ArgumentException(nameof(snowData));
                if (snowData.SelectToken("3h") != null)
                    H3 = double.Parse(snowData.SelectToken("3h").ToString(), CultureInfo.InvariantCulture);
            }
            public double H3 { get; }
        }
        public class Wind : Weather
        {
            public enum DirectionEnum
            {
                North,
                North_North_East,
                North_East,
                East_North_East,
                East,
                East_South_East,
                South_East,
                South_South_East,
                South,
                South_South_West,
                South_West,
                West_South_West,
                West,
                West_North_West,
                North_West,
                North_North_West,
                Unknown
            }
            public double SpeedMetersPerSecond { get; }
            public double SpeedFeetPerSecond { get; }
            public DirectionEnum Direction { get; }
            public double Degree { get; }
            public double Gust { get; }
            public Wind(JToken windData) : base(windData)
        {
                if (windData is null)
                    throw new System.ArgumentNullException(nameof(windData));
                SpeedMetersPerSecond = double.Parse(windData.SelectToken("speed").ToString(), CultureInfo.InvariantCulture);
                SpeedFeetPerSecond = SpeedMetersPerSecond * 3.28084;
                Degree = double.Parse(windData.SelectToken("deg").ToString(), CultureInfo.InvariantCulture);
                Direction = assignDirection(Degree);
                if (windData.SelectToken("gust") != null)
                    Gust = double.Parse(windData.SelectToken("gust").ToString(), CultureInfo.InvariantCulture);
            }
            public static string DirectionEnumToString(DirectionEnum dir)
            {
                switch (dir)
                {
                    case DirectionEnum.East:
                        return "East";
                    case DirectionEnum.East_North_East:
                        return "East North-East";
                    case DirectionEnum.East_South_East:
                        return "East South-East";
                    case DirectionEnum.North:
                        return "North";
                    case DirectionEnum.North_East:
                        return "North East";
                    case DirectionEnum.North_North_East:
                        return "North North-East";
                    case DirectionEnum.North_North_West:
                        return "North North-West";
                    case DirectionEnum.North_West:
                        return "North West";
                    case DirectionEnum.South:
                        return "South";
                    case DirectionEnum.South_East:
                        return "South East";
                    case DirectionEnum.South_South_East:
                        return "South South_East";
                    case DirectionEnum.South_South_West:
                        return "South South_West";
                    case DirectionEnum.South_West:
                        return "South West";
                    case DirectionEnum.West:
                        return "West";
                    case DirectionEnum.West_North_West:
                        return "West North_West";
                    case DirectionEnum.West_South_West:
                        return "West South_West";
                    case DirectionEnum.Unknown:
                        return "Unknown";
                    default:
                        return "Unknown";

                }
            }
            private DirectionEnum assignDirection(double degree)
            {
                if (fB(degree, 348.75, 360))
                    return DirectionEnum.North;
                if (fB(degree, 0, 11.25))
                    return DirectionEnum.North;
                if (fB(degree, 11.25, 33.75))
                    return DirectionEnum.North_North_East;
                if (fB(degree, 33.75, 56.25))
                    return DirectionEnum.North_East;
                if (fB(degree, 56.25, 78.75))
                    return DirectionEnum.East_North_East;
                if (fB(degree, 78.75, 101.25))
                    return DirectionEnum.East;
                if (fB(degree, 101.25, 123.75))
                    return DirectionEnum.East_South_East;
                if (fB(degree, 123.75, 146.25))
                    return DirectionEnum.South_East;
                if (fB(degree, 168.75, 191.25))
                    return DirectionEnum.South;
                if (fB(degree, 191.25, 213.75))
                    return DirectionEnum.South_South_West;
                if (fB(degree, 213.75, 236.25))
                    return DirectionEnum.South_West;
                if (fB(degree, 236.25, 258.75))
                    return DirectionEnum.West_South_West;
                if (fB(degree, 258.75, 281.25))
                    return DirectionEnum.West;
                if (fB(degree, 281.25, 303.75))
                    return DirectionEnum.West_North_West;
                if (fB(degree, 303.75, 326.25))
                    return DirectionEnum.North_West;
                if (fB(degree, 326.25, 348.75))
                    return DirectionEnum.North_North_West;
                return DirectionEnum.Unknown;
            }
            private static bool fB(double val, double min, double max)
            {
                if ((min <= val) && (val <= max))
                    return true;
                return false;
            }
        }
        public class Sun : Weather
        {
            public Sun(JToken sunData) : base(sunData) 
            {
            if (sunData is null)
                throw new System.ArgumentNullException(nameof(sunData));
            All = double.Parse(sunData.SelectToken("all").ToString(), CultureInfo.InvariantCulture);
        }
        public double All { get; }
    }
}