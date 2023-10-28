using Microsoft.VisualBasic;
using static SQLite.SQLite3;
using static System.Net.Mime.MediaTypeNames;

namespace SymptomTracker;

public partial class EditItem : ContentPage
{
    Symptom editSymptom;
    TaskCompletionSource<Symptom> tcs;
    List<string> labels = new List<string>();
    public EditItem(string method, Symptom template)
    {
        InitializeComponent();
        for (int i = 1; i <= 10; i++) labels.Add(i.ToString());
        lv.ItemsSource = labels;
        Edit.Text = method;
        editSymptom = template;
        dateButton.Text = editSymptom.Datetime.ToString("MM/dd/yyyy");
        timeButton.Text = editSymptom.Datetime.ToString("hh:mm tt");
        intensityButton.Text = template.Strength.ToString();
        notes.Text = template.Notes;
    }

    private async void ExitEdit(object sender, EventArgs e)
    {
        Button clicked = sender as Button;
        if (clicked.ClassId != "quit")
        {
            string[] dateData = (dateButton.Text.Split('/'));
            int hour = int.Parse(timeButton.Text.Substring(0, 2));
            if (editSymptom.Datetime.ToString("tt") == "PM" && hour != 12) hour += 12;
            if (editSymptom.Datetime.ToString("tt") == "AM" && hour == 12) hour = 0;
            DateTime symptomDate = new DateTime(int.Parse(dateData[2]), int.Parse(dateData[0]), int.Parse(dateData[1]), hour,
                int.Parse(timeButton.Text.Substring(3, 2)), 0);
            string symptomNotes = notes.Text;
            int symptomIntensity = int.Parse(intensityButton.Text);
            tcs.SetResult(new Symptom(symptomDate, symptomNotes, symptomIntensity));
            await Navigation.PopModalAsync();
        } 
        else if (clicked.ClassId == "quit" && Edit.Text == "Update") 
        {
            bool result = await DisplayAlert("Warning", "Do you wish to discard these changes?", "Yes", "No");
            if (result) {
                await Navigation.PopModalAsync();
                tcs.SetResult(editSymptom);
            }
        }
        else
        {
            tcs.SetResult(editSymptom);
            await Navigation.PopModalAsync();
        }
    }
    public Task<Symptom> ShowAsyncSymptom()
    {
        tcs = new TaskCompletionSource<Symptom>();
        return tcs.Task;
    }

    private async void propertyButton_Clicked(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        if (clickedButton == dateButton)
        {
            DatePopup datePage = new DatePopup(editSymptom.Datetime);
            await Navigation.PushModalAsync(datePage);
            DateTime result = await datePage.ShowAsyncDate();
            dateButton.Text = result.ToString("M/d/yyyy");
        }
        else if (clickedButton == timeButton)
        {
            TimePopup timePage = new TimePopup(editSymptom.Datetime);
            await Navigation.PushModalAsync(timePage);
            DateTime result = await timePage.ShowAsyncTime();
            timeButton.Text = result.ToString("hh:mm tt");
        }
        else if (clickedButton == intensityButton)
        {
            popupFrame.IsVisible = true;
            popupFrame.IsEnabled = true;
            mainEdit.IsEnabled = false;
            mainEdit.Opacity = 0.7;
        }
    }

    private void lv_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        string selected = (string)lv.SelectedItem;
        intensityButton.Text = selected;
        DeactivatePopup();
    }

    private void ClosePop_Clicked(object sender, EventArgs e)
    {
        DeactivatePopup();
    }

    private void DeactivatePopup()
    {
        popupFrame.IsVisible = false;
        popupFrame.IsEnabled = false;
        mainEdit.IsEnabled = true;
        mainEdit.Opacity = 1;
    }
}