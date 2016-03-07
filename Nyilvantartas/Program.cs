using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nyilvantartas
{
    class Program
    {
        #region Deklarálások
        static List<Dolgozo> alkalmazottLista = new List<Dolgozo>();
        static List<Dolgozo> alvallalkozoLista = new List<Dolgozo>();
        static List<Dolgozo> kiszervezettLista = new List<Dolgozo>();
        static List<Dolgozo> dolgozoLista = new List<Dolgozo>();
        static List<Dolgozo> rendezhetoLista = new List<Dolgozo>();
        #endregion

        static void Main(string[] args)
        {
            
            double choice = 0;
            

            #region Különálló listák feltöltése

            for (int i = 0; i < 6; i++)
            {
                alkalmazottLista.Add(MockGenerator.createNewAlkalmazott());
                alvallalkozoLista.Add(MockGenerator.createNewAlvallalkozo());
                kiszervezettLista.Add(MockGenerator.createNewKiszervezett());
            }

            #endregion

            #region Összegzés egy listába, valamint a rendezhetőlistába a rendezhetők
            dolgozoLista.AddRange(alkalmazottLista);
            dolgozoLista.AddRange(alvallalkozoLista);
            dolgozoLista.AddRange(kiszervezettLista);

            rendezhetoLista.AddRange(alvallalkozoLista);
            rendezhetoLista.AddRange(kiszervezettLista);
            rendezhetoLista.Sort();
            #endregion

            #region Indítómenü, maga a program futása
            while(choice != 1 && choice != 2)
            {
                Console.WriteLine("Csak a dolgozó, és a közös rendezett lista kiírása \t (1)");
                Console.WriteLine("Az összes lista kiírása \t\t\t\t (2)");
                choice = Char.GetNumericValue(Console.ReadKey().KeyChar);
                Console.Clear();
            }
            if (choice == 1)
            {
                KozosKiiras();
            }
            else
            {
                MindentKiir();
            }

            Console.ReadLine();
            #endregion
        }


        #region Metódusok

        private static void MindentKiir()
        {
            #region Kiírások
            //Mivel konzolos applikáció, most nem akartam külön a megjelenítésért felelő osztályt készíteni, mert nem lett volna különösebb értelme

            writeInRed("\n*** Az alkalmazottLista tartalmának kiírása ***\n(beosztás, név)\n");
            foreach (Alkalmazott item in alkalmazottLista)
            {
                Console.WriteLine(item);
            }

            writeInRed("\n*** Az alvallalkozoLista tartalmának kiírása ***\n(szerződés vége, név)\n");
            foreach (Alvallalkozo item in alvallalkozoLista)
            {
                Console.WriteLine(item);
            }

            writeInRed("\n*** Az alvallalkozoLista tartalmának kiírása, név szerint rendezve ***\n(szerződés vége, név)\n");
            alvallalkozoLista.Sort();
            foreach (Alvallalkozo item in alvallalkozoLista)
            {
                Console.WriteLine(item);
            }

            writeInRed("\n*** Az alvallalkozoLista tartalmának kiírása, a dátum szerint rendezve ***\n(szerződés vége, név)\n");
            Alvallalkozo.sortField = Alvallalkozo.SortFieldType.SortDatum;
            alvallalkozoLista.Sort();
            foreach (Alvallalkozo item in alvallalkozoLista)
            {
                Console.WriteLine(item);
            }

            writeInRed("\n*** A kiszervezettLista tartalmának kiírása ***\n(munkáltató, név)\n");
            foreach (Kiszervezett item in kiszervezettLista)
            {
                Console.WriteLine(item);
            }

            writeInRed("\n*** A kiszervezettLista tartalmának kiírása, név szerint rendezve ***\n(munkáltató, név)\n");
            kiszervezettLista.Sort();
            foreach (Kiszervezett item in kiszervezettLista)
            {
                Console.WriteLine(item);
            }

            writeInRed("\n*** A kiszervezettLista tartalmának kiírása, munkáltató szerint rendezve ***\n(munkáltató, név)\n");
            Kiszervezett.sortField = Kiszervezett.SortFieldType.SortMunkaltato;
            kiszervezettLista.Sort();
            foreach (Kiszervezett item in kiszervezettLista)
            {
                Console.WriteLine(item);
            }

            KozosKiiras();

            #endregion
        }

        private static void KozosKiiras()
        {
            writeInRed("\n*** A dolgozoLista tartalmának kiírása ***\n(név, cím)\n");
            foreach (Dolgozo item in dolgozoLista)
            {
                Console.WriteLine(item.Nev + ", " + item.Cim);

            }

            writeInRed("\n*** A dolgozoLista tartalmának kiírása ***\n(név, fizetés)\n");
            foreach (Dolgozo item in dolgozoLista)
            {
                Console.WriteLine(item.Nev + ", " + item.Fizetes());

            }

            writeInRed("\n*** A rendezhetoLista tartalmának kiírása, név szerint sorbarakva ***\n(csak név és a példányok osztályai)\n");
            foreach (Dolgozo item in rendezhetoLista)
            {
                Console.WriteLine(item.Nev + "\t\t(" + item.GetType().Name + ")");

            }
        }

        //A konzolunk olvashatóbbá tételét szolgálja
        private static void writeInRed(string szoveg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(szoveg);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        #endregion

    }
}
