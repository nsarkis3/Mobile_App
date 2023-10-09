using LINQMauiApp.Models;
using Microsoft.Maui.Controls;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Intrinsics.X86;

namespace LINQMauiApp;

public partial class AutoPage : ContentPage
{
	public AutoPage()
	{
		InitializeComponent();
	}
	private void ButtonClicked(object sender, EventArgs e) {
		Button b = sender as Button;
		var autos = DB.conn.Table<Automobile>().ToList();
		IEnumerable<Object> result = null;

		switch (b.Text) {
			case "Q0":		// Q0 - All records
				result = autos;
				break;
			case "Q1":		// Q1 - Cars that are less than $25000
				result = from a in autos
				where a.Cost < 25000
						select a;
				break;
			case "Q2":      // Q2 - Cars sorted by year descending
				result = null;
				break;
			case "Q3":      // Q3 - Autos sorted by cost in ascending order
				result = from a in autos
						 orderby a.Cost
						 select a;
				break;
			case "Q4":      // Q4 - Honda cars
				result = null;
				break;
			case "Q5":      // Q5 - Only the make and model of each automobile
				result = null; 
				break;
			case "Q6":      // Q6 - Cars that are cheap(< 1000) or expensive(> 30000)
				result = from a in autos
						 where a.Cost < 1000 || a.Cost > 30000
						 select a;
				break;
			case "Q7":  // Q7 - All the makes listed.But only one copy will appear in the result.
						// For this one, you can use more than LINQ.
				result = null;
				break;
		}
		lv.ItemsSource = result?.ToList();
	}
}