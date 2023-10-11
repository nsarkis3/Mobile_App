namespace ExerciseNavigation;

public partial class Units : ContentPage
{
	public Units()
	{
		InitializeComponent();
        base.OnAppearing();

        if (Preferences.ContainsKey("IsSwitchOn"))
        {
            MetricSwitch.IsToggled = Preferences.Get("IsSwitchOn", false);
        }
    }

    private void MetricSwitch_Toggled(object sender, ToggledEventArgs e)
    {
        Preferences.Set("IsSwitchOn", e.Value);
    }
}