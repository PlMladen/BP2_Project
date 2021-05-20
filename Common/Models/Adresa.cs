using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class Adresa
    {
        public Adresa(string ulica, string grad, int broj, int postanskiBroj)
        {
            Ulica = ulica;
            Grad = grad;
            Broj = broj;
            PostanskiBroj = postanskiBroj;
        }

        public Adresa()
        {
            Ulica = "";
            Grad = "";
            Broj = -1;
            PostanskiBroj = -1;
        }
        public string Ulica { get; set; }
        public string Grad { get; set; }
        public int Broj { get; set; }
        public int PostanskiBroj { get; set; }
    }
}
