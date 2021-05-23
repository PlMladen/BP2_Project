using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class Komponenta : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private int id_komp;
        private string naz_komp;
        private double cijena_komp;
        private Nullable<int> racunarID_racunara;
        public Komponenta()
        {
            /*this.Sastoji_se = new HashSet<Sastoji_se>();
            this.Sastoji_se1 = new HashSet<Sastoji_se>();*/
        }

        

        //public virtual ICollection<Sastoji_se> Sastoji_se { get; set; }
        //public virtual ICollection<Sastoji_se> Sastoji_se1 { get; set; }
        public virtual Racunar Racunar { get; set; }
        public int Id_komp
        {
            get
            {
                return id_komp;
            }
            set
            {
                if (id_komp != value)
                {
                    id_komp = value;
                    RaisePropertyChanged("Id_komp");
                }
            }
        }
        public string Naz_komp 
        {
            get
            {
                return naz_komp;
            }
            set
            {
                if (naz_komp != value)
                {
                    naz_komp = value;
                    RaisePropertyChanged("Naz_komp");
                }
            }
        }
        public double Cijena_komp 
        {
            get
            {
                return cijena_komp;
            }
            set
            {
                if (cijena_komp != value)
                {
                    cijena_komp = value;
                    RaisePropertyChanged("Cijena_komp");
                }
            }
        }
        public int? RacunarID_racunara 
        {
            get
            {
                return racunarID_racunara;
            }
            set
            {
                if (racunarID_racunara != value)
                {
                    racunarID_racunara = value;
                    RaisePropertyChanged("RacunarID_racunara");
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
