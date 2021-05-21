using Common.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientUI.ViewModel
{
    public class ServisViewModel : BindableBase
    {
        private ObservableCollection<Servis> servisi = new ObservableCollection<Servis>(DatabaseServiceProvider.Instance.GetAllServiss());

        public ObservableCollection<Servis> Servisi
        {
            get
            {
                return servisi;
            }
            set
            {
                if(servisi != value)
                {
                    servisi = value;
                    OnPropertyChanged(nameof(Servisi));
                }
            }
        }

        private string lbl = string.Empty;
        private Servis selectedServis;

        public MyICommand DeleteCommand { get; set; }
        public MyICommand AddCommand { get; set; }

        public ServisViewModel()
        {

            DeleteCommand = new MyICommand(OnDelete, CanDelete);
            //AddCommand = new MyICommand()
        }

        public Servis SelectedServis
        {
            get
            {
                return selectedServis;
            }
            set
            {
                selectedServis = value;
                DeleteCommand.RaiseCanExecuteChanged();
            }
        }

        public string LBL
        {
            get => lbl;
            set
            {
                lbl = value;
                OnPropertyChanged("LBL");
            }
        }

        private bool CanDelete()
        {
            return SelectedServis != null;
        }

        private void OnDelete()
        {
            int idServisa = SelectedServis.ID_servisa;
            if (DatabaseServiceProvider.Instance.DeleteServis(idServisa))
            {
                lbl = "Servis (ID: " + idServisa + ") obrisan";
            }
            else
            {
                lbl = "Greska pri brisanju servisa - ID: " + idServisa;
            }
            Servisi = new ObservableCollection<Servis>(DatabaseServiceProvider.Instance.GetAllServiss());
        }
    }
}
