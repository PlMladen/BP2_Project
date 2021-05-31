using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class Posjeduje : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private long jmbg_vl;
        private string ime_vl;
        private string prezime_vl;
        private int id_racunara;
        private string proizvodjac_racunara;
        private Vrsta_racunara vrsta_racunara;
        private Racunar racunar;
        private Vlasnik_racunara vlasnik_racunara;

        public long JMBG_vl
        {
            get
            {
                return jmbg_vl;
            }
            set
            {
                if (jmbg_vl != value)
                {
                    jmbg_vl = value;
                    RaisePropertyChanged("JMBG_vl");
                }
            }
        }

        public Racunar Racunar
        {
            get
            {
                return racunar;
            }
            set
            {
                if (racunar != value)
                {
                    racunar = value;
                    RaisePropertyChanged("Racunar");
                }
            }
        }
        public Vlasnik_racunara Vlasnik_racunara
        {
            get
            {
                return vlasnik_racunara;
            }
            set
            {
                if (vlasnik_racunara != value)
                {
                    vlasnik_racunara = value;
                    RaisePropertyChanged("Vlasnik_racunara");
                }
            }
        }
         public string Ime_vl 
         {
             get
             {
                 return ime_vl;
             }
             set
             {
                 if (ime_vl != value)
                 {
                     ime_vl = value;
                     RaisePropertyChanged("Ime_vl");
                 }
             }
         }
         public string Prezime_vl 
         {
             get
             {
                 return prezime_vl;
             }
             set
             {
                 if (prezime_vl != value)
                 {
                     prezime_vl = value;
                     RaisePropertyChanged("Prezime_vl");
                 }
             }
         }
         
        public int Id_racunara 
        {
            get
            {
                return id_racunara;
            }
            set
            {
                if (id_racunara != value)
                {
                    id_racunara = value;
                    RaisePropertyChanged("Id_racunara");
                }
            }
        }
        public string Proizvodjac_racunara 
        {
            get
            {
                return proizvodjac_racunara;
            }
            set
            {
                if (proizvodjac_racunara != value)
                {
                    proizvodjac_racunara = value;
                    RaisePropertyChanged("Proizvodjac_racunara");
                }
            }
        }
        public Vrsta_racunara Vrsta_racunara 
        {
            get
            {
                return vrsta_racunara;
            }
            set
            {
                if (vrsta_racunara != value)
                {
                    vrsta_racunara = value;
                    RaisePropertyChanged("Vrsta_racunara");
                }
            }
        }
        
        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

    }
}
