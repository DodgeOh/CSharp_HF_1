using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nyilvantartas
{
    class Alvallalkozo : Dolgozo, IComparable
    {
        #region propok, alapadatok
        public DateTime SzerzodesVege { get; private set; }
        public string Feladat { get; private set; }
        public int Sikerdij { get; private set; }
        public enum SortFieldType { SortDatum, SortNev }
        public static SortFieldType sortField = Alvallalkozo.SortFieldType.SortNev; // alapból név szerint sortolunk
        #endregion

        #region Konstruktor, metódusok
        public Alvallalkozo(string nev, string cim, string adoszam, int alapfizetes, DateTime szerzodesVege, string feladat, int sikerdij) : base(nev, cim, adoszam, alapfizetes)
        {
            this.SzerzodesVege = szerzodesVege;
            this.Feladat = feladat;
            this.Sikerdij = sikerdij;
        }

        public override int Fizetes()
        {
            return (Alapfizetes + Sikerdij);
        }
        #endregion

        #region ToString, CompareTo
        public override string ToString()
        {
            return  SzerzodesVege.ToShortDateString() + ", " + Nev;
        }

        public int CompareTo(object other)
        {

            int ret = -1;
            if (other is Dolgozo)
            {
                if (sortField == Alvallalkozo.SortFieldType.SortDatum && other is Alvallalkozo)
                {
                    ret = SzerzodesVege.CompareTo((other as Alvallalkozo).SzerzodesVege);
                }
                else
                {
                    ret = Nev.CompareTo((other as Dolgozo).Nev);
                }
            }
            return ret;
        }
        #endregion
    }
}
