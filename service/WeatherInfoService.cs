using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherInformation.model;

namespace WeatherInformation.service
{
    internal class WeatherInfoService
    {
        private readonly System.Timers.Timer timer;

        public WeatherInfoService()
        {
            timer = new(5 * 1000) { AutoReset = true };
            timer.Elapsed += TimerElapsed;
        }

        private void TimerElapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            new SqlDataAccess().AddToSqlDb(new DataHandler(city: "Hradec Králové").GetWeatherDataAsObject());
        }

        public void Start() { timer.Start(); }
        public void Stop() { timer.Stop(); }
    }
}
