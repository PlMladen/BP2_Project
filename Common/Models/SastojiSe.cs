using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class SastojiSe : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int komponentaId_komp;
        private int komponentaId_komp1;

        private Komponenta komponenta;
        private Komponenta komponenta1;

        public int KomponentaId_komp
        {
            get
            {
                return komponentaId_komp;
            }
            set
            {
                if (komponentaId_komp != value)
                {
                    komponentaId_komp = value;
                    RaisePropertyChanged("KomponentaId_komp");
                }
            }
        }
        public int KomponentaId_komp1 
        {
            get
            {
                return komponentaId_komp1;
            }
            set
            {
                if (komponentaId_komp1 != value)
                {
                    komponentaId_komp1 = value;
                    RaisePropertyChanged("KomponentaId_komp1");
                }
            }
        }
        public Komponenta Komponenta 
        {
            get
            {
                return komponenta;
            }
            set
            {
                if (komponenta != value)
                {
                    komponenta = value;
                    RaisePropertyChanged("Komponenta");
                }
            }
        }
        public Komponenta Komponenta1
        {
            get
            {
                return komponenta1;
            }
            set
            {
                if (komponenta1 != value)
                {
                    komponenta1 = value;
                    RaisePropertyChanged("Komponenta1");
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
