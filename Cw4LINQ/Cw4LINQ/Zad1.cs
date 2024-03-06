
using System.Linq.Expressions;
namespace Cw4LINQ
{
	class Zad1
	{
		public static void Output()
		{
			int number;
			try
			{
				number = int.Parse(Console.ReadLine());
			}
			catch (Exception e)
			{
				Console.WriteLine("You have to write number!");
				return;
			}
			IEnumerable<int> squares = Enumerable.Range(1, number).Where(n => n != 5 && n != 9 && (n % 2 != 0 || n % 7 == 0)).OrderBy(n => n).Select(n => n * n);
			try
			{
				Console.WriteLine(squares.Sum() + '\n' + squares.Count() + '\n' + squares.First() + '\n' + squares.Last() + '\n' + squares.ElementAt(3));
			}
			catch (Exception e)
			{
				Console.WriteLine("Not correct number");
			}
		}
	}
}
