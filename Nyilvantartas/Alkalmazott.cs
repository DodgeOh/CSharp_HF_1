using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nyilvantartas
{
    class Alkalmazott : Dolgozo
    {
        public string BelsoAzonosito { get; private set; }
        public string Beosztas { get; private set; }
        public int TuloraDij { get; private set; }
        public int Tulora { get; private set; }

        public Alkalmazott(string nev, string cim, string adoszam, int alapfizetes, string belsoAzon, string beosztas, int tuloradij) : base(nev, cim, adoszam, alapfizetes)
        {
            this.Beosztas = beosztas;
            this.BelsoAzonosito = belsoAzon;
            this.TuloraDij = tuloradij;
        }

        public override int Fizetes()
        {
            int fizetes = ((Tulora * TuloraDij) + Alapfizetes);
            Tulora = 0;
            return fizetes;
        }

        public void Tulorazik(int ido)
        {
            Tulora += ido;
        }

        public override string ToString()
        {
            return Beosztas + ", " + Nev; 
        }
    }
}
