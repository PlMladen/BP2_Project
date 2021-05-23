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
        private ServisViewModel servisViewModel = new ServisViewModel();
        private ServiserRacunaraViewModel serviserRacunaraViewModel = new ServiserRacunaraViewModel();
        private RacunarViewModel racunarViewModel = new RacunarViewModel();
        private VlasnikRacunaraViewModel vlasnikRacunaraViewModel = new VlasnikRacunaraViewModel();
        private KomponentaViewModel komponentaViewModel = new KomponentaViewModel();
        private GarantniListViewModel garantniListViewModel = new GarantniListViewModel();

        private BindableBase currentViewModel;

        public MainWindowViewModel()
        {
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
