using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class Racunarski_servis : Servis
    {

        private ICollection<Radi> radi;
        private ICollection<Donosi> donosi;
        public Racunarski_servis()
        {
            this.Radi = new HashSet<Radi>();
            this.Donosi = new HashSet<Donosi>();
        }

        public ICollection<Radi> Radi 
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
        public ICollection<Donosi> Donosi 
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
        
    }
}
