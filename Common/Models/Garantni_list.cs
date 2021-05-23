using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class Garantni_list : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private int id_gar_list;
        private System.DateTime period_vazenja;

        public int Id_gar_list
        {
            get
            {
                return id_gar_list;
            }
            set
            {
                if (id_gar_list != value)
                {
                    id_gar_list = value;
                    RaisePropertyChanged("Id_gar_list");
                }
            }
        }
        public DateTime Period_vazenja 
        {
            get
            {
                return period_vazenja;
            }
            set
            {
                if (period_vazenja != value)
                {
                    period_vazenja = value;
                    RaisePropertyChanged("Period_vazenja");
                }
            }
        }

        public Garantni_list()
        {
            //this.Servisira = new HashSet<Servisira>();
        }



        //public virtual ICollection<Servisira> Servisira { get; set; }
        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
