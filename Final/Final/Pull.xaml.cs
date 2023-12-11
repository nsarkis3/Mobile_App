namespace Final;

public partial class Pull : ContentPage
{
	Button lastClickedButton;
    Button clear;
	Line activeLine;
	public Pull(Line line)
	{
		InitializeComponent();
		activeLine = line;
        Possesion.Text = activeLine.LineName;
		Player1.Text = activeLine.Players[0].Name;
		Player2.Text = activeLine.Players[1].Name;
		Player3.Text = activeLine.Players[2].Name;
		Player4.Text = activeLine.Players[3].Name;
		Player5.Text = activeLine.Players[4].Name;
		Player6.Text = activeLine.Players[5].Name;
		Player7.Text = activeLine.Players[6].Name;
	}

    private async void Score_Clicked(object sender, EventArgs e)
    {
		await Navigation.PopModalAsync();
    }

    private void Player_Clicked(object sender, EventArgs e)
    {
        Button clickedButton = (Button)sender;

        if (lastClickedButton != null)
        {
            if (clear != null) 
            {
                if (clear.BackgroundColor == Colors.Silver) clear.BackgroundColor = Colors.DarkBlue;
            }
            
            if (lastClickedButton.BackgroundColor == Colors.Gold)
            {
                // If the last clicked button was gold, change it to silver
                lastClickedButton.BackgroundColor = Colors.Silver;
                clear = lastClickedButton;
                Player thrower = activeLine.Players.First(p => p.Name == lastClickedButton.Text.ToString());
                thrower.Completions += 1;
                Player catcher = activeLine.Players.First(p => p.Name == clickedButton.Text.ToString());
                DB.UpdatePlayerStat(catcher, "Catch");
                DB.UpdatePlayerStat(thrower, "Completion");                
            }
        }
        clickedButton.BackgroundColor = Colors.Gold;
        lastClickedButton = clickedButton;
    }

    private void CustomAction(object sender, EventArgs e)
    {
        Button clickedButton = (Button)sender;
        if (clickedButton.Text.ToString() == "Thrown Away")
        {
            if (activeLine.LineName == "Offense" && lastClickedButton != null)
            {     
                Player thrower = activeLine.Players.First(p => p.Name == lastClickedButton.Text.ToString());
                thrower.ThrowAways += 1;
                DB.UpdatePlayerStat(thrower, "ThrowAway");
            }
        }
        else if (clickedButton.Text.ToString() == "Score")
        {
            if (activeLine.LineName == "Offense" && lastClickedButton != null)
            {
                Player catcher = activeLine.Players.First(p => p.Name == lastClickedButton.Text.ToString());
                catcher.Points += 1;
                DB.UpdatePlayerStat(catcher, "Score");
            }
            Navigation.PopModalAsync();
        }
    }
}