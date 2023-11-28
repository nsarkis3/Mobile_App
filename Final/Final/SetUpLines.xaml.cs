namespace Final;

public partial class SetUpLines : ContentPage
{
	public SetUpLines()
	{
        InitializeComponent();
        lv.ItemsSource = DB.GetAllPlayers();
	}

    private async void AddPlayer_Clicked(object sender, EventArgs e)
    {
		await Navigation.PushModalAsync(new EditPlayer());
    }

    private async void Finish_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }

    private async void lv_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        Player selectedPlayer = (Player)lv.SelectedItem;
        bool result = await DisplayAlert("Warning", "Do you wish to delete Player: " 
            + selectedPlayer.Name + "?", "Yes", "No");
        if (result)
        {
            DB.DeletePlayer(selectedPlayer);
        }
        lv.ItemsSource = DB.GetAllPlayers();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        lv.ItemsSource = DB.GetAllPlayers();
    }
}