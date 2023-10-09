using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite;
namespace LINQMauiApp.Models {
	internal class DB {
		public static SQLiteConnection conn;
		public static void InitDB(string fname) {
			string libFolder = FileSystem.Current.AppDataDirectory;
			string fullFileName = System.IO.Path.Combine(libFolder, fname);

			File.Delete(fullFileName);

			conn = new SQLiteConnection(fullFileName);

			Person.CreateDB(conn);
			School.CreateDB(conn);
			Student.CreateDB(conn);
			Automobile.CreateDB(conn);
		}
	}
}
