using ClientUI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientUI.ViewModel
{
    public class MainWindowViewModel : BindableBase
    {
        public MyICommand<string> NavCommand { get; private set; }
        private ServisViewModel servisViewModel = new ServisViewModel(MainWindow.Uloga);
        private ServiserRacunaraViewModel serviserRacunaraViewModel = new ServiserRacunaraViewModel();
        private RacunarViewModel racunarViewModel = new RacunarViewModel(MainWindow.Uloga);
        private VlasnikRacunaraViewModel vlasnikRacunaraViewModel = new VlasnikRacunaraViewModel();
        private KomponentaViewModel komponentaViewModel = new KomponentaViewModel(MainWindow.Uloga, MainWindow.IdVlasnika);
        private GarantniListViewModel garantniListViewModel = new GarantniListViewModel();
        private PosjedujeViewModel posjedujeViewModel = new PosjedujeViewModel();
        private SastojiSeViewModel sastojiSeViewModel = new SastojiSeViewModel();
        private RadiViewModel radiViewModel = new RadiViewModel(MainWindow.Uloga);
        private DonosiViewModel donosiViewModel = new DonosiViewModel(MainWindow.Uloga, MainWindow.IdVlasnika);
        private ServisiraViewModel servisiraViewModel = new ServisiraViewModel(MainWindow.Uloga);
        private FuncProcViewModel funcProcViewModel = new FuncProcViewModel();
        private string ulogaKorisnika = string.Empty;
        private string autorizacija = string.Empty;
        private string autorizacijaSA = string.Empty;
        private string meniStavkaPosjeduje = string.Empty;
        private string meniStavkaDonosi = string.Empty;

        private BindableBase currentViewModel;

        public MainWindowViewModel()
        {
            UlogaKorisnika = MainWindow.Uloga;
            NavCommand = new MyICommand<string>(OnNav);
            currentViewModel = servisViewModel;
        }

        public MyICommand ServisCommand { get; set; }

        private void OnNav(string destination)
        {
            switch (destination)
            {
                case "Servis view":
                    CurrentViewModel = servisViewModel;
                    break;
                /*case "RServis view":
                    CurrentViewModel = servisViewModel;
                    break;
                case "MServis view":
                    CurrentViewModel = servisViewModel;
                    break;
                */case "Racunari view":
                    CurrentViewModel = racunarViewModel;
                    break;
                 case "VLRacunara view":
                    CurrentViewModel = vlasnikRacunaraViewModel;
                    break;
                case "SerRacunara view":
                    CurrentViewModel = serviserRacunaraViewModel;
                    break;
                case "Komponente view":
                    CurrentViewModel = komponentaViewModel;
                    break;
                case "Gar list view":
                    CurrentViewModel = garantniListViewModel;
                    break;
                case "Posjeduje view":
                    CurrentViewModel = posjedujeViewModel;
                    break;
                case "SastojiSe view":
                    CurrentViewModel = sastojiSeViewModel;
                    break;
                case "Radi view":
                    CurrentViewModel = radiViewModel;
                    break;
                case "Donosi view":
                    CurrentViewModel = donosiViewModel;
                    break;
                case "Servisira view":
                    CurrentViewModel = servisiraViewModel;
                    break;
                case "FuncProc view":
                    CurrentViewModel = funcProcViewModel;
                    break;
            }
        }

        public string UlogaKorisnika
        {
            get => ulogaKorisnika;
            set
            {
                ulogaKorisnika = value;
                Autorizacija = ulogaKorisnika.Equals("Administrator") ? "Visible" : "Collapsed";
                AutorizacijaSA = ulogaKorisnika.Equals("Administrator") || ulogaKorisnika.Equals("Serviser_racunara") ? "Visible" : "Collapsed";
                MeniStavkaPosjeduje = ulogaKorisnika.Equals("Administrator") || ulogaKorisnika.Equals("Serviser_racunara") ? "Računari korisnika" : "Moji računari";
                MeniStavkaDonosi = ulogaKorisnika.Equals("Administrator") || ulogaKorisnika.Equals("Serviser_racunara") ? "Istorija posjeta servisima" : "Mojе posjete servisima";
             
                OnPropertyChanged("UlogaKorisnika");
                OnPropertyChanged("Autorizacija");
                OnPropertyChanged("AutorizacijaSA");
                OnPropertyChanged("MeniStavkaPosjeduje");
                OnPropertyChanged("MeniStavkaDonosi");
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
        public string MeniStavkaPosjeduje
        {
            get => meniStavkaPosjeduje;
            set
            {
                meniStavkaPosjeduje = value;
                OnPropertyChanged("MeniStavkaPosjeduje");
            }
        }
        public string MeniStavkaDonosi
        {
            get => meniStavkaDonosi;
            set
            {
                meniStavkaDonosi = value;
                OnPropertyChanged("MeniStavkaDonosi");
            }
        }
        public string AutorizacijaSA
        {
            get => autorizacijaSA;
            set
            {
                autorizacijaSA = value;
                OnPropertyChanged("AutorizacijaSA");
            }
        }

        public BindableBase CurrentViewModel
        {
            get { return currentViewModel; }
            set
            {
                SetProperty(ref currentViewModel, value);
            }
        }
    }
}
