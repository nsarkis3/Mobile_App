using System.Collections.ObjectModel;

namespace OlympicsMauiApp;


public partial class AthletesPage : ContentPage
{
    public string origin = null;
    public string sportPlayed = null;
    public string eventPlayed = null;
    public ObservableCollection<Participant2016Summer> players { get; set; }

    public AthletesPage()
    {
        InitializeComponent();
        var participants = DB.conn.Table<Participant2016Summer>();
        players = new ObservableCollection<Participant2016Summer>(DB.conn.Table<Participant2016Summer>());
        IEnumerable<Object> countries = participants.Select(p => p.Country).Distinct().OrderBy(cntry => cntry);
        Country.ItemsSource = countries?.ToList();

        IEnumerable<Object> sports = participants.Select(p => p.Sport).Distinct().OrderBy(sprt => sprt);
        Category.ItemsSource = sports?.ToList();
    }

    private void Country_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        origin = e.SelectedItem.ToString();

        Update_Athletes(origin, sportPlayed, eventPlayed);
    }

    private void Category_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        var participants = DB.conn.Table<Participant2016Summer>();
        sportPlayed = e.SelectedItem.ToString();

        IEnumerable<Object> events = participants.Select(p => p.Event).Where(eve => eve.Contains(sportPlayed)).
            Distinct().OrderBy(eve => eve);
        Event.ItemsSource = events?.ToList();

        Update_Athletes(origin, sportPlayed, eventPlayed);
    }

    private void Event_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        eventPlayed = e.SelectedItem.ToString();
        Update_Athletes(origin, sportPlayed, eventPlayed);
    }

    private async void Athletes_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        string name = e.SelectedItem.ToString();
        string events = "";
        IEnumerable<Object> participated = players.Where(p => p.Name == name)
            .Select(p => p.Event).ToList();
        foreach(string str in participated)
        {
            events += str + '\n';
        }

        await DisplayAlert(name, events, "Ok");
    }

    private void Update_Athletes(string country, string sport, string eventIn)
    {
        if (country == null || sport == null || eventIn == null) return;

        //var participants = DB.conn.Table<Participant2016Summer>();
        //IEnumerable<Object> people = players.Where(p => p.Country == country && p.Sport == sport && p.Event == eventIn)
        //    .OrderByDescending(p => p.Medal).Select(p => p.Name);
        //Athletes.ItemsSource = people.ToList();
        Athletes.ItemsSource = players.Where(p => p.Country == country && p.Sport == sport && p.Event == eventIn)
            .OrderByDescending(p => p.Medal).Select(p => p).ToList();
    }
}