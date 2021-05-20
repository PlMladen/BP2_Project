using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class Racunar
    {
        public int ID_racunara { get; set; }
        public string Proizvodjac { get; set; }
        public double Brzina_procesora { get; set; }
        public int Kapacitet_RAM { get; set; }
        public int Kapacitet_memorije { get; set; }
        public Vrsta_racunara Vrsta_racunara { get; set; }

        public Racunar(int iD_racunara, string proizvodjac, double brzina_procesora, int kapacitet_RAM, int kapacitet_memorije, Vrsta_racunara vrsta_racunara)
        {
            ID_racunara = iD_racunara;
            Proizvodjac = proizvodjac;
            Brzina_procesora = brzina_procesora;
            Kapacitet_RAM = kapacitet_RAM;
            Kapacitet_memorije = kapacitet_memorije;
            Vrsta_racunara = vrsta_racunara;
        }

        public Racunar() { }
    }
}
