using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherInformation.model
{
    internal interface IDataManager
    {
        public void Save(WeatherInfo.Root weatherData, string path);
        public void Load(string path);
    }
}