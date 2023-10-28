namespace SymptomTracker;

public partial class TimePopup : ContentPage
{
    private Button selectedButton = null;
    TaskCompletionSource<DateTime> tcs;
    public TimePopup(DateTime template)
    {
        InitializeComponent();
        string[] data = template.ToString("h mm").Split(' ');
        Hours.Text = data[0];
        Minutes.Text = data[1];
        bool selected = false;
        foreach (View child in gridClock.Children)
        {
            if (child is Button button && int.Parse(button.ClassId) == int.Parse(Hours.Text.ToString()))
            {
                selectedButton = button;
                selected = true;
            }
        }
        if(!selected)
        {
            selectedButton = OnHour;
        }
        setColor("select");

    }
    public Task<DateTime> ShowAsyncTime()
    {
        tcs = new TaskCompletionSource<DateTime>();
        return tcs.Task;
    }
    private async void Exit(object sender, EventArgs e)
    {
        Button clickedButton = (Button)sender;
        if (clickedButton.Text != "Cancel")
        {
            int afternoon = 0;
            int hours = int.Parse(Hours.Text);
            if (am.IsEnabled && hours != 12) afternoon = 12; 
            else if (pm.IsEnabled && hours == 12) hours = 0;
            DateTime ret = new DateTime(2000, 5, 5, hours + afternoon, int.Parse(Minutes.Text), 0);
            tcs.SetResult(ret);
        }
        await Navigation.PopModalAsync();
    }
    private void flip(object sender, EventArgs e)
    {
        Button clickedButton = (Button)sender;

        if (clickedButton == am)
        {
            am.IsEnabled = false;
            am.Opacity = 1;
            pm.IsEnabled = true;
            pm.Opacity = 0.5;
        }
        else if (clickedButton == pm)
        {
            am.IsEnabled = true;
            am.Opacity = 0.5;
            pm.IsEnabled = false;
            pm.Opacity = 1;
        }
    }

    private void valueClicked(object sender, EventArgs e)
    {
        setColor("reset");
        selectedButton = (Button)sender;
        setColor("select");

        if (!Hours.IsEnabled) Hours.Text = selectedButton.Text;
        else Minutes.Text = selectedButton.Text;
    }

    private void setColor(string option)
    {
        if (option == "select")
        {
            selectedButton.BackgroundColor = Colors.DarkBlue;
            selectedButton.TextColor = Colors.White;
        } 
        else
        {
            selectedButton.BackgroundColor = Colors.Transparent;
            selectedButton.TextColor = Colors.Black;
        }
    }

    private void switchMode(object sender, EventArgs e)
    {
        Button clickedButton = (Button)sender;
        double scalar = 0;
        if (clickedButton.ClassId == "Minutes")
        {
            selectedButton.BackgroundColor = Colors.Transparent;
            selectedButton.TextColor = Colors.Black;
            scalar = 5;
            Hours.Opacity = 0.5;
            Hours.IsEnabled = true;
            Minutes.Opacity = 1;
            Minutes.IsEnabled = false;
            OnHour.Text = "00";
            fiveAfter.Text = "05";
        }
        else
        {
            scalar = 0.2;
            Hours.Opacity = 1;
            Hours.IsEnabled = false;
            Minutes.Opacity = 0.5;
            Minutes.IsEnabled = true;
            OnHour.Text = "12";
            fiveAfter.Text = "1";
        }
        foreach (var view in gridClock.Children)
        {
            if (view is Button button && button.Text != "12" && button.Text != "00" &&
                button.Text != "05" && button.Text != "1")
            {
                button.Text = (double.Parse(button.Text) * scalar).ToString();
            }
        }
    }
}