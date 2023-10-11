namespace ExerciseNavigation;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

    private async void Units_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Units());
    }

    private async void Technology_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Technology());
    }

    private async void Credits_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new Credits());
    }
}

