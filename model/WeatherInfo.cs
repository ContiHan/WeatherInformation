using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherInformation.model
{
    internal class WeatherInfo
    {
        public class Coord
        {
            public double Lon { get; set; }
            public double Lat { get; set; }
        }

        public class Weather
        {
            public int Id { get; set; }
            public string Main { get; set; }
            public string Description { get; set; }
            public string Icon { get; set; }
        }

        public class Main
        {
            public double Temp { get; set; }
            public double FeelsLike { get; set; }
            public double Pressure { get; set; }
        }

        public class Root
        {
            public Coord Coord { get; set; }
            public List<Weather> Weather { get; set; }
            public Main Main { get; set; }
            public double Dt { get; set; }
            public string Name { get; set; }

            public DateTime DateTime
            {
                get => new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(Dt).ToLocalTime();
            }

            public string FullInfo
            {
                //get => $"City: {Name}\nDate: {DateTime}\nTemperature: {Main.Temp}\n" + Weather.ForEach(x => $"{x.Main}");
                get
                {
                    string value = $"City: {Name}\nDate: {DateTime}\nTemperature: {Main.Temp}°C\n";
                    Weather.ForEach(x => value += $"Status: {x.Main}");
                    return value;
                }
            }
        }
    }
}