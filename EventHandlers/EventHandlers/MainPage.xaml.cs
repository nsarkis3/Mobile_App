namespace EventHandlers;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
        thePicker.SelectedIndex = 0;
    }

	private void TheButton_Clicked(object sender, EventArgs e) {
		count++;
		buttonLabel.Text = count.ToString();
	}

	private void TheEntry_TextChanged(object sender, TextChangedEventArgs e) {
		entryLabel.Text = theEntry.Text;
	}

    private void theSlider_ValueChanged(object sender, ValueChangedEventArgs e)
    {
		sliderLabel.Text = theSlider.Value.ToString();
    }

    private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
		checkBoxLabel.Text = theCheckBox.IsChecked.ToString();
    }

    private void theSwitch_Toggled(object sender, ToggledEventArgs e)
    {
		switchLabel.Text = theSwitch.IsToggled.ToString();
    }

    private void theStepper_ValueChanged(object sender, ValueChangedEventArgs e)
    {
		stepperLabel.Text = theStepper.Value.ToString();
    }

    private void thePicker_SelectedIndexChanged(object sender, EventArgs e)
    {
		pickerLabel.Text = thePicker.SelectedItem.ToString();
        pickerLabel.TextColor = Color.Parse(thePicker.SelectedItem.ToString());
    }
}

