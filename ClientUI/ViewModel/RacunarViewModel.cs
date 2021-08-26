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
    public class RacunarViewModel : BindableBase
    {
        private ObservableCollection<Racunar> racunari = 
            !MainWindow.Uloga.Equals("Vlasnik_racunara") ? new ObservableCollection<Racunar>(DatabaseServiceProvider.Instance.GetAllRacunari()) :
            new ObservableCollection<Racunar>(DatabaseServiceProvider.Instance.GetAllMojiRacunari(MainWindow.IdVlasnika));
        public static List<string> RacunarTypes { get; set; } = new List<string> { Vrsta_racunara.Desktop.ToString(), Vrsta_racunara.Laptop.ToString(), Vrsta_racunara.Tablet.ToString() };
        private Racunar selectedRacunar;
        private Brush foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF3AFF00"));
        private string txTBoxID_Racunara;
        private string txTBoxProizvodjac;
        private string txtBoxRAM;
        private string txtBoxMemorija;
        private string txtBoxBrzinaCPU;
        private string cmbBoxVrsta_racunara;
        private string lbl = string.Empty;
        private string ulogaKorisnika = string.Empty;
        private string autorizacija = string.Empty;
        private int autorizacijaRaspored = 2;

        public MyICommand DeleteCommand { get; set; }
        public MyICommand AddCommand { get; set; }
        public MyICommand UpdateCommand { get; set; }

        public RacunarViewModel(string uloga)
        {
            UlogaKorisnika = uloga;
            DeleteCommand = new MyICommand(OnDelete, CanDelete);
            AddCommand = new MyICommand(OnAdd, CanAdd);
            UpdateCommand = new MyICommand(OnUpdate, CanUpdate);
        }

        public ObservableCollection<Racunar> Racunari
        {
            get
            {
                return racunari;
            }
            set
            {
                if (racunari != value)
                {
                    racunari = value;
                    OnPropertyChanged(nameof(Racunari));
                }
            }
        }
        public Racunar SelectedRacunar
        {
            get
            {
                return selectedRacunar;
            }
            set
            {
                if (selectedRacunar != value)
                {
                    selectedRacunar = value;
                    OnPropertyChanged(nameof(SelectedRacunar));
                    //TxTBoxID_Racunara = SelectedRacunar == null ? "1234567891234" : SelectedRacunar.ID_racunara.ToString();
                    TxtBoxBrzinaCPU = SelectedRacunar == null ? "" : SelectedRacunar.Brzina_procesora.ToString();
                    TxtBoxRAM = SelectedRacunar == null ? "" : SelectedRacunar.Kapacitet_RAM.ToString();
                    TxtBoxMemorija = SelectedRacunar == null ? "" : SelectedRacunar.Kapacitet_memorije.ToString();
                    CmbBoxVrsta_racunara = SelectedRacunar == null ? "" : SelectedRacunar.Vrsta_racunara.ToString();
                    TxTBoxProizvodjac = SelectedRacunar == null ? "" : SelectedRacunar.Proizvodjac;
                    DeleteCommand.RaiseCanExecuteChanged();
                    UpdateCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public string UlogaKorisnika
        {
            get => ulogaKorisnika;
            set
            {
                ulogaKorisnika = value;
                Autorizacija = ulogaKorisnika.Equals("Administrator") ? "Visible" : "Hidden";
                AutorizacijaRaspored = ulogaKorisnika.Equals("Administrator") ? 2 : 1;
                OnPropertyChanged("UlogaKorisnika");
                OnPropertyChanged("Autorizacija");
                OnPropertyChanged("AutorizacijaRaspored");
            }
        }
        public string Autorizacija
        {
            get => autorizacija;
            set
            {
                autorizacija = value;
                OnPropertyChanged("Autorizacija");
            }
        }
        public int AutorizacijaRaspored
        {
            get => autorizacijaRaspored;
            set
            {
                autorizacijaRaspored = value;
                OnPropertyChanged("AutorizacijaRaspored");
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
        public string TxTBoxID_Racunara
        {
            get => txTBoxID_Racunara;
            set
            {
                if (txTBoxID_Racunara != value)
                {
                    txTBoxID_Racunara = value;
                    OnPropertyChanged("TxTBoxID_Racunara");
                    AddCommand.RaiseCanExecuteChanged();
                    UpdateCommand.RaiseCanExecuteChanged();
                }
            }
        }
        public string TxTBoxProizvodjac
        {
            get => txTBoxProizvodjac;
            set
            {
                if (txTBoxProizvodjac != value)
                {
                    txTBoxProizvodjac = value;
                    OnPropertyChanged("TxTBoxProizvodjac");
                    AddCommand.RaiseCanExecuteChanged();
                    UpdateCommand.RaiseCanExecuteChanged();
                }
            }
        }
        public string TxtBoxRAM
        {
            get => txtBoxRAM;
            set
            {
                if (txtBoxRAM != value)
                {
                    txtBoxRAM = value;
                    OnPropertyChanged("TxtBoxRAM");
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
        public string TxtBoxMemorija
        {
            get => txtBoxMemorija;
            set
            {
                txtBoxMemorija = value;
                OnPropertyChanged("TxtBoxMemorija");
                AddCommand.RaiseCanExecuteChanged();
                UpdateCommand.RaiseCanExecuteChanged();
            }
        }
        public string TxtBoxBrzinaCPU
        {
            get => txtBoxBrzinaCPU;
            set
            {
                txtBoxBrzinaCPU = value;
                OnPropertyChanged("TxtBoxBrzinaCPU");
                AddCommand.RaiseCanExecuteChanged();
                UpdateCommand.RaiseCanExecuteChanged();
            }
        }
        public string CmbBoxVrsta_racunara
        {
            get => cmbBoxVrsta_racunara;
            set
            {
                cmbBoxVrsta_racunara = value;
                OnPropertyChanged("CmbBoxVrsta_racunara");
                AddCommand.RaiseCanExecuteChanged();
                UpdateCommand.RaiseCanExecuteChanged();
            }
        }

        private bool CanDelete()
        {
            return SelectedRacunar != null;
        }

        private void OnDelete()
        {
            int idRacunara = SelectedRacunar.ID_racunara;
            if (DatabaseServiceProvider.Instance.DeleteRacunar(idRacunara))
            {
                LBL = "Racunar (ID: " + idRacunara + ") obrisan";
                Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF3AFF00"));
            }
            else
            {
                LBL = "Greska pri brisanju racunara - ID: " + idRacunara;
                Foreground = Brushes.Red;
            }
            Racunari = new ObservableCollection<Racunar>(DatabaseServiceProvider.Instance.GetAllRacunari());
        }

        private bool CanAdd()
        {
            return !String.IsNullOrEmpty(TxtBoxBrzinaCPU) &&
                   !String.IsNullOrEmpty(TxtBoxMemorija) &&
                   !String.IsNullOrEmpty(TxtBoxRAM) &&
                   //!String.IsNullOrEmpty(TxTBoxID_Racunara) &&
                   !String.IsNullOrEmpty(TxTBoxProizvodjac) &&
                   !String.IsNullOrEmpty(CmbBoxVrsta_racunara) &&
                    SelectedRacunar == null;
        }

        private bool CanUpdate()
        {
            return !String.IsNullOrEmpty(TxtBoxBrzinaCPU) &&
                   !String.IsNullOrEmpty(TxtBoxMemorija) &&
                   !String.IsNullOrEmpty(TxtBoxRAM) &&
                   //!String.IsNullOrEmpty(TxTBoxID_Racunara) &&
                   !String.IsNullOrEmpty(TxTBoxProizvodjac) &&
                   !String.IsNullOrEmpty(CmbBoxVrsta_racunara);
        }

        private void OnAdd()
        {
            try
            {
                var brzina = double.Parse(TxtBoxBrzinaCPU.Replace(',', '.'), CultureInfo.InvariantCulture);
                if (!TxtBoxMemorija.All(c => Char.IsDigit(c)))
                {
                    LBL = "Greska pri dodavanju racunara!\nKapacitet masovne memorije mora biti cio broj!";
                    Foreground = Brushes.Red;
                }
                else if (!TxtBoxRAM.All(c => Char.IsDigit(c)))
                {
                    LBL = "Greska pri dodavanju racunara!\nKapacitet radne memorije mora biti cio broj!";
                    Foreground = Brushes.Red;
                }
                else
                {
                    if (brzina <= 0)
                    {
                        LBL = "Greska pri dodavanju racunara!\nBrzina procesora mora biti pozitivan cio broj ili decimalni broj\n u formatu '0000.00'";
                        Foreground = Brushes.Red;
                        return;
                    }
                    if (int.Parse(TxtBoxMemorija) <= 0)
                    {
                        LBL = "Greska pri dodavanju racunara!\nKapacitet masovne memorije mora biti pozitivan cio broj!";
                        Foreground = Brushes.Red;
                        return;
                    }
                    if (int.Parse(TxtBoxRAM) <= 0)
                    {
                        LBL = "Greska pri dodavanju racunara!\nKapacitet radne memorije mora biti pozitivan cio broj!";
                        Foreground = Brushes.Red;
                        return;
                    }

                    if (DatabaseServiceProvider.Instance.AddRacunar(new Racunar()
                    {
                        Brzina_procesora = brzina,
                        Kapacitet_memorije = int.Parse(TxtBoxMemorija),
                        Kapacitet_RAM = int.Parse(TxtBoxRAM),
                        Proizvodjac = TxTBoxProizvodjac,
                        Vrsta_racunara = (Vrsta_racunara)Enum.Parse(typeof(Vrsta_racunara), CmbBoxVrsta_racunara)
                    }))
                    {
                        LBL = "Novi racunar uspjesno dodat \nu bazu!";
                        Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF3AFF00"));
                        Racunari = new ObservableCollection<Racunar>(DatabaseServiceProvider.Instance.GetAllRacunari());

                    }
                    else
                    {
                        LBL = "Greska pri dodavanju racunara!";
                        Foreground = Brushes.Red;
                    }
                }
            }catch(Exception e)
            {
                LBL = "Greska pri dodavanju racunara!\nBrzina procesora mora biti cio broj ili decimalni broj\n u formatu '0000.00'";
                Foreground = Brushes.Red;
            }
        }
        private void OnUpdate()
        {
            try
            {
                double brzina = 0;
                try
                {
                    brzina = double.Parse(TxtBoxBrzinaCPU.Replace(',', '.'), CultureInfo.InvariantCulture);

                }catch(Exception e)
                {
                    LBL = "Greska pri dodavanju racunara!\nBrzina procesora mora biti cio broj ili decimalni broj\n u formatu '0000.00'";
                    Foreground = Brushes.Red;
                    return;
                }
                if (!TxtBoxMemorija.All(c => Char.IsDigit(c)))
                {
                    LBL = "Greska pri dodavanju racunara!\nKapacitet masovne memorije mora biti pozitivan cio broj!";
                    Foreground = Brushes.Red;
                }
                else if (!TxtBoxRAM.All(c => Char.IsDigit(c)))
                {
                    LBL = "Greska pri dodavanju racunara!\nKapacitet radne memorije mora biti pozitivan cio broj!";
                    Foreground = Brushes.Red;
                }
                else
                {
                    if(brzina <= 0)
                    {
                        LBL = "Greska pri dodavanju racunara!\nBrzina procesora mora biti pozitivan cio broj ili decimalni broj\n u formatu '0000.00'";
                        Foreground = Brushes.Red;
                        return;
                    }
                    if(int.Parse(TxtBoxMemorija) <= 0)
                    {
                        LBL = "Greska pri dodavanju racunara!\nKapacitet masovne memorije mora biti pozitivan cio broj!";
                        Foreground = Brushes.Red;
                        return;
                    }
                    if(int.Parse(TxtBoxRAM) <= 0)
                    {
                        LBL = "Greska pri dodavanju racunara!\nKapacitet radne memorije mora biti pozitivan cio broj!";
                        Foreground = Brushes.Red;
                        return;
                    }

                    DatabaseServiceProvider.Instance.UpdateRacunar(new Racunar()
                    {
                        ID_racunara = SelectedRacunar.ID_racunara,
                        Brzina_procesora = brzina,
                        Kapacitet_memorije = int.Parse(TxtBoxMemorija),
                        Kapacitet_RAM = int.Parse(TxtBoxRAM),
                        Proizvodjac = TxTBoxProizvodjac,
                        Vrsta_racunara = (Vrsta_racunara)Enum.Parse(typeof(Vrsta_racunara), CmbBoxVrsta_racunara)
                    });

                    LBL = "Racunar [" + SelectedRacunar.ID_racunara + "] uspjesno azuriran!";
                    Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF3AFF00"));
                    Racunari = new ObservableCollection<Racunar>(DatabaseServiceProvider.Instance.GetAllRacunari());
                }
            }
            catch (Exception e)
            {
                LBL = "Greska pri dodavanju racunara!Racunar sa istim ID postoji vec!";
                Foreground = Brushes.Red;
            }
        }
    }
}
