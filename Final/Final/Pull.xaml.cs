namespace Final;

public partial class Pull : ContentPage
{
	public Pull()
	{
		InitializeComponent();
	}

    private async void Score_Clicked(object sender, EventArgs e)
    {
		await Navigation.PopModalAsync();
    }
}