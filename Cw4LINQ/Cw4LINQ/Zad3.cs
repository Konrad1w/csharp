using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Cw4LINQ
{
	class Zad3
	{
		public static void Output()
		{
			List<string> cities = new List<string>();
			string city = Console.ReadLine();
			while (city != "X")
			{
				cities.Add(city);
				city = Console.ReadLine();
			}
			var groupedWords = cities.OrderBy(n => n).GroupBy(n => n.First());
			Dictionary<char, List<string>> dictionary = groupedWords.ToDictionary(n => n.Key, n => n.ToList());
			string command = Console.ReadLine();
			while (command != "KONIEC")
			{
				char letter;
				try
				{
					letter = Char.Parse(command);
				}
				catch (Exception e)
				{
					Console.WriteLine("You have to write single character");
					return;
				}
				WriteCountriesFromDictionaryStartingWithLetter(dictionary, letter);
				command = Console.ReadLine();
			}
		}
		public static void WriteCountriesFromDictionaryStartingWithLetter(Dictionary<char, List<string>> dictionary, char letter)
		{
			if (!dictionary.Keys.Contains(letter))
			{
				Console.WriteLine("PUSTE");
				return;
			}
			foreach (var value in dictionary[letter])
			{
				Console.Write(value + " ");
			}
			Console.WriteLine();
		}
	}
}
