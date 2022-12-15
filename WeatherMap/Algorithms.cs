using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WeatherMap
{
    public class Algorithms
    {
        private readonly List<string> _cities;

        public Algorithms()
        {
            _cities = ReadData();
        }

        private static List<string> ReadData ()
        {
            var cities = new List<string>(); 
            var filepath = $"{Environment.CurrentDirectory}\\worldcities.csv";
            using (var reader = new StreamReader(filepath)) 
            { 
                string line,city = string.Empty ,country = string.Empty;
                var counter = 0;
                while ((line = reader.ReadLine()) != null) 
                {
                    foreach (var item in line)
                    {
                        if (item == '\"')
                            counter++;
                        
                        else if (counter == 3)
                            city += item;
                           
                        else if (counter == 9)
                            country += item;
                    }
             
                    cities.Add(city + ", " + country);
                    city = string.Empty; 
                    country = string.Empty;
                    counter = 0;
                }

            }

            cities.RemoveAt(0);
            return cities;
        }

        public List<string> FindMatches(string search)
        {
            return _cities.Where(item => item.StartsWith(search)).ToList();
        }
    }
}