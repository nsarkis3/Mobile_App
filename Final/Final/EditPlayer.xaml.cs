namespace Final;

public partial class EditPlayer : ContentPage
{
	public EditPlayer()
	{
		InitializeComponent();
	}

    private async void Finish_Clicked(object sender, EventArgs e)
    {
		await Navigation.PopModalAsync();
    }
}