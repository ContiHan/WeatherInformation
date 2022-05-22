using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherInformation.model
{
    internal class SqlData
    {
        public int Id { get; set; }
        public string City { get; set; }
        public double Temperature { get; set; }
        public string FullInfo
        {
            get => $"City: {City}\nTemperature: {Temperature}°C\n";
        }
    }
}
