namespace Final;

public partial class Stats : ContentPage
{
	public Stats()
	{
		InitializeComponent();
	}

    private async void Exit_Clicked(object sender, EventArgs e)
    {
		await Navigation.PopModalAsync();
    }
}