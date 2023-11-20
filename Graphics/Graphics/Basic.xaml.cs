namespace Graphics;
using Graphics.Drawables;

public partial class Basic : ContentPage {
    public Basic() {
        InitializeComponent();
        picker.SelectedItem = 100;
    }

    private void picker_SelectedIndexChanged(object sender, EventArgs e) {
        int val = (int)picker.SelectedItem;
        float perc = val / 100.0f;

        GraphicsSample gs = (GraphicsSample)graphics1.Drawable;
        gs.Percent = perc;
        graphics1.Invalidate();
    }
}