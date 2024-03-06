using Common;
using System.Dynamic;
using System.Security.AccessControl;
namespace BeerProcessor
{
    public class ZleceniePiwo :Izlecenie
    {
        public string Title
        {
            get; set;
        }

        public void Process()
        {
            Console.WriteLine(Title);
            Console.WriteLine("Zacieranie:\n-66-67 stopni – 60 minut\n-77 stopni – 10 minut");
            Thread.Sleep(2000);
            Console.WriteLine("gotowanie:\n-60 min – 30g Galaxy\n-45 min – 10g Citra\n-10 min – mech irlandzki\n-5 min – 25g Simcoe\n-0 min – 25g Equonat\n-0 min – 50g Citra");
            Thread.Sleep(2000);
            Console.WriteLine("Fermentacja burzliwa 9 dni (odermentoawało do 2,5 blg).");
            Thread.Sleep(2000);
            Console.WriteLine("Fermentacja cicha 6 dni (chmiel poszedł na 4 ostatnie dni).");
            Thread.Sleep(2000);
            Console.WriteLine("Chmiel na cichą:\n-40g Citra\n-20g Mosaic\n-30g Cascade\n-25g Ekuonat\n-25g Simcoe");
            Thread.Sleep(2000);
            Console.WriteLine("Ostatecznie wyszło około 22 litrów piwa 2,3blg.\n");
        }
    }
}