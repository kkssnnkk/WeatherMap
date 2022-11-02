using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace WeatherMap
{
    internal class AutoSave
    {
        DataToSave dataToSave = new DataToSave();
        BinaryFormatter formatter = new BinaryFormatter();


        [SerializableAttribute]
        public struct DataToSave
        {
            public string language;
            public string theme;
            public int font_size;

            public string temperature;
            public string location;
            public string status;
            public string seacrh_field;
        };

        public DataToSave getSaveDataStructure() { return dataToSave; }

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
