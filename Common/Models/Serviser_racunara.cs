using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class Serviser_racunara : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private long jmbg_s;
        private string ime_s;
        private string prezime_s;
        private DateTime dat_rodjenja_s;

        public Serviser_racunara()
        {
            //this.Radi = new HashSet<Radi>();
        }

        public long JMBG_s
        {
            get
            {
                return jmbg_s;
            }
            set
            {
                if (jmbg_s != value)
                {
                    jmbg_s = value;
                    RaisePropertyChanged("JMBG_s");
                }
            }
        }
        public string Ime_s
        {
            get
            {
                return ime_s;
            }
            set
            {
                if(ime_s != value)
                {
                    ime_s = value;
                    RaisePropertyChanged("Ime_s");
                }
            }
        }
        public string Prezime_s 
        {
            get
            {
                return prezime_s;
            }
            set
            {
                if(prezime_s != value)
                {
                    prezime_s = value;
                    RaisePropertyChanged("Prezime_s");
                }
            }
        }
        public System.DateTime Dat_rodjenja_s
        {
            get
            {
                return dat_rodjenja_s;
            }
            set
            {
                if(dat_rodjenja_s != value)
                {
                    dat_rodjenja_s = value;
                    RaisePropertyChanged("Dat_rodjenja_s");
                }
            }
        }

        //public virtual ICollection<Radi> Radi { get; set; }

        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
