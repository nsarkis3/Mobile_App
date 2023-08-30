using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS;

public class Student {
	private string Name { get; set; }
	private double GPA { get; set; }
	public override string ToString() {
		return string.Format("{0} {1}", Name, GPA);
	}
	public Student() {
		Name = "X";
		GPA = 2.0;
	}
	public static void StudentMain() {
		Student s1 = new Student();
		Console.WriteLine(s1);
		Student s2 = new Student { Name = "John Doe", GPA = 3.2 };
		Console.WriteLine(s2);
	}
}
