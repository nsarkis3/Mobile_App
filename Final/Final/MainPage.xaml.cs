using Final.ViewModels;
using Plugin.Maui.Audio;
using System.Collections.ObjectModel;

namespace Final
{
    public partial class MainPage : ContentPage
    {
        private TimerViewModel gameClock;
        private Line activeLine;
        private readonly IAudioManager audioManager;

        public MainPage(IAudioManager AudioManager)
        {
            InitializeComponent();
            activeLine = new Line();
            lv.ItemsSource = activeLine.Players.ToList();
            DB.ResetPlayers();
            this.audioManager = AudioManager;
            gameClock = new TimerViewModel(audioManager);
            BindingContext = gameClock;

        }

        private async void SetUp_Clicked(object sender, EventArgs e)
        {
            SetUpLines setUp = new SetUpLines(activeLine);
            await Navigation.PushModalAsync(setUp);
            activeLine = await setUp.ShowAsyncLine();
            name.Text = "Active Line: " + activeLine.LineName;
            lv.ItemsSource = activeLine.Players;
        }

        private async void Pull_Clicked(object sender, EventArgs e)
        {
            if (activeLine.Players.Count != 7)
            {
                await DisplayAlert("Invalid Line", "You do not have a valid line set," +
                " please set a line by clicking Set Line", "Okay");
            }
            else
            {
                await Navigation.PushModalAsync(new Pull(activeLine));
            }
        }

        private async void Stats_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Stats());
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            lv.ItemsSource = activeLine.Players.ToList();
        }

        private void TimerEvent(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            if (clickedButton.Text == "Start")
            {
                gameClock.startTimer();
                Start.IsEnabled = false;
                Half.IsEnabled = true;
            }
            else if (clickedButton.Text == "Half")
            {
                gameClock.halfTime();
                Half.IsEnabled = false;
                End.IsEnabled = true;
            }
            else
            {
                gameClock.startSecondHalf();
                End.IsEnabled = false;
            }
        }

        private async void Wipe_Clicked(object sender, EventArgs e)
        {
            bool clear = await DisplayAlert("Erase Team", "Are you sure you would like to wipe all" +
                " players from your roster, this cannot be undone" , "Yes", "No");
            if (clear)
            {
                DB.Clear();
                activeLine = new Line();
                lv.ItemsSource = activeLine.Players.ToList();
            }
        }
    }
}