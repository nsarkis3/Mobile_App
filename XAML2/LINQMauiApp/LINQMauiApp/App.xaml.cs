namespace LINQMauiApp;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();

		Models.DB.InitDB("data.db");
	}
}
