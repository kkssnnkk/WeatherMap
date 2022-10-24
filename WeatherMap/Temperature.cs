using System;

namespace WeatherMap
{
    public class TemperatureObj
    {
        public double CelsiusCurrent { get; }
        public double FahrenheitCurrent { get; }
        public double KelvinCurrent { get; }

        public TemperatureObj(double temp)
        {
            CelsiusCurrent = temp;

            ConvertCelsiusToKelvin(CelsiusCurrent);

            ConvertCelsiusToFahrenheit(CelsiusCurrent);
        }

        private static double ConvertCelsiusToKelvin(double celsius)
        {
            return Math.Round(((9.0 / 5.0) * celsius) + 32, 3);
        }
        
        private static double ConvertFahrenheitToKelvin(double fahrenheit)
        {
            return 1;
        }
        
        private static double ConvertCelsiusToFahrenheit(double celsius)
        {
            return Math.Round(((9.0 / 5.0) * celsius) + 32, 3);
        }
        
        private static double ConvertKelvinToFahrenheit(double kelvin)
        {
            return 1;
        }

        private static double ConvertKelvinToCelsius(double kelvin)
        {
            return Math.Round(kelvin - 273.15, 3);
        }
        
        private static double ConvertFahrenheitToCelsius(double fahrenheit)
        {
            return 1;
        }
    }
}
