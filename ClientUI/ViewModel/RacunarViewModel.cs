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
        private ObservableCollection<Racunar> racunari = new ObservableCollection<Racunar>(DatabaseServiceProvider.Instance.GetAllRacunari());
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

        public MyICommand DeleteCommand { get; set; }
        public MyICommand AddCommand { get; set; }
        public MyICommand UpdateCommand { get; set; }

        public RacunarViewModel()
        {
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
                    TxtBoxBrzinaCPU = SelectedRacunar == null ? "Brzina..." : SelectedRacunar.Brzina_procesora.ToString();
                    TxtBoxRAM = SelectedRacunar == null ? "RAM..." : SelectedRacunar.Kapacitet_RAM.ToString();
                    TxtBoxMemorija = SelectedRacunar == null ? "Memorija..." : SelectedRacunar.Kapacitet_memorije.ToString();
                    CmbBoxVrsta_racunara = SelectedRacunar == null ? "" : SelectedRacunar.Vrsta_racunara.ToString();
                    TxTBoxProizvodjac = SelectedRacunar == null ? "Proizvodjac..." : SelectedRacunar.Proizvodjac;
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
            if (DatabaseServiceProvider.Instance.AddRacunar(new Racunar()
            {
                Brzina_procesora = double.Parse(TxtBoxBrzinaCPU),
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
        private void OnUpdate()
        {
            try
            {
                DatabaseServiceProvider.Instance.UpdateRacunar(new Racunar()
                {
                    ID_racunara = SelectedRacunar.ID_racunara,
                    Brzina_procesora = double.Parse(TxtBoxBrzinaCPU, CultureInfo.InvariantCulture),
                    Kapacitet_memorije = int.Parse(TxtBoxMemorija),
                    Kapacitet_RAM = int.Parse(TxtBoxRAM),
                    Proizvodjac = TxTBoxProizvodjac,
                    Vrsta_racunara = (Vrsta_racunara)Enum.Parse(typeof(Vrsta_racunara), CmbBoxVrsta_racunara)
                });

                LBL = "Racunar [" + SelectedRacunar.ID_racunara + "] uspjesno azuriran!";
                Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF3AFF00"));
                Racunari = new ObservableCollection<Racunar>(DatabaseServiceProvider.Instance.GetAllRacunari());

            }
            catch (Exception e)
            {
                LBL = "Greska pri azuriranju racunara!";
                Foreground = Brushes.Red;
            }
        }
    }
}
