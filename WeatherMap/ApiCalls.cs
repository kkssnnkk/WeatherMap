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
        // api base
        private const string BaseUrl = "http://api.weatherstack.com/current?access_key="; 
        private readonly HttpClient _client = new HttpClient();

        NumberFormatInfo NFI = new NumberFormatInfo()
        {
            NumberDecimalSeparator = ".",
        };
        public string GetJsonResponseString(string city) 
        {
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json")); // change this request string in order to use new api
            HttpResponseMessage response = _client.GetAsync(new Uri(BaseUrl + AccessKey + "&query=" + city)).Result;
            return response.Content.ReadAsStringAsync().Result;
        }

        // get weather data by coords
        public string GetJsonResponseStringByCoords(double lat, double lon) 
        {
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = _client.GetAsync(new Uri(BaseUrl + AccessKey + "&query=" + lat.ToString(NFI) + ',' + lon.ToString(NFI))).Result; // change this request string in order to use new api
            return Convert.ToString(response.Content.ReadAsStringAsync().Result, NFI);
        }
    }
}
