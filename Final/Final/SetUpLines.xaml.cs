namespace Final;

public partial class SetUpLines : ContentPage
{
	public SetUpLines()
	{
		InitializeComponent();
	}

    private async void AddPlayer_Clicked(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new EditPlayer());
    }

    private async void Finish_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }
}