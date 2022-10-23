using System.Linq;
using Newtonsoft.Json.Linq;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms;
using System;

namespace WeatherMap
{
    public class Exceptions
    {
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

        public void runProcessLurking() 
        {
            Thread thread = new Thread(delegate () {
                Process process = null;
                while (true) 
                {
                    Thread.Sleep(5);
                    try 
                    { 
                        process = Process.GetProcessesByName("WeatherMap")[0];
                        if (process.MainWindowHandle == null || string.IsNullOrEmpty(process.MainWindowTitle))
                        {
                            //MessageBox.Show(@"Process was closed.", @"Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            //process.Kill(); 
                            break;
                        }
                    }
                    catch { continue; };
                }
            });
            thread.Start();
        }
    }
}