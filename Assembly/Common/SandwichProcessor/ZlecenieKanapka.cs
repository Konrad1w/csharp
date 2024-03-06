using Common;

namespace SandwichProcessor
{
	public class ZlecenieKanapka : Izlecenie
	{
		public string Title
		{
			get; set;
		}

		public void Process()
		{
			Console.WriteLine(Title);
			Console.WriteLine("Przygotuj 2 kromki chleba.");
			Thread.Sleep(1000);
			Console.WriteLine("Pokrój pomidory (jeśli używasz) na cienkie plastry.");
			Thread.Sleep(1000);
			Console.WriteLine("Na jednej kromce chleba rozłóż liście sałaty lub szpinaku.");
			Thread.Sleep(1000);
			Console.WriteLine("Na sałacie ułóż plastry salami i pomidora, równomiernie rozłożone na chlebie.");
			Thread.Sleep(1000);
			Console.WriteLine("Delikatnie przykryj kanapkę drugą kromką chleba z sosem do środka.");
			Thread.Sleep(1000);
			Console.WriteLine("Gotową kanapkę podaj na talerzu lub owiń w papier spożywczy, by zabrać ze sobą.\n");
		}
	}
}