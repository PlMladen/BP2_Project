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
                case "Racunari view":
                    CurrentViewModel = servisViewModel;
                    break;
                case "VLRacunara view":
                    CurrentViewModel = servisViewModel;
                    break;
                case "SerRacunara view":
                    CurrentViewModel = servisViewModel;
                    break;
                case "Komponente view":
                    CurrentViewModel = servisViewModel;
                    break;
                case "Gar list view":
                    CurrentViewModel = servisViewModel;
                    break;*/
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
