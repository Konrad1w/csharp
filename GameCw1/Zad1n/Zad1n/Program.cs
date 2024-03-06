using System;
using System.Net;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

class Game
{
	public enum EHeroClass
	{
		barbarzyńca = 1,
		paladyn = 2,
		amazonka = 3
	}

	public interface IDialogPart
	{
		public string TrescWypowiedzi { get; set; }
	}

	public class NonPlayerCharacter
	{
		public string name;
		NpcDialogPart initialDialog;
		public NonPlayerCharacter(string name, NpcDialogPart initialDialog)
		{
			this.name = name;
			this.initialDialog = initialDialog;
		}

		public NpcDialogPart StartTalking()
		{
			return initialDialog;
		}
	}

	public class NpcDialogPart : IDialogPart
	{
		public string TrescWypowiedzi { get; set; }
		public List<HeroDialogPart> heroDialogs;
		public NpcDialogPart(string trescWypowiedzi)
		{
			this.TrescWypowiedzi = trescWypowiedzi;
			heroDialogs = new List<HeroDialogPart>();
		}
	}

	public class HeroDialogPart : IDialogPart
	{
		public string TrescWypowiedzi { get; set; }
		public NpcDialogPart npcDialogPart;
		public HeroDialogPart(string trescWypowiedzi, NpcDialogPart npcDialogPart)
		{
			this.TrescWypowiedzi = trescWypowiedzi;
			this.npcDialogPart = npcDialogPart;
		}
	}

	public class Localization
	{
		public List<NonPlayerCharacter> npc;
		public string name;
		public Localization(string name)
		{
			this.name = name;
			this.npc = new List<NonPlayerCharacter>();
		}
	}

	public class Hero
	{
		public string name { get; set; }
		public EHeroClass klasa { get; set; }
		public Hero(string name, EHeroClass klasa)
		{
			this.name = name;
			this.klasa = klasa;
		}
	}

	public class DialogParse
	{
		public Hero hero;
		public DialogParse(Hero hero)
		{
			this.hero = hero;
		}
		public string ParseDialog(IDialogPart iDialogPart)
		{
			return iDialogPart.TrescWypowiedzi.Replace("#HERONAME#", hero.name);
		}

	}

	public static string ChoosingNameHero()
	{
		Console.WriteLine("Podaj nazwe bohatera");
		string insertedNameHero = Console.ReadLine();
		string cleanedName = Regex.Replace(insertedNameHero, @"\s+", " ");
		string pattern = "^[a-zA-Z ]+$";
		Regex regex = new Regex(pattern);
		while (cleanedName.Length < 2 || !regex.IsMatch(cleanedName))
		{
			Console.WriteLine("Twoja nazwa jest bledna, wybierz jeszcze raz");
			insertedNameHero = Console.ReadLine();
			cleanedName = Regex.Replace(insertedNameHero, @"\s+", " ");
		}
		return cleanedName;
	}

	public static EHeroClass ChoosingClassHero(string name)
	{
		Console.WriteLine("Witaj, " + name + " wybierz klasę bohatera:");
		Console.WriteLine("1. barbarzyńca");
		Console.WriteLine("2. paladyn");
		Console.WriteLine("3. amazonka");
		string choosenClassHero = Console.ReadLine();
		while (choosenClassHero != "1" && choosenClassHero != "2" && choosenClassHero != "3")
		{
			Console.WriteLine("Wybrales zla opcje, wybierz jeszcze raz");
			choosenClassHero = Console.ReadLine();
		}
		if (choosenClassHero == "1")
			return EHeroClass.barbarzyńca;
		else if (choosenClassHero == "2")
			return EHeroClass.paladyn;
		else
			return EHeroClass.amazonka;
	}

	public static void TalkTo(NonPlayerCharacter npc, DialogParse dialogParse)
	{
		ChoosingOptionInConversation(npc.StartTalking(), dialogParse);
	}

	public static void ChoosingOptionInConversation(NpcDialogPart npcDialogPart, DialogParse dialogParse)
	{
		Console.WriteLine(dialogParse.ParseDialog(npcDialogPart));
		if (npcDialogPart.heroDialogs.Count > 0)
		{
			Console.WriteLine("Wybierz odpowiedz:");
			for (int i = 0; i < npcDialogPart.heroDialogs.Count; i++)
			{
				Console.WriteLine(i + 1 + ". " + npcDialogPart.heroDialogs[i].TrescWypowiedzi);
			}
			string choice = Console.ReadLine();
			int number = 0;
			Int32.TryParse(choice, out number);
			while (number <= 0 || number > npcDialogPart.heroDialogs.Count)
			{
				Console.WriteLine("Wybrales zla opcje, wybierz jeszcze raz");
				choice = Console.ReadLine();
				number = 0;
				Int32.TryParse(choice, out number);
			}
			HeroDialogPart heroDialogPart = npcDialogPart.heroDialogs[number - 1];
			Console.WriteLine(dialogParse.ParseDialog(heroDialogPart));
			if (heroDialogPart.npcDialogPart.TrescWypowiedzi != "<KONIEC>")
				ChoosingOptionInConversation(heroDialogPart.npcDialogPart, dialogParse);
		}
	}

	public static NonPlayerCharacter ShowLocation(Localization localization)
	{
		Console.WriteLine($"Znajdujesz się w: {localization.name}. Co chcesz zrobić?");
		for (int i = 0; i < localization.npc.Count; i++)
			Console.WriteLine($"[{i + 1}] Porozmawiaj z " + localization.npc[i].name);
		Console.WriteLine("[X] Zamknij program");
		string choosenOption = Console.ReadLine();
		int number = 0;
		Int32.TryParse(choosenOption, out number);

		while ((number <= 0 || number > localization.npc.Count) && choosenOption != "x")
		{
			Console.WriteLine("Wybrales zla opcje, wybierz jeszcze raz");
			choosenOption = Console.ReadLine();
			number = 0;
			Int32.TryParse(choosenOption, out number);
		}
		if (choosenOption == "x")
			Environment.Exit(0);
		else
		{
			return localization.npc[number - 1];
		}
		return null;
	}

	public static void newGame()
	{
		Console.Clear();
		string nameHero = ChoosingNameHero();
		EHeroClass classHero = ChoosingClassHero(nameHero);
		Hero newHero = new Hero(nameHero, classHero);
		Console.Clear();
		
		Console.WriteLine(newHero.klasa + " " + newHero.name + " wyrusza na przygodę");
		Localization localizationSilverymoon = new Localization("Silverymoon");
		NpcDialogPart npcDialogPartAkara1 = new NpcDialogPart("Witaj, czy możesz mi pomóc dostać się do innego miasta?");
		NpcDialogPart npcDialogPartAkara2 = new NpcDialogPart("Dziękuję! W nagrodę otrzymasz ode mnie 100 sztuk złota");
		NpcDialogPart npcDialogPartAkara3 = new NpcDialogPart("Niestety nie mam więcej.Jestem bardzo biedny");
		NpcDialogPart npcDialogPartAkara4 = new NpcDialogPart("Dziękuję.");
		NpcDialogPart npcDialogPartAkaraEnd = new NpcDialogPart("<KONIEC>");
		
		NonPlayerCharacter nonPlayerCharacterAkara = new NonPlayerCharacter("Akara", npcDialogPartAkara1);
		localizationSilverymoon.npc.Add(nonPlayerCharacterAkara);
		
		HeroDialogPart heroDialogPartAkara1 = new HeroDialogPart("Tak, chętnie pomogę", npcDialogPartAkara2);
		HeroDialogPart heroDialogPartAkara6 = new HeroDialogPart("Nie, nie pomogę, żegnaj.", npcDialogPartAkaraEnd);
		npcDialogPartAkara1.heroDialogs.Add(heroDialogPartAkara1);
		npcDialogPartAkara1.heroDialogs.Add(heroDialogPartAkara6);
		
		HeroDialogPart heroDialogPartAkara2 = new HeroDialogPart("Dam znać jak będę gotowy", npcDialogPartAkaraEnd);
		HeroDialogPart heroDialogPartAkara3 = new HeroDialogPart("100 sztuk złota to za mało!", npcDialogPartAkara3);
		npcDialogPartAkara2.heroDialogs.Add(heroDialogPartAkara2);
		npcDialogPartAkara2.heroDialogs.Add(heroDialogPartAkara3);
		
		HeroDialogPart heroDialogPartAkara4 = new HeroDialogPart("OK, może być 100 sztuk złota.", npcDialogPartAkara4);
		HeroDialogPart heroDialogPartAkara5 = new HeroDialogPart("W takim razie radź sobie sam.", npcDialogPartAkaraEnd);
		npcDialogPartAkara3.heroDialogs.Add(heroDialogPartAkara4);
		npcDialogPartAkara3.heroDialogs.Add(heroDialogPartAkara5);
		
		NpcDialogPart npcDialogPartCharsi1 = new NpcDialogPart("Witaj, podróżniku #HERONAME#.Potrzebujesz jakiejś broni ?");
		NpcDialogPart npcDialogPartCharsi2 = new NpcDialogPart("Oto nasza oferta:\n1. Miecz +1 za 100 złota\n2. Łuk +1 za 80 złota\n3. Tarcza +1 za 50 złota");
		NpcDialogPart npcDialogPartCharsi3 = new NpcDialogPart("Dobry wybor!");
		NpcDialogPart npcDialogPartCharsiEnd = new NpcDialogPart("<KONIEC>");
		NonPlayerCharacter nonPlayerCharacterCharsi = new NonPlayerCharacter("Charsi", npcDialogPartCharsi1);
		localizationSilverymoon.npc.Add(nonPlayerCharacterCharsi);
		
		HeroDialogPart heroDialogPartCharsi1 = new HeroDialogPart("Tak, chciałbym zakupić nową broń.", npcDialogPartCharsi2);
		HeroDialogPart heroDialogPartCharsi2 = new HeroDialogPart("Nie, dzięki, mam już wystarczającą ilosc broni.", npcDialogPartCharsiEnd);
		npcDialogPartCharsi1.heroDialogs.Add(heroDialogPartCharsi1);
		npcDialogPartCharsi1.heroDialogs.Add(heroDialogPartCharsi2);
		
		HeroDialogPart heroDialogPartCharsi3 = new HeroDialogPart("Wybieram miecz", npcDialogPartCharsi3);
		HeroDialogPart heroDialogPartCharsi4 = new HeroDialogPart("Wybieram łuk", npcDialogPartCharsi3);
		HeroDialogPart heroDialogPartCharsi5 = new HeroDialogPart("Wybieram tarcze", npcDialogPartCharsi3);
		HeroDialogPart heroDialogPartCharsi6 = new HeroDialogPart("Nic, dziękuję", npcDialogPartCharsiEnd);
		npcDialogPartCharsi2.heroDialogs.Add(heroDialogPartCharsi3);
		npcDialogPartCharsi2.heroDialogs.Add(heroDialogPartCharsi4);
		npcDialogPartCharsi2.heroDialogs.Add(heroDialogPartCharsi5);
		npcDialogPartCharsi2.heroDialogs.Add(heroDialogPartCharsi6);
		
		NonPlayerCharacter nonPlayerCharacter = ShowLocation(localizationSilverymoon);
		TalkTo(nonPlayerCharacter, new DialogParse(newHero));
	}


	static void Main()
	{
		Console.WriteLine("Witaj w grze Heroes");
		Console.WriteLine("[1] Zacznij nową grę");
		Console.WriteLine("[X] Zamknij program");
		string choice = Console.ReadLine();
		
		while (choice != "1" && choice != "x")
		{
			Console.WriteLine("Wybrales zla opcje, wybierz jeszcze raz");
			choice = Console.ReadLine();
		}
		if (choice == "1")
			newGame();
		else
			Environment.Exit(0);
	}
}