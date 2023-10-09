using LINQMauiApp.Models;
using Microsoft.Maui.Animations;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Xml.Linq;

namespace LINQMauiApp;

public partial class PersonPage : ContentPage
{
	public PersonPage()
	{
		InitializeComponent();
	}

	private void ButtonClicked(object sender, EventArgs e) {
		Button b = sender as Button;
		var people = DB.conn.Table<Person>().ToList();
		IEnumerable<Object> result = null;

		switch (b.Text) {
			case "Q0":      // Q0 - All records
				result = people;
				break;
			case "Q1":      // Q1 - People born in 1900 or later
				result = people.Where(p => p.DOB.Year >= 1900);
				break;
			case "Q2":      // Q2 - People sorted by DOB
				result = from p in people
						 orderby p.DOB
						 select p;
				break;
			case "Q3":      // Q3 - People that have a Wikipedia page
				result = from p in people
						 where p.Wikipedia != null
						 select p;
				break;
			case "Q4":      // Q4 - People sorted by length of quote(shortest first)
				result = from p in people
							orderby p.FamousQuote.Length
							select p;
				break;
			case "Q5":      // Q5 - People born between 1900 and 1920(inclusive) sorted by DOB
				result = null;
				break;
			case "Q6":      // Q6 - The name only of people born between 1900 and 1920(inclusive)
				result = null;
				break;
			case "Q7":      // Q7 - Persons that were born in January,February, … June.
				result = null;
				break;
		}
		lv.ItemsSource = result?.ToList();
	}
}