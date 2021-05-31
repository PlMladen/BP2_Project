using Common.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ClientUI.ViewModel
{
    public class ServiserRacunaraViewModel : BindableBase
    {
        private ObservableCollection<Serviser_racunara> serviseri = new ObservableCollection<Serviser_racunara>(DatabaseServiceProvider.Instance.GetAllServiseriRacunara());
        private Serviser_racunara selectedServiser;
        private Brush foreground = new SolidColorBrush((Color) ColorConverter.ConvertFromString("#FF3AFF00"));
        private string txTBoxJMBGsServ;
        private string txTBoxIme_s;
        private string txtBoxPrezime_s;
        private string lbl = string.Empty;
        private DateTime dpDat_rodj_s = DateTime.Now;

        public MyICommand DeleteCommand { get; set; }
        public MyICommand AddCommand { get; set; }
        public MyICommand UpdateCommand { get; set; }
        private bool canEdit;

        public bool CanEdit
        {
            get
            {
                return canEdit;
            }
            set
            {
                if (canEdit != value)
                {
                    canEdit = value;
                    OnPropertyChanged("CanEdit");
                }
            }
        }
        public ServiserRacunaraViewModel()
        {
            DeleteCommand = new MyICommand(OnDelete, CanDelete);
            AddCommand = new MyICommand(OnAdd, CanAdd);
            UpdateCommand = new MyICommand(OnUpdate, CanUpdate);
        }

        public ObservableCollection<Serviser_racunara> Serviseri
        {
            get
            {
                return serviseri;
            }
            set
            {
                if (serviseri != value)
                {
                    serviseri = value;
                    OnPropertyChanged(nameof(Serviseri));
                }
            }
        }
        public Serviser_racunara SelectedServiser
        {
            get
            {
                return selectedServiser;
            }
            set
            {
                if (selectedServiser != value)
                {
                    selectedServiser = value;
                    OnPropertyChanged(nameof(SelectedServiser));
                    TxTBoxJMBGsServ = SelectedServiser == null ? "1234567891234" : SelectedServiser.JMBG_s.ToString();
                    TxTBoxIme_s = SelectedServiser == null ? "Ime..." : SelectedServiser.Ime_s;
                    TxtBoxPrezime_s = SelectedServiser == null ? "Prezime..." : SelectedServiser.Prezime_s;
                    DpDat_rodj_s = SelectedServiser == null ? DateTime.Now : SelectedServiser.Dat_rodjenja_s;
                

                    DeleteCommand.RaiseCanExecuteChanged();
                    UpdateCommand.RaiseCanExecuteChanged();
                }
            }
        }
        public Brush Foreground
        {
            get => foreground;
            set
            {
                if (foreground != value)
                {
                    foreground = value;
                    OnPropertyChanged("Foreground");
                }
            }
        }
        public string TxTBoxJMBGsServ
        {
            get => txTBoxJMBGsServ;
            set
            {
                if (txTBoxJMBGsServ != value)
                {
                    txTBoxJMBGsServ = value;
                    OnPropertyChanged("TxTBoxJMBGsServ");
                    AddCommand.RaiseCanExecuteChanged();
                    UpdateCommand.RaiseCanExecuteChanged();
                }
            }
        }
        public string TxTBoxIme_s
        {
            get => txTBoxIme_s;
            set
            {
                if (txTBoxIme_s != value)
                {
                    txTBoxIme_s = value;
                    OnPropertyChanged("TxTBoxIme_s");
                    AddCommand.RaiseCanExecuteChanged();
                    UpdateCommand.RaiseCanExecuteChanged();
                }
            }
        }
        public string TxtBoxPrezime_s
        {
            get => txtBoxPrezime_s;
            set
            {
                if (txtBoxPrezime_s != value)
                {
                    txtBoxPrezime_s = value;
                    OnPropertyChanged("TxtBoxPrezime_s");
                    AddCommand.RaiseCanExecuteChanged();
                    UpdateCommand.RaiseCanExecuteChanged();
                }
            }
        }
        public DateTime DpDat_rodj_s
        {
            get => dpDat_rodj_s;
            set
            {
                if (dpDat_rodj_s != value)
                {
                    dpDat_rodj_s = value;
                    OnPropertyChanged("DpDat_rodj_s");
                    AddCommand.RaiseCanExecuteChanged();
                    UpdateCommand.RaiseCanExecuteChanged();
                }
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
            CanEdit = SelectedServiser != null;
            return SelectedServiser != null;
        }

        private void OnDelete()
        {
            long idServisera = SelectedServiser.JMBG_s;
            if (DatabaseServiceProvider.Instance.DeleteServiserRacunara(idServisera))
            {
                LBL = "Servis (JMBG: " + idServisera + ") obrisan";
                Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF3AFF00"));
            }
            else
            {
                LBL = "Greska pri brisanju servisera - JMBG: " + idServisera;
                Foreground = Brushes.Red;
            }
            Serviseri = new ObservableCollection<Serviser_racunara>(DatabaseServiceProvider.Instance.GetAllServiseriRacunara());
        }

        private bool CanAdd()
        {
            return !String.IsNullOrEmpty(TxTBoxJMBGsServ) &&
                   !String.IsNullOrEmpty(TxTBoxIme_s) &&
                   !String.IsNullOrEmpty(TxtBoxPrezime_s) &&
                   !String.IsNullOrEmpty(DpDat_rodj_s.ToString()) &&
                    SelectedServiser == null;
        }

        private bool CanUpdate()
        {
            return !String.IsNullOrEmpty(TxTBoxJMBGsServ) &&
                   !String.IsNullOrEmpty(TxTBoxIme_s) &&
                   !String.IsNullOrEmpty(TxtBoxPrezime_s) &&
                   !String.IsNullOrEmpty(DpDat_rodj_s.ToString());
        }

        private void OnAdd()
        {
            if (DatabaseServiceProvider.Instance.AddServiserRacunara(new Serviser_racunara()
            {
                JMBG_s = long.Parse(TxTBoxJMBGsServ, CultureInfo.CurrentCulture),
                Dat_rodjenja_s = DpDat_rodj_s,
                Ime_s = TxTBoxIme_s,
                Prezime_s = TxtBoxPrezime_s
            }))
            {
                LBL = "Novi serviser uspjesno dodat \nu bazu!";
                Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF3AFF00"));
                Serviseri = new ObservableCollection<Serviser_racunara>(DatabaseServiceProvider.Instance.GetAllServiseriRacunara());

            }
            else
            {
                LBL = "Greska pri dodavanju servisera!";
                Foreground = Brushes.Red;
            }
        }
        private void OnUpdate()
        {
            try
            {
                DatabaseServiceProvider.Instance.UpdateServiserRacunara(new Serviser_racunara()
                {
                    JMBG_s = long.Parse(TxTBoxJMBGsServ, CultureInfo.CurrentCulture),
                    Dat_rodjenja_s = DateTime.Parse(DpDat_rodj_s.ToString()),
                    Ime_s = TxTBoxIme_s,
                    Prezime_s = TxtBoxPrezime_s
                });

                LBL = "Serviser [" + SelectedServiser.JMBG_s + "] uspjesno azuriran!";
                Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF3AFF00"));
                Serviseri = new ObservableCollection<Serviser_racunara>(DatabaseServiceProvider.Instance.GetAllServiseriRacunara());

            }
            catch (Exception e)
            {
                LBL = "Greska pri azuriranju servisera!";
                Foreground = Brushes.Red;
            }
        }

    }
}
