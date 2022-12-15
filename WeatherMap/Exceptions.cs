// ReSharper disable RedundantUsingDirective
using System.Linq;
using System.Windows.Forms;
using System;
using System.Threading;
using WeatherMap.OpenWeatherMapClasses;

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
    public class FormNotOpenedException : Exception
    {
        public FormNotOpenedException()
        {
        }
        public FormNotOpenedException(string message) : base(message)
        {
        }
        public FormNotOpenedException(string message, Exception inner) : base(message, inner)
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
    public class AppOnCloseException : Exception
    {
        public AppOnCloseException()
        {
        }
        public AppOnCloseException(string message) : base(message)
        {
        }
        public AppOnCloseException(string message, Exception inner) : base(message, inner)
        {
        }
    }
    public class BadResponseException : Exception
    {
        public BadResponseException()
        {
        }
        public BadResponseException(string message) : base(message)
        {
        }
        public BadResponseException(string message, Exception inner) : base(message, inner)
        {
        }
    }

    public class Exceptions
    {
        public void ValidateJsonAnswer(QueryResponse jsonData)
        {
            if (!jsonData.ValidRequest) throw new BadResponseException("404 Not found.");
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
                    throw new AppOnCloseException("App can not be closed.");
                }
            }
            else
            {
                e.Cancel = true;
            }
        }

        public DialogResult OpenFormSafely(Form f) 
        {
            try
            {
                return f.ShowDialog() == DialogResult.OK ? DialogResult.OK : DialogResult.Cancel;
            }
            catch (Exception) 
            {
                throw new FormNotOpenedException("Form not opened.");
            }
        }
    }
}