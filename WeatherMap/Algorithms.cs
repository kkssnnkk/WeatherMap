using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace WeatherMap
{
    public class Algorithms
    {
        private readonly List<string> _cities;
        private static readonly Exceptions _exceptions = new Exceptions();

        public Algorithms()
        {
            _cities = ReadData();
        }

        private static List<string> ReadData ()
        {
            var filepath = $"{Environment.CurrentDirectory}\\worldcities.csv";

            try 
            {
                _exceptions.FileExists(filepath);
            }
            catch (FileNotExistsException exc)
            {
                MessageBox.Show(exc.Message.ToString(), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            var cities = new List<string>(); 
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