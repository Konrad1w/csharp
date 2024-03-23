using ParlamentN;
using System;

class Program
{
	public static void Main(string[] args)
	{
		Console.WriteLine("Podaj liczbe parlamentarzystow");
		int liczbaParlamentarzystow = Int32.Parse(Console.ReadLine());
		Console.WriteLine("Podaj temat glosowania");
		string tematGlosowania = Console.ReadLine();
		Parlament parlament = new Parlament(tematGlosowania, liczbaParlamentarzystow);
		while (true)
		{
			string command = Console.ReadLine();
			if (command.StartsWith("POCZĄTEK "))
			{
				parlament.StartGlosowania(command.Substring(command.LastIndexOf(" ") + 1));
			}
			else if (command.StartsWith("GŁOS "))
			{
				int numerParlamenatrzysty = -1;
				bool parsable = int.TryParse(command.Substring(command.LastIndexOf(" ") + 1), out numerParlamenatrzysty);
				if (parsable && numerParlamenatrzysty < parlament.liczbaParlamentarzystow)
				{
					parlament.parlamentarzysci[numerParlamenatrzysty].Glosuj();
				}
				else if (parsable)
					Console.WriteLine("Niepoprawny numer palamentarzysty");
				else
					Console.WriteLine("Wpisz numer parlamentarzysty po tekscie \"GŁOS\"");
			}
			else if (command == "KONIEC")
			{
				parlament.KoniecGlosowania();
			}
			else
			{
				Console.WriteLine("Nieznana komenda. Do wyboru masz komendy: POCZĄTEK, GŁOS, KONIEC");
			}

		}
	}
}
