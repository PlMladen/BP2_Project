using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class Servis : INotifyPropertyChanged
    {
        private int id_servisa;
        private string naziv_servisa;
        private Tip_servisa tip_servisa;
        private Adresa adresa_servisa;
        private Broj_telefona br_tel_servisa;
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

        public int ID_servisa 
        {
            get
            { 
                return id_servisa;
            } 
            set
            {
                if(id_servisa != value)
                {
                    id_servisa = value;
                    RaisePropertyChanged("ID_servisa");
                }
            }
        }
        public string Naziv_serv 
        {
            get
            {
                return naziv_servisa;
            }
            set
            {
                if(naziv_servisa != value)
                {
                    naziv_servisa = value;
                    RaisePropertyChanged("Naziv_servisa");
                }
            }
        }
        public Tip_servisa Tip_serv 
        {
            get
            {
                return tip_servisa; 
            }
            set
            {
                if(tip_servisa != value)
                {
                    tip_servisa = value;
                    RaisePropertyChanged("Tip_servisa");
                }
            }
        }

        public Adresa Adresa_serv
        {
            get
            {
                return adresa_servisa;
            }
            set
            {
                if(adresa_servisa != value)
                {
                    adresa_servisa = value;
                    RaisePropertyChanged("Adresa_servisa");
                }
            }
        }
        public Broj_telefona Br_tel_serv
        {
            get
            {
                return br_tel_servisa;
            }
            set
            {
                if(br_tel_servisa != value)
                {
                    br_tel_servisa = value;
                    RaisePropertyChanged("Br_tel_servisa");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
