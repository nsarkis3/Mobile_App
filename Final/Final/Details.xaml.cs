using Final.Drawabels;

namespace Final;

public partial class Details : ContentPage
{
	public Details()
	{
		InitializeComponent();

        CatchesStat catchesGraph = (CatchesStat)catches.Drawable;
        List<Player> top = DB.Top5();
        catchesGraph.players = top;
        first.Text = top[0].Name;
        second.Text = top[1].Name;
        third.Text = top[2].Name;
        fourth.Text = top[3].Name;
        fifth.Text = top[4].Name;
        catches.Invalidate();
    }

    private void Exit_Clicked(object sender, EventArgs e)
    {
		Navigation.PopModalAsync();
    }
}