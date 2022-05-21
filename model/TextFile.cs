using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherInformation.model
{
    internal class TextFile : IDataManager
    {
        public void Load(string path)
        {
            throw new NotImplementedException();
        }

        public void Save(WeatherInfo.Root weatherData, string path)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                WriteToFile(weatherData, sw);
            }
        }

        public void AppendAndSave(WeatherInfo.Root weatherData, string path)
        {
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                WriteToFile(weatherData, sw);
            }
        }

        private void WriteToFile(WeatherInfo.Root weatherData, StreamWriter sw)
        {
            sw.WriteLine($"City: {weatherData.Name}");
            sw.WriteLine($"Latitude: {weatherData.Coord.Lat}");
            sw.WriteLine($"Longitude: {weatherData.Coord.Lon}");
            sw.WriteLine($"Date: {weatherData.DateTime}");
            sw.WriteLine($"Temperature: {weatherData.Main.Temp}°C");
            weatherData.Weather.ForEach(data => sw.WriteLine($"Status: {data.Main}"));
        }
    }
}