using System.Collections.ObjectModel;

namespace ListViewXAML;

public partial class AddingStringsPage : ContentPage
{
	private List<string> standardList1;
	private List<string> standardList2;
	private ObservableCollection<string> observableCollection;
	public AddingStringsPage()
	{
		InitializeComponent();
		standardList1 = new List<string>();
		standardList2 = new List<string>();
		observableCollection = new ObservableCollection<string>();
		foreach (string s in new string[] { "A", "B" }) {
			standardList1.Add(s);
			standardList2.Add(s);
			observableCollection.Add(s);
		}
		lv1.ItemsSource = standardList1;
		lv2.ItemsSource = standardList2;
		lv3.ItemsSource = observableCollection;
	}

	private void ButtonClicked(object sender, EventArgs e) {
		standardList1.Add(entry.Text);
		standardList2.Add(entry.Text);
		lv2.ItemsSource = new List<string>(standardList2);
		observableCollection.Add(entry.Text);
    }
}