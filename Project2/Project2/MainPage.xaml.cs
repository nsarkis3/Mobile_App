using System;

namespace Project2;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        modePicker.SelectedIndex = 2;
    }

    private void Seven_Clicked(object sender, EventArgs e)
    {
        if (Display.Text == "0") Display.Text = "7";
        else Display.Text += "7";
        calculateValues();
    }

    private void Eight_Clicked(object sender, EventArgs e)
    {
        if (Display.Text == "0") Display.Text = "8";
        else Display.Text += "8";
        calculateValues();
    }

    private void Nine_Clicked(object sender, EventArgs e)
    {
        if (Display.Text == "0") Display.Text = "9";
        else Display.Text += "9";
        calculateValues();
    }

    private void Four_Clicked(object sender, EventArgs e)
    {
        if (Display.Text == "0") Display.Text = "4";
        else Display.Text += "4";
        calculateValues();
    }

    private void Five_Clicked(object sender, EventArgs e)
    {
        if (Display.Text == "0") Display.Text = "5";
        else Display.Text += "5";
        calculateValues();
    }

    private void Six_Clicked(object sender, EventArgs e)
    {
        if (Display.Text == "0") Display.Text = "6";
        else Display.Text += "6";
        calculateValues();
    }

    private void One_Clicked(object sender, EventArgs e)
    {
        if (Display.Text == "0") Display.Text = "1";
        else Display.Text += "1";
        calculateValues();
    }

    private void Two_Clicked(object sender, EventArgs e)
    {
        if (Display.Text == "0") Display.Text = "2";
        else Display.Text += "2";
        calculateValues();
    }

    private void Three_Clicked(object sender, EventArgs e)
    {
        if (Display.Text == "0") Display.Text = "3";
        else Display.Text += "3";
        calculateValues();
    }

    private void Zero_Clicked(object sender, EventArgs e)
    {
        if (!(Display.Text == "0")) Display.Text += "0";
        calculateValues();
    }

    private void A_Clicked(object sender, EventArgs e)
    {
        if (Display.Text == "0") Display.Text = "A";
        else Display.Text += "A";
        calculateValues();
    }

    private void B_Clicked(object sender, EventArgs e)
    {
        if (Display.Text == "0") Display.Text = "B";
        else Display.Text += "B";
        calculateValues();
    }

    private void C_Clicked(object sender, EventArgs e)
    {
        if (Display.Text == "0") Display.Text = "C";
        else Display.Text += "C";
        calculateValues();
    }

    private void D_Clicked(object sender, EventArgs e)
    {
        if (Display.Text == "0") Display.Text = "D";
        else Display.Text += "D";
        calculateValues();
    }

    private void E_Clicked(object sender, EventArgs e)
    {
        if (Display.Text == "0") Display.Text = "E";
        else Display.Text += "E";
        calculateValues();
    }

    private void F_Clicked(object sender, EventArgs e)
    {
        if (Display.Text == "0") Display.Text = "F";
        else Display.Text += "F";
        calculateValues();
    }

    private void Clear_Clicked(object sender, EventArgs e)
    {
        Display.Text = "0";
        calculateValues();
    }

    private void Delete_Clicked(object sender, EventArgs e)
    {
        if (Display.Text.Length == 1)
        {
            Display.Text = "0";
        }
        else
        {
            Display.Text = Display.Text.Substring(0, Display.Text.Length - 1);
        }
        calculateValues();
    }
    
    private void calculateValues()
    {
        if (modePicker.SelectedIndex == 0)
        {
            binaryLabel.Text = Display.Text;
            int value = Convert.ToInt32(Display.Text, 2);
            decimalLabel.Text = value.ToString();
            octalLabel.Text = Convert.ToString(value, 8);
            hexLabel.Text = Convert.ToString(value, 16);
        }

        if (modePicker.SelectedIndex == 1)
        {
            octalLabel.Text = Display.Text;
            int value = Convert.ToInt32(Display.Text, 8);
            binaryLabel.Text = Convert.ToString(value, 2);
            decimalLabel.Text = value.ToString();
            hexLabel.Text = Convert.ToString(value, 16);
        }

        if (modePicker.SelectedIndex == 2)
        {
            decimalLabel.Text = Display.Text;
            int value = Convert.ToInt32(Display.Text, 10);
            binaryLabel.Text = Convert.ToString(value, 2);
            octalLabel.Text = Convert.ToString(value, 8);
            hexLabel.Text = Convert.ToString(value, 16);
        }

        if (modePicker.SelectedIndex == 3)
        {
            hexLabel.Text = Display.Text;
            int value = Convert.ToInt32(Display.Text, 16);
            decimalLabel.Text = value.ToString();
            binaryLabel.Text = Convert.ToString(value, 2);
            octalLabel.Text = Convert.ToString(value, 8);
        }
    }

    private void modePicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        List<Button> allButtons = new List<Button>() {
            Two, Three, Four, Five, Six, Seven, Eight, Nine,
            A, B, C, D, E, F
        };
        disableButton(allButtons);

        if (modePicker.SelectedIndex >= 0)
        {
            List<Button> binaryButtons = new List<Button>() { 
                Zero, One
            };
            enableButton(binaryButtons);
        }

        if (modePicker.SelectedIndex >= 1)
        {
            List<Button> octalButtons = new List<Button>() {
                Two, Three, Four, Five, Six, Seven
            };
            enableButton(octalButtons);
        }

        if (modePicker.SelectedIndex >= 2)
        {
            List<Button> decimalButtons = new List<Button>() {
                Eight, Nine
            };
            enableButton(decimalButtons);
        }

        if (modePicker.SelectedIndex >= 3)
        {
            List<Button> hexButtons = new List<Button>() {
                A, B, C, D, E, F
            };
            enableButton(hexButtons);
        }

        Display.Text = "0";
        binaryLabel.Text = "0";
        octalLabel.Text= "0";
        decimalLabel.Text= "0";
        hexLabel.Text= "0";
    }
    private void disableButton(List<Button> btn)
    {
        foreach (Button button in btn)
        {
            button.IsEnabled = false;
            button.BackgroundColor = Colors.LightGray;
            button.TextColor = Colors.Black;
        }
    }
    private void enableButton(List<Button> btn)
    {
        foreach (Button button in btn)
        {
            button.TextColor = Colors.White;
            button.BackgroundColor = Colors.Blue;
            button.IsEnabled = true;
        }
    }
}