using System.Collections.ObjectModel;

namespace ListViewXAML;

public partial class ObjectPage : ContentPage
{
	ObservableCollection<School> schools;
	public ObjectPage()
	{
		InitializeComponent();
		schools = new ObservableCollection<School>();
		schools.Add(new School { Name = "MU", SchoolColor = Colors.Red, School2ndColor = Colors.White, WebsiteURL = "https://www.miamioh.edu" });
		schools.Add(new School { Name = "OSU", SchoolColor = Colors.Gray, School2ndColor = Colors.Red, WebsiteURL = "https://www.osu.edu" });
		schools.Add(new School { Name = "UC", SchoolColor = Colors.Black, School2ndColor = Colors.Black, WebsiteURL = "https://www.uc.edu" });
		schools.Add(new School { Name = "Ohio U", SchoolColor = Colors.Green, School2ndColor = Colors.Black, WebsiteURL = "https://www.ohio.edu" });
		schools.Add(new School { Name = "BGSU", SchoolColor = Colors.Orange, School2ndColor = Colors.SaddleBrown, WebsiteURL = "https://www.bgsu.edu" });
		lv.ItemsSource = schools;
		lv.SelectedItem = schools[0];
		lv_ItemTapped(null, null);
	}

	private void lv_ItemTapped(object sender, ItemTappedEventArgs e) {
		School school = lv.SelectedItem as School;
		if (school == null) {
			return;
		}
		label.Text = school.Name;
		webview.Source = school.WebsiteURL;
    }
}