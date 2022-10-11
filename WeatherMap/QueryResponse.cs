using System.Globalization;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace WeatherMap
{
    public class QueryResponse
    {
        public bool ValidRequest { get; }
        public Coordinates Coordinates { get; }
        public List<Weather> WeatherList { get; } = new List<Weather>();
        public string Base { get; }
        public Main Main { get; }
        public double Visibility { get; }
        public Wind Wind { get; }
        public Rain Rain { get; }
        public Snow Snow { get; }
        public Clouds Clouds { get; }
        public Sys Sys { get; }
        public int ID { get; }
        public string Name { get; }
        public int Cod { get; }
        public int Temperature { get; }

        public QueryResponse(string jsonResponse)
        {
            var jsonData = JObject.Parse(jsonResponse);

            if (jsonData.SelectToken("cod").ToString() != "200")
            {
                ValidRequest = false;
                return;
            }
            
            ValidRequest = true;
            Coordinates = new Coordinates(jsonData.SelectToken("coord"));

            foreach (var weather in jsonData.SelectToken("weather"))
                WeatherList.Add(new Weather(weather));

            Base = jsonData.SelectToken("base").ToString();
            Main = new Main(jsonData.SelectToken("main"));

            if (jsonData.SelectToken("visibility") != null)
                Visibility = double.Parse(jsonData.SelectToken("visibility").ToString(), CultureInfo.InvariantCulture);

            if (jsonData.SelectToken("wind") != null)
                Wind = new Wind(jsonData.SelectToken("wind"));
            
            if (jsonData.SelectToken("rain") != null)
                Rain = new Rain(jsonData.SelectToken("rain"));
            
            if (jsonData.SelectToken("snow") != null)
                Snow = new Snow(jsonData.SelectToken("snow"));


            Temperature = int.Parse(jsonData.SelectToken("temperature").ToString(), CultureInfo.InvariantCulture);
            Clouds = new Clouds(jsonData.SelectToken("clouds"));
            Sys = new Sys(jsonData.SelectToken("sys"));
            ID = int.Parse(jsonData.SelectToken("id").ToString(), CultureInfo.InvariantCulture);
            Name = jsonData.SelectToken("name").ToString();
            Cod = int.Parse(jsonData.SelectToken("cod").ToString(), CultureInfo.InvariantCulture);
        }
    }
}