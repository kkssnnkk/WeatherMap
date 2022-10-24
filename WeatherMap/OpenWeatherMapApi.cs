using System;
using System.Globalization;
using System.Net.Http;
using System.Net.Http.Headers;

namespace WeatherMap
{
    public class OpenWeatherMapApi
    {
        // api provider access key
        private readonly string _accessKey;
        
        // api base url
        private readonly string _baseUrl;
        
        // client for read returned data from api request
        private readonly HttpClient _httpClient;
        
        // formatting floating point types
        private readonly NumberFormatInfo _nfi;

        public OpenWeatherMapApi(string accessKey)
        {
            _accessKey = accessKey;
            _baseUrl = "http://http://api.openweathermap.org/data/2.5/weather?";
            _httpClient = new HttpClient();
            _nfi = new NumberFormatInfo { NumberDecimalSeparator = "." };
        }

        // getting weather data by city name
        public string GetJsonResponseStringByName(string city) 
        {
            // setting request headers
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            
            // return the read data from the page
            return _httpClient.GetStringAsync(new Uri($"{_baseUrl}q={city}&appid={_accessKey}")).Result;
        }
        
        // getting weather data by coords
        public string GetJsonResponseStringByCoords(double lat, double lng)
        {
            // setting request headers
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            
            // return the read data from the page
            return _httpClient.GetStringAsync(new Uri($"{_baseUrl}lat={lat.ToString(_nfi)}&lon={lng.ToString(_nfi)}&appid={_accessKey}")).Result;
        }
    }
}

