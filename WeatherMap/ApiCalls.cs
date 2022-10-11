using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace WeatherMap
{
    public class ApiCalls
    {
        private string access_key = ""; // api provider access key
        private string base_url = "http://api.weatherstack.com/current?access_key="; // api base 
        private HttpClient client = new HttpClient();

        // get weather data by city name
        public string getJsonResponseString(string city) 
        {
            client.BaseAddress = new Uri(base_url + access_key + "&query=" + city); // change this request string in order to use new api
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync(client.BaseAddress).Result;
            return response.Content.ReadAsStringAsync().Result;
        }

        // get weather data by coords
        public string getJsonResponseStringByCoords(float lat, float lon) 
        {
            client.BaseAddress = new Uri(base_url + access_key + "&query=" + lat + ',' + lon); // change this request string in order to use new api
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync(client.BaseAddress).Result;
            return response.Content.ReadAsStringAsync().Result;
        }
    }
}
