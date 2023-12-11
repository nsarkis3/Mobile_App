namespace Final;

public partial class Stats : ContentPage
{
	public Stats()
	{
		InitializeComponent();
		lv.ItemsSource = DB.GetAllPlayers();
	}

    private async void Exit_Clicked(object sender, EventArgs e)
    {
		await Navigation.PopModalAsync();
    }

    private async void Top_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new Details());
    }
}