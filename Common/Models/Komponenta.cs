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
        public Komponenta()
        {
            /*this.Sastoji_se = new HashSet<Sastoji_se>();
            this.Sastoji_se1 = new HashSet<Sastoji_se>();*/
        }

        public int Id_komp { get; set; }
        public string Naz_komp { get; set; }
        public double Cijena_komp { get; set; }
        public Nullable<int> RacunarID_racunara { get; set; }

        //public virtual ICollection<Sastoji_se> Sastoji_se { get; set; }
        //public virtual ICollection<Sastoji_se> Sastoji_se1 { get; set; }
        public virtual Racunar Racunar { get; set; }
    }
}
