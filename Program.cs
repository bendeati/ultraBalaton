using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ubBalaton
{
    class Program
    {
        static List<UbClass> ubLista = new List<UbClass>();

        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("ub2017egyeni.txt",Encoding.UTF8);
            string sor = sr.ReadLine(); //az első sort beolvastam
            while (!sr.EndOfStream)
            {
                sor = sr.ReadLine();
                UbClass ub = new UbClass(sor);
                ubLista.Add(ub);
            }
            sr.Close();

            Console.WriteLine("3. feladat");
            Console.WriteLine("Egyéni indulók: " + ubLista.Count + " fő");

            Console.WriteLine("4. feladat");
            int noiSportolo = 0;
            for (int i = 0; i < ubLista.Count; i++)
            {
                if (ubLista[i].Kategoria == "Noi" && ubLista[i].TavSzazalek == 100)
                {
                    noiSportolo++;
                }
            }
            Console.WriteLine("Célba érkező női sportolók: " + noiSportolo + " fő");

            Console.WriteLine("5. feladat");
            Console.Write("Kérek egy sportoló nevet: ");
            string nev = Console.ReadLine();
            int index = 0;
            bool megvan = false;
            while (!megvan && index < ubLista.Count)
            {
                if (ubLista[index].Versenyzo == nev)
                {
                    megvan = true;
                }
                index++;
            }
            Console.Write("Indult egyéniben a sportoló? ");
            if (megvan == true)
            {
                Console.WriteLine("Igen");
                Console.Write("A teljes távot teljesítette-e? ");
                if (ubLista[index-1].TavSzazalek == 100)
                {
                    Console.WriteLine("Igen");
                }
                else
                {
                    Console.WriteLine("Nem");
                }
            }
            else
            {
                Console.WriteLine("Nem");
            }

            Console.WriteLine("7. feladat");
            double ossz = 0;
            int db = 0;
            for (int i = 0; i < ubLista.Count; i++)
            {
                if (ubLista[i].Kategoria == "Ferfi" && ubLista[i].TavSzazalek == 100)
                {
                    ossz += ubLista[i].idoOraban();
                    db++;
                }
            }
            Console.WriteLine("Átlagos idő: " + (ossz/db) + "óra");

            Console.WriteLine("8. feladat Verseny győztesei:");
            double legjobbNoIdo = ubLista[0].idoOraban();
            int legjobbNoIndex = 0;
            for (int i = 0; i < ubLista.Count; i++)
            {
                if (ubLista[i].Kategoria == "Noi" && ubLista[i].TavSzazalek == 100 
                    && ubLista[i].idoOraban() < legjobbNoIdo)
                {
                    legjobbNoIdo = ubLista[i].idoOraban();
                    legjobbNoIndex = i;
                }
            }
            Console.WriteLine("Női:");
            Console.WriteLine(ubLista[legjobbNoIndex].Versenyzo 
                + "(" + ubLista[legjobbNoIndex].Rajtszam + ")"
                + ubLista[legjobbNoIndex].Versenyido);

            Console.ReadKey();
        }
    }
}
