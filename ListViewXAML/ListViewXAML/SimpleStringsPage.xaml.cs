namespace ListViewXAML;

public partial class SimpleStringsPage : ContentPage
{
	List<string> strings;
	int[] tapped = new int[3];
	int[] selected = new int[3];
	public SimpleStringsPage()
	{
		InitializeComponent();
		strings = new List<string>();
		strings.Add("Red");
		strings.Add("Green");
		strings.Add("Blue");
		lv.ItemsSource = strings;
	}
	private int GetIndex(string str) {
		if (str == "Red")
			return 0;
		else if (str == "Green")
			return 1;
		else
			return 2;
	}
	private void lv_ItemTapped(object sender, ItemTappedEventArgs e) {
		int pos = GetIndex(lv.SelectedItem.ToString());
		tapped[pos]++;
		tappedLabel.Text = string.Format("Tapped: {0} {1} {2}", tapped[0], tapped[1], tapped[2]);
	}

	private void lv_ItemSelected(object sender, SelectedItemChangedEventArgs e) {
		int pos = GetIndex(lv.SelectedItem.ToString());
		selected[pos]++;
		selectedLabel.Text = string.Format("Selected: {0} {1} {2}", selected[0], selected[1], selected[2]);
	}
}