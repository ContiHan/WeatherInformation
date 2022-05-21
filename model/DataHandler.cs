using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherInformation.model
{
    internal class DataHandler
    {
        private const string ApiKey = "a7bf257916dee56198a99ce95aaef81d";
        private const string Url = $"https://api.openweathermap.org/data/2.5/weather?q=Maroko&APPID={ApiKey}&units=metric";
        private const char Sep = ';';
        public string Data { get; set; }

        public DataHandler()
        {
            Data = GetDataFromUrl(Url);
        }

        public DataHandler(string url)
        {
            Data = GetDataFromUrl(url);
        }

        public DataHandler(string city = "Praha", string apiKey = ApiKey)
        {
            string url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&APPID={apiKey}&units=metric";
            Data = GetDataFromUrl(url);
        }

        public string GetWeatherDataAsCsv()
        {
            WeatherInfo.Root data = GetWeatherDataAsObject();
            return $"{data.Name}{Sep}{data.DateTime}{Sep}{data.Main.Temp}";
        }
        public WeatherInfo.Root GetWeatherDataAsObject()
        {
            return JsonConvert.DeserializeObject<WeatherInfo.Root>(Data);
        }

        private string GetDataFromUrl(string url)
        {
            using HttpClient client = new();
            return client.GetStringAsync(url).Result;
        }
    }
}