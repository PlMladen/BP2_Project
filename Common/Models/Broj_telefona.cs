using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class Broj_telefona
    {
        public Broj_telefona(int pozivni_broj, int okrug, int broj)
        {
            Pozivni_broj = pozivni_broj;
            Okrug = okrug;
            Broj = broj;
        }

        public Broj_telefona()
        {
            Pozivni_broj = -1;
            Okrug = -1;
            Broj = -1;
        }

        public int Pozivni_broj { get; set; }
        public int Okrug { get; set; }
        public int Broj { get; set; }

        public override string ToString()
        {
            return Pozivni_broj+" "+Okrug+Broj;
        }
    }
}
