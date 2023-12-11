using System.Collections.ObjectModel;

namespace Final;

public partial class SetUpLines : ContentPage
{
    private ObservableCollection<Player> selectedPlayers = new ObservableCollection<Player>();
    Line cancel;
    TaskCompletionSource<Line> tcs;
    public SetUpLines(Line activeLine)
	{
        InitializeComponent();
        lv.ItemsSource = DB.GetAllPlayers();
        cancel = activeLine;
        foreach (Player player in activeLine.Players) 
        {
            selectedPlayers.Add(player);
        }
        if (selectedPlayers.Count == 0) Possesion.SelectedItem = "Offense";
        else Possesion.SelectedItem = activeLine.LineName;
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        lv.ItemsSource = DB.GetAllPlayers();
    }

    private async void AddPlayer_Clicked(object sender, EventArgs e)
    {
		await Navigation.PushModalAsync(new EditPlayer());
    }

    private async void Finish_Clicked(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        if(button.Text == "Save")
        {
            if (selectedPlayers.Count > 7)
            {
                int playersCheck = selectedPlayers.Count - 7;
                await DisplayAlert("To Many Players", "A line can only have 7 players, you have "
                    + selectedPlayers.Count + " players selected. Please deselect " + playersCheck+ " players.", "Okay");
            }
            else if (selectedPlayers.Count < 7) 
            {
                int playersCheck = 7 - selectedPlayers.Count;
                await DisplayAlert("Not Enough Players", "A line needs 7 players, you have "
                    + selectedPlayers.Count + " players selected. Please pick " + playersCheck + " more players.", "Okay");
            }
            else
            {
                tcs.SetResult(new Line(Possesion.SelectedItem.ToString(), selectedPlayers.ToList()));
                await Navigation.PopModalAsync();
            }
        }
        else 
        {
            tcs.SetResult(cancel);
            selectedPlayers.Clear();
            List<int> Ids = new List<int>();
            foreach (Player p in cancel.Players) Ids.Add(p.Id);
            foreach (Player p in DB.GetAllPlayers())
            {
                if(Ids.Contains(p.Id))
                {
                    p.IsPlaying = true;
                    selectedPlayers.Add(p);
                    DB.UpdatePlayer(p);
                }
                else
                {
                    p.IsPlaying = false;
                    DB.UpdatePlayer(p);
                }
            }
            lv.ItemsSource = DB.GetAllPlayers();
            await Navigation.PopModalAsync();
        }
    }

    private void lv_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem == null) return;

        Player selectedPlayer = (Player)lv.SelectedItem;
        selectedPlayer.IsPlaying = !selectedPlayer.IsPlaying;
        if (selectedPlayer.IsPlaying) selectedPlayers.Add(selectedPlayer);
        else
        {
            for (int i = 0; i < selectedPlayers.Count; i++)
            {
                if (selectedPlayers[i].Id == selectedPlayer.Id)
                {
                    selectedPlayers.RemoveAt(i);
                }
            }
        }
        DB.UpdatePlayer(selectedPlayer);
        lv.ItemsSource = DB.GetAllPlayers();
    }
    public Task<Line> ShowAsyncLine()
    {
        tcs = new TaskCompletionSource<Line>();
        return tcs.Task;
    }
}