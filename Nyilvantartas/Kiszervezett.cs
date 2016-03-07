using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nyilvantartas
{
    class Kiszervezett : Dolgozo, IComparable   
    {
        #region propok, alapadatok
        public string Munkakor { get; private set; }
        public string Munkaltato { get; private set; } //A munkáltatót külön osztályba illene tenni, de most egyelőre egy string is megteszi
        public int Muszakpotlek { get; private set; }
        public enum SortFieldType { SortMunkaltato, SortNev }
        public static SortFieldType sortField = Kiszervezett.SortFieldType.SortNev; // alapból név szerint sortolunk
        #endregion

        #region konstruktor, metódusok
        public Kiszervezett(string nev, string cim, string adoszam, int alapfizetes, string munkakor, string munkaltato, int muszakpotlek) : base(nev, cim, adoszam, alapfizetes)
        {
            this.Munkakor = munkakor;
            this.Munkaltato = munkaltato;
            this.Muszakpotlek = muszakpotlek;
        }


        public override int Fizetes()
        {
            return (Alapfizetes + Muszakpotlek);
        }
        #endregion

        #region ToString és CompareTo
        public override string ToString()
        {
            return Munkaltato + ", " + Nev;
        }

        public int CompareTo(object other)
        {

            int ret = -1;
            if (other is Dolgozo)
            {
                if (sortField == Kiszervezett.SortFieldType.SortMunkaltato && other is Kiszervezett)
                {
                    ret = Munkaltato.CompareTo((other as Kiszervezett).Munkaltato);
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
