using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Project1;
public class Participant {
	public enum MedalType { None, Bronze, Silver, Gold };
	public enum SeasonType { Summer, Winter };
	public enum GenderType { Female, Male };

	public int ID { get; set; }
	public String Name { get; set; }
	public GenderType Gender { get; set; }
	public int Age { get; set; }
	public String Country { get; set; }
	public int Year { get; set; }
	public SeasonType Season { get; set; }
	public String Location { get; set; }
	public String Sport { get; set; }
	public String Event { get; set; }
	public MedalType Medal { get; set; }

	public Participant(String str) {
		string[] toks = str.Split(new char[] { '\t' });
	}
}
