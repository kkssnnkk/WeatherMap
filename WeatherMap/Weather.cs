﻿using System;
using System.Globalization;
using Newtonsoft.Json.Linq;

namespace WeatherMap
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
                throw new ArgumentNullException(nameof(weatherData));

            Id = int.Parse(weatherData.SelectToken("id").ToString(), CultureInfo.InvariantCulture);
            Main = weatherData.SelectToken("main").ToString();
            Description = weatherData.SelectToken("description").ToString();
            Icon = weatherData.SelectToken("icon").ToString();
        }
    }
    
    public class Clouds : Weather
    {
        public double All { get; }
        
        public Clouds(JToken cloudsData) : base(cloudsData)
        {
            if (cloudsData is null)
                throw new ArgumentNullException(nameof(cloudsData));

            if (cloudsData.SelectToken("all") != null)
                All = double.Parse(cloudsData.SelectToken("all").ToString(), CultureInfo.InvariantCulture);
        }
    }
    
    public class Rain : Weather
    {
        public double H3 { get; }
        
        public Rain(JToken rainData) : base(rainData)
        {
            if (rainData is null)
                throw new ArgumentNullException(nameof(rainData));

            if (rainData.SelectToken("3h") != null)
                H3 = double.Parse(rainData.SelectToken("3h").ToString(), CultureInfo.InvariantCulture);
        }
    }
    
    public class Snow : Weather
    {
        public double H3 { get; }
        
        public Snow(JToken snowData) : base(snowData)
        {
            if (snowData is null)
                throw new ArgumentException(nameof(snowData));

            if (snowData.SelectToken("3h") != null)
                H3 = double.Parse(snowData.SelectToken("3h").ToString(), CultureInfo.InvariantCulture);
        }
    }

    public class Wind : Weather
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

        public Wind(JToken windData) : base(windData)
        {
            if (windData is null)
                throw new ArgumentNullException(nameof(windData));

            SpeedMetersPerSecond = double.Parse(windData.SelectToken("speed").ToString(), CultureInfo.InvariantCulture);
            SpeedFeetPerSecond = SpeedMetersPerSecond * 3.28084;
            Degree = double.Parse(windData.SelectToken("deg").ToString(), CultureInfo.InvariantCulture);
            Direction = AssignDirection(Degree);

            if (windData.SelectToken("gust") != null)
                Gust = double.Parse(windData.SelectToken("gust").ToString(), CultureInfo.InvariantCulture);
        }
        
        public static string DirectionEnumToString(DirectionEnum dir)
        {
            switch (dir)
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
            if (fB(degree, 348.75, 360))
                return DirectionEnum.North;

            if (fB(degree, 0, 11.25))
                return DirectionEnum.North;

            if (fB(degree, 11.25, 33.75))
                return DirectionEnum.NorthNorthEast;

            if (fB(degree, 33.75, 56.25))
                return DirectionEnum.NorthEast;

            if (fB(degree, 56.25, 78.75))
                return DirectionEnum.EastNorthEast;

            if (fB(degree, 78.75, 101.25))
                return DirectionEnum.East;

            if (fB(degree, 101.25, 123.75))
                return DirectionEnum.EastSouthEast;

            if (fB(degree, 123.75, 146.25))
                return DirectionEnum.SouthEast;

            if (fB(degree, 168.75, 191.25))
                return DirectionEnum.South;

            if (fB(degree, 191.25, 213.75))
                return DirectionEnum.SouthSouthWest;

            if (fB(degree, 213.75, 236.25))
                return DirectionEnum.SouthWest;

            if (fB(degree, 236.25, 258.75))
                return DirectionEnum.WestSouthWest;

            if (fB(degree, 258.75, 281.25))
                return DirectionEnum.West;

            if (fB(degree, 281.25, 303.75))
                return DirectionEnum.WestNorthWest;

            if (fB(degree, 303.75, 326.25))
                return DirectionEnum.NorthWest;

            if (fB(degree, 326.25, 348.75))
                return DirectionEnum.NorthNorthWest;

            return DirectionEnum.Unknown;
        }
        
        private static bool fB(double val, double min, double max)
        {
            return min <= val && val <= max;
        }
    }
    
    public class Sun : Weather
    {
        public double All { get; }
        
        public Sun(JToken sunData) : base(sunData)
        {
            if (sunData is null)
                throw new ArgumentNullException(nameof(sunData));

            if (sunData.SelectToken("all") != null)
                All = double.Parse(sunData.SelectToken("all").ToString(), CultureInfo.InvariantCulture);
        }
    }
}