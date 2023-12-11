using System.Runtime.ExceptionServices;

namespace Final;

public partial class EditPlayer : ContentPage
{
	public EditPlayer()
	{
		InitializeComponent();
        Year.SelectedIndex = 1;
        Position.SelectedIndex = 1;
	}

    private async void Finish_Clicked(object sender, EventArgs e)
    {
        Button clickedButton = (Button)sender;
        if(clickedButton.Text == "Save")
        {
            if(First.Text == null || Last.Text == null) 
            {
                await DisplayAlert("Missing Name", "Please enter a name", "Okay");
            }
            else
            {
                Player newPlayer = new Player(First.Text + " " + Last.Text,
                    Year.SelectedItem.ToString(), Position.SelectedItem.ToString());
                DB.InsertPlayer(newPlayer);
                First.Placeholder = "First Name";
                Last.Placeholder = "Last Name";
                Year.SelectedIndex = 0;
                Position.SelectedIndex = 0;
                await Navigation.PopModalAsync();
            }
        }
        else
        {
            First.Placeholder = "First Name";
            Last.Placeholder = "Last Name";
            Year.SelectedIndex = 0;
            Position.SelectedIndex = 0;
            await Navigation.PopModalAsync();
        }
    }
}