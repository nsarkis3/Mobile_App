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

		this.ID = int.Parse(toks[0]);
		this.Name = toks[1];

		if (toks[2] == "M") this.Gender = GenderType.Male;
		else this.Gender = GenderType.Female;

		if (toks[3] == "NA") this.Age = -1;
		else this.Age = int.Parse(toks[3]);
		
		this.Country = toks[6];
		this.Year = int.Parse(toks[9]);

		if (toks[10] == "Summer") this.Season = SeasonType.Summer;
		else this.Season = SeasonType.Winter;

		this.Location = toks[11];
		this.Sport = toks[12];
		this.Event = toks[13];

		if (toks[14] == "Gold") this.Medal = MedalType.Gold;
		else if (toks[14] == "Silver") this.Medal = MedalType.Silver;
		else if (toks[14] == "Bronze") this.Medal = MedalType.Bronze;
		else this.Medal = MedalType.None;
    }
}
