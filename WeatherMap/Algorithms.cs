using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace WeatherMap
{
    public class Algorithms
    {
        private List<string> Cities;

        public Algorithms()
        {
            Cities = ReadData();
        }
        private List<string> ReadData ()
        {
            List<string> Cities = new List<string>(); 
            string Filepath = $"{Environment.CurrentDirectory}\\worldcities.csv";
            using (var Reader = new StreamReader(Filepath)) 
            { 
                string line,city = String.Empty ,country = String.Empty;
                int counter = 0;
                while ((line = Reader.ReadLine()) != null) 
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
             
                    Cities.Add(city + ", " + country);
                    city = String.Empty; 
                    country = String.Empty;
                    counter = 0;
                }

            }

            Cities.RemoveAt(0);
            return Cities;
        }

        public List<string> FindMatches(string search)
        {
            List<string> result = new List<string>();
            foreach (var item in Cities)
            {
                if (item.StartsWith(search))
                {
                    result.Add(item);
                }
            }

            return result;
        }

    }
}