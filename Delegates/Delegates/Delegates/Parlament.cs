using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParlamentN
{
	public delegate void Notify();
	public delegate void Notify1(bool glos);
	class Parlament
	{
		public event Notify poczatekGlosowaniaEvent;
		public event Notify koniecGlosowaniaEvent;
		public List<Parlamentarzysta> parlamentarzysci;
		public string tematGlosowania;
		public int liczbaParlamentarzystow;
		public int zaGlosy;
		public int przeciwGlosy;
		public Parlament(string tematGlosowania, int liczbaParlamentarzystow)
		{
			parlamentarzysci = new List<Parlamentarzysta>(liczbaParlamentarzystow);
			this.tematGlosowania = tematGlosowania;
			this.liczbaParlamentarzystow = liczbaParlamentarzystow;
			zaGlosy = 0;
			przeciwGlosy = 0;
			for (int i = 0; i < liczbaParlamentarzystow; i++)
			{
				parlamentarzysci.Add(new Parlamentarzysta(i, this));
				poczatekGlosowaniaEvent += parlamentarzysci[i].SetMozeGlosowacTrue;
				koniecGlosowaniaEvent += parlamentarzysci[i].SetMozeGlosowacFalse;
			}
		}
		public void StartGlosowania(string temat)
		{
			if (tematGlosowania == temat)
			{
				OnPoczatekGlosowania();
				Console.WriteLine("Glosowanie rozpoczelo sie na temat: " + temat);
			}
		}
		void OnPoczatekGlosowania()
		{
			poczatekGlosowaniaEvent?.Invoke();
		}
		void OnKoniecGlosowania()
		{
			koniecGlosowaniaEvent?.Invoke();
		}
		public void KoniecGlosowania()
		{
			OnKoniecGlosowania();
			OstatnieGlosowanie();
			Console.WriteLine("Koniec glosowania");
		}
		private void OstatnieGlosowanie()
		{
			Console.WriteLine("Ostatnie glosowanie na temat:" + tematGlosowania + " liczba glosow za: " + zaGlosy + " liczba glosow przeciw: " + przeciwGlosy);
		}
		public void glosParlamentarzysty(bool glos)
		{
			if (glos)
				zaGlosy++;
			else
				przeciwGlosy++;
		}

	}
	class Parlamentarzysta
	{
		bool mozeGlosowac;
		int numer;
		bool glos;
		public event Notify1 oddanieGlosuEvent;
		public Parlamentarzysta(int numer, Parlament p)
		{
			mozeGlosowac = false;
			this.numer = numer;
			oddanieGlosuEvent += p.glosParlamentarzysty;
		}
		public void SetMozeGlosowacTrue()
		{
			mozeGlosowac = true;
		}
		public void SetMozeGlosowacFalse()
		{
			mozeGlosowac = false;
		}
		public void Glosuj()
		{
			if (mozeGlosowac)
			{
				Random rand = new Random();
				glos = rand.Next(2) == 0;
				OnOddanieGlosu(glos);
				SetMozeGlosowacFalse();
				Console.Write("Parlamentarzysta " + numer + " oddaje glos na: " + glos);
			}
			else
			{
				Console.WriteLine("Nie mozesz oddac glosu, bo juz to zrobiles lub glosowanie sie nie odbywa");
			}
		}
		void OnOddanieGlosu(bool b)
		{
			oddanieGlosuEvent?.Invoke(b);
		}

	}
}
