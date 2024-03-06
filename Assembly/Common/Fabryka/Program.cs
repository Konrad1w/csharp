using System.Reflection;
using Common;
namespace Fabryka
{
	public class Program
	{
		public static void Main(string[] args)
		{
			if (args.Length == 0)
			{
				Console.WriteLine("Niepoprawne użycie aby użyć: Fabryka.exe [ścieżka do assembly];[nazwa zlecenia]");
				return;
			}
			foreach (string arg in args)
			{
				string filePath = arg.Substring(0, arg.IndexOf(";"));
				string fileName = filePath.Substring(filePath.LastIndexOf("\\") + 1);
				fileName = fileName.Substring(0, fileName.Length - 4);
				string productName = arg.Substring(arg.IndexOf(";") + 1);
				try
				{
					Assembly assembly = Assembly.LoadFrom(filePath);
					Type t = null;
					if (fileName == "BeerProcessor")
						t = assembly.GetType(fileName + ".ZleceniePiwo");
					else if (fileName == "SandwichProcessor")
						t = assembly.GetType(fileName + ".ZlecenieKanapka");
					if (t != null)
					{
						var zlecenie = (Izlecenie)Activator.CreateInstance(t);
						zlecenie.Title = productName;
						zlecenie.Process();
					}
					else
						Console.WriteLine("Błednie podanie klasy implementujacej Zlecenie Kanapki lub Piwa");
				}
				catch (Exception ex)
				{
					Console.WriteLine("Blad: " + ex.ToString());
				}
			}
		}
	}
}
//input
//Fabryka.exe "C:\\Users\\user\\Desktop\\c#\\cw7Assembly\\Common\\BeerProcessor\\bin\\Debug\\net7.0\\BeerProcessor.dll;Piwo dla Franka" "C:\\Users\\user\\Desktop\\c#\\cw7Assembly\\Common\\SandwichProcessor\\bin\\Debug\\net7.0\\SandwichProcessor.dll;Kanapka dla Franka" "C:\\Users\\user\\Desktop\\c#\\cw7Assembly\\Common\\SandwichProcessor\\bin\\Debug\\net7.0\\SandwichProcessor.dll;Kanapka Janiny"