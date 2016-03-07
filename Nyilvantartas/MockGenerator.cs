using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nyilvantartas
{
    static class MockGenerator
    {
        #region Deklarálások
        static Random rand = new Random();
        private static DateTime start = new DateTime(1995, 1, 1);
        #endregion

        #region Publikus metódusok
        //A háromféle dolgozónkat legyártó metódusok

        public static Alkalmazott createNewAlkalmazott()
        {
            List<string> alapadatok = RandomDolgozoAdatok();
            string nev = alapadatok[0];
            string cim = alapadatok[1];
            string adoszam = alapadatok[2];
            int alapfizetes = rand.Next(8000);
            string belsoAzon = RandomString(2);
            string beosztas = RandomString(4);
            int tuloradij = rand.Next(500);


            Alkalmazott item = new Alkalmazott(nev,cim,adoszam,alapfizetes,belsoAzon,beosztas,tuloradij);
            return item;
        }

        public static Alvallalkozo createNewAlvallalkozo()
        {
            List<string> alapadatok = RandomDolgozoAdatok();
            string nev = alapadatok[0];
            string cim = alapadatok[1];
            string adoszam = alapadatok[2];
            int alapfizetes = rand.Next(8000);
            DateTime szerzodesVege = RandomDate();
            string feladat = RandomString(9);
            int sikerdij = rand.Next(500);

            Alvallalkozo item = new Alvallalkozo(nev, cim, adoszam,alapfizetes,szerzodesVege,feladat,sikerdij);
            return item;
        }

        public static Kiszervezett createNewKiszervezett()
        {
            List<string> alapadatok = RandomDolgozoAdatok();
            string nev = alapadatok[0];
            string cim = alapadatok[1];
            string adoszam = alapadatok[2];
            int alapfizetes = rand.Next(8000);
            string munkakor = RandomString(8);
            string munkaltato = RandomString(14);
            int muszakpotlek = rand.Next(600);

            Kiszervezett item = new Kiszervezett(nev, cim, adoszam,alapfizetes,munkakor,munkaltato,muszakpotlek);
            return item;
        }

        #endregion

        #region Belső metódusok
        //Az osztályok elkészítéséhez szükséges belső metódusok: random string, random dátum, és egy minden dolgozóra felhasználható alapadat-generátorok

        private static string RandomString(int hossz)
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789-";
            char[] stringChars = new char[rand.Next(2, hossz)];
            

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[rand.Next(chars.Length)];
            }

            return new String(stringChars);
        }

        private static DateTime RandomDate()
        {
            int range = (DateTime.Today - start).Days;
            return start.AddDays(rand.Next(range));
        }

        private static List<String> RandomDolgozoAdatok()
        {
            List<String> adatok = new List<string>();
            adatok.Add(RandomString(9) + " " + RandomString(9));
            adatok.Add(RandomString(8));
            adatok.Add(RandomString(12));
            return adatok;
        }

        #endregion
    }
}
