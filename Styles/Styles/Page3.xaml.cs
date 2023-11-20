namespace Styles;

public partial class Page3 : ContentPage {
    public Page3() {
        InitializeComponent();
    }

    private void Button_Clicked(object sender, EventArgs e) {
        int currSz = (int)Resources["fontSz"];
        if (currSz == 16) {
            Resources["fontSz"] = 32;
        } else {
            Resources["fontSz"] = 16;
        }
    }
}