using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class Radi : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        
        private int racunarski_servisID_servisa;
        private long serviser_racunaraJMBG_s;
        
        private  Racunarski_servis racunarski_servis;
        private  Serviser_racunara serviser_racunara;
        private  ICollection<Servisira> servisira;
        public Radi()
        {
            this.Servisira = new HashSet<Servisira>();
        }

        

        public int Racunarski_servisID_servisa1 
        {
            get
            {
                return racunarski_servisID_servisa;
            }
            set
            {
                if (racunarski_servisID_servisa != value)
                {
                    racunarski_servisID_servisa = value;
                    RaisePropertyChanged("Racunarski_servisID_servisa1");
                }
            }
        }
        public long Serviser_racunaraJMBG_s 
        {
            get
            {
                return serviser_racunaraJMBG_s;
            }
            set
            {
                if (serviser_racunaraJMBG_s != value)
                {
                    serviser_racunaraJMBG_s = value;
                    RaisePropertyChanged("Serviser_racunaraJMBG_s");
                }
            }
        }
        public Racunarski_servis Racunarski_servis 
        {
            get
            {
                return racunarski_servis;
            }
            set
            {
                if (racunarski_servis != value)
                {
                    racunarski_servis = value;
                    RaisePropertyChanged("Racunarski_servis");
                }
            }
        }
        public Serviser_racunara Serviser_racunara 
        {
            get
            {
                return serviser_racunara;
            }
            set
            {
                if (serviser_racunara != value)
                {
                    serviser_racunara = value;
                    RaisePropertyChanged("Serviser_racunara");
                }
            }
        }
        public ICollection<Servisira> Servisira 
        {
            get
            {
                return servisira;
            }
            set
            {
                if (servisira != value)
                {
                    servisira = value;
                    RaisePropertyChanged("Servisira");
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
