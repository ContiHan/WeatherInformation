using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace WeatherInformation.model
{
    internal class SqlDataAccess
    {
        private const string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\danie\OneDrive\Dokumenty\C#\WeatherInformation\database\WeatherDB.mdf;Integrated Security=True";

        public void AddToSqlDb(WeatherInfo.Root weatherData)
        {
            using (IDbConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Query(
                    $"INSERT INTO dbo.[WeatherInfo](City, Temperature)" +
                    $"VALUES('{weatherData.Name}', {weatherData.Main.Temp.ToString().Replace(',', '.')})");
            }
        }
    }
}