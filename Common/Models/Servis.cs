using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class Servis
    {
        public Servis()
        {
            this.Adresa_serv = new Adresa();
            this.Br_tel_serv = new Broj_telefona();
        }

        public Servis(int iD_servisa, string naziv_serv, Tip_servisa tip_serv, Adresa adresa_serv, Broj_telefona br_tel_serv)
        {
            ID_servisa = iD_servisa;
            Naziv_serv = naziv_serv;
            Tip_serv = tip_serv;
            Adresa_serv = adresa_serv;
            Br_tel_serv = br_tel_serv;
        }

        public int ID_servisa { get; set; }
        public string Naziv_serv { get; set; }
        public Tip_servisa Tip_serv { get; set; }

        public Adresa Adresa_serv { get; set; }
        public Broj_telefona Br_tel_serv { get; set; }
    }
}
