using System;

namespace WeatherMap
{
    public class TemperatureObj
    {
        public double CelsiusCurrent { get; }
        
        public double FahrenheitCurrent { get; }
        
        public double KelvinCurrent { get; }
        
        public double CelsiusMax { get; }
        
        public double FahrenheitMax { get; }
        
        public double KelvinMax { get; }
        
        public double CelsiusMin { get; }
        
        public double FahrenheitMin { get; }
        
        public double KelvinMin { get; }
        
        public double CelsiusFeelsLike { get; }
        
        public double FahrenheitFeelsLike { get; }
        
        public double KelvinFeelsLike { get; }

        public TemperatureObj(double temp, double tempMin, double tempMax, double feelsLike)
        {
            KelvinCurrent = temp;

            KelvinMin = tempMin;

            KelvinMax = tempMax;

            KelvinFeelsLike = feelsLike;

            CelsiusCurrent = ConvertKelvinToCelsius(KelvinCurrent);
            
            CelsiusMin = ConvertKelvinToCelsius(KelvinMin);

            CelsiusMax = ConvertKelvinToCelsius(KelvinMax);
            
            CelsiusFeelsLike = ConvertKelvinToCelsius(KelvinFeelsLike);

            FahrenheitCurrent = ConvertKelvinToFahrenheit(KelvinCurrent);

            FahrenheitMin = ConvertKelvinToFahrenheit(KelvinMin);
            
            FahrenheitMax = ConvertKelvinToFahrenheit(KelvinMax);
            
            FahrenheitFeelsLike = ConvertKelvinToFahrenheit(KelvinFeelsLike);
        }

        private static double ConvertKelvinToFahrenheit(double kelvin)
        {
            return Math.Round((kelvin - 273.15) * 1.8 + 32, 3);
        }

        private static double ConvertKelvinToCelsius(double kelvin)
        {
            return Math.Round(kelvin - 273.15, 3);
        }
    }
}