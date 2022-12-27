using System.Linq;
using System.Windows.Forms;
using System;
using System.Threading;
using WeatherMap.OpenWeatherMapClasses;
using System.Net.NetworkInformation;
using System.IO;

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
    public class ConnectionRefusedException : Exception
    {
        public ConnectionRefusedException()
        {
        }
        public ConnectionRefusedException(string message) : base(message)
        {
        }
        public ConnectionRefusedException(string message, Exception inner) : base(message, inner)
        {
        }
    }
    public class FileNotExistsException : Exception
    {
        public FileNotExistsException()
        {
        }
        public FileNotExistsException(string message) : base(message)
        {
        }
        public FileNotExistsException(string message, Exception inner) : base(message, inner)
        {
        }
    }

    public class Exceptions
    {
        public void ValidateJsonAnswer(QueryResponse jsonData)
        {
            if (!jsonData.ValidRequest) throw new BadResponseException("404 Not found.");
        }

        public void CheckCityCorrectnessByResponceCod(QueryResponse jsonData)
        {
            if (jsonData.Cod != 200) throw new BadResponseException("Cod " + jsonData.Cod.ToString());
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

        public void ConnectionIsAlive()
        {
            try
            {
                if (new Ping().Send("www.google.com", 10000).Status != IPStatus.Success)
                    throw new ConnectionRefusedException("Check your internet connection.");
            }
            catch (Exception)
            {
                throw new ConnectionRefusedException("Check your internet connection.");
            }
        }

        public void FileExists(string filepath)
        {
            try
            {
                if (!File.Exists(filepath)) throw new FileNotExistsException("File not found");
            }
            catch (Exception)
            {
                throw new FileNotExistsException("Unknown error while checking file path.");
            }
        }
    }
}