using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class Vlasnik_racunara : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private long jmbg_vl;
        private string ime_vl;
        private string prezime_vl;
        private System.DateTime dat_rodjenja_vl;
        private Adresa adresa_vl;

        public virtual ICollection<Posjeduje> Posjeduje { get; set; }
        

        public Vlasnik_racunara()
        {
            this.Posjeduje = new HashSet<Posjeduje>();
            this.Adresa_vl = new Adresa();
        }
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
        public DateTime Dat_rodjenja_vl 
        {
            get
            {
                return dat_rodjenja_vl;
            }
            set
            {
                if (dat_rodjenja_vl != value)
                {
                    dat_rodjenja_vl = value;
                    RaisePropertyChanged("Dat_rodjenja_vl");

                }
            }
        }
        public Adresa Adresa_vl 
        {
            get
            {
                return adresa_vl;
            }
            set
            {
                if (adresa_vl != value)
                {
                    adresa_vl = value;
                    RaisePropertyChanged("Adresa_vl");

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
