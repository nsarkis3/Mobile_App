using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace LINQMauiApp.Models;
[Table("person")]
public class Person {
	[PrimaryKey, AutoIncrement]
	public int Id { get; set; }
	[MaxLength(25)]
	public string Name { get; set; }
	public DateTime DOB { get; set; }
	public string Wikipedia { get; set; }
	public string FamousQuote { get; set; }
	[Ignore]
	public string DOBShortString {
		get {
			return DOB.ToShortDateString();
		}
	}
	public override string ToString() {
		return String.Format("{0} {1} {2} [{3}]", Name, DOB.ToString("MM/dd/yyyy"), FamousQuote, Id);
	}
	public static void CreateDB(SQLiteConnection conn) {
		conn.CreateTable<Person>();
		conn.DeleteAll<Person>();

		conn.Insert(new Person {
			Name = "Abraham Lincoln",
			DOB = new DateTime(1809, 2, 12),
			FamousQuote = "Whatever you are, be a good one.",
			Wikipedia = "https://en.wikipedia.org/wiki/Abraham_Lincoln"
		});
		conn.Insert(new Person {
			Name = "Clara Barton",
			DOB = new DateTime(1821, 12, 25),
			FamousQuote = "Everybody's business is nobody's business, and nobody's business is my business.",
			Wikipedia = "https://en.wikipedia.org/wiki/Clara_Barton"
		});
		conn.Insert(new Person {
			Name = "Winston Churchill",
			DOB = new DateTime(1874, 11, 30),
			FamousQuote = "Attitude is a little thing that makes a big difference.",
			Wikipedia = "https://en.wikipedia.org/wiki/Winston_Churchill"
		});
		conn.Insert(new Person {
			Name = "Rosa Parks",
			DOB = new DateTime(1913, 2, 4),
			FamousQuote = "Each person must live their life as a model for others.",
			Wikipedia = "https://en.wikipedia.org/wiki/Rosa_Parks"
		});
		conn.Insert(new Person {
			Name = "Katherine Johnson",
			DOB = new DateTime(1918, 8, 26),
			FamousQuote = "I don't have a feeling of inferiority. Never had. I'm as good as anybody, but no better.",
			Wikipedia = "https://en.wikipedia.org/wiki/Katherine_Johnson"
		});
		conn.Insert(new Person {
			Name = "Henrik Doolittle",
			DOB = new DateTime(1950, 1, 1),
			FamousQuote = "There's no crying in computer science.",
			Wikipedia = null,
		});
	}
}