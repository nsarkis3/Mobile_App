using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQMauiApp.Models;
internal class School {
	[PrimaryKey, AutoIncrement]
	public int Id { get; set; }
	public string Name { get; set; }
	public string ShortName {  get; set; }
	public string ImageSrc { get; set; }
	public string WebsiteURL { get; set; }
	public bool IsPublic { get; set; }
	public int Cost { get; set; }
	public override string ToString() {
		return String.Format("{0} {1} {2} [{3}, {4}]", Name, ImageSrc, WebsiteURL, IsPublic, Cost);
	}
	public static void CreateDB(SQLiteConnection conn) {
		conn.CreateTable<School>();
		conn.DeleteAll<School>();
		conn.Insert(new School {
			Name = "Miami",
			ShortName = "MU",
			WebsiteURL = "https://www.miamioh.edu",
			ImageSrc = "https://upload.wikimedia.org/wikipedia/en/1/16/Seal_of_Miami_University.png",
			IsPublic = true,
			Cost = 16700,
		});
		conn.Insert(new School {
			Name = "Ohio State",
			ShortName = "OSU",
			WebsiteURL = "https://www.osu.edu",
			ImageSrc = "https://pixy.org/src/149/1497856.jpg",
			IsPublic = true,
			Cost = 14000,
		});
		conn.Insert(new School {
			Name = "U. Cincinnati",
			ShortName = "UC",
			WebsiteURL = "https://www.uc.edu",
			ImageSrc = "https://pixy.org/src/95/956771.png",
			IsPublic = true,
			Cost = 13500,
		});
		conn.Insert(new School {
			Name = "Ohio",
			ShortName = "OU",
			WebsiteURL = "https://www.ohio.edu",
			ImageSrc = "https://pixy.org/src/141/1412375.jpeg",
			IsPublic = true,
			Cost = 12700,
		});
		conn.Insert(new School {
			Name = "Columbus College of Art & Design",
			ShortName = "CCAD",
			WebsiteURL = "https://www.ccad.edu/",
			ImageSrc = "https://d1yjjnpx0p53s8.cloudfront.net/styles/logo-original-577x577/s3/042012/caad.ai-converted.png?itok=fL13ivIs",
			IsPublic = false,
			Cost = 39100,
		});
	}
}