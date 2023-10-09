using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQMauiApp.Models;
internal class Automobile {
	[PrimaryKey, AutoIncrement]
	public int Id { get; set; }
	public int Year { get; set; }
	public int Cost { get; set; }
	public string Make { get; set; }
	public string Model { get; set; }
	public static void CreateDB(SQLiteConnection conn) {
		conn.CreateTable<Automobile>();
		conn.DeleteAll<Automobile>();
		conn.Insert(new Automobile { Year = 2023, Make = "Ford", Model = "Focus", Cost=21000 });
		conn.Insert(new Automobile { Year = 2023, Make = "Honda", Model = "Civic", Cost = 22500 });
		conn.Insert(new Automobile { Year = 2023, Make = "Honda", Model = "CRV", Cost = 29500 });
		conn.Insert(new Automobile { Year = 2023, Make = "Subaru", Model = "Forester", Cost = 32500 });
		conn.Insert(new Automobile { Year = 2023, Make = "Toyota", Model = "Corolla", Cost = 21900 });
		conn.Insert(new Automobile { Year = 1972, Make = "AMC", Model = "Gremlin", Cost = 450 });
	}
	public override string ToString() {
		return String.Format("{0} {1} {2} ${3}", Year, Make, Model, Cost);
	}
}