namespace Prefs;

public partial class MainPage : ContentPage { 
	public MainPage() {
		InitializeComponent();

		if (!Preferences.ContainsKey("MetricMode"))
			Preferences.Set("MetricMode", false);
		metricSwitch.IsToggled = Preferences.Get("MetricMode", false);

        if (!Preferences.ContainsKey("DOB"))
            Preferences.Set("DOB", new DateTime(2000,01,01));
        DOB.Date = Preferences.Get("DOB", new DateTime(2000, 01, 01));

        if (!Preferences.ContainsKey("exp"))
            Preferences.Set("exp", 0.5);
        exp_slider.Value = Preferences.Get("exp", 0.5);
    }
	private void MetricSwitchToggled(object sender, ToggledEventArgs e) {
		Preferences.Set("MetricMode", metricSwitch.IsToggled);
	}

    private void DOB_DateSelected(object sender, DateChangedEventArgs e)
    {
		Preferences.Set("DOB", e.NewDate);
    }

    private void exp_slider_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        Preferences.Set("exp", e.NewValue);
        lab.Text = e.NewValue.ToString();
    }
}

