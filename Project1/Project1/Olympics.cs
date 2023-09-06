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
		ReadParticipants("olympics.tsv");

		while (true) {
			Console.Write(">> ");
			string? userInput = Console.ReadLine();
		}
	}
}