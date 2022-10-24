using System;
using System.Globalization;
using System.Net.Http;
using System.Net.Http.Headers;

namespace WeatherMap
{
    public class WeatherStackApi
    {
        // api provider access key
        private readonly string _accessKey;
        
        // api base url
        private readonly string _baseUrl;
        
        // client for read returned data from api request
        private readonly HttpClient _httpClient;
        
        // formatting floating point types
        private readonly NumberFormatInfo _nfi;

        public WeatherStackApi(string accessKey)
        {
            _accessKey = accessKey;
            _baseUrl = "http://api.weatherstack.com/current?access_key=";
            _httpClient = new HttpClient();
            _nfi = new NumberFormatInfo { NumberDecimalSeparator = "." };
        }
        
        // get weather data by city name
        public string GetJsonResponseStringByName(string city) 
        {
            // change this request string in order to use new api
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            
            // return the read data from the page
            return _httpClient.GetStringAsync(new Uri($"{_baseUrl}{_accessKey}&query={city}")).Result;
        }

        // get weather data by coords
        public string GetJsonResponseStringByCoords(double lat, double lng)
        {
            // change this request string in order to use new api
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            
            // return the read data from the page
            return _httpClient.GetStringAsync(new Uri($"{_baseUrl}{_accessKey}&query={lat.ToString(_nfi)},{lng.ToString(_nfi)}")).Result;
        }
    }
}