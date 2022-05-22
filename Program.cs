using Topshelf;
using WeatherInformation.model;
using WeatherInformation.service;

//string apiKey = "a7bf257916dee56198a99ce95aaef81d";
//string city = "Hradec Králové";
//string url = string.Format("https://api.openweathermap.org/data/2.5/weather?q={0}&APPID={1}&units=metric", city, apiKey);
//string filePath = @"..\..\..\data.txt";

//DataHandler dataHandler = new();
//DataHandler dataHandlerPraha = new(city: "Praha");
//DataHandler dataHandlerLiberec = new(city: "Liberec");
//DataHandler dataHandlerHribojedy = new(city: "Hřibojedy");
//WeatherInfo.Root weatherData = dataHandler.GetWeatherDataAsObject();

//Console.WriteLine(weatherData.FullInfo);

//TextFile dataManager = new();
//dataManager.Save(weatherData, @"..\..\..\pokus_textfile.txt");
//Console.WriteLine();

//weatherData = dataHandlerPraha.GetWeatherDataAsObject();
//Console.WriteLine($"City: {weatherData.Name}");
//Console.WriteLine(dataHandlerPraha.GetWeatherDataAsCsv());
//dataManager.AppendAndSave(weatherData, @"..\..\..\pokus_textfile.txt");
//Console.WriteLine();

//weatherData = dataHandlerLiberec.GetWeatherDataAsObject();
//Console.WriteLine($"City: {weatherData.Name}");
//Console.WriteLine(dataHandlerLiberec.GetWeatherDataAsCsv());
//dataManager.AppendAndSave(weatherData, @"..\..\..\pokus_textfile.txt");
//Console.WriteLine();

//weatherData = dataHandlerHribojedy.GetWeatherDataAsObject();
//Console.WriteLine($"City: {weatherData.Name}");
//Console.WriteLine(dataHandlerHribojedy.GetWeatherDataAsCsv());
//dataManager.AppendAndSave(weatherData, @"..\..\..\pokus_textfile.txt");
//Console.WriteLine();

//Console.WriteLine(new DataHandler(city: "Brandýs nad Labem").GetWeatherDataAsCsv());
//new SqlDataAccess().AddToSqlDb(weatherData = dataHandlerLiberec.GetWeatherDataAsObject());
//Console.WriteLine();

WinService();

static void WinService()
{
    var exitCode = HostFactory.Run(x =>
    {
        x.Service<WeatherInfoService>(s =>
        {
            s.ConstructUsing(WeatherInfo => new WeatherInfoService());
            s.WhenStarted(WeatherInfo => WeatherInfo.Start());
            s.WhenStopped(WeatherInfo => WeatherInfo.Stop());
        });

        x.RunAsLocalSystem();

        x.SetServiceName("WeatherInfoService");
        x.SetDisplayName("WeatherInfo Service");
        x.SetDescription("This service logs temperature from weather API to local database");
    });

    int exitCodeValue = (int)Convert.ChangeType(exitCode, exitCode.GetTypeCode());
    Environment.ExitCode = exitCodeValue;
}