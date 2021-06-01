using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class Donosi : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private int racunarski_servisID_servisa;
        private long posjedujeVlasnik_racunaraJMBG_vl;
        private int posjedujeRacunarID_racunara;

        private  Racunarski_servis racunarski_servis;
        private  Posjeduje posjeduje;
        private  ICollection<Servisira> servisira;

        public Donosi()
        {
            this.Servisira = new HashSet<Servisira>();
        }

        public int Racunarski_servisID_servisa 
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
                    RaisePropertyChanged("Racunarski_servisID_servisa");
                }
            }
        }
        public long PosjedujeVlasnik_racunaraJMBG_vl 
        {
            get
            {
                return posjedujeVlasnik_racunaraJMBG_vl;
            }
            set
            {
                if (posjedujeVlasnik_racunaraJMBG_vl != value)
                {
                    posjedujeVlasnik_racunaraJMBG_vl = value;
                    RaisePropertyChanged("PosjedujeVlasnik_racunaraJMBG_vl");
                }
            }
        }
        public int PosjedujeRacunarID_racunara 
        {
            get
            {
                return posjedujeRacunarID_racunara;
            }
            set
            {
                if (posjedujeRacunarID_racunara != value)
                {
                    posjedujeRacunarID_racunara = value;
                    RaisePropertyChanged("PosjedujeRacunarID_racunara");
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
        public Posjeduje Pposjeduje
        {
            get
            {
                return posjeduje;
            }
            set
            {
                if (posjeduje != value)
                {
                    posjeduje = value;
                    RaisePropertyChanged("Pposjeduje");
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
