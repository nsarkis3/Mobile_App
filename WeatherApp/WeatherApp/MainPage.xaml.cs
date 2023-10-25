namespace WeatherApp;

using System.Collections.ObjectModel;

public partial class MainPage : ContentPage
{
    RestService _restService;
    ObservableCollection<WeatherData> data;

    public MainPage()
	{
		InitializeComponent();
        _restService = new RestService();
        data = new ObservableCollection<WeatherData>();
    }

    private async void OnGetWeatherButtonClicked(object sender, EventArgs e) {
        if (Constants.OpenWeatherMapAPIKey == "XXXX") {
            await DisplayAlert("APIKEY is not set", "Add your API key to Constants.cs", "OK");
        }
        if (!string.IsNullOrWhiteSpace(_cityEntry.Text)) {
            string[] cities = _cityEntry.Text.Split(',');
            data.Clear();
            foreach (string city in cities) {
                string uriRequest = GenerateRequestUri(Constants.OpenWeatherMapEndpoint, city);
                WeatherData weatherData = await _restService.GetWeatherData(uriRequest);
                if (weatherData != null)
                    data.Add(weatherData);
            }
            lv.ItemsSource = data;
        }
    }
    string GenerateRequestUri(string endpoint, string city) {
        string requestUri = endpoint;
        requestUri += $"?q={city}";
        requestUri += "&units=imperial"; // or units=metric
        requestUri += $"&APPID={Constants.OpenWeatherMapAPIKey}";
        return requestUri;
    }
}

