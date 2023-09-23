namespace GridXAML;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

    private void Seven_Clicked(object sender, EventArgs e)
    {
        if (Display.Text == "0") Display.Text = "7";
        else Display.Text += "7";
    }

    private void Eight_Clicked(object sender, EventArgs e)
    {
        if (Display.Text == "0") Display.Text = "8";
        else Display.Text += "8";
    }

    private void Nine_Clicked(object sender, EventArgs e)
    {
        if (Display.Text == "0") Display.Text = "9";
        else Display.Text += "9";
    }

    private void Four_Clicked(object sender, EventArgs e)
    {
        if (Display.Text == "0") Display.Text = "4";
        else Display.Text += "4";
    }

    private void Five_Clicked(object sender, EventArgs e)
    {
        if (Display.Text == "0") Display.Text = "5";
        else Display.Text += "5";
    }

    private void Six_Clicked(object sender, EventArgs e)
    {
        if (Display.Text == "0") Display.Text = "6";
        else Display.Text += "6";
    }

    private void One_Clicked(object sender, EventArgs e)
    {
        if (Display.Text == "0") Display.Text = "1";
        else Display.Text += "1";
    }

    private void Two_Clicked(object sender, EventArgs e)
    {
        if (Display.Text == "0") Display.Text = "2";
        else Display.Text += "2";
    }

    private void Three_Clicked(object sender, EventArgs e)
    {
        if (Display.Text == "0") Display.Text = "3";
        else Display.Text += "3";
    }

    private void Zero_Clicked(object sender, EventArgs e)
    {
        if (!(Display.Text == "0")) Display.Text += "0";
    }

    private void Clear_Clicked(object sender, EventArgs e)
    {
        Display.Text = "0";
    }
}

