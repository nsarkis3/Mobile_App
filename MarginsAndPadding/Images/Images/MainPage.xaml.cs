using System.Collections.ObjectModel;

namespace Images;

public partial class MainPage : ContentPage
{
	ObservableCollection<Person> people;
	public MainPage()
	{
		InitializeComponent();
		people = new ObservableCollection<Person>();
		people.Add(new Person { Name = "Mack", Borough = "Queens" });
		people.Add(new Person { Name = "Maria", Borough = "Manhatten" });
		people.Add(new Person { Name = "Chris", Borough = "Bronx" });
		lv_people.ItemsSource = people;
	}

	private void ImageButton_Clicked(object sender, EventArgs e) {
		label.Text = "clicked";
	}
}

