using Common.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ClientUI.ViewModel
{
    public class VlasnikRacunaraViewModel : BindableBase
    {
        private ObservableCollection<Vlasnik_racunara> vlasnici = new ObservableCollection<Vlasnik_racunara>(DatabaseServiceProvider.Instance.GetAllVlasniciRacunara());
        private Vlasnik_racunara selectedVlasnik;
        private Brush foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF3AFF00"));
        private string txTBoxJMBG_Vl;
        private string txTBoxIme_vl;
        private string txtBoxPrezime_vl;
        private string txtBoxAdresaVl_Ulica;
        private string txtBoxAdresaVl_Broj;
        private string txtBoxAdresaVl_Grad;
        private string txtBoxAdresaVl_PTTBroj;

        private string lbl = string.Empty;
        private DateTime dpDat_rodj_vl = DateTime.Now;
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
        public MyICommand DeleteCommand { get; set; }
        public MyICommand AddCommand { get; set; }
        public MyICommand UpdateCommand { get; set; }

        public VlasnikRacunaraViewModel()
        {
            DeleteCommand = new MyICommand(OnDelete, CanDelete);
            AddCommand = new MyICommand(OnAdd, CanAdd);
            UpdateCommand = new MyICommand(OnUpdate, CanUpdate);
        }

        public ObservableCollection<Vlasnik_racunara> Vlasnici
        {
            get
            {
                return vlasnici;
            }
            set
            {
                if (vlasnici != value)
                {
                    vlasnici = value;
                    OnPropertyChanged(nameof(Vlasnici));
                }
            }
        }
        public Vlasnik_racunara SelectedVlasnik
        {
            get
            {
                return selectedVlasnik;
            }
            set
            {
                if (selectedVlasnik != value)
                {
                    selectedVlasnik = value;
                    OnPropertyChanged(nameof(SelectedVlasnik));
                    TxTBoxJMBG_Vl = SelectedVlasnik == null ? "1234567891234" : SelectedVlasnik.JMBG_vl.ToString();
                    TxTBoxIme_vl = SelectedVlasnik == null ? "Ime..." : SelectedVlasnik.Ime_vl;
                    TxtBoxPrezime_vl = SelectedVlasnik == null ? "Prezime..." : SelectedVlasnik.Prezime_vl;
                    TxtBoxAdresaVl_Ulica = SelectedVlasnik == null ? "Ulica..." : SelectedVlasnik.Adresa_vl.Ulica;
                    TxtBoxAdresaVl_Grad = SelectedVlasnik == null ? "Grad..." : SelectedVlasnik.Adresa_vl.Grad;
                    TxtBoxAdresaVl_Broj = SelectedVlasnik == null ? "123" : SelectedVlasnik.Adresa_vl.Broj.ToString();
                    TxtBoxAdresaVl_PTTBroj = SelectedVlasnik == null ? "123" : SelectedVlasnik.Adresa_vl.PostanskiBroj.ToString();
                    DpDat_rodj_vl = SelectedVlasnik == null ? DateTime.Now : SelectedVlasnik.Dat_rodjenja_vl;


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
        public string TxTBoxJMBG_Vl
        {
            get => txTBoxJMBG_Vl;
            set
            {
                if (txTBoxJMBG_Vl != value)
                {
                    txTBoxJMBG_Vl = value;
                    OnPropertyChanged("TxTBoxJMBG_Vl");
                    AddCommand.RaiseCanExecuteChanged();
                    UpdateCommand.RaiseCanExecuteChanged();
                }
            }
        }
        public string TxTBoxIme_vl
        {
            get => txTBoxIme_vl;
            set
            {
                if (txTBoxIme_vl != value)
                {
                    txTBoxIme_vl = value;
                    OnPropertyChanged("TxTBoxIme_vl");
                    AddCommand.RaiseCanExecuteChanged();
                    UpdateCommand.RaiseCanExecuteChanged();
                }
            }
        }
        public string TxtBoxPrezime_vl
        {
            get => txtBoxPrezime_vl;
            set
            {
                if (txtBoxPrezime_vl != value)
                {
                    txtBoxPrezime_vl = value;
                    OnPropertyChanged("TxtBoxPrezime_vl");
                    AddCommand.RaiseCanExecuteChanged();
                    UpdateCommand.RaiseCanExecuteChanged();
                }
            }
        }
        public DateTime DpDat_rodj_vl
        {
            get => dpDat_rodj_vl;
            set
            {
                if (dpDat_rodj_vl != value)
                {
                    dpDat_rodj_vl = value;
                    OnPropertyChanged("DpDat_rodj_vl");
                    AddCommand.RaiseCanExecuteChanged();
                    UpdateCommand.RaiseCanExecuteChanged();
                }
            }
        }
        public string TxtBoxAdresaVl_Ulica
        {
            get => txtBoxAdresaVl_Ulica;
            set
            {
                txtBoxAdresaVl_Ulica = value;
                OnPropertyChanged("TxtBoxAdresaVl_Ulica");
                AddCommand.RaiseCanExecuteChanged();
                UpdateCommand.RaiseCanExecuteChanged();
            }
        }
        public string TxtBoxAdresaVl_Broj
        {
            get => txtBoxAdresaVl_Broj;
            set
            {
                txtBoxAdresaVl_Broj = value;
                OnPropertyChanged("TxtBoxAdresaVl_Broj");
                AddCommand.RaiseCanExecuteChanged();
                UpdateCommand.RaiseCanExecuteChanged();
            }
        }
        public string TxtBoxAdresaVl_Grad
        {
            get => txtBoxAdresaVl_Grad;
            set
            {
                txtBoxAdresaVl_Grad = value;
                OnPropertyChanged("TxtBoxAdresaVl_Grad");
                AddCommand.RaiseCanExecuteChanged();
                UpdateCommand.RaiseCanExecuteChanged();
            }
        }
        public string TxtBoxAdresaVl_PTTBroj
        {
            get => txtBoxAdresaVl_PTTBroj;
            set
            {
                txtBoxAdresaVl_PTTBroj = value;
                OnPropertyChanged("TxtBoxAdresaVl_PTTBroj");
                AddCommand.RaiseCanExecuteChanged();
                UpdateCommand.RaiseCanExecuteChanged();
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
            CanEdit = SelectedVlasnik != null;
            return SelectedVlasnik != null;
        }

        private void OnDelete()
        {
            long idVlasnika = SelectedVlasnik.JMBG_vl;
            if (DatabaseServiceProvider.Instance.DeleteVlasnikRacunara(idVlasnika))
            {
                LBL = "Vlasnik (JMBG: " + idVlasnika + ") obrisan";
                Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF3AFF00"));
            }
            else
            {
                LBL = "Greska pri brisanju vlasnika - JMBG: " + idVlasnika;
                Foreground = Brushes.Red;
            }
            Vlasnici = new ObservableCollection<Vlasnik_racunara>(DatabaseServiceProvider.Instance.GetAllVlasniciRacunara());
        }

        private bool CanAdd()
        {
            return !String.IsNullOrEmpty(TxTBoxJMBG_Vl) &&
                   !String.IsNullOrEmpty(TxTBoxIme_vl) &&
                   !String.IsNullOrEmpty(TxtBoxPrezime_vl) &&
                   !String.IsNullOrEmpty(DpDat_rodj_vl.ToString()) &&
                   !String.IsNullOrEmpty(TxtBoxAdresaVl_Ulica) &&
                   !String.IsNullOrEmpty(TxtBoxAdresaVl_Grad) &&
                   !String.IsNullOrEmpty(TxtBoxAdresaVl_Broj) &&
                   !String.IsNullOrEmpty(TxtBoxAdresaVl_PTTBroj) &&
                    SelectedVlasnik == null;
        }

        private bool CanUpdate()
        {
            return !String.IsNullOrEmpty(TxTBoxJMBG_Vl) &&
                   !String.IsNullOrEmpty(TxTBoxIme_vl) &&
                   !String.IsNullOrEmpty(TxtBoxPrezime_vl) &&
                   !String.IsNullOrEmpty(DpDat_rodj_vl.ToString()) &&
                   !String.IsNullOrEmpty(TxtBoxAdresaVl_Ulica) &&
                   !String.IsNullOrEmpty(TxtBoxAdresaVl_Grad) &&
                   !String.IsNullOrEmpty(TxtBoxAdresaVl_Broj) &&
                   !String.IsNullOrEmpty(TxtBoxAdresaVl_PTTBroj);
        }

        private void OnAdd()
        {
            if (!TxTBoxJMBG_Vl.All(c => char.IsDigit(c)) || TxTBoxJMBG_Vl.Length != 13)
            {
                LBL = "Greska pri dodavanju vlasnika!\nJMBG vlasnika mora biti pozitivan \ncio brojkoji se sastoji od \n13 cifara!";
                Foreground = Brushes.Red;
                return;
            }
            else if (!TxTBoxIme_vl.All(x => char.IsLetter(x)))
            {
                LBL = "Greska pri dodavanju vlasnika!\nIme vlasnika treba da sadrzi samo slova!";
                Foreground = Brushes.Red;
                return;
            }
            else if (!TxtBoxPrezime_vl.All(x => char.IsLetter(x)))
            {
                LBL = "Greska pri dodavanju vlasnika!\nPrezime vlasnika treba da sadrzi samo slova!";
                Foreground = Brushes.Red;
                return;
            }
            else if (DpDat_rodj_vl.Date >= DateTime.Now.Date)
            {
                LBL = "Greska pri dodavanju vlasnika!\nDatum rodjenja vlasnika treba da \nbude u proslosti!";
                Foreground = Brushes.Red;
                return;
            }
            else if(!Regex.IsMatch(TxtBoxAdresaVl_Ulica, @"^[\w \s]+$"))
            {
                LBL = "Greska pri dodavanju vlasnika!\nUlica u adresi vlasnika treba \nda sadrzi samo slova!";
                Foreground = Brushes.Red;
                return;
            }
            else if (!Regex.IsMatch(TxtBoxAdresaVl_Grad, @"^[\w \s]+$"))
            {
                LBL = "Greska pri dodavanju vlasnika!\nGrad u adresi vlasnika treba \nda sadrzi samo slova!";
                Foreground = Brushes.Red;
                return;
            }
            else if (!Regex.IsMatch(TxtBoxAdresaVl_Broj, @"^[\w \s]+$"))
            {
                LBL = "Greska pri dodavanju vlasnika!\nBroj u adresi vlasnika mora \nbiti pozitivan cio broj!";
                Foreground = Brushes.Red;
                return;
            }
            else if (!TxtBoxAdresaVl_PTTBroj.All(c => char.IsDigit(c)))
            {
                LBL = "Greska pri dodavanju vlasnika!\nPTT broj u adresi vlasnika mora biti \npozitivan cio broj!";
                Foreground = Brushes.Red;
                return;
            }
            else
            {
                if (long.Parse(TxTBoxJMBG_Vl, CultureInfo.CurrentCulture) <= 0)
                {
                    LBL = "Greska pri dodavanju vlasnika!\nJMBG vlasnika mora biti pozitivan \ncio brojkoji se sastoji od 13 \ncifara!";
                    Foreground = Brushes.Red;
                    return;
                }
                if (int.Parse(TxtBoxAdresaVl_Broj, CultureInfo.CurrentCulture) <= 0)
                {
                    LBL = "Greska pri dodavanju vlasnika!\nBroj u adresi vlasnika mora biti \npozitivan cio broj!";
                    Foreground = Brushes.Red;
                    return;
                }
                if (int.Parse(TxtBoxAdresaVl_PTTBroj, CultureInfo.CurrentCulture) <= 0)
                {
                    LBL = "Greska pri dodavanju vlasnika!\nPTT broj u adresi vlasnika mora \nbiti pozitivan cio broj!";
                    Foreground = Brushes.Red;
                    return;
                }

                if (DatabaseServiceProvider.Instance.AddVlasnikRacunara(new Vlasnik_racunara()
                {
                    JMBG_vl = long.Parse(TxTBoxJMBG_Vl, CultureInfo.InvariantCulture),
                    Dat_rodjenja_vl = DpDat_rodj_vl,
                    Ime_vl = TxTBoxIme_vl,
                    Prezime_vl = TxtBoxPrezime_vl,
                    Adresa_vl = new Adresa()
                    {
                        Ulica = TxtBoxAdresaVl_Ulica,
                        Broj = Int32.Parse(TxtBoxAdresaVl_Broj, CultureInfo.InvariantCulture),
                        PostanskiBroj = Int32.Parse(TxtBoxAdresaVl_PTTBroj, CultureInfo.InvariantCulture),
                        Grad = TxtBoxAdresaVl_Grad
                    }
                }))
                {
                    LBL = "Novi vlasnik uspjesno dodat \nu bazu!";
                    Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF3AFF00"));
                    Vlasnici = new ObservableCollection<Vlasnik_racunara>(DatabaseServiceProvider.Instance.GetAllVlasniciRacunara());

                }
                else
                {
                    LBL = "Greska pri dodavanju vlasnika!";
                    Foreground = Brushes.Red;
                }
            }
        }
        private void OnUpdate()
        {
            try
            {
                if (!TxTBoxJMBG_Vl.All(c => char.IsDigit(c)) || TxTBoxJMBG_Vl.Length != 13)
                {
                    LBL = "Greska pri dodavanju vlasnika!\nJMBG vlasnika mora biti pozitivan cio \nbrojkoji se sastoji od 13 \ncifara!";
                    Foreground = Brushes.Red;
                    return;
                }
                else if (!TxTBoxIme_vl.All(x => char.IsLetter(x)))
                {
                    LBL = "Greska pri dodavanju vlasnika!\nIme vlasnika treba da sadrzi samo slova!";
                    Foreground = Brushes.Red;
                    return;
                }
                else if (!TxtBoxPrezime_vl.All(x => char.IsLetter(x)))
                {
                    LBL = "Greska pri dodavanju vlasnika!\nPrezime vlasnika treba da sadrzi samo slova!";
                    Foreground = Brushes.Red;
                    return;
                }
                else if (DpDat_rodj_vl.Date >= DateTime.Now.Date)
                {
                    LBL = "Greska pri dodavanju vlasnika!\nDatum rodjenja vlasnika treba da \nbude u proslosti!";
                    Foreground = Brushes.Red;
                    return;
                }
                else if (!Regex.IsMatch(TxtBoxAdresaVl_Ulica, @"^[\w \s]+$"))
                {
                    LBL = "Greska pri dodavanju vlasnika!\nUlica u adresi vlasnika treba \nda sadrzi samo slova!";
                    Foreground = Brushes.Red;
                    return;
                }
                else if (!Regex.IsMatch(TxtBoxAdresaVl_Grad, @"^[\w \s]+$"))
                {
                    LBL = "Greska pri dodavanju vlasnika!\nGrad u adresi vlasnika treba \nda sadrzi samo slova!";
                    Foreground = Brushes.Red;
                    return;
                }
                else if (!Regex.IsMatch(TxtBoxAdresaVl_Broj, @"^[\w \s]+$"))
                {
                    LBL = "Greska pri dodavanju vlasnika!\nBroj u adresi vlasnika mora \nbiti pozitivan cio broj!";
                    Foreground = Brushes.Red;
                    return;
                }
                else if (!TxtBoxAdresaVl_PTTBroj.All(c => char.IsDigit(c)))
                {
                    LBL = "Greska pri dodavanju vlasnika!\nPTT broj u adresi vlasnika mora biti \npozitivan cio broj!";
                    Foreground = Brushes.Red;
                    return;
                }
                else
                {
                    if (long.Parse(TxTBoxJMBG_Vl, CultureInfo.CurrentCulture) <= 0)
                    {
                        LBL = "Greska pri dodavanju vlasnika!\nJMBG vlasnika mora biti pozitivan cio \nbroj\nkoji se sastoji od 13 cifara!";
                        Foreground = Brushes.Red;
                        return;
                    }
                    if (int.Parse(TxtBoxAdresaVl_Broj, CultureInfo.CurrentCulture) <= 0)
                    {
                        LBL = "Greska pri dodavanju vlasnika!\nBroj u adresi vlasnika mora biti \npozitivan cio broj!";
                        Foreground = Brushes.Red;
                        return;
                    }
                    if (int.Parse(TxtBoxAdresaVl_PTTBroj, CultureInfo.CurrentCulture) <= 0)
                    {
                        LBL = "Greska pri dodavanju vlasnika!\nPTT broj u adresi vlasnika mora biti \npozitivan cio broj!";
                        Foreground = Brushes.Red;
                        return;
                    }
                    DatabaseServiceProvider.Instance.UpdateVlasnikRacunara(new Vlasnik_racunara()
                    {
                        JMBG_vl = long.Parse(TxTBoxJMBG_Vl, CultureInfo.InvariantCulture),
                        Dat_rodjenja_vl = DpDat_rodj_vl,
                        Ime_vl = TxTBoxIme_vl,
                        Prezime_vl = TxtBoxPrezime_vl,
                        Adresa_vl = new Adresa()
                        {
                            Ulica = TxtBoxAdresaVl_Ulica,
                            Broj = Int32.Parse(TxtBoxAdresaVl_Broj, CultureInfo.InvariantCulture),
                            PostanskiBroj = Int32.Parse(TxtBoxAdresaVl_PTTBroj, CultureInfo.InvariantCulture),
                            Grad = TxtBoxAdresaVl_Grad
                        }
                    });

                    LBL = "Vlasnik [" + SelectedVlasnik.JMBG_vl + "] uspjesno azuriran!";
                    Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF3AFF00"));
                    Vlasnici = new ObservableCollection<Vlasnik_racunara>(DatabaseServiceProvider.Instance.GetAllVlasniciRacunara());

                }
            }
            catch (Exception e)
            {
                LBL = "Greska pri azuriranju vlasnika!";
                Foreground = Brushes.Red;
            }
        }
    }
}
