using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Images;

public class Person {
	public string Name { get; set; }
	public string Borough { get; set; }
	public string GetFavoriteTeamImage {
		get {
			switch (Borough) {
				case "Bronx":	return"yankees.png";
				case "Queens":	return "mets.png";
				default:		return null;
			}
		}
	}
}
