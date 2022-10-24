﻿using System;
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
        
        // formatting floating point types
        private readonly NumberFormatInfo _nfi = new NumberFormatInfo() { NumberDecimalSeparator = "." };

        // getting weather data by city name
        public string GetJsonResponseString(string city) 
        {
            // setting request headers
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // change this request string in order to use new api
            var response = _client.GetAsync(new Uri($"{BaseUrl}{AccessKey}&query={city}")).Result;
            
            // returning data as string
            return response.Content.ReadAsStringAsync().Result;
        }

        // getting weather data by coords
        public string GetJsonResponseStringByCoords(double lat, double lon)
        {
            // setting request headers
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // change this request string in order to use new api
            var response = _client.GetAsync(new Uri($"{BaseUrl}{AccessKey}&query={lat.ToString(_nfi)},{lon.ToString(_nfi)}")).Result;
            
            // returning data as string
            return response.Content.ReadAsStringAsync().Result;
        }
    }
}