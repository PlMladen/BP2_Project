using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class Korisnik
    {
        public long JMBG { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string KorisnickoIme { get; set; }
        public string Lozinka { get; set; }
        public Adresa Adresa { get; set; }
        public string Uloga { get; set; }
        public DateTime DatumRodjenja { get; set; }
    }
}
