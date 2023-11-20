namespace Graphics;
using Graphics.Drawables;

public partial class MainPage : ContentPage {
    public MainPage() {
        InitializeComponent();
        picker.SelectedItem = 100;
    }

    private void picker_SelectedIndexChanged(object sender, EventArgs e) {
        int val = (int)picker.SelectedItem;
        float perc = val / 100.0f;

        GraphicsSample gs = (GraphicsSample)graphics1.Drawable;
        gs.Percent = perc;
        graphics1.Invalidate();

        GraphicsSample gs2 = (GraphicsSample)graphics2.Drawable;
        gs2.Percent = perc;
        graphics2.Invalidate();

        GraphicsSample gs3 = (GraphicsSample)graphics3.Drawable;
        gs3.Percent = perc;
        graphics3.Invalidate();
    }
}

