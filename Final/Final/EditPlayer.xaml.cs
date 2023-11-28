using System.Runtime.ExceptionServices;

namespace Final;

public partial class EditPlayer : ContentPage
{
	public EditPlayer()
	{
		InitializeComponent();
	}

    private async void Finish_Clicked(object sender, EventArgs e)
    {
        Button clickedButton = (Button)sender;
        if(clickedButton.Text == "Save")
        {
            Player newPlayer = new Player(First.Text + " " + Last.Text,
                Year.Text, Position.Text);
            DB.InsertPlayer(newPlayer);
        }
        First.Placeholder = "First Name";
        Last.Placeholder = "Last Name";
        Year.Placeholder = "School Year";
        Position.Placeholder = "Position";

        await Navigation.PopModalAsync();
    }
}