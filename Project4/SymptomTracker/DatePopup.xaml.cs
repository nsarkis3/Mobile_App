using System.Globalization;

namespace SymptomTracker;

public partial class DatePopup : ContentPage
{
    private Button selectedButton = null;
    TaskCompletionSource<DateTime> tcs;
    DateTime CurrentDate;
    public DatePopup(DateTime template)
    {
        CurrentDate = DateTime.Now;
        InitializeComponent();
        int daysInMonth = DateTime.DaysInMonth(CurrentDate.Year, CurrentDate.Month);
        int startingDayOfWeek = (int)new DateTime(CurrentDate.Year, CurrentDate.Month, 1).DayOfWeek;

        current.Text = CurrentDate.ToString("MMMM yyyy");

        for (int day = 1; day <= daysInMonth; day++)
        {
            Button button = new Button
            {
                Text = day.ToString(),
                TextColor = Colors.Black,
                BackgroundColor = Colors.Transparent,
                BorderColor = Colors.Transparent,
                CornerRadius = 50
            };

            if(day == template.Day)
            {
                button.BackgroundColor = Colors.DarkBlue;
                button.TextColor = Colors.White;
                selectedButton = button;
            }

            Grid.SetRow(button, (day + startingDayOfWeek - 1) / 7 + 2);
            Grid.SetColumn(button, (day + startingDayOfWeek - 1) % 7);
            button.Clicked += daySelected;

            gridCalendar.Children.Add(button);
        }
        year.Text = CurrentDate.Year.ToString();
    }
    private void daySelected(object sender, EventArgs e)
    {
        Button clickedButton = (Button)sender;

        if (selectedButton != null)
        {
            selectedButton.BackgroundColor = Colors.Transparent;
            selectedButton.TextColor = Colors.Black;
        }

        clickedButton.BackgroundColor = Colors.DarkBlue;
        clickedButton.TextColor = Colors.White;

        string buttonText = clickedButton.Text;
        int column = Grid.GetColumn(clickedButton);

        string[] dayNames = { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };

        string currentLabelText = current.Text;
        string currentMonth = currentLabelText.Split(' ')[0].Substring(0, 3);

        string formattedDate = $"{dayNames[column]}, {currentMonth} {buttonText}";

        day.Text = formattedDate;
        year.Text = currentLabelText.Split(' ')[1];

        selectedButton = clickedButton;
        CurrentDate = new DateTime(int.Parse(year.Text), DateTime.ParseExact(currentMonth,"MMM", CultureInfo.InvariantCulture).Month,
            int.Parse(clickedButton.Text));
    }

    private void monthChanged(object sender, EventArgs e)
    {
        Button clicked = (Button)sender;

        DateTime currentDate = new DateTime(int.Parse(current.Text.Split(' ')[1]),
            DateTime.ParseExact(current.Text.Split(' ')[0].Substring(0, 3), "MMM", CultureInfo.InvariantCulture).Month, DateTime.Now.Day);

        DateTime newDate = new DateTime();

        if (currentDate.Month == 12 && clicked.Text == ">") newDate = new DateTime(currentDate.Year + 1, 1, currentDate.Day);
        else if (currentDate.Month != 12 && clicked.Text == ">") newDate = new DateTime(currentDate.Year, currentDate.Month + 1, currentDate.Day);
        else if (currentDate.Month == 1 && clicked.Text == "<") newDate = new DateTime(currentDate.Year - 1, 12, currentDate.Day);
        else if (currentDate.Month != 1 && clicked.Text == "<") newDate = new DateTime(currentDate.Year, currentDate.Month - 1, currentDate.Day);

        int daysInMonth = DateTime.DaysInMonth(newDate.Year, newDate.Month);
        int startingDayOfWeek = (int)new DateTime(newDate.Year, newDate.Month, 1).DayOfWeek;

        current.Text = newDate.ToString("MMMM yyyy");

        var buttonsToRemove = gridCalendar.Children.Where(c => c is Button).ToList();

        foreach (var button in buttonsToRemove)
        {
            gridCalendar.Children.Remove(button);
        }

        for (int day = 1; day <= daysInMonth; day++)
        {
            Button button = new Button
            {
                Text = day.ToString(),
                TextColor = Colors.Black,
                BackgroundColor = Colors.Transparent,
                BorderColor = Colors.Transparent,
                CornerRadius = 50
            };

            int row = (day + startingDayOfWeek - 1) / 7 + 2;
            int col = (day + startingDayOfWeek - 1) % 7;

            Grid.SetRow(button, row);
            Grid.SetColumn(button, col);
            button.Clicked += daySelected;

            gridCalendar.Children.Add(button);
        }
        year.Text = newDate.Year.ToString();
    }

    private async void Exit(object sender, EventArgs e)
    {
        Button clicked = (Button)sender;
        if(clicked.Text == "OK")
        {
            tcs.SetResult(CurrentDate);
        }
        await Navigation.PopModalAsync();
    }

    public Task<DateTime> ShowAsyncDate()
    {
        tcs = new TaskCompletionSource<DateTime>();
        return tcs.Task;
    }
}