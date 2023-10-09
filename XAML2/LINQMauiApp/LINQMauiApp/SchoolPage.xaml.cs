using LINQMauiApp.Models;
using System.Xml.Linq;

namespace LINQMauiApp;

public partial class SchoolPage : ContentPage
{
	public SchoolPage()
	{
		InitializeComponent();
	}
	private void ButtonClicked(object sender, EventArgs e) {
		Button b = sender as Button;
		var schools = DB.conn.Table<School>().ToList();
		IEnumerable<School> result = null;
		
		switch (b.Text) {
			case "Q0":		// Q0 - All records
				result = schools;
				break;
			case "Q1":      // Q1 - Public schools
				result = schools.Where(s => s.IsPublic);
				break;
			case "Q2":      // Q2 - Schools that cost less than 15000
				result = from s in schools
						 where s.Cost < 15000
							select s;
				break;
			case "Q3":      // Q3 - Schools sorted by ascending Cost
				result = from s in schools
							orderby s.Cost
							select s;
				break;
			case "Q4":      // Q4 - Public schools sorted by descending Cost
				result = from s in schools
							where s.IsPublic
							orderby s.Cost descending
							select s;
				break;
			case "Q5":      // Q5 - Public schools that cost less than 15000
				result = from s in schools
						 where s.IsPublic && s.Cost < 15000
						 select s;
				break;
			case "Q6":      // Q6 - Schools sorted by Name
				result = from s in schools
						 orderby s.Name
						 select s;
				break;
			case "Q7":      // Q7 - Schools that have short names with only two characters
				result = from s in schools
						 where s.ShortName.Length == 2
						 select s;
				break;
		}
		lv.ItemsSource = result?.ToList();
	}
}