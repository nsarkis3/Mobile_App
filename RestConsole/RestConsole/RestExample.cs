using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using System.Diagnostics;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.VisualBasic;

namespace RestConsole;
public class RestExample {
    /*
	* Documentation on weather API: https://openweathermap.org/current
	* You will need to get your own keys:
	* https://home.openweathermap.org/users/sign_up
	*/

    public static string OpenWeatherMapEndpoint = "https://api.openweathermap.org/data/2.5/weather";
    // YOU WILL NEED TO REGISTER FROM YOUR OWN KEY AND INSERT THAT KEY INTO secrets.json
    public static string OpenWeatherMapAPIKey = "2e8f332e44a8fdfcee7175d0997ff647";

    public HttpClient client = new HttpClient();
    public string CreateWeatherQuery(string cityName, string units = "imperial") {
        string requestUri = OpenWeatherMapEndpoint;
        requestUri += $"?q={cityName}";
        requestUri += $"&units={units}";
        requestUri += $"&APPID={OpenWeatherMapAPIKey}";
        return requestUri;
    }
    public async Task<string?> GetWeatherQueryResult() {
        Console.Write("Enter a big US city: ");
        string? city = Console.ReadLine()?.Trim();
        if (city == null) {
            return null;
        }
        string query = CreateWeatherQuery(city);
        //string query = CreateWeatherQuery(city, "metric");

        string? result = null;

        try {
            var response = await client.GetAsync(query);
            if (response.IsSuccessStatusCode) {
                result = await response.Content.ReadAsStringAsync();
            }
        } catch (Exception ex) {
            Debug.WriteLine("\t\tERROR {0}", ex.Message);
            Environment.Exit(0);
        }

        return result;
    }
    public void ProcessWeatherQuery() {
        Task<string?> weatherTask = GetWeatherQueryResult();
        weatherTask.Wait();
        string? response = weatherTask.Result;
        if (response == null) {
            return;
        }
        WeatherData? weatherData = JsonConvert.DeserializeObject<WeatherData>(response);
        if (weatherData == null) {
            return;
        }
        Console.WriteLine("City:" + weatherData.City);
        Console.WriteLine("Temp:" + weatherData.Main?.Temperature);
        Console.WriteLine("Temp min:" + weatherData.Main?.TempMin);
        Console.WriteLine("Temp max:" + weatherData.Main?.TempMax);
        Console.WriteLine("Wind:" + weatherData.Wind?.Speed);
    }
    public static void Main(string[] args) {
        if (OpenWeatherMapAPIKey == "XXXX") {
            Console.WriteLine("Add your API key to the code");
            Environment.Exit(0);
        }
        RestExample rest = new RestExample();
        rest.ProcessWeatherQuery();
    }
}