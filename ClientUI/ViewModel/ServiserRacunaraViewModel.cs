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
        private string dugmeContent = string.Empty;
        private Brush okvirBoja = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF3AFF00"));
        private DateTime dpDat_rodj_s = DateTime.Now;

        public MyICommand DeleteCommand { get; set; }
        public MyICommand AddCommand { get; set; }
        public MyICommand OdobriCommand { get; set; }
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
            OdobriCommand = new MyICommand(OnOdobri, CanOdobri);
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
                    TxTBoxIme_s = SelectedServiser == null ? "" : SelectedServiser.Ime_s;
                    TxtBoxPrezime_s = SelectedServiser == null ? "" : SelectedServiser.Prezime_s;
                    DpDat_rodj_s = SelectedServiser == null ? DateTime.Now : SelectedServiser.Dat_rodjenja_s;

                    
                    
                    if (Int64.TryParse(TxTBoxJMBGsServ, out long jmbg)) {
                        if (DatabaseServiceProvider.Instance.VratiAktivnostProfilaKorisnikaJmbg(jmbg))
                        {
                            OkvirBoja = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF3AFF00")); 
                            DugmeContent = "Blokiraj logovanje";
                        }
                        else
                        {
                            OkvirBoja = Brushes.Red;
                            DugmeContent = "Odobri logovanje";
                        }
                    } 
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
        public Brush OkvirBoja
        {
            get => okvirBoja;
            set
            {
                if (okvirBoja != value)
                {
                    okvirBoja = value;
                    OnPropertyChanged("OkvirBoja");
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
        public string DugmeContent
        {
            get => dugmeContent;
            set
            {
                dugmeContent = value;
                OnPropertyChanged("DugmeContent");
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
        private void OnOdobri()
        {
            long idServisera = SelectedServiser.JMBG_s;
            bool naredba = false;
            if (DatabaseServiceProvider.Instance.VratiAktivnostProfilaKorisnikaJmbg(idServisera))
                naredba = false;
            else
                naredba = true;
            if (DatabaseServiceProvider.Instance.PromijeniAktivnostProfilaKorisnika(idServisera, naredba))
            {
                if (naredba)
                {
                    LBL = "Profil servisera (JMBG: " + idServisera + ") odobren";
                    Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF3AFF00"));
                    OkvirBoja = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF3AFF00")); 
                    DugmeContent = "Blokiraj logovanje";
                }
                else
                {
                    LBL = "Profil servisera (JMBG: " + idServisera + ") blokiran";
                    Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF3AFF00"));
                    OkvirBoja = Brushes.Red;
                    DugmeContent = "Odobri logovanje";
                }
            }
            else
            {
                if (naredba)
                {
                    LBL = "Greska pri odobravanju profila servisera - JMBG: " + idServisera;
                    Foreground = Brushes.Red;
                }
                else
                {

                    LBL = "Greska pri blokiranju profila servisera - JMBG: " + idServisera;
                    Foreground = Brushes.Red;
                }
            }
            //Serviseri = new ObservableCollection<Serviser_racunara>(DatabaseServiceProvider.Instance.GetAllServiseriRacunara());
        }

        private bool CanAdd()
        {
            return !String.IsNullOrEmpty(TxTBoxJMBGsServ) &&
                   !String.IsNullOrEmpty(TxTBoxIme_s) &&
                   !String.IsNullOrEmpty(TxtBoxPrezime_s) &&
                   !String.IsNullOrEmpty(DpDat_rodj_s.ToString()) &&
                    SelectedServiser == null;
        }
        
        private bool CanOdobri()
        {
            return true /*&&
                    SelectedServiser == null*/;
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
            if (!TxTBoxJMBGsServ.All(c => char.IsDigit(c)) || TxTBoxJMBGsServ.Length != 13)
            {
                LBL = "Greska pri dodavanju servisera!\n JMBG servisera mora biti pozitivan cio broj\nkoji se sastoji od 13 cifara!";
                Foreground = Brushes.Red;
                return;
            }
            else if(!TxTBoxIme_s.All(x => char.IsLetter(x)))
            {
                LBL = "Greska pri dodavanju servisera!\n Ime servisera treba da sadrzi samo slova!";
                Foreground = Brushes.Red;
                return;
            }
            else if (!TxtBoxPrezime_s.All(x => char.IsLetter(x)))
            {
                LBL = "Greska pri dodavanju servisera!\n Prezime servisera treba da sadrzi samo slova!";
                Foreground = Brushes.Red;
                return;
            }
            else if(DpDat_rodj_s.Date >= DateTime.Now.Date)
            {
                LBL = "Greska pri dodavanju servisera!\n Datum rodjenja servisera treba da \nbude u proslosti!";
                Foreground = Brushes.Red;
                return;
            }
            else 
            {
                if (long.Parse(TxTBoxJMBGsServ, CultureInfo.CurrentCulture) <= 0)
                {
                    LBL = "Greska pri dodavanju servisera!\n JMBG servisera mora biti pozitivan cio broj\nkoji se sastoji od 13 cifara!";
                    Foreground = Brushes.Red;
                    return;
                }
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
        }
        private void OnUpdate()
        {
            try
            {
                if (!TxTBoxJMBGsServ.All(c => char.IsDigit(c)) || TxTBoxJMBGsServ.Length != 13)
                {
                    LBL = "Greska pri dodavanju servisera!\n JMBG servisera mora biti pozitivan cio broj\nkoji se sastoji od 13 cifara!";
                    Foreground = Brushes.Red;
                    return;
                }
                else if (!TxTBoxIme_s.All(x => char.IsLetter(x)))
                {
                    LBL = "Greska pri dodavanju servisera!\n Ime servisera treba da sadrzi samo slova!";
                    Foreground = Brushes.Red;
                    return;
                }
                else if (!TxtBoxPrezime_s.All(x => char.IsLetter(x)))
                {
                    LBL = "Greska pri dodavanju servisera!\n Prezime servisera treba da sadrzi samo slova!";
                    Foreground = Brushes.Red;
                    return;
                }
                else if (DpDat_rodj_s.Date >= DateTime.Now.Date)
                {
                    LBL = "Greska pri dodavanju servisera!\n Datum rodjenja servisera treba da \nbude u proslosti!";
                    Foreground = Brushes.Red;
                    return;
                }
                else
                {
                    if (long.Parse(TxTBoxJMBGsServ, CultureInfo.CurrentCulture) <= 0)
                    {
                        LBL = "Greska pri dodavanju servisera!\n JMBG servisera mora biti pozitivan cio broj\nkoji se sastoji od 13 cifara!";
                        Foreground = Brushes.Red;
                        return;
                    }
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
            }
            catch (Exception e)
            {
                LBL = "Greska pri azuriranju servisera!";
                Foreground = Brushes.Red;
            }
        }

    }
}
