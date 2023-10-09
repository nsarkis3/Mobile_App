using LINQMauiApp.Models;
using Microsoft.Maui.Controls.Shapes;
using System.Collections.Generic;
using System.ComponentModel;

namespace LINQMauiApp;

public partial class StudentPage : ContentPage
{
	public StudentPage()
	{
		InitializeComponent();
	}
	private void ButtonClicked(object sender, EventArgs e) {
		Button b = sender as Button;
		var students = DB.conn.Table<Student>().ToList();
		IEnumerable<Object> result = null;

		switch (b.Text) {
			case "Q0":      // Q0 - All records
				result = students;
				break;
			case "Q1":      // Q1 - Students with GPAs at least 3.0.
				result = from s in students
						 where s.GPA >= 3.0
						 select s;
				break;
			case "Q2":      // Q2 - The last names of students with GPAs at least 3.0.
				result = from s in students
                         where s.GPA >= 3.0
                         select s.LastName;
                break;
			case "Q3":      // Q3 - The first and last names of students with GPAs at least 3.0.
				result = from s in students
						 where s.GPA >= 3.0
						 select new Tuple<string, string>(s.FirstName, s.LastName);
				break;
			case "Q4":      // Q4 - Students with a first name beginning with an ‘S’
				result = from s in students
						 where s.FirstName.Substring(0, 1) == "S"
                         select s;
                break;
			case "Q5":      // Q5 - Students ordered by decreasing GPA
				result = from s in students
						 orderby s.GPA descending
						 select s;
				break;
			case "Q6":      // Q6 - Legacy students
				result = from s in students
                         where s.Legacy
                         select s;
                break;
			case "Q7":      // Q7 - Last name of legacy students
				result = from s in students
                         where s.Legacy
                         select s.LastName;
                break;
		}
		lv.ItemsSource = result?.ToList();
	}
}
