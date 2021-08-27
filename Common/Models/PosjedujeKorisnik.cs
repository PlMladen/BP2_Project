using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class PosjedujeKorisnik : Posjeduje
    {
        public string KorisnickoIme { get; set; }
        public string Lozinka { get; set; }
        public string Uloga { get; set; }
        public bool ProfilOdobren { get; set; }
    }
}
