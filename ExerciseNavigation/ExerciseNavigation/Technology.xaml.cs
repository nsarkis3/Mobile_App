namespace ExerciseNavigation;

public partial class Technology : ContentPage
{
    List<string> strings;
    public Technology()
	{
		InitializeComponent();
        strings = new List<string>();
        strings.Add("XAML");
        strings.Add("C#");
        strings.Add("Maui");
        strings.Add("JSON");
        strings.Add("Asynchronus Programing");
        lv.ItemsSource = strings;
    }

    private async void lv_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        await Navigation.PushAsync(new TechType(lv.SelectedItem.ToString()));
    }
}