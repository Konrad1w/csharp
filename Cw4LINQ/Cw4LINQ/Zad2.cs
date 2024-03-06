using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cw4LINQ
{
	class Zad2
	{
		public static void Output()
		{
			int N;
			int M;
			try
			{
				N = int.Parse(Console.ReadLine());
				M = int.Parse(Console.ReadLine());
			}
			catch (Exception e)
			{
				Console.WriteLine("You have to write number!");
				return;
			}
			var random = new Random();
			IEnumerable<IEnumerable<int>> listOflists = Enumerable.Range(0, N).Select(n => Enumerable.Range(0, M).Select(n => random.Next(0, 100)).ToList()).ToList();
			int sum = listOflists.SelectMany(n => n).Sum();
			Console.WriteLine(sum);
		}
	}
}
