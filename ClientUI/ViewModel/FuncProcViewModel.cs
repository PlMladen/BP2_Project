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
    public class FuncProcViewModel : BindableBase
    {
        private ObservableCollection<string> vlasnici = new ObservableCollection<string>(DatabaseServiceProvider.Instance.GetAllVlasniciRacunara().Select(x => String.Format(x.JMBG_vl.ToString() +"\n" +x.Ime_vl +" "+ x.Prezime_vl )));
        private ObservableCollection<string> servisi = new ObservableCollection<string>(DatabaseServiceProvider.Instance.GetAllServiss().Select(x => String.Format(x.Naziv_serv)));
        public static List<string> VrsteRacunara { get; set; } = new List<string> { Vrsta_racunara.Desktop.ToString(), Vrsta_racunara.Laptop.ToString(), Vrsta_racunara.Tablet.ToString() };
        
        private Brush foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF3AFF00"));
        private string cmbBoxVlasnici;
        private string cmbBoxServisi;
        private string cmbBoxVrsteRacunara;
        private string brojRacunara;
        private string najskPop;
        private string najstarijiRadnik;
        private string brPunVl;

        
        public MyICommand RetNumPCCommand { get; set; }
        public MyICommand RetMaxPriceCommand { get; set; }
        public MyICommand ReturnTheOldestWorkerCommand { get; set; }
        public MyICommand RetAdultsCommand { get; set; }
        

        public FuncProcViewModel()
        {
            RetNumPCCommand = new MyICommand(OnRetNumPCCommand, CanRetNumPCCommand);
            RetMaxPriceCommand = new MyICommand(OnRetMaxPriceCommand);
            RetAdultsCommand = new MyICommand(OnRetAdultsCommand);
            ReturnTheOldestWorkerCommand = new MyICommand(OnReturnTheOldestWorkerCommand, CanReturnTheOldestWorkerCommand);
        }

        public ObservableCollection<string> Vlasnici
        {
            get
            {
                return new ObservableCollection<string>(DatabaseServiceProvider.Instance.GetAllVlasniciRacunara().Select(x => String.Format(x.JMBG_vl.ToString() + "\n" + x.Ime_vl + " " + x.Prezime_vl))); ;
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
        public ObservableCollection<string> Servisi
        {
            get
            {
                return new ObservableCollection<string>(DatabaseServiceProvider.Instance.GetAllServiss().Select(x => String.Format(x.Naziv_serv)));
            }
            set
            {
                if (servisi != value)
                {
                    servisi = value;
                    OnPropertyChanged(nameof(Servisi));
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
        

        
        public string BrojRacunara
        {
            get => brojRacunara;
            set
            {
                brojRacunara = value;
                OnPropertyChanged("BrojRacunara");
            }
        }
        public string BrPunVl
        {
            get => brPunVl;
            set
            {
                brPunVl = value;
                OnPropertyChanged("BrPunVl");
            }
        }
        public string NajstarijiRadnik
        {
            get => najstarijiRadnik;
            set
            {
                najstarijiRadnik = value;
                OnPropertyChanged("NajstarijiRadnik");
            }
        }
        public string NajskPop
        {
            get => najskPop;
            set
            {
                najskPop = value;
                OnPropertyChanged("NajskPop");
            }
        }
        public string CmbBoxVlasnici
        {
            get => cmbBoxVlasnici;
            set
            {
                cmbBoxVlasnici = value;
                OnPropertyChanged("CmbBoxVlasnici");
                RetNumPCCommand.RaiseCanExecuteChanged();
                
            }
        }
        public string CmbBoxServisi
        {
            get => cmbBoxServisi;
            set
            {
                cmbBoxServisi = value;
                OnPropertyChanged("CmbBoxServisi");
                ReturnTheOldestWorkerCommand.RaiseCanExecuteChanged();
                
            }
        }

        public string CmbBoxVrsteRacunara
        {
            get => cmbBoxVrsteRacunara;
            set
            {
                cmbBoxVrsteRacunara = value;
                OnPropertyChanged("CmbBoxVrsteRacunara");
                RetNumPCCommand.RaiseCanExecuteChanged();

            }
        }
        private bool CanRetNumPCCommand()
        {
            
            return !String.IsNullOrEmpty(CmbBoxVrsteRacunara) &&
                   !String.IsNullOrEmpty(CmbBoxVlasnici);
        }
        private bool CanReturnTheOldestWorkerCommand()
        {
            
            return !String.IsNullOrEmpty(CmbBoxServisi);
        }

        private void OnRetNumPCCommand()
        {
            try
            {
                long jmbg = long.Parse(CmbBoxVlasnici.Split('\n')[0], CultureInfo.InvariantCulture);
                Vrsta_racunara vr = (Vrsta_racunara)Enum.Parse(typeof(Vrsta_racunara), CmbBoxVrsteRacunara);

                BrojRacunara = DatabaseServiceProvider.Instance.ReturnNumberOfUserComputersByType(jmbg, vr).ToString();
                OnPropertyChanged("BrojRacunara");
            }
            catch (Exception e)
            {

            }
        }

    
        private void OnRetMaxPriceCommand()
        {
            try
            {
                
                SqlUpitVlasnikServisCijena retVal = DatabaseServiceProvider.Instance.ReturnOwnerWithMaxRepairPrice();
                if (retVal != null)
                    NajskPop = retVal.ToString();
                else
                    NajskPop = "0";
                OnPropertyChanged("NajskPop");
                
            }
            catch (Exception e)
            {

            }
        }

        private void OnRetAdultsCommand()
        {
            try
            {

                int isg = DatabaseServiceProvider.Instance.ReturnCountOfAdultOwners();
                BrPunVl = isg.ToString();
                OnPropertyChanged("BrPunVl");

            }
            catch (Exception e)
            {

            }
        }

        private void OnReturnTheOldestWorkerCommand()
        {
            try
            {

                string s = DatabaseServiceProvider.Instance.ReturnTheOldestWorker(CmbBoxServisi);
                NajstarijiRadnik = s != null ? s : "U servisu nema zaposlenih servisera";
                OnPropertyChanged("NajstarijiRadnik");

            }
            catch (Exception e)
            {

            }
        }

    }
}
