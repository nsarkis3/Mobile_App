using System.Collections.ObjectModel;

namespace Final
{
    public partial class MainPage : ContentPage
    {
        ObservableCollection<Player> players;
        public MainPage()
        {
            InitializeComponent();
            players = new ObservableCollection<Player>();
            players.Add(new Player("Nic Sarkis", "Senior", "Cutter"));
            players.Add(new Player("Alex Rintamaa", "Senior", "Handler"));
            players.Add(new Player("Carlo Vanni", "Junior", "Both"));
            lv.ItemsSource = players;
        }

        private async void SetUp_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new SetUpLines());
        }

        private async void Pull_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Pull());
        }

        private async void Stats_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Stats());
        }
    }
}