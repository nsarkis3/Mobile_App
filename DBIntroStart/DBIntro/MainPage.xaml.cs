using SQLite;
namespace DBIntro;
public partial class MainPage : ContentPage
{
    SQLiteConnection conn;
    public void CreateConnection()
    {
        string libFolder = FileSystem.AppDataDirectory;
        string fname = System.IO.Path.Combine(libFolder, "users.db");
        conn = new SQLiteConnection(fname);
        conn.CreateTable<User>();
        conn.CreateTable<Person>();
    }
    public MainPage()
    {
        InitializeComponent();
        CreateConnection();
        lv.ItemsSource = conn.Table<User>().ToList();
        personLv.ItemsSource = conn.Table<Person>().ToList();
    }
    private void Button_Clicked(object sender, EventArgs e)
    {
        User newUser = new User { Username = name.Text };
        conn.Insert(newUser);
        lv.ItemsSource = conn.Table<User>().ToList();
    }

    private void personButton_Clicked(object sender, EventArgs e)
    {
        Person newPerson = new Person { Name2 = pName.Text, DOB = dob.Date, SSN = ssn.Text };
        conn.Insert(newPerson);
        personLv.ItemsSource = conn.Table<Person>().ToList();
    }
}