using System.Linq;
using Newtonsoft.Json.Linq;
using System.Windows.Forms;
using System;
using System.Security.Cryptography;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace WeatherMap
{
    public class Exceptions
    {
        public enum MemoryProtectionScope 
        { 
            CrossProcess = 1, 
            SameLogon = 2, 
            SameProcess = 0 
        };

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

        public void validateExit(FormClosingEventArgs e) 
        {
            if (MessageBox.Show("Exit?", "Closing app...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) Environment.Exit(0);
            else e.Cancel = true;
        }
    }
}