namespace ExerciseNavigation;

public partial class TechType : ContentPage
{
	public TechType(String type)
	{
		InitializeComponent();
		Type.Text = type;
	}
}