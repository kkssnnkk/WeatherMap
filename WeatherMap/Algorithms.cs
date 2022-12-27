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

        // конструктор
        public Algorithms()
        {
            _cities = ReadData();
        }

        private static List<string> ReadData ()
        {
            // розташування файлу
            var filepath = $"{Environment.CurrentDirectory}\\worldcities.csv";

            // перевірка на наявність файлу
            try 
            {
                _exceptions.FileExists(filepath);
            }
            catch (FileNotExistsException exc)
            {
                MessageBox.Show(exc.Message.ToString(), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // контейнер для збору всіх міст
            var cities = new List<string>(); 
            // читання з файлу
            using (var reader = new StreamReader(filepath)) 
            { 
                string line,city = string.Empty ,country = string.Empty;
                var counter = 0;
                // читаємо файл
                while ((line = reader.ReadLine()) != null) 
                {
                    // розбивання строки на символи та виконання певних маніпуляцій
                    foreach (var item in line)
                    {
                        if (item == '\"')
                            counter++;
                        
                        else if (counter == 3)
                            city += item;
                           
                        else if (counter == 9)
                            country += item;
                    }
             
                    // додавання міста в список
                    cities.Add(city + ", " + country);
                    // очищення змінних 
                    city = string.Empty; 
                    country = string.Empty;
                    counter = 0;
                }

            }

            // видалення 0 елемениту 
            cities.RemoveAt(0);
            // повертання даних
            return cities;
        }

        public List<string> FindMatches(string search)
        {
            // фільтрація міст
            return _cities.Where(item => item.StartsWith(search)).ToList();
        }
    }
}