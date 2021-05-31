using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class Servisira : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private double cijena_serv;
        private System.DateTime dat_potp;
        private int radiRacunarski_servisID_servisa;
        private long radiServiser_racunaraJMBG_s;
        private int donosiRacunarski_servisID_servisa;
        private long donosiPosjedujeVlasnik_racunaraJMBG_vl;
        private int donosiPosjedujeRacunarID_racunara;
        private Nullable<int> garantni_listId_gar_list;

        private  Radi radi;
        private  Donosi donosi;
        private  Garantni_list garantni_list;

        public double Cijena_serv 
        {
            get
            {
                return cijena_serv;
            }
            set
            {
                if (cijena_serv != value)
                {
                    cijena_serv = value;
                    RaisePropertyChanged("Cijena_serv");
                }
            }
        }
        public DateTime Dat_potp 
        {
            get
            {
                return dat_potp;
            }
            set
            {
                if (dat_potp != value)
                {
                    dat_potp = value;
                    RaisePropertyChanged("Dat_potp");
                }
            }
        }
        public int RadiRacunarski_servisID_servisa
        {
            get
            {
                return radiRacunarski_servisID_servisa;
            }
            set
            {
                if (radiRacunarski_servisID_servisa != value)
                {
                    radiRacunarski_servisID_servisa = value;
                    RaisePropertyChanged("RadiRacunarski_servisID_servisa");
                }
            }
        }
        public long RadiServiser_racunaraJMBG_s 
        {
            get
            {
                return radiServiser_racunaraJMBG_s;
            }
            set
            {
                if (radiServiser_racunaraJMBG_s != value)
                {
                    radiServiser_racunaraJMBG_s = value;
                    RaisePropertyChanged("RadiServiser_racunaraJMBG_s");
                }
            }
        }
        public int DonosiRacunarski_servisID_servisa 
        {
            get
            {
                return donosiRacunarski_servisID_servisa;
            }
            set
            {
                if (donosiRacunarski_servisID_servisa != value)
                {
                    donosiRacunarski_servisID_servisa = value;
                    RaisePropertyChanged("DonosiRacunarski_servisID_servisa");
                }
            }
        }
        public long DonosiPosjedujeVlasnik_racunaraJMBG_vl 
        {
            get
            {
                return donosiPosjedujeVlasnik_racunaraJMBG_vl;
            }
            set
            {
                if (donosiPosjedujeVlasnik_racunaraJMBG_vl != value)
                {
                    donosiPosjedujeVlasnik_racunaraJMBG_vl = value;
                    RaisePropertyChanged("DonosiPosjedujeVlasnik_racunaraJMBG_vl");
                }
            }
        }
        public int DonosiPosjedujeRacunarID_racunara 
        {
            get
            {
                return donosiPosjedujeRacunarID_racunara;
            }
            set
            {
                if (donosiPosjedujeRacunarID_racunara != value)
                {
                    donosiPosjedujeRacunarID_racunara = value;
                    RaisePropertyChanged("DonosiPosjedujeRacunarID_racunara");
                }
            }
        }
        public int? Garantni_listId_gar_list 
        {
            get
            {
                return garantni_listId_gar_list;
            }
            set
            {
                if (garantni_listId_gar_list != value)
                {
                    garantni_listId_gar_list = value;
                    RaisePropertyChanged("Garantni_listId_gar_list");
                }
            }
        }
        public Radi Radi
        {
            get
            {
                return radi;
            }
            set
            {
                if (radi != value)
                {
                    radi = value;
                    RaisePropertyChanged("Radi");
                }
            }
        }
        public Donosi Donosi 
        {
            get
            {
                return donosi;
            }
            set
            {
                if (donosi != value)
                {
                    donosi = value;
                    RaisePropertyChanged("Donosi");
                }
            }
        }
        public Garantni_list Garantni_list 
        {
            get
            {
                return garantni_list;
            }
            set
            {
                if (garantni_list != value)
                {
                    garantni_list = value;
                    RaisePropertyChanged("Garantni_list");
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
