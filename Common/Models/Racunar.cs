using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class Racunar
    {
        private int id_racunara;
        private string proizvodjac;
        private double brzina_procesora;
        private int kapacitet_RAM;
        private int kapacitet_memorije;
        private Vrsta_racunara vrsta_racunara;

        private Racunar(int iD_racunara, string proizvodjac, double brzina_procesora, int kapacitet_RAM, int kapacitet_memorije, Vrsta_racunara vrsta_racunara)
        {
            ID_racunara = iD_racunara;
            Proizvodjac = proizvodjac;
            Brzina_procesora = brzina_procesora;
            Kapacitet_RAM = kapacitet_RAM;
            Kapacitet_memorije = kapacitet_memorije;
            Vrsta_racunara = vrsta_racunara;
            this.Komponenta = new HashSet<Komponenta>();
            this.Posjeduje = new HashSet<Posjeduje>();
        }

        public Racunar() {
            this.Komponenta = new HashSet<Komponenta>();
            this.Posjeduje = new HashSet<Posjeduje>();
        }

        public virtual ICollection<Komponenta> Komponenta { get; set; }
        public virtual ICollection<Posjeduje> Posjeduje { get; set; }
        public int ID_racunara { get => id_racunara; set => id_racunara = value; }
        public string Proizvodjac { get => proizvodjac; set => proizvodjac = value; }
        public double Brzina_procesora { get => brzina_procesora; set => brzina_procesora = value; }
        public int Kapacitet_RAM { get => kapacitet_RAM; set => kapacitet_RAM = value; }
        public int Kapacitet_memorije { get => kapacitet_memorije; set => kapacitet_memorije = value; }
        public Vrsta_racunara Vrsta_racunara { get => vrsta_racunara; set => vrsta_racunara = value; }
    }
}
