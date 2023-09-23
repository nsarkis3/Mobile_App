namespace MyFirst;

public class NewPage2 : ContentPage
{
	Entry entry;
	Button button;
	Picker picker;
	VerticalStackLayout vs;
	public NewPage2()
	{
		entry = new Entry();
		button = new Button { Text = "Add" };
		picker = new Picker { WidthRequest = 200 };
		picker.Items.Add("A");
		picker.Items.Add("B");
		picker.Items.Add("C");
		vs = new VerticalStackLayout {
			Children = {
					entry, button, picker
			}
		};

		button.Clicked += ButtonClicked;
		Content = vs;
	}
	//describe how to make a new page and display to user for quiz
	private void ButtonClicked(object sender, EventArgs e) {
		Label newLabel = new Label { Text = entry.Text };
		vs.Children.Add(newLabel);
		entry.Text = "";
	}
}

