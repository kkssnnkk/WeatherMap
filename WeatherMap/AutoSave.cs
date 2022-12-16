using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace WeatherMap
{
    internal class AutoSave
    {
        private DataToSave _dataToSave;
        private readonly BinaryFormatter _formatter = new BinaryFormatter();


        [Serializable]
        public struct DataToSave
        {
            public string SearchField;
            public bool English;
            public bool Ukrainian;
            public bool Light;
            public bool Dark;
            public int FontSize;
        };

        public DataToSave GetSaveDataStructure() { return _dataToSave; }

        public void SaveAppState(DataToSave dataToSave)
        {
            _dataToSave = dataToSave;
            try
            {
                byte[] data;

                using (var ms = new MemoryStream())
                {
                    _formatter.Serialize(ms, _dataToSave);
                    ms.Seek(0, SeekOrigin.Begin);
                    data = ms.ToArray();
                }

                using (var bin = new BinaryWriter(File.Open("configuration.bin", FileMode.OpenOrCreate), System.Text.Encoding.UTF8, false))
                {
                    bin.Write(data);
                }
            }
            catch (Exception) { Console.WriteLine(@"Error writing config file."); }
        }

        public DataToSave GetAppLastState()
        {
            try
            {
                var fs = File.Open("configuration.bin", FileMode.Open);
                var data = _formatter.Deserialize(fs);
                _dataToSave = (DataToSave)data;
                fs.Flush();
                fs.Close();
                fs.Dispose();
            }
            catch (Exception) { Console.WriteLine(@"Error reading config file."); }

            return _dataToSave;
        }
    }
}