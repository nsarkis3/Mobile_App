using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Zipcode;

public partial class MainPage : ContentPage
{
    RestService _restService;
    ObservableCollection<Place> data;
    public MainPage()
    {
		InitializeComponent();
        _restService = new RestService();
        data = new ObservableCollection<Place>();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        data = new ObservableCollection<Place>();
        if (!string.IsNullOrWhiteSpace(cityEntry.Text) && !string.IsNullOrWhiteSpace(stateEntry.Text))
        {
            string uriRequest = GenerateRequestUri(Constants.ZipEndpoint, cityEntry.Text, stateEntry.Text);
            ZipCode zipData = await _restService.GetZipCodeData(uriRequest);
            foreach(Place place in zipData.places)
            {
                data.Add(place);
            }
            lv.ItemsSource = data;
        }
    }

    string GenerateRequestUri(string endpoint, string city, string state)
    {
        string requestUri = endpoint;
        requestUri += $"{state}/{city}";
        return requestUri;
    }
}

