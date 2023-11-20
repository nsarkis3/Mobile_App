namespace Graphics;
using Graphics.Drawables;
using static System.Net.Mime.MediaTypeNames;

public partial class Plotting : ContentPage {
    public Plotting() {
        InitializeComponent();
    }
    private void Button_Clicked(object sender, EventArgs e) {
        PlottingDrawable plot = (PlottingDrawable)graphics.Drawable;
        plot.Labels = labels.Text.Split(",");
        plot.Data = data.Text.Split(',').Select(x => int.Parse(x)).ToArray();
        graphics.Invalidate();
    }
}