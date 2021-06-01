using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class SqlUpitVlasnikServisCijena
    {
        public long JMBG_vlasnika { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public double Cijena { get; set; }
        public string Naziv_servisa { get; set; }

        public override string ToString()
        {
            return "JMBG vlasnika: "+JMBG_vlasnika+"\nIme i prezime: "+Ime+" "+Prezime+"\nObavljeno u servisu: "+Naziv_servisa+" [Cijena: "+Cijena+" RSD]";
        }
    }
}
