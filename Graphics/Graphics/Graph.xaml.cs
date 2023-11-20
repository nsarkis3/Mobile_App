namespace Graphics;
using Graphics.Drawables;
using static System.Net.Mime.MediaTypeNames;

public partial class Graph : ContentPage
{
	public Graph()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
        int[] values = data.Text.Split(',').Select(int.Parse).ToArray();
        int total = values.Sum();

        int[] percentages = values.Select(value => (int)((double)value / total * 100)).ToArray();

        PlottingDrawable plot = (PlottingDrawable)graphics.Drawable;
        plot.Labels = labels.Text.Split(",");
        plot.Data = percentages;

        graphics.Invalidate();
    }
}