using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nyilvantartas
{
    abstract class Dolgozo
    {
        public string Nev { get; private set; }
        public string Cim { get; private set; }
        public string Adoszam { get; private set; }
        public int Alapfizetes { get; private set; }

        public Dolgozo(string nev, string cim, string adoszam, int alapfizetes) 
        {
            this.Nev = nev;
            this.Cim = cim;
            this.Adoszam = adoszam;
            this.Alapfizetes = alapfizetes;
        }

        abstract public int Fizetes();


        public override string ToString()
        {
            return Nev + ", " + Cim;
        }

    }    
}
