using System;
using System.Globalization;
using System.Net.Http;
using System.Net.Http.Headers;

namespace WeatherMap
{
    public class ApiCalls
    {
        // api provider access key
        private const string AccessKey = "";
        
        // api base url
        private const string BaseUrl = "http://api.weatherstack.com/current?access_key=";
        
        // client for read returned data from api request
        private readonly HttpClient _client = new HttpClient();
        
        // formatting floating point types
        private readonly NumberFormatInfo _nfi = new NumberFormatInfo() { NumberDecimalSeparator = "." };

        // get weather data by city name
        public string GetJsonResponseString(string city) 
        {
            // change this request string in order to use new api
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            
            // reading data from page
            var response = _client.GetAsync(new Uri($"{BaseUrl}{AccessKey}&query={city}")).Result;
            
            // returning data as string
            return response.Content.ReadAsStringAsync().Result;
        }

        // get weather data by coords
        public string GetJsonResponseStringByCoords(double lat, double lon)
        {
            // change this request string in order to use new api
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            
            // reading data from page
            var response = _client.GetAsync(new Uri($"{BaseUrl}{AccessKey}&query={lat.ToString(_nfi)},{lon.ToString(_nfi)}")).Result;
            
            // returning data as string
            return response.Content.ReadAsStringAsync().Result;
        }
    }
}