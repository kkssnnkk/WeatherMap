using System.Collections.Generic;
using Newtonsoft.Json.Linq;

// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable MemberCanBePrivate.Global

namespace WeatherMap.OpenWeatherMapClasses
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
        
        public int Id { get; }
        
        public string Name { get; }
        
        public int Cod { get; }
        
        public int Temperature { get; }

        public QueryResponse(string jsonResponse)
        {
            var jsonData = JObject.Parse(jsonResponse);

            Cod = int.Parse(jsonData.SelectToken("cod")?.ToString() ?? "0");
            
            if (Cod != 200)
            {
                ValidRequest = false;
                return;
            }
            
            ValidRequest = true;
            Coordinates = new Coordinates(jsonData.SelectToken("coord"));
            
            
            // ReSharper disable once PossibleNullReferenceException
            foreach (var weather in jsonData.SelectToken("weather"))
                WeatherList.Add(new Weather(weather));

            Base = jsonData.SelectToken("base")?.ToString();
            
            Main = new Main(jsonData.SelectToken("main"));
            
            Visibility = double.Parse(jsonData.SelectToken("visibility")?.ToString() ?? "0");

            Wind = new Wind(jsonData.SelectToken("wind"));
            
            Rain = new Rain(jsonData.SelectToken("rain"));
            
            Snow = new Snow(jsonData.SelectToken("snow"));
            
            Temperature = int.Parse(jsonData.SelectToken("temperature")?.ToString() ?? "0");
            
            Clouds = new Clouds(jsonData.SelectToken("clouds"));

            Sys = new Sys(jsonData.SelectToken("sys"));
            
            Id = int.Parse(jsonData.SelectToken("id")?.ToString() ?? "0");
            
            Name = jsonData.SelectToken("name")?.ToString();
        }
    }
}