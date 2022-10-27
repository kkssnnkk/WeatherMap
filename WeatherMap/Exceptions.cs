// ReSharper disable RedundantUsingDirective
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Windows.Forms;
using System;
using System.Threading;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.ComponentModel;

namespace WeatherMap
{
    public class Exceptions
    {
        DataToSave dataToSave = new DataToSave();
        BinaryFormatter formatter = new BinaryFormatter();


        [SerializableAttribute]
        public struct DataToSave
        {
            public string language;
            public string theme;
            public string api;
            public int    font_size;

            public string temperature;
            public string location;
            public string status;
            public string seacrh_field;
        };

        public DataToSave getSaveDataStructure() { return dataToSave; }

        public bool ValidateJsonAnswer(string jsonData)
        {
            return !JObject.Parse(jsonData).ContainsKey("success");
        }

        public bool ValidateJsonAnswer(JObject jsonData)
        {
            return !jsonData.ContainsKey("success");
        }

        public bool ValidateSearchQuery(string text)
        {
            return text.Any();
        }

        public bool ValidateCoords(double lat, double lon) 
        {
            return !(Convert.ToInt16(lat) == 85 && Convert.ToInt16(lon) == -180) && 
                   !(Convert.ToInt16(lat) == -85 && Convert.ToInt16(lon) == -180) && 
                   !(Convert.ToInt16(lat) == -85 && Convert.ToInt16(lon) == 180) && 
                   !(Convert.ToInt16(lat) == 85 && Convert.ToInt16(lon) == 180);
        }

        public void ValidateExit(FormClosingEventArgs e) 
        {
            if (MessageBox.Show(@"Exit?", @"Closing app...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Thread.Sleep(1000);
                Environment.Exit(0);
            }
            else 
                e.Cancel = true;
        }

        public void saveAppState(DataToSave data_to_save)
        {
            dataToSave = data_to_save;
            try
            {
                 byte[] data;

                 using (MemoryStream ms = new MemoryStream())
                 {
                      formatter.Serialize(ms, dataToSave);
                      ms.Seek(0, SeekOrigin.Begin);
                      data = ms.ToArray();
                 }

                 using (BinaryWriter bin = new BinaryWriter(File.Open("configuration.bin", FileMode.OpenOrCreate), System.Text.Encoding.UTF8, false))
                 {
                      bin.Write(data);
                 }
            }
            catch (Exception) { Console.WriteLine("Error writing config file."); }    
        }

        public DataToSave getAppLastState() 
        {
            try
            {
                FileStream fs = File.Open("configuration.bin", FileMode.Open);
                object data = formatter.Deserialize(fs);
                dataToSave = (DataToSave)data;
                fs.Flush(); 
                fs.Close();
                fs.Dispose();
            }
            catch (Exception) { Console.WriteLine("Error reading config file."); }

            return dataToSave;
        }
    }
}