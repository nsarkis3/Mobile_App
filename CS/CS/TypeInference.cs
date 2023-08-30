using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS;
public class TypeInference {
	public static Dictionary<string, ISet<int>> createDictionary() {
		Dictionary<string, ISet<int>> result = new Dictionary<string, ISet<int>>();
		result.Add("Miami", new HashSet<int>());
		result["Miami"].Add(1809);
		result["Miami"].Add(1900);

		result.Add("OSU", new HashSet<int>());
		result["OSU"].Add(1810);
		result["OSU"].Add(1940);

		result.Add("UC", new HashSet<int>());
		result["UC"].Add(1830);

		return result;
	}
	public static void TypeInferenceMain() {
		int x = 34;	// x explicitly declared as int
		var y = 34; // x implicitly declared as int

		// y = 3.14; // illegal at this point, because y is int

		var dict1 = createDictionary();
		var items1 = dict1.Values;
		foreach (var itemSet in items1) {
			foreach (var item in itemSet) {
				Console.Write(item + " ");
			}
			Console.WriteLine();
		}

		// Same as below
		Dictionary<string, ISet<int>> dict2 = createDictionary();
		ICollection<ISet<int>> items2 = dict2.Values;
		foreach (ISet<int> itemSet in items1) {
			foreach (int item in itemSet) {
				Console.Write(item + " ");
			}
			Console.WriteLine();
		}
	}
}
