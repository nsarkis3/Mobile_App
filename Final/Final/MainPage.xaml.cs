using Final.ViewModels;
using System.Collections.ObjectModel;

namespace Final
{
    public partial class MainPage : ContentPage
    {
        private TimerViewModel gameClock;
        public MainPage()
        {
            InitializeComponent();
            lv.ItemsSource = DB.GetAllPlayers();
            gameClock = new TimerViewModel();
            BindingContext = gameClock;
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
        protected override void OnAppearing()
        {
            base.OnAppearing();
            lv.ItemsSource = DB.GetAllPlayers();
        }

        private void TimerEvent(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            if(clickedButton.Text == "Start") gameClock.startTimer();
            else if(clickedButton.Text == "Half") gameClock.halfTime();
            else gameClock.startSecondHalf();
        }
    }
}