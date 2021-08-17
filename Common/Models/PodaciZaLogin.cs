using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class PodaciZaLogin : INotifyPropertyChanged
    {
        private string email;
        private string lozinka;

        public event PropertyChangedEventHandler PropertyChanged;

        public PodaciZaLogin()
        {
            this.email = String.Empty;
            this.lozinka = String.Empty;
        }

        public string Email 
        {
            get
            { 
                return email;
            }
            set
            {
                if (email != value)
                {
                    email = value;
                    RaisePropertyChanged("Email");
                }
            }
        }
        public string Lozinka
        {
            get
            {
                return lozinka;
            }
            set
            {
                if (lozinka != value)
                {
                    lozinka = value;
                    RaisePropertyChanged("Lozinka");
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
