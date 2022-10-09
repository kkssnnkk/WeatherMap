using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace WeatherMap
{
    public class ApiCalls
    {
        private string access_key = "";
        private string base_url = "http://api.weatherstack.com/current?access_key=";
        private HttpClient client = new HttpClient();

        public string getJsonResponseString(string query) 
        {
            client.BaseAddress = new Uri(base_url + access_key + "&query=" + query);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync(client.BaseAddress).Result;
            return response.Content.ReadAsStringAsync().Result;
        }
    }
}
