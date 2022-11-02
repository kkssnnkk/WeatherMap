// ReSharper disable RedundantUsingDirective
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Windows.Forms;
using System;
using System.Threading;


namespace WeatherMap
{
    public class NaTException : Exception 
    {
        public NaTException()
        {
        }
        public NaTException(string message): base(message)
        {
        }
        public NaTException(string message, Exception inner): base(message, inner)
        {
        }
    }
    public class FormNotOpened : Exception
    {
        public FormNotOpened()
        {
        }
        public FormNotOpened(string message) : base(message)
        {
        }
        public FormNotOpened(string message, Exception inner) : base(message, inner)
        {
        }
    }
    public class CoordsException : Exception
    {
        public CoordsException()
        {
        }
        public CoordsException(string message) : base(message)
        {
        }
        public CoordsException(string message, Exception inner) : base(message, inner)
        {
        }
    }
    public class AppOnCloseExcption : Exception
    {
        public AppOnCloseExcption()
        {
        }
        public AppOnCloseExcption(string message) : base(message)
        {
        }
        public AppOnCloseExcption(string message, Exception inner) : base(message, inner)
        {
        }
    }



    public class Exceptions
    {
        // rebuild
        public bool ValidateJsonAnswer(string jsonData)
        {
            return !JObject.Parse(jsonData).ContainsKey("success");
        }
        // rebuild
        public bool ValidateJsonAnswer(JObject jsonData)
        {
            return !jsonData.ContainsKey("success");
        }

        public void ValidateSearchQuery(string text)
        {
            if (!text.Any()) throw new NaTException("Pls, check your search query."); 
        }

        public void ValidateCoords(double lat, double lon) 
        {
            if ((Convert.ToInt16(lat) == 85 && Convert.ToInt16(lon) == -180) || (Convert.ToInt16(lat) == -85 && Convert.ToInt16(lon) == -180) 
            || (Convert.ToInt16(lat) == -85 && Convert.ToInt16(lon) == 180) || (Convert.ToInt16(lat) == 85 && Convert.ToInt16(lon) == 180)) 
            {
                throw new CoordsException("Coords are not valid or no data for this coords provided.");
            }
        }

        public void ValidateExit(FormClosingEventArgs e) 
        {
            if (MessageBox.Show(@"Exit?", @"Closing app...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    Thread.Sleep(1000);
                    Environment.Exit(0);
                }
                catch (Exception) 
                {
                    throw new AppOnCloseExcption();
                }
            }
            else 
                e.Cancel = true;
        }

        public void msgError()
        {
            MessageBox.Show(@"Unexpected error", @"Press retry or cancel.", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}