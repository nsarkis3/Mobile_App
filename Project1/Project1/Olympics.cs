using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace Project1;
public class Olympics {
	public static List<Participant>? participants;

	public static List<Participant> ReadParticipants(string fname) {
		participants = new List<Participant>();
		using (StreamReader input = new StreamReader(fname)) {
			string? header = input.ReadLine();
			while (!input.EndOfStream) {
				string? line = input.ReadLine();
				if (line == null) {
					continue;
				}
				Participant p = new Participant(line);
				participants.Add(p);
			}
		}
		return participants;
	}
	public static void Main(string[] args) {
		List<Participant> p = ReadParticipants("olympics.tsv");

		while (true) {
			Console.Write(">> ");
			string? userInput = Console.ReadLine();

			if (userInput == "exit") break;
			else if (userInput == "hosts")
			{
				List<string> hosts = Hosts(p);
				foreach (string host in hosts) Console.WriteLine(host);
			}
			else if (userInput.Contains("count"))
			{
				string[] inputArr = userInput.Split(' ');
				if (inputArr.Length <= 2)
				{
					Console.WriteLine("Invalid query");
				}
				else
				{
					try
					{
						int year = int.Parse(inputArr[1]);
						String country = userInput.Substring(7 + inputArr[1].Length, userInput.Length - (7 + inputArr[1].Length));
						Console.WriteLine(Count(p, year, country));
					}
					catch (Exception e)
					{
						Console.WriteLine("Invalid query");
					}
				}
			}
			else if (userInput.Contains("golds"))
			{
				string[] inputArr = userInput.Split(' ');
				if (inputArr.Length <= 2)
				{
					Console.WriteLine("Invalid query");
				}
				else
				{
					try
					{
						int year = int.Parse(inputArr[1]);
						String country = userInput.Substring(7 + inputArr[1].Length, userInput.Length - (7 + inputArr[1].Length));
						List<string> gold = Golds(p, year, country);
						foreach (string goldItem in gold) Console.WriteLine(goldItem);
					}
					catch (Exception e)
					{
						Console.WriteLine("Invalid query");
					}
				}
			}
			else if (userInput.Contains("podium"))
			{
				string[] inputArr = userInput.Split(' ');
				if (inputArr.Length >= 3)
				{
                    try
                    {
						List<string> podium = new List<string>(); 
                        int year = int.Parse(inputArr[1]);

						Participant.SeasonType season = Participant.SeasonType.Winter;
						if (userInput.Contains("Summer")) season = Participant.SeasonType.Summer;
						else if (userInput.Contains("Winter")) season = Participant.SeasonType.Winter;
						else
						{
							Console.WriteLine("Invalid query");
							continue;
						}
                        string sport = userInput.Substring(15 + inputArr[1].Length, userInput.Length - (15 + inputArr[1].Length));
						podium = Podium(p, year, season, sport);
                        foreach (string winner in podium)
						{
							Console.WriteLine(winner);
							Console.WriteLine();
						}
                    }
                    catch (Exception E)
                    {
                        Console.WriteLine("Invalid query");
                    }
				}
				else
				{
                    Console.WriteLine("Invalid query");
                }
			}
			else Console.WriteLine("Invalid query");
		}
	}

	public static List<string> Hosts(List<Participant> p)
	{
		List<string> hosts = new List<string>();
		foreach (Participant participant in p)
		{
			if (!hosts.Contains(participant.Location)) hosts.Add(participant.Location);
		}
		hosts.Sort();
		return hosts;
	}

	public static int Count(List<Participant> p, int year, string country)
	{
		int count = 0;
		foreach (Participant participant in p)
		{
			if (participant.Country == country &&
				participant.Medal != Participant.MedalType.None &&
				participant.Year == year)
			{
				count++;
			}
		}

		return count;
	}
	public static List<string> Golds(List<Participant> p, int year, string country)
	{
		List<string> goldWinners = new List<string>();
		foreach (Participant participant in p)
		{
			if(participant.Country == country &&
				participant.Year == year &&
				participant.Medal == Participant.MedalType.Gold &&
				!goldWinners.Contains(participant.Name))
			{
				goldWinners.Add(participant.Name);
			}
		}
		if (goldWinners.Count == 0) goldWinners.Add("None");

		return goldWinners;
	}

	public static List<string> Podium(List<Participant> p, int year, Participant.SeasonType season, string Event)
	{
		List<string> podium = new List<string>() { "", "", "" };
		string gold = "Gold \n";
		string silver = "Silver \n";
		string bronze = "Bronze \n";
        foreach (Participant participant in p)
		{
			if (participant.Year == year && 
				participant.Season == Participant.SeasonType.Summer && 
				participant.Event == Event)
			{
				if (participant.Medal == Participant.MedalType.Gold) gold += participant.Name + "\n";
				else if (participant.Medal == Participant.MedalType.Silver) silver += participant.Name + "\n";
				else if (participant.Medal == Participant.MedalType.Bronze) bronze += participant.Name + "\n";
            }
		}
		podium[0] = gold;
		podium[1] = silver;
		podium[2] = bronze;
        return podium;
    }
}